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
    public class SettingsDAO : Repository<Settings>, ISettingsDAO
    {


        public Settings Create(Settings entity)
        {
            return base.Create(entity);
        }

        public Settings Update(Settings entity)
        {
            return base.Update(entity);
        }

        public void Delete(Settings entity)
        {
            base.Delete(entity);
        }

        public List<Settings> Search(System.Linq.Expressions.Expression<Func<Settings, bool>> whereExpression, int page, int size, string[] includes)
        {
            return base.Search(whereExpression);
        }

        public Settings Get(int id)
        {
            return base.Find(id);
        }

        public Settings GetByKey(string key)
        {
            try
            {
                System.Linq.Expressions.Expression<Func<Settings, bool>> whereExpression = (x => x.Key == key);
                return base.Search(whereExpression).FirstOrDefault();
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
        }
    }
}
