using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Warehouse.Tools
{
    public class GeneralTools
    {

        /// <summary>
        /// 获取当前的日期字符串
        /// </summary>
        /// <returns>今日日期的字符串</returns>
        public static string getDateNow()
        {
            string date=DateTime.Now.Year.ToString();
            int mouth = DateTime.Now.Month;
            if (mouth < 10)
                date += "0" + mouth.ToString();
            else
                date += mouth.ToString();
            int day = DateTime.Now.Day;
            if (day < 10)
                date += "0" + day.ToString();
            else
                date += day.ToString();
            return date;
            
        }


        /// <summary>
        /// 查询最大的编号
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="colname"></param>
        /// <returns>如果有，返回最大的编号的后两位，如果无，返回null</returns>
        public static string getMAXnum(string tablename, string colname)
        {
            string MAXnum = null;
            string date = getDateNow();
            SqlConnection sc = DAL.DBTools.DBConn();
            SqlCommand scd = new SqlCommand();
            scd.Connection = sc;
            scd.CommandText = string.Format("select top 1 {0} from {1} where {2} like '11" + date + "%' order by {3} desc", colname, tablename, colname, colname);
            object num = scd.ExecuteScalar();
            if (num == null)
            {
                return "00";
            }
            else
            {
                MAXnum = num.ToString().Substring(10, 2);
            }
            DAL.DBTools.DBClose(sc);
            return MAXnum;
        }
    }
}