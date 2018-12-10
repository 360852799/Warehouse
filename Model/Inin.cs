using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Inin
    {
        /// <summary>
        /// 序号
        /// </summary>
        private int num;
        public int Num
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
        /// 入库批次
        /// </summary>
        private Batch batch;
        public Batch Batch
        {
            get
            {
                return batch;
            }
            set
            {
                batch = value;
            }
        }
        /// <summary>
        /// 批次编号
        /// </summary>
        private string batchNum;
        public string BatchNum
        {
            get
            {
                return batchNum;
            }
            set
            {
                batchNum = value;
            }
        }
        /// <summary>
        /// 体积
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
        /// 入库量
        /// </summary>
        private double inAmount;
        public double InAmount
        {
            get
            {
                return inAmount;
            }
            set
            {
                inAmount = value;
            }
        }

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
        /// 入库ID
        /// </summary>
        private string inID;
        public string InID
        {
            get
            {
                return inID;
            }
            set
            {
                inID = value;
            }
        }

        /// <summary>
        /// 库位信息
        /// </summary>
        private Position position ;
        public Position Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
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
        /// 物品编号
        /// </summary>
        private string goodsNum;
        public string GoodsNum
        {
            get
            {
                return goodsNum;
            }
            set
            {
                goodsNum = value;
            }
        }
        /// <summary>
        /// 物品信息
        /// </summary>
        private Goods goods ;
        public Goods Goods
        {
            get
            {
                return goods;
            }
            set
            {
                goods = value;
            }
        }

        /// <summary>
        /// 入库日期
        /// </summary>
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
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
