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
    //[PrintException(typeof(Exception))]
    public class RolesUsers : IRolesUsers
    {
        public DAOContainer DAO { get; set; }

        public List<VO.Entities.RolesUser> GetRolesByUserId(int userId)
        {
            List<VO.Entities.RolesUser> roles = null;

            Expression<Func<VO.Entities.RolesUser, bool>> whereExpression = (x => x.UserId == userId);
            roles = DAO.Resolve<RolesUserDAO>().Search(whereExpression);
            return roles;       
        }

        public VO.Entities.RolesUser Create(VO.Entities.RolesUser entity)
        {
            VO.Entities.RolesUser data = null;
            data = DAO.Resolve<RolesUserDAO>().Create(entity);
            return data;
        }

        public VO.Entities.RolesUser Update(VO.Entities.RolesUser entity)
        {
            VO.Entities.RolesUser data = null;
            data = DAO.Resolve<RolesUserDAO>().Create(entity);
            return data;
        }

        public VO.Entities.RolesUser Delete(int id)
        {
            VO.Entities.RolesUser data = DAO.Resolve<RolesUserDAO>().Get(id);
            DAO.Resolve<RolesUserDAO>().Delete(data);
            return data;
        }
    }
}
