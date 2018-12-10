using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
namespace Warehouse.Controllor
{
    public class Syslog_controllor
    {
        public static List<SysLog> syslog = null;
        public Syslog_controllor()
        {
            syslog = new DAL.SysLogDAO().getAllLogs();
        }

        public List<SysLog> getSyslog()
        {
            return syslog;
        }
    }
}