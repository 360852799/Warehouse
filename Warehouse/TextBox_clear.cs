using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace Warehouse
{
    public class TextBox_Clear : System.Web.UI.Page
    {
        public void clear(HtmlGenericControl xx)
        {
            foreach (Control x in xx.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = "";
                }
            }
        }
    }
}