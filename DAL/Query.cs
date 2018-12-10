using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
   public class Query
    {
        public int query(string str1)//参数是表名
        {
            int m = 0;
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from " + str1 + " where 1=1";
            m = Convert.ToInt32(cmd.ExecuteScalar());
            return m;
        }
        public int querys(string str1,string str2,string str3)//str1是表名,str2是列名，str3是参数
        {
            int m = 0;
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from " + str1 + " where "+str2+"='"+str3+"'";
            m = Convert.ToInt32(cmd.ExecuteScalar());
            return m;
        }
    }
}
