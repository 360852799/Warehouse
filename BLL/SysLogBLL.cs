using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SysLogBLL
    {
        /// <summary>
        /// 添加一条日志记录对象.
        /// </summary>
        /// <param name="templog">日志类对象</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool addLog(Model.SysLog templog)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多条日志记录.
        /// </summary>
        /// <param name="templogs">日志泛型类对象集合.</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool addLogs(List<Model.SysLog> templogs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有日志.
        /// </summary>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool deleteAllLogs()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有日志记录.
        /// </summary>
        /// <returns>日志对象泛型列表.</returns>
        public List<Model.SysLog> getAllLogs()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取某个用户ID操作的日志记录.
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns>日志类对象的泛型集合.</returns>
        public List<Model.SysLog> getLogsByUserId(string uid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取某个IP地址的日志记录.
        /// </summary>
        /// <param name="iip">ip地址</param>
        /// <returns>日志类对象的泛型集合.</returns>
        public List<Model.SysLog> getLogsByIpAddr(string iip)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取某个栏目的日志记录.
        /// </summary>
        /// <param name="col">栏目名称</param>
        /// <returns>日志类对象泛型集合</returns>
        public List<Model.SysLog> getlLogsByColumn(string col)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取某种操作类型的日志记录
        /// </summary>
        /// <param name="ttype">操作类型.如添加、删除、更新等。</param>
        /// <returns>日志类对象的泛型集合.</returns>
        public List<Model.SysLog> getLogsByType(string ttype)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取某个时间段的日志记录.
        /// </summary>
        /// <param name="starttime">开始时间点</param>
        /// <param name="endtime">结束时间点</param>
        /// <returns>日志类对象的泛型集合.</returns>
        public List<Model.SysLog> getLogsByTime(DateTime starttime, DateTime endtime)
        {
            throw new System.NotImplementedException();
        }
    }
}
