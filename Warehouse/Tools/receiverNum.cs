using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Text;

namespace Warehouse.Tools
{
    public class receiverNum
    {
        public string protect_receiverNum(DateTime kk)
        {
            string Num = "";
            string g = "00";
            StringBuilder sb=new StringBuilder ();
            StringBuilder sb1 = new StringBuilder();
            foreach (char j in Convert.ToString(kk))
            {
                if(Convert.ToInt32(j)>=47&&(Convert.ToInt32(j)<=57))
                {
                   sb1.Append(j);
                }
                if((Convert.ToInt32(j)==32))
                {
                    break;
                }
            }
            string xx = sb1.ToString();
            string x1 = "", x2 = "", x3 = "";
            foreach (char x in xx)
            {
                if (Convert.ToInt32(x) >= 48 && Convert.ToInt32(x) <= 57)
                {
                    sb.Append(x);
                }
                else if (Convert.ToInt32(x) == 47)
                {
                    break;
                }
            }
            x1 = sb.ToString();
            string yy1 = xx.Substring(sb.Length + 1, xx.Length - sb.Length - 1);
            sb.Remove(0, sb.Length);
            foreach (char x in yy1)
            {
                if (Convert.ToInt32(x) >= 48 && Convert.ToInt32(x) <= 57)
                {
                    sb.Append(x);
                }
                else if (Convert.ToInt32(x) == 47)
                {
                    break;
                }
            }
            x2 = sb.ToString();
            string zz = yy1.Substring(sb.Length + 1, yy1.Length - sb.Length - 1);
            sb.Remove(0, sb.Length);

            foreach (char x in zz)
            {
                if (Convert.ToInt32(x) >= 48 && Convert.ToInt32(x) <= 57)
                {
                    sb.Append(x);
                }
                else if (Convert.ToInt32(x) == 47)
                {
                    break;
                }
            }
            x3 = sb.ToString();
            if (x2.Length != 2)
            {
                x2 = "0" + x2;
            }
            if (x3.Length != 2)
            {
                x3 = "0" + x3;
            }
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select count(*) from  Receiver where createTime ='" + kk + "'";
            int m = Convert.ToInt32(cmd.ExecuteScalar());
            g = (Convert.ToInt32(g) + m+1).ToString();
            if (g.Length == 1)
            {
                g = "0" + g;
            }
            Num = "10" + x1 + x2 + x3 + g;
            return Num;
        }
    }
}