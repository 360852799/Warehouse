using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PositionType
    {
        /// <summary>
        /// 库位类型ID
        /// </summary>
        private string positionTypeId;
        public string PositionTypeId
        {
            get
            {
                return positionTypeId;
            }
            set
            {
                positionTypeId = value;
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
        /// 库位类型名称
        /// </summary>
        private string positionTypeName;
        public string PositionTypeName
        {
            get
            {
                return positionTypeName;
            }
            set
            {
                positionTypeName = value;
            }
        }

        /// <summary>
        /// 库位的长度
        /// </summary>
        private string length;
        public string Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        /// <summary>
        /// 库位的宽度
        /// </summary>
        private string width;
        public string Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        /// <summary>
        /// 库位的高度
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
