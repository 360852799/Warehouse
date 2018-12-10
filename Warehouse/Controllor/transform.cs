using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class transform
    {
        public void trans(string str1)
        {
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            int h = str1.Length;
            cmd.CommandText = "select count(*) from China where p='中国'";
            int m = Convert.ToInt32(cmd.ExecuteScalar());
            string xx = "", yy = "", mm = "", zz = "", gg = "";
            for (int i = 0; i < m; i++)
            {
                cmd.CommandText = "select s into #a from China where p='中国' ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top(" + (i + 1) + ") s into #b from #a order by s asc";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top(1) s from #b order by s desc ";
                xx = Convert.ToString(cmd.ExecuteScalar());
                cmd.CommandText = "drop table #a";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "drop table #b";
                cmd.ExecuteNonQuery();
                if (str1.Contains(xx) == true)
                {
                    System.Web.HttpContext.Current.Session["One"] = xx;
                    str1 = str1.Substring(xx.Length, str1.Length - xx.Length);
                    break;
                }
            }
            cmd.CommandText = "select count(*) from City_2 where First='" + xx + "'";
            int n = Convert.ToInt32(cmd.ExecuteScalar());
            int bb = 0;
            for (int k = 0; k < n; k++)
            {
                cmd.CommandText = "select zone,Second into #a from City_2 where First='" + xx + "' ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top(" + (k + 1) + ") zone, Second into #b from #a order by zone asc";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top(1) zone, Second into #c from #b order by zone desc ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top(1) Second from #c order by zone desc ";
                cmd.ExecuteNonQuery();
                yy = Convert.ToString(cmd.ExecuteScalar());
                if (str1.Contains(yy) == true)
                {
                    int hhh = 0;
                    cmd.CommandText = "select count(*) from City where Second='" + yy + "'";
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 1)
                    {
                        hhh = 1;
                    }
                    if (hhh == 0)
                    {
                        cmd.CommandText = "select zone from #c where second='" + yy + "' ";
                        gg = Convert.ToString(cmd.ExecuteScalar());
                        if (bb > 0)
                        {
                            System.Web.HttpContext.Current.Session["Twoo"] = yy;
                            System.Web.HttpContext.Current.Session["Twoozone"] = gg;
                            break;
                        }
                        bb++;
                        System.Web.HttpContext.Current.Session["Two"] = yy;
                        System.Web.HttpContext.Current.Session["Twozone"] = gg;
                    }
                }
                cmd.CommandText = "drop table #a";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "drop table #b";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "drop table #c";
                cmd.ExecuteNonQuery();
            }
            //if (str1 == yy)
            //{
            //    str1 = "";
            //}
            //if (str1.Length > 0)
            //{
            //    cmd.CommandText = "select count(*) from City_2 where First='" + xx + "'";
            //    int p = Convert.ToInt32(cmd.ExecuteScalar());
            //    for (int k = 0; k < p; k++)
            //    {
            //        int nn = 0;
            //        cmd.CommandText = "select zone,Second into #aa from City_2 where First='" + xx + "' ";
            //        cmd.ExecuteNonQuery();
            //        cmd.CommandText = "select top(" + (k + 1) + ") zone, Second into #bb from #aa order by zone asc";
            //        cmd.ExecuteNonQuery();
            //        cmd.CommandText = "select top(1) zone, Second into #cc from #bb order by zone desc ";
            //        cmd.ExecuteNonQuery();
            //        cmd.CommandText = "select top(1) Second from #cc order by zone desc ";
            //        cmd.ExecuteNonQuery();
            //        zz = Convert.ToString(cmd.ExecuteScalar());
            //        if (str1.Contains(yy) == true)
            //        {
            //            cmd.CommandText = "select zone from #cc where second='" + zz + "' ";
            //            gg = Convert.ToString(cmd.ExecuteScalar());
            //            if (nn > 0)
            //            {
            //                System.Web.HttpContext.Current.Session["Threee"] = zz;
            //                System.Web.HttpContext.Current.Session["Threeezone"] = gg;
            //            }
            //            nn++;
            //            System.Web.HttpContext.Current.Session["Three"] = zz;
            //            System.Web.HttpContext.Current.Session["Threeezone"] = gg;
            //        }
            //        cmd.CommandText = "drop table #aa";
            //        cmd.ExecuteNonQuery();
            //        cmd.CommandText = "drop table #bb";
            //        cmd.ExecuteNonQuery();
            //        cmd.CommandText = "drop table #cc";
            //        cmd.ExecuteNonQuery();
            //    }
        }
    }
}