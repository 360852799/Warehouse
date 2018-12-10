using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ChestDAO
    {
        /// <summary>
        /// 增加一个库柜。
        /// </summary>
        /// <param name="cchest">库柜对象。</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addChest(Model.Chest cchest)
        {
            string sqltext = "insert chest(num,chestNum,chestName,M,Height,roomNum,remark,createTime,updateTime) values(@num,@chestNum,@chestName,@M,@Height,@roomNum,@remark,@createTime,@updateTime)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", cchest.Num);
            SqlParameter sqlpara1 = new SqlParameter("@chestNum", cchest.ChestNum);
            SqlParameter sqlpara2 = new SqlParameter("@chestName", cchest.ChestName);
            SqlParameter sqlpara4 = new SqlParameter("@roomNum", cchest.RoomNum);
            SqlParameter sqlpara5 = new SqlParameter("@remark", cchest.Remark);
            SqlParameter sqlpara6 = new SqlParameter("@createTime", cchest.CreateTime);
            SqlParameter sqlpara7 = new SqlParameter("@updateTime", cchest.UpdateTime);
            SqlParameter sqlpara8 = new SqlParameter("@M", cchest.M);
            SqlParameter sqlpara9 = new SqlParameter("@Height", cchest.Height);
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara8);
            para.Add(sqlpara9);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加多个库柜对象。
        /// </summary>
        /// <param name="cchests">库柜对象集合</param>
        public bool addChests(List<Model.Chest> cchests)
        {
            for (int j = 0; j < cchests.Count; j++)
            {
                string sqltext = "insert chest(num,chestNum,chestName,positionMax,roomNum,remark,createTime,updateTime,M,Height) values(@num,@chestNum,@chestName,@positionMax,@roomNum,@remark,@createTime,@updateTime,@M,@Height)";
                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara1 = new SqlParameter("@chestNum", cchests[j].ChestNum);
                SqlParameter sqlpara2 = new SqlParameter("@chestName", cchests[j].ChestName);
                SqlParameter sqlpara3 = new SqlParameter("@positionMax", cchests[j].PositionMax);
                SqlParameter sqlpara4 = new SqlParameter("@roomNum", cchests[j].RoomNum);
                SqlParameter sqlpara5 = new SqlParameter("@remark", cchests[j].Remark);
                SqlParameter sqlpara6 = new SqlParameter("@createTime", cchests[j].CreateTime);
                SqlParameter sqlpara7 = new SqlParameter("@updateTime", cchests[j].UpdateTime);
                SqlParameter sqlpara8 = new SqlParameter("@M", cchests[j].M);
                SqlParameter sqlpara9 = new SqlParameter("@Height", cchests[j].Height);
                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara4);
                para.Add(sqlpara5);
                para.Add(sqlpara6);
                para.Add(sqlpara7);
                para.Add(sqlpara8);
                para.Add(sqlpara9);
                int i = DBTools.exenonquerySQL(sqltext, para);
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 删除所有的库柜。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteChests()
        {
            string sqltext = "delete from chest";
            int i = DBTools.exenonquerySQL(sqltext, new List<SqlParameter>());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据库柜编号，删除某个库柜。
        /// </summary>
        /// <param name="nnum">库柜编号</param>
        public bool deleteChestByNum(string nnum)
        {
            string sqltext = "delete from chest where chestNum=@chestNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@chestNum", nnum);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新某个库柜信息。
        /// </summary>
        /// <param name="cchest">库柜对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateChest(Model.Chest cchest)
        {
            string sqltext = "update chest set chestName=@chestName,positionMax=@positionMax,roomNum=@roomNum,remark=@remark,createTime=@createTime,updateTime=@updateTime,M=@M,Height=@Height where chestNum=@chestNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@chestNum", cchest.ChestNum);
            SqlParameter sqlpara2 = new SqlParameter("@chestName", cchest.ChestName);
            SqlParameter sqlpara3 = new SqlParameter("@positionMax", cchest.PositionMax);
            SqlParameter sqlpara4 = new SqlParameter("@roomNum", cchest.RoomNum);
            SqlParameter sqlpara5 = new SqlParameter("@remark", cchest.Remark);
            SqlParameter sqlpara6 = new SqlParameter("@createTime", cchest.CreateTime);
            SqlParameter sqlpara7 = new SqlParameter("@updateTime", cchest.UpdateTime);
            SqlParameter sqlpara8 = new SqlParameter("@M", cchest.M);
            SqlParameter sqlpara9 = new SqlParameter("@Height", cchest.Height);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            para.Add(sqlpara8);
            para.Add(sqlpara9);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获得所有的库柜。
        /// </summary>
        public List<Model.Chest> getAllChests()
        {
            List<Model.Chest> chest = new List<Model.Chest>();
            string sqltext = "select * from chest";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, new List<SqlParameter>());
            while (sdr.Read())
            {
                Model.Chest c = new Model.Chest();
                c.ChestNum = sdr["chestNum"].ToString();
                c.ChestName = sdr["chestName"].ToString();
                c.PositionMax = int.Parse(sdr["positionMax"].ToString());
                c.RoomNum = sdr["roomNum"].ToString();
                c.Remark = sdr["remark"].ToString();
                c.CreateTime = Convert.ToDateTime(sdr["createTime"]);
                c.UpdateTime = Convert.ToDateTime(sdr["updateTime"]);
                c.M = sdr["M"].ToString();
                c.Height = sdr["Height"].ToString();
                chest.Add(c);
            }
            sdr.Close();
            DBTools.DBClose();
            return chest;
        }

        /// <summary>
        /// 根据库柜编号，获得某个库柜。
        /// </summary>
        /// <param name="nnum">库柜编号</param>
        public Model.Chest getChestByNum(string nnum)
        {
            Model.Chest chest = null;
            string sqltext = "select * from chest where chestNum=@chestNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@chestNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                chest = new Model.Chest();
                chest.ChestNum = sdr["chestNum"].ToString();
                chest.ChestName = sdr["chestName"].ToString();
                chest.PositionMax = int.Parse(sdr["positionMax"].ToString());
                chest.RoomNum = sdr["roomNum"].ToString();
                chest.Remark = sdr["remark"].ToString();
                chest.CreateTime = Convert.ToDateTime(sdr["createTime"]);
                chest.UpdateTime = Convert.ToDateTime(sdr["updateTime"]);
                chest.M = sdr["M"].ToString();
                chest.Height = sdr["Height"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return chest;
        }
    }
}
