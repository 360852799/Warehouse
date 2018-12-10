using System;
using System.Web;
using System.ComponentModel;

namespace Model
{
    public class Notice
    {
        /// <summary>
        /// 管理员
        /// </summary>
        private SysUser sysUser ;
        public SysUser SysUser
        {
            get
            {
                return sysUser;
            }
            set
            {
                sysUser = value;
            }
        }

        /// <summary>
        /// 公告ID
        /// </summary>
        private string noticeId;
        public  string NoticeId
        {
            get
            {
                return noticeId;
            }
            set
            {
                noticeId = value;
            }
        }

        /// <summary>
        /// 公告的主题
        /// </summary>
        private string subject;
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        /// <summary>
        /// 公告的标题
        /// </summary>
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// 公告的内容
        /// </summary>
        private string body;
        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        /// <summary>
        /// 创建公告的时间
        /// </summary>
        private DateTime createTime;
        public DateTime CreateTime
        {
            get
            {
                return createTime;
            }
            set
            {
                createTime = value;
            }
        }

        /// <summary>
        /// 更新公告的时间
        /// </summary>
        private DateTime updateTime;
        public DateTime UpdateTime
        {
            get
            {
                return updateTime;
            }
            set
            {
                updateTime = value;
            }
        }
    }
}
