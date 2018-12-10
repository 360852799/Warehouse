using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GoodsTypeBLL
    {
        /// <summary>
        /// 添加一个物品种类
        /// </summary>
        /// <param name="ttype">物品种类对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addGoodsType(Model.GoodsType ttype)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有的物品种类。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteAllGoodsTypes()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据编号，删除某个物品种类。
        /// </summary>
        /// <param name="nnum">种类编号</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteGoodsTypeByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取素有的物品种类
        /// </summary>
        public List<Model.GoodsType> getAllGoodsTypes()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过种类编号，获取某个物品种类。
        /// </summary>
        /// <param name="nnum">种类编号</param>
        public Model.GoodsType getGoodsTypeByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过种类名称，获取物品种类。
        /// </summary>
        /// <param name="nname">种类名称</param>
        /// <returns>物品种类对象泛型集合</returns>
        public List<Model.GoodsType> getGoodsTypeByName(string nname)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个物品种类
        /// </summary>
        /// <param name="ttype">物品种类对象</param>
        public bool updateGoodsType(Model.GoodsType ttype)
        {
            throw new System.NotImplementedException();
        }
    }
}
