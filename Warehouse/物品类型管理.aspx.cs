using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse
{
    public partial class 物品类型管理 : System.Web.UI.Page
    {
        Warehouse.Controllor.GoodsTypes_Bind gb = new Controllor.GoodsTypes_Bind();
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        Warehouse.Controllor.RefreshListbox rl = new Controllor.RefreshListbox();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ListBox3.Text != "")
            {
                Image4.Visible = true;
                Image4.ImageUrl = "~/Image/对号.png";
            }
            else if (ListBox3.Text == "")
            {
                Image4.Visible = true;
                Image4.ImageUrl = "~/Image/错号.png";
            }
            if (!IsPostBack)
            {
                DAL.Sort so = new DAL.Sort();
                so.sort("Goodstype", "goodsTypeNum");
                gb.Bind1(GridView1);
                rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
            }
            gb.Bind2(GridView1);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {
                int xy = Convert.ToInt32(e.CommandArgument);
                Div1.Visible = true;
                Button9.Text = "确定";
                GridView1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                TextBox2.Visible = false;
                ListBox4.Visible = false;
                Div1.Visible = true;
                TextBox10.Text = GridView1.Rows[xy].Cells[1].Text;
                Model.GoodsType pos = new DAL.GoodsTypeDAO().getGoodsTypeByNum(GridView1.Rows[xy].Cells[1].Text);
                TextBox11.Text = GridView1.Rows[xy].Cells[2].Text;
                TextBox12.Text = GridView1.Rows[xy].Cells[3].Text;
                string[] arr = new string[ListBox3.Items.Count];
                for (int i = 0; i < ListBox3.Items.Count; i++)
                {
                    arr[i] = ListBox3.Items[i].Text;
                }
                ListBox3.Items.Clear();
                ListBox3.Items.Add(pos.GoodsTypeCondition);
                for (int k = 0; k < ListBox3.Items.Count; k++)
                {
                    if (arr[k] != pos.GoodsTypeCondition)
                    {
                        ListBox3.Items.Add(arr[k]);
                    }
                }
                ListBox3.Items.Remove("");
                TextBox14.Text = GridView1.Rows[xy].Cells[4].Text;
                TextBox15.Text = GridView1.Rows[xy].Cells[5].Text;
                Image1.Visible = true;
                Image2.Visible = true;
                Image3.Visible = true;
                Image4.Visible = true;
                Image5.Visible = true;
                Image1.ImageUrl = "~/Image/对号.png";
                Image2.ImageUrl = "~/Image/对号.png";
                Image3.ImageUrl = "~/Image/对号.png";
                Image4.ImageUrl = "~/Image/对号.png";
                Image5.ImageUrl = "~/Image/对号.png";
                rl.Refresh("goodsTypeNum", "goodsTypeName", "Goodstype", ListBox2);

            }
            if (e.CommandName == "deletee")
            {
                Model.GoodsType delete = new Model.GoodsType();
                int x = Convert.ToInt32(e.CommandArgument);
                delete.GoodsTypeNum = GridView1.Rows[x].Cells[1].Text;
                ideas.Style["display"] = "inline";
                Session["delete"] = delete.GoodsTypeNum;
            }
        }
        protected void Button200_Click(object sender, EventArgs e)
        {
            ideas.Style["display"] = "none";
            bool yy = new DAL.GoodsTypeDAO().deleteGoodsTypeByNum(Session["delete"].ToString());
            Session["delete"] = "";
            if (yy)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }

        protected void Button300_Click(object sender, EventArgs e)
        {
            ideas.Style["display"] = "none";
            rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            TextBox2.Visible = false;
            ListBox4.Visible = false;
            Div1.Visible = true;
            GridView1.Visible = false;
            //这里自动生成物品类别编号
            TextBox10.Text = "1001";
            Image1.Visible = true;
            Image1.ImageUrl = "~/Image/对号.png";
            rl.Refresh("goodsTypeNum", "goodsTypeName", "Goodstype", ListBox2);
            Image5.Visible = true;
            Image5.ImageUrl = "~/Image/对号.png";
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Button2.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            TextBox2.Visible = true;
            ListBox4.Visible = true;
            Div1.Visible = false;
            GridView1.Visible = true;
            rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            bool xx = new DAL.GoodsTypeDAO().deleteAllGoodsTypes();
            if (xx)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }

        protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            switch (ListBox4.SelectedItem.Text)
            {
                case "根据物品类型编号":
                    rg.Queryequal("goodsTypeNum", "Goodstype", TextBox2.Text, GridView1);
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
                        rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
                    }
                    break;
                case "根据物品类型名称":
                    rg.Queryequal("goodsTypeName", "Goodstype", TextBox2.Text, GridView1);
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
                        rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
                    }
                    break;
                case "根据父类别编号":
                    //根据上级部门得到对象，并刷新gridview的内容                    
                    rg.Querylike("parentTypeNum", "Goodstype", TextBox2.Text, GridView1);
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
                        rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
                    }
                    break;
                case "根据备注要求":
                    rg.Querylike("remark", "Goodstype", TextBox2.Text, GridView1);
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
                        rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
                    }
                    break;
                case "":
                    TextBox2.Text = "";
                    rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
                    break;
            }
        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {
            Warehouse.Controllor.JudgeChinese ju = new Controllor.JudgeChinese();
            DAL.sameQuary sq = new DAL.sameQuary();
            if (ju.Judge(TextBox11.Text))
            {
                bool xx = sq.quary("Goodstype", "goodsTypeName", TextBox11.Text);
                if (xx)
                {
                    Image2.ImageUrl = "~/Image/对号.png";
                    Image2.Visible = true;
                    Label1.Visible = false;
                }
                else
                {
                    Image2.ImageUrl = "~/Image/错号.png";
                    Image2.Visible = true;
                    Label1.Visible = true;
                    Label1.Text = "已存在该物品名，请重输";
                    TextBox11.Text = "";
                    this.TextBox11.Focus();
                }
            }
            else
            {
                Image2.ImageUrl = "~/Image/错号.png";
                Image2.Visible = true;
                Label1.Visible = true;
                Label1.Text = "名称输入不合理,请重新输入";
                this.TextBox11.Focus();
                TextBox11.Text = "";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox12.Text = ListBox2.SelectedItem.Value;
            Image3.Visible = true;
            Image3.ImageUrl = "~/Image/对号.png";
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            switch (Button9.Text)
            {
                case "增加":
                    {
                        if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png")
                        {
                            try
                            {
                                Model.GoodsType add = new Model.GoodsType();
                                DAL.Query nn = new DAL.Query();
                                int n = nn.query("GoodsType");
                                add.Num = (n + 1).ToString();
                                add.GoodsTypeNum = TextBox10.Text;
                                add.GoodsTypeName = TextBox11.Text;
                                add.ParentTypeNum = TextBox12.Text;
                                add.GoodsTypeCondition = ListBox3.Text;
                                add.Remark = TextBox14.Text;
                                add.CreateTime = DateTime.Now;
                                add.UpdateTime = DateTime.Now;
                                bool xx = new DAL.GoodsTypeDAO().addGoodsType(add);
                                if (xx == true)
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                                    Div1.Visible = false;
                                    GridView1.Visible = true;
                                    Button2.Visible = true;
                                    Button3.Visible = true;
                                    Button4.Visible = true;
                                    TextBox2.Visible = true;
                                    ListBox4.Visible = true;
                                    Div1.Visible = false;
                                    GridView1.Visible = true;
                                    rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
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
                        Model.GoodsType update = new Model.GoodsType();
                        update.GoodsTypeNum = TextBox10.Text;
                        update.GoodsTypeName = TextBox11.Text;
                        update.ParentTypeNum = TextBox12.Text;
                        update.GoodsTypeCondition = ListBox3.Text;
                        update.Remark = TextBox14.Text;
                        update.CreateTime = Convert.ToDateTime(TextBox15.Text);
                        update.UpdateTime = DateTime.Now;
                        bool xx = new DAL.GoodsTypeDAO().updateGoodsType(update);
                        if (xx)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                            Div1.Visible = false;
                            GridView1.Visible = true;
                            Button2.Visible = true;
                            Button3.Visible = true;
                            Button4.Visible = true;
                            TextBox2.Visible = true;
                            ListBox4.Visible = true;
                            Div1.Visible = false;
                            GridView1.Visible = true;
                            rg.Refresh("select * from Goodstype order by num", "goodsTypeNum", GridView1);
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
                        }
                    }
                    break;
            }
        }
        protected void TextBox14_TextChanged(object sender, EventArgs e)
        {
            if (TextBox14.Text != "")
            {
                Image5.Visible = true;
                Image5.ImageUrl = "~/Image/对号.png";
            }
            else if (ListBox3.Text == "")
            {
                Image5.Visible = true;
                Image5.ImageUrl = "~/Image/错号.png";
            }
        }
    }
}