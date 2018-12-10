using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Position
    {
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
        /// 库位编号
        /// </summary>
        private string positionNum;
        public string PositionNum
        {
            get
            {
                return positionNum;
            }
            set
            {
                positionNum = value;
            }
        }
        /// <summary>
        /// 可用体积
        /// </summary>
        private string rest;
        public string Rest
        {
            get
            {
                return rest;
            }
            set
            {
                rest = value;
            }
        }
        /// <summary>
        /// 库柜
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
        /// 库位类型ID
        /// </summary>
        private string positiontypeId;
        public string PositiontypeId
        {
            get
            {
                return positiontypeId;
            }
            set
            {
                positiontypeId = value;
            }
        }

        /// <summary>
        /// 房间
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
        /// 高度
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
        /// 可存物品类别
        /// </summary>
        private string goodsTypes;
        public string GoodsTypes
        {
            get
            {
                return goodsTypes;
            }
            set
            {
                goodsTypes = value;
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
        /// <summary>
        /// 创建库位的时间
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
        /// 更新库位的时间
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
