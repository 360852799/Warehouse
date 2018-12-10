using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Warehouse
{
    public class Time
    {
        public DateTime time(DateTime y)
        {
            string bb = y.ToString();
            string xx = y.ToString("yyyy/MM/dd");
            StringBuilder sb = new StringBuilder();
            string x1 = "", x2 = "", x3 = "";
            foreach (char x in xx)
            {
                if (Convert.ToInt32(x) >= 48 && Convert.ToInt32(x) <= 57)
                {
                    sb.Append(x);
                }
                else if (Convert.ToInt32(x) == 47)
                {
                    break;
                }
            }
            x1 = sb.ToString();
            string yy1 = xx.Substring(sb.Length + 1, xx.Length - sb.Length - 1);
            sb.Remove(0, sb.Length);
            foreach (char x in yy1)
            {
                if (Convert.ToInt32(x) >= 48 && Convert.ToInt32(x) <= 57)
                {
                    sb.Append(x);
                }
                else if (Convert.ToInt32(x) == 47)
                {
                    break;
                }
            }
            x2 = sb.ToString();
            string zz = yy1.Substring(sb.Length + 1, yy1.Length - sb.Length - 1);
            sb.Remove(0, sb.Length);

            foreach (char x in zz)
            {
                if (Convert.ToInt32(x) >= 48 && Convert.ToInt32(x) <= 57)
                {
                    sb.Append(x);
                }
                else if (Convert.ToInt32(x) == 47)
                {
                    break;
                }
            }
            x3 = sb.ToString();
            if (x2.Length != 2)
            {
                x2 = "0" + x2;
            }
            if (x3.Length != 2)
            {
                x3 = "0" + x3;
            }
            int x4 =Convert.ToInt32(bb.Substring(bb.Length - 8, 2));
            int x5 = Convert.ToInt32(bb.Substring(bb.Length - 5, 2));
            int x6 = Convert.ToInt32(bb.Substring(bb.Length - 2, 2));
            x6 = x6 + 30;
            if (x6 > 59)
            {
                x5 = x5 + 1;
                x6 = x6 - 59;
                if (x5 > 59)
                {
                    x4 = x4 + 1;
                    x5 = x5 - 59;
                }
                if (x4 > 23)
                {
                    x3 = Convert.ToString(Convert.ToInt32(x3) + 1);
                    x4 = x4 - 23;
                }
            }
            string xx1 = Convert.ToString(x4);
            string xx2 = Convert.ToString(x5);
            string xx3 = Convert.ToString(x6);
            if (xx1.Length == 1)
            {
                xx1 = "0" + xx1;
            }
            if (xx2.Length == 1)
            {
                xx2 = "0" + xx2;
            }
            if (xx3.Length == 1)
            {
                xx3 = "0" + xx3;
            }
            y =Convert.ToDateTime(x1+"/" + x2+"/"+ x3 +" "+ xx1+":" + xx2+":" + xx3);
            return y;
        }
    }
}