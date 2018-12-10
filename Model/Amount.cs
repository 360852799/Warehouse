using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Amount
    {
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
        //平均体积
        private string vp;
        public string Vp
        {
            get
            {
                return vp;
            }
            set
            {
                vp = value;
            }
        }
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
        private Model.Goods goods ;
        public Model.Goods Goods
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
        private Model.Position position ;
        public Model.Position Position
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
        /// 现有量
        /// </summary>
        private double amounts;
        public double Amounts
        {
            get
            {
                return amounts;
            }
            set
            {
                amounts = value;
            }  
        }

        /// <summary>
        /// 单位
        /// </summary>
        private string amountper;
        public string AmountPer
        {
            get
            {
                return amountper;
            }
            set
            {
                amountper = value;
            }
        }
    }
}
