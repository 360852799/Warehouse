using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class chestSum
    {
        public double Sum(string roomNum)
        {
            double dd = 0;
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Chest where roomNum='" + roomNum + "'";
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            for (int i = 1; i <= a; i++)
            {
                cmd.CommandText = "select top(" + i + ") num,M,Height into #a from Chest  where roomNum='" + roomNum + "' order by num asc ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top(1) M from #a where 1=1 order by num desc";
                double M = Convert.ToDouble(cmd.ExecuteScalar());
                cmd.CommandText = "select top(1) Height from #a where 1=1 order by num desc";
                double H = Convert.ToDouble(cmd.ExecuteScalar());
                cmd.CommandText = "drop table #a";
                cmd.ExecuteNonQuery();
                dd += M * H;
            }
            return dd;
        }
    }
}