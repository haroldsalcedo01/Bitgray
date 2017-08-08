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
    public class UserDAO : Repository<User>, IUserDAO
    {
        
        public User Get(int id)
        {
            return base.Find(id);
        }

        public User Create(User entity)
        {
            return base.Create(entity);
        }

        public User Update(User entity)
        {
            return base.Update(entity); 
        }      

        public List<User> Search(Expression<Func<User, bool>> whereExpression)
        {
            return base.Search(whereExpression);
        }      

        public void Delete(User entity)
        {
            base.Delete(entity);
        }



        public User Read(string Phone)
        {
            User info = null;
            using (DAO.Context.Context context = new DAO.Context.Context())
            {
                info = context.User.FirstOrDefault(x => x.Phone == Phone);
            }
            return info;
        }

        
    }
}
