using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace Warehouse.Controllor
{
    public class ProviderControl
    {
        public static string GetNum()
        {
            int maxnum = int.Parse(Tools.GeneralTools.getMAXnum("provider", "providerNum"));
            string num = null;
            if(maxnum+1<10)
            {
                num = "0"+(maxnum+1).ToString();
            }
            else num=(maxnum+1).ToString();
            return "11"+Tools. GeneralTools.getDateNow() + num;
        }
    }
}