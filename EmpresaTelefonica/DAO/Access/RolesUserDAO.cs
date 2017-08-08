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
    public class RolesUserDAO : Repository<RolesUser>, IRolesUserDAO
    {
        public List<RolesUser> Search(System.Linq.Expressions.Expression<Func<RolesUser, bool>> whereExpression, int page = 1, int size = 10, string[] includes = null)
        {
            return base.Search(whereExpression);
        }

        public RolesUser Create(RolesUser entity)
        {
            return base.Create(entity);
        }

        public RolesUser Update(RolesUser entity)
        {
            return base.Update(entity);
        }

        public void Delete(RolesUser entity)
        {
            base.Delete(entity);
        }

        public RolesUser Get(int id)
        {
            return base.Find(id);
        }
    }
}
