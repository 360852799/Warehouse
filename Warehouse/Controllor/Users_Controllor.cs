using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace Warehouse.Controllor
{
    public class Users_Controllor
    {
        public static List<SysUser> syss = null;
        public Users_Controllor()
        {
            syss = new DAL.SysUserDAO().getAllUsers();
        }

        public List<SysUser> getUsers()
        {
            return syss;
        }
    }
}