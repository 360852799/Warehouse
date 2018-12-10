using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class RefreshGridview
    {
        public void Refresh(string str1, string str2, GridView G1)//str1为sql语句，str2为查询列
        {
            G1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            G1.AutoGenerateColumns = false;
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = str1;
            SqlDataAdapter da = new SqlDataAdapter(sql, coon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ds.Tables[0].DefaultView.Sort = "num asc";
            G1.DataSource = ds.Tables[0];
            G1.DataBind();
        }
        public void Queryequal(string str1, string str2, string str3, GridView G1)//str1为查询列，str2为查询表，str3为文本数值(查询的参数)
        {
            G1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            G1.AutoGenerateColumns = false;
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = "select * from " + str2 + " where " + str1 + "='" + str3 + "'order by num ";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            ds.Tables[0].DefaultView.Sort = "num asc";
            G1.DataSource = ds.Tables[0];
            G1.DataBind();
        }
        public void Querylike(string str1, string str2, string str3, GridView G1)//str1为查询列，str2为查询表，str3为文本数值(查询的参数)
        {
            G1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            G1.AutoGenerateColumns = false;
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            str3 = "%" + str3 + "%";
            string sql = "select * from " + str2 + " where " + str1 + " like '" + str3 + "' order by num ";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            ds.Tables[0].DefaultView.Sort = "num asc";
            G1.DataSource = ds.Tables[0];
            G1.DataBind();
        }
        public void Querymt(string str1, string str2, string str3, GridView G1)//str1为查询列，str2为查询表，str3为文本数值(查询的参数)
        {
            G1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            G1.AutoGenerateColumns = false;
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            string sql = "select * from " + str2 + " where " + str1 + ">'" + str3 + "' order by num ";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            //ds.Tables[0].DefaultView.Sort = str2;
            ds.Tables[0].DefaultView.Sort = "num asc";
            G1.DataSource = ds.Tables[0];
            G1.DataBind();
        }
        public void Control_Refresh(GridView G1)//str1为sql语句，str2为查询列
        {
            G1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            G1.AutoGenerateColumns = false;
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select Goods.num,Goods.goodsNum,Goods.goodsName,Goodstype.goodsTypeName,amount.amount,amount.per,Goods.max into #a from Goods,Amount,Goodstype where (Goods.goodsNum=Amount.goodsNum and Goods.goodsTypeNum=Goodstype.goodsTypeNum)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "alter table #a add rest nvarchar(50)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select  num,goodsNum into #c from Amount ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select count(*) num,goodsNum into  #d from #c group by goodsNum";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select count(*) from #d";
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "drop table #c";
            cmd.ExecuteNonQuery();
            for (int i = 1; i <= count; i++)
            {
                double amount = 0;
                cmd.CommandText = "select top(" + i + ") num,goodsNum into #f from #d order by goodsNum asc";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top(1) num from #f order by goodsNum desc";
                int Count = Convert.ToInt32(cmd.ExecuteScalar()); 
                cmd.CommandText = "drop table #f";
                cmd.ExecuteNonQuery();
                for (int k = 1; k <= Count; k++)
                {
                    cmd.CommandText = "select top(" + k + ") num,amount into #b from #a where num=" + i + " order by amount asc ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select top(1) amount from #b where num=" + i + " order by amount desc ";
                    double x = Convert.ToDouble(cmd.ExecuteScalar());
                    amount += x;
                    cmd.CommandText = "drop table #b";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "update #a set amount='" + amount + "' where num='" + i + "' ";
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = "drop table #d";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update #a set rest = max-amount";
            cmd.ExecuteNonQuery();
            string sql = "select distinct * from #a";
            SqlDataAdapter da = new SqlDataAdapter(sql, coon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ds.Tables[0].DefaultView.Sort = "num asc";
            G1.DataSource = ds.Tables[0];
            G1.DataBind();
            cmd.CommandText = "drop table #a";
            cmd.ExecuteNonQuery();
        }
        public void Control_Refresh2(GridView G1)//str1为sql语句，str2为查询列
        {
            G1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            G1.AutoGenerateColumns = false;
            SqlConnection coon = new SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            coon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = coon;
            cmd.CommandText = "select Goods.num,Goods.goodsNum,Goods.goodsTypeNum,Goodstype.goodsTypeName,amount.amount,Goods.max,amount.per into #a from Amount,Goods,Goodstype where (Goods.goodsTypeNum=Goodstype.goodsTypeNum and Goods.goodsNum=Amount.goodsNum)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "alter table #a add rest nvarchar(50)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select  num,goodsNum into #c from Amount ";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select count(*) num,goodsNum into  #d from #c group by goodsNum";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select count(*) from #d";
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "drop table #c";
            cmd.ExecuteNonQuery();
            for (int i = 1; i <= count; i++)
            {
                double amount = 0;
                cmd.CommandText = "select top(" + i + ") num,goodsNum into #f from #d order by goodsNum asc";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select top(1) num from #f order by goodsNum desc";
                int Count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = "drop table #f";
                cmd.ExecuteNonQuery();
                for (int k = 1; k <= Count; k++)
                {
                    cmd.CommandText = "select top(" + k + ") num,amount into #b from #a where num=" + i + " order by amount asc ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select top(1) amount from #b where num=" + i + " order by amount desc ";
                    double x = Convert.ToDouble(cmd.ExecuteScalar());
                    amount += x;
                    cmd.CommandText = "drop table #b";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "update #a set amount='" + amount + "' where num='" + i + "' ";
                cmd.ExecuteNonQuery();
            }
            cmd.CommandText = "drop table #d";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update #a set rest = max-amount";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "alter table #a drop column goodsNum";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select count(*) num,goodsTypeNum into #g from #a group by goodsTypeNum";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select count(*) from #g";
            int a=Convert.ToInt32(cmd.ExecuteScalar());

            string sql = "select distinct * from #a";
            SqlDataAdapter da = new SqlDataAdapter(sql, coon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ds.Tables[0].DefaultView.Sort = "num asc";
            G1.DataSource = ds.Tables[0];
            G1.DataBind();
            cmd.CommandText = "drop table #a";
            cmd.ExecuteNonQuery();
        }
    }
}