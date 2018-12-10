using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GoodsBLL
    {
        /// <summary>
        /// 添加一种物品。
        /// </summary>
        /// <param name="goods">物品对象</param>
        public bool addGoods(Model.Goods goods)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多种物品。
        /// </summary>
        /// <param name="goodes">物品对象集合</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addGoodes(List<Model.Goods> goodes)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有物品。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteGoodes()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据编号，删除某种物品
        /// </summary>
        /// <param name="nnum">物品编号</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteGoodsByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有物品。
        /// </summary>
        public List<Model.Goods> getAllGoods()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据物品编号，获取物品。
        /// </summary>
        /// <param name="nnum">物品编号</param>
        /// <returns>物品对象</returns>
        public Model.Goods getGoodsByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某种物品信息。
        /// </summary>
        /// <param name="goods">物品对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateGoods(Model.Goods goods)
        {
            throw new System.NotImplementedException();
        }
    }
}
