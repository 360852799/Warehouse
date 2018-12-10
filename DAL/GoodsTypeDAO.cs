using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GoodsTypeDAO
    {
        /// <summary>
        /// 获取所有的物品类型。
        /// </summary>
        /// <returns>GoodsType的list集合</returns>
        public List<Model.GoodsType> getAllGoodsTypes()
        {
            List<Model.GoodsType> goodtype = new List<Model.GoodsType>();
            string sqltext = "select * from goodstype";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.GoodsType dt = new Model.GoodsType();
                dt.GoodsTypeNum = sdr["goodsTypeNum"].ToString();
                dt.GoodsTypeName = sdr["goodsTypeName"].ToString();
                dt.ParentTypeNum = sdr["parentTypeNum"].ToString();
                dt.GoodsTypeCondition = sdr["goodsTypeCondition"].ToString();
                dt.Remark = sdr["remark"].ToString();
                dt.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                dt.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                goodtype.Add(dt);
            }
            sdr.Close();
            DBTools.DBClose();
            return goodtype;
        }

        /// <summary>
        /// 通过编号，获取某个物品种类。
        /// </summary>
        /// <param name="nnum">物品类别编号。</param>
        /// <returns>GoodsType对象</returns>
        public Model.GoodsType getGoodsTypeByNum(string nnum)
        {
            Model.GoodsType goodtype = null;
            string sqltext ="select * from goodstype where goodsTypeNum=@goodsTypeNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsTypeNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                goodtype = new Model.GoodsType();
                goodtype.GoodsTypeNum = sdr["goodsTypeNum"].ToString();
                goodtype.GoodsTypeName = sdr["goodsTypeName"].ToString();
                goodtype.ParentTypeNum = sdr["parentTypeNum"].ToString();
                goodtype.GoodsTypeCondition = sdr["goodsTypeCondition"].ToString();
                goodtype.Remark = sdr["remark"].ToString();
                goodtype.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                goodtype.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
            }
            sdr.Close();
            DBTools.DBClose();
            return goodtype;
        }

        /// <summary>
        /// 通过种类名称，获取某个名称的物品类别。
        /// </summary>
        /// <param name="nname">物品种类名称</param>
        /// <returns>GoodsType的list集合</returns>
        public List<Model.GoodsType> getGoodsTypesByName(string nname)
        {
            List<Model.GoodsType> goodtype = new List<Model.GoodsType>();
            string sqltext = "select * from goodstype where goodsTypeName=@goodsTypeName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsTypeNum", nname);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                Model.GoodsType gt = new Model.GoodsType();
                gt.GoodsTypeNum = sdr["goodsTypeNum"].ToString();
                gt.GoodsTypeName = sdr["goodsTypeName"].ToString();
                gt.ParentTypeNum = sdr["parentTypeNum"].ToString();
                gt.GoodsTypeCondition = sdr["goodsTypeCondition"].ToString();
                gt.Remark = sdr["remark"].ToString();
                gt.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                gt.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                goodtype.Add(gt);
            }
            sdr.Close();
            DBTools.DBClose();
            return goodtype;
        }

        /// <summary>
        /// 添加一个物品种类
        /// </summary>
        /// <param name="ttype">物品种类对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addGoodsType(Model.GoodsType ttype)
        {
            string sqltext = "insert goodstype(num,goodsTypeNum,goodsTypeName,parentTypeNum,goodsTypeCondition,remark,createTime,updateTime) values(@num,@goodsTypeNum,@goodsTypeName,@parentTypeNum,@goodsTypeCondition,@remark,@createTime,@updateTime)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", ttype.Num);
            SqlParameter sqlpara1 = new SqlParameter("@goodsTypeNum", ttype.GoodsTypeNum);
            SqlParameter sqlpara2 = new SqlParameter("@goodsTypeName", ttype.GoodsTypeName);
            SqlParameter sqlpara3 = new SqlParameter("@parentTypeNum", ttype.ParentTypeNum);
            SqlParameter sqlpara4 = new SqlParameter("@goodsTypeCondition", ttype.GoodsTypeCondition);
            SqlParameter sqlpara5 = new SqlParameter("@remark", ttype.Remark);
            SqlParameter sqlpara6 = new SqlParameter("@createTime", ttype.CreateTime.ToString());
            SqlParameter sqlpara7 = new SqlParameter("@updateTime", ttype.UpdateTime.ToString());
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除所有的物品种类
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteAllGoodsTypes()
        {
            string sqltext = "delete from goodstype";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 通过种类编号，删除物品种类。
        /// </summary>
        /// <param name="nnum">物品种类编号</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteGoodsTypeByNum(string nnum)
        {
            string sqltext = "delete from goodstype where goodsTypeNum=@goodsTypeNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsTypeNum", nnum);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新某个物品种类
        /// </summary>
        /// <param name="ttype">物品种类对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateGoodsType(Model.GoodsType ttype)
        {
            string sqltext = "update goodstype set goodsTypeName=@goodsTypeName,parentTypeNum=@parentTypeNum,goodsTypeCondition=@goodsTypeCondition,remark=@remark,createTime=@createTime,updateTime=@updateTime where goodsTypeNum=@goodsTypeNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsTypeNum", ttype.GoodsTypeNum);
            SqlParameter sqlpara2 = new SqlParameter("@goodsTypeName", ttype.GoodsTypeName);
            SqlParameter sqlpara3 = new SqlParameter("@parentTypeNum", ttype.ParentTypeNum);
            SqlParameter sqlpara4 = new SqlParameter("@goodsTypeCondition", ttype.GoodsTypeCondition);
            SqlParameter sqlpara5 = new SqlParameter("@remark", ttype.Remark);
            SqlParameter sqlpara6 = new SqlParameter("@createTime", ttype.CreateTime.ToString());
            SqlParameter sqlpara7 = new SqlParameter("@updateTime", ttype.UpdateTime.ToString());
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取全部的父级类型
        /// </summary>
        /// <returns>GoodsType的list集合</returns>
        public List<Model.GoodsType> getParentGoodsTypes()
        {
            List<Model.GoodsType> goodtype = new List<Model.GoodsType>();
            string sqltext = "select * from goodstype where parentTypeNum is null";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.GoodsType gt = new Model.GoodsType();
                gt.GoodsTypeNum = sdr["goodsTypeNum"].ToString();
                gt.GoodsTypeName = sdr["goodsTypeName"].ToString();
                gt.ParentTypeNum = sdr["parentTypeNum"].ToString();
                gt.GoodsTypeCondition = sdr["goodsTypeCondition"].ToString();
                gt.Remark = sdr["remark"].ToString();
                gt.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                gt.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                goodtype.Add(gt);
            }
            sdr.Close();
            DBTools.DBClose();
            return goodtype;
        }

        /// <summary>
        /// 通过父类的编号查找响应子类的GoodsType集合
        /// </summary>
        /// <param name="parentNum"></param>
        /// <returns>GoodsType的list集合</returns>
        public List<Model.GoodsType> getGoodsTypesByParentNum(string parentNum)
        {
            List<Model.GoodsType> goodtype = new List<Model.GoodsType>();
            string sqltext = "select * from goodstype where parentTypeNum=@parentTypeNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@parentTypeNum", parentNum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                Model.GoodsType gt = new Model.GoodsType();
                gt.GoodsTypeNum = sdr["goodsTypeNum"].ToString();
                gt.GoodsTypeName = sdr["goodsTypeName"].ToString();
                gt.ParentTypeNum = sdr["parentTypeNum"].ToString();
                gt.GoodsTypeCondition = sdr["goodsTypeCondition"].ToString();
                gt.Remark = sdr["remark"].ToString();
                gt.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                gt.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                goodtype.Add(gt);
            }
            sdr.Close();
            DBTools.DBClose();
            return goodtype;
        }
    }
}
