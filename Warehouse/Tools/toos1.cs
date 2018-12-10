using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class toos1
    {
        public int query(string roomNum)  //查询符合条件某一列的和
        {
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select * into #a from Chest where roomNum='" + roomNum + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select count(*) from #a where 1=1";
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            int mm = 0;
            for (int i = 1; i <= a; i++)
            {
                cmd.CommandText = "select top(" + i + ") num, M into #b from #a order by num asc";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top (1) M from #b order by num desc";
                mm += Convert.ToInt32(cmd.ExecuteScalar());
            }
            return mm;
        }
    }
}