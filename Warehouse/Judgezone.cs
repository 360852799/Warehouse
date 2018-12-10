using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class Judgezone
    {
        public string judge(string str1)
        {
            Warehouse.Controllor.transform ff = new Controllor.transform();
            ff.trans(str1);
            string x1 = System.Web.HttpContext.Current.Session["One"].ToString();
            string x2 = System.Web.HttpContext.Current.Session["Two"].ToString();
            string x3 = System.Web.HttpContext.Current.Session["Twozone"].ToString();
            string x4 = "";
            string x5 = "";
            try
            {
                x4 = System.Web.HttpContext.Current.Session["Twoo"].ToString();
                x5 = System.Web.HttpContext.Current.Session["Twoozone"].ToString();
            }
            catch
            {
                x4 = "";
                x5 = "";
            }
            Warehouse.Controllor.Queryareanum qu = new Controllor.Queryareanum();
            string x0 = qu.querying(x2);
            string x = x1 + x0 + x2;
            System.Web.HttpContext.Current.Session["zone1"] = x3;
            System.Web.HttpContext.Current.Session["zone2"] = x5;
            return x;
        }
    }
}