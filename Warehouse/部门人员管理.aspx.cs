using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Warehouse
{
    public partial class 部门人员管理 : System.Web.UI.Page
    {
        Warehouse.Controllor.RefreshListbox rl = new Controllor.RefreshListbox();
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        Warehouse.Controllor.Staff_Bind sb = new Controllor.Staff_Bind();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Sort so = new DAL.Sort();
            so.sort("Staff", "staffNum");
            if (!IsPostBack)
            {
                Div1.Style["display"] = "none";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            ListBox9.Visible = false;
            if (GridView1.Visible == true)
            {
                Button2.Visible = true;
                Button4.Visible = true;
                Button3.Visible = true;
                ListBox9.Visible = true;
                TextBox6.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Button2.Visible = false;
                Button4.Visible = false;
                Button3.Visible = false;
                ListBox9.Visible = false;
                TextBox6.Visible = false;
            }
            Div1.Style["display"] = "inline";
            Button9.Text = "增加";
            Warehouse.Tools.staffNum st = new Warehouse.Tools.staffNum();
            TextBox1.Text = st.protect_staffNum();
            Image1.Visible = true;
            Image4.Visible = true;
            Image6.Visible = true;
            Image5.Visible = true;
            rl.Refresh("年", "年", "listbox_year", ListBox2);
            rl.Refresh("月", "月", "listbox_month", ListBox3);
            rl.Refresh("日", "日", "listbox_day", ListBox4);
            rl.Refreshss("s", "China", "p", "中国", ListBox5);
            rl.Refresh("departId", "departName", "Department", ListBox8);
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            if (GridView1.Visible == true)
            {
                Button2.Visible = true;
                Button4.Visible = true;
                Button3.Visible = true;
                ListBox9.Visible = true;
                TextBox6.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Button2.Visible = false;
                Button4.Visible = false;
                Button3.Visible = false;
                ListBox9.Visible = false;
                TextBox6.Visible = false;
            }
            Warehouse.TextBox_Clear txt = new Warehouse.TextBox_Clear();
            txt.clear(Div1);
            Div1.Style["display"] = "none";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            switch (ListBox9.Text)
            {
                case "根据员工编号":
                    //根据staffNum得到对象，并刷新gridview的内容
                    rg.Queryequal("staffNum", "Staff", TextBox6.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            Div1.Style["display"] = "none";
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                    }
                    break;
                case "根据员工姓名":
                    //根据部门名称得到对象，并刷新gridview的内容
                    rg.Queryequal("staffName", "Staff", TextBox6.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            Div1.Style["display"] = "none";
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                    }
                    break;
                case "根据员工部门":
                    //根据上级部门得到对象，并刷新gridview的内容
                    rg.Queryequal("departId", "Staff", TextBox6.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            Div1.Style["display"] = "none";
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                    }
                    break;
                case "根据员工出生年月":
                    //根据负责人得到对象，并刷新gridview的内容
                    rg.Queryequal("birthday", "Staff", TextBox6.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            Div1.Style["display"] = "none";
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                    }
                    break;
                case "根据员工性别":
                    //根据负责人得到对象，并刷新gridview的内容
                    rg.Queryequal("gender", "Staff", TextBox6.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            Div1.Style["display"] = "none";
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                    }
                    break;
                case "根据员工身份证号":
                    //根据负责人得到对象，并刷新gridview的内容
                    rg.Queryequal("idCard", "Staff", TextBox6.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            Div1.Style["display"] = "none";
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                    }
                    break;
                case "根据员工电话":
                    //根据负责人得到对象，并刷新gridview的内容
                    rg.Querylike("phoneNumber", "Staff", TextBox6.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            Div1.Style["display"] = "none";
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                    }
                    break;
                case "":
                    TextBox6.Text = "";
                    rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                    break;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button30_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Model.staff staff = new Model.staff();
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            staff.StaffNum = row.Cells[0].Text;
            bool xx = new DAL.StaffDAO().deleteStaffByNum(staff.StaffNum);
            if (xx)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                Response.Redirect(Request.Url.ToString());
                rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }
        public int Date(string str1, string str2)
        {
            int m = 0;
            if (str2 == "1" || str2 == "3" || str2 == "5" || str2 == "7" || str2 == "8" || str2 == "10" || str2 == "12")
            {
                m = 31;
            }
            else if (ListBox3.Text == "4" || ListBox3.Text == "6" || ListBox3.Text == "9" || ListBox3.Text == "11")
            {
                m = 30;
            }
            else if (((Convert.ToInt32(str1) % 4 == 0 && Convert.ToInt32(str1) % 100 != 0) || Convert.ToInt32(str1) % 400 == 0) && (str2 == "2"))
            {
                m = 28;
            }
            else if (!((Convert.ToInt32(str1) % 4 == 0 && Convert.ToInt32(str1) % 100 != 0) || Convert.ToInt32(str1) % 400 == 0) && (str2 == "2"))
            {
                m = 29;
            }
            return m;
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            switch (Button9.Text)
            {
                case "增加":
                    {
                        if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png" && Image6.ImageUrl == "~/Image/对号.png" && Image7.ImageUrl == "~/Image/对号.png" && Image8.ImageUrl == "~/Image/对号.png")
                        {
                            Model.staff staff = new Model.staff();
                            DAL.Query qu = new DAL.Query();
                            int n = qu.query("staff");
                            staff.Num = (n + 1).ToString();
                            staff.StaffNum = TextBox1.Text;
                            staff.StaffName = TextBox2.Text;
                            staff.DepartId = TextBox3.Text;
                            staff.Birthday = Convert.ToDateTime(ListBox2.Text + "/" + ListBox3.Text + "/" + ListBox4.Text);
                            staff.Gender = ListBox7.Text;
                            staff.Hometown = ListBox5.SelectedItem.Text + TextBox4.Text;
                            staff.IdCard = TextBox7.Text;
                            staff.PhoneNumber = TextBox8.Text;
                            staff.EntryTime = DateTime.Now;
                            bool xx = new DAL.StaffDAO().addStaff(staff);
                            if (xx == true)//添加一个员工
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                                Div1.Visible = false;
                                GridView1.Visible = true;
                                if (GridView1.Visible == true)
                                {
                                    Button2.Visible = true;
                                    Button4.Visible = true;
                                    Button3.Visible = true;
                                    ListBox9.Visible = true;
                                    TextBox6.Visible = true;
                                }
                                else if (GridView1.Visible == false)
                                {
                                    Button2.Visible = false;
                                    Button4.Visible = false;
                                    Button3.Visible = false;
                                    ListBox9.Visible = false;
                                    TextBox6.Visible = false;
                                }
                                rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
                            }
                            else
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败！');", true);
                                Div1.Visible = false;
                                GridView1.Visible = true;
                                if (GridView1.Visible == true)
                                {
                                    Button2.Visible = true;
                                    Button4.Visible = true;
                                    Button3.Visible = true;
                                    ListBox9.Visible = true;
                                    TextBox6.Visible = true;
                                }
                                else if (GridView1.Visible == false)
                                {
                                    Button2.Visible = false;
                                    Button4.Visible = false;
                                    Button3.Visible = false;
                                    ListBox9.Visible = false;
                                    TextBox6.Visible = false;
                                }
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
                        Model.staff staff = new Model.staff();
                        staff.StaffNum = TextBox1.Text;
                        staff.StaffName = TextBox2.Text;
                        staff.DepartId = TextBox3.Text;
                        staff.Birthday = Convert.ToDateTime(ListBox2.Text + "/" + ListBox3.Text + "/" + ListBox4.Text);
                        staff.Gender = ListBox7.Text;
                        //staff.Hometown = ListBox5.SelectedValue + TextBox4.Text;
                        staff.IdCard = TextBox7.Text;
                        staff.PhoneNumber = TextBox8.Text;
                        bool xx = new DAL.StaffDAO().updateStaff(staff);
                        if (xx)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                            Div1.Visible = false;
                            GridView1.Visible = true;
                            if (GridView1.Visible == true)
                            {
                                Button2.Visible = true;
                                Button4.Visible = true;
                                Button3.Visible = true;
                                ListBox9.Visible = true;
                                TextBox6.Visible = true;
                            }
                            else if (GridView1.Visible == false)
                            {
                                Button2.Visible = false;
                                Button4.Visible = false;
                                Button3.Visible = false;
                                ListBox9.Visible = false;
                                TextBox6.Visible = false;
                            }
                            rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
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

        protected void Button2_Init(object sender, EventArgs e)
        {
            sb.Bind1(GridView1);
            sb.Bind2(GridView1);
            rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DAL.StaffDAO DeleteAll = new DAL.StaffDAO();
            bool xx = DeleteAll.deleteAllStaffs();//删除所有员工
            if (xx)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                Div1.Visible = false;
                GridView1.Visible = true;
                if (GridView1.Visible == true)
                {
                    Button2.Visible = true;
                    Button4.Visible = true;
                    Button3.Visible = true;
                    ListBox9.Visible = true;
                    TextBox6.Visible = true;
                }
                else if (GridView1.Visible == false)
                {
                    Button2.Visible = false;
                    Button4.Visible = false;
                    Button3.Visible = false;
                    ListBox9.Visible = false;
                    TextBox6.Visible = false;
                }
                rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }

        protected void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox5.SelectedItem.Text.Length > 4)
            {
                ListBox5.Style["width"] = "189px";
                rl.Refreshsss("Second", "City_2", "First", this.ListBox5.SelectedValue, ListBox6);
                for (int i = 0; i < ListBox6.Items.Count; i++)
                {
                    ListBox6.SelectedIndex = i;
                    if (ListBox6.SelectedItem.Text == "")
                    {
                        ListBox6.SelectedItem.Text = ListBox6.SelectedItem.Value;
                    }
                }
            }
            else if (ListBox5.SelectedItem.Text.Length == 4)
            {
                ListBox5.Style["width"] = "130px";
                rl.Refreshsss("Second", "City_2", "First", this.ListBox5.SelectedValue, ListBox6);
            }
            else if (ListBox5.SelectedItem.Text.Length <= 3)
            {
                if (Button9.Text == "增加")
                {
                    ListBox5.Style["width"] = "100px";
                    rl.Refreshsss("Second", "City_2", "First", this.ListBox5.SelectedValue, ListBox6);
                }
            }
            TextBox4.Visible = false;
            ListBox6.Visible = true;
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            A6.InnerText = ">>";
            A7.InnerText = "编辑员工";
            if (e.CommandName == "editt")
            {
                int xy = Convert.ToInt32(e.CommandArgument);
                Div1.Visible = true;
                Button9.Text = "确定";
                GridView1.Visible = false;
                if (GridView1.Visible == true)
                {
                    Button2.Visible = true;
                    Button4.Visible = true;
                    Button3.Visible = true;
                    ListBox9.Visible = true;
                    TextBox6.Visible = true;
                }
                else if (GridView1.Visible == false)
                {
                    Button2.Visible = false;
                    Button4.Visible = false;
                    Button3.Visible = false;
                    ListBox9.Visible = false;
                    TextBox6.Visible = false;
                }
                TextBox1.Text = GridView1.Rows[xy].Cells[1].Text;
                Model.staff pos = new DAL.StaffDAO().getStaffByNum(GridView1.Rows[xy].Cells[1].Text);
                TextBox2.Text = pos.StaffName;
                TextBox3.Text = pos.DepartId;


                ListBox7.Text = pos.Gender;
                TextBox7.Text = pos.IdCard;
                TextBox8.Text = pos.PhoneNumber;
            }
            if (e.CommandName == "deletee")
            {
                Model.Room delete = new Model.Room();
                int x = Convert.ToInt32(e.CommandArgument);
                delete.RoomNum = GridView1.Rows[x].Cells[1].Text;
                bool yy = new DAL.RoomDAO().deleteRoomByNum(delete.RoomNum);
                if (yy)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                    rg.Refresh("select * from Room", "roomNum", GridView1);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
                }
            }
        }
        protected void ListBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            rg.Refresh("select * from Staff order by num", "staffNum", GridView1);
            TextBox6.Text = "";
        }

        protected void Button9_Init(object sender, EventArgs e)
        {

        }

        protected void Button13_Click(object sender, EventArgs e)
        {

        }

        protected void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ListBox6_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            string x0 = "", x1 = "", x2 = "", x4 = "", x5 = "", x6 = "";
            ListBox6.Style["width"] = ListBox6.SelectedItem.Text.Length * 40 + "px";
            if (TextBox7.Text.Length != 18)
            {
                Image7.Visible = true;
                Image7.ImageUrl = "~/Image/错号.png";
                Label17.Text = "身份证必须为18位";
            }
            else
            {
                x0 = TextBox7.Text.Substring(TextBox7.Text.Length - 2, 1);
                x1 = TextBox7.Text.Substring(0, 6);
                x2 = TextBox7.Text.Substring(6, 8);
                Warehouse.Controllor.Judgezone ju = new Controllor.Judgezone();
                string bb = ju.judge(ListBox5.SelectedItem.Text + ListBox6.SelectedItem.Text);
                if (bb != "")
                {
                    string aa = Session["zone1"].ToString();
                    string bbbbb = Session["zone2"].ToString();
                    if (x1 == Session["zone1"].ToString() || x1 == Session["zone2"].ToString())
                    {
                        x4 = ListBox2.SelectedItem.Text;
                        x5 = ListBox3.SelectedItem.Text;
                        x6 = ListBox4.SelectedItem.Text;
                        if (x5.Length == 1)
                        {
                            x5 = "0" + x5;
                        }
                        if (x6.Length == 1)
                        {
                            x6 = "0" + x6;
                        }
                        if (x2 == x4 + x5 + x6)
                        {
                            if (ListBox7.SelectedItem.Text == "男")
                            {
                                if (x0 == "1")
                                {
                                    Image7.Visible = true;
                                    Image7.ImageUrl = "~/Image/对号.png";
                                    Label17.Text = "";
                                    Warehouse.Controllor.Queryareanum qa = new Controllor.Queryareanum();
                                    ListBox6.Visible = false;
                                    TextBox4.Visible = true;
                                    TextBox4.Text = qa.querys(ListBox6.SelectedItem.Text) + ListBox6.SelectedItem.Text;
                                    TextBox4.Width = System.Web.UI.WebControls.Unit.Parse(TextBox4.Text.Length * 21 + "px");
                                    ListBox5.Enabled = false;
                                    ListBox6.Enabled = false;
                                }
                                else
                                {
                                    Image7.Visible = true;
                                    Image7.ImageUrl = "~/Image/错号.png";
                                    Label17.Text = "请重新选择性别或输入身份证号," + x2;
                                    Label17.Visible = true;
                                }
                            }
                            else if (ListBox7.SelectedItem.Text == "女")
                            {
                                if (x0 == "2")
                                {
                                    Image7.Visible = true;
                                    Image7.ImageUrl = "~/Image/对号.png";
                                    Label17.Text = "";
                                    Warehouse.Controllor.Queryareanum qa = new Controllor.Queryareanum();
                                    ListBox6.Visible = false;
                                    TextBox4.Visible = true;
                                    TextBox4.Text = qa.querys(ListBox6.SelectedItem.Text) + ListBox6.SelectedItem.Text;
                                    TextBox4.Width=System.Web.UI.WebControls.Unit.Parse(TextBox4.Text.Length * 21 + "px");
                                }
                                else
                                {
                                    Image7.Visible = true;
                                    Image7.ImageUrl = "~/Image/错号.png";
                                    Label17.Text = "请重新选择性别或输入身份证号," + x2;
                                    Label17.Visible = true;
                                }
                            }

                        }
                        else
                        {
                            Image4.Visible = true;
                            Image4.ImageUrl = "~/Image/错号.png";
                            Label14.Text = "请重新选择生日或输入身份证号," + x2;
                            Label14.Visible = true;
                        }
                    }
                    else
                    {
                        Image7.Visible = true;
                        Image7.ImageUrl = "~/Image/错号.png";
                        Label17.Text = "请重新选择籍贯或输入身份证号," + x1;
                        Label17.Visible = true;
                    }
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox3.Text = ListBox8.SelectedItem.Value;
            Image3.Visible = true;
        }

        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = Date(ListBox2.SelectedItem.Text, ListBox3.SelectedItem.Text);
            rl.Refreshh("select top(" + m + ") 日 from listbox_day where 1=1", "日", "日", ListBox4);
        }

        protected void Button2_Command(object sender, CommandEventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Warehouse.Controllor.JudgeChinese ju = new Controllor.JudgeChinese();
            DAL.sameQuary sq = new DAL.sameQuary();
            if (ju.Judge(TextBox2.Text))
            {
                bool xx = sq.quary("Staff", "staffName", TextBox2.Text);
                if (xx)
                {
                    Image2.ImageUrl = "~/Image/对号.png";
                    Image2.Visible = true;
                    Label12.Visible = false;
                }
                else
                {
                    Image2.ImageUrl = "~/Image/错号.png";
                    Image2.Visible = true;
                    Label12.Visible = true;
                    Label12.Text = "已存在该员工名，请重新输入";
                    TextBox2.Text = "";
                }
            }
            else
            {
                Image2.ImageUrl = "~/Image/错号.png";
                Image2.Visible = true;
                Label12.Visible = true;
                Label12.Text = "您的员工名称输入不合理,请重新输入";
                TextBox2.Text = "";
            }
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(TextBox8.Text);
                if (TextBox8.Text.Length != 11)
                {
                    Image8.Visible = true;
                    Image8.ImageUrl = "~/Image/错号.png";
                    Label18.Text = "请输入11位数的手机号";
                }
                else if (TextBox8.Text.Length == 11)
                {
                    Image8.Visible = true;
                    Image8.ImageUrl = "~/Image/对号.png";
                    Label18.Text = "";
                }
            }
            catch
            {
                Image8.Visible = true;
                Image8.ImageUrl = "~/Image/错号.png";
                Label18.Text = "只能输入数字";
                TextBox8.Text = "";
            }
        }

    }
}