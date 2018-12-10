using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class OutoutNum
    {
        public string Num()
        {
            string x = "O000001";
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Outout where 1=1 ";
            int y = Convert.ToInt32(cmd.ExecuteScalar());
            if (y > 0)
            {
                for (int i = 1; i <= y + 1; i++)
                {
                    cmd.CommandText = "select top(" + i + ") num,outID into #a from Outout  where 1=1 order by num asc ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select top(1) outID from #a where 1=1 order by num desc";
                    string Num = Convert.ToString(cmd.ExecuteScalar());
                    cmd.CommandText = "drop table #a";
                    cmd.ExecuteNonQuery();
                    string Nums = Num.Substring(1, Num.Length - 1);
                    int a = Convert.ToInt32(Nums);
                    int length = a.ToString().Length;
                    if (a != i)
                    {
                        string k = "";
                        for (int m = 0; m < 6 - length; m++)
                        {
                            k += "0";
                        }
                        x = "O" + k + i;
                        break;
                    }
                    else if (a == i)
                    {
                        continue;
                    }
                }
            }
            else
            {
                x = "O000001";
            }
            return x;
        }
    }
}