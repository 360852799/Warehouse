using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label4.Attributes.Add("onclick", "X1()");
            Label5.Attributes.Add("onclick", "X2()");
            Label6.Attributes.Add("onclick", "X3()");
            Label7.Attributes.Add("onclick", "X4()");
            Label8.Attributes.Add("onclick", "X5()");
            Label9.Attributes.Add("onclick", "X6()");
            Label11.Attributes.Add("onclick", "X7()");
            Label12.Attributes.Add("onclick", "X8()");
            Label13.Attributes.Add("onclick", "X9()");
            Label15.Attributes.Add("onclick", "X10()");
            Label16.Attributes.Add("onclick", "X11()");
            Label17.Attributes.Add("onclick", "X12()");
            Label25.Attributes.Add("onclick", "X13()");
            Label26.Attributes.Add("onclick", "X14()");
            Label27.Attributes.Add("onclick", "X15()");
            Label28.Attributes.Add("onclick", "X16()");
            Label19.Attributes.Add("onclick", "X17()");
            Label20.Attributes.Add("onclick", "X18()");
            Label21.Attributes.Add("onclick", "X19()");
            Label22.Attributes.Add("onclick", "X20()");
        }
    }
}
