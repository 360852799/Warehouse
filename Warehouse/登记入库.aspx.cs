using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse
{
    public partial class 登记入库 : System.Web.UI.Page
    {
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        Warehouse.Controllor.RefreshListbox rl = new Controllor.RefreshListbox();
        Warehouse.Controllor.Inin_Bind gb = new Controllor.Inin_Bind();
        Warehouse.Tools.queryV qu = new Tools.queryV();
        Warehouse.Tools.tiqushuzi tiqu = new Tools.tiqushuzi();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Sort so = new DAL.Sort();
            so.sort("Inin", "inID");
            if (!IsPostBack)
            {
                gb.Bind1(GridView1);
                rg.Refresh("select * from Inin order by num", "inID", GridView1);
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
            string j = "";
            Warehouse.Tools.IninNum inin = new Tools.IninNum();
            TextBox11.Text = inin.Num();
            Image1.Visible = true;
            Image1.ImageUrl = "~/Image/对号.png";
            DateTime date = DateTime.Now;
            string dd = date.ToString("yyyyMMdd");
            int c = Convert.ToInt32(qu.query("select count(*) from Inin where batchNum like  '%" + dd + "%'  ")) + 1;
            switch (c.ToString().Length)
            {
                case 1: j = "00" + c.ToString(); break;
                case 2: j = "0" + c.ToString(); break;
                case 3: j = c.ToString(); break;
            }
            TextBox3.Text = DateTime.Now.ToString("yyyyMMdd") + "1111" + j;
            TextBox4.Text = DateTime.Now.ToString("yyyy/MM/dd");
            ListBox5.Visible = true;
            Button9.Visible = true;
            Image5.Visible = true;
            Image6.Visible = true;
            Image8.Visible = true;
            Image5.ImageUrl = "~/Image/对号.png";
            Image6.ImageUrl = "~/Image/对号.png";
            Image8.ImageUrl = "~/Image/对号.png";
            rl.Refresh("positionNum", "positionNum", "Position", ListBox5);
        }
        protected void Button200_Click(object sender, EventArgs e)
        {
            bool xx = new DAL.IninDAO().deleteInById(Session["delete"].ToString());
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
                rg.Refresh("select * from Inin order by num", "inID", GridView1);
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
            rg.Refresh("select * from Inin order by num", "", GridView1);
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            rg.Refresh("select * from Inin order by num", "inID", GridView1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {

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
            rg.Refresh("select * from Inin order by num", "inID", GridView1);
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {
            TextBox9.Text = "";
            Image2.Visible = false;
            Warehouse.Tools.queryV qu = new Tools.queryV();
            if (Convert.ToInt32(qu.query("select count(*) from Goods where goodsName='" + TextBox12.Text + "'")) == 0)
            {
                if (TextBox12.Text == "")
                {
                    Image3.Visible = true;
                    Image3.ImageUrl = "~/Image/错号.png";
                }
                else
                {
                    Image3.Visible = true;
                    Image3.ImageUrl = "~/Image/对号.png";
                }
            }
            else
            {
                Image3.Visible = true;
                Image3.ImageUrl = "~/Image/错号.png";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('没有此物品信息，请重新输入或前往添加该物品！');", true);
                TextBox12.Text = "";
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (Button9.Text == "获取库位")
            {
                if (Image3.ImageUrl == "~/Image/对号.png" && qu.query("select goodsTypes from Position where positionNum='" + ListBox5.SelectedItem.Text + "'").ToString().Contains(qu.query("select goodsTypeNum from Goods where goodsNum='" + TextBox12.Text + "'").ToString()))
                {
                    TextBox9.Text = ListBox5.SelectedItem.Value;
                    string m = qu.query("select M from Position where positionNum='" + TextBox9.Text + "'").ToString();
                    string h = qu.query("select Height from Position where positionNum='" + TextBox9.Text + "'").ToString();
                    Session["v"] = tiqu.tiqu(m) * tiqu.tiqu(h) + "m³";
                    Image2.Visible = true;
                    Image2.ImageUrl = "~/Image/对号.png";
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('存放类型不符，请选择其他库位！');", true);
                }
            }
            else if (Button9.Text == "获取经办人")
            {
                TextBox5.Text = qu.query("select staffName from Staff where staffNum='" + ListBox5.SelectedItem.Value + "'").ToString();
                if (TextBox5.Text != "")
                {
                    Image7.Visible = true;
                    Image7.ImageUrl = "~/Image/对号.png";
                }
                else if (TextBox5.Text == "")
                {
                    Image7.Visible = true;
                    Image7.ImageUrl = "~/Image/错号.png";
                }
            }
        }

        protected void Button66_Click(object sender, EventArgs e)
        {
            if (Button66.Text == "增加")
            {
                if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png" && Image6.ImageUrl == "~/Image/对号.png" && Image7.ImageUrl == "~/Image/对号.png" && Image8.ImageUrl == "~/Image/对号.png")
                {
                    Warehouse.Tools.queryV qq = new Tools.queryV();
                    Model.Inin add = new Model.Inin();
                    DAL.Query qu = new DAL.Query();
                    int n = qu.query("Inin");
                    add.Num = n + 1;
                    add.InID = TextBox11.Text;
                    add.PositionNum = TextBox9.Text;
                    add.GoodsNum = TextBox12.Text;
                    add.InAmount = double.Parse(TextBox2.Text);
                    add.V = (Convert.ToDouble(tiqu.tiqu(TextBox2.Text)) * Convert.ToDouble(tiqu.tiqu(TextBox7.Text))).ToString();
                    add.BatchNum = TextBox3.Text;
                    add.Date = DateTime.Now;
                    add.UserId = TextBox5.Text;
                    add.Remark = TextBox6.Text;
                    bool xx = new DAL.IninDAO().addIn(add);
                    if (xx)
                    {
                        if ((Convert.ToInt32(new Warehouse.Tools.queryV().query("select count(*) from Amount where goodsNum='" + add.GoodsNum + "' and PositionNum ='" + add.PositionNum + "' ")) > 0) && (Convert.ToInt32(new Warehouse.Tools.queryV().query("select count(*) from Amount where Vp='" + (tiqu.tiqu(TextBox7.Text)).ToString() + "' "))) > 0)
                        {
                            Model.Amount addd = new Model.Amount();
                            addd.Num = Convert.ToInt32(new Warehouse.Tools.queryV().query("select count(*) from Amount where 1=1 ")) + 1;
                            addd.GoodsNum = add.GoodsNum;
                            addd.PositionNum = add.PositionNum;
                            addd.Vp = (tiqu.tiqu(TextBox7.Text)).ToString();
                            addd.Amounts = add.InAmount + Convert.ToDouble(new Warehouse.Tools.queryV().query("select amount from Amount where goodsNum='" + add.GoodsNum + "' and PositionNum ='" + add.PositionNum + "' "));
                            switch (new Warehouse.Tools.queryV().query("select goodsStyle from Goods where goodsNum='" + add.GoodsNum + "'").ToString())
                            {
                                case "固态": addd.AmountPer = "Kg"; break;
                                case "液态": addd.AmountPer = "L"; break;
                                case "气态": addd.AmountPer = "L"; break;
                                case "其他": addd.AmountPer = "Kg"; break;
                            }
                            addd.V = (Convert.ToDouble(new Warehouse.Tools.queryV().query("select V from Amount where goodsNum='" + add.GoodsNum + "' and PositionNum ='" + add.PositionNum + "' "))+ (Convert.ToDouble(TextBox2.Text) * Convert.ToDouble(tiqu.tiqu(TextBox7.Text)))).ToString();
                            new DAL.AmountDAO().updateAmount(addd);
                        }
                        else
                        {
                            Model.Amount addd = new Model.Amount();
                            addd.Num = Convert.ToInt32(new Warehouse.Tools.queryV().query("select count(*) from Amount where 1=1 ")) + 1;
                            addd.GoodsNum = add.GoodsNum;
                            addd.PositionNum = add.PositionNum;
                            addd.Amounts = add.InAmount;
                            switch (new Warehouse.Tools.queryV().query("select goodsStyle from Goods where goodsNum='" + add.GoodsNum + "' ").ToString())
                            {
                                case "固态": addd.AmountPer = "Kg"; break;
                                case "液态": addd.AmountPer = "L"; break;
                                case "气态": addd.AmountPer = "L"; break;
                                case "其他": addd.AmountPer = "Kg"; break;
                            }
                            addd.Vp =(tiqu.tiqu(TextBox7.Text)).ToString();
                            addd.V = (Convert.ToDouble(tiqu.tiqu(TextBox2.Text)) * Convert.ToDouble(tiqu.tiqu(TextBox7.Text))).ToString();
                            new DAL.AmountDAO().addAmount(addd);
                        }
                        Warehouse.Tools.update up = new Tools.update();
                        double xxxx1 = (tiqu.tiqu(TextBox7.Text) * (tiqu.tiqu(TextBox2.Text))); 
                        double xxxx2 = tiqu.tiqu(qq.query("select Rest from Position where positionNum='" + TextBox9.Text + "' "));
                        string rest = (xxxx2 - xxxx1).ToString();
                        up.updates("update Position set Rest='" + rest + "' where positionNum='" + TextBox9.Text + "' ");
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
                        rg.Refresh("select * from Inin order by num", "inID", GridView1);
                        Warehouse.TextBox_Clear tx = new TextBox_Clear();
                        tx.clear(Div1);
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
                Model.Inin add = new Model.Inin();
                add.InID = TextBox11.Text;
                add.PositionNum = TextBox9.Text;
                add.GoodsNum = TextBox12.Text;
                add.InAmount = Int32.Parse(TextBox2.Text);
                add.BatchNum = TextBox3.Text;
                add.Date = DateTime.Now;
                add.UserId = TextBox5.Text;
                add.Remark = TextBox6.Text;
                bool xx = new DAL.IninDAO().updateIn(add);
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
                    rg.Refresh("select * from Inin order by num", "inID", GridView1);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
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
            Warehouse.TextBox_Clear te = new TextBox_Clear();
            te.clear(this.Div1);
            Response.Redirect(Request.Url.ToString());
            rg.Refresh("select * from Inin order by num", "inID", GridView1);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            switch (ListBox11.SelectedItem.Text)
            {
                case "根据入库编号":
                    rg.Queryequal("inID", "Inin", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Inin order by num", "inID", GridView1);
                    }
                    break;
                case "根据库位编号":
                    rg.Querylike("positionNum", "Inin", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Inin order by num", "inID", GridView1);
                    }
                    break;
                case "根据物品编号":
                    rg.Querylike("goodsNum", "Inin", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Inin order by num", "inID", GridView1);
                    }
                    break;
                case "根据批次编号":
                    rg.Querylike("batchNum", "Inin", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Inin order by num", "inID", GridView1);
                    }
                    break;
                case "根据经办人":
                    rg.Queryequal("userId", "Inin", TextBox1.Text, GridView1);
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
                        rg.Refresh("select * from Inin order by num", "inID", GridView1);
                    }
                    break;
                case "":
                    TextBox1.Text = "";
                    rg.Refresh("select * from Inin order by num", "inID", GridView1);
                    break;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            bool xx = new DAL.IninDAO().deleteAllIn();
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
                rg.Refresh("select * from Inin order by num", "inID", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(qu.query("select count(*) from Sysuser where staffNum='" + qu.query("select staffNum from Staff where staffName='" + TextBox5.Text + "'").ToString() + "'")) > 0)
                {
                    Image7.Visible = true;
                    Image7.ImageUrl = "~/Image/对号.png";
                }
                else
                {
                    Image7.Visible = true;
                    Image7.ImageUrl = "~/Image/错号.png";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('经办人输入有误，请从左侧选取或再次输入！');", true);
                    rl.Refresh("staffNum", "staffNum", "Sysuser", ListBox5);
                    Button9.Text = "获取经办人";
                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('Error！！！');", true);
            }
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double.Parse(TextBox7.Text);
                Image9.Visible = true;
                Image9.ImageUrl = "~/Image/对号.png";
                TextBox7.Text += "m³";
                TextBox2.Text = "";
            }
            catch
            {
                Image9.Visible = true;
                Image9.ImageUrl = "~/Image/错号.png";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('请输入一个整数或小数！');", true);
                TextBox7.Text = "";
                TextBox2.Text = "";
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double.Parse(TextBox2.Text);
                double n = Convert.ToDouble(qu.query("select Rest from Position where positionNum='" + TextBox9.Text + "'")) / tiqu.tiqu(TextBox7.Text);
                if (n > double.Parse(TextBox2.Text))
                {
                    Image4.Visible = true;
                    Image4.ImageUrl = "~/Image/对号.png";
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('可用空间不足，请选择其他库位或者更改数量！');", true);
                    TextBox2.Text = n.ToString();
                    Image4.Visible = true;
                    Image4.ImageUrl = "~/Image/错号.png";
                }
            }
            catch
            {
                Image4.Visible = true;
                Image4.ImageUrl = "~/Image/错号.png";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('请输入一个整数或小数！');", true);
                TextBox2.Text = "";
            }
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (TextBox6.Text == "")
            {
                Image8.Visible = true;
                Image8.ImageUrl = "~/Image/错号.png";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('不能为空！');", true);
            }
            else
            {
                Warehouse.Controllor.JudgeChinese ju = new Controllor.JudgeChinese();
                if (ju.Judge(TextBox6.Text))
                {
                    Image8.Visible = true;
                    Image8.ImageUrl = "~/Image/对号.png";
                }
                else
                {
                    Image8.Visible = true;
                    Image8.ImageUrl = "~/Image/错号.png";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('请重新输入,只能输入汉字！');", true);
                }
            }
        }
    }
}