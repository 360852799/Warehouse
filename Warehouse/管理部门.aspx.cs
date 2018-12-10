using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace Warehouse
{
    public partial class 管理部门 : System.Web.UI.Page
    {
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        Warehouse.Controllor.Depart_Bind db = new Controllor.Depart_Bind();
        Warehouse.Controllor.RefreshListbox rl = new Controllor.RefreshListbox();
        Warehouse.Tools.queryV qu = new Tools.queryV();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Sort so = new DAL.Sort();
            so.sort("Department", "departId");
           int a=Convert.ToInt32(qu.query("select count(*) from Department where 1=1"));
           TextBox6.Style["Rows"] = a.ToString();
            if (!IsPostBack)
            {
                Div1.Style["display"] = "none";
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            if (GridView1.Visible == true)
            {
                Button1.Visible = true;
                Button4.Visible = true;
                Button5.Visible = true;
                ListBox1.Visible = true;
                TextBox5.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Button1.Visible = false;
                Button4.Visible = false;
                Button5.Visible = false;
                ListBox1.Visible = false;
                TextBox5.Visible = false;
            }
            Div1.Style["display"] = "inline";
            Button9.Text = "增加";
            Image11.Visible = true;
            Image11.ImageUrl = "~/Image/对号.png";
        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            if (GridView1.Visible == true)
            {
                Button1.Visible = true;
                Button4.Visible = true;
                Button5.Visible = true;
                ListBox1.Visible = true;
                TextBox5.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Button1.Visible = false;
                Button4.Visible = false;
                Button5.Visible = false;
                ListBox1.Visible = false;
                TextBox5.Visible = false;
            }
            string mm = TextBox1.Text;
            Warehouse.TextBox_Clear txt = new Warehouse.TextBox_Clear();
            txt.clear(Div1);
            TextBox1.Text = mm;
            TextBox1.ReadOnly = true;
            Div1.Style["display"] = "none";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            switch (ListBox1.Text)
            {
                case "根据部门ID":
                    //根据部门ID得到对象，并刷新gridview的内容
                    rg.Queryequal("departId", "Department", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from department order by num", "departId", GridView1);
                    }
                    break;
                case "根据部门名称":
                    //根据部门名称得到对象，并刷新gridview的内容
                    rg.Queryequal("departName", "Department", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from department order by num", "departId", GridView1);
                    }
                    break;
                case "根据上级部门":
                    //根据上级部门得到对象，并刷新gridview的内容
                    rg.Queryequal("parentdepartName", "Department", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from department order by num", "departId", GridView1);
                    }
                    break;
                case "根据负责人":
                    //根据负责人得到对象，并刷新gridview的内容
                    rg.Queryequal("staffNum", "Department", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from department order by num", "departId", GridView1);
                    }
                    break;
                case "":
                    TextBox5.Text = "";
                    rg.Refresh("select * from department order by num", "departId", GridView1);
                    break;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            switch (Button9.Text)
            {
                case "增加":
                    {
                        if (Image12.ImageUrl == "~/Image/对号.png" && Image11.ImageUrl == "~/Image/对号.png")
                        {
                            if (TextBox3.Text == "")
                            {
                                TextBox3.Text = "暂无";
                            }
                            if (TextBox4.Text == "")
                            {
                                TextBox4.Text = "暂无";
                            }
                            Model.Department add = new Model.Department();
                            DAL.Query nn = new DAL.Query();
                            int n = nn.query("Department");
                            add.Num = (n + 1).ToString();
                            add.StaffNum = TextBox4.Text;
                            add.DepartId = TextBox1.Text;
                            add.DepartName = TextBox2.Text;
                            add.ParentdepartName = TextBox3.Text;
                            bool xx = new DAL.DepartmentDAO().addDepart(add);
                            if (xx == true)//添加一个部门
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功!');window.location.href='管理部门.aspx'", true);
                                Div1.Style["display"] = "none";
                                GridView1.Visible = true;
                                if (GridView1.Visible == true)
                                {
                                    Button1.Visible = true;
                                    Button4.Visible = true;
                                    Button5.Visible = true;
                                    ListBox1.Visible = true;
                                    TextBox5.Visible = true;
                                }
                                else if (GridView1.Visible == false)
                                {
                                    Button1.Visible = false;
                                    Button4.Visible = false;
                                    Button5.Visible = false;
                                    ListBox1.Visible = false;
                                    TextBox5.Visible = false;
                                }
                            }
                            else
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败！');", true);
                            }
                        }
                        else
                        {
                            Response.Write("<script>window.location.href='#div_kkk'</script>");
                        }
                    }
                    break;
                case "确定":
                    {
                        Button btn = sender as Button;
                        Model.Department update = new Model.Department();
                        update.DepartId = TextBox1.Text;
                        update.DepartName = TextBox2.Text;
                        update.StaffNum = TextBox4.Text;
                        update.ParentdepartName = TextBox3.Text;
                        bool xx = new DAL.DepartmentDAO().updateDepart(update);
                        if (xx)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                            Div1.Style["display"] = "none";
                            GridView1.Visible = true;
                            if (GridView1.Visible == true)
                            {
                                Button1.Visible = true;
                                Button4.Visible = true;
                                Button5.Visible = true;
                                ListBox1.Visible = true;
                                TextBox5.Visible = true;
                            }
                            else if (GridView1.Visible == false)
                            {
                                Button1.Visible = false;
                                Button4.Visible = false;
                                Button5.Visible = false;
                                ListBox1.Visible = false;
                                TextBox5.Visible = false;
                            }
                            rg.Refresh("select * from Department order by num", "departId", GridView1);
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
                        }
                    }
                    break;
            }
        }

        protected void Button1_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Init(object sender, EventArgs e)
        {

        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Warehouse.Controllor.JudgeChinese ju = new Controllor.JudgeChinese();
            DAL.sameQuary sq = new DAL.sameQuary();
            if (ju.Judge(TextBox2.Text))
            {
                bool xx = sq.quary("Department", "departName", TextBox2.Text);
                if (xx)
                {
                    Image12.ImageUrl = "~/Image/对号.png";
                    Image12.Visible = true;
                    Label12.Visible = false;
                }
                else
                {
                    Image12.ImageUrl = "~/Image/错号.png";
                    Image12.Visible = true;
                    Label12.Visible = true;
                    Label12.Text = "已存在该部门名，请重新输入";
                    TextBox2.Text = "";
                }
            }
            else
            {
                Image12.ImageUrl = "~/Image/错号.png";
                Image12.Visible = true;
                Label12.Visible = true;
                Label12.Text = "您的房间名称输入不合理,请重新输入";
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            rg.Refresh("select * from Department order by num", "departId", GridView1);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {
                Div1.Style["display"] = "inline";
                int xy = Convert.ToInt32(e.CommandArgument);
                Button9.Text = "确定";
                GridView1.Visible = false;
                if (GridView1.Visible == true)
                {
                    Button1.Visible = true;
                    Button4.Visible = true;
                    Button5.Visible = true;
                    ListBox1.Visible = true;
                    TextBox5.Visible = true;
                }
                else if (GridView1.Visible == false)
                {
                    Button1.Visible = false;
                    Button4.Visible = false;
                    Button5.Visible = false;
                    ListBox1.Visible = false;
                    TextBox5.Visible = false;
                }
                TextBox1.Text = GridView1.Rows[xy].Cells[1].Text;
                TextBox2.Text = GridView1.Rows[xy].Cells[2].Text;
                //TextBox3.Text = GridView1.Rows[xy].Cells[3].Text;
                //TextBox4.Text = GridView1.Rows[xy].Cells[4].Text;
                Model.Department de = new Model.Department();
                Model.staff st = new Model.staff();
                de = new DAL.DepartmentDAO().getDepartById(GridView1.Rows[xy].Cells[3].Text);
                st = new DAL.StaffDAO().getStaffByNum(GridView1.Rows[xy].Cells[4].Text);
                TextBox3.Text = de.DepartName;
                TextBox4.Text = st.StaffName;
                Image11.Visible = true;
                Image11.ImageUrl = "~/Image/对号.png";
                Image12.Visible = true;
                Image12.ImageUrl = "~/Image/对号.png";
                Image1.Visible = true;
                Image1.ImageUrl = "~/Image/对号.png";
                Image2.Visible = true;
                Image2.ImageUrl = "~/Image/对号.png";
                rl.Refresh3("departId", "departName", "Department", TextBox1.Text, ListBox2);
            }
            if (e.CommandName == "deletee")
            {
                ideas.Style["display"] = "inline";
                int x = Convert.ToInt32(e.CommandArgument);
                Session["e"] = x;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rg.Refresh("select * from department order by num", "departId", GridView1);
            TextBox5.Text = "";
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button200_Click(object sender, EventArgs e)
        {
            Model.Department delete = new Model.Department();
            int x = Convert.ToInt32(Session["e"]);
            delete.DepartId = GridView1.Rows[x].Cells[1].Text;
            bool yy = new DAL.DepartmentDAO().deleteDepartById(GridView1.Rows[x].Cells[1].Text);
            if (yy)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                Server.Transfer("管理部门.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }
        protected void Button300_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Button2.Text == "获取上级部门")
            {
                TextBox3.Text = ListBox2.SelectedItem.Value;
                Button2.Text = "获取负责人";
                rl.Refresh2("staffNum", "staffName", "Staff", TextBox1.Text, ListBox2);
            }
            else if (Button2.Text == "获取负责人")
            {
                TextBox4.Text = ListBox2.SelectedItem.Value;
                Button2.Visible = false;
                ListBox2.Visible = false;
            }
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            Button2.Visible = true;
            ListBox2.Visible = true;
            TextBox3.Text = "";
            TextBox4.Text = "";
            rl.Refresh("departId", "departName", "Department", ListBox2);
            Button2.Text = "获取上级部门";
        }

        protected void Button9_Init(object sender, EventArgs e)
        {

        }

        protected void Button5_Init(object sender, EventArgs e)
        {
            Warehouse.Tools.departNum dn = new Tools.departNum();
            TextBox1.Text = "D" + dn.Num();
            db.Bind1(GridView1);
            rl.Refresh3("departId", "departName", "Department", TextBox1.Text, ListBox2);
            rg.Refresh("select * from department order by num ", "departId", GridView1);
        }
    }
}