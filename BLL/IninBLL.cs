using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class IninBLL
    {
        /// <summary>
        /// 添加一条入库记录。
        /// </summary>
        /// <param name="iin">入库对象。</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addIn(Model.Inin iin)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有入库记录。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteAllIn()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过入库ID，删除某条入库记录
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteInById()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的入库记录。
        /// </summary>
        public List<Model.Inin> getAllIn()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据批次编号，获取入库记录。
        /// </summary>
        /// <param name="batnum">批次编号。</param>
        public List<Model.Inin> getInsByBatchNum(string batnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个入库记录。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateIn()
        {
            throw new System.NotImplementedException();
        }
    }
}
