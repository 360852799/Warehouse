using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class OutoutBLL
    {
        /// <summary>
        /// 添加一条出库信息
        /// </summary>
        /// <param name="oout">出库对象</param>
        public bool addOut(Model.Outout oout)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有的出库信息。
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteAllOut()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过出库ID删除一条出库记录。
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteOutById()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的出库记录。
        /// </summary>
        public List<Model.Outout> getAllOut()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过批次编号，获取出库信息。
        /// </summary>
        /// <param name="batnum">批次编号</param>
        public List<Model.Outout> getOutsByBatchNum(string batnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新一条出库记录。
        /// </summary>
        /// <param name="oout">出库对象。</param>
        public bool updateOut(Model.Outout oout)
        {
            throw new System.NotImplementedException();
        }
    }
}
