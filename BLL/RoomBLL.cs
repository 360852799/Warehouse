using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class RoomBLL
    {
        /// <summary>
        /// 添加一个房间.
        /// </summary>
        /// <param name="rroom">房间对象</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addRoom(Model.Room rroom)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多个房间.
        /// </summary>
        /// <param name="rooms">房间对象的泛型集合.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addRooms(List<Model.Room> rooms)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据房间编号删除某个房间.
        /// </summary>
        /// <param name="nnum">房间编号</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteRoomByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有房间.
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteAllRooms()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获得所有的房间对象.
        /// </summary>
        /// <returns>所有房间对象的泛型集合.</returns>
        public List<Model.Room> getAllRooms()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据房间编号,获取某个房间对象.
        /// </summary>
        /// <param name="nnum">房间编号</param>
        /// <returns>该房间编号的房间类对象</returns>
        public Model.Room getRoomByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新房间对象信息.
        /// </summary>
        /// <param name="rroom">房间对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool updateRoom(Model.Room rroom)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据创建时间,获取房间对象集合.
        /// </summary>
        /// <param name="cretime">创建时间.</param>
        /// <returns>房间对象泛型集合.</returns>
        public List<Model.Room> getRoomByCreatTime(DateTime cretime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据库柜上限,获取相应房间对象.
        /// </summary>
        /// <param name="cm">库柜上限</param>
        /// <returns>房间对象泛型集合.</returns>
        public List<Model.Room> getRoomsByChestMax(int cm)
        {
            throw new System.NotImplementedException();
        }
    }
}
