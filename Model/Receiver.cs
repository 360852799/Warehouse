using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Receiver
    {
        /// <summary>
        /// 收货商编号
        /// </summary>
        private string receiverNum;
        public string ReceiverNum
        {
            get
            {
                return receiverNum;
            }
            set
            {
                receiverNum = value;
            }
        }

        /// <summary>
        /// 收货商名称
        /// </summary>
        private string receiverName;
        public string ReceiverName
        {
            get
            {
                return receiverName;
            }
            set
            {
                receiverName = value;
            }
        }

        /// <summary>
        /// 系统管理员
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
        private string staffName;
        public string StaffName
        {
            get
            {
                return staffName;
            }
            set
            {
                staffName = value;
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
        /// 收货商地址
        /// </summary>
        private string receiverAddress;
        public string ReceiverAddress
        {
            get
            {
                return receiverAddress;
            }
            set
            {
                receiverAddress = value;
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
