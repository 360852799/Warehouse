using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GoodsDAO
    {
        /// <summary>
        /// 获取所有物品。
        /// </summary>
        public List<Model.Goods> getAllGoods()
        {
            List<Model.Goods> good = new List<Model.Goods>();
            string sqltext = "select * from goods";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Goods g = new Model.Goods();
                g.GoodsNum = sdr["goodsNum"].ToString();
                g.GoodsTypeNum = sdr["goodsTypeNum"].ToString();
                g.GoodsName = sdr["goodsName"].ToString();
                g.GoodsStyle = sdr["goodsStyle"].ToString();
                g.GoodsColor = sdr["goodsColor"].ToString();
                g.GoodsSmell = sdr["goodsSmell"].ToString();
                g.GoodsShape = sdr["goodsShape"].ToString();
                g.GoodsPer = sdr["per"].ToString();
                g.GoodsCondition = sdr["condition"].ToString();
                g.GoodsCount = this.GoodsCountByNum(g.GoodsNum);
                g.GoodsType = new DAL.GoodsTypeDAO().getGoodsTypeByNum(g.GoodsTypeNum);
                good.Add(g);
            }
            sdr.Close();
            DBTools.DBClose();
            return good;
        }

        /// <summary>
        /// 根据物品编号，获取某种物品
        /// </summary>
        /// <param name="nnum">物品编号</param>
        public Model.Goods getGoodsByNum(string nnum)
        {
            Model.Goods good = null;
            string sqltext = "select * from goods where goodsNum=@goodsNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                good = new Model.Goods();
                good.GoodsNum = sdr["goodsNum"].ToString();
                good.GoodsTypeNum= sdr["goodsTypeNum"].ToString();
                good.GoodsName = sdr["goodsName"].ToString();
                good.GoodsStyle = sdr["goodsStyle"].ToString();
                good.GoodsColor = sdr["goodsColor"].ToString();
                good.GoodsSmell = sdr["goodsSmell"].ToString();
                good.GoodsShape = sdr["goodsShape"].ToString();
                good.GoodsPer = sdr["per"].ToString();
                good.GoodsCondition = sdr["condition"].ToString();
                good.GoodsCount = this.GoodsCountByNum(good.GoodsNum);
                good.GoodsType = new DAL.GoodsTypeDAO().getGoodsTypeByNum(good.GoodsTypeNum);
            }
            sdr.Close();
            DBTools.DBClose();
            return good;
        }

        /// <summary>
        /// 添加一种物品。
        /// </summary>
        /// <param name="goods">物品对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addGoods(Model.Goods goods)
        {
            string sqltext = "insert goods(num,goodsNum,goodsTypeNum,goodsName,goodsStyle,goodsColor,goodsSmell,goodsShape,per,condition,max) values(@num,@goodsNum,@goodsTypeNum,@goodsName,@goodsStyle,@goodsColor,@goodsSmell,@goodsShape,@per,@condition,@max)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", goods.Num);
            SqlParameter sqlpara1 = new SqlParameter("@goodsNum", goods.GoodsNum);
            SqlParameter sqlpara2 = new SqlParameter("@goodsTypeNum", goods.GoodsTypeNum);
            SqlParameter sqlpara3 = new SqlParameter("@goodsName", goods.GoodsName);
            SqlParameter sqlpara4 = new SqlParameter("@goodsStyle", goods.GoodsStyle);
            SqlParameter sqlpara5 = new SqlParameter("@goodsColor", goods.GoodsColor);
            SqlParameter sqlpara6 = new SqlParameter("@goodsSmell", goods.GoodsSmell);
            SqlParameter sqlpara7 = new SqlParameter("@goodsShape", goods.GoodsShape);
            SqlParameter sqlpara8 = new SqlParameter("@per", goods.GoodsPer);
            SqlParameter sqlpara9 = new SqlParameter("@condition", goods.GoodsCondition);
            SqlParameter sqlpara10 = new SqlParameter("@max", goods.Max);
            para.Add(sqlpara);
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
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多种物品。
        /// </summary>
        /// <param name="goodes">物品对象集合</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addGoodes(List<Model.Goods> goodes)
        {
            for (int j = 0; j < goodes.Count; j++)
            {
                string sqltext = "insert goods(goodsNum,goodsTypeNum,goodsName,goodsStyle,goodsColor,goodsSmell,goodsShape,per,condition) values(@goodsNum,@goodsTypeNum,@goodsName,@goodsStyle,@goodsColor,@goodsSmell,@goodsShape,@per,@condition)";
                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara1 = new SqlParameter("@goodsNum", goodes[j].GoodsNum);
                SqlParameter sqlpara2 = new SqlParameter("@goodsTypeNum", goodes[j].GoodsTypeNum);
                SqlParameter sqlpara3 = new SqlParameter("@goodsName", goodes[j].GoodsName);
                SqlParameter sqlpara4 = new SqlParameter("@goodsStyle", goodes[j].GoodsStyle);
                SqlParameter sqlpara5 = new SqlParameter("@goodsColor", goodes[j].GoodsColor);
                SqlParameter sqlpara6 = new SqlParameter("@goodsSmell", goodes[j].GoodsSmell);
                SqlParameter sqlpara7 = new SqlParameter("@goodsShape", goodes[j].GoodsShape);
                SqlParameter sqlpara8 = new SqlParameter("@per", goodes[j].GoodsPer);
                SqlParameter sqlpara9 = new SqlParameter("@condition", goodes[j].GoodsCondition);

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
        /// 删除所有物品。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteGoodes()
        {
            string sqltext = "delete from goods";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter>());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据编号，删除某种物品。
        /// </summary>
        /// <param name="nnum">物品编号</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteGoodsByNum(string nnum)
        {
            string sqltext = "delete from goods where goodsNum=@goodsNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsNum", nnum);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新某个物品信息。
        /// </summary>
        /// <param name="goods">物品对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateGoods(Model.Goods goods)
        {
            string sqltext = "update goods set goodsTypeNum=@goodsTypeNum,goodsName=@goodsName,goodsStyle=@goodsStyle,goodsColor=@goodsColor,goodsSmell=@goodsSmell,goodsShape=@goodsShape,per=@per,condition=@condition,max=@max where goodsNum=@goodsNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsTypeNum", goods.GoodsTypeNum);
            SqlParameter sqlpara2 = new SqlParameter("@goodsName", goods.GoodsName);
            SqlParameter sqlpara3 = new SqlParameter("@goodsStyle", goods.GoodsStyle);
            SqlParameter sqlpara4 = new SqlParameter("@goodsColor", goods.GoodsColor);
            SqlParameter sqlpara5 = new SqlParameter("@goodsSmell", goods.GoodsSmell);
            SqlParameter sqlpara6 = new SqlParameter("@goodsShape", goods.GoodsShape);
            SqlParameter sqlpara7 = new SqlParameter("@per", goods.GoodsPer);
            SqlParameter sqlpara8 = new SqlParameter("@condition", goods.GoodsCondition);
            SqlParameter sqlpara9 = new SqlParameter("@goodsNum", goods.GoodsNum);
            SqlParameter sqlpara10 = new SqlParameter("@max", goods.Max);
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
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取指定编号的物品的
        /// </summary>
        /// <param name="GoodsNum">物品编号</param>
        /// <returns></returns>
        public int GoodsCountByNum(string GoodsNum)
        {
            string sqltext = "select sum(amount) from Amount where goodsNum='"+GoodsNum+"'";
            object obj = DBTools.exescalarSQL(sqltext,new List<SqlParameter>());
            if (obj == null||obj.ToString()=="")
                return 0;
            else
                return int.Parse(obj.ToString());
        }
    }
}
