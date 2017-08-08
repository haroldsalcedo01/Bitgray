using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Access;
using VO.Interfaces.BLL;
using System.Linq.Expressions;
//using VO.ExceptionHandler;

namespace Bll
{
   // [PrintException(typeof(Exception))]
    public class Consumes : IConsumes
    {
        public DAOContainer DAO { get; set; }

        public List<VO.Entities.Consumes> GetConsumesByUserId(int UserId)
        {
            List<VO.Entities.Consumes> consumes = null;

            Expression<Func<VO.Entities.Consumes, bool>> whereExpression = (x => x.UserId == UserId);
            consumes = DAO.Resolve<ConsumesDAO>().Search(whereExpression).OrderBy(y => y.DateCall).ToList();
            return consumes;
        }

        public VO.Entities.Consumes Create(VO.Entities.Consumes entity)
        {
            VO.Entities.Consumes data = null;
            data = DAO.Resolve<ConsumesDAO>().Create(entity);
            return data;
        }

        public VO.Entities.Consumes Update(VO.Entities.Consumes entity)
        {
            VO.Entities.Consumes data = null;
            data = DAO.Resolve<ConsumesDAO>().Update(entity);
            return data;
        }

        public VO.Entities.Consumes Delete(int id)
        {
            VO.Entities.Consumes data = DAO.Resolve<ConsumesDAO>().Get(id);
            DAO.Resolve<ConsumesDAO>().Delete(data);
            return data;
        }

        public VO.Entities.Consumes Call(int userId, decimal seconds)
        {
            VO.Entities.Settings valueSecond = DAO.Resolve<SettingsDAO>().GetByKey("SecondValue");
            decimal valueCall = (seconds * decimal.Parse(valueSecond.Value));
            VO.Entities.Consumes newConsume = new VO.Entities.Consumes() {UserId = userId, DateCall = DateTime.Now, Time = seconds, ValueCall = valueCall };
            DAO.Resolve<ConsumesDAO>().Create(newConsume);
            VO.Entities.ClientUser user = DAO.Resolve<ClientsDAO>().Get(userId);
            user.Balance = user.Balance - valueCall;
            user.Balance = user.Balance < 0 ? 0 : user.Balance;
            return newConsume;

        }
    }
}
