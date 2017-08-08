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
    public class RolesDAO : Repository<Roles>, IRolesDAO
    {
        public Roles Get(int id)
        {
            return base.Find(id);
        }

        public List<Roles> Search(System.Linq.Expressions.Expression<Func<Roles, bool>> whereExpression, int page = 1, int size = 10, string[] includes = null)
        {
            return base.Search(whereExpression);
        }             

        public Roles Create(Roles entity)
        {
            return base.Create(entity);
        }

        public Roles Update(Roles entity)
        {
            return base.Update(entity);
        }

        public void Delete(Roles entity)
        {
            base.Delete(entity);
        }

        
    }
}
