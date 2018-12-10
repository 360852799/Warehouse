using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RoomDAO
    {
        /// <summary>
        /// 获得所有房间对象
        /// </summary>
        /// <returns>房间类对象的泛型集合.</returns>
        public List<Model.Room> getAllRooms()
        {
            List<Model.Room> room = new List<Model.Room>();
            string sqltext = "select * from room order by num";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Room r = new Model.Room();
                r.RoomNum = sdr["roomNum"].ToString();
                r.RoomName = sdr["roomName"].ToString();
                r.ChestMax = int.Parse(sdr["chestMax"].ToString());
                r.Remark = sdr["remark"].ToString();
                r.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                r.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                r.M = sdr["M"].ToString();
                r.Height = sdr["Height"].ToString();
                room.Add(r);
            }
            sdr.Close();
            DBTools.DBClose();
            return room;
        }

        /// <summary>
        /// 根据房间编号获得房间.
        /// </summary>
        /// <param name="nnum">房间编号</param>
        /// <returns>房间类对象</returns>
        public Model.Room getRoomByNum(string nnum)
        {
            Model.Room room = null;
            string sqltext = "select * from Room  where roomNum=@roomNum order by num";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@roomNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                room = new Model.Room();
                room.Num = sdr["num"].ToString();
                room.RoomNum = sdr["roomNum"].ToString();
                room.RoomName = sdr["roomName"].ToString();
                room.ChestMax = int.Parse(sdr["chestMax"].ToString());
                room.Remark = sdr["remark"].ToString();
                room.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                room.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                room.M = sdr["M"].ToString();
                room.Height = sdr["Height"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return room;
        }

        /// <summary>
        /// 添加一个房间.
        /// </summary>
        /// <param name="rroom">房间对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addRoom(Model.Room rroom)
        {
            string sqltext = "insert room(num,roomNum,roomName,M,Height,remark,createTime,updateTime) values(@num,@roomNum,@roomName,@M,@Height,@remark,@createTime,@updateTime)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", rroom.Num);
            SqlParameter sqlpara1 = new SqlParameter("@roomNum", rroom.RoomNum);
            SqlParameter sqlpara2 = new SqlParameter("@roomName", rroom.RoomName);
            SqlParameter sqlpara3 = new SqlParameter("@M", rroom.M);
            SqlParameter sqlpara33 = new SqlParameter("@Height", rroom.Height);
            SqlParameter sqlpara4 = new SqlParameter("@remark", rroom.Remark);
            SqlParameter sqlpara5 = new SqlParameter("@createTime", rroom.CreateTime.ToString());
            SqlParameter sqlpara6 = new SqlParameter("@updateTime", rroom.UpdateTime.ToString());
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara33);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);

            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多个房间.
        /// </summary>
        /// <param name="rooms">房间类对象的泛型集合.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addRooms(List<Model.Room> rooms)
        {
            for (int j = 0; j < rooms.Count; j++)
            {
                string sqltext = "insert room(num,roomNum,roomName,M,Height,remark,createTime,updateTime) values(@num,@roomNum,@roomName,@M,@Height,@remark,@createTime,@updateTime)";
                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@num", rooms[j].Num);
                SqlParameter sqlpara1 = new SqlParameter("@roomNum", rooms[j].RoomNum);
                SqlParameter sqlpara2 = new SqlParameter("@roomName", rooms[j].RoomName);
                SqlParameter sqlpara3 = new SqlParameter("@M", rooms[j].M);
                SqlParameter sqlpara33 = new SqlParameter("@Height", rooms[j].Height);
                SqlParameter sqlpara4 = new SqlParameter("@remark", rooms[j].Remark);
                SqlParameter sqlpara5 = new SqlParameter("@createTime", rooms[j].CreateTime.ToString());
                SqlParameter sqlpara6 = new SqlParameter("@updateTime", rooms[j].UpdateTime.ToString());
                para.Add(sqlpara);
                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara33);
                para.Add(sqlpara4);
                para.Add(sqlpara5);
                para.Add(sqlpara6);
                int i = DBTools.exenonquerySQL(sqltext,para);
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 删除所有房间.
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteAllRooms()
        {
            string sqltext = string.Format("delete from room");
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter>());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除某个房间编号的房间.
        /// </summary>
        /// <param name="nnum">房间编号</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteRoomByNum(string nnum)
        {
            string sqltext = "delete from room where roomNum=@roomNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@roomNum", nnum);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新某个房间对象的信息.房间编号不变.
        /// </summary>
        /// <param name="rroom">要更新的房间对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool updateRoom(Model.Room rroom)
        {
            string sqltext = "update room set roomName=@roomName,M=@M,Height=@Height,chestMax=@chestMax,remark=@remark,createTime=@createTime,updateTime=@updateTime where roomNum=@roomNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@roomNum", rroom.RoomNum);
            SqlParameter sqlpara2 = new SqlParameter("@roomName", rroom.RoomName);
            SqlParameter sqlpara22 = new SqlParameter("@M", rroom.M);
            SqlParameter sqlpara33 = new SqlParameter("@Height", rroom.Height);
            SqlParameter sqlpara3 = new SqlParameter("@chestMax", rroom.ChestMax);
            SqlParameter sqlpara4 = new SqlParameter("@remark", rroom.Remark);
            SqlParameter sqlpara5 = new SqlParameter("@createTime", rroom.CreateTime.ToString());
            SqlParameter sqlpara6 = new SqlParameter("@updateTime", rroom.UpdateTime.ToString());
          
            para.Add(sqlpara2);
            para.Add(sqlpara22);
            para.Add(sqlpara33);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否已有相同房间编号的房间对象.
        /// </summary>
        /// <param name="nnum">房间编号</param>
        /// <returns>有,则返回True;没有,则返回False.</returns>
        public bool hasRoomOfNum(string nnum)
        {
            Model.Room room = new Model.Room();
            string sqltext = "select * from room where roomNum=@roomNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@roomNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                sdr.Close();
                DBTools.DBClose();
                return true;
            }

            return false;
        }
    }
}
