using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
public partial class 未完成出库 : System.Web.UI.Page
{
    public static string outBatch = null;      //记录修改的时候的批次编号
    public static string outID = null;           //记录修改的时候的出库ID
    public static string inBatch = null;      //记录修改的时候的批次编号
    public static string inID=null;           //记录修改的时候的入库ID
    public static Amount amount = null;          //记录如果修改库存，需要修改Amount表
    public static bool in_out = true;                 //记录当前的是操作出库还是入库，true是入库，false是出库
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            databindOut();
            databindIn();
            refreAllIn();
            refreAllOut();
            GridView1.Visible = false;
            addIn.Visible = false;
            addOut.Visible = false;
        }

        ButtonField bfG1 = GridView1.Columns[9] as ButtonField; bfG1.ControlStyle.BorderStyle = BorderStyle.None; bfG1.ControlStyle.BackColor = System.Drawing.Color.White;
        ButtonField bfG2 = GridView1.Columns[10] as ButtonField; bfG2.ControlStyle.BorderStyle = BorderStyle.None; bfG2.ControlStyle.BackColor = System.Drawing.Color.White;

        ButtonField bfG3 = GridView2.Columns[8] as ButtonField; bfG3.ControlStyle.BorderStyle = BorderStyle.None; bfG3.ControlStyle.BackColor = System.Drawing.Color.White;
        ButtonField bfG4 = GridView2.Columns[9] as ButtonField; bfG4.ControlStyle.BorderStyle = BorderStyle.None; bfG4.ControlStyle.BackColor = System.Drawing.Color.White;

    }


    public void databindOut()
    {
        BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
        BoundField bf2 = new BoundField(); bf2.DataField = "outID"; bf2.HeaderText = "出库id";
        BoundField bf3 = new BoundField(); bf3.DataField = "goodsname"; bf3.HeaderText = "物品名称";
        BoundField bf4 = new BoundField(); bf4.DataField = "goodstypename"; bf4.HeaderText = "物品类别";
        BoundField bf5 = new BoundField(); bf5.DataField = "positionnum"; bf5.HeaderText = "库位编号";
        BoundField bf6 = new BoundField(); bf6.DataField = "outAmount"; bf6.HeaderText = "预入库量";
        BoundField bf7 = new BoundField(); bf7.DataField = "indate"; bf7.HeaderText = "入库时间";
        BoundField bf8 = new BoundField(); bf8.DataField = "outdate"; bf8.HeaderText = "计划出库时间";
        BoundField bf9 = new BoundField(); bf9.DataField = "staffname"; bf9.HeaderText = "经办人";

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

    public void databindIn()
    {
        BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
        BoundField bf2 = new BoundField(); bf2.DataField = "inID"; bf2.HeaderText = "入库id";
        BoundField bf3 = new BoundField(); bf3.DataField = "goodsname"; bf3.HeaderText = "物品名称";
        BoundField bf4 = new BoundField(); bf4.DataField = "goodstypename"; bf4.HeaderText = "物品类别";
        BoundField bf5 = new BoundField(); bf5.DataField = "positionnum"; bf5.HeaderText = "库位编号";
        BoundField bf6 = new BoundField(); bf6.DataField = "inAmount"; bf6.HeaderText = "预出库量";
        BoundField bf7 = new BoundField(); bf7.DataField = "indate"; bf7.HeaderText = "计划入库时间";
        BoundField bf8 = new BoundField(); bf8.DataField = "staffname"; bf8.HeaderText = "经办人";

        GridView2.Columns.Add(bf1);
        GridView2.Columns.Add(bf2);
        GridView2.Columns.Add(bf3);
        GridView2.Columns.Add(bf4);
        GridView2.Columns.Add(bf5);
        GridView2.Columns.Add(bf6);
        GridView2.Columns.Add(bf7);
        GridView2.Columns.Add(bf8);
 
        ButtonField bf11 = new ButtonField(); bf11.CommandName = "editt"; bf11.Text = "编辑"; bf11.ControlStyle.BorderStyle = BorderStyle.None; bf11.ControlStyle.BackColor = System.Drawing.Color.White; bf11.ButtonType = ButtonType.Button; bf11.HeaderText = "";
        ButtonField bf12 = new ButtonField(); bf12.CommandName = "deletee"; bf12.Text = "删除"; bf12.ControlStyle.BorderStyle = BorderStyle.None; bf12.ControlStyle.BackColor = System.Drawing.Color.White; bf12.ButtonType = ButtonType.Button; bf12.HeaderText = "";

        GridView2.Columns.Add(bf11);
        GridView2.Columns.Add(bf12);

    }

    public void refreAllOut()
    {
        DataSet ds = new DAL.OutoutDAO().getOutsWhereFailToOut();
        GridView1.DataSource = ds.Tables[0].DefaultView.ToTable();
        GridView1.DataBind();
        refreEmpty(); 
    }

    public void refreAllIn()
    {
        DataSet ds = new DAL.IninDAO().getInWhereFailToIn();
        GridView2.DataSource = ds.Tables[0].DefaultView.ToTable();
        GridView2.DataBind();
        refreEmpty();
    }

    public void refreEmpty()
    {
        if (in_out)
        {
            if (GridView2.Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("inID");
                dt.Columns.Add("goodsname");
                dt.Columns.Add("goodstypename");
                dt.Columns.Add("positionnum");
                dt.Columns.Add("inAmount");
                dt.Columns.Add("indate");
                dt.Columns.Add("staffname");
                dt.Rows.Add(dt.NewRow());
                this.GridView2.DataSource = dt;
                this.GridView2.DataBind();
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 3;
                GridView2.Rows[0].Cells[0].Text = "您查询的信息为空";
                GridView2.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
        }
        else
        {
            if (GridView1.Rows.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("outID");
                dt.Columns.Add("goodsname");
                dt.Columns.Add("goodstypename");
                dt.Columns.Add("positionnum");
                dt.Columns.Add("outAmount");
                dt.Columns.Add("indate");
                dt.Columns.Add("outdate");
                dt.Columns.Add("staffname");
                dt.Rows.Add(dt.NewRow());
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 3;
                GridView1.Rows[0].Cells[0].Text = "您查询的信息为空";
                GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refreAllOut();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        refreAllIn();
    }

    protected void Button3_Click(object sender, EventArgs e)              //未完成入库按钮点击事件
    {

        GridView1.Visible = false;
        GridView2.Visible = true;
        in_out = true;
        refreAllIn();
        new Warehouse.Tools.AddSysLog().addlog("1", "未完成入库", "查询");
    }

    protected void Button2_Click(object sender, EventArgs e)             //未完成出库按钮点击事件
    {
        in_out = false;
        refreAllOut();
        GridView2.Visible = false;
        GridView1.Visible = true;
        new Warehouse.Tools.AddSysLog().addlog("1", "未完成出库", "查询");
        
    }

    protected void Button1_Click(object sender, EventArgs e)           //新增按钮点击事件
    {
        GridView1.Visible = false;
        GridView2.Visible = false;
        if (in_out)
        {
            addIn.Visible = true;
            TextBox4.ReadOnly = false;
            Button4.Text = "确认添加";
            Button5.Text = "取消添加";
        }
        else
        {
            addOut.Visible = true;
            TextBox7.ReadOnly = false;
            TextBox10.ReadOnly = false;
            Label13.Text = "入库ID";
            Button6.Text = "确认添加";
            Button7.Text = "取消添加";
        }
    }


    public void clea()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";

        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
    }


    public void cleaTitle()
    {
        if (in_out)
        {
            Label2.Text = "";
            Label4.Text = "";
            Label6.Text = "";
            Label8.Text = "";
            Label10.Text = "";
            Label12.Text = "";
        }
        else
        {
            Label14.Text = "";
            Label16.Text = "";
            Label18.Text = "";
            Label20.Text = "";
            Label22.Text = "";
            Label24.Text = "";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)        //入库确定添加按钮点击事件
    {
        cleaTitle();
        Button b = sender as Button;
        if (TextBox1.Text.Trim() == "" || TextBox2.Text.Trim() == "" || TextBox3.Text.Trim() == "" || TextBox4.Text.Trim() == "" || TextBox5.Text.Trim() == "" || TextBox6.Text.Trim() == "")
        {
            Response.Write("<script>alert('所有信息不能为空!')</script>");
        }
        else
        {
            bool condition = true;       //记录输入的东西是否符合条件，全都正确为true
            Position p = new DAL.PositionDAO().getPositionByNum(TextBox1.Text.Trim());
            if (p == null)
            {
                condition = false;
                Label2.Text = "没有查询到此库位";
            }

            Goods g = new DAL.GoodsDAO().getGoodsByNum(TextBox2.Text.Trim());
            if (g == null)
            {
                condition = false;
                Label4.Text = "没有查询到此物品";
            }

            int inamount;
            try
            {
                inamount = int.Parse(TextBox3.Text.Trim());
                if (inamount <= 0)
                {
                    int.Parse("测试");
                }
            }
            catch
            {
                condition = false;
                inamount = 0;
                Label6.Text = "输入格式错误,请输入大于0的整数";
            }

            Provider pr = new DAL.ProviderDAO().getProviderByNum(TextBox4.Text.Trim());
            if (pr == null)
            {
                condition = false;
                Label8.Text = "没有查询到此供应商";
            }

            if (TextBox5.Text.Length >= 100)
            {
                condition = false;
                Label10.Text = "输入长度大于100";
            }

            DateTime dt;
            try
            {
                dt = DateTime.Parse(TextBox6.Text.Trim());
                if (b.Text != "确认修改")
                {
                    if (dt < DateTime.Now)
                    {
                        condition = false;
                        Label12.Text = "输入日期必须大于等于今天的日期";
                    }
                }
            }
            catch
            {
                condition = false;
                dt = DateTime.Parse("2018-8-8");
                Label12.Text = "输入日期的格式不正确";
            }

            if (condition)
            {
                if (b.Text != "确认修改")
                {
                    Batch bt = new Batch();
                    bt.BatchNum = new Warehouse.Tools.batchNum().protect_batchNumByWPB("供货");
                    bt.ProorrecNum = TextBox4.Text.Trim();
                    bt.Condition = "准备";
                    bt.OutorinType = "入库";
                    bool batchsucc = new DAL.BatchDao().addBatch(bt);
                    new Warehouse.Tools.AddSysLog().addlog("1", "批次", "添加");
                    Inin ii = new Inin();
                    ii.PositionNum = TextBox1.Text.Trim();
                    ii.GoodsNum = TextBox2.Text.Trim();
                    ii.InAmount = inamount;
                    ii.Remark = TextBox5.Text.Trim();
                    ii.Date = dt;
                    bool ininsucc = new DAL.IninDAO().addIn(ii);
                    if (batchsucc && ininsucc)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                        new Warehouse.Tools.AddSysLog().addlog("1", "未完成入库", "添加");
                        addIn.Visible = false;

                        refreAllIn();

                        clea();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败！');", true);
                    }
                }
                else
                {

                    Inin ii = new Inin();
                    ii.PositionNum = TextBox1.Text.Trim();
                    ii.GoodsNum = TextBox2.Text.Trim();
                    ii.InAmount = inamount;
                    ii.Remark = TextBox5.Text.Trim();
                    ii.Date = dt;
                    ii.InID = inID;
                    ii.BatchNum = inBatch;
                    ii.UserId = "1";
                    bool ininsucc = new DAL.IninDAO().updateIn(ii);
                    if (ininsucc)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                        new Warehouse.Tools.AddSysLog().addlog("1", "未完成入库", "修改");
                        addIn.Visible = false;
                        GridView2.Visible = true;
                        refreAllIn();
                        inID = null;
                        inBatch = null;
                        clea();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
                    }
                }
            }
            else
            {
               
            }
        }
        

    }

    protected void Button5_Click(object sender, EventArgs e)           //入库取消添加按钮点击事件
    {      
        addIn.Visible = false;
        GridView2.Visible = true;
        clea();
        refreAllIn();
    }

    protected void Button6_Click(object sender, EventArgs e)            //添加出库按钮点击事件
    {
        cleaTitle();
        Button b = sender as Button;
        if (TextBox7.Text.Trim() == "" || TextBox8.Text.Trim() == "" || TextBox9.Text.Trim() == "" || TextBox10.Text.Trim() == "" || TextBox11.Text.Trim() == "" || TextBox12.Text.Trim() == "")
        {
            Response.Write("<script>alert('所有信息不能为空!')</script>");
        }
        else
        {
            bool condition = true;       //记录输入的东西是否符合条件，全都正确为true
            Inin i = new DAL.IninDAO().getInsById(TextBox7.Text.Trim());
            if (i == null)
            {
                condition = false;
                Label14.Text = "没有查询到此入库";
            }

            Goods g = new DAL.GoodsDAO().getGoodsByNum(TextBox8.Text.Trim());
            Amount am = null;
            if (g == null)
            {
                condition = false;
                Label16.Text = "没有查询到此物品";
            }
            else
            {
                List<string> sql = new List<string>();
                sql.Add(" and positionNum ='" + i.PositionNum + "'");
                sql.Add(" and GoodsNum='" + g.GoodsNum + "'");
                am= new DAL.AmountDAO().getAmountsByWherePoAndGo(sql);
                if (am == null)
                {
                    condition = false;
                    Label16.Text = "此物品在此库位无存货";
                }
                else if (am.Amounts <= 0)
                {
                    condition = false;
                    Label16.Text = "此物品在此库位无存货";
                }
            }
            
            int outamount;
            try
            {
                outamount = int.Parse(TextBox9.Text.Trim());
                if (outamount <= 0)
                {
                    condition = false;
                    outamount = 0;
                    Label18.Text = "输入格式错误,请输入大于0的整数";
                }
                else if(am!=null)
                {
                    if (am.Amounts < outamount)
                    {
                        condition = false;
                        outamount = 0;
                        Label18.Text = "库存数量小于出货数量";
                    }
                }
            }
            catch
            {
                condition = false;
                outamount = 0;
                Label18.Text = "输入格式错误,请输入整数";
            }

            Receiver re = new DAL.ReceiverDAO().getReceiverByNum(TextBox10.Text.Trim());
            if (re == null)
            {
                condition = false;
                Label20.Text = "没有查询到此收货商";
            }

            if (TextBox11.Text.Length >= 100)
            {
                condition = false;
                Label22.Text = "输入长度必须小于100";
            }

            DateTime dt;
            try
            {
                dt = DateTime.Parse(TextBox12.Text.Trim());
                if (b.Text != "确认修改")
                {
                    if (dt < DateTime.Now)
                    {
                        condition = false;
                        Label24.Text = "输入日期必须大于等于今天的日期";
                    }
                }
            }
            catch
            {
                condition = false;
                dt = DateTime.Parse("2018-8-8");
                Label24.Text = "输入日期的格式不正确";
            }

            if (condition)
            {
                if (b.Text != "确认修改")
                {
                    Batch bt = new Batch();
                    bt.BatchNum = new Warehouse.Tools.batchNum().protect_batchNumByWPB("收货");
                    bt.ProorrecNum = TextBox10.Text.Trim();
                    bt.Condition = "准备";
                    bt.OutorinType = "出库";
                    bool batchsucc = new DAL.BatchDao().addBatch(bt);
                    new Warehouse.Tools.AddSysLog().addlog("1", "批次", "添加");
                    Outout oo = new Outout();
                    oo.PositionNum = i.PositionNum;
                    oo.GoodsNum = TextBox8.Text.Trim();
                    oo.OutAmount = outamount;
                    oo.Remark = TextBox11.Text.Trim();
                    oo.Date = dt;
                    bool outoutsucc = new DAL.OutoutDAO().addOut(oo);
                    if (batchsucc && outoutsucc)
                    {
                        new Warehouse.Tools.AddSysLog().addlog("1", "未完成出库", "添加");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功！');", true);
                        addOut.Visible = true;
                        refreAllOut();
                        clea();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败！');", true);
                    }
                }
                else
                {
                    Outout oo = new Outout();
                    oo.PositionNum = TextBox1.Text.Trim();
                    oo.GoodsNum = TextBox2.Text.Trim();
                    oo.OutAmount = outamount;
                    oo.Remark = TextBox5.Text.Trim();
                    oo.Date = dt;
                    oo.OuID = outID;
                    oo.BatchNum = outBatch;
                    oo.UserId = "1";
                    bool ininsucc = new DAL.OutoutDAO().updateOut(oo);
                    if (ininsucc)
                    {
                        new Warehouse.Tools.AddSysLog().addlog("1", "未完成出库", "修改");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);

                        addIn.Visible = false;
                        GridView2.Visible = true;
                        refreAllIn();
                        outID = null;
                        outBatch = null;
                        clea();
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
                    }
                }
            }
            else
            {
                
            }
        }
    }

    protected void Button7_Click(object sender, EventArgs e)          //取消出库按钮点击事件
    {
        addOut.Visible = false;
        GridView1.Visible = true;
        refreAllOut();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editt")
        {
            int xy = Convert.ToInt32(e.CommandArgument);
            Model.Inin ins = new DAL.IninDAO().getInsById(GridView2.Rows[xy].Cells[1].Text);
            addIn.Visible = true;
            Button btn = sender as Button;
            GridViewRow row = GridView2.Rows[xy];
           
            inID = row.Cells[1].Text;
            inBatch = ins.BatchNum;
            TextBox1.Text = ins.PositionNum;
            TextBox2.Text = ins.GoodsNum;
            TextBox3.Text = ins.InAmount.ToString();
            TextBox4.Text = new DAL.BatchDao().getBatchByNum(ins.BatchNum).ProorrecNum;
            TextBox4.ReadOnly = true;
            TextBox5.Text = ins.Remark;
            TextBox6.Text = ins.Date.ToShortDateString();
            Button4.Text = "确认修改";
            Button5.Text = "取消修改";
            GridView2.Visible = false;
        }
        if (e.CommandName == "deletee")
        {
            int x = Convert.ToInt32(e.CommandArgument);
            string inid = GridView2.Rows[x].Cells[2].Text;
            bool yy = new DAL.IninDAO().deleteInById(inid);
            if (yy)
            {
                new Warehouse.Tools.AddSysLog().addlog("1", "未完成入库", "删除");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                refreAllIn();

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "editt")
        {
            int xy = Convert.ToInt32(e.CommandArgument);
            Model.Outout outs = new DAL.OutoutDAO().getOutsById(GridView1.Rows[xy].Cells[1].Text);
            addOut.Visible = true;
            Button btn = sender as Button;
            GridViewRow row = GridView1.Rows[xy];

            Label13.Text = "库位编号";
            outID = row.Cells[1].Text;
            outBatch = outs.BatchNum;
            TextBox7.Text = outs.PositionNum;
            TextBox7.ReadOnly = true;
            TextBox8.Text = outs.GoodsNum;
            TextBox9.Text = outs.OutAmount.ToString();
            TextBox10.Text = new DAL.BatchDao().getBatchByNum(outs.BatchNum).ProorrecNum;
            TextBox10.ReadOnly = true;
            TextBox11.Text = outs.Remark;
            TextBox12.Text = outs.Date.ToShortDateString();
            Button6.Text = "确认修改";
            Button7.Text = "取消修改";
            GridView1.Visible = false;
        }
        if (e.CommandName == "deletee")
        {
            new Warehouse.Tools.AddSysLog().addlog("1", "未完成出库", "删除");
            int x = Convert.ToInt32(e.CommandArgument);
            string inid = GridView1.Rows[x].Cells[2].Text;
            bool yy = new DAL.IninDAO().deleteInById(inid);
            if (yy)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                refreAllOut();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }
    }

}