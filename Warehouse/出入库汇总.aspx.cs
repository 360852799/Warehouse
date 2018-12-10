using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 在库汇总 : System.Web.UI.Page
{
    public static bool in_out = true;          //判断当前选择的是入库还是出库，true为in,false为out

    public static List<Inin> inin = null;               //记录下来查询结果，翻页的时候使用
    public static List<Outout> outout = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView2.AutoGenerateColumns = false;
        if (!IsPostBack)
        {
            refredatabind();
            refre_provide();
            
            receive.Visible = true;
            provide.Visible = false;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            new Warehouse.Tools.AddSysLog().addlog("1", "出入库汇总", "查询");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refre_provide();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
        refre_receive();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    /// <summary>
    /// 刷新函数，刷新收货商
    /// </summary>
    public void refre_receive()
    {
        if (outout == null)
        {
            List<Outout> dcs = new DAL.OutoutDAO().getAllOut();
            GridView2.DataSource = dcs;
        }
        else
        {
            GridView2.DataSource = inin;
        }
        GridView2.DataBind();

        refre_receive_Empty();
    }

    /// <summary>
    /// 刷新函数，刷新供货商
    /// </summary>
    public void refre_provide()
    {
        if (inin == null)
        {
            List<Inin> dcs = new DAL.IninDAO().getAllIn();            
            GridView1.DataSource = dcs;
        }
        else
        {
            GridView1.DataSource = outout;
        }
        GridView1.DataBind();
         
        refre_provide_Empty();

    }

    /// <summary>
    /// 刷新函数，如果供货商数据为空，显示无数据
    /// </summary>
    public void refre_provide_Empty()
    {
        GridView1.AutoGenerateColumns = false;
        if (GridView1.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("inID");
            dt.Columns.Add("goods.goodsName");
            dt.Columns.Add("goods.goodsType.goodsTypeName");
            dt.Columns.Add("position.positionNum");
            dt.Columns.Add("date");
            dt.Columns.Add("inAmount");
            dt.Columns.Add("batch.provider.providerName");
            dt.Columns.Add("sysuser.staff.staffname");
            dt.Rows.Add(dt.NewRow());
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 1;
            GridView1.Rows[0].Cells[0].Text = "您查询的信息为空";
            GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");  
        }
        
    }

    /// <summary>
    /// 绑定下拉框的数据
    /// </summary>
    public void refredatabind()
    {
        ListItem lt1 = new ListItem();
        lt1.Value = "";
        /*        绑定供应商        */
        List<Provider> ps = new DAL.ProviderDAO().getAllProviders();
        ListBox6.DataSource = ps;
        ListBox6.DataTextField = "providerName";
        ListBox6.DataValueField = "providerNum";
        ListBox6.DataBind();

        ListBox6.Items.Add(lt1);
        ListBox6.SelectedValue = "";

        /*             绑定库柜        */
        List<Chest> cs = new DAL.ChestDAO().getAllChests();
        ListBox4.DataSource = cs;
        ListBox4.DataTextField = "chestName";
        ListBox4.DataValueField = "chestNum";
        ListBox4.DataBind();

        ListBox4.Items.Add(lt1);
        ListBox4.SelectedValue = "";

        /*                绑定经办人           */
        List<SysUser> sys = new DAL.SysUserDAO().getAllUsers();
        ListBox5.DataSource = sys;
        ListBox5.DataTextField = "userId";
        ListBox5.DataValueField = "staffnum";
        ListBox5.DataBind();

        ListBox5.Items.Add(lt1);
        ListBox5.SelectedValue = "";


        /*             绑定物品类别第一项        */
        List<GoodsType> gts = new DAL.GoodsTypeDAO().getParentGoodsTypes();
        ListBox1.DataSource = gts;
        ListBox1.DataTextField = "goodsTypeName";
        ListBox1.DataValueField = "goodsTypeNum";
        ListBox1.DataBind();

        ListBox1.Items.Add(lt1);
        ListBox1.SelectedValue = "";


        /*            绑定gridview数据源            */
        BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
        BoundField bf2 = new BoundField(); bf2.DataField = "inID"; bf2.HeaderText = "编号";
        BoundField bf3 = new BoundField(); bf3.DataField = "goods.goodsName"; bf3.HeaderText = "物品名称";
        BoundField bf4 = new BoundField(); bf4.DataField = "goods.goodsType.goodsTypeName"; bf4.HeaderText = "物品类别";
        BoundField bf5 = new BoundField(); bf5.DataField = "position.positionNum"; bf5.HeaderText = "库位编号";
        BoundField bf6 = new BoundField(); bf6.DataField = "date"; bf6.HeaderText = "入库时间";
        BoundField bf7 = new BoundField(); bf7.DataField = "inAmount"; bf7.HeaderText = "入库量";
        BoundField bf8 = new BoundField(); bf8.DataField = "batch.provider.providername"; bf8.HeaderText = "供应商";
        BoundField bf9 = new BoundField(); bf9.DataField = "sysuser.staff.staffname"; bf9.HeaderText = "经办人";

        GridView1.Columns.Add(bf1);
        GridView1.Columns.Add(bf2);
        GridView1.Columns.Add(bf3);
        GridView1.Columns.Add(bf4);
        GridView1.Columns.Add(bf5);
        GridView1.Columns.Add(bf6);
        GridView1.Columns.Add(bf7);
        GridView1.Columns.Add(bf8);
        GridView1.Columns.Add(bf9);

        BoundField bf11 = new BoundField(); bf11.HeaderText = "序号";
        BoundField bf12 = new BoundField(); bf12.DataField = "ouID"; bf12.HeaderText = "编号";
        BoundField bf13 = new BoundField(); bf13.DataField = "goods.goodsName"; bf13.HeaderText = "物品名称";
        BoundField bf14 = new BoundField(); bf14.DataField = "goods.goodsType.goodsTypeName"; bf14.HeaderText = "物品类别";
        BoundField bf15 = new BoundField(); bf15.DataField = "position.positionNum"; bf15.HeaderText = "库位编号";
        BoundField bf16 = new BoundField(); bf16.DataField = "date"; bf16.HeaderText = "出库时间";
        BoundField bf17 = new BoundField(); bf17.DataField = "outAmount"; bf17.HeaderText = "出库量";
        BoundField bf18 = new BoundField(); bf18.DataField = "batch.receiver.receivername"; bf18.HeaderText = "收货商";
        BoundField bf19 = new BoundField(); bf19.DataField = "sysuser.staff.staffname"; bf19.HeaderText = "经办人";

        GridView2.Columns.Add(bf11);
        GridView2.Columns.Add(bf12);
        GridView2.Columns.Add(bf13);
        GridView2.Columns.Add(bf14);
        GridView2.Columns.Add(bf15);
        GridView2.Columns.Add(bf16);
        GridView2.Columns.Add(bf17);
        GridView2.Columns.Add(bf18);
        GridView2.Columns.Add(bf19);
    }

    /// <summary>
    /// 刷新函数，如果收货商数据为空，显示无数据
    /// </summary>
    public void refre_receive_Empty()
    {
        GridView2.AutoGenerateColumns = false;
        if (GridView2.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ouID");
            dt.Columns.Add("goods.goodsName");
            dt.Columns.Add("goods.goodsType.goodsTypeName");
            dt.Columns.Add("position.positionNum");
            dt.Columns.Add("date");
            dt.Columns.Add("outAmount");
            dt.Columns.Add("batch.receiver.receiverName");
            dt.Columns.Add("sysuser.staff.staffname");
            dt.Rows.Add(dt.NewRow());
            this.GridView2.DataSource = dt;
            this.GridView2.DataBind();
            GridView2.Rows[0].Cells.Clear();
            GridView2.Rows[0].Cells.Add(new TableCell());
            GridView2.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count + 1;
            GridView2.Rows[0].Cells[0].Text = "您查询的信息为空";
            GridView2.Rows[0].Cells[0].Style.Add("text-align", "center");
        }
        
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        receive.Visible = true;
        provide.Visible = false;
        TextBox3.Enabled = false;
        TextBox4.Enabled = false;
        TextBox1.Enabled = true;
        TextBox2.Enabled = true;
        in_out = true;
        clea();
        inin = null;
        outout = null;
        refre_provide();
        
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        receive.Visible = false;
        provide.Visible = true;
        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        TextBox3.Enabled = true;
        TextBox4.Enabled = true;
        in_out = false;
        clea();
        
        inin = null;
        outout = null;
        refre_receive();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        clea();
    }

    /// <summary>
    /// 清空函数，清空全部选项框中的数据
    /// </summary>
    public void clea()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        ListBox1.SelectedValue = "";
        ListBox2.Items.Clear();
        ListBox3.Items.Clear();
        ListBox4.SelectedValue = "";
        ListBox5.SelectedValue = "";
        ListBox6.SelectedValue = "";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (in_out)
        {
            refre_provide();
        }
        else
        {
            refre_receive();
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox1.SelectedValue == "")
        {
            ListBox2.Items.Clear();
            ListBox3.Items.Clear();
        }
        else
        {
            List<GoodsType> gts = new DAL.GoodsTypeDAO().getGoodsTypesByParentNum(ListBox1.SelectedValue.ToString());
            if (gts.Count > 0)
            {
                ListBox2.DataSource = gts;
                ListBox2.DataTextField = "goodsTypeName";
                ListBox2.DataValueField = "goodsTypeNum";
                ListBox2.DataBind();
                ListItem lt4 = new ListItem();
                lt4.Value = "";
                ListBox2.Items.Add(lt4);
                ListBox2.SelectedValue = "";
            }
        }
    }

    protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox2.SelectedValue == "")
        {
            ListBox3.Items.Clear();
        }
        else
        {
            List<GoodsType> gts = new DAL.GoodsTypeDAO().getGoodsTypesByParentNum(ListBox2.SelectedValue.ToString());
            if (gts.Count > 0)
            {
                ListBox3.DataSource = gts;
                ListBox3.DataTextField = "goodsTypeName";
                ListBox3.DataValueField = "goodsTypeNum";
                ListBox3.DataBind();
                ListItem lt4 = new ListItem();
                lt4.Value = "";
                ListBox3.Items.Add(lt4);
                ListBox3.SelectedValue = "";
            }
        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (in_out)
        {
            List<Inin> ins = null;
            List<string> sqlwhere = new List<string>();
            if (TextBox1.Text.Trim() != "" && TextBox2.Text.Trim() != "")          //判断时间是否填写
            {
                DateTime dt1;
                DateTime dt2;
                try
                {
                    dt1 = DateTime.Parse(TextBox1.Text.Trim());
                    dt2 = DateTime.Parse(TextBox2.Text.Trim());

                    if (dt1 > dt2)
                    {
                        Response.Write("<script>alert('日期区间错误应从小到大!')</script>");
                        return;
                    }
                    else
                    {
                        sqlwhere.Add(" and date between '" + dt1.ToShortDateString().ToString() + " 00:00:00' and '" + dt2.ToShortDateString().ToString() + " 00:00:00' ");
                    }
                }
                catch
                {
                    Response.Write("<script>alert('日期格式不正确，应输入例:2018-8-8!')</script>");
                    return;
                }
            }

            if (ListBox1.Text != "")            //判断物品类别是否选择
            {
                if (ListBox2.Text != "")
                {
                    if (ListBox3.Text != "")
                    {
                        sqlwhere.Add(" and goods.goodsTypeNum='" + ListBox3.SelectedValue.ToString() + "'");

                    }
                    else
                    {
                        sqlwhere.Add(" and goods.goodsTypeNum='" + ListBox2.SelectedValue.ToString() + "'");
                    }
                }
                else
                {
                    sqlwhere.Add(" and goods.goodsTypeNum='" + ListBox1.SelectedValue.ToString() + "'");
                }
            }
            if (ListBox4.Text != "")         //判断库柜是否选择
            {
                sqlwhere.Add(" and chest.chestNum='" + ListBox4.SelectedValue.ToString() + "'");
            }

            if (ListBox5.Text != "")         //判断经办人是否选择
            {
                sqlwhere.Add(" and sysuser.staffNum='" + ListBox5.SelectedValue.ToString() + "'");
            }

            if (ListBox6.Text != "")         //判断供应商是否选择
            {
                sqlwhere.Add(" and provider.providerNum='" + ListBox6.SelectedValue.ToString() + "'");
            }
            ins = new DAL.IninDAO().getInsByWhere(sqlwhere);

            inin = ins;
            GridView1.DataSource = ins;
            GridView1.DataBind();
            new Warehouse.Tools.AddSysLog().addlog("1", "出入库汇总", "查询");
            refre_provide_Empty();
        }
        else
        {
            List<Outout> outs = null;
            List<string> sqlwhere = new List<string>();
            if (TextBox3.Text.Trim() != "" && TextBox4.Text.Trim() != "")          //判断时间是否填写
            {
                DateTime dt1;
                DateTime dt2;
                try
                {
                    dt1 = DateTime.Parse(TextBox3.Text.Trim());
                    dt2 = DateTime.Parse(TextBox4.Text.Trim());

                    if (dt1 > dt2)
                    {
                        Response.Write("<script>alert('日期区间错误应从小到大!')</script>");
                        return;
                    }
                    else
                    {
                        sqlwhere.Add(" and date between '" + dt1.ToShortDateString().ToString() + " 00:00:00' and '" + dt2.ToShortDateString().ToString() + " 00:00:00' ");
                    }
                }
                catch
                {
                    Response.Write("<script>alert('日期格式不正确，应输入例:2018-8-8!')</script>");
                    return;
                }
            }

            if (ListBox1.Text != "")            //判断物品类别是否选择
            {
                if (ListBox2.Text != "")
                {
                    if (ListBox3.Text != "")
                    {
                        sqlwhere.Add(" and goods.goodsTypeNum='" + ListBox3.SelectedValue.ToString() + "'");

                    }
                    else
                    {
                        sqlwhere.Add(" and goods.goodsTypeNum='" + ListBox2.SelectedValue.ToString() + "'");
                    }
                }
                else
                {
                    sqlwhere.Add(" and goods.goodsTypeNum='" + ListBox1.SelectedValue.ToString() + "'");
                }
            }

            if (ListBox4.Text != "")         //判断库柜是否选择
            {
                sqlwhere.Add(" and chest.chestNum='" + ListBox4.SelectedValue.ToString() + "'");
            }

            if (ListBox5.Text != "")         //判断经办人是否选择
            {
                sqlwhere.Add(" and sysuser.staffNum='" + ListBox5.SelectedValue.ToString() + "'");
            }

            if (ListBox6.Text != "")         //判断供应商是否选择
            {
                sqlwhere.Add(" and receiver.receiverNum='" + ListBox6.SelectedValue.ToString() + "'");
            }

            outs = new DAL.OutoutDAO().getOutsByWhere(sqlwhere);
            outout = outs;
            GridView2.DataSource = outs;
            GridView2.DataBind();
            new Warehouse.Tools.AddSysLog().addlog("1", "出入库汇总", "查询");
            refre_receive_Empty();

        }
    }
}