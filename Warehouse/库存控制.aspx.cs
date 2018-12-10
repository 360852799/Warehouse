using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Warehouse
{
    public partial class 库存控制 : System.Web.UI.Page
    {
        Warehouse.Controllor.Control_Bind gb = new Controllor.Control_Bind();
        Warehouse.Controllor.RefreshGridview rg = new Controllor.RefreshGridview();
        Warehouse.Tools.queryV qu = new Tools.queryV();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gb.Bind1(GridView1);
                gb.Bind3(GridView2);
                rg.Control_Refresh(GridView1);
                rg.Control_Refresh2(GridView2);
            }
            gb.Bind2(GridView1);
            gb.Bind4(GridView2);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }       
    }
}