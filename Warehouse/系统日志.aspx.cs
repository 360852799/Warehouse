using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
public partial class 系统日志 : System.Web.UI.Page
{
    public static string userid = null;              //判断当前的查询出来的是不是根据ID查询出来的
    public static List<SysLog> syslog = new Warehouse.Controllor.Syslog_controllor().getSyslog();
    public static List<SysLog> ss = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
            BoundField bf2 = new BoundField(); bf2.DataField = "UserId"; bf2.HeaderText = "管理员ID";
            BoundField bf3 = new BoundField(); bf3.DataField = "IpAddress"; bf3.HeaderText = "IP地址";
            BoundField bf4 = new BoundField(); bf4.DataField = "ActionTime"; bf4.HeaderText = "操作时间";
            BoundField bf5 = new BoundField(); bf5.DataField = "Column"; bf5.HeaderText = "栏目";
            BoundField bf6 = new BoundField(); bf6.DataField = "ActionType"; bf6.HeaderText = "操作类型";

            GridView1.Columns.Add(bf1);
            GridView1.Columns.Add(bf2);
            GridView1.Columns.Add(bf3);
            GridView1.Columns.Add(bf4);
            GridView1.Columns.Add(bf5);
            GridView1.Columns.Add(bf6);
            refresh();
            new Warehouse.Tools.AddSysLog().addlog("1", "系统日志", "查询");
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

    public void refresh()
    {
        if (userid == null)
        {
            GridView1.DataSource = syslog;
            GridView1.DataBind();
            refreEmpty();
        }
        else
        {
            GridView1.DataSource = ss;
            GridView1.DataBind();
            refreEmpty();
        }
    }

    /// <summary>
    /// gridview没有数据的时候进行操作
    /// </summary>
    public void refreEmpty()
    {
        if (GridView1.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId");
            dt.Columns.Add("IpAddress");
            dt.Columns.Add("ActionTime");
            dt.Columns.Add("Column");
            dt.Columns.Add("ActionType");
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

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        bool success = new DAL.SysLogDAO().deleteAllLogs();
        if (success)
        {
            new Warehouse.Tools.AddSysLog().addlog("1", "系统日志", "删除");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
            syslog = new Warehouse.Controllor.Syslog_controllor().getSyslog();
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
        }
        refresh();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refresh();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "")
        {
            userid = TextBox1.Text.Trim();
            ss = new DAL.SysLogDAO().getLogsByUserId(TextBox1.Text.Trim());
            GridView1.DataSource = ss;
            GridView1.DataBind();
            refreEmpty();
        }
        else
        {
            userid = null;
            GridView1.DataSource = syslog;
            GridView1.DataBind();
            refreEmpty();
        }

    }
}