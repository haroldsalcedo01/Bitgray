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
    public class Roles : IRoles
    {
        public DAOContainer DAO { get; set; }

        public VO.Entities.Roles Create(VO.Entities.Roles entity)
        {
            VO.Entities.Roles data = null;
            data = DAO.Resolve<RolesDAO>().Create(entity);
            return data;
        }

        public VO.Entities.Roles Update(VO.Entities.Roles entity)
        {
            VO.Entities.Roles data = null;
            data = DAO.Resolve<RolesDAO>().Create(entity);
            return data;
        }

        public VO.Entities.Roles Delete(int id)
        {
            VO.Entities.Roles data = DAO.Resolve<RolesDAO>().Get(id);
            DAO.Resolve<RolesDAO>().Delete(data);
            return data;
        }

        public List<VO.Entities.Roles> GetAllRoles()
        {
            List<VO.Entities.Roles> roles = null;

            Expression<Func<VO.Entities.Roles, bool>> whereExpression = (x => x.Id > 0);
            roles = DAO.Resolve<RolesDAO>().Search(whereExpression);
            return roles;       
        }
    }
}
