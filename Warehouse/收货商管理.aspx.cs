using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse
{
    public partial class 收货商管理 : System.Web.UI.Page
    {
        public static string name = null;           //记录下来查询的时候输入的供货商的名字
        public static string num = null;           //记录下来修改的时候需要修改的编号
        public static int countPageIndex = 1;         //记录下gridview的总页数
        public static int PageIndex = 1;               //当前的页数
        public static string providerName;              //记录下用来判断修改的时候收货商名字有没有修改
        public static List<Receiver> pros = new Warehouse.Controllor.Receiver_Controllor().getrec();         //记录下来全部的收货商，避免重复查询
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                add.Visible = false;
                databind();
                refresh();
                new Warehouse.Tools.AddSysLog().addlog("1", "收货商管理", "查询");

            }

            ButtonField bf88 = GridView1.Columns[9] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White;
            ButtonField bf99 = GridView1.Columns[10] as ButtonField; bf99.ControlStyle.BorderStyle = BorderStyle.None; bf99.ControlStyle.BackColor = System.Drawing.Color.White;

        }

        public void databind()
        {


            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
            BoundField bf2 = new BoundField(); bf2.DataField = "ReceiverNum"; bf2.HeaderText = "收货商编号";
            BoundField bf3 = new BoundField(); bf3.DataField = "ReceiverName"; bf3.HeaderText = "收货商名称";
            BoundField bf4 = new BoundField(); bf4.DataField = "Leader"; bf4.HeaderText = "负责人";
            BoundField bf5 = new BoundField(); bf5.DataField = "Contact"; bf5.HeaderText = "联系人";
            BoundField bf6 = new BoundField(); bf6.DataField = "ContactNumber"; bf6.HeaderText = "联系方式";
            BoundField bf7 = new BoundField(); bf7.DataField = "ReceiverAddress"; bf7.HeaderText = "地址";
            BoundField bf8 = new BoundField(); bf8.DataField = "CreateTime"; bf8.HeaderText = "创建时间";
            BoundField bf9 = new BoundField(); bf9.DataField = "UpdateTime"; bf9.HeaderText = "更新时间";

            GridView1.Columns.Add(bf1);
            GridView1.Columns.Add(bf2);
            GridView1.Columns.Add(bf3);
            GridView1.Columns.Add(bf4);
            GridView1.Columns.Add(bf5);
            GridView1.Columns.Add(bf6);
            GridView1.Columns.Add(bf7);
            GridView1.Columns.Add(bf8);
            GridView1.Columns.Add(bf9);

            ButtonField bf11 = new ButtonField(); bf11.CommandName = "editt"; bf11.Text = "编辑"; bf11.ControlStyle.BorderStyle = BorderStyle.None; bf11.ControlStyle.BackColor = System.Drawing.Color.White; bf11.ButtonType = ButtonType.Button; bf11.HeaderText = "";
            ButtonField bf12 = new ButtonField(); bf12.CommandName = "deletee"; bf12.Text = "删除"; bf12.ControlStyle.BorderStyle = BorderStyle.None; bf12.ControlStyle.BackColor = System.Drawing.Color.White; bf12.ButtonType = ButtonType.Button; bf12.HeaderText = "";

            GridView1.Columns.Add(bf11);
            GridView1.Columns.Add(bf12);
        }

        public void refresh()      //刷新函数，查找并显示全部的供应商的信息
        {
            if (name == null || name == "")          //判断name里面存的有没有值，有的话说明刚才查询过，现在gridview显示的查询名字后的，刷新的时候就不能查询全部
            {
                GridView1.DataSource = pros;
                GridView1.DataBind();
                countPageIndex = pros.Count / 11 + 1;
                Label8.Text = "总记录数:" + pros.Count;
                Label9.Text = "总页数:" + countPageIndex;
                Label10.Text = "当前页:" + PageIndex;
            }
            else
            {
                List<Receiver> recss = new List<Receiver>();           //若获取的单个对象，需要添加到集合中，因为gridview的数据源不支持单个对象
                Receiver pro = new DAL.ReceiverDAO().getReceiverByName(name);
                if (pro == null)
                { }
                else
                {
                    recss.Add(pro);
                }
                GridView1.DataSource = recss;
                GridView1.DataBind();
                countPageIndex = 1;
                PageIndex = 1;
                Label8.Text = "总记录数:" + recss.Count;
                Label9.Text = "总页数:1";
                Label10.Text = "当前页:" + PageIndex;
            }

            if (GridView1.Rows.Count == 0)
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("ReceiverNum");
                dt.Columns.Add("ReceiverName");
                dt.Columns.Add("Leader");
                dt.Columns.Add("Contact");
                dt.Columns.Add("ContactNumber");
                dt.Columns.Add("ReceiverAddress");
                dt.Columns.Add("CreateTime");
                dt.Columns.Add("UpdateTime");
                dt.Rows.Add(dt.NewRow());
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 3;
                GridView1.Rows[0].Cells[0].Text = "您查询的信息为空";
                GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
                Label8.Text = "总记录数:0";
                Label9.Text = "总页数:0";
                Label10.Text = "";
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            search.Visible = true;
            add.Visible = false;
            if (TextBox1.Text.Trim() == null || TextBox1.Text.Trim() == "")        //如果名字没输入就默认是查询全部的供应商
            {
                name = null;
            }
            else
            {
                name = TextBox1.Text.Trim();
            }
            GridView1.EditIndex = -1;     //防止在准备编辑一条记录的时候查询所有的信息造成的误编辑
            refresh();

        }


        protected void Button2_Click1(object sender, EventArgs e)
        {
            search.Visible = false;
            add.Visible = true;
            TextBox2.Text = "";
            TextBox6.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            Button3.Text = "确定添加";

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.Trim() == "" || TextBox3.Text.Trim() == "" || TextBox4.Text.Trim() == "" || TextBox5.Text.Trim() == "" || TextBox6.Text.Trim() == "")
            {
                Response.Write("<script>alert('信息都不能为空!')</script>");
            }
            else
            {
                if (num != null)            //判断num是否为空，不为空则说明是要修改信息，而不是添加
                {
                    Receiver r = new Receiver();
                    r.ReceiverName = num;
                    r.ReceiverName = TextBox2.Text.Trim();
                    if (providerName != TextBox2.Text.Trim())           //判断名字修改了没有（即和修改前记录的是否一样），如果名字改了需要判断是否重复
                    {
                        bool exit = new DAL.ReceiverDAO().hasReceiverOfName(r.ReceiverName);
                        if (exit)              //如果重复就提示
                        {
                            Response.Write("<script>alert('收货商名字重复，请重新输入!')</script>");
                        }
                        else
                        {
                            r.StaffName = TextBox6.Text.Trim();
                            r.Contact = TextBox3.Text.Trim();
                            r.ContactNumber = TextBox4.Text.Trim();
                            r.ReceiverAddress = TextBox5.Text.Trim();
                            r.UpdateTime = DateTime.Now;
                            bool success = new DAL.ReceiverDAO().updateReceiver(r);
                            if (success)
                            {
                                new Warehouse.Tools.AddSysLog().addlog("1", "收货商管理", "修改");
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);

                            }
                            else
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);

                            }
                            num = null;
                        }
                    }
                    else
                    {
                        r.StaffName = TextBox6.Text.Trim();
                        r.Contact = TextBox3.Text.Trim();
                        r.ContactNumber = TextBox4.Text.Trim();
                        r.ReceiverAddress = TextBox5.Text.Trim();
                        r.UpdateTime = DateTime.Now;
                        bool success = new DAL.ReceiverDAO().updateReceiver(r);
                        if (success)
                        {
                            new Warehouse.Tools.AddSysLog().addlog("1", "收货商管理", "修改");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);

                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);

                        }
                        num = null;
                    }
                }
                else
                {
                    
                    Receiver r = new Receiver();

                   
                    r.ReceiverName = TextBox2.Text.Trim();
                    bool exit = new DAL.ReceiverDAO().hasReceiverOfName(r.ReceiverName);
                    if (exit)
                    {
                        Response.Write("<script>alert('收货商名字重复，请重新输入!')</script>");
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        r.ReceiverNum = new Warehouse.Tools.receiverNum().protect_receiverNum(dt);
                        r.Contact = TextBox3.Text.Trim();
                        r.ContactNumber = TextBox4.Text.Trim();
                        r.ReceiverAddress = TextBox5.Text.Trim();
                        r.UpdateTime = dt;
                        r.StaffName = TextBox6.Text.Trim();
                        r.CreateTime = dt;
                        bool success = new DAL.ReceiverDAO().addReceiver(r);               //调用DAL层的添加方法

                        if (success)
                        {
                            new Warehouse.Tools.AddSysLog().addlog("1", "收货商管理", "添加");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                            TextBox2.Text = "";
                            TextBox6.Text = "";
                            TextBox3.Text = "";
                            TextBox4.Text = "";
                            TextBox5.Text = "";
                            search.Visible = true;
                            add.Visible = false;
                            refresh();
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败！');", true);
                        }
                    }
                }

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

        protected void Button4_Click(object sender, EventArgs e)
        {
            add.Visible = false;
            search.Visible = true;
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {

        }

        protected void Button4_Click1(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (GridView1.PageIndex == 0)
            {
                Response.Write("<script>alert('到头了！')</script>");
            }
            else
            {
                GridView1.PageIndex = 0;
                Label10.Text = "当前页:" + (GridView1.PageIndex + 1);
            }
            PageIndex = GridView1.PageIndex + 1;
            refresh();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (GridView1.PageIndex == 0)
            {
                Response.Write("<script>alert('到头了！')</script>");
            }
            else
            {
                GridView1.PageIndex = GridView1.PageIndex - 1;
                Label10.Text = "当前页:" + (GridView1.PageIndex + 1);
            }
            PageIndex = GridView1.PageIndex + 1;
            refresh();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (GridView1.PageIndex == countPageIndex - 1)
            {
                Response.Write("<script>alert('到底了！')</script>");
            }
            else
            {
                GridView1.PageIndex = GridView1.PageIndex + 1;
                Label10.Text = "当前页:" + (GridView1.PageIndex + 1);
            }
            PageIndex = GridView1.PageIndex + 1;
            refresh();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (GridView1.PageIndex == countPageIndex - 1)
            {
                Response.Write("<script>alert('到底了！')</script>");
            }
            else
            {
                GridView1.PageIndex = countPageIndex - 1;
                Label10.Text = "当前页:" + (GridView1.PageIndex + 1);
                PageIndex = GridView1.PageIndex + 1;
            }
            PageIndex = GridView1.PageIndex + 1;
            refresh();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {
                int xy = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[xy];

                search.Visible = false;
                add.Visible = true;
                Button3.Text = "确定修改";
                TextBox2.Text = row.Cells[2].Text;
                TextBox6.Text = row.Cells[3].Text;
                TextBox3.Text = row.Cells[4].Text;
                TextBox4.Text = row.Cells[5].Text;
                TextBox5.Text = row.Cells[6].Text;
                num = row.Cells[1].Text;
                providerName = row.Cells[2].Text;

            }
            if (e.CommandName == "deletee")
            {
                int x = Convert.ToInt32(e.CommandArgument);
                string dataid = GridView1.Rows[x].Cells[2].Text;
                bool success = new DAL.ReceiverDAO().deleteReceiverByName(dataid);
                if (success)
                {
                    new Warehouse.Tools.AddSysLog().addlog("1", "收货商管理", "删除");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
                }
                refresh();
            }
        }
    }
}