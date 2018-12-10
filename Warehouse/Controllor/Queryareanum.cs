using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Controllor
{
    public class Queryareanum
    {
        public string query(string str2)
        {
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select zone from City_2 where Second='" + str2 + "'";
            string mm = Convert.ToString(cmd.ExecuteScalar());
            return mm;
        }
        public string querys(string str2)
        {
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select Second from City where Third ='" + str2 + "'";
            string mm = Convert.ToString(cmd.ExecuteScalar());
            if (mm.Length > 0)
            {
                return mm;
            }
            else
            {
                return "";
            }
        }
        public string querying(string str1)
        {
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select Second from City where Third='" + str1 + "'";
            string mm = Convert.ToString(cmd.ExecuteScalar());
            return mm;
        }
    }

}