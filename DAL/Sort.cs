using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class Sort
    {
        public bool sort(string str1, string str2)//str1为表名,str2为主键
        {
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            DAL.Query nu = new Query();
            int count = nu.query(str1);
            try
            {
                for (int i = 1; i <= count; i++)
                {
                    cmd.CommandText = "update " + str1 + " set num='" + i + "' where " + str2 + "=( select max(t." + str2 + ") from (SELECT top (" + i + ") " + str2 + " FROM " + str1 + " order by " + str2 + ") t)";
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}