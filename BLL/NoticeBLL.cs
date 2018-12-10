using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class NoticeBLL
    {
        /// <summary>
        /// 添加一条公告。
        /// </summary>
        /// <param name="noti">公告对象。</param>
        public bool addNotice(Model.Notice noti)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过公告ID，删除一条公告。
        /// </summary>
        /// <param name="iid">公告Id</param>
        public bool deleteNoticeById(string iid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有公告。
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteNotices()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的公告对象。
        /// </summary>
        public List<Model.Notice> getAllNotices()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 通过公告ID，获取一条公告。
        /// </summary>
        /// <param name="iid">公告ID</param>
        public Model.Notice getNoticeById(string iid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新一条公告。
        /// </summary>
        /// <param name="noti">公告对象。</param>
        public bool updateNotice(Model.Notice noti)
        {
            throw new System.NotImplementedException();
        }
    }
}
