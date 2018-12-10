using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
namespace Warehouse.Controllor
{
    public class Provoder_Controllor
    {
        public static List<Provider> pros = null;
        public Provoder_Controllor()
        {
            pros = new DAL.ProviderDAO().getAllProviders();
        }

        public List<Provider> getpro()
        {
            return pros;
        }
    }
}