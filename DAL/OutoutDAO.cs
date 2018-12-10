using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OutoutDAO
    {
        /// <summary>
        /// 获取所有的出库信息。
        /// </summary>
        /// <returns>Outout类型的集合</returns>
        public List<Model.Outout> getAllOut()
        {
            List<Model.Outout> outout = new List<Model.Outout>();
            string sqltext = "select * from outout";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum =sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                outout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return outout;
        }

        /// <summary>
        /// 添加一条出库信息
        /// </summary>
        /// <param name="oout">出库对象。</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addOut(Model.Outout oout)
        {
            string sqltext = "insert outout(num,outID,positionNum,goodsNum,outAmount,batchNum,date,userId,remark) values(@num,@outID,@positionNum,@goodsNum,@outAmount,@batchNum,@date,@userId,@remark)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", oout.Num);
            SqlParameter sqlpara1 = new SqlParameter("@outID", oout.OuID);
            SqlParameter sqlpara2 = new SqlParameter("@positionNum", oout.PositionNum);
            SqlParameter sqlpara3 = new SqlParameter("@goodsNum", oout.GoodsNum);
            SqlParameter sqlpara4 = new SqlParameter("@outAmount", oout.OutAmount);
            SqlParameter sqlpara5 = new SqlParameter("@batchNum", oout.BatchNum);
            SqlParameter sqlpara6 = new SqlParameter("@date", oout.Date.ToString());
            SqlParameter sqlpara7 = new SqlParameter("@userId", oout.UserId);
            SqlParameter sqlpara8 = new SqlParameter("@remark", oout.Remark);
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
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
        /// 删除所有出库信息。
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteAllOut()
        {
            string sqltext = "delete from outout";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 通过出库ID，删除某条信息。
        /// </summary>
        /// <param name="outid">出库id</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteOutById(string outid)
        {
            string sqltext = "delete from outout where outID=@outID";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@outID", outid);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新一条出库信息。
        /// </summary>
        /// <param name="oout">出库对象。</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool updateOut(Model.Outout oout)
        {
            string sqltext = "update outout set positionNum=@positionNum,goodsNum=@goodsNum,outAmount=@outAmount,batchNum=@batchNum,date=@date,userId=@userId,remark=@remark where outID=@outID";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@outID", oout.OuID);
            SqlParameter sqlpara2 = new SqlParameter("@positionNum", oout.PositionNum);
            SqlParameter sqlpara3 = new SqlParameter("@goodsNum", oout.GoodsNum);
            SqlParameter sqlpara4 = new SqlParameter("@outAmount", oout.OutAmount);
            SqlParameter sqlpara5 = new SqlParameter("@batchNum", oout.BatchNum);
            SqlParameter sqlpara6 = new SqlParameter("@date", oout.Date.ToString());
            SqlParameter sqlpara7 = new SqlParameter("@userId", oout.UserId);
            SqlParameter sqlpara8 = new SqlParameter("@remark", oout.Remark);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            para.Add(sqlpara8);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 通过批次编号，查找出库对象信息。
        /// </summary>
        /// <param name="batnum">批次编号。</param>
        /// <returns>Outout类型的集合</returns>
        public List<Model.Outout> getOutsByBatchNum(string batnum)
        {
            List<Model.Outout> oout = new List<Model.Outout>();
            string sqltext = "select * from outout where batchNum=@batchNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@batchNum", batnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId=sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                oout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return oout;
        }


        /// <summary>
        /// 根据时间的字符串类型查询出库对象信息
        /// </summary>
        /// <param name="time">返回字符串类型的日期字符串</param>
        /// <returns>Outout类型的集合</returns>
        public List<Model.Outout> getOutsByDate(string time)
        {
            List<Model.Outout> outout = new List<Model.Outout>();
            string sqltext = "select * from outout where date between '" + time + " 0:00:00' and '" + time + " 23:59:59'";
            List<SqlParameter> para = new List<SqlParameter>();
            //SqlParameter sqlpara1 = new SqlParameter("@date", time);
            
            //para.Add(sqlpara1);
            
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                outout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return outout;
        }

        /// <summary>
        /// 根据时间的区间的字符串类型查询一样的Inin类型集合
        /// </summary>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns>Outout类型的集合</returns>
        public List<Model.Outout> getOutsBetweenDate(string starttime, string endtime)
        {
            List<Model.Outout> outout = new List<Model.Outout>();
            string sqltext = "select * from outout where date between '@date1 0:00:00' and '@date2 23:59:59'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@date1", starttime);
            SqlParameter sqlpara2 = new SqlParameter("@date2", endtime);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                outout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return outout;
        }

        /// <summary>
        /// 根据传进来的库柜编号查找相应库柜上面的物品信息
        /// </summary>
        /// <param name="chestNum">库柜编号</param>
        /// <returns>Outout类型的集合</returns>
        public List<Model.Outout> getOutsByChestNum(string chestNum)
        {
            List<Model.Outout> outout = new List<Model.Outout>();
            string sqltext = "select outID,outout.positionNum,outout.goodsNum,inAmount,outout.batchNum,[date],userId,outout.remark from outout,position where outout.positionnum=position.positionnum and position.positionNum='@positionNum'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionNum", chestNum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                outout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return outout;
        }

        /// <summary>
        /// 根据传进来的用户ID查找相应ID上面的信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>Outout类型的集合</returns>
        public List<Model.Outout> getOutsByUserId(string id)
        {
            List<Model.Outout> outout = new List<Model.Outout>();
            string sqltext = "select * from outout where userId='@userId'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@userId", id);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                outout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return outout;
        }


        /// <summary>
        /// 根据id查找相应的信息
        /// </summary>
        /// <param name="id">入库id</param>
        /// <returns>Outout类对象</returns>
        public Model.Outout getOutsById(string id)
        {
            Model.Outout o = null;
            string sqltext = "select * from outout where outID=@ouID";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@ouID", id);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
            }
            sdr.Close();
            DBTools.DBClose();
            return o;
        }

        /// <summary>
        /// 根据传进来的物品编号查找相应的信息
        /// </summary>
        /// <param name="goodstypeNum">商品类别编号</param>
        /// <returns>Outout类型的集合</returns>
        public List<Model.Outout> getOutsByGoodsType(string goodstypeNum)
        {
            List<Model.Outout> outout = new List<Model.Outout>();
            string sqltext = "select outID,outout.positionNum,outout.goodsNum,outAmount,outout.batchNum,[date],userId,outout.remark from outout,Goods where outout.goodsNum=Goods.goodsNum and Goods.goodsTypeNum='@goodsTypeNum'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsTypeNum", goodstypeNum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                outout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return outout;
        }


        /// <summary>
        /// 根据传进来的供应商编号查找相应的信息
        /// </summary>
        /// <param name="provideNum">供应商编号</param>
        /// <returns>Outout类型的集合</returns>
        public List<Model.Outout> getoutsByProviderNum(string provideNum)
        {
            List<Model.Outout> outout = new List<Model.Outout>();
            string sqltext = "select outID,outout.positionNum,outout.goodsNum,outAmount,outout.batchNum,[date],userId,outout.remark from outout,batch where outout.batchNum=batch.batchNum and batch.proorrecNum='@provideNum'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@provideNum", provideNum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                outout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return outout;
        }

        /// <summary>
        /// 根据Where条件查找相应的信息
        /// </summary>
        /// <param name="sqlWhere">Where条件字符串集合编号</param>
        /// <returns>outout类型的集合</returns>
        public List<Model.Outout> getOutsByWhere(List<string> sqlWhere)
        {
            List<Model.Outout> outout = new List<Model.Outout>();
            string sqltext = "select * from Outout,Goods,Goodstype,Position,receiver,Sysuser,Staff,Batch,chest where Position.chestNum=chest.chestNum and Outout.goodsNum=Goods.goodsNum and Goods.goodsTypeNum=Goodstype.goodsTypeNum and Outout.positionNum=Position.positionNum and Outout.batchNum=Batch.batchNum and Batch.proorrecNum=Receiver.receiverNum and Outout.userId=Sysuser.userId  and Sysuser.staffNum=Staff.staffNum";
            foreach (string sql in sqlWhere)
            {
                sqltext += sql;
            }
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, new List<SqlParameter>());
            while (sdr.Read())
            {
                Model.Outout o = new Model.Outout();
                o.OuID = sdr["outID"].ToString();
                o.PositionNum = sdr["positionNum"].ToString();
                o.GoodsNum = sdr["goodsNum"].ToString();
                o.OutAmount = int.Parse(sdr["outAmount"].ToString());
                o.BatchNum = sdr["batchNum"].ToString();
                o.Date = DateTime.Parse(sdr["date"].ToString());
                o.UserId = sdr["userId"].ToString();
                o.Remark = sdr["remark"].ToString();
                o.Position = new DAL.PositionDAO().getPositionByNum(o.PositionNum);
                o.Goods = new DAL.GoodsDAO().getGoodsByNum(o.GoodsNum);
                o.Batch = new DAL.BatchDao().getBatchByNum(o.BatchNum);
                o.SysUser = new DAL.SysUserDAO().getUserById(o.UserId);
                outout.Add(o);
            }
            sdr.Close();
            DBTools.DBClose();
            return outout;
        }


        /// <summary>
        /// 查询所有未完成出库信息
        /// </summary>
        /// <returns>Dataset类型</returns>
        public DataSet getOutsWhereFailToOut()
        {
            string sqltext = "select Outout.outID,Goods.goodsName,Goodstype.goodsTypeName,Position.positionNum,Outout.outAmount,Inin.date as indate,Outout.date as outdate,Staff.staffName from Outout,Position,Goods,Goodstype,Batch,inin,Sysuser,Staff where Outout.positionNum=Position.positionNum and Outout.goodsNum=Goods.goodsNum and Goods.goodsTypeNum=Goodstype.goodsTypeNum and Outout.batchNum=Batch.batchNum and Inin.goodsNum=Goods.goodsNum and Outout.userId=Sysuser.userId and Sysuser.staffNum=Staff.staffNum and (Batch.condition='准备' or Batch.condition='进行中')";

            SqlDataAdapter sdr = new SqlDataAdapter(sqltext, DBTools.DBConn());
            DataSet ds = new DataSet();
            sdr.Fill(ds);
            DBTools.DBClose();
            return ds;
        }
    }
}
