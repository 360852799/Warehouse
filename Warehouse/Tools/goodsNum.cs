using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Warehouse.Tools
{
    public class goodsNum
    {
        public string protect_goodsNum(string typeNum)
        {
            string Num = "";
            string x = "0001";
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Goods where goodsTypeNum='"+typeNum+"'";
            int y = Convert.ToInt32(cmd.ExecuteScalar());
            x = (Convert.ToInt32(x) + y).ToString();
            if (x.Length == 1)
            {
                x = "000" + x;
            }
            if (x.Length == 2)
            {
                x = "00" + x;
            }
            if (x.Length == 3)
            {
                x = "0" + x;
            }
            Num = typeNum + x;
            return Num;
        }
    }
}