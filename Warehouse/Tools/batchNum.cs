using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class batchNum
    {
        /// <summary>
        /// 返回唯一的批次编号，如果出错或找不到返回null
        /// </summary>
        /// <param name="type">操作类型：收货或者供货</param>
        /// <returns></returns>
        public string protect_batchNum(string type,DateTime s)
        {
            string Num = "";
            string ff="00";
            if (type == "收货")
            {
                ff = "10";

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string xx = s.ToString("yyyy/MM/dd");
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
                string g = "001";
                SqlConnection coon = new SqlConnection();
                coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                xx = "%" + x1 + x2 + x3 + "%";
                cmd.CommandText = "select count(*) from Inin where batchNum like'" + xx + "'";
                int y = Convert.ToInt32(cmd.ExecuteScalar());
                g = (Convert.ToInt32(g) + y).ToString();
                if (g.Length == 1)
                {
                    g = "00" + g;
                }
                if (g.Length == 2)
                {
                    g = "0" + g;
                }
                Num = x1 + x2 + x3 + "1010" + g;
            }
            else if (type == "供货")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string xx = s.ToString("yyyy/MM/dd");
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
                string g = "001";
                SqlConnection coon = new SqlConnection();
                coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
                coon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = coon;
                xx = "%" + x1 + x2 + x3 + "%";
                cmd.CommandText = "select count(*) from Outout where batchNum like'" + xx + "'";
                int y = Convert.ToInt32(cmd.ExecuteScalar());
                g = (Convert.ToInt32(g) + y).ToString();
                if (g.Length == 1)
                {
                    g = "00" + g;
                }
                if (g.Length == 2)
                {
                    g = "0" + g;
                }
                Num = x1 + x2 + x3 + "1111" + g;
            }
            return Num;
        }


        /// <summary>
        /// 返回唯一的批次编号，如果出错或找不到返回null By王朋博
        /// </summary>
        /// <param name="type">操作类型：收货或者供货</param>
        /// <returns></returns>
        public string protect_batchNumByWPB(string type)
        {
            string batchNum = "";
            string date = Warehouse.Tools.GeneralTools.getDateNow();
            if (type == "收货")
            {
                batchNum += date + "1010";
            }
            else if (type == "供货")
            {
                batchNum += date + "1111";
            }

            string sql = "select top 1 batchnum from batch where batchnum like '" + batchNum + "%'";
            object result = DAL.DBTools.exescalarSQL(sql,new List<SqlParameter> ());
            if (result == null)
            {
                return batchNum += "001";
            }
            else
            {
                string endnum = result.ToString().Substring(12,3);
                int i = int.Parse(endnum);
                if (i < 9)
                {
                    return batchNum + "00" + (i + 1);
                }
                else if (i < 99)
                {
                    return batchNum + "0" + (i + 1);
                }
                else if (i < 999)
                {
                    return batchNum + i;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}