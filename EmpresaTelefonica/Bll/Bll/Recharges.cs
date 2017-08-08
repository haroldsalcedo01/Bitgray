using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Access;
using VO.Interfaces.BLL;
using System.Linq.Expressions;
using System.Data.Objects;

namespace Bll
{
    //[VO.ExceptionHandler.PrintException(typeof(Exception))]
    public class Recharges : IRecharges
    {
        private const int WEEK = -7;
        public DAOContainer DAO { get; set; }

        public List<VO.Entities.Recharges> GetRechargesByUserId(int userId)
        {
            List<VO.Entities.Recharges> roles = null;

            roles = DAO.Resolve<RechargesDAO>().GetRechargesByUserId(userId).ToList();
            return roles;
        }

        public VO.Entities.Recharges Create(VO.Entities.Recharges entity)
        {
            VO.Entities.Recharges data = null;
            data = DAO.Resolve<RechargesDAO>().Create(entity);
            return data;
        }

        public VO.Entities.Recharges Update(VO.Entities.Recharges entity)
        {
            VO.Entities.Recharges data = null;
            data = DAO.Resolve<RechargesDAO>().Create(entity);
            return data;
        }

        public VO.Entities.Recharges Delete(int id)
        {
            VO.Entities.Recharges data = DAO.Resolve<RechargesDAO>().Get(id);
            DAO.Resolve<RechargesDAO>().Delete(data);
            return data;
        }

        public VO.Entities.Recharges SimulateRecharge(int userId, decimal value)
        {
            VO.Entities.Recharges data = new VO.Entities.Recharges();            
            List<VO.Entities.Recharges> recharges = this.GetRechargesByUserId(userId);
            data = CalculateBonds(recharges, value);
            data.UserId = userId;
            data.DateRecharge = DateTime.Now;           
            return data;
        }

        public VO.Entities.Recharges Recharge(int userId, decimal value)
        {
            VO.Entities.Recharges data = new VO.Entities.Recharges();
            List<VO.Entities.Recharges> recharges = this.GetRechargesByUserId(userId);
            data = CalculateBonds(recharges, value);
            data.UserId = userId;
            data.DateRecharge = DateTime.Now;
            data = this.Create(data);
            VO.Entities.ClientUser client = DAO.Resolve<ClientsDAO>().Get(userId);
            client.Balance = client.Balance + data.TotalRecharge;
            DAO.Resolve<ClientsDAO>().Update(client);
            return data;
        }

        public VO.Entities.Recharges CalculateBonds(List<VO.Entities.Recharges> recharges, decimal value) 
        {

            VO.Entities.Recharges data = new VO.Entities.Recharges();

            if (recharges != null && recharges.Count > 0)
            {
                bool applyPromo = !recharges.Any(x => x.DateRecharge.Date == DateTime.Now.Date);

                decimal BondsValue = 0;

                if (applyPromo)
                {
                    decimal averageRecharges = recharges.Average(x => x.Value);

                    if (averageRecharges < value)
                    {
                        BondsValue = BondsValue + decimal.Multiply(value, 0.1M);
                    }
                    DateTime filterDate = DateTime.Now.Date;
                    System.Linq.Expressions.Expression<Func<VO.Entities.Recharges, bool>> whereExpression = (x => EntityFunctions.TruncateTime(x.DateRecharge) == filterDate);
                    List<VO.Entities.Recharges> generalRecharges = DAO.Resolve<RechargesDAO>().Search(whereExpression);
                    if (generalRecharges.Min(x => x.Value) > value)
                    {
                        List<VO.Entities.Recharges> aux = recharges.Where(x => x.Value == recharges.Min(y => y.Value)).ToList();
                        VO.Entities.Recharges minRecharge = aux.Where(x => x.DateRecharge == aux.Max(y => y.DateRecharge)).FirstOrDefault();

                        DateTime endDate = minRecharge.DateRecharge.Date;
                        DateTime initialDate = endDate.AddDays(WEEK);
                        aux = recharges.Where(x => x.DateRecharge.Date >= initialDate && x.DateRecharge.Date <= endDate).ToList();

                        decimal averageWeek = aux.Average(x => x.Value);

                        BondsValue = BondsValue + (decimal.Multiply(averageWeek, 0.05M));
                    }
                }

                data.Value = value;
                data.BondsValue = BondsValue;
                data.TotalRecharge = BondsValue + value;
                data.ApplyPromo = applyPromo;                
            }
            else
            {
                data.Value = value;
                data.BondsValue = 0;
                data.TotalRecharge= value;
                data.ApplyPromo = false;
            }

            return data;
        }
    }
}
