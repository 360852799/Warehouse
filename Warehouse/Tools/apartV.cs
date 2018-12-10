using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class apartV
    {
        public double apart(string str1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char x in str1)
            {
                if ((Convert.ToInt32(x) > 47 && Convert.ToInt32(x) < 58)||(Convert.ToInt32(x)==46))
                {
                    sb.Append(x);
                }
            }
            return double.Parse(sb.ToString());
        }
    }
}