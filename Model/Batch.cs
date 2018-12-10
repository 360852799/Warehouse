using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Batch
    {
        private Model.Provider provider ;
        public Model.Provider Provider
        {
            get
            {
                return provider;
            }
            set
            {
                provider = value;
            }
        }
        private Model.Receiver receiver ;
        public Model.Receiver Receiver
        {
            get
            {
                return receiver;
            }
            set
            {
                receiver = value;
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
        /// 批次类型
        /// </summary>
        private string outorinType;
        public string OutorinType
        {
            get
            {
                return outorinType;
            }
            set
            {
                outorinType = value;
            }
        }

        /// <summary>
        /// 出库/入库编号
        /// </summary>
        private string proorrecNum;
        public string ProorrecNum
        {
            get
            {
                return proorrecNum;
            }
            set
            {
                proorrecNum = value;
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private string condition;
        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
               condition=value;
            }
        }
    }
}
