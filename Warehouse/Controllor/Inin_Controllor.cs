using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Controllor
{
    public class Inin_Controllor
    {
        public static List<Inin> ins = null;
        public Inin_Controllor()
        {
            ins = new DAL.IninDAO().getAllIn();
        }

        public List<Inin> getinin()
        {
            return ins;
        }
    }
}