using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Department
    {
        /// <summary>
        /// 部门的ID
        /// </summary>
        /// 
        private string departId;
        public string DepartId
        {
            get
            {
                return departId;
            }
            set
            {
                departId = value;
            }
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        private string departName;
        public string DepartName
        {
            get
            {
                return departName;
            }
            set
            {
                departName = value;
            }
        }

        /// <summary>
        /// 负责人
        /// </summary>
        private SysUser sysUser ;
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
        private string num;
        public string Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }
        /// <summary>
        /// 上级部门
        /// </summary>
        private string parentdepartName ;
        public string ParentdepartName
        {
            get
            {
                return parentdepartName;
            }
            set
            {
                parentdepartName = value;
            }
        }
    }
}
