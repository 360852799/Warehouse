using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ReceiverDAO
    {
        /// <summary>
        /// 添加一个收货商.
        /// </summary>
        /// <param name="nname">收货商类对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addReceiver(Model.Receiver rec)
        {
            string sqltext = "insert receiver(receiverNum,receiverName,staffName,contact,contactNumber,receiverAddress,createTime,updateTime) values(@receiverNum,@receiverName,@staffName,@contact,@contactNumber,@receiverAddress,@createTime,@updateTime)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@receiverNum", rec.ReceiverNum);
            SqlParameter sqlpara2 = new SqlParameter("@receiverName", rec.ReceiverName);
            SqlParameter sqlpara3 = new SqlParameter("@staffName", rec.StaffName);
            SqlParameter sqlpara4 = new SqlParameter("@contact", rec.Contact);
            SqlParameter sqlpara5 = new SqlParameter("@contactNumber", rec.ContactNumber);
            SqlParameter sqlpara6 = new SqlParameter("@receiverAddress", rec.ReceiverAddress);
            SqlParameter sqlpara7 = new SqlParameter("@createTime", rec.CreateTime.ToString());
            SqlParameter sqlpara8 = new SqlParameter("@updateTime", rec.UpdateTime.ToString());

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
        /// 添加多个收货商.
        /// </summary>
        /// <param name="recs">收货商对象泛型集合.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addReceivers(List<Model.Receiver> recs)
        {
            for (int j = 0; j < recs.Count; j++)
            {
                string sqltext = "insert receiver(receiverNum,receiverName,staffName,contact,contactNumber,receiverAddress,createTime,updateTime) values(@receiverNum,@receiverName,@staffName,@contact,@contactNumber,@receiverAddress,@createTime,@updateTime)";
                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara1 = new SqlParameter("@receiverNum", recs[j].ReceiverNum);
                SqlParameter sqlpara2 = new SqlParameter("@receiverName", recs[j].ReceiverName);
                SqlParameter sqlpara3 = new SqlParameter("@staffName", recs[j].StaffName);
                SqlParameter sqlpara4 = new SqlParameter("@contact", recs[j].Contact);
                SqlParameter sqlpara5 = new SqlParameter("@contactNumber", recs[j].ContactNumber);
                SqlParameter sqlpara6 = new SqlParameter("@receiverAddress", recs[j].ReceiverAddress);
                SqlParameter sqlpara7 = new SqlParameter("@createTime", recs[j].CreateTime.ToString());
                SqlParameter sqlpara8 = new SqlParameter("@updateTime", recs[j].UpdateTime.ToString());

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
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 根据名称,删除一个收货商.
        /// </summary>
        /// <param name="nname">收货商名称</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteReceiverByName(string nname)
        {
            string sqltext = "delete from receiver where receiverName=@receiverName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@receiverName", nname);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 删除全部收货商.
        /// </summary>
        /// <param name="nname">收货商名称</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteAllReceivers(string nname)
        {
            string sqltext = "delete from receiver where 1=1";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@receiverName", nname);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取所有的收货商对象.
        /// </summary>
        /// <returns>所有收货商对象的泛型集合.</returns>
        public List<Model.Receiver> getAllReceivers()
        {
            List<Model.Receiver> rece = new List<Model.Receiver>();
            string sqltext = "select * from receiver";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Receiver r = new Model.Receiver();
                r.ReceiverNum = sdr["receiverNum"].ToString();
                r.ReceiverName = sdr["receiverName"].ToString();
                r.StaffName = sdr["staffName"].ToString();
                r.Contact = sdr["contact"].ToString();
                r.ContactNumber = sdr["contactNumber"].ToString();
                r.ReceiverAddress = sdr["receiverAddress"].ToString();
                r.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                r.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                rece.Add(r);
            }
            sdr.Close();
            DBTools.DBClose();
            return rece;
        }

        /// <summary>
        /// 根据名称,获取某个收货商.
        /// </summary>
        /// <returns>收货商对象</returns>
        public Model.Receiver getReceiverByName(string recename)
        {
            Model.Receiver rece = null;
            string sqltext = "select * from receiver where receiverName=@receiverName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@receiverName", recename);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                rece = new Model.Receiver();
                rece.ReceiverNum = sdr["receiverNum"].ToString();
                rece.ReceiverName = sdr["receiverName"].ToString();
                rece.StaffName=sdr["staffName"].ToString();
                rece.Contact = sdr["contact"].ToString();
                rece.ContactNumber = sdr["contactNumber"].ToString();
                rece.ReceiverAddress = sdr["receiverAddress"].ToString();
                rece.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                rece.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
            }
            sdr.Close();
            DBTools.DBClose();
            return rece;
        }


        /// <summary>
        /// 根据编号,获取某个收货商.
        /// </summary>
        /// <returns>收货商对象</returns>
        public Model.Receiver getReceiverByNum(string recenum)
        {
            Model.Receiver rece = null;
            string sqltext = "select * from receiver where receiverNum=@receiverNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@receiverNum", recenum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                rece = new Model.Receiver();
                rece.ReceiverNum = sdr["receiverNum"].ToString();
                rece.ReceiverName = sdr["receiverName"].ToString();
                rece.StaffName = sdr["staffName"].ToString();
                rece.Contact = sdr["contact"].ToString();
                rece.ContactNumber = sdr["contactNumber"].ToString();
                rece.ReceiverAddress = sdr["receiverAddress"].ToString();
                rece.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                rece.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
            }
            sdr.Close();
            DBTools.DBClose();
            return rece;
        }

        /// <summary>
        /// 更新某个收货商信息对象.
        /// </summary>
        /// <param name="rec">收货商对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool updateReceiver(Model.Receiver rec)
        {
            string sqltext = "update receiver set receiverName=@receiverName,staffName=@staffName,contact=@contact,contactNumber=@contactNumber,receiverAddress=@receiverAddress,createTime=@createTime,updateTime=@updateTime where receiverNum=@receiverNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@receiverNum", rec.ReceiverNum);
            SqlParameter sqlpara2 = new SqlParameter("@receiverName", rec.ReceiverName);
            SqlParameter sqlpara3 = new SqlParameter("@staffName", rec.StaffName);
            SqlParameter sqlpara4 = new SqlParameter("@contact", rec.Contact);
            SqlParameter sqlpara5 = new SqlParameter("@contactNumber", rec.ContactNumber);
            SqlParameter sqlpara6 = new SqlParameter("@receiverAddress", rec.ReceiverAddress);
            SqlParameter sqlpara7 = new SqlParameter("@createTime", rec.CreateTime.ToString());
            SqlParameter sqlpara8 = new SqlParameter("@updateTime", rec.UpdateTime.ToString());
            
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
        /// 是否有某个名称的收货商.
        /// </summary>
        /// <param name="nname">收货商名称</param>
        /// <returns>如果有,则返回True;如果没有,则返回False.</returns>
        public bool hasReceiverOfName(string nname)
        {
            Model.Receiver rece = new Model.Receiver();
            string sqltext = "select * from receiver where receiverName=@receiverName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@receiverName", nname);
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
