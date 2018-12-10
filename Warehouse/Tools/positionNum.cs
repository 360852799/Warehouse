using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Warehouse.Tools
{
    public class positionNum
    {
        public string protect_positionNum(string chestnum)
        {
            string Num = "";
            string x = "00";
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Position where chestNum='"+chestnum+"'";
            int y = Convert.ToInt32(cmd.ExecuteScalar());
            x = (Convert.ToInt32(x) + y+1).ToString();
            if (x.Length == 1)
            {
                x = "0" + x;
            }
            Num = chestnum + "W" + x;
            return Num;
        }
    }
}