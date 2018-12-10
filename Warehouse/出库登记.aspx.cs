using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Warehouse
{
    public partial class 出库登记 : System.Web.UI.Page
    {
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        Warehouse.Controllor.RefreshListbox rl = new Controllor.RefreshListbox();
        Warehouse.Controllor.Outout_Bind gb = new Controllor.Outout_Bind();
        Warehouse.Tools.queryV qu = new Tools.queryV();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Sort so = new DAL.Sort();
            so.sort("Outout", "outID");
            if (!IsPostBack)
            {
                gb.Bind3(GridView1);
                gb.Bind1(GridView2);
                rg.Refresh("select * from Outout order by num", "", GridView1);
            }
            gb.Bind4(GridView1);
            gb.Bind2(GridView2);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "新增出库")
            {
                GridView1.Visible = false;
                GridView2.Visible = true;
                rg.Refresh("select * from Amount order by num", "", GridView2);
                Button1.Text = "新增入库";
                ListBox11.Items.Clear();
                ListBox11.Items.Add("");
                ListBox11.Items.Add("根据物品编号");
                ListBox11.Items.Add("根据库位编号");
            }
            else if (Button1.Text == "新增入库")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "window.location.href = '登记入库.aspx'", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "新增出库")
            {
                if (new DAL.OutoutDAO().deleteAllOut())
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                    rg.Refresh("select * from Outout order by num", "", GridView1);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
                    rg.Refresh("select * from Outout order by num", "", GridView1);
                }
            }
            else if (Button1.Text == "新增入库")
            {
                if (new DAL.AmountDAO().deleteAmounts())
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                    rg.Refresh("select * from Amount order by num", "", GridView2);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
                    rg.Refresh("select * from Amount order by num", "", GridView2);
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "新增出库")
            {
                switch (ListBox11.SelectedItem.Text)
                {
                    case "根据出库编号":
                        rg.Queryequal("outID", "Outout", TextBox1.Text, GridView1);
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
                            rg.Refresh("select * from Outout order by num", "outID", GridView1);
                        }
                        break;
                    case "根据库位编号":
                        rg.Querylike("positionNum", "Outout", TextBox1.Text, GridView1);
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
                            rg.Refresh("select * from Outout order by num", "outID", GridView1);
                        }
                        break;
                    case "根据物品编号":
                        rg.Querylike("goodsNum", "Outout", TextBox1.Text, GridView1);
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
                            rg.Refresh("select * from Outout order by num", "outID", GridView1);
                        }
                        break;
                    case "根据批次编号":
                        rg.Querylike("batchNum", "Outout", TextBox1.Text, GridView1);
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
                            rg.Refresh("select * from Outout order by num", "outID", GridView1);
                        }
                        break;
                    case "根据经办人":
                        rg.Queryequal("userId", "Outout", TextBox1.Text, GridView1);
                        try
                        {
                            if (GridView1.Rows[0].Cells[0].Text != null)
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            }
                        }
                        catch
                        {
                            string Num = qu.query("select staffNum from Staff where staffName='" + TextBox1.Text + "'");
                            rg.Queryequal("userId", "Outout", Num, GridView1);
                            if (GridView1.Rows[0].Cells[0].Text != null)
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            }
                            else
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                                rg.Refresh("select * from Outout order by num", "outID", GridView1);
                            }
                        }
                        break;
                    case "":
                        TextBox1.Text = "";
                        rg.Refresh("select * from Outout order by num", "outID", GridView1);
                        break;
                }
            }
            else if (Button1.Text == "新增入库")
            {
                switch (ListBox11.SelectedItem.Text)
                {
                    case "根据物品编号":
                        rg.Queryequal("goodsNum", "Amount", TextBox1.Text, GridView2);
                        try
                        {
                            if (GridView2.Rows[0].Cells[0].Text != null)
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            }
                        }
                        catch
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                            rg.Refresh("select * from Amount order by num", "", GridView2);
                        }
                        break;
                    case "根据库位编号":
                        rg.Querylike("positionNum", "Amount", TextBox1.Text, GridView2);
                        try
                        {
                            if (GridView2.Rows[0].Cells[0].Text != null)
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                            }
                        }
                        catch
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                            rg.Refresh("select * from  Amount order by num", "", GridView2);
                        }
                        break;
                    case "":
                        TextBox1.Text = "";
                        rg.Refresh("select * from  Amount order by num", "", GridView2);
                        break;
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            if (Button1.Text == "新增出库")
            {
                rg.Refresh("select * from Outout order by num", "", GridView1);
            }
            else if (Button1.Text == "新增入库")
            {
                rg.Refresh("select * from Amount order by num", "", GridView2);
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {
                    Div1.Visible = true;
                    Button1.Visible = false;
                    Button4.Visible = false;
                    Button5.Visible = false;
                    TextBox1.Visible = false;
                    ListBox11.Visible = false;
                    GridView2.Visible = false;
                    int n = Convert.ToInt32(qu.query("select count(*) from  Outout where 1=1")) + 1;
                    string j = "";
                    Warehouse.Tools.OutoutNum ou = new Tools.OutoutNum();
                    TextBox11.Text = ou.Num();
                    Image1.Visible = true;
                    Image1.ImageUrl = "~/Image/对号.png";
                    int x = Convert.ToInt32(e.CommandArgument);
                    TextBox12.Text = GridView2.Rows[x].Cells[1].Text;
                    TextBox9.Text = GridView2.Rows[x].Cells[2].Text;
                    TextBox4.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    Session["max"] = GridView2.Rows[x].Cells[3].Text;
                    Session["V"] = GridView2.Rows[x].Cells[5].Text;
                    DateTime date = DateTime.Now;
                    string dd = date.ToString("yyyyMMdd");
                    int c = Convert.ToInt32(qu.query("select count(*) from Outout where batchNum like  '%" + dd + "%'  ")) + 1;
                    switch (c.ToString().Length)
                    {
                        case 1: j = "00" + c.ToString(); break;
                        case 2: j = "0" + c.ToString(); break;
                        case 3: j = c.ToString(); break;
                    }
                    TextBox3.Text = DateTime.Now.ToString("yyyyMMdd") + "1010" + j;
                    Image3.Visible = true;
                    Image3.ImageUrl = "~/Image/对号.png";
                    Image2.Visible = true;
                    Image2.ImageUrl = "~/Image/对号.png";
                    Image5.Visible = true;
                    Image5.ImageUrl = "~/Image/对号.png";
                    Image6.Visible = true;
                    Image6.ImageUrl = "~/Image/对号.png";
                    Image8.Visible = true;
                    Image8.ImageUrl = "~/Image/对号.png";
            }
            else if (e.CommandName == "deletee")
            {
                Model.Outout delete = new Model.Outout();
                int x = Convert.ToInt32(e.CommandArgument);
                delete.OuID = GridView1.Rows[x].Cells[1].Text;
                ideas.Style["display"] = "inline";
                Session["delete"] = delete.OuID;
            }
        }
        protected void Button200_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "新增出库")
            {
                bool xx = new DAL.OutoutDAO().deleteOutById(Session["delete"].ToString());
                if (xx)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                    ideas.Style["display"] = "none";
                    rg.Refresh("select * from Outout order by num", "", GridView1);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
                    rg.Refresh("select * from Outout order by num", "", GridView1);
                }
            }
        }
        protected void Button300_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "新增出库")
            {
                ideas.Style["display"] = "none";
                rg.Refresh("select * from Outout order by num", "", GridView1);
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            rg.Refresh("select * from Outout order by num", "", GridView1);
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(TextBox2.Text);
                double b = Convert.ToDouble(Session["max"].ToString());
                if (b >= a)
                {
                    Image4.Visible = true;
                    Image4.ImageUrl = "~/Image/对号.png";
                }
                else
                {
                    Image4.Visible = true;
                    Image4.ImageUrl = "~/Image/错号.png";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('请重新输入一个不大于" + b + "的数！');", true);
                    TextBox2.Text = "";
                }
            }
            catch
            {
                Image4.Visible = true;
                Image4.ImageUrl = "~/Image/错号.png";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('请重新输入！');", true);
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

        protected void TextBox5_TextChanged(object sender, EventArgs e)
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
                    ListBox5.Visible = true;
                    Button9.Visible = true;
                    rl.Refresh("staffNum", "staffNum", "Sysuser", ListBox5);
                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('Error！！！');", true);
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            TextBox5.Text = qu.query("select staffName from Staff where staffNum='" + ListBox5.SelectedItem.Value + "'");
            Image7.Visible = true;
            Image7.ImageUrl = "~/Image/对号.png";
        }

        protected void Button66_Click(object sender, EventArgs e)
        {
            Model.Outout add = new Model.Outout();
            if (Button66.Text == "增加")
            {
                if (Image1.ImageUrl == "~/Image/对号.png" && Image2.ImageUrl == "~/Image/对号.png" && Image3.ImageUrl == "~/Image/对号.png" && Image4.ImageUrl == "~/Image/对号.png" && Image5.ImageUrl == "~/Image/对号.png" && Image6.ImageUrl == "~/Image/对号.png" && Image7.ImageUrl == "~/Image/对号.png" && Image8.ImageUrl == "~/Image/对号.png")
                {
                    Warehouse.Tools.queryV qq = new Tools.queryV();
                    DAL.Query quu = new DAL.Query();
                    int n = quu.query("Outout");
                    add.Num = n + 1;
                    add.OuID = TextBox11.Text;
                    add.GoodsNum = TextBox12.Text;
                    add.PositionNum = TextBox9.Text;
                    add.OutAmount = Convert.ToDouble(TextBox2.Text);
                    add.BatchNum = TextBox3.Text;
                    add.Date = Convert.ToDateTime(TextBox4.Text);
                    add.UserId = qu.query("select staffNum from Staff where staffName='" + TextBox5.Text + "'");
                    add.Remark = TextBox6.Text;
                    bool xx = new DAL.OutoutDAO().addOut(add);
                    if (xx)
                    {
                        Model.Amount update = new Model.Amount();
                        update.Amounts = Convert.ToDouble(Session["max"].ToString()) - Convert.ToDouble(add.OutAmount);
                        double d = Convert.ToDouble(Session["V"].ToString()) / Convert.ToDouble(Session["max"].ToString());
                        update.V = (update.Amounts * d).ToString();
                        update.GoodsNum = TextBox12.Text;
                        update.PositionNum = TextBox9.Text;
                        update.Vp = d.ToString();
                        bool yy = new DAL.AmountDAO().update(update);
                        if (yy)
                        {
                            double rest = Convert.ToDouble(qu.query("select Rest from Position where positionNum='" + TextBox9.Text + "'"));
                            Model.Position Update = new Model.Position();
                            Update.Rest = (rest + d * add.OutAmount).ToString();
                            Update.PositionNum = TextBox9.Text;
                            bool cc = new DAL.PositionDAO().update(Update);
                        }
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功!');window.location.href='出库登记.aspx'", true);
                    }
                }
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView2.PageIndex = e.NewPageIndex;
            rg.Refresh("select * from Amount order by num", "num", GridView2);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {

            }
            else if (e.CommandName == "deletee")
            {
                Model.Outout delete = new Model.Outout();
                int x = Convert.ToInt32(e.CommandArgument);
                delete.OuID = GridView1.Rows[x].Cells[1].Text;
                ideas.Style["display"] = "inline";
                Session["delete"] = delete.OuID;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button77_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = true;
            Div1.Visible = false;
            Button1.Visible = true;
            Button4.Visible = true;
            Button5.Visible = true;
            TextBox1.Visible = true;
            ListBox11.Visible = true;
            rg.Refresh("select * from Amount order by num", "", GridView2);
            Button1.Text = "新增出库";
            ListBox11.Items.Clear();
            ListBox11.Items.Add("");
            ListBox11.Items.Add("根据物品编号");
            ListBox11.Items.Add("根据库位编号");
        }
    }
}