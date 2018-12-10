using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SysLogDAO
    {
        /// <summary>
        /// 获取所有的日志对象
        /// </summary>
        /// <returns>日志对象泛型集合</returns>
        public List<Model.SysLog> getAllLogs()
        {
            List<Model.SysLog> sys = new List<Model.SysLog>();
            string sqltext = "select * from syslog";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.SysLog s = new Model.SysLog();
                s.LogId = sdr["logId"].ToString();
                s.UserId =sdr["userId"].ToString();
                s.SysUser = new DAL.SysUserDAO().getUserById(s.UserId);
                s.IpAddress = sdr["ipAddress"].ToString();
                s.ActionTime = DateTime.Parse(sdr["actionTime"].ToString());
                s.Column = sdr["column"].ToString();
                s.ActionType = sdr["actionType"].ToString();
                sys.Add(s);
            }
            sdr.Close();
            DBTools.DBClose();
            return sys;
        }

        /// <summary>
        /// 根据用户ID查找对应的日志
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns>日志对象泛型集合</returns>
        public List<Model.SysLog> getLogsByUserId(string userid)
        {
            List<Model.SysLog> syss = new List<Model.SysLog>();
            string sqltext = "select * from syslog where userId=@userId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@userId", userid);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                Model.SysLog s= new Model.SysLog();
                s.LogId = sdr["logId"].ToString();
                s.UserId = sdr["userId"].ToString();
                s.SysUser = new DAL.SysUserDAO().getUserById(s.UserId);
                s.IpAddress = sdr["ipAddress"].ToString();
                s.ActionTime = DateTime.Parse(sdr["actionTime"].ToString());
                s.Column = sdr["column"].ToString();
                s.ActionType = sdr["actionType"].ToString();
                syss.Add(s);
            }
            sdr.Close();
            DBTools.DBClose();
            return syss;
        }

        /// <summary>
        /// 删除所有的日志记录
        /// </summary>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool deleteAllLogs()
        {
            string sqltext = string.Format("delete from syslog");
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加一条日志记录对象
        /// </summary>
        /// <param name="templog">系统日志类对象</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool addLog(Model.SysLog templog)
        {
            string sqltext = "insert syslog(logId,userId,ipAddress,actionTime,[column],actionType) values(@logId,@userId,@ipAddress,@actionTime,@column,@actionType)";
            List<SqlParameter> para = new List<SqlParameter>();
            string maxid = DBTools.searchID("syslog", "logid");
            int id = maxid != null ? int.Parse(maxid) : 0;
            SqlParameter sqlpara1 = new SqlParameter("@logId", (id+1).ToString());
            SqlParameter sqlpara2 = new SqlParameter("@userId", templog.UserId);
            SqlParameter sqlpara3 = new SqlParameter("@ipAddress", templog.IpAddress);
            SqlParameter sqlpara4 = new SqlParameter("@actionTime", templog.ActionTime.ToString());
            SqlParameter sqlpara5 = new SqlParameter("@column", templog.Column);
            SqlParameter sqlpara6 = new SqlParameter("@actionType", templog.ActionType);

            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);

            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多条日志对象
        /// </summary>
        /// <param name="templogs">日志对象泛型列表集合</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool addLogs(List<Model.SysLog> templogs)
        {
            for (int j = 0; j < templogs.Count; j++)
            {
                string sqltext = "insert syslog(logId,userId,ipAddress,actionTime,column,actionType) values(@logId,@userId,@ipAddress,@actionTime,@column,@actionType)";
                List<SqlParameter> para = new List<SqlParameter>();
                string maxid = DBTools.searchID("syslog", "logid");
                int id = maxid != null ? int.Parse(maxid) : 0;
                SqlParameter sqlpara1 = new SqlParameter("@logId", (id+1).ToString());
                SqlParameter sqlpara2 = new SqlParameter("@userId", templogs[j].UserId);
                SqlParameter sqlpara3 = new SqlParameter("@ipAddress", templogs[j].IpAddress);
                SqlParameter sqlpara4 = new SqlParameter("@actionTime", templogs[j].ActionTime.ToString());
                SqlParameter sqlpara5 = new SqlParameter("@column", templogs[j].Column);
                SqlParameter sqlpara6 = new SqlParameter("@actionType", templogs[j].ActionType);

                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara4);
                para.Add(sqlpara5);
                para.Add(sqlpara6);
                int i = DBTools.exenonquerySQL(sqltext,para);
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }
    }
}
