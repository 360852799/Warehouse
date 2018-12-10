using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Warehouse.Controllor
{
   public class City
    {
       public int transform(string str1)
       {
           char []a=str1.ToCharArray();
           string x1="",x2="",x3="",x4="",x5="",x6="",x7="",x8="";
           for (int i = 0; i < a.Length; i++)
           {
               if (a[i] == '省' || a[i] == '市' || a[i] == '区' || a[i] == '县' || a[i] == '旗' || a[i] == '岛' || a[i] == '族')
               {
                   x1 = str1.Substring(0, i+1);
                   x2 = str1.Substring(i + 1, str1.Length - (i + 1));
                   break;
               }
           }
           System.Web.HttpContext.Current.Session["x1"] = x1;
           char[] b = x2.ToCharArray();
           for (int i = 0; i < b.Length; i++)
           {
               if (b[i] == '省' || b[i] == '市' || b[i] == '区' || b[i] == '县' || a[i] == '旗' || a[i] == '岛' || a[i] == '族')
               {
                   x3 = x2.Substring(0, i + 1);
                   x4 = x2.Substring(i + 1, x2.Length - (i + 1));
                   break;
               }
           }
           System.Web.HttpContext.Current.Session["x2"] = x3;
           char[] c = x4.ToCharArray();
           for (int i = 0; i < c.Length; i++)
           {
               if (c[i] == '省' || c[i] == '市' || c[i] == '区' || c[i] == '县' || a[i] == '旗' || a[i] == '岛' || a[i] == '族')
               {
                   x5 = x4.Substring(0, i + 1);
                   x6 = x4.Substring(i + 1, x4.Length - (i + 1));
                   break;
               }
           }
           System.Web.HttpContext.Current.Session["x3"] = x5;
           char[] d = x6.ToCharArray();
           for (int i = 0; i < d.Length; i++)
           {
               if (d[i] == '省' || d[i] == '市' || d[i] == '区' || d[i] == '县' || a[i] == '旗' || a[i] == '岛' || a[i] == '族')
               {
                   x7 = x6.Substring(0, i + 1);
                   x8 = x6.Substring(i + 1, x6.Length - (i + 1));
                   break;
               }
           }
           System.Web.HttpContext.Current.Session["x4"] = x7;
           return 0;
       }
    }
}
