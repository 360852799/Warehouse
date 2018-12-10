using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class update
    {
        public bool updates(string str1)
        {
            try
            {
                SqlConnection coon = new SqlConnection();
                coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandText = str1;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}