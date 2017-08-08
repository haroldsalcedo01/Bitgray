using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO.Utils
{
    public class LogRegister
    {
        public static void RegisterLog(Exception ex) 
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory +  @"\log.txt"))
            {
                string format = "Fecha: {0} : Error : {1}";
                string date = DateTime.Now.ToString();
                file.WriteLine(string.Format(format, date, ex.Message));
            }
        }
    }
}
