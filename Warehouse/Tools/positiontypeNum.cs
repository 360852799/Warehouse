using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Warehouse.Tools
{
    public class positiontypeNum
    {
        public string Num()
        {
            string xx="001";
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from PositionType where 1=1";
             int x = Convert.ToInt32(cmd.ExecuteScalar());
             xx = (Convert.ToInt32(xx) + x).ToString();
             if (xx.Length == 1)
             {
                 xx = "00" + xx;
             }
             if (xx.Length == 2)
             {
                 xx = "0" + xx;
             }
             return xx;
        }
    }
}