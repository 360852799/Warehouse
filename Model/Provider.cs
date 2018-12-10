using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Provider
    {
        /// <summary>
        /// 供货商编号
        /// </summary>
        private string providerNum;
        public string ProviderNum
        {
            get
            {
                return providerNum;
            }
            set
            {
                providerNum = value;
            }
        }

        /// <summary>
        /// 供货商名称
        /// </summary>
        private string providerName;
        public string ProviderName
        {
            get
            {
                return providerName;
            }
            set
            {
                providerName = value;
            }
        }

        /// <summary>
        /// 系统管理员，没用
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

        /// <summary>
        /// 供货商负责人
        /// </summary>
        private string leader;
        public string Leader
        {
            get
            {
                return leader;
            }
            set
            {
                leader = value;
            }
        }

        /// <summary>
        /// 联系人
        /// </summary>
        private string contact;
        public string Contact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;
            }
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        private string contactNumber;
        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }
            set
            {
                contactNumber = value;
            }
        }

        /// <summary>
        /// 供货商地址
        /// </summary>
        private string providerAddress;
        public string ProviderAddress
        {
            get
            {
                return providerAddress;
            }
            set
            {
                providerAddress = value;
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createTime;
        public DateTime CreateTime
        {
            get
            {
                return createTime;
            }
            set
            {
                createTime = value;
            }
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        private DateTime updateTime;
        public DateTime UpdateTime
        {
            get
            {
                return updateTime;
            }
            set
            {
                updateTime = value;
            }
        }
    }
}
