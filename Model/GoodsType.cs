using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GoodsType
    {
        /// <summary>
        /// 序号
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
        /// 物品类别编号
        /// </summary>
        private string goodsTypeNum;
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
        /// 物品类别名称
        /// </summary>
        private string goodsTypeName;
        public string GoodsTypeName
        {
            get
            {
                return goodsTypeName;
            }
            set
            {
                goodsTypeName = value;
            }
        }

        /// <summary>
        /// 父类别编号
        /// </summary>
        private string parentTypeNum;
        public string ParentTypeNum
        {
            get
            {
                return parentTypeNum;
            }
            set
            {
                parentTypeNum = value;
            }
        }

        /// <summary>
        /// 物品状态
        /// </summary>
        private string goodsTypeCondition;
        public string GoodsTypeCondition
        {
            get
            {
                return goodsTypeCondition;
            }
            set
            {
                goodsTypeCondition = value;
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
        /// 创建物品的时间
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
        /// 更新物品的时间
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
