using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PositionDAO
    {
        /// <summary>
        /// 获取所有的库位.
        /// </summary>
        /// <returns>库位对象泛型集合.</returns>
        public List<Model.Position> getAllPositions()
        {
            List<Model.Position> posi = new List<Model.Position>();
            string sqltext = "select * from position";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Position p = new Model.Position();
                p.PositionNum = sdr["positionNum"].ToString();
                p.RoomNum =sdr["roomNum"].ToString();
                p.ChestNum =sdr["chestNum"].ToString();
                p.PositiontypeId =sdr["positionTypeId"].ToString();
                p.GoodsTypes = sdr["goodsTypes"].ToString();
                p.Remark = sdr["remark"].ToString();
                p.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                p.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                p.M = sdr["M"].ToString();
                p.Height = sdr["Height"].ToString();
                p.Rest = sdr["Rest"].ToString();
                posi.Add(p);
            }
            sdr.Close();
            DBTools.DBClose();
            return posi;
        }

        /// <summary>
        /// 删除所有的库位
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteAllPositions()
        {
            string sqltext ="delete from position";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加一个库位.库位编号是主键.
        /// </summary>
        /// <param name="posi">库位对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addPosition(Model.Position posi)
        {
            string sqltext = "insert position(num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,Height,Rest,remark,createTime,updateTime) values(@num,@positionNum,@chestNum,@roomNum,@positionTypeId,@goodsTypes,@M,@Height,@Rest,@remark,@createTime,@updateTime)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", posi.Num);
            SqlParameter sqlpara1 = new SqlParameter("@positionNum", posi.PositionNum);
            SqlParameter sqlpara2 = new SqlParameter("@chestNum", posi.ChestNum);
            SqlParameter sqlpara3 = new SqlParameter("@roomNum", posi.RoomNum);
            SqlParameter sqlpara4 = new SqlParameter("@positionTypeId", posi.PositiontypeId);
            SqlParameter sqlpara5 = new SqlParameter("@goodsTypes", posi.GoodsTypes);
            SqlParameter sqlpara51 = new SqlParameter("@M", posi.M);
            SqlParameter sqlpara52 = new SqlParameter("@Height", posi.Height);
            SqlParameter sqlpara53 = new SqlParameter("@Rest", posi.Rest);
            SqlParameter sqlpara6 = new SqlParameter("@remark", posi.Remark);
            SqlParameter sqlpara7 = new SqlParameter("@createTime", posi.CreateTime.ToString());
            SqlParameter sqlpara8 = new SqlParameter("@updateTime", posi.UpdateTime.ToString());
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara51);
            para.Add(sqlpara52);
            para.Add(sqlpara53);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            para.Add(sqlpara8);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多个库位.
        /// </summary>
        /// <param name="posis">库位对象泛型集合.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addPositions(List<Model.Position> posis)
        {
            for (int j = 0; j < posis.Count; j++)
            {
                string sqltext = "insert position(positionNum,roomNum,chestNum,positionTypeId,goodsTypes,remark,createTime,updateTime,M,Height) values(@positionNum,@roomNum,@chestNum,@positionTypeId,@goodsTypes,@remark,@createTime,@updateTime,@M,@Height)";
                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara1 = new SqlParameter("@positionNum", posis[j].PositionNum);
                SqlParameter sqlpara2 = new SqlParameter("@roomNum", posis[j].RoomNum);
                SqlParameter sqlpara3 = new SqlParameter("@chestNum", posis[j].ChestNum);
                SqlParameter sqlpara4 = new SqlParameter("@positionTypeId", posis[j].PositiontypeId);
                SqlParameter sqlpara5 = new SqlParameter("@goodsTypes", posis[j].GoodsTypes);
                SqlParameter sqlpara6 = new SqlParameter("@remark", posis[j].Remark);
                SqlParameter sqlpara7 = new SqlParameter("@createTime", posis[j].CreateTime.ToString());
                SqlParameter sqlpara8 = new SqlParameter("@updateTime", posis[j].UpdateTime.ToString());
                SqlParameter sqlpara9 = new SqlParameter("@M", posis[j].M);
                SqlParameter sqlpara10 = new SqlParameter("@Height", posis[j].Height); 
                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara4);
                para.Add(sqlpara5);
                para.Add(sqlpara6);
                para.Add(sqlpara7);
                para.Add(sqlpara8);
                para.Add(sqlpara9);
                para.Add(sqlpara10);
                int i = DBTools.exenonquerySQL(sqltext,para);
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 更新某个库位.库位编号不可更改.
        /// </summary>
        /// <param name="posi">库位对象.</param>
        public bool updatePosition(Model.Position posi)
        {
            string sqltext = "update position set roomNum=@roomNum,chestNum=@chestNum,positionTypeId=@positionTypeId,goodsTypes=@goodsTypes,remark=@remark,createTime=@createTime,updateTime=@updateTime,M=@M,Height=@Height where positionNum=@positionNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionNum", posi.PositionNum);
            SqlParameter sqlpara2 = new SqlParameter("@roomNum", posi.RoomNum);
            SqlParameter sqlpara3 = new SqlParameter("@chestNum", posi.ChestNum);
            SqlParameter sqlpara4 = new SqlParameter("@positionTypeId", posi.PositiontypeId);
            SqlParameter sqlpara5 = new SqlParameter("@goodsTypes", posi.GoodsTypes);
            SqlParameter sqlpara6 = new SqlParameter("@remark", posi.Remark);
            SqlParameter sqlpara7 = new SqlParameter("@createTime", posi.CreateTime.ToString());
            SqlParameter sqlpara8 = new SqlParameter("@updateTime", posi.UpdateTime.ToString());
            SqlParameter sqlpara9 = new SqlParameter("@M", posi.M);
            SqlParameter sqlpara10 = new SqlParameter("@Height", posi.Height);
            SqlParameter sqlpara11 = new SqlParameter("@Rest", posi.Rest); 
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            para.Add(sqlpara8);
            para.Add(sqlpara1);
            para.Add(sqlpara9);
            para.Add(sqlpara10);
            para.Add(sqlpara11);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 更新某个库位.库位编号不可更改.
        /// </summary>
        /// <param name="posi">库位对象.</param>
        public bool update(Model.Position posi)
        {
            string sqltext = "update Position set rest=@rest where positionNum=@positionNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionNum", posi.PositionNum);
            SqlParameter sqlpara11 = new SqlParameter("@Rest", posi.Rest);
            para.Add(sqlpara1);
            para.Add(sqlpara11);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 通过编号找到库位.
        /// </summary>
        /// <param name="nnum">库位编号.</param>
        public Model.Position getPositionByNum(string nnum)
        {
            Model.Position posi = null;
            string sqltext ="select * from position where positionNum=@positionNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                posi = new Model.Position();
                posi.PositionNum = sdr["positionNum"].ToString();
                posi.RoomNum= sdr["roomNum"].ToString();
                posi.ChestNum = sdr["chestNum"].ToString();
                posi.PositiontypeId =sdr["positionTypeId"].ToString();
                posi.GoodsTypes = sdr["goodsTypes"].ToString();
                posi.Remark = sdr["remark"].ToString();
                posi.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                posi.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                posi.M = sdr["M"].ToString();
                posi.Height = sdr["Height"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return posi;
        }

        /// <summary>
        /// 通过编号,删除某个库位.
        /// </summary>
        public bool deletePositionByNum(string posinum)
        {
            string sqltext = "delete from position where positionNum=@positionNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionNum", posinum);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }
    }
}
