using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class departNum
    {
        public string Num()
        {
            string xx = "001";
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Department where 1=1";
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
            coon.Dispose();
            return xx;
        }
    }
}