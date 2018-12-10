using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AmountDAO
    {
        /// <summary>
        /// 获取所有库存对象。
        /// </summary>
        public List<Model.Amount> getAllAmounts()
        {
            List<Model.Amount> amount = new List<Model.Amount>();
            string sqltext = "select * from amount";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, new List<SqlParameter>());
            while (sdr.Read())
            {
                Model.Amount a = new Model.Amount();
                a.PositionNum = sdr["positionNum"].ToString();
                a.GoodsNum= sdr["goodsNum"].ToString();
                a.Amounts = double.Parse(sdr["amount"].ToString());
                a.AmountPer = sdr["per"].ToString();
                amount.Add(a);
            }
            sdr.Close();
            DBTools.DBClose();
            return amount;
        }

        /// <summary>
        /// 获取满足指定条件的。
        /// </summary>
        public List<Model.Amount> getAmountsByWhere(List<string> Conditions)
        {
            List<Model.Amount> amount = new List<Model.Amount>();
            string sqltext = "select * from amount,position,goods,goodsType,chest where Amount.goodsNum=Goods.goodsNum and  Amount.positionNum=Position.positionNum and Goods.goodsTypeNum=Goodstype.goodsTypeNum and Position.chestNum=Chest.chestNum";
            foreach (string sql in Conditions)
            {
                sqltext += sql;
            }
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, new List<SqlParameter>());
            while (sdr.Read())
            {
                Model.Amount a = new Model.Amount();
                a.PositionNum = sdr["positionNum"].ToString();
                a.GoodsNum = sdr["goodsNum"].ToString();
                a.Amounts = int.Parse(sdr["amount"].ToString());
                a.AmountPer = sdr["per"].ToString();
                amount.Add(a);
            }
            sdr.Close();
            DBTools.DBClose();
            return amount;
        }

        /// <summary>
        /// 获取满足指定位置和物品编号条件的。
        /// </summary>
        public Model.Amount getAmountsByWherePoAndGo(List<string> Conditions)
        {
            Model.Amount a = null;
            string sqltext = "select * from amount where 1=1";
            foreach (string sql in Conditions)
            {
                sqltext += sql;
            }
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, new List<SqlParameter>());
            while (sdr.Read())
            {
                a = new Model.Amount();
                a.PositionNum = sdr["positionNum"].ToString();
                a.GoodsNum = sdr["goodsNum"].ToString();
                a.Amounts = int.Parse(sdr["amount"].ToString());
                a.AmountPer = sdr["per"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return a;
        }

        /// <summary>
        /// 添加一条库存记录。
        /// </summary>
        /// <param name="aamount">库存记录对象</param>
        public bool addAmount(Model.Amount aamount)
        {
            string sqltext = "insert amount(num,positionNum,goodsNum,amount,per,V,Vp) values(@num,@positionNum,@goodsNum,@amount,@per,@V,@Vp)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", aamount.Num);
            SqlParameter sqlpara1 = new SqlParameter("@positionNum",aamount.PositionNum);
            SqlParameter sqlpara2 = new SqlParameter("@goodsNum", aamount.GoodsNum);
            SqlParameter sqlpara3 = new SqlParameter("@amount", aamount.Amounts);
            SqlParameter sqlpara4 = new SqlParameter("@per", aamount.AmountPer);
            SqlParameter sqlpara5 = new SqlParameter("@V", aamount.V);
            SqlParameter sqlpara6 = new SqlParameter("@Vp", aamount.Vp);
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }



        /// <summary>
        /// 更新某个库存对象
        /// </summary>
        /// <param name="aamount">库存对象</param>
        public bool updateAmount(Model.Amount aamount)
        {
            string sqltext = "update amount set goodsNum=@goodsNum,amount=@amount,per=@per,v=@v where positionNum=@positionNum1 and goodsNum=@goodsNum1";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@goodsNum", aamount.GoodsNum);
            SqlParameter sqlpara2 = new SqlParameter("@amount", aamount.Amounts);
            SqlParameter sqlpara3 = new SqlParameter("@per", aamount.AmountPer);
            SqlParameter sqlpara = new SqlParameter("@v", aamount.V);
            SqlParameter sqlpara4 = new SqlParameter("@positionNum1", aamount.PositionNum);
            SqlParameter sqlpara6 = new SqlParameter("@goodsNum1", aamount.GoodsNum);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara);
            para.Add(sqlpara4);
            para.Add(sqlpara6);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 更新某个库存对象
        /// </summary>
        /// <param name="aamount">库存对象</param>
        public bool update(Model.Amount aamount)
        {
            string sqltext = "update amount set amount=@amount,V=@V where positionNum=@positionNum1 and goodsNum=@goodsNum1 and Vp=@Vp";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@V", aamount.V);
            SqlParameter sqlpara2 = new SqlParameter("@amount", aamount.Amounts);
            SqlParameter sqlpara4 = new SqlParameter("@positionNum1", aamount.PositionNum);
            SqlParameter sqlpara6 = new SqlParameter("@goodsNum1", aamount.GoodsNum);
            SqlParameter sqlpara7 = new SqlParameter("@Vp", aamount.Vp);
            para.Add(sqlpara2);
            para.Add(sqlpara1);
            para.Add(sqlpara4);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 删除所有库存。
        /// </summary>
        public bool deleteAmounts()
        {
            string sqltext = "delete from amount";
            int i = DBTools.exenonquerySQL(sqltext, new List<SqlParameter>());
            if (i > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 通过库存ID，删除某条信息。
        /// </summary>
        /// <param name="outid">出库id</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteOutById(string outid)
        {
            string sqltext = "delete from outout where outID=@outID";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@outID", outid);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }
    }
}
