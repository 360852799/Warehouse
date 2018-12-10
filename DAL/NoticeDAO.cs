using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class NoticeDAO
    {
        /// <summary>
        /// 获取所有的公告对象。
        /// </summary>
        public List<Model.Notice> getAllNotices()
        {
            List<Model.Notice> notice = new List<Model.Notice>();
            string sqltext = "select * from notice";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.Notice n = new Model.Notice();
                n.NoticeId = sdr["noticeId"].ToString();
                n.Subject = sdr["subject"].ToString();
                n.Title = sdr["title"].ToString();
                n.Body = sdr["body"].ToString();
                n.SysUser = new DAL.SysUserDAO().getUserById(sdr["userId"].ToString());
                n.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                n.UpdateTime = DateTime.Parse(sdr["publishTime"].ToString());
                notice.Add(n);
            }
            sdr.Close();
            DBTools.DBClose();
            return notice;
        }

        /// <summary>
        /// 根据ID获取某条公告。
        /// </summary>
        /// <param name="iid">公告id</param>
        public Model.Notice getNoticeById(string iid)
        {
            Model.Notice notice = null;
            string sqltext = "select * from notice where noticeId=@noticeId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@noticeId", iid);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                notice = new Model.Notice();
                notice.NoticeId = sdr["noticeId"].ToString();
                notice.Subject = sdr["subject"].ToString();
                notice.Title = sdr["title"].ToString();
                notice.Body = sdr["body"].ToString();
                notice.SysUser = new DAL.SysUserDAO().getUserById(sdr["userId"].ToString());
                notice.CreateTime = DateTime.Parse(sdr["createTime"].ToString());
                notice.UpdateTime = DateTime.Parse(sdr["publishTime"].ToString());
            }
            sdr.Close();
            DBTools.DBClose();
            return notice;
        }

        /// <summary>
        /// 添加一条公告。
        /// </summary>
        public bool addNotice(Model.Notice notice)
        {
            string sqltext = "insert notice(noticeId,subject,title,body,userId,createTime,publishTime) values(@noticeId,@subject,@title,@body,@userId,@createTime,@publishTime)";
            string maxid = DBTools.searchID("notice", "noticeId");
            int id = maxid != null ? int.Parse(maxid) : 0;
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@noticeId", (id+1).ToString());
            SqlParameter sqlpara2 = new SqlParameter("@subject", notice.Subject);
            SqlParameter sqlpara3 = new SqlParameter("@title", notice.Title);
            SqlParameter sqlpara4 = new SqlParameter("@body", notice.Body);
            SqlParameter sqlpara5 = new SqlParameter("@userId", notice.SysUser.UserId);
            SqlParameter sqlpara6 = new SqlParameter("@createTime", notice.CreateTime.ToString());
            SqlParameter sqlpara7 = new SqlParameter("@publishTime", notice.UpdateTime.ToString());

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
        /// 删除所有的公告。
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteNotices()
        {
            string sqltext = "delete from notice";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据公告ID，删除某条公告。
        /// </summary>
        /// <param name="iid">公告ID</param>
        public bool deleteNoticeById(string iid)
        {
            string sqltext = "delete from notice where noticeId=@noticeId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@noticeId", iid);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新某条公告的内容。
        /// </summary>
        /// <param name="noti">公告对象</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool updateNotice(Model.Notice noti)
        {
            string sqltext = "update notice set subject=@subject,title=@title,body=@body,userId=@userId,createTime=@createTime,publishTime=@publishTime where noticeId=@noticeId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@noticeId", noti.NoticeId);
            SqlParameter sqlpara2 = new SqlParameter("@subject", noti.Subject);
            SqlParameter sqlpara3 = new SqlParameter("@title", noti.Title);
            SqlParameter sqlpara4 = new SqlParameter("@body", noti.Body);
            SqlParameter sqlpara5 = new SqlParameter("@userId", noti.SysUser.UserId);
            SqlParameter sqlpara6 = new SqlParameter("@createTime", noti.CreateTime.ToString());
            SqlParameter sqlpara7 = new SqlParameter("@publishTime", noti.UpdateTime.ToString());
            
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }
    }
}
