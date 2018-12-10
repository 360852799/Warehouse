using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BatchBLL
    {
        /// <summary>
        /// 添加一个批次。
        /// </summary>
        /// <param name="bat">批次对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addBatch(Model.Batch bat)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多个批次。
        /// </summary>
        /// <param name="bates">批次对象集合</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addBatches(List<Model.Batch> bates)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有的批次。
        /// </summary>
        public bool deleteAllBatches()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据编号，删除某个批次。
        /// </summary>
        /// <param name="nnum">批次编号</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteBatchByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的批次对象。
        /// </summary>
        public List<Model.Batch> getAllBatches()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据编号，获得某个编号的批次。
        /// </summary>
        /// <param name="nnum">批次编号</param>
        /// <returns>批次对象</returns>
        public Model.Batch getBatchByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个批次，批次编号不变。
        /// </summary>
        /// <param name="bat">批次对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateBatch(Model.Batch bat)
        {
            throw new System.NotImplementedException();
        }
    }
}
