﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 入库日报 : System.Web.UI.Page
{
    public string dt = null;         //判断当前是否是条件搜索
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
            BoundField bf2 = new BoundField(); bf2.DataField = "inID"; bf2.HeaderText = "入库ID";
            BoundField bf3 = new BoundField(); bf3.DataField = "batch.batchNum"; bf3.HeaderText = "批次编号";
            BoundField bf4 = new BoundField(); bf4.DataField = "goods.goodsName"; bf4.HeaderText = "物品名称";
            BoundField bf5 = new BoundField(); bf5.DataField = "goods.goodsType.goodsTypeName"; bf5.HeaderText = "物品类别";
            BoundField bf6 = new BoundField(); bf6.DataField = "position.positionNum"; bf6.HeaderText = "库位编号";
            BoundField bf7 = new BoundField(); bf7.DataField = "date"; bf7.HeaderText = "入库时间";
            BoundField bf8 = new BoundField(); bf8.DataField = "inAmount"; bf8.HeaderText = "入库量";
            BoundField bf9 = new BoundField(); bf9.DataField = "goods.goodsper"; bf9.HeaderText = "单位";
            BoundField bf10 = new BoundField(); bf10.DataField = "batch.provider.providerName"; bf10.HeaderText = "供应商";
            BoundField bf11 = new BoundField(); bf11.DataField = "sysUser.staff.staffname"; bf11.HeaderText = "经办人";

            GridView1.Columns.Add(bf1);
            GridView1.Columns.Add(bf2);
            GridView1.Columns.Add(bf3);
            GridView1.Columns.Add(bf4);
            GridView1.Columns.Add(bf5);
            GridView1.Columns.Add(bf6);
            GridView1.Columns.Add(bf7);
            GridView1.Columns.Add(bf8);
            GridView1.Columns.Add(bf9);
            GridView1.Columns.Add(bf10);
            GridView1.Columns.Add(bf11);
            refreshAll();
            new Warehouse.Tools.AddSysLog().addlog("1", "入库日报", "查询");
        }
    }

    /// <summary>
    /// 刷新全部信息
    /// </summary>
    public void refreshAll()
    {
        if (dt == null)
        {

            List<Inin> dcs = new DAL.IninDAO().getAllIn();
            GridView1.DataSource = dcs;
            GridView1.DataBind();
            refreshEmpty();
        }
        else
        {
            DateTime d =DateTime.Parse(dt);
            List<Inin> dcs = new DAL.IninDAO().getInsByDate(d.ToShortDateString());
            GridView1.DataSource = dcs;
            GridView1.DataBind();
            refreshEmpty();
            
        }
    }

    /// <summary>
    /// 如果搜索结果为空则显示信息为空
    /// </summary>
    public void refreshEmpty()
    {
        if (GridView1.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("inID");
            dt.Columns.Add("batch.batchNum");
            dt.Columns.Add("goods.goodsName");
            dt.Columns.Add("goods.goodsType.goodsTypeName");
            dt.Columns.Add("position.positionNum");
            dt.Columns.Add("date");
            dt.Columns.Add("inAmount");
            dt.Columns.Add("goods.goodsper");
            dt.Columns.Add("batch.provider.providerName");
            dt.Columns.Add("sysUser.staff.staffname");
            dt.Rows.Add(dt.NewRow());
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 1;
            GridView1.Rows[0].Cells[0].Text = "您查询的信息为空";
            GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refreshAll();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() == "")
        {
            dt = null;
            refreshAll();
        }
        else
        {
            DateTime d;
            try
            {
                d = DateTime.Parse(TextBox1.Text.Trim());
                List<Inin> ins = new DAL.IninDAO().getInsByDate(d.ToShortDateString());
                GridView1.DataSource = ins;
                GridView1.DataBind();
                new Warehouse.Tools.AddSysLog().addlog("1", "入库日报", "查询");
                dt = TextBox1.Text.Trim();
                refreshEmpty();
            }
            catch
            {
                Response.Write("<script>alert('格式不正确，应输入例:2018-8-8!')</script>");
            }
        }
    } 

}