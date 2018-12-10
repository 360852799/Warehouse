using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Goods
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
        /// 物品类别
        /// </summary>
        private string goodsTypeNum ;
        public string GoodsTypeNum
        {
            get
            {
                return goodsTypeNum;
            }
            set
            {
                goodsTypeNum = value;
            }
        }
        /// <summary>
        /// 最大存放
        /// </summary>
        private string max;
        public string Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
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
        /// 物品类型类对象
        /// </summary>
        private GoodsType goodsType;

        public GoodsType GoodsType
        {
            get { return goodsType; }
            set { goodsType = value; }
        }

        /// <summary>
        /// 物品名称
        /// </summary>
        private string goodsName;
        public string GoodsName
        {
            get
            {
                return goodsName;
            }
            set
            {
                goodsName = value;
            }
        }

        /// <summary>
        /// 物品规格
        /// </summary>
        private string goodsStyle;
        public string GoodsStyle
        {
            get
            {
                return goodsStyle;
            }
            set
            {
                goodsStyle = value;
            }
        }

        /// <summary>
        /// 物品颜色
        /// </summary>
        private string goodsColor;
        public string GoodsColor
        {
            get
            {
                return goodsColor;
            }
            set
            {
                goodsColor = value;
            }
        }

        /// <summary>
        /// 物品气味
        /// </summary>
        private string goodsSmell;
        public string GoodsSmell
        {
            get
            {
                return goodsSmell;
            }
            set
            {
                goodsSmell = value;
            }
        }

        /// <summary>
        /// 物品形状
        /// </summary>
        private string goodsShape;
        public string GoodsShape
        {
            get
            {
                return goodsShape;
            }
            set
            {
                goodsShape = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        private string goodsper;
        public string GoodsPer
        {
            get
            {
                return goodsper;
            }
            set
            {
                goodsper = value;
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private string goodscondition;
        public string GoodsCondition
        {
            get
            {
                return goodscondition;
            }
            set
            {
                goodscondition = value;
            }
        }
        /// <summary>
        /// 所在位置
        /// </summary>
        private string goodsLocation;
        public string GoodsLocation
        {
            get
            {
                return goodsLocation;
            }
            set
            {
                goodsLocation = value;
            }
        }

        /// <summary>
        /// 物品总数
        /// </summary>
        private int goodsCount;

        public int GoodsCount
        {
            get { return goodsCount; }
            set { goodsCount = value; }
        }
    }
}
