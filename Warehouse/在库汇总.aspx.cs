using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;
public partial class 出入库汇总 : System.Web.UI.Page
{
    public static List<Amount> amo = null; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
            BoundField bf2 = new BoundField(); bf2.DataField = "goods.goodsNum"; bf2.HeaderText = "物品编号";
            BoundField bf3 = new BoundField(); bf3.DataField = "goods.goodsName"; bf3.HeaderText = "物品名称";
            BoundField bf4 = new BoundField(); bf4.DataField = "goods.goodsType.goodsTypeName"; bf4.HeaderText = "物品类别";
            //BoundField bf5 = new BoundField(); bf5.DataField = "position.positionNum"; bf5.HeaderText = "库位编号";
            BoundField bf6 = new BoundField(); bf6.DataField = "goods.goodsCount"; bf6.HeaderText = "在库总数";
            BoundField bf7 = new BoundField(); bf7.DataField = "goods.goodsper"; bf7.HeaderText = "单位";
            GridView1.Columns.Add(bf1);
            GridView1.Columns.Add(bf2);
            GridView1.Columns.Add(bf3);
            GridView1.Columns.Add(bf4);
            //GridView1.Columns.Add(bf5);
            GridView1.Columns.Add(bf6);
            GridView1.Columns.Add(bf7);

            refreshAll();
            refredatabind();
            new Warehouse.Tools.AddSysLog().addlog("1", "在库汇总", "查询");

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //ListItem lt = new ListItem();
        //lt.Value = "";
        //TextBox1.Text = "";
        //TextBox2.Text = "";
        //ListBox1.Items.Add(lt);
        ListBox1.SelectedValue = "";
        //ListBox2.Items.Add(lt);
        ListBox2.Items.Clear();
        //ListBox3.Items.Add(lt);
        ListBox3.Items.Clear();
        //DropDownList1.Items.Add(lt);
        DropDownList1.SelectedValue = "";

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refreshAll();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    /// <summary>
    /// 刷新全部信息
    /// </summary>
    public void refreshAll()
    {
        if (amo != null)
        {
            GridView1.DataSource = amo;
        }
        else
        {
            List<Amount> dcs = new DAL.AmountDAO().getAllAmounts();
            GridView1.DataSource = dcs;
        }
        GridView1.DataBind();
        refreEmpty();
    }

    /// <summary>
    /// 如果无信息刷新提示
    /// </summary>
    public void refreEmpty()
    {
        if (GridView1.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("goods.goodsNum");
            dt.Columns.Add("goods.goodsName");
            dt.Columns.Add("goods.goodsType.goodsTypeName");
            //dt.Columns.Add("position.positionNum");
            dt.Columns.Add("goods.goodsCount");
            dt.Columns.Add("goods.goodsper");
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

        /*        绑定供应商        */
        //List<Provider> ps = new DAL.ProviderDAO().getAllProviders();
        //ListBox6.DataSource = ps;
        //ListBox6.DataTextField = "providerName";
        //ListBox6.DataValueField = "providerNum";
        //ListBox6.DataBind();
        //ListItem lt1 = new ListItem();
        //lt1.Value = "";
        //ListBox6.Items.Add(lt1);
        //ListBox6.SelectedValue = "";

        /*             绑定物品        */
        List<Goods> gs = new DAL.GoodsDAO().getAllGoods();
        //ListBox4.DataSource = cs;
        //ListBox4.DataTextField = "chestName";
        //ListBox4.DataValueField = "chestNum";
        //ListBox4.DataBind();

        DropDownList1.DataSource = gs;
        DropDownList1.DataTextField = "goodsname";
        DropDownList1.DataValueField = "goodsnum";
        DropDownList1.DataBind();
        ListItem lt2 = new ListItem();
        lt2.Value = "";
        DropDownList1.Items.Add(lt2);
        DropDownList1.SelectedValue = "";


        /*                绑定经办人           */
        //List<SysUser> sys = new DAL.SysUserDAO().getAllUsers();
        //ListBox5.DataSource = sys;
        //ListBox5.DataTextField = "userId";
        //ListBox5.DataValueField = "staffNum";
        //ListBox5.DataBind();
        //ListItem lt3 = new ListItem();
        //lt3.Value = "";
        //ListBox5.Items.Add(lt3);
        //ListBox5.SelectedValue = "";


        /*             绑定物品类别第一项        */
        List<GoodsType> gts = new DAL.GoodsTypeDAO().getParentGoodsTypes();
        ListBox1.DataSource = gts;
        ListBox1.DataTextField = "goodsTypeName";
        ListBox1.DataValueField = "goodsTypeNum";
        ListBox1.DataBind();
        ListItem lt4 = new ListItem();
        lt4.Value = "";
        ListBox1.Items.Add(lt4);
        ListBox1.SelectedValue = "";

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        refreshAll();
        new Warehouse.Tools.AddSysLog().addlog("1", "在库汇总", "查询");
        amo = null;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
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
            if(gts.Count>0)
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
        List<string> wheresql = new List<string>();
        List<Amount> ins = null;

        if (ListBox1.Text != "")            //判断物品类别是否选择
        {
            if (ListBox2.Text != "")
            {
                if (ListBox3.Text != "")
                {
                    wheresql.Add(" and goods.goodsTypeNum='"+ListBox3.SelectedValue.ToString()+"'");
                }
                else
                {
                    wheresql.Add(" and goods.goodsTypeNum='" + ListBox2.SelectedValue.ToString() + "'");
                }
            }
            else
            {
                wheresql.Add(" and goods.goodsTypeNum='" + ListBox1.SelectedValue.ToString() + "'");
            }
        }

        if (DropDownList1.Text != "")         //判断库柜是否选择
        {
            wheresql.Add(" and goods.goodsnum='" + DropDownList1.SelectedValue.ToString() + "'");
        }

        ins = new DAL.AmountDAO().getAmountsByWhere(wheresql);
        amo = ins;
        GridView1.DataSource = ins;
        GridView1.DataBind();
        new Warehouse.Tools.AddSysLog().addlog("1", "在库汇总", "查询");
        refreEmpty();
    }
}