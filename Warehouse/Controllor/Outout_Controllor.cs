using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Controllor
{
    public class Outout_Controllor
    {
        public static List<Outout> outs = null;
        public Outout_Controllor()
        {
            outs = new DAL.OutoutDAO().getAllOut();
        }

        public List<Outout> getoutout()
        {
            return outs;
        }
    }
}