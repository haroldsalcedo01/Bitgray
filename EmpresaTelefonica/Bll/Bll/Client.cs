using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Access;
using VO.Entities;
//using VO.ExceptionHandler;
using VO.Interfaces.BLL;

namespace Bll
{
   // [PrintException(typeof(Exception))]
    public class Client : IClients
    {
        public DAOContainer DAO { get; set; }

        
        public List<ClientUser> List(string word)
        {
            throw new NotImplementedException();
        }

        public ClientUser Create(ClientUser entity)
        {
            VO.Entities.ClientUser data = null;
            data = DAO.Resolve<ClientsDAO>().Create(entity);
            return data;
        }

        public ClientUser Update(ClientUser entity)
        {
            VO.Entities.ClientUser data = null;
            data = DAO.Resolve<ClientsDAO>().Update(entity);
            return data;
        }

        public ClientUser Delete(int id)
        {
            VO.Entities.ClientUser data = DAO.Resolve<ClientsDAO>().Get(id);
            DAO.Resolve<ClientsDAO>().Delete(data);
            return data;
        }


        public ClientUser Get(int userId)
        {
            return DAO.Resolve<ClientsDAO>().Get(userId);
        }
    }
}
