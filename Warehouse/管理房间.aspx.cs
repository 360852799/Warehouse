using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Warehouse
{
    public partial class 管理房间 : System.Web.UI.Page
    {
        Warehouse.Controllor.RefreshGridview re = new Controllor.RefreshGridview();
        Warehouse.Controllor.Room_Bind rb = new Controllor.Room_Bind();
        Warehouse.Tools.tiqushuzi qu = new Tools.tiqushuzi();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Sort so = new DAL.Sort();
            so.sort("Room", "roomNum");
            if (!IsPostBack)
            {
                Div1.Visible = false;
            }
            rb.Bind2(GridView1);
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
                        if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png")
                        {
                            try
                            {
                                Model.Room add = new Model.Room();
                                DAL.Query nn = new DAL.Query();
                                int n = nn.query("room");
                                add.Num = (n + 1).ToString();
                                add.RoomNum = TextBox10.Text;
                                add.RoomName = TextBox11.Text;
                                add.M =qu.tiqu(TextBox12.Text).ToString();
                                add.Height = qu.tiqu(TextBox2.Text).ToString();
                                add.Remark = TextBox13.Text;
                                add.CreateTime = DateTime.Now;
                                add.UpdateTime = DateTime.Now;
                                bool xx = new DAL.RoomDAO().addRoom(add);
                                if (xx == true)
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                                    Div1.Visible = false;
                                    GridView1.Visible = true;
                                    re.Refresh("select * from Room order by num", "roomNum", GridView1);
                                    if (GridView1.Visible == true)
                                    {
                                        Button1.Visible = true;
                                        Button5.Visible = true;
                                        ListBox1.Visible = true;
                                        TextBox1.Visible = true;
                                    }
                                    else if (GridView1.Visible == false)
                                    {
                                        Button1.Visible = false;
                                        Button5.Visible = false;
                                        ListBox1.Visible = false;
                                        TextBox1.Visible = false;
                                        Div1.Visible = true;
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败！');", true);
                                }
                            }
                            catch
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
                        Model.Room update = new Model.Room();
                        update.RoomNum = TextBox10.Text;
                        update.RoomName = TextBox11.Text;
                        update.M = qu.tiqu(TextBox12.Text).ToString();
                        update.Height = qu.tiqu(TextBox2.Text).ToString();
                        update.Remark = TextBox13.Text;
                        update.CreateTime = Convert.ToDateTime(TextBox14.Text);
                        update.UpdateTime = DateTime.Now;
                        bool xx = new DAL.RoomDAO().updateRoom(update);
                        if (xx)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                            Div1.Visible = false;
                            GridView1.Visible = true;
                            re.Refresh("select * from Room order by num", "roomNum", GridView1);
                            if (GridView1.Visible == true)
                            {
                                Button1.Visible = true;
                                Button5.Visible = true;
                                ListBox1.Visible = true;
                                TextBox1.Visible = true;
                            }
                            else if (GridView1.Visible == false)
                            {
                                Button1.Visible = false;
                                Button5.Visible = false;
                                ListBox1.Visible = false;
                                TextBox1.Visible = false;
                                Div1.Visible = true;
                            }
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
                        }
                    }
                    break;

            }
        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            Div1.Visible = false;
            GridView1.Visible = true;
            if (GridView1.Visible == true)
            {
                Button1.Visible = true;
                Button5.Visible = true;
                ListBox1.Visible = true;
                TextBox1.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Button1.Visible = false;
                Button5.Visible = false;
                ListBox1.Visible = false;
                TextBox1.Visible = false;
                Div1.Visible = true;
            }
            Warehouse.TextBox_Clear txt = new Warehouse.TextBox_Clear();
            txt.clear(Div1);
            TextBox10.ReadOnly = false;
            Response.Redirect(Request.Url.ToString());
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            bool xx = new DAL.RoomDAO().deleteAllRooms();
            if (xx)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                re.Refresh("select * from Room order by num", "roomNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            switch (ListBox1.SelectedItem.Text)
            {
                case "根据房间编号":
                    //根据部门ID得到对象，并刷新gridview的内容
                    re.Queryequal("roomNum", "Room", TextBox1.Text, GridView1);
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
                        re.Refresh("select * from Room order by num", "roomNum", GridView1);
                    }
                    break;
                case "根据房间名称":
                    //根据部门名称得到对象，并刷新gridview的内容
                    re.Queryequal("roomName", "Room", TextBox1.Text, GridView1);
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
                        re.Refresh("select * from Room order by num", "roomNum", GridView1);
                    }
                    break;
                case "根据备注要求":
                    //根据上级部门得到对象，并刷新gridview的内容
                    re.Queryequal("remark", "Room", TextBox1.Text, GridView1);
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
                        re.Refresh("select * from Room order by num", "roomNum", GridView1);
                    }
                    break;
                case "根据库柜最大值":
                    //根据上级部门得到对象，并刷新gridview的内容
                    re.Querymt("chestMax", "Room", TextBox1.Text, GridView1);
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
                        re.Refresh("select * from Room order by num", "roomNum", GridView1);
                    }
                    break;
                case "":
                    TextBox1.Text = "";
                    re.Refresh("select * from Room order by num", "roomNum", GridView1);
                    break;
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                re.Refresh("select * from Room order by num", "roomNum", GridView1);
                TextBox1.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Image1.Visible = true;
            Image1.ImageUrl = "~/Image/对号.png";
            Image4.Visible = true;
            Image4.ImageUrl = "~/Image/对号.png";
            GridView1.Visible = false;
            DAL.Sort so = new DAL.Sort();
            so.sort("Room", "roomNum");
            Warehouse.Tools.roomNum ro = new Tools.roomNum();
            TextBox10.Text = ro.protect_roomNum();
            if (GridView1.Visible == true)
            {
                Button1.Visible = true;
                Button4.Visible = true;
                Button5.Visible = true;
                ListBox1.Visible = true;
                TextBox1.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Button1.Visible = false;
                Button4.Visible = false;
                Button5.Visible = false;
                ListBox1.Visible = false;
                TextBox1.Visible = false;
            }
            Div1.Visible = true;
            Button9.Text = "增加";
        }

        protected void Button5_Init(object sender, EventArgs e)
        {
            rb.Bind1(GridView1);
            re.Refresh("select * from Room order by num", "roomNum", GridView1);
        }
        protected void Button66_Click(object sender, EventArgs e)
        {
            Server.Transfer("管理库位.aspx");
        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {
            Warehouse.Controllor.JudgeChinese ju = new Controllor.JudgeChinese();
            DAL.sameQuary sq = new DAL.sameQuary();
            if (ju.Judge(TextBox11.Text))
            {
                bool xx = sq.quary("Room", "roomName", TextBox11.Text);
                if (xx)
                {
                    Image2.ImageUrl = "~/Image/对号.png";
                    Image2.Visible = true;
                    Label2.Visible = false;
                    this.TextBox12.Focus();
                }
                else
                {
                    Image2.ImageUrl = "~/Image/错号.png";
                    Image2.Visible = true;
                    Label2.Visible = true;
                    Label2.Text = "已存在该房间名，请重新输入";
                    TextBox11.Text = "";
                    this.TextBox11.Focus();
                }
            }
            else
            {
                Image2.ImageUrl = "~/Image/错号.png";
                Image2.Visible = true;
                Label2.Visible = true;
                Label2.Text = "您的房间名称输入不合理,请重新输入";
                this.TextBox11.Focus();
                TextBox11.Text = "";
            }
        }
        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {
            if (TextBox13.Text != "")
            {
                Image4.ImageUrl = "~/Image/对号.png";
                Image4.Visible = true;
                Label4.Visible = false;
            }
            else
            {
                Image4.ImageUrl = "~/Image/错号.png";
                Image4.Visible = true;
                Label4.Visible = true;
            }
        }
        protected void Button9_Init(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            re.Refresh("select * from Room order by num", "roomNum", GridView1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            A6.InnerText = ">>";
            A7.InnerText = "编辑房间";
            if (e.CommandName == "editt")
            {
                int xy = Convert.ToInt32(e.CommandArgument);
                Div1.Visible = true;
                Button9.Text = "确定";
                GridView1.Visible = false;
                if (GridView1.Visible == true)
                {
                    Button1.Visible = true;
                    Button4.Visible = true;
                    Button5.Visible = true;
                    ListBox1.Visible = true;
                    TextBox1.Visible = true;
                }
                else if (GridView1.Visible == false)
                {
                    Button1.Visible = false;
                    Button4.Visible = false;
                    Button5.Visible = false;
                    ListBox1.Visible = false;
                    TextBox1.Visible = false;
                }
                TextBox10.Text = GridView1.Rows[xy].Cells[1].Text;
                Model.Room pos = new DAL.RoomDAO().getRoomByNum(GridView1.Rows[xy].Cells[1].Text);
                TextBox11.Text = pos.RoomName;
                TextBox12.Text = pos.ChestMax.ToString();
                string xx = pos.CreateTime.ToString();
                string yy = pos.UpdateTime.ToString();
                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();
                foreach (char x in xx)
                {
                    if (Convert.ToInt32(x) != 32)
                    {
                        sb1.Append(x);
                    }
                    else if (Convert.ToInt32(x) == 32)
                    {
                        break;
                    }
                }
                foreach (char x in yy)
                {
                    if (Convert.ToInt32(x) != 32)
                    {
                        sb2.Append(x);
                    }
                    else if (Convert.ToInt32(x) == 32)
                    {
                        break;
                    }
                }
                TextBox13.Text = pos.Remark;
                TextBox14.Text = sb1.ToString();
                TextBox15.Text = sb2.ToString();
                TextBox1.ReadOnly = true;
            }
            if (e.CommandName == "deletee")
            {
                Model.Room delete = new Model.Room();
                int x = Convert.ToInt32(e.CommandArgument);
                delete.RoomNum = GridView1.Rows[x].Cells[1].Text;
                ideas.Style["display"] = "inline";
                Session["delete"] = delete.RoomNum;
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TextBox12.Text.Contains("m²"))
                {
                    TextBox12.Text = TextBox12.Text.Substring(0, TextBox12.Text.Length - 2);
                }
                float b = float.Parse(TextBox12.Text);
                if (b > 0)
                {
                    Image3.Visible = true;
                    Image3.ImageUrl = "~/Image/对号.png";
                    Label3.Visible = false;
                    TextBox12.Text = TextBox12.Text + "m²";
                    this.TextBox2.Focus();
                }
                else
                {
                    Image3.Visible = true;
                    Image3.ImageUrl = "~/Image/错号.png";
                    Label3.Visible = true;
                    TextBox12.Text = "";
                    this.TextBox12.Focus();
                }
            }
            catch
            {
                Image3.Visible = true;
                Image3.ImageUrl = "~/Image/错号.png";
                Label3.Visible = true;
                TextBox12.Text = "";
                this.TextBox12.Focus();
            }
        }
        protected void TextBox22_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TextBox2.Text.Contains("m"))
                {
                    TextBox2.Text = TextBox2.Text.Substring(0, TextBox2.Text.Length - 1);
                }
                float b = float.Parse(TextBox2.Text);
                if (b > 0)
                {
                    Image5.Visible = true;
                    Image5.ImageUrl = "~/Image/对号.png";
                    Label7.Visible = false;
                    TextBox2.Text = TextBox2.Text + "m";
                    this.TextBox13.Focus();
                }
                else
                {
                    Image5.Visible = true;
                    Image5.ImageUrl = "~/Image/错号.png";
                    Label7.Visible = true;
                    TextBox2.Text = "";
                    this.TextBox2.Focus();
                }
            }
            catch
            {
                Image5.Visible = true;
                Image5.ImageUrl = "~/Image/错号.png";
                Label7.Visible = true;
                TextBox2.Text = "";
                this.TextBox2.Focus();
            }
        }

        protected void Button200_Click(object sender, EventArgs e)
        {
            ideas.Style["display"] = "none";
            bool yy = new DAL.RoomDAO().deleteRoomByNum(Session["delete"].ToString());
            Session["delete"] = "";
            if (yy)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                re.Refresh("select * from Room order by num", "roomNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }

        protected void Button300_Click(object sender, EventArgs e)
        {
            ideas.Style["display"] = "none";
            re.Refresh("select * from Room order by num", "roomNum", GridView1);
        }
    }
}