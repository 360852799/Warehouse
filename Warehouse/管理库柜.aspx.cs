using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Model;

namespace Warehouse
{
    public partial class 库柜管理 : System.Web.UI.Page
    {
        Warehouse.Controllor.Chest_Bind cb = new Controllor.Chest_Bind();
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        Warehouse.Controllor.RefreshListbox rl = new Controllor.RefreshListbox();
        Warehouse.Tools.tiqushuzi quu = new Tools.tiqushuzi();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Sort so = new DAL.Sort();
            so.sort("Chest", "chestNum");
            if (!IsPostBack)
            {
                Div1.Visible = false;
            }
            cb.Bind2(GridView1);
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
                        Warehouse.Tools.apartV ap = new Tools.apartV();
                        Warehouse.Tools.queryV qu = new Tools.queryV();
                        double xxx = new Warehouse.Tools.chestSum().Sum(ListBox2.SelectedItem.Value);
                        double yy = Convert.ToDouble(quu.tiqu(new Warehouse.Tools.queryV().query("select M from Room where roomNum='" + ListBox2.SelectedItem.Value + "'"))) * Convert.ToDouble(quu.tiqu(new Warehouse.Tools.queryV().query("select Height from Room where roomNum='" + ListBox2.SelectedItem.Value + "'")));
                        if (yy - xxx >= Convert.ToDouble(quu.tiqu(TextBox12.Text)) * Convert.ToDouble(quu.tiqu(TextBox2.Text)))
                        {
                            if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png")
                            {
                                try
                                {
                                    Model.Chest add = new Model.Chest();
                                    DAL.Query nn = new DAL.Query();
                                    int n = nn.query("chest");
                                    add.Num = (n + 1).ToString();
                                    add.ChestNum = TextBox10.Text;
                                    add.ChestName = TextBox11.Text;
                                    add.M = quu.tiqu(TextBox12.Text).ToString();
                                    add.Height = quu.tiqu(TextBox2.Text).ToString();
                                    add.RoomNum = TextBox13.Text;
                                    add.Remark = TextBox14.Text;
                                    add.CreateTime = DateTime.Now;
                                    add.UpdateTime = DateTime.Now;
                                    bool xx = new DAL.ChestDAO().addChest(add);
                                    if (xx == true)
                                    {
                                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                                        Div1.Visible = false;
                                        GridView1.Visible = true;
                                        rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
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
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('可放位置不足，请选择其他房间或总体积小于" + (yy - xxx).ToString() + "！');", true);
                        }
                    }
                    break;
                case "确定":
                    {
                        Button btn = sender as Button;
                        Model.Chest update = new Chest();
                        update.ChestNum = TextBox10.Text;
                        update.ChestName = TextBox11.Text;
                        update.M = quu.tiqu(TextBox12.Text).ToString();
                        update.Height = quu.tiqu(TextBox2.Text).ToString();
                        update.RoomNum = TextBox13.Text;
                        update.Remark = TextBox14.Text;
                        update.CreateTime = Convert.ToDateTime(TextBox15.Text);
                        update.UpdateTime = DateTime.Now;
                        bool xx = new DAL.ChestDAO().updateChest(update);
                        if (xx && (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png"))
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                            Div1.Visible = false;
                            GridView1.Visible = true;
                            rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
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
                                Div1.Visible = true;
                            }
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
                        }
                        break;
                    }
            }
        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            Div1.Visible = false;
            GridView1.Visible = true;
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
                Div1.Visible = true;
            }
            Warehouse.TextBox_Clear txt = new Warehouse.TextBox_Clear();
            txt.clear(Div1);
            rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
            Response.Redirect(Request.Url.ToString());
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            bool xx = new DAL.ChestDAO().deleteChests();
            if (xx)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
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
                case "根据库柜编号":
                    //根据部门ID得到对象，并刷新gridview的内容
                    rg.Queryequal("chestNum", "Chest", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
                    }
                    break;
                case "根据库柜名称":
                    //根据部门名称得到对象，并刷新gridview的内容
                    rg.Queryequal("chestName", "Chest", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
                    }
                    break;
                case "根据备注要求":
                    //根据上级部门得到对象，并刷新gridview的内容
                    rg.Querylike("remark", "Chest", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
                    }
                    break;
                case "根据库位最大值":
                    //根据上级部门得到对象，并刷新gridview的内容
                    rg.Querymt("positionMax", "Chest", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
                    }
                    break;
                case "":
                    TextBox1.Text = "";
                    rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
                    break;
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
            TextBox1.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            DAL.Sort so = new DAL.Sort();
            so.sort("Room", "roomNum");
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
            cb.Bind1(GridView1);
            rg.Refresh("select * from Chest order by num", "chestNum", GridView1);
        }
        protected void Button66_Click(object sender, EventArgs e)
        {
            Server.Transfer("管理库位.aspx");
        }
        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            double xx = new Warehouse.Tools.chestSum().Sum(ListBox2.SelectedItem.Value);
            double yy = Convert.ToDouble(quu.tiqu(new Warehouse.Tools.queryV().query("select M from Room where roomNum='" + ListBox2.SelectedItem.Value + "'"))) * Convert.ToDouble(quu.tiqu(new Warehouse.Tools.queryV().query("select Height from Room where roomNum='" + ListBox2.SelectedItem.Value + "'")));
            if (yy > xx)
            {
                TextBox13.Text = ListBox2.SelectedItem.Value;
                TextBox10.Text = new Warehouse.Tools.chestNum().protect_chestNum(ListBox2.SelectedItem.Value);
                Image1.ImageUrl = "~/Image/对号.png";
                Image1.Visible = true;
                Image4.ImageUrl = "~/Image/对号.png";
                Image4.Visible = true;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('位置已满，请选择其他库位！');", true);
            }
        }

        protected void Button6_Init(object sender, EventArgs e)
        {
            rl.Refresh("roomNum", "roomName", "Room", ListBox2);
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {
            Warehouse.Controllor.JudgeChinese ju = new Controllor.JudgeChinese();
            DAL.sameQuary sq = new DAL.sameQuary();
            if (ju.Judge(TextBox11.Text))
            {
                bool xx = sq.quary("Chest", "chestName", TextBox11.Text);
                if (xx)
                {
                    Image2.ImageUrl = "~/Image/对号.png";
                    Image2.Visible = true;
                    Label3.Visible = false;
                }
                else
                {
                    Image2.ImageUrl = "~/Image/错号.png";
                    Image2.Visible = true;
                    Label3.Visible = true;
                    Label3.Text = "已存在该库柜名，请重新输入";
                    TextBox11.Text = "";
                }
            }
            else
            {
                Image2.ImageUrl = "~/Image/错号.png";
                Image2.Visible = true;
                Label3.Visible = true;
                Label3.Text = "您的库柜名称输入不合理,请重新输入";
            }
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox14_TextChanged(object sender, EventArgs e)
        {
            if (TextBox14.Text == "")
            {
                Image5.ImageUrl = "~/Image/错号.png";
                Image5.Visible = true;
                Label6.Visible = true;
            }
            else if (TextBox14.Text != "")
            {
                Image5.ImageUrl = "~/Image/对号.png";
                Image5.Visible = true;
                Label6.Visible = false;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            rg.Refresh("select * from Chest", "chestNum", GridView1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {
                Image1.Visible = true;
                Image2.Visible = true;
                Image3.Visible = true;
                Image4.Visible = true;
                Image5.Visible = true;
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
                Model.Chest pos = new DAL.ChestDAO().getChestByNum(GridView1.Rows[xy].Cells[1].Text);
                TextBox11.Text = pos.ChestName;
                TextBox12.Text = pos.M;
                TextBox2.Text = pos.Height;
                TextBox13.Text = pos.RoomNum;
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
                TextBox14.Text = pos.Remark;
                TextBox15.Text = sb1.ToString();
                TextBox16.Text = sb2.ToString();
                TextBox1.ReadOnly = true;
            }
            if (e.CommandName == "deletee")
            {
                Model.Chest delete = new Chest();
                int x = Convert.ToInt32(e.CommandArgument);
                delete.ChestNum = GridView1.Rows[x].Cells[1].Text;
                ideas.Style["display"] = "inline";
                Session["delete"] = delete.ChestNum;
            }
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("管理房间.aspx");
        }

        protected void ListBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            rg.Refresh("select * from Chest", "chestNum", GridView1);
        }
        protected void TextBox333_TextChanged(object sender, EventArgs e)
        {
            Warehouse.Tools.queryV qu = new Tools.queryV();
            int a = Convert.ToInt32(qu.query("select count(*) from Chest where roomNum='" + TextBox13.Text + "'"));
            Warehouse.Tools.toos1 to = new Tools.toos1();
            int M = Convert.ToInt32(qu.query("select M from Room where roomNum='" + TextBox13.Text + "'"));
            int m = to.query(TextBox13.Text);
            int c=Convert.ToInt32(quu.tiqu(TextBox12.Text));
            if (c <M-m)
            {

                Image3.Visible = true;
                Image3.ImageUrl = "~/Image/对号.png";
                Label1.Visible = false;
                TextBox12.Text = TextBox12.Text + "m²";
                this.TextBox2.Focus();
            }
            else
            {
                Image3.Visible = true;
                Image3.ImageUrl = "~/Image/对号.png";
                Label1.Visible = false;
                TextBox12.Text = (M - m).ToString();
                TextBox12.Text = TextBox12.Text + "m²";
                this.TextBox12.Focus();
            }
        }
        protected void TextBox334_TextChanged(object sender, EventArgs e)
        {
            Warehouse.Tools.queryV qu = new Tools.queryV();
            int M = Convert.ToInt32(qu.query("select Height from Room where roomNum='" + TextBox13.Text + "'"));
            int c = Convert.ToInt32(quu.tiqu(TextBox2.Text));
            if (c < M)
            {
                Image6.Visible = true;
                Image6.ImageUrl = "~/Image/对号.png";
                Label7.Visible = false;
                TextBox2.Text = TextBox2.Text + "m";
            }
            else
            {
                Image6.Visible = true;
                Image6.ImageUrl = "~/Image/对号.png";
                Label7.Visible = false;
                TextBox2.Text = (M).ToString();
                TextBox2.Text = TextBox2.Text + "m";
            }
        }
        protected void Button200_Click(object sender, EventArgs e)
        {
            ideas.Style["display"] = "none";
            bool yy = new DAL.ChestDAO().deleteChestByNum(Session["delete"].ToString());
            Session["delete"] = "";
            if (yy)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                rg.Refresh("select * from Chest", "chestNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }

        protected void Button300_Click(object sender, EventArgs e)
        {
            ideas.Style["display"] = "none";
            rg.Refresh("select * from Chest", "chestNum", GridView1);
        }
    }
}