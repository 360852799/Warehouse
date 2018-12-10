using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
namespace Warehouse.Controllor
{
    public class DataRecovery_Controllor
    {
        public static List<DataCopy> dcs = null;
        public DataRecovery_Controllor()
        {
            dcs = new DAL.DataCopyDAO().getAllCopy();
        }

        public List<DataCopy> getDataCopy()
        {
            return dcs;
        }
    }
}