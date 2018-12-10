using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;

public partial class 用户管理 : System.Web.UI.Page
{
    public static string num;
    public static List<SysUser> syss = new Warehouse.Controllor.Users_Controllor().getUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
            BoundField bf2 = new BoundField(); bf2.DataField = "userId"; bf2.HeaderText = "id"; bf2.Visible = false;
            BoundField bf3 = new BoundField(); bf3.DataField = "staffNum"; bf3.HeaderText = "用户编号";
            BoundField bf4 = new BoundField(); bf4.DataField = "staff.staffname"; bf4.HeaderText = "用户名称";
            BoundField bf5 = new BoundField(); bf5.DataField = "staff.idCard"; bf5.HeaderText = "身份证号";
            BoundField bf6 = new BoundField(); bf6.DataField = "staff.phoneNumber"; bf6.HeaderText = "联系方式";
            BoundField bf7 = new BoundField(); bf7.DataField = "job"; bf7.HeaderText = "身份";
            BoundField bf8 = new BoundField(); bf8.DataField = "staff.gender"; bf8.HeaderText = "性别";
            BoundField bf9 = new BoundField(); bf9.DataField = "staff.hometown"; bf9.HeaderText = "地址";
            BoundField bf10 = new BoundField(); bf10.DataField = "staff.department.departName"; bf10.HeaderText = "隶属部门";

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


            ButtonField bf11 = new ButtonField(); bf11.CommandName = "editt"; bf11.Text = "编辑"; bf11.ControlStyle.BorderStyle = BorderStyle.None; bf11.ControlStyle.BackColor = System.Drawing.Color.White; bf11.ButtonType = ButtonType.Button; bf11.HeaderText = "";
            ButtonField bf12 = new ButtonField(); bf12.CommandName = "deletee"; bf12.Text = "删除"; bf12.ControlStyle.BorderStyle = BorderStyle.None; bf12.ControlStyle.BackColor = System.Drawing.Color.White; bf12.ButtonType = ButtonType.Button; bf12.HeaderText = "";
            
            GridView1.Columns.Add(bf11);
            GridView1.Columns.Add(bf12);
            
            refresh();
            add.Visible = false;
            update.Visible = false;

