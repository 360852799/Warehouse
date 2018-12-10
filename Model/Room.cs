using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Room
    {
        /// <summary>
        /// 房间编号
        /// </summary>
        private string roomNum;
        public string RoomNum
        {
            get
            {
                return roomNum;
            }
            set
            {
                roomNum = value;
            }
        }

        /// <summary>
        /// 编号
        /// </summary>
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
        /// 房间名
        /// </summary>
        private string roomName;
        public string RoomName
        {
            get
            {
                return roomName;
            }
            set
            {
                roomName = value;
            }
        }

        /// <summary>
        /// 库柜上限
        /// </summary>
        private int chestMax;
        public int ChestMax
        {
            get
            {
                return chestMax;
            }
            set
            {
                chestMax = value;
            }
        }
        /// <summary>
        /// 房间体积
        /// </summary>
        private string v;
        public string V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
            }
        }
        /// <summary>
        /// 可用面积
        /// </summary>
        private string m;
        public string M
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
            }
        }
        /// <summary>
        /// 房间高度
        /// </summary>
        private string height;
        public string Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
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
        /// <summary>
        /// 备注
        /// </summary>
        private string remark;
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }
    }
}
