using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SysUserDAO
    {
        /// <summary>
        /// 获取所有系统用户.
        /// </summary>
        /// <returns>用户对象的泛型列表.</returns>
        public List<Model.SysUser> getAllUsers()
        {
            List<Model.SysUser> sysuser = new List<Model.SysUser>();
            string sqltext = "select * from sysuser";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.SysUser s = new Model.SysUser();
                s.UserId = sdr["userId"].ToString();
                s.StaffNum = sdr["staffNum"].ToString();
                s.Staff = new DAL.StaffDAO().getStaffByNum(s.StaffNum);
                s.Password = sdr["password"].ToString();
                s.Job = sdr["job"].ToString();
                sysuser.Add(s);
            }
            sdr.Close();
            DBTools.DBClose();
            return sysuser;
        }

        /// <summary>
        /// 获取某个员工编号的用户对象.
        /// </summary>
        /// <param name="ss">用户编号</param>
        /// <returns>系统用户类对象</returns>
        public Model.SysUser getUserByNum(string ss)
        {
            Model.SysUser sysuser = null;
            string sqltext = "select * from sysuser where staffNum=@staffNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@staffNum", ss);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                sysuser = new Model.SysUser();
                sysuser.UserId = sdr["userId"].ToString();
                sysuser.StaffNum = sdr["staffNum"].ToString();
                sysuser.Staff = new DAL.StaffDAO().getStaffByNum(sysuser.StaffNum);
                sysuser.Password = sdr["password"].ToString();
                sysuser.Job = sdr["job"].ToString();                
            }
            sdr.Close();
            DBTools.DBClose();
            return sysuser;
        }

        /// <summary>
        /// 获取某个员工id的用户对象.
        /// </summary>
        /// <param name="ss">用户id</param>
        /// <returns>系统用户类对象</returns>
        public Model.SysUser getUserById(string sid)
        {
            Model.SysUser sysuser = null;
            string sqltext = "select * from sysuser where userId=@userId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@userId", sid);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                sysuser = new Model.SysUser();
                sysuser.UserId = sdr["userId"].ToString();
                sysuser.StaffNum = sdr["staffNum"].ToString();
                sysuser.Staff = new DAL.StaffDAO().getStaffByNum(sysuser.StaffNum);
                sysuser.Password = sdr["password"].ToString();
                sysuser.Job = sdr["job"].ToString();               
            }
            sdr.Close();
            DBTools.DBClose();
            return sysuser;
        }


        /// <summary>
        /// 添加一个系统用户。
        /// </summary>
        /// <param name="su">系统用户类对象</param>
        /// <returns>布尔值提示添加是否成功</returns>
        public bool addUser(Model.SysUser su)
        {
            string sqltext = "insert sysuser(userId,staffNum,password,job) values(@userId,@staffNum,@password,@job)";
            string maxid = DBTools.searchID("sysuser", "userId");
            int id = maxid != null ? int.Parse(maxid) : 0;

            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@userId", (id+1).ToString());
            SqlParameter sqlpara2 = new SqlParameter("@staffNum", su.StaffNum);
            SqlParameter sqlpara3 = new SqlParameter("@password", su.Password);
            SqlParameter sqlpara4 = new SqlParameter("@job", su.Job);

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
        /// 添加多个系统用户。
        /// </summary>
        /// <param name="sus">用户类对象列表</param>
        /// <returns>通过布尔值提示添加是否成功</returns>
        public bool addUsers(List<Model.SysUser> sus)
        {
            for (int j = 0; j < sus.Count; j++)
            {
                string sqltext = "insert sysuser(userId,staffNum,password,job) values(@userId,@staffNum,@password,@job)";
                string maxid = DBTools.searchID("sysuser", "userId");
                int id = maxid != null ? int.Parse(maxid) : 0;

                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara1 = new SqlParameter("@userId", (id + 1).ToString());
                SqlParameter sqlpara2 = new SqlParameter("@staffNum", sus[j].StaffNum);
                SqlParameter sqlpara3 = new SqlParameter("@password", sus[j].Password);
                SqlParameter sqlpara4 = new SqlParameter("@job", sus[j].Job);
               

                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara4);
                int i = DBTools.exenonquerySQL(sqltext, para);
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 删除所有的用户.
        /// </summary>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool deleteAllUsers()
        {
            string sqltext = "delete from sysuser";
            int i = DBTools.exenonquerySQL(sqltext, new List<SqlParameter>());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除某个特定员工编号的用户.
        /// </summary>
        /// <param name="su">员工编号</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool deleteUserByNum(string nnum)
        {
            string sqltext = "delete from sysuser where staffNum=@staffNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@staffNum", nnum);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 通过员工编号,更新用户信息.员工编号跟用户ID不能修改.
        /// </summary>
        /// <param name="su">要更新的用户对象.员工编号不可更改.</param>
        /// <returns>通过布尔值提示是否完成.</returns>  
        public bool updateUser(Model.SysUser su)
        {
            string sqltext = "update sysuser set password=@password,job=@job where userId=@userId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@userId", su.UserId);
            //SqlParameter sqlpara2 = new SqlParameter("@staffNum", su.StaffNum);
            SqlParameter sqlpara3 = new SqlParameter("@password", su.Password);
            SqlParameter sqlpara4 = new SqlParameter("@job", su.Job);
            
            //para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否已有某个员工编号的用户.
        /// </summary>
        /// <param name="nnum">员工编号</param>
        /// <returns>如果有,则返回True;如果没有,则返回False.</returns>
        public bool hasUserOfNum(string nnum)
        {
            Model.SysUser sysuser = new Model.SysUser();
            string sqltext = "select * from sysuser where staffNum=@staffNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@staffNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                sdr.Close();
                DBTools.DBClose();
                return true;
            }
            sdr.Close();
            return false;
        }
    }
}
