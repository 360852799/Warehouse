using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DataCopyBLL
    {
        /// <summary>
        /// 增加多个数据备份。
        /// </summary>
        /// <param name="ccopies">数据备份对象集合</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addCopies(List<Model.DataCopy> ccopies)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 增加一个数据备份。
        /// </summary>
        /// <param name="ccopy">数据备份对象。</param>
        public bool addCopy(Model.DataCopy ccopy)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有的备份。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteAllCopy()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据备份ID，删除某个备份。
        /// </summary>
        /// <param name="iid">备份ID</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteCopyById(string iid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的备份。
        /// </summary>
        public List<Model.DataCopy> getAllCopy()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据备份ID，获取某个备份对象。
        /// </summary>
        /// <param name="iid">备份ID</param>
        public Model.DataCopy getCopyById(string iid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个备份。
        /// </summary>
        /// <param name="ccopy">备份对象。</param>
        public bool updateCopy(Model.DataCopy ccopy)
        {
            throw new System.NotImplementedException();
        }
    }
}
