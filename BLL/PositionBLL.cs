using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PositionBLL
    {
        /// <summary>
        /// 添加一个库位对象.
        /// </summary>
        /// <param name="posi">库位对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addPosition(Model.Position posi)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 多个库位对象.
        /// </summary>
        public List<Model.Position> addPositions()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有的库位.
        /// </summary>
        public bool deleteAllPositions()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据编号,删除某个库位.
        /// </summary>
        /// <param name="nnum">库位编号.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deletePositionByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获得所有的库位对象.
        /// </summary>
        public List<Model.Position> getAllPositions()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据编号,获取某个库位.
        /// </summary>
        public Model.Position getPositionByNum()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个库位.库位编号不变.
        /// </summary>
        /// <param name="posi">库位对象</param>
        public bool updatePosition(Model.Position posi)
        {
            throw new System.NotImplementedException();
        }
    }
}
