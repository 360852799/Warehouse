using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Warehouse.Tools
{
    public class tiqushuzi
    {
        public double tiqu(string mm)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char x in mm)
            {
                if ((Convert.ToInt32(x) > 47 && Convert.ToInt32(x) < 58) || (Convert.ToInt32(x)==46))
                {
                    sb.Append(x);
                }
            }
            return Convert.ToDouble(sb.ToString());
        }
    }
}