using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class SysUser 
    {
        /// <summary>
        /// 用户属于员工类
        /// </summary>
        private staff staff;
        public staff Staff
        {
            get
            {
                return staff;
            }
            set
            {
                staff = value;
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
        /// 用户的员工编号
        /// </summary>
        private string staffNum;
        public string StaffNum
        {
            get
            {
                return staffNum;
            }
            set
            {
                staffNum = value;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        /// <summary>
        /// 用户的角色
        /// </summary>
        private string job;
        public string Job
        {
            get
            {
                return job;
            }
            set
            {
                job = value;
            }
        }
    }
}
