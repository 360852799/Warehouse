using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class staff
    {
        /// <summary>
        /// 所在部门
        /// </summary>
        private string departId ;
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
        /// 部门类实例化
        /// </summary>
        private Department department;

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }
        /// <summary>
        /// 员工编号
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
        /// 员工姓名
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
        /// 出生日期
        /// </summary>
        private DateTime birthday;
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        private string gender;
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        /// <summary>
        /// 籍贯
        /// </summary>
        private string hometown;
        public string Hometown
        {
            get
            {
                return hometown;
            }
            set
            {
                hometown = value;
            }
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        private string idCard;
        public string IdCard
        {
            get
            {
                return idCard;
            }
            set
            {
                idCard = value;
            }
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        /// <summary>
        /// 入职时间
        /// </summary>
        private DateTime entryTime;
        public DateTime EntryTime
        {
            get
            {
                return entryTime;
            }
            set
            {
                entryTime = value;
            }
        }
    }
}
