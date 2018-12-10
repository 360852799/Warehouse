using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class RefreshListbox
    {
        public void Refresh(string str2, string str1,string str3, ListBox L1)//str1是文本,str2是值，str3 是表名
        {
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = "select "+str1+","+str2+" from "+str3+" where 1=1";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            L1.DataSource = ds.Tables[0].DefaultView;
            L1.DataTextField = str1;
            L1.DataValueField = str2;
            L1.DataBind();
        }
        public void Refresh2(string str2, string str1, string str3,string str4, ListBox L1)//str1是文本,str2是值，str3 是表名
        {
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = "select " + str1 + "," + str2 + " from " + str3 + " where departId='"+str4+"'";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            L1.DataSource = ds.Tables[0].DefaultView;
            L1.DataTextField = str1;
            L1.DataValueField = str2;
            L1.DataBind();
        }
        public void Refresh3(string str2, string str1, string str3, string str4, ListBox L1)//str1是文本,str2是值，str3 是表名
        {
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = "select " + str1 + "," + str2 + " from " + str3 + " where departId !='" + str4 + "'";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            L1.DataSource = ds.Tables[0].DefaultView;
            L1.DataTextField = str1;
            L1.DataValueField = str2;
            L1.DataBind();
        }
        public void Refreshh(string str1,string str2,string str3, ListBox L1)
        {
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = str1;
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            L1.DataSource = ds.Tables[0].DefaultView;
            L1.DataTextField = str2;
            L1.DataValueField = str3;
            L1.DataBind();
        }
        public void Refreshs(string str2, string str1, string str3,string str4,string str5, ListBox L1)//str1是文本,str2是值，str3 是表名,str4是查询的值 如查询表中属于该str4的,str5为roomNum,或者chestNum
        {
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = "select " + str1 + "," + str2 + " from " + str3 + " where "+str5+" = '"+str4+"'";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            L1.DataSource = ds.Tables[0].DefaultView;
            L1.DataTextField = str1;
            L1.DataValueField = str2;
            L1.DataBind();
        }
        public void Refreshss(string str1,string str2, string str3, string str4, ListBox L1)//str1:Second str2:City_2 str3:First str4:文本值
        {
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = "select " + str1+ " from " + str2 + " where " + str3 + " =   '"+str4 +"' ";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            L1.DataSource = ds.Tables[0].DefaultView;
            L1.DataTextField = str1;
            L1.DataValueField = str1;
            L1.DataBind();
        }
        public void Refreshsss(string str1, string str2, string str3, string str4, ListBox L1)//str1:Second str2:City_2 str3:First str4:文本值
        {
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = "select " + str1 + " from " + str2 + " where " + str3 + " =   '" + str4 + "' order by zone ";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            L1.DataSource = ds.Tables[0].DefaultView;
            L1.DataTextField = str1;
            L1.DataValueField = str1;
            L1.DataBind();
        }
    }
}