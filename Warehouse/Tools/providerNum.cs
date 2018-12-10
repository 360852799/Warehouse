using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Warehouse.Tools
{
    public class providerNum
    {
        public string protect_providerNum(string x1, string x2)
        {
            string Num = "";
            string x = "00";
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            x1 = "%" + x1 + "%";
            cmd.CommandText = "select * from  Provider into #a where providerNum like'" + x1 + "'";
            cmd.CommandText = "select count(*) from #a where 1=1";
            int y = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "select top " + y + " providerNum into #b from #a where 1=1";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * into #c from #b where 1=1 order by providerNum desc";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select top(1) providerNum from #c where 1=1";
            object a = cmd.ExecuteScalar();
            string xx = a.ToString();
            int l = 0;
            string mm = xx.Substring(xx.Length - 2, 2);
            int k = 0;
            if (mm.Contains("0"))
            {
                k = 1;
            }
            x = Convert.ToString(Convert.ToInt32(mm) + 1);
            if (k == 1)
            {
                x = "0" + x;
            }
            Num = x1 + x;
            return Num;
        }
    }
}