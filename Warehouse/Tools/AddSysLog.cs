using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace Warehouse.Tools
{
    public class AddSysLog
    {
        /// <summary>
        /// 添加系统日志
        /// </summary>
        /// <param name="userid">操作者用户名</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="PageName">操作页面的名字</param>
        /// <param name="actionType">操作类型，增加，删除，修改，删除</param>
        /// <returns>添加成功返回true，添加失败返回false</returns>
        public bool addlog(string userid,string PageName, string actionType)
        {

            IPAddress localIp = null;
            IPAddress[] ipArray;
            ipArray = Dns.GetHostAddresses(Dns.GetHostName());
            localIp = ipArray.First(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            
            Model.SysLog sl = new Model.SysLog();
            sl.UserId = userid;
            sl.IpAddress = localIp.ToString();
            sl.Column = PageName;
            sl.ActionType = actionType;
            sl.ActionTime = DateTime.Now;
            bool success = new DAL.SysLogDAO().addLog(sl);
            return success;
        }
    }
}