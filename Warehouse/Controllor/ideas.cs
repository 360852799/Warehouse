using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class ideas
    {
        public void div(HtmlGenericControl x)
        {
            HtmlGenericControl div1 = new HtmlGenericControl();
            HtmlGenericControl div2 = new HtmlGenericControl();
            HtmlGenericControl div3 = new HtmlGenericControl();

            div1.Attributes.Add("id", "div1");
            div1.Attributes.Add("runat", "server");
            div1.Style["height"] = "180px";
            div1.Style["width"] = "300px";
            div1.Style["background-color"] = "#fff";
            div1.Style["border"] = "1px solid #000";
            div1.Style["position"] = "absolute";
            div1.Style["left"] = "500px";
            div1.Style["top"] = "380px";
            //div1.Style["display"] = "none";
            x.Controls.Add(div1);

            div2.Style["height"] = "100px";
            div2.Style["width"] = "300px";
            div2.Style["background-color"] = "white";
            div1.Controls.Add(div2);

            Label lab1 = new Label ();
            lab1.Attributes.Add("ID", "Label100");
            lab1.Attributes.Add("runat", "server");
            lab1.Text = "确定要删除吗？";
            lab1.Style["line-height"] = "80px";
            lab1.Style["font-size"] = "22px";
            lab1.Style["margin-left"] = "73px";
            div2.Controls.Add(lab1);

            div3.Style["height"] = "50px";
            div3.Style["width"] = "300px";
            div3.Style["background-color"] = "white";
            div3.Style["margin-top"] = "20px";
            div1.Controls.Add(div3);
            Button btn1 = new Button();
            Button btn2 = new Button();
            btn1.Attributes.Add("ID", "Button200");
            btn1.Attributes.Add("runat", "server");
            btn1.Text = "确认";
            btn1.Style["font-size"] = "22px";
            btn1.Style["width"] = "80px";
            btn1.Style["height"] = "40px";
            btn1.Style["margin-left"] = "60px";
            btn1.Style["border"] = "1px solid #1377f0";
            btn1.Click += new System.EventHandler(this.Button1_Click);
            btn2.Attributes.Add("ID", "Button300");
            btn2.Attributes.Add("runat", "server");
            btn2.Text = "取消";
            btn2.Style["font-size"] = "22px";
            btn2.Style["width"] = "80px";
            btn2.Style["height"] = "40px";
            btn2.Style["margin-left"] = "30px";
            btn2.Click += new System.EventHandler(this.Button2_Click);
            div3.Controls.Add(btn1);
            div3.Controls.Add(btn2);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session["xx"] = "确定";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session["xx"] = "取消";
        }
    }
}