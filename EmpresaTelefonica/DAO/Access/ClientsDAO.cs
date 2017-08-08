using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VO.Entities;
//using VO.ExceptionHandler;
using VO.Interfaces.DAO;

namespace DAO.Access
{
    //[PrintException(typeof(Exception))]
    public class ClientsDAO : Repository<ClientUser>, IClientsDAO
    {


        public ClientUser Create(ClientUser entity)
        {
            return base.Create(entity);
        }

        public ClientUser Update(ClientUser entity)
        {
            return base.Update(entity);
        }

        public void Delete(ClientUser entity)
        {
            base.Delete(entity);
        }

        public List<ClientUser> Search(Expression<Func<ClientUser, bool>> whereExpression, int page, int size, string[] includes)
        {
            return base.Search(whereExpression);
        }

        public ClientUser Get(int userId)
        {

            ClientUser info = null;
            using (DAO.Context.Context context = new DAO.Context.Context())
            {
                info = context.ClientUser.FirstOrDefault(x => x.UserId == userId);
            }
            return info;
        }
    }
}
