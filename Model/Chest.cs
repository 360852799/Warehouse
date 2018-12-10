using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Chest
    {
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
        /// 库柜编号
        /// </summary>
        private string chestNum;
        public string ChestNum
        {
            get
            {
                return chestNum;
            }
            set
            {
                chestNum = value;
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
        /// 库柜名
        /// </summary>
        private string chestName;
        public string ChestName
        {
            get
            {
                return chestName;
            }
            set
            {
                chestName = value;
            }
        }

        /// <summary>
        /// 库位上限
        /// </summary>
        private int positionMax;
        public int PositionMax
        {
            get
            {
                return positionMax;
            }
            set
            {
                positionMax = value;
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
        /// 库柜高度
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
