using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Controllor
{
    public class JudgeChinese
    {
        public bool Judge(string xx)
        {
            bool yy = true;
            foreach (char x in xx)
            {
                if (Convert.ToInt32(x) < 127)
                {
                    yy = false;
                    break;
                }
                else 
                {
                    yy = true;
                }
            }
            return yy;
        }
    }
}