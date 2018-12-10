using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DataCopy
    {
        private SysUser sysUser;
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
        /// 备份ID
        /// </summary>
        private string copyId;
        public string CopyId
        {
            get
            {
                return copyId;
            }
            set
            {
                copyId = value;
            }
        }

        /// <summary>
        /// 数据包名
        /// </summary>
        private string dataName;
        public string DataName
        {
            get
            {
                return dataName;
            }
            set
            {
                dataName = value;
            }
        }

        /// <summary>
        /// 复制时间
        /// </summary>
        private DateTime copyTime;
        public DateTime CopyTime
        {
            get
            {
                return copyTime;
            }
            set
            {
                copyTime = value;
            }
        }

        /// <summary>
        /// 复制类型
        /// </summary>
        private string copyType;
        public string CopyType
        {
            get
            {
                return copyType;
            }
            set
            {
                copyType = value;
            }
        }

        /// <summary>
        /// 数据包大小
        /// </summary>
        private int copySize;
        public int CopySize
        {
            get
            {
                return copySize;
            }
            set
            {
                copySize = value;
            }
        }

        /// <summary>
        /// 备份位置
        /// </summary>
        private string copyLocation;
        public string CopyLocation
        {
            get
            {
                return copyLocation;
            }
            set
            {
                copyLocation = value;
            }
        }

        /// <summary>
        /// 备份状态
        /// </summary>
        private string copyState;

        public string CopyState
        {
            get { return copyState; }
            set { copyState = value; }
        }

        /// <summary>
        /// 数据包检测-------默认完整
        /// </summary>
        private string copyjiance;

        public string Copyjiance
        {
          get { return "数据包完整"; }
          set { copyjiance = "数据包完整"; }
        }
    }
}
