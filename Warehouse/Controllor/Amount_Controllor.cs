using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
namespace Warehouse.Controllor
{
    public class Amount_Controllor
    {
        public static List<Amount> amount = null;
        public Amount_Controllor()
        {
            amount = new DAL.AmountDAO().getAllAmounts();
        }

        public List<Amount> getAmo()
        {
            return amount;
        }
    }
}