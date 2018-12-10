using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class DBTools
    {
        public static SqlConnection conn = null;
        /// <summary>
        /// 实例化数据库连接对象
        /// </summary>
        /// <returns>数据库连接对象SqlConnection</returns>
        public static SqlConnection DBConn()
        {
            
            string sqlconn = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString(); //使用需要在DAL层的引用configuration
            //string sqlconn = "Max Pool Size=256;Min Pool Size=10;Pooling=true;Data Source=DESKTOP-KUAHEDD;Initial Catalog=WareHouse;User ID=register;Password=123456";
            conn = new SqlConnection();
            conn.ConnectionString = sqlconn;
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public  static void DBClose()
        {
            conn.Close();
            conn.Dispose();
        }


        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        public static void DBClose(SqlConnection sc)
        {
            sc.Close();
            sc.Dispose();
        }

        /// <summary>
        /// 执行SQL语句读取数据库里面的信息
        /// </summary>
        /// <param name="sqltext">SQL语句</param>
        /// <param name="sqlpara">Parameter参数</param>
        /// <returns>SqlDataReader对象</returns>
        public  static SqlDataReader exereaderSQL(string sqltext, List<SqlParameter> sqlpara)
        {
            SqlConnection conn = DBConn();
            SqlCommand scd = new SqlCommand(sqltext, conn);
            scd.Parameters.Clear();
            foreach (SqlParameter para in sqlpara)
            {
                scd.Parameters.Add(para);
            }
            SqlDataReader sdr = scd.ExecuteReader();
            return sdr;
        }

        /// <summary>
        /// 执行SQL语句读取数据库里面返回信息的第一行第一列
        /// </summary>
        /// <param name="sqltext">SQL语句</param>
        /// <param name="sqlpara">Parameter参数</param>
        /// <returns>查询的第一行第一列的值object</returns>
        public static object exescalarSQL(string sqltext, List<SqlParameter> sqlpara)
        {
            SqlConnection conn = DBConn();
            SqlCommand scd = new SqlCommand(sqltext, conn);
            scd.Parameters.Clear();
            foreach (SqlParameter para in sqlpara)
            {
                scd.Parameters.Add(para);
            }
            object result = scd.ExecuteScalar();
            DBClose();
            return result;

        }

        /// <summary>
        /// 执行SQL语句，进行非查询操作
        /// </summary>
        /// <param name="sqltext">SQL语句</param>
        /// <param name="sqlpara">Parameter参数</param>
        /// <returns>受影响行数int</returns>
        public static int exenonquerySQL(string sqltext, List<SqlParameter> sqlpara)
        {
            SqlConnection conn = DBConn();
            SqlCommand scd = new SqlCommand(sqltext, conn);
            scd.Parameters.Clear();
            foreach (SqlParameter para in sqlpara)
            {
                scd.Parameters.Add(para);
            }
            int result = scd.ExecuteNonQuery();
            DBClose();
            return result;
        }

        /// <summary>
        /// 查找tablename表里面最大的ID号
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="idname">ID字段名</param>
        /// <returns>最大的ID名</returns>
        public static string searchID(string tablename,string idname)
        {
            SqlConnection conn = DBConn();
            string sql = string.Format("select top 1 {0} from {1} order by convert(int,{2}) DESC", idname, tablename, idname);
            SqlCommand scd = new SqlCommand(sql, conn);
            scd.Connection = conn;
            object value = scd.ExecuteScalar();
            string MAXId = null;
            if (value != null)
            {
                MAXId = value.ToString();
            }
            DBClose();
            return MAXId;
        }

        internal static string GetDbName()
        {
            throw new NotImplementedException();
        }

        internal static string GetDbPath()
        {
            throw new NotImplementedException();
        }

        internal static SqlConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
