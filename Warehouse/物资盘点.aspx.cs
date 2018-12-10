using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;

public partial class 物资盘点 : System.Web.UI.Page
{
    public static List<Amount> aas = new Warehouse.Controllor.Amount_Controllor().getAmo();
    public static List<Inin> ins = new Warehouse.Controllor.Inin_Controllor().getinin();

    public static bool Amount_Inin = true;          //判断当前是查询的库存表还是进货表
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            databind_G1();
            databind_G2();
            GridView1.Visible = true;
            GridView2.Visible = false;
            refresh();
            refre_databind();
            
        }

    }

    public void databind_G1()
    {
        BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
        BoundField bf2 = new BoundField(); bf2.DataField = "goods.goodsNum"; bf2.HeaderText = "编号";
        BoundField bf3 = new BoundField(); bf3.DataField = "goods.goodsname"; bf3.HeaderText = "物品名称";
        BoundField bf4 = new BoundField(); bf4.DataField = "goods.goodstype.goodstypename"; bf4.HeaderText = "物品类别";
        BoundField bf5 = new BoundField(); bf5.DataField = "amounts"; bf5.HeaderText = "数量";

        GridView1.Columns.Add(bf1);
        GridView1.Columns.Add(bf2);
        GridView1.Columns.Add(bf3);
        GridView1.Columns.Add(bf4);
        GridView1.Columns.Add(bf5);
    }

    public void databind_G2()
    {
        BoundField bf1 = new BoundField(); bf1.HeaderText = "序号";
        BoundField bf2 = new BoundField(); bf2.DataField = "goods.goodsNum"; bf2.HeaderText = "编号";
        BoundField bf3 = new BoundField(); bf3.DataField = "goods.goodsname"; bf3.HeaderText = "物品名称";
        BoundField bf4 = new BoundField(); bf4.DataField = "goods.goodstype.goodstypename"; bf4.HeaderText = "物品类别";
        BoundField bf5 = new BoundField(); bf5.DataField = "inAmount"; bf5.HeaderText = "入库数量";
        BoundField bf6 = new BoundField(); bf6.DataField = "date"; bf6.HeaderText = "入库时间";
        BoundField bf7 = new BoundField(); bf7.DataField = "sysUser.staff.staffname"; bf7.HeaderText = "经办人";

        GridView2.Columns.Add(bf1);
        GridView2.Columns.Add(bf2);
        GridView2.Columns.Add(bf3);
        GridView2.Columns.Add(bf4);
        GridView2.Columns.Add(bf5);
        GridView2.Columns.Add(bf6);
        GridView2.Columns.Add(bf7);
    }

    public void refresh()
    {
        if (Amount_Inin)
        {
            GridView1.DataSource = aas;
            GridView1.DataBind();
        }
        else
        {
            GridView2.DataSource = ins;
            GridView2.DataBind();
        }
        
    }

    public void refre_databind()
    {
        ListItem lt2 = new ListItem();
        lt2.Value = "";

        ListBox3.DataSource = new DAL.GoodsTypeDAO().getParentGoodsTypes();
        
        ListBox3.DataTextField = "goodsTypeName";
        ListBox3.DataValueField = "goodsTypeNum";
        ListBox3.DataBind();
        ListBox3.Items.Add(lt2);
        ListBox3.SelectedValue = "";

        ListBox2.DataSource = new DAL.GoodsDAO().getAllGoods();
        
        ListBox2.DataTextField = "goodsName";
        ListBox2.DataValueField = "goodsNum";
        ListBox2.DataBind();
        ListBox2.Items.Add(lt2);
        ListBox2.SelectedValue = "";
        
    }

    public void refre_empty_G1()
    {
        if (GridView1.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("goods.goodsNum");
            dt.Columns.Add("goods.goodsName");
            dt.Columns.Add("goods.goodsType.goodsTypeName");

            dt.Columns.Add("amounts");

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

    public void refre_empty_G2()
    {
        if (GridView2.Rows.Count == 0)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("goods.goodsNum");
            dt.Columns.Add("goods.goodsName");
            dt.Columns.Add("goods.goodsType.goodsTypeName");
            dt.Columns.Add("inAmount");
            dt.Columns.Add("date");
            dt.Columns.Add("sysUser.staff.staffname");

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

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView2.Visible = false;
        Amount_Inin = true;
        List<string> sqlWhere = new List<string> ();
        if (ListBox3.SelectedValue == "" && ListBox2.SelectedValue == "")
        {
            aas = new DAL.AmountDAO().getAllAmounts();
            refresh();
        }
        else
        {
            if (ListBox3.SelectedValue != "")
            {
                if (ListBox4.SelectedValue != "")
                {
                    if (ListBox1.SelectedValue != "")
                    {
                        sqlWhere.Add(" and goods.goodsTypeNum='" + ListBox1.SelectedValue + "'");
                    }
                    else
                    {
                        sqlWhere.Add(" and goods.goodsTypeNum='" + ListBox4.SelectedValue + "'");
                    }
                }
                else
                {
                    sqlWhere.Add(" and goods.goodsTypeNum='" + ListBox3.SelectedValue + "'");
                }
            }
            
            if (ListBox2.SelectedValue != "")
            {
                sqlWhere.Add(" and goods.goodsNum='" + ListBox2.SelectedValue + "'");
            }
            aas = new DAL.AmountDAO().getAmountsByWhere(sqlWhere);
            
            GridView1.DataSource = aas;
            GridView1.DataBind();
        }
        refre_empty_G1();
    }

    protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox3.SelectedValue != "")
        {
            ListItem lt2 = new ListItem();
            lt2.Value = "";

            ListBox4.DataSource = new DAL.GoodsTypeDAO().getGoodsTypesByParentNum(ListBox3.SelectedValue);
            
            ListBox4.DataTextField = "goodsTypeName";
            ListBox4.DataValueField = "goodsTypeNum";
            ListBox4.DataBind();
            ListBox4.Items.Add(lt2);
            ListBox4.SelectedValue = "";
        }
        else
        {
            ListBox4.Items.Clear();
            ListBox1.Items.Clear();
        }
    }

    protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox4.SelectedValue != "")
        {
            ListItem lt2 = new ListItem();
            lt2.Value = "";

            ListBox1.DataSource = new DAL.GoodsTypeDAO().getGoodsTypesByParentNum(ListBox4.SelectedValue);
            
            ListBox1.DataTextField = "goodsTypeName";
            ListBox1.DataValueField = "goodsTypeNum";
            ListBox1.DataBind();
            ListBox1.Items.Add(lt2);
            ListBox1.SelectedValue = "";
        }
        else
        {      
            ListBox1.Items.Clear();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        refresh();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
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
                    ins = new DAL.IninDAO().getInsByWhere(sqlwhere);
                    GridView1.Visible = false;
                    GridView2.Visible = true;
                    Amount_Inin = false;
                }
            }
            catch
            {
                Response.Write("<script>alert('日期格式不正确，应输入例:2018-8-8!')</script>");
                return;
            }
        }
        else
        {
            Response.Write("<script>alert('请填写时间区间')</script>");
        }
        refresh();
        refre_empty_G2();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        refresh(); 
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }
}