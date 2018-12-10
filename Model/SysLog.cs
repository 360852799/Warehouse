using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SysLog
    {
        private  SysUser sysUser;
        public SysUser SysUser
        {
            get
            {
                return sysUser;
            }
            set
            {
                sysUser = value;
            }
        }

        /// <summary>
        /// 日志ID
        /// </summary>
        private string logId;
        public string LogId
        {
            get
            {
                return logId;
            }
            set
            {
                logId = value;
            }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        private string userId;
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        /// <summary>
        /// IP地址
        /// </summary>
        private string ipAddress;
        public string IpAddress
        {
            get
            {
                return ipAddress;
            }
            set
            {
                ipAddress = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        private DateTime actionTime;
        public DateTime ActionTime
        {
            get
            {
                return actionTime;
            }
            set
            {
                actionTime = value;
            }
        }

        /// <summary>
        /// 栏目，操作菜单的名称
        /// </summary>
        private string column;
        public string Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        /// <summary>
        /// 用户的操作
        /// </summary>
        private string actionType; 
       public string ActionType
        {
            get
            {
                return actionType;
            }
            set
            {
                actionType = value;
            }
        }
    }
}
