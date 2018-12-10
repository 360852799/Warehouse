using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
namespace Warehouse.Tools
{
    public class staffNum
    {
        public string protect_staffNum()
        {
            string Num = "";
            string x = "0000";
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Staff where 1=1";
            int y = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "select top " + y + " staffNum into #a from Staff where 1=1";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * into #b from #a where 1=1 order by staffNum desc";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select top(1) staffNum from #b where 1=1";
            object a = cmd.ExecuteScalar();
            try
            {
                string xx = a.ToString(); StringBuilder sb = new StringBuilder();
                string mm = xx.Substring(xx.Length - 4, 4);
                int k = 0;
                if (mm.Contains("000"))
                {
                    k = 3;
                }
                else if (mm.Contains("00"))
                {
                    k = 2;
                }
                else if (mm.Contains("0"))
                {
                    k = 1;
                }
                x = Convert.ToString(Convert.ToInt32(mm) + 1);
                if (k == 1)
                {
                    x = "0" + x;
                }
                else if (k == 2)
                {
                    x = "00" + x;
                }
                else if (k == 3)
                {
                    x = "000" + x;
                }
            }
            catch
            {
                x = "0001";
            }

            Num = "1" + x;
            return Num;
        }
    }
}