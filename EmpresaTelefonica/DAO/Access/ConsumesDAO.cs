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
    public class ConsumesDAO : Repository<Consumes>, IConsumesDAO
    {
        public List<Consumes> Search(System.Linq.Expressions.Expression<Func<Consumes, bool>> whereExpression, int page = 1, int size = 10, string[] includes = null)
        {
            return base.Search(whereExpression);
        }

        public Consumes Create(Consumes entity)
        {
            return base.Create(entity);
        }

        public Consumes Update(Consumes entity)
        {
            return base.Update(entity);
        }

        public void Delete(Consumes entity)
        {
            base.Delete(entity);
        }
        
        public Consumes Get(int id)
        {
            return base.Find(id);
        }
    }
}
