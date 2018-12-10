using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse
{
    public partial class 库位类型管理 : System.Web.UI.Page
    {
        Warehouse.Controllor.PositionType_Bind pb = new Controllor.PositionType_Bind();
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Div1.Visible = false;
            }
            pb.Bind2(GridView1);
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
                        if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png" && Image6.ImageUrl == "~/Image/对号.png")
                        {
                            try
                            {
                                Model.PositionType add = new Model.PositionType();
                                DAL.Query nn = new DAL.Query();
                                int n = nn.query("Positiontype");
                                add.Num = (n + 1).ToString();
                                add.PositionTypeId = TextBox10.Text;
                                add.PositionTypeName = TextBox11.Text;
                                add.Length = TextBox12.Text;
                                add.Width = TextBox13.Text;
                                add.Height = TextBox14.Text;
                                add.Remark = TextBox15.Text;
                                bool xx = new DAL.PositionTypeDAO().addPositionType(add);
                                if (xx == true)
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                                    Div1.Visible = false;
                                    GridView1.Visible = true;
                                    rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
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
                                //Response.Redirect(Request.Url.ToString());
                            }
                            catch
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败！');", true);
                            }
                        }
                    }
                    break;
                case "确定":
                    {
                        Button btn = sender as Button;
                        Model.PositionType update = new Model.PositionType();
                        update.PositionTypeId = TextBox10.Text;
                        update.PositionTypeName = TextBox11.Text;
                        update.Length = TextBox12.Text;
                        update.Width = TextBox13.Text;
                        update.Height = TextBox14.Text;
                        update.Remark = TextBox15.Text;
                        bool xx = new DAL.PositionTypeDAO().updatePositionType(update);
                        if (xx)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                            Div1.Visible = false;
                            GridView1.Visible = true;
                            rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
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
            TextBox10.ReadOnly = false;
            rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            bool xx = new DAL.PositionTypeDAO().deleteAllPositionsType();
            if (xx)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
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
                case "根据库位类型编号":
                    //根据部门ID得到对象，并刷新gridview的内容
                    rg.Queryequal("PositionTypeId", "Positiontype", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
                    }
                    break;
                case "根据库位类型名称":
                    //根据部门名称得到对象，并刷新gridview的内容
                    rg.Queryequal("PositionTypeName", "Positiontype", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
                    }
                    break;
                case "根据备注要求":
                    //根据上级部门得到对象，并刷新gridview的内容
                    rg.Querylike("remark","Positiontype", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
                    }
                    break;
                case "":
                    TextBox1.Text = "";
                    rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
                    break;
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem.Text == "")
            {
                rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
                TextBox1.Text = "";
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
            Button9.Text = "增加";
            Warehouse.Tools.positiontypeNum pyn = new Tools.positiontypeNum();
            TextBox10.Text = "P" + pyn.Num();
            Image1.Visible = true;
        }

        protected void Button5_Init(object sender, EventArgs e)
        {
            pb.Bind1(GridView1);
            rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
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
                bool xx = sq.quary("Positiontype", "positionTypeName", TextBox11.Text);
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
                    Label3.Text = "已存在该类型，请重新输入";
                    TextBox11.Text = "";
                }
            }
            else
            {
                Image2.ImageUrl = "~/Image/错号.png";
                Image2.Visible = true;
                Label3.Visible = true;
                Label3.Text = "您的房间名称只能含有汉字";
            }
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {
            if (TextBox12.Text.Contains("m"))
            {
                TextBox12.Text = TextBox12.Text.Substring(0, TextBox12.Text.Length - 1);
            }
            try
            {
                double x = double.Parse(TextBox12.Text);
                Image3.ImageUrl = "~/Image/对号.png";
                Image3.Visible = true;
                Label4.Visible = false;
                TextBox12.Text = TextBox12.Text + "m";
            }
            catch
            {
                Image3.ImageUrl = "~/Image/错号.png";
                Image3.Visible = true;
                Label4.Visible = true;
                TextBox12.Text = "";
            }
        }
        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {
            if (TextBox13.Text.Contains("m"))
            {
                TextBox13.Text = TextBox13.Text.Substring(0, TextBox13.Text.Length - 1);
            }
            try
            {
                double x = double.Parse(TextBox13.Text);
                Image4.ImageUrl = "~/Image/对号.png";
                Image4.Visible = true;
                Label5.Visible = false;
                TextBox13.Text = TextBox13.Text + "m";
            }
            catch
            {
                Image4.ImageUrl = "~/Image/错号.png";
                Image4.Visible = true;
                Label5.Visible = true;
                TextBox13.Text = "";
            }
        }
        protected void TextBox14_TextChanged(object sender, EventArgs e)
        {
            if (TextBox14.Text.Contains("m"))
            {
                TextBox14.Text = TextBox14.Text.Substring(0, TextBox14.Text.Length - 1);
            }
            try
            {
                double x = double.Parse(TextBox14.Text);
                Image5.ImageUrl = "~/Image/对号.png";
                Image5.Visible = true;
                Label6.Visible = false;
                TextBox14.Text = TextBox14.Text + "m";
            }
            catch
            {
                Image5.ImageUrl = "~/Image/错号.png";
                Image5.Visible = true;
                Label6.Visible = true;
                TextBox14.Text = "";
            }
        }
        protected void TextBox15_TextChanged(object sender, EventArgs e)
        {
            if (TextBox15.Text == "")
            {
                Image6.ImageUrl = "~/Image/错号.png";
                Image6.Visible = true;
                Label7.Visible = true;
            }
            else if (TextBox15.Text != "")
            {
                Image6.ImageUrl = "~/Image/对号.png";
                Image6.Visible = true;
                Label7.Visible = false;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
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
                Image6.Visible = true;
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
                Model.PositionType pos = new DAL.PositionTypeDAO().getPositionTypeByid(GridView1.Rows[xy].Cells[1].Text);
                TextBox11.Text = pos.PositionTypeName;
                TextBox12.Text = pos.Length;
                TextBox13.Text = pos.Width;
                TextBox14.Text = pos.Height;
                TextBox15.Text = pos.Remark;
                TextBox10.ReadOnly = true;
            }
            if (e.CommandName == "deletee")
            {
                Model.PositionType delete = new Model.PositionType();
                int x = Convert.ToInt32(e.CommandArgument);
                delete.PositionTypeId = GridView1.Rows[x].Cells[1].Text;
                bool yy = new DAL.ChestDAO().deleteChestByNum(delete.PositionTypeId);
                if (yy)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                    rg.Refresh("select * from Positiontype order by num", "PositionTypeId", GridView1);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
                }
            }
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}