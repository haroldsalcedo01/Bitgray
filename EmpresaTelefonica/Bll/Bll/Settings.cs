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
    public class Settings : ISettings
    {
        public DAOContainer DAO { get; set; }

        public List<VO.Entities.Settings> GetAllConfigurations()
        {
            List<VO.Entities.Settings> settings = null;

            Expression<Func<VO.Entities.Settings, bool>> whereExpression = (x => x.Id > 0);
            settings = DAO.Resolve<SettingsDAO>().Search(whereExpression);
            return settings;       
        }

        public VO.Entities.Settings Create(VO.Entities.Settings entity)
        {
            VO.Entities.Settings data = null;
            data = DAO.Resolve<SettingsDAO>().Create(entity);
            return data;
        }

        public VO.Entities.Settings Update(VO.Entities.Settings entity)
        {
            VO.Entities.Settings data = null;
            data = DAO.Resolve<SettingsDAO>().Update(entity);
            return data;
        }

        public VO.Entities.Settings Delete(int id)
        {
            VO.Entities.Settings data = DAO.Resolve<SettingsDAO>().Get(id);
            DAO.Resolve<SettingsDAO>().Delete(data);
            return data;
        }
    }
}
