using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class updateChestM
    {
        public bool update(string str1, string str2)
        {
            try
            {
                SqlConnection coon = new SqlConnection();
                coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                cmd.CommandText = "update Chest set M='" + str1 + "' where chestNum='" + str2 + "' ";
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