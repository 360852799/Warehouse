using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class positionSum
    {
        public double Sum(string chestNum)
        {
            double dd = 0;
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Position where chestNum='" + chestNum + "'";
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            for (int i = 1; i <= a; i++)
            {
                cmd.CommandText = "select top(" + i + ") num,M,Height into #a from Position  where chestNum='" + chestNum + "' order by num asc ";
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