using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Collections.Generic;

namespace Warehouse
{
    public class PositionControl
    {
        /// <summary>
        /// 根据房间编号获取库位对象.
        /// </summary>
        /// <param name="roomnum">房间编号</param>
        /// <returns>库位对象的泛型集合.</returns>
        public List<Model.Position> getPositionsByRoomNum(string roomnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据库柜编号,获取库位对象集合.
        /// </summary>
        /// <param name="chestnum">库柜编号.</param>
        /// <returns>库位对象泛型集合.</returns>
        public List<Model.Position > getPositionsByChestNum(string chestnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据库位类型，获取库位对象集合。
        /// </summary>
        /// <param name="typeid">库位类型id</param>
        public List<Model.Position> getPositionsByTypeId(string typeid)
        {
            throw new System.NotImplementedException();
        }
    }
}
