using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;

namespace Warehouse
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Warehouse.Controllor.transform ff = new Controllor.transform();
            ff.trans("");
            string x1 = Session["One"].ToString();
            string x2 = Session["Two"].ToString();
            string x3 = Session["Twozone"].ToString();
            string x4 = "";
            string x5 = "";
            try
            {
                x4 = Session["Twoo"].ToString();
                x5 = Session["Twoozone"].ToString();
            }
            catch
            {
                x4 = "";
                x5 = "";
            }
            Warehouse.Controllor.Queryareanum qu = new Controllor.Queryareanum();
            string x0=qu.querying(x2);
            string x = x1 + x0 + x2;
        }
    }
}