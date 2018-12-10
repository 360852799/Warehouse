using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class BatchDao
    {
        /// <summary>
        /// 添加一个批次。
        /// </summary>
        /// <param name="bat">批次对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addBatch(Model.Batch bat)
        {
            string sqltext ="insert batch(batchNum,outorinType,proorrecNum,condition) values(@batchNum,@outorinType,@proorrecNum,@condition)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@batchNum", bat.BatchNum);
            SqlParameter sqlpara2 = new SqlParameter("@outorinType", bat.OutorinType);
            SqlParameter sqlpara3 = new SqlParameter("@proorrecNum",bat.ProorrecNum);
            SqlParameter sqlpara4 = new SqlParameter("@condition",bat.Condition);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多个批次。
        /// </summary>
        /// <param name="bates">批次对象集合</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addBatches(List<Model.Batch> bates)
        {
            for (int j = 0; j < bates.Count; j++)
            {
                string sqltext ="insert batch(batchNum,outorinType,proorrecNum,condition) values(@batchNum,@outorinType,@proorrecNum,@condition)";
                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara1 = new SqlParameter("@batchNum", bates[j].BatchNum);
                SqlParameter sqlpara2 = new SqlParameter("@outorinType", bates[j].OutorinType);
                SqlParameter sqlpara3 = new SqlParameter("@proorrecNum", bates[j].ProorrecNum);
                SqlParameter sqlpara4 = new SqlParameter("@condition", bates[j].Condition);
                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara4);
                int i = DBTools.exenonquerySQL(sqltext,para); ;
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 删除所有批次。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteAllBatches()
        {
            string sqltext ="delete from batch";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ()); ;
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据编号，删除某个批次。
        /// </summary>
        /// <param name="nnum">批次编号</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteBatchByNum(string nnum)
        {
            string sqltext ="delete from batch where batchNum=@batchNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@batchNum",nnum);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新某个批次信息。
        /// </summary>
        /// <param name="bat">批次对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateBatch(Model.Batch bat)
        {
            string sqltext ="update batch set outorinType=@outorinType,proorrecNum=@proorrecNum,condition=@condition where batchNum=@batchNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@outorinType",bat.OutorinType);
            SqlParameter sqlpara2 = new SqlParameter("@proorrecNum", bat.ProorrecNum);
            SqlParameter sqlpara3 = new SqlParameter("@condition", bat.Condition);
            SqlParameter sqlpara4 = new SqlParameter("@batchNum", bat.BatchNum);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取所有的批次对象。
        /// </summary>
        public List<Model.Batch> getAllBatches()
        {
            List<Model.Batch> batch = new List<Model.Batch>();
            string sqltext = "select * from batch";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Batch b = new Model.Batch();
                b.BatchNum = sdr["batchNum"].ToString();
                b.OutorinType = sdr["outorinType"].ToString();
                b.ProorrecNum = sdr["proorrecNum"].ToString();
                if (b.OutorinType == "入库")
                {
                    b.Provider = new DAL.ProviderDAO().getProviderByNum(b.ProorrecNum);
                }
                else if (b.OutorinType == "出库")
                {
                    b.Receiver = new DAL.ReceiverDAO().getReceiverByNum(b.ProorrecNum);
                }
                b.Condition = sdr["condition"].ToString();

                batch.Add(b);
            }
            sdr.Close();
            DBTools.DBClose();
            return batch;
        }

        /// <summary>
        /// 根据编号，获取批次对象。
        /// </summary>
        /// <param name="nnum">批次编号</param>
        public Model.Batch getBatchByNum(string nnum)
        {
            Model.Batch batch = null;
            string sqltext = "select * from batch where batchNum=@batchNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@batchNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {        
                batch = new Model.Batch();        
                batch.BatchNum = sdr["batchNum"].ToString();
                batch.OutorinType = sdr["outorinType"].ToString();
                batch.ProorrecNum = sdr["proorrecNum"].ToString();
                batch.Condition = sdr["condition"].ToString();
                if (batch.OutorinType == "入库")
                {
                    batch.Provider = new DAL.ProviderDAO().getProviderByNum(batch.ProorrecNum);
                }
                else if (batch.OutorinType == "出库")
                {
                    batch.Receiver = new DAL.ReceiverDAO().getReceiverByNum(batch.ProorrecNum);
                }
            }
            sdr.Close();
            return batch;
        }
    }
}
