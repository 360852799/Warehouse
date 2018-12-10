using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse
{
    public partial class 物品信息管理 : System.Web.UI.Page
    {
        Warehouse.Controllor.Goods_Bind gb = new Controllor.Goods_Bind();
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        Warehouse.Controllor.RefreshListbox rl = new Controllor.RefreshListbox();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Sort so = new DAL.Sort();
            so.sort("Goods","goodsNum");
            if (!IsPostBack)
            {
                gb.Bind1(GridView1);
                rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
                Div1.Visible = false;
            }
            gb.Bind2(GridView1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Div1.Visible = true;
            GridView1.Visible = false;
            if (GridView1.Visible == false)
            {
                Button1.Visible = false;
                Button4.Visible = false;
                ListBox11.Visible = false;
                TextBox1.Visible = false;
                Button5.Visible = false;
            }
            TextBox9.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            ListBox5.Visible = true;
            Button9.Visible = true;
            Image4.Visible = true;
            Image5.Visible = true;
            Image6.Visible = true;
            Image7.Visible = true;
            Image8.Visible = true;
            Image9.Visible = true;
            Image4.ImageUrl = "~/Image/对号.png";
            Image5.ImageUrl = "~/Image/对号.png";
            Image6.ImageUrl = "~/Image/对号.png";
            Image7.ImageUrl = "~/Image/对号.png";
            Image8.ImageUrl = "~/Image/对号.png";
            Image9.ImageUrl = "~/Image/对号.png";
            rl.Refresh("goodsTypeNum", "goodsTypeName", "Goodstype", ListBox5);
        }
        protected void Button200_Click(object sender, EventArgs e)
        {
          bool xx=  new DAL.GoodsDAO().deleteGoodsByNum(Session["delete"].ToString());
          if (xx)
          {
              ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
              ideas.Style["display"] = "none";
              Div1.Visible = false;
              GridView1.Visible = true;
              if (GridView1.Visible == true)
              {
                  Button1.Visible = true;
                  Button4.Visible = true;
                  ListBox11.Visible = true;
                  TextBox1.Visible = true;
                  Button5.Visible = true;
              }
              rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
          }
          else
          {
              ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
          }
        }
        protected void Button300_Click(object sender, EventArgs e)
        {
            Div1.Visible = false;
            GridView1.Visible = true;
            Button1.Visible = true;
            Button4.Visible = true;
            ListBox11.Visible = true;
            TextBox1.Visible = true;
            Button5.Visible = true;
            ideas.Style["display"] = "none";
            rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {
                int xy = Convert.ToInt32(e.CommandArgument);
                Div1.Visible = true;
                Button66.Text = "确定";
                Div1.Visible = true;
                GridView1.Visible = false;
                if (GridView1.Visible == false)
                {
                    Button1.Visible = false;
                    Button4.Visible = false;
                    ListBox11.Visible = false;
                    TextBox1.Visible = false;
                    Button5.Visible = false;
                }
                TextBox11.Text = GridView1.Rows[xy].Cells[1].Text;
                TextBox12.Text = GridView1.Rows[xy].Cells[2].Text;
                Model.Goods pos = new DAL.GoodsDAO().getGoodsByNum(GridView1.Rows[xy].Cells[1].Text);
                TextBox9.Text = new DAL.GoodsTypeDAO().getGoodsTypeByNum(pos.GoodsTypeNum).GoodsTypeName;
                for (int i = 0; i < ListBox6.Items.Count; i++)
                {
                    if (ListBox6.Items[i].Text == pos.GoodsStyle)
                    {
                        string str = ListBox6.Items[0].Text;
                        ListBox6.Items[0].Text = ListBox6.Items[i].Text;
                        ListBox6.Items[i].Text = str;
                    }
                }
                for (int i = 0; i < ListBox7.Items.Count; i++)
                {
                    if (ListBox7.Items[i].Text == pos.GoodsColor)
                    {
                        string str = ListBox7.Items[0].Text;
                        ListBox7.Items[0].Text = ListBox7.Items[i].Text;
                        ListBox7.Items[i].Text = str;
                    }
                }

                for (int i = 0; i < ListBox8.Items.Count; i++)
                {
                    if (ListBox8.Items[i].Text == pos.GoodsSmell)
                    {
                        string str = ListBox8.Items[0].Text;
                        ListBox8.Items[0].Text = ListBox8.Items[i].Text;
                        ListBox8.Items[i].Text = str;
                    }
                }
                for (int i = 0; i < ListBox9.Items.Count; i++)
                {
                    if (ListBox9.Items[i].Text == pos.GoodsShape)
                    {
                        string str = ListBox9.Items[0].Text;
                        ListBox9.Items[0].Text = ListBox9.Items[i].Text;
                        ListBox9.Items[i].Text = str;
                    }
                }

                for (int i = 0; i < ListBox14.Items.Count; i++)
                {
                    if (ListBox14.Items[i].Text == pos.GoodsPer)
                    {
                        string str = ListBox14.Items[0].Text;
                        ListBox14.Items[0].Text = ListBox14.Items[i].Text;
                        ListBox14.Items[i].Text = str;
                    }
                }

                for (int i = 0; i < ListBox10.Items.Count; i++)
                {
                    if (ListBox10.Items[i].Text == pos.GoodsCondition)
                    {
                        string str = ListBox10.Items[0].Text;
                        ListBox10.Items[0].Text = ListBox10.Items[i].Text;
                        ListBox10.Items[i].Text = str;
                    }
                }
                TextBox2.Text = GridView1.Rows[xy].Cells[7].Text;
                Image1.Visible = true;
                Image2.Visible = true;
                Image3.Visible = true;
                Image4.Visible = true;
                Image5.Visible = true;
                Image6.Visible = true;
                Image7.Visible = true;
                Image8.Visible = true;
                Image9.Visible = true;
                Image10.Visible = true;
                Image1.ImageUrl = "~/Image/对号.png";
                Image2.ImageUrl = "~/Image/对号.png";
                Image3.ImageUrl = "~/Image/对号.png";
                Image4.ImageUrl = "~/Image/对号.png";
                Image5.ImageUrl = "~/Image/对号.png";
                Image6.ImageUrl = "~/Image/对号.png";
                Image7.ImageUrl = "~/Image/对号.png";
                Image8.ImageUrl = "~/Image/对号.png";
                Image9.ImageUrl = "~/Image/对号.png";
                Image10.ImageUrl = "~/Image/对号.png";
                Button9.Visible = false;
                ListBox5.Visible = false;
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {
            Warehouse.Tools.queryV qu = new Tools.queryV();
            if (Convert.ToInt32(qu.query("select count(*) from Goods where goodsName='" + TextBox12.Text + "'")) == 0)
            {
                if (TextBox12.Text == "")
                {
                    Image3.Visible = true;
                    Image3.ImageUrl = "~/Image/错号.png";
                    Label3.Visible = true;
                }
                else
                {
                    Image3.Visible = true;
                    Image3.ImageUrl = "~/Image/对号.png";
                    Label3.Visible = false;
                }
            }
            else
            {
                Image3.Visible = true;
                Image3.ImageUrl = "~/Image/错号.png";
                Label3.Visible = true;
                Label3.Text = "您的物品名称已存在，请重新输入";
                TextBox12.Text = "";
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            TextBox9.Text = ListBox5.SelectedItem.Value;
            Image2.Visible = true;
            Image2.ImageUrl = "~/Image/对号.png";
            Warehouse.Tools.queryV qu = new Tools.queryV();
            string m = qu.query("select count(*) from Goods where goodsTypeNum='" + TextBox9.Text + "'");
            string mm = (Convert.ToInt32(m) + 1).ToString();
            if (mm.Length == 1)
            {
                mm = "000" + mm;
            }
            else if (mm.Length == 2)
            {
                mm = "00" + mm;
            }
            else if (mm.Length == 3)
            {
                mm = "0" + mm;
            }
            TextBox11.Text = TextBox9.Text + mm;
            Image1.Visible = true;
            Image1.ImageUrl = "~/Image/对号.png";
        }

        protected void Button66_Click(object sender, EventArgs e)
        {
            if (Button66.Text == "增加")
            {
                if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png" && Image6.ImageUrl == "~/Image/对号.png" && Image7.ImageUrl == "~/Image/对号.png" && Image8.ImageUrl == "~/Image/对号.png" && Image9.ImageUrl == "~/Image/对号.png" && Image10.ImageUrl == "~/Image/对号.png")
                {
                    Model.Goods add = new Model.Goods();
                    DAL.Query qu = new DAL.Query();
                    int n = qu.query("Goods");
                    add.Num = n + 1;
                    add.GoodsNum = TextBox11.Text;
                    add.GoodsTypeNum = TextBox9.Text;
                    add.GoodsName = TextBox12.Text;
                    add.GoodsStyle = ListBox6.SelectedItem.Text;
                    add.GoodsColor = ListBox7.SelectedItem.Text;
                    add.GoodsSmell = ListBox8.SelectedItem.Text;
                    add.GoodsShape = ListBox9.SelectedItem.Text;
                    add.GoodsPer = ListBox14.SelectedItem.Text;
                    add.GoodsCondition = ListBox10.SelectedItem.Text;
                    add.Max = TextBox2.Text;
                    bool xx = new DAL.GoodsDAO().addGoods(add);
                    if (xx)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                        Div1.Visible = false;
                        GridView1.Visible = true;
                        if (GridView1.Visible == true)
                        {
                            Button1.Visible = true;
                            Button4.Visible = true;
                            ListBox11.Visible = true;
                            TextBox1.Visible = true;
                            Button5.Visible = true;
                        }
                        rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
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
            else if (Button66.Text == "确定")
            {
                if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png" && Image6.ImageUrl == "~/Image/对号.png" && Image7.ImageUrl == "~/Image/对号.png" && Image8.ImageUrl == "~/Image/对号.png" && Image9.ImageUrl == "~/Image/对号.png" && Image10.ImageUrl == "~/Image/对号.png")
                {
                    Model.Goods add = new Model.Goods();
                    add.GoodsNum = TextBox11.Text;
                    add.GoodsTypeNum = TextBox9.Text;
                    add.GoodsName = TextBox12.Text;
                    add.GoodsStyle = ListBox6.SelectedItem.Text;
                    add.GoodsColor = ListBox7.SelectedItem.Text;
                    add.GoodsSmell = ListBox8.SelectedItem.Text;
                    add.GoodsShape = ListBox9.SelectedItem.Text;
                    add.GoodsPer = ListBox14.SelectedItem.Text;
                    add.GoodsCondition = ListBox10.SelectedItem.Text;
                    add.Max = TextBox2.Text;
                    bool xx = new DAL.GoodsDAO().updateGoods(add);
                    if (xx)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                        Div1.Visible = false;
                        GridView1.Visible = true;
                        if (GridView1.Visible == true)
                        {
                            Button1.Visible = true;
                            Button4.Visible = true;
                            ListBox11.Visible = true;
                            TextBox1.Visible = true;
                            Button5.Visible = true;
                        }
                        rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
                    }
                }
            }
        }

        protected void Button77_Click(object sender, EventArgs e)
        {
            Div1.Visible = false;
            GridView1.Visible = true;
            if (GridView1.Visible == true)
            {
                Button1.Visible = true;
                Button4.Visible = true;
                ListBox11.Visible = true;
                TextBox1.Visible = true;
                Button5.Visible = true;
            }
            rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            switch (ListBox11.SelectedItem.Text)
            {
                case "根据物品编号":
                    rg.Queryequal("goodsNum", "Goods", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
                    }
                    break;
                case "根据物品名称":
                    //根据上级部门得到对象，并刷新gridview的内容                    
                    rg.Querylike("goodsName", "Goods", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
                    }
                    break;
                case "":
                    TextBox1.Text = "";
                    rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
                    break;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
          bool xx=  new DAL.GoodsDAO().deleteGoodes();
          if (xx)
          {
              ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
              Div1.Visible = false;
              GridView1.Visible = true;
              if (GridView1.Visible == true)
              {
                  Button1.Visible = true;
                  Button4.Visible = true;
                  ListBox11.Visible = true;
                  TextBox1.Visible = true;
                  Button5.Visible = true;
              }
              rg.Refresh("select * from Goods order by num", "goodsNum", GridView1);
          }
          else
          {
              ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
          }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(TextBox2.Text);
                if (a > 0)
                {
                    Image10.Visible = true;
                    Image10.ImageUrl = "~/Image/对号.png";
                    Label2.Visible = false;
                }
                else
                {
                    Image10.Visible = true;
                    Image10.ImageUrl = "~/Image/错号.png";
                    Label2.Visible = true;
                }
            }
            catch
            {
                Image10.Visible = true;
                Image10.ImageUrl = "~/Image/错号.png";
                Label2.Visible = true;
            }
        }
    }
}