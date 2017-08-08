using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO.Entities;
//using VO.ExceptionHandler;
using VO.Interfaces.DAO;

namespace DAO.Access
{
    //[PrintException(typeof(Exception))]
    public class RechargesDAO : Repository<Recharges>, IRechargesDAO
    {
        public List<Recharges> Search(System.Linq.Expressions.Expression<Func<Recharges, bool>> whereExpression, int page = 1, int size = 10, string[] includes = null)
        {
            return base.Search(whereExpression);
        }

        public Recharges Create(Recharges entity)
        {
            return base.Create(entity);
        }

        public Recharges Update(Recharges entity)
        {
            return base.Update(entity);
        }

        public void Delete(Recharges entity)
        {
            base.Delete(entity);
        }

        public Recharges Get(int id)
        {
            return base.Find(id);
        }

        public List<Recharges> GetRechargesByUserId(int userId)
        {
            List<Recharges> info = null;
            using (DAO.Context.Context context = new DAO.Context.Context())
            {
                info = context.Recharges.Where(x => x.UserId == userId).ToList();
            }
            return info;
        }
    }
}
