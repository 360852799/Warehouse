using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 数据备份 : System.Web.UI.Page
{
    public static bool file_enable = false;               //字段名字表示文件是否选择
    public static List<DataCopy> dc = new Warehouse.Controllor.DataRecovery_Controllor().getDataCopy();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            datacontract();
            refresh();
            refreEmpty();
            add.Visible = false;
            new Warehouse.Tools.AddSysLog().addlog("1", "数据备份", "查询");
        }

        ButtonField bf88 = GridView1.Columns[8] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White;
        ButtonField bf99 = GridView1.Columns[9] as ButtonField; bf99.ControlStyle.BorderStyle = BorderStyle.None; bf99.ControlStyle.BackColor = System.Drawing.Color.White;

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refresh();
    }

    /// <summary>
    /// Gridview绑定数据源字段
    /// </summary>
    public void datacontract()
    {
        BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
        BoundField bf2 = new BoundField(); bf2.DataField = "copyId"; bf2.HeaderText = "数据包id";
        BoundField bf3 = new BoundField(); bf3.DataField = "dataName"; bf3.HeaderText = "数据包名";
        BoundField bf4 = new BoundField(); bf4.DataField = "copyTime"; bf4.HeaderText = "时间";
        BoundField bf5 = new BoundField(); bf5.DataField = "copyType"; bf5.HeaderText = "类型";
        BoundField bf6 = new BoundField(); bf6.DataField = "copySize"; bf6.HeaderText = "大小(单位KB)";
        BoundField bf7 = new BoundField(); bf7.DataField = "copyjiance"; bf7.HeaderText = "检测";
        BoundField bf8 = new BoundField(); bf8.DataField = "sysuser.staff.staffname"; bf8.HeaderText = "上传人";

        GridView1.Columns.Add(bf1);
        GridView1.Columns.Add(bf2);
        GridView1.Columns.Add(bf3);
        GridView1.Columns.Add(bf4);
        GridView1.Columns.Add(bf5);
        GridView1.Columns.Add(bf6);
        GridView1.Columns.Add(bf7);
        GridView1.Columns.Add(bf8);

        ButtonField bf11 = new ButtonField(); bf11.CommandName = "reup"; bf11.Text = "还原"; bf11.ControlStyle.BorderStyle = BorderStyle.None; bf11.ControlStyle.BackColor = System.Drawing.Color.White; bf11.ButtonType = ButtonType.Button; bf11.HeaderText = "";
        ButtonField bf12 = new ButtonField(); bf12.CommandName = "deletee"; bf12.Text = "删除"; bf12.ControlStyle.BorderStyle = BorderStyle.None; bf12.ControlStyle.BackColor = System.Drawing.Color.White; bf12.ButtonType = ButtonType.Button; bf12.HeaderText = "";

        GridView1.Columns.Add(bf11);
        GridView1.Columns.Add(bf12);
    }

    /// <summary>
    /// 刷新函数
    /// </summary>
    public void refresh()
    {     
        GridView1.DataSource = dc;
        GridView1.DataBind();
    }

    /// <summary>
    /// 判断GridView为空情况
    /// </summary>
    public void refreEmpty()
    {
        if (GridView1.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("copyId");
            dt.Columns.Add("dataName");
            dt.Columns.Add("copyTime");
            dt.Columns.Add("copyType");
            dt.Columns.Add("copySize");
            dt.Columns.Add("copyjiance");
            dt.Columns.Add("sysuser.staff.staffname");
            dt.Rows.Add(dt.NewRow());
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 3;
            GridView1.Rows[0].Cells[0].Text = "您查询的信息为空";
            GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
        }
    }

    public void clea()
    {
        TextBox1.Text = "";
        Label9.Text = "";
        Label2.Text = "";
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bool success = new DAL.DataCopyDAO().deleteCopyById(GridView1.DataKeys[e.RowIndex].Value.ToString());
        if (success)
        {
            new Warehouse.Tools.AddSysLog().addlog("1", "数据备份", "删除");
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
            e.Row.Cells[0].Text = id.ToString();  
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        refresh();
        refreEmpty();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        add.Visible = false;
        search.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
        if (!FileUpload1.HasFile)
        {
            Label2.Text = "请选择文件!";
        }
        else
        {
            if (TextBox1.Text.Trim() == "")
            {
                Label9.Text="请输入数据包类型!";
            }
            else
            {
                string filename = FileUpload1.PostedFile.FileName;
                FileInfo fi = new FileInfo(filename);
                String name = fi.Name;
                string type = fi.Extension;
                if (FileUpload1.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(filename);
                    if (extension.ToLower() != ".mdf")
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('只允许mdf！');", true);
                        Label2.Text = "只允许mdf！";
                    }
                    else
                    {
                        if (new DAL.DataCopyDAO().HaveSameDataCopyName(Path.GetFileNameWithoutExtension(filename)))
                        {
                            //Response.Write("<script>alert('数据包名字重复，请更换数据包或更改数据包名字!')</script>");
                            Label2.Text = "数据包名字重复!";
                        }
                        else
                        {
                            DataCopy dc = new DataCopy();
                            //dc.DataName = TextBox1.Text.Trim();

                            dc.DataName = Path.GetFileNameWithoutExtension(filename);
                            dc.CopyTime = DateTime.Now;
                            dc.CopySize = int.Parse(FileUpload1.PostedFile.ContentLength.ToString().Trim());
                            dc.CopyType = TextBox1.Text.Trim();
                            dc.CopyState = "未恢复";
                            dc.CopyLocation = Path.GetFullPath(FileUpload1.PostedFile.FileName);
                            int i = dc.CopyLocation.Length;
                            dc.SysUser = new DAL.SysUserDAO().getUserById("123");
                            bool success = new DAL.DataCopyDAO().addCopy(dc);
                            if (success)
                            {
                                new Warehouse.Tools.AddSysLog().addlog("1", "数据备份", "添加");

                                string savepath = Server.MapPath("~/DataPackage");
                                FileUpload1.PostedFile.SaveAs(savepath + "//" + name);
                                add.Visible = false;
                                search.Visible = true;
                                clea();
                                refresh();
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                            }
                        }
                    }
                }
            }
            
        }
        
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        
    }

    protected void Button8_Click(object sender, EventArgs e)                     //还原按钮
    {

    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        add.Visible = false;
        search.Visible = true;
        
        DataCopy daco;
        if (TextBox5.Text.Trim() != "")
        { 
            daco = new DAL.DataCopyDAO().getCopyByName(TextBox5.Text.Trim());
            if (dc == null)
            {

            }
            else
            {
                dc.Clear();
                dc.Add(daco);
            }
            
        }
        else
        {
            dc = new Warehouse.Controllor.DataRecovery_Controllor().getDataCopy();
        }

        //datacontract();
        GridView1.DataSource = dc;
        GridView1.DataBind();
        refreEmpty();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        add.Visible = true;
        search.Visible = false;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "reup")
        {
            
            int xy = Convert.ToInt32(e.CommandArgument);
            Model.Position pos = new DAL.PositionDAO().getPositionByNum(GridView1.Rows[xy].Cells[1].Text);
            add.Visible = false;
            search.Visible = false;

            Button btn = sender as Button;
            GridViewRow row = GridView1.Rows[xy];
            SysUser s = new DAL.SysUserDAO().getUserByNum(row.Cells[2].Text);
        }
        else if (e.CommandName == "deletee")
        {
            int x = Convert.ToInt32(e.CommandArgument);
            string dataid = GridView1.Rows[x].Cells[1].Text;
            string dataname = GridView1.Rows[x].Cells[2].Text;
            bool yy = new DAL.DataCopyDAO().deleteCopyById(dataid);
            if (yy)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                try
                {
                    File.Delete(@"~/DataPackage/" + dataname + ".mdf");
                }
                catch
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败,未找到文件！');", true);
                }
                dc = new Warehouse.Controllor.DataRecovery_Controllor().getDataCopy();
                
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
            
        }
        refresh();
    }
}