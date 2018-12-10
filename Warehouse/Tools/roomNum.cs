using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Warehouse.Tools
{
    public class roomNum
    {
        public string protect_roomNum()
        {
            int a = 0;
            int m = 0;
            int hj = 0;
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Room where 1=1";
            int y = Convert.ToInt32(cmd.ExecuteScalar());
            string[] xx = new string[y + 20];
            cmd.CommandText = "select top " + y + " num, roomNum into #a from Room where 1=1";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * into #b from #a where 1=1 order by num asc";
            cmd.ExecuteNonQuery();
            for (int mm = 1; mm <= y; mm++)
            {
                cmd.CommandText = "select roomNum from Room where roomNum=( select max(t.roomNum) from (SELECT top " + mm + " roomNum FROM Room order by roomNum) t)";
                xx[mm] = (cmd.ExecuteScalar()).ToString();
            }
            for (int l = 1; l <= y; l++)
            {
                int x = Convert.ToInt32(xx[l + 1]) - Convert.ToInt32(xx[l]);
                if (x > 1)
                {
                    m = Convert.ToInt32(xx[l]);
                    hj = 1;
                    break;
                }
            }
            if (hj == 0)
            {
                m = Convert.ToInt32(xx[y]);
            }
            if (m == 0)
            {
                m = 100;
            }
            return (m + 1).ToString();
        }
    }
}