using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Warehouse.Tools
{
    public class chestNum
    {
        public string protect_chestNum(string roomNum)
        {
            string x = "001";
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from Chest where roomNum='" + roomNum + "'";
            int y = Convert.ToInt32(cmd.ExecuteScalar());
            if (y > 0)
            {
                for (int i = 1; i <= y+1; i++)
                {
                    cmd.CommandText = "select top(" + i + ") num,chestNum into #a from Chest  where roomNum='" + roomNum + "' order by num asc ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select top(1) chestNum from #a where 1=1 order by num desc";
                    string chestNum = Convert.ToString(cmd.ExecuteScalar());
                    cmd.CommandText = "drop table #a";
                    cmd.ExecuteNonQuery();
                    string chestNums = chestNum.Substring(4, 3);
                    int a = Convert.ToInt32(chestNums);
                    if (a != i)
                    {
                        x = "00" + i;
                        break;
                    }
                    else if (a == i)
                    {
                        continue;
                    }
                }
            }
            else
            {
                x = "001";
            }
            return roomNum + "G" + x;
        }
    }
}