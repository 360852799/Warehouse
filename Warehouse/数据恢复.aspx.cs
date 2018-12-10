using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
public partial class 数据恢复 : System.Web.UI.Page
{
    public static List<DataCopy> dcs = new Warehouse.Controllor.DataRecovery_Controllor().getDataCopy();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
            BoundField bf2 = new BoundField(); bf2.DataField = "copyId"; bf2.HeaderText = "id"; bf2.Visible = false;
            BoundField bf3 = new BoundField(); bf3.DataField = "sysuser.userid"; bf3.HeaderText = "用户ID";
            BoundField bf4 = new BoundField(); bf4.DataField = "dataName"; bf4.HeaderText = "数据包名";
            BoundField bf5 = new BoundField(); bf5.DataField = "copyTime"; bf5.HeaderText = "时间";
            BoundField bf6 = new BoundField(); bf6.DataField = "copyType"; bf6.HeaderText = "类型";
            BoundField bf7 = new BoundField(); bf7.DataField = "copySize"; bf7.HeaderText = "大小(单位KB)";
            BoundField bf8 = new BoundField(); bf8.DataField = "copyState"; bf8.HeaderText = "状态";
            BoundField bf9 = new BoundField(); bf9.DataField = "copyjiance"; bf9.HeaderText = "检测";

            GridView1.Columns.Add(bf1);
            GridView1.Columns.Add(bf2);
            GridView1.Columns.Add(bf3);
            GridView1.Columns.Add(bf4);
            GridView1.Columns.Add(bf5);
            GridView1.Columns.Add(bf6);
            GridView1.Columns.Add(bf7);
            GridView1.Columns.Add(bf8);
            GridView1.Columns.Add(bf9);
            refresh();
            new Warehouse.Tools.AddSysLog().addlog("1", "数据恢复", "查询");
        }
    }

    public void refresh()
    {
        GridView1.DataSource = dcs;
        GridView1.DataBind();
        refreEmpty();
    }

    public void refreEmpty()
    {   
        if (GridView1.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("copyId");
            dt.Columns.Add("sysuser.userid");
            dt.Columns.Add("dataName");
            dt.Columns.Add("copyTime");
            dt.Columns.Add("copyType");
            dt.Columns.Add("copySize");
            dt.Columns.Add("copyState");
            dt.Columns.Add("copyjiance");
            dt.Rows.Add(dt.NewRow());
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 2;
            GridView1.Rows[0].Cells[0].Text = "您查询的信息为空";
            GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bool success = new DAL.DataCopyDAO().deleteCopyById(GridView1.DataKeys[e.RowIndex].Value.ToString());
        if (success)
        {
            new Warehouse.Tools.AddSysLog().addlog("1", "数据恢复", "删除");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
        }
        refresh();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[2].Text = id.ToString();

            if (e.Row.Cells[7].Text == "已恢复")
            {
                CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("CheckBox1");
                cb.Enabled = false;
            }
        }
   
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        
        int delcount = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)(GridView1.Rows[i].Cells[0].FindControl("CheckBox1"));
            if (cb.Checked)
            {
                DataCopy dc = new DataCopy();
                dc = new DAL.DataCopyDAO().getCopyById(GridView1.DataKeys[i].Value.ToString());
                dc.CopyState = "已恢复";
                DAL.DataCopyDAO dd = new DAL.DataCopyDAO();
                dd.updateCopy(dc);
                new Warehouse.Tools.AddSysLog().addlog("1", "数据恢复", "修改");
                delcount++;
            }

        }
        if (delcount != 0)
        {
            Response.Write("<script>alert('成功恢复" + delcount + "条数据')</script>");
            refresh();
        }
        else
        {
            Response.Write("<script>alert('请选择您要恢复的数据(一次只能恢复一页的数据)')</script>");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refresh();
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
       
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "")
        {
            List<DataCopy> dcc = new List<DataCopy>();
            DataCopy dc = new DAL.DataCopyDAO().getCopyByUserId(TextBox1.Text.Trim());
            if(dc!=null)
            dcc.Add(dc);           
            GridView1.DataSource = dcc;
            GridView1.DataBind();
            refreEmpty();
        }
        else
        {
            GridView1.DataSource = dcs;
            GridView1.DataBind();
            refreEmpty();
        }
    }
}