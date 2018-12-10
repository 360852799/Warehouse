using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class IninDAO
    {
        /// <summary>
        /// 添加一条入库信息。
        /// </summary>
        /// <param name="iin">入库对象。</param>
        public bool addIn(Model.Inin iin)
        {
            string sqltext = "insert inin(num,inID,positionNum,goodsNum,inAmount,V,batchNum,date,userId,remark) values(@num,@inID,@positionNum,@goodsNum,@inAmount,@V,@batchNum,@date,@userId,@remark)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara0 = new SqlParameter("@num", iin.Num);
            SqlParameter sqlpara1 = new SqlParameter("@inID",iin.InID);
            SqlParameter sqlpara2 = new SqlParameter("@positionNum", iin.PositionNum);
            SqlParameter sqlpara3 = new SqlParameter("@goodsNum", iin.GoodsNum);
            SqlParameter sqlpara4 = new SqlParameter("@inAmount", iin.InAmount);
            SqlParameter sqlpara10 = new SqlParameter("@V", iin.V);
            SqlParameter sqlpara5 = new SqlParameter("@batchNum", iin.BatchNum);
            SqlParameter sqlpara6 = new SqlParameter("@date", iin.Date.ToString());
            SqlParameter sqlpara7 = new SqlParameter("@userId", iin.UserId);
            SqlParameter sqlpara8 = new SqlParameter("@remark", iin.Remark);
            para.Add(sqlpara0);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara10);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            para.Add(sqlpara8);
            int i = DBTools.exenonquerySQL(sqltext,para); ;
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除所有入库信息。
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteAllIn()
        {
            string sqltext ="delete from inin";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据入库ID，删除某条信息。
        /// </summary>
        /// <param name="iid">入库ID</param>
        public bool deleteInById(string iid)
        {
            string sqltext = "delete from inin where inID=@inID";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@inID", iid);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取所有的入库信息。
        /// </summary>
        public List<Model.Inin> getAllIn()
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select * from inin";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum =sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount =int.Parse(sdr["inAmount"].ToString());
                i.BatchNum = sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }

        /// <summary>
        /// 根据批次编号，获取入库信息。
        /// </summary>
        public List<Model.Inin> getInsByBatchNum(string batchnum)
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select * from inin where batchNum=@batchNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@batchNum", batchnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum =sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum= sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }

        /// <summary>
        /// 更新某个入库记录。
        /// </summary>
        /// <param name="iin">入库对象。</param>
        public bool updateIn(Model.Inin iin)
        {
            string sqltext = "update inin set positionNum=@positionNum,goodsNum=@goodsNum,inAmount=@inAmount,batchNum=@batchNum,date=@date,userId=@userId,remark=@remark where inID=@inID";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionNum", iin.PositionNum);
            SqlParameter sqlpara2 = new SqlParameter("@goodsNum", iin.GoodsNum);
            SqlParameter sqlpara3 = new SqlParameter("@inAmount", iin.InAmount);
            SqlParameter sqlpara4 = new SqlParameter("@batchNum", iin.BatchNum);
            SqlParameter sqlpara5 = new SqlParameter("@date", iin.Date.ToString());
            SqlParameter sqlpara6 = new SqlParameter("@userId", iin.UserId);
            SqlParameter sqlpara7 = new SqlParameter("@remark", iin.Remark);
            SqlParameter sqlpara8 = new SqlParameter("@inID", iin.InID);
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
        /// 根据时间的字符串类型查询一样的Inin类型集合
        /// </summary>
        /// <param name="time">字符串类型的日期字符串</param>
        /// <returns>Inin类型的集合</returns>
        public List<Model.Inin> getInsByDate(string time)
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select * from inin where date between '"+time+" 0:00:00' and '"+time+" 23:59:59'";
            List<SqlParameter> para = new List<SqlParameter>();
            //SqlParameter sqlpara1 = new SqlParameter("@date", time);
            
            //para.Add(sqlpara1);
            
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum =sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum= sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }

        /// <summary>
        /// 根据时间的区间的字符串类型查询一样的Inin类型集合
        /// </summary>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns>Inin类型的集合</returns>
        public List<Model.Inin> getInsBetweenDate(string starttime,string endtime)
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select * from inin where date between '@date1 0:00:00' and '@date2 23:59:59'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@date1", starttime);
            SqlParameter sqlpara2 = new SqlParameter("@date2", endtime);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum = sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum = sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }

        /// <summary>
        /// 根据传进来的库柜编号查找相应库柜上面的物品信息
        /// </summary>
        /// <param name="chestNum">库柜编号</param>
        /// <returns>Inin类型的集合</returns>
        public List<Model.Inin> getInsByChestNum(string chestNum)
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select inID,Inin.positionNum,Inin.goodsNum,inAmount,Inin.batchNum,[date],userId,Inin.remark from Inin,position where inin.positionnum=position.positionnum and position.positionNum='@positionNum'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionNum", chestNum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum = sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum = sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }

        /// <summary>
        /// 根据传进来的用户ID查找相应ID上面的信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>Inin类型的集合</returns>
        public List<Model.Inin> getInsByUserId(string id)
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select * from Inin where userId='@userId'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@userId", id);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum = sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum = sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }

        /// <summary>
        /// 根据传进来的物品编号查找相应的信息
        /// </summary>
        /// <param name="goodstypeNum">商品类别编号</param>
        /// <returns>Inin类型的集合</returns>
        public List<Model.Inin> getInsByGoodsType(string goodstypeNum)
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select inID,Inin.positionNum,Inin.goodsNum,inAmount,Inin.batchNum,[date],userId,Inin.remark from Inin,Goods where inin.goodsNum=Goods.goodsNum and Goods.goodsTypeNum='@goodsTypeNum'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsTypeNum", goodstypeNum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum = sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum = sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }


        /// <summary>
        /// 根据传进来的供应商编号查找相应的信息
        /// </summary>
        /// <param name="provideNum">供应商编号</param>
        /// <returns>Inin类型的集合</returns>
        public List<Model.Inin> getInsByProviderNum(string provideNum)
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select inID,Inin.positionNum,Inin.goodsNum,inAmount,Inin.batchNum,[date],userId,Inin.remark from Inin,batch where inin.batchNum=batch.batchNum and batch.proorrecNum='@provideNum'";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@provideNum", provideNum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum = sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum = sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }


        /// <summary>
        /// 根据id查找相应的信息
        /// </summary>
        /// <param name="id">入库id</param>
        /// <returns>Inin类对象</returns>
        public Model.Inin getInsById(string id)
        {
            Model.Inin i = null;
            string sqltext = "select * from Inin where inID=@inID";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@inID", id);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                i= new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum = sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum = sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId = sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
            }
            sdr.Close();
            DBTools.DBClose();
            return i;
        }


        /// <summary>
        /// 根据Where条件查找相应的信息
        /// </summary>
        /// <param name="sqlWhere">Where条件字符串集合编号</param>
        /// <returns>Inin类型的集合</returns>
        public List<Model.Inin> getInsByWhere(List<string> sqlWhere)
        {
            List<Model.Inin> inin = new List<Model.Inin>();
            string sqltext = "select * from Inin,Goods,Goodstype,Position,Provider,Sysuser,Staff,Batch,Chest where position.chestNum=chest.chestNum and Inin.goodsNum=Goods.goodsNum and Goods.goodsTypeNum=Goodstype.goodsTypeNum and Inin.positionNum=Position.positionNum and Inin.batchNum=Batch.batchNum and Batch.proorrecNum=Provider.providerNum and Inin.userId=Sysuser.userId and Sysuser.staffNum=Staff.staffNum";
            foreach (string sql in sqlWhere)
            {
                sqltext += sql;
            }
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, new List<SqlParameter>());
            while (sdr.Read())
            {
                Model.Inin i = new Model.Inin();
                i.InID = sdr["inID"].ToString();
                i.PositionNum = sdr["positionNum"].ToString();
                i.GoodsNum = sdr["goodsNum"].ToString();
                i.InAmount = int.Parse(sdr["inAmount"].ToString());
                i.BatchNum = sdr["batchNum"].ToString();
                i.Date = DateTime.Parse(sdr["date"].ToString());
                i.UserId =sdr["userId"].ToString();
                i.Remark = sdr["remark"].ToString();
                i.Position = new DAL.PositionDAO().getPositionByNum(i.PositionNum);
                i.Goods = new DAL.GoodsDAO().getGoodsByNum(i.GoodsNum);
                i.Batch = new DAL.BatchDao().getBatchByNum(i.BatchNum);
                i.SysUser = new DAL.SysUserDAO().getUserById(i.UserId);
                inin.Add(i);
            }
            sdr.Close();
            DBTools.DBClose();
            return inin;
        }


        /// <summary>
        /// 查询所有未完成入库信息
        /// </summary>
        /// <returns>Dataset类型</returns>
        public DataSet getInWhereFailToIn()
        {
            string sqltext = "select Inin.inID,Goods.goodsName,Goodstype.goodsTypeName,Position.positionNum,Inin.inAmount,Inin.date as indate,Staff.staffName from Inin,Position,Goods,Goodstype,Batch,Sysuser,Staff where Inin.positionNum=Position.positionNum and Inin.goodsNum=Goods.goodsNum and Goods.goodsTypeNum=Goodstype.goodsTypeNum and Inin.batchNum=Batch.batchNum and Inin.goodsNum=Goods.goodsNum and Inin.userId=Sysuser.userId and Sysuser.staffNum=Staff.staffNum and (Batch.condition='准备' or Batch.condition='进行中')";

            SqlDataAdapter sdr = new SqlDataAdapter(sqltext, DBTools.DBConn());
            DataSet ds = new DataSet();
            sdr.Fill(ds);
            DBTools.DBClose();
            return ds;
        }
    }
}
