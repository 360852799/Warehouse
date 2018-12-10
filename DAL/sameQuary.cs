using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class sameQuary
    {
        public bool quary(string str1, string str2, string str3)//str1为表名,str2为列名,str3为Text
        {
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from " + str1 + " where " + str2 + " ='" + str3 + "' ";
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            if (a > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
