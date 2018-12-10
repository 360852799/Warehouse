using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProviderDAO
    {
        /// <summary>
        /// 添加一个供货商.
        /// </summary>
        /// <param name="pro">供货商对象</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addProvider(Model.Provider pro)
        {
            string sqltext = "insert provider(providerNum,providerName,staffName,contact,contactNumber,providerAddress,createTime,updateTime) values(@providerNum,@providerName,@staffName,@contact,@contactNumber,@providerAddress,@createTime,@updateTime)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@providerNum", pro.ProviderNum);
            SqlParameter sqlpara2 = new SqlParameter("@providerName", pro.ProviderName);
            SqlParameter sqlpara3 = new SqlParameter("@staffName", pro.Leader);
            SqlParameter sqlpara4 = new SqlParameter("@contact", pro.Contact);
            SqlParameter sqlpara5 = new SqlParameter("@contactNumber", pro.ContactNumber);
            SqlParameter sqlpara6 = new SqlParameter("@providerAddress", pro.ProviderAddress);
            SqlParameter sqlpara7 = new SqlParameter("@createTime", pro.CreateTime.ToString());
            SqlParameter sqlpara8 = new SqlParameter("@updateTime", pro.UpdateTime.ToString());

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
        /// 添加多个供货商.
        /// </summary>
        /// <param name="pros">供货商对象泛型集合.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addProviders(List<Model.Provider> pros)
        {
            for (int j = 0; j < pros.Count; j++)
            {
                string sqltext = "insert provider(providerNum,providerName,staffName,contact,contactNumber,providerAddress,createTime,updateTime) values(@providerNum,@providerName,@staffName,@contact,@contactNumber,@providerAddress,@createTime,@updateTime)";
                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara1 = new SqlParameter("@providerNum", pros[j].ProviderNum);
                SqlParameter sqlpara2 = new SqlParameter("@providerName", pros[j].ProviderName);
                SqlParameter sqlpara3 = new SqlParameter("@staffName", pros[j].Leader);
                SqlParameter sqlpara4 = new SqlParameter("@contact", pros[j].Contact);
                SqlParameter sqlpara5 = new SqlParameter("@contactNumber", pros[j].ContactNumber);
                SqlParameter sqlpara6 = new SqlParameter("@providerAddress", pros[j].ProviderAddress);
                SqlParameter sqlpara7 = new SqlParameter("@createTime", pros[j].CreateTime.ToString());
                SqlParameter sqlpara8 = new SqlParameter("@updateTime", pros[j].UpdateTime.ToString());

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
        /// 通过名称,删除某个供货商.
        /// </summary>
        /// <param name="nname">供货商名称</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteProviderByName(string nname)
        {
            string sqltext = "delete from provider where providerName=@providerName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@providerName", nname);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取所有的供货商对象.
        /// </summary>
        /// <returns>供货商对象的泛型集合.</returns>
        public List<Model.Provider> getAllProviders()
        {
            List<Model.Provider> pro = new List<Model.Provider>();
            string sqltext = "select * from provider";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Provider p = new Model.Provider();
                p.ProviderNum = sdr["providerNum"].ToString();
                p.ProviderName = sdr["providerName"].ToString();
                p.Leader = sdr["staffName"].ToString();
                p.Contact = sdr["contact"].ToString();
                p.ContactNumber = sdr["contactNumber"].ToString();
                p.ProviderAddress = sdr["providerAddress"].ToString();
                p.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                p.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
                pro.Add(p);
            }
            
            sdr.Close();
            DBTools.DBClose();
            return pro;
        }

        /// <summary>
        /// 通过名称,获取某个供货商.
        /// </summary>
        /// <param name="nname">供货商名称.</param>
        /// <returns>供货商对象.</returns>
        public Model.Provider getProviderByName(string nname)
        {
            Model.Provider pro = null;
            string sqltext = "select * from provider where providerName=@providerName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@providerName", nname);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                pro = new Model.Provider();
                pro.ProviderNum = sdr["providerNum"].ToString();
                pro.ProviderName = sdr["providerName"].ToString();
                pro.Leader = sdr["staffName"].ToString();
                pro.Contact = sdr["contact"].ToString();
                pro.ContactNumber = sdr["contactNumber"].ToString();
                pro.ProviderAddress = sdr["providerAddress"].ToString();
                pro.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                pro.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
            }
            sdr.Close();
            DBTools.DBClose();
            return pro;
        }


        /// <summary>
        /// 通过编号,获取某个供货商.
        /// </summary>
        /// <param name="nname">供货商编号.</param>
        /// <returns>供货商对象.</returns>
        public Model.Provider getProviderByNum(string nnum)
        {
            Model.Provider pro = null;
            string sqltext = "select * from provider where providerNum=@providerNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@providerNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                pro = new Model.Provider();
                pro.ProviderNum = sdr["providerNum"].ToString();
                pro.ProviderName = sdr["providerName"].ToString();
                pro.Leader = sdr["staffName"].ToString();
                pro.Contact = sdr["contact"].ToString();
                pro.ContactNumber = sdr["contactNumber"].ToString();
                pro.ProviderAddress = sdr["providerAddress"].ToString();
                pro.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                pro.UpdateTime = DateTime.Parse(sdr["updateTime"].ToString());
            }
            sdr.Close();
            DBTools.DBClose();
            return pro;
        }

        /// <summary>
        /// 判断是否有相同名称的供货商.
        /// </summary>
        /// <param name="nname">供货商名称</param>
        /// <returns>有,则返回true;没有,则返回false</returns>
        public bool hasProviderOfName(string nname)
        {
            Model.Provider pro = new Model.Provider();
            string sqltext = "select * from provider where providerName=@providerName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@providerName", nname);
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

        /// <summary>
        /// 更新某个供货商信息
        /// </summary>
        /// <param name="pro">要更新的供货商对象</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool updateProvider(Model.Provider pro)
        {
            string sqltext = "update provider set providerName=@providerName,staffName=@staffName,contact=@contact,contactNumber=@contactNumber,providerAddress=@providerAddress,updateTime=@updateTime where providerNum=@providerNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@providerNum", pro.ProviderNum);
            SqlParameter sqlpara2 = new SqlParameter("@providerName", pro.ProviderName);
            SqlParameter sqlpara3 = new SqlParameter("@staffName", pro.Leader);
            SqlParameter sqlpara4 = new SqlParameter("@contact", pro.Contact);
            SqlParameter sqlpara5 = new SqlParameter("@contactNumber", pro.ContactNumber);
            SqlParameter sqlpara6 = new SqlParameter("@providerAddress", pro.ProviderAddress);
            //SqlParameter sqlpara7 = new SqlParameter("@createTime", pro.CreateTime.ToString());
            SqlParameter sqlpara8 = new SqlParameter("@updateTime", pro.UpdateTime.ToString());

            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            //para.Add(sqlpara7);
            para.Add(sqlpara8);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }
    }
}
