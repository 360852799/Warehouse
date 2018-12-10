using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
namespace Warehouse.Controllor
{
    public class Receiver_Controllor
    {
        public static List<Receiver> recs = null;
        public Receiver_Controllor()
        {
            recs = new DAL.ReceiverDAO().getAllReceivers();
        }

        public List<Receiver> getrec()
        {
            return recs;
        }
    }
}