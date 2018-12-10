using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ChestBLL
    {
        /// <summary>
        /// 增加一个库柜
        /// </summary>
        /// <param name="cchest">库柜对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addChest(Model.Chest cchest)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 增加多个库柜。
        /// </summary>
        /// <param name="cchests">库柜对象集合</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addChests(List<Model.Chest> cchests)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据库柜编号，删除某个库柜。
        /// </summary>
        /// <param name="nnum">库柜编号</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteChestByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有的库柜。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteChests()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获得所有的库柜。
        /// </summary>
        public List<Model.Chest> getAllChests()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据编号，获得某个库柜。
        /// </summary>
        /// <param name="nnum">库柜编号</param>
        public Model.Chest getChestByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个库柜信息。
        /// </summary>
        /// <param name="cchest">库柜对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateChest(Model.Chest cchest)
        {
            throw new System.NotImplementedException();
        }
    }
}