            databind();
            new Warehouse.Tools.AddSysLog().addlog("1", "用户管理", "查询");
        }

        ButtonField bf88 = GridView1.Columns[10] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White;
        ButtonField bf99 = GridView1.Columns[11] as ButtonField; bf99.ControlStyle.BorderStyle = BorderStyle.None; bf99.ControlStyle.BackColor = System.Drawing.Color.White;

    }

    protected void Button2_Click(object sender, EventArgs e)          //重置密码按钮点击事件
    {
        clea();
        Button btn = sender as Button;
        GridViewRow row = (GridViewRow)btn.NamingContainer;

        //search.Visible = false;
        //update.Visible=true;
        num = row.Cells[1].Text;
        SysUser su = new DAL.SysUserDAO().getUserByNum(row.Cells[3].Text);
        su.Password = "000000";
        bool updatesuccess = new DAL.SysUserDAO().updateUser(su);
        if (updatesuccess)
        {
            new Warehouse.Tools.AddSysLog().addlog("1", "用户管理", "修改");
            Response.Write("<script>alert('重置成功!')</script>");
        }
        else
        {
            Response.Write("<script>alert('重置失败!')</script>");
        }

    }

    protected void Button3_Click(object sender, EventArgs e)           //编辑按钮点击事件
    {
        
          
    }

    protected void Button1_Click(object sender, EventArgs e)          //新增用户按钮点击事件
    {
        search.Visible = false;
        update.Visible = false;
        add.Visible = true;
        clea();
        //Button5.Text = "确定添加";
        //Button6.Text = "取消添加";
    }

    /// <summary>
    /// 刷新函数
    /// </summary>
    public void refresh()
    {        
        GridView1.DataSource = syss;
        GridView1.DataBind();
        refreEmpty();
    }

    /// <summary>
    /// 操作GridView为空的情况
    /// </summary>
    public void refreEmpty()
    {
        if (GridView1.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("userId");
            dt.Columns.Add("staffNum");
            dt.Columns.Add("staff.staffName");
            dt.Columns.Add("staff.idCard");
            dt.Columns.Add("staff.phoneNumber");
            dt.Columns.Add("job");
            dt.Columns.Add("staff.gender");
            dt.Columns.Add("staff.hometown");
            dt.Columns.Add("staff.department.departName");
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

    public void clea()
    {
        //修改清空
        TextBox2.Text="";
        TextBox6.Text="";
        TextBox3.Text="";
        TextBox4.Text="";
        TextBox5.Text="";

        //添加清空
        TextBox1.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
    }

    /// <summary>
    /// 清空label提示
    /// </summary>
    public void cleartip()
    {
        Label1.Text = "";
        Label6.Text = "";
        Label8.Text = "";
        Label9.Text = "";
        Label10.Text = "";

        Label27.Text = "";
        Label12.Text = "";
        Label14.Text = "";
        Label16.Text = "";
        Label19.Text = "";
    }

    /// <summary>
    /// 绑定dropdownlist数据源
    /// </summary>
    public void databind()
    {
        //List<Department> dep = new DAL.DepartmentDAO().getAllDeparts();
        //DropDownList3.DataSource = dep;
        //DropDownList3.DataTextField = "departName";
        //DropDownList3.DataValueField = "departId";
        //DropDownList3.DataBind();
    }

    protected void Button6_Click(object sender, EventArgs e)             //取消修改按钮点击事件
    {
        add.Visible = false;
        search.Visible = true; 
        update.Visible = false;
        clea();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bool success = new DAL.SysUserDAO().deleteUserByNum(GridView1.DataKeys[e.RowIndex].Value.ToString());
        if (success)
        {
            new Warehouse.Tools.AddSysLog().addlog("1", "用户管理", "删除");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
        }
        refresh();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text.Trim() != "" && TextBox6.Text.Trim() != "" && TextBox3.Text.Trim() != "" && TextBox4.Text.Trim() != "" && TextBox5.Text.Trim() != ""&&TextBox11.Text.Trim() != "")
        {
            if (Button5.Text == "确定修改")             //修改信息的操作
            {
                if (TextBox5.Text.Length == 18)
                {
                    if (TextBox11.Text.Length <= 16 && TextBox11.Text.Length >= 6)
                    {
                        staff sf = new DAL.StaffDAO().getStaffByNum(TextBox6.Text.Trim());
                        sf.StaffName = TextBox3.Text.Trim();
                        sf.IdCard = TextBox4.Text.Trim();
                        sf.PhoneNumber = TextBox5.Text.Trim();

                        SysUser s = new DAL.SysUserDAO().getUserByNum(sf.StaffNum);
                        s.Password = TextBox11.Text;
                        bool sta = new DAL.StaffDAO().updateStaff(sf);
                        bool systa = new DAL.SysUserDAO().updateUser(s);
                        if (sta && systa)
                        {
                            new Warehouse.Tools.AddSysLog().addlog("1", "用户管理", "修改");
                            Response.Write("<script>alert('信息修改成功！')</script>");
                            add.Visible = false;
                            update.Visible = false;
                            search.Visible = true;
                            refresh();
                            clea();
                        }
                        else
                        {
                            Response.Write("<script>alert('信息修改失败！')</script>");
                        }
                    }

                    else
                    {
                        Label27.Text = "密码要在8-16位之间";
                    }
                }
                else
                {
                    Label10.Text = "身份证号长度为18位";
                }
                                
            }
            else                //添加用户的操作
            {
                
            }
        }
        else
        {
            Response.Write("<script>alert('所有信息不能为空！')</script>");
        }
    }


    protected void Button8_Click(object sender, EventArgs e)            //取消修改密码
    {
        update.Visible = false;
        add.Visible = false;
        search.Visible = true;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refresh();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void Button7_Click(object sender, EventArgs e)          //确认添加
    {
        cleartip();
        if (TextBox1.Text.Trim() == "" || TextBox7.Text.Trim() == "" || TextBox8.Text.Trim() == "" || TextBox9.Text.Trim() == "")
        {
            Response.Write("<script>alert('所有信息不能为空！')</script>");
        }
        else
        {
            if (TextBox7.Text.Trim() != TextBox8.Text.Trim())
            {
                Label16.Text = "两次输入的密码不一致";
            }
            else
            {
                staff sta = new DAL.StaffDAO().getStaffByNum(TextBox1.Text.Trim());
                if (sta == null)
                {
                    Label12.Text = "查无此人，请确定无误再输入";
                }
                else
                {
                    if (TextBox9.Text.Length == 18)
                    {
                        SysUser s = new DAL.SysUserDAO().getUserByNum(TextBox1.Text.Trim());
                        if (s != null)
                        {
                            Label12.Text = "此人已注册，请更换注册员工";
                        }
                        else
                        {
                            if (sta.IdCard != TextBox9.Text.Trim())
                            {
                                Label19.Text = "您输入的身份证号和本人不符，请重新输入";
                            }
                            else
                            {

                                SysUser su = new SysUser();
                                su.Job = DropDownList1.SelectedValue.ToString();
                                su.Password = TextBox7.Text.Trim();
                                su.StaffNum = TextBox1.Text.Trim();
                                bool addsuccess = new DAL.SysUserDAO().addUser(su);
                                if (addsuccess)
                                {
                                    new Warehouse.Tools.AddSysLog().addlog("1", "用户管理", "添加");
                                    Response.Write("<script>alert('注册成功')</script>");
                                    clea();
                                    refresh();
                                    update.Visible = false;
                                    add.Visible = false;
                                    search.Visible = true;
                                }
                                else
                                {
                                    Response.Write("<script>alert('注册失败！')</script>");
                                }
                            }
                        }
                    }
                    else
                    {
                        Label19.Text = "身份证格式不正确";
                    }
                }
            }

        }
    }

    protected void Button2_Click1(object sender, EventArgs e)         //取消添加
    {
        update.Visible = false;
        add.Visible = false;
        search.Visible = true;
        refresh();
        clea();
    }

    protected void Button8_Click1(object sender, EventArgs e)
    {
        List<SysUser> sus = new List<SysUser> () ;
        if (TextBox10.Text.Trim() != "")
        {

            SysUser su = new DAL.SysUserDAO().getUserByNum(TextBox10.Text.Trim());
           if (su != null)
               sus.Add(su);
        }
        else
        {
            sus = new DAL.SysUserDAO().getAllUsers();
        }
        new Warehouse.Tools.AddSysLog().addlog("1", "用户管理", "查询");
        GridView1.DataSource = sus;
        GridView1.DataBind();
        refreEmpty();
        update.Visible = false;
        add.Visible = false;
        search.Visible = true;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editt")
        {
            cleartip();
            int xy = Convert.ToInt32(e.CommandArgument);
            
            add.Visible = false;
            search.Visible = false;
            update.Visible = true;

            Button btn = sender as Button;
            GridViewRow row = GridView1.Rows[xy];
            SysUser s = new DAL.SysUserDAO().getUserByNum(row.Cells[2].Text);

            TextBox2.Text = s.UserId;
            TextBox6.Text = row.Cells[2].Text;
            TextBox3.Text = row.Cells[3].Text;
            TextBox4.Text = row.Cells[4].Text;
            TextBox5.Text = row.Cells[5].Text;
            TextBox11.Text = s.Password;
            
        }
        if (e.CommandName == "deletee")
        {
            int x = Convert.ToInt32(e.CommandArgument);
            string sysnum = GridView1.Rows[x].Cells[2].Text;
            bool yy = new DAL.SysUserDAO().deleteUserByNum(sysnum);
            if (yy)
            {
                new DAL.StaffDAO().deleteStaffByNum(sysnum);
                new Warehouse.Tools.AddSysLog().addlog("1", "用户管理", "删除");

                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                syss = new Warehouse.Controllor.Users_Controllor().getUsers();
                refresh();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }

    }
}