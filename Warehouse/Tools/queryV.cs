using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class queryV
    {
        public string query(string str1)
        {
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = str1;
            string mm = Convert.ToString(cmd.ExecuteScalar());
            return mm;
        }
    }
}