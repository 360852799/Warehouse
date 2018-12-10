using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ProviderBLL
    {
        /// <summary>
        /// 添加一个供货商.
        /// </summary>
        /// <param name="pro">供货商对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addProvider(Model.Provider pro)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多个供货商.
        /// </summary>
        /// <param name="pros">供货商对象泛型集合.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addProviders(List<Model.Provider> pros)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过名称,删除某个供货商.
        /// </summary>
        /// <param name="nname">供货商名称.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteProviderByName(string nname)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获得所有的供货商对象的泛型集合.
        /// </summary>
        public List<Model.Provider> getAllProviders()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过名称,获得某个供货商.
        /// </summary>
        /// <param name="nname">供货商名称</param>
        public Model.Provider getProviderByName(string nname)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 是否已有同名的供货商对象.
        /// </summary>
        /// <param name="nname">供货商名称。</param>
        /// <returns>有,则返回true;没有，则返回false。</returns>
        public bool hasProviderOfName(string nname)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个供货商信息。
        /// </summary>
        /// <param name="pro">供货商对象.</param>
        public bool updateProvider(Model.Provider pro)
        {
            throw new System.NotImplementedException();
        }
    }
}
