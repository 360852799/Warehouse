using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StaffDAO
    {
        /// <summary>
        /// 添加一个员工.
        /// </summary>
        /// <param name="sstaff">员工类对象</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool addStaff(Model.staff sstaff)
        {
            string sqltext = "insert staff(num,staffNum,staffName,departId,birthday,gender,hometown,idCard,phoneNumber,entryTime) values(@num,@staffNum,@staffName,@departId,@birthday,@gender,@hometown,@idCard,@phoneNumber,@entryTime)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", sstaff.Num);
            SqlParameter sqlpara1 = new SqlParameter("@staffNum", sstaff.StaffNum);
            SqlParameter sqlpara2 = new SqlParameter("@staffName", sstaff.StaffName);
            SqlParameter sqlpara3 = new SqlParameter("@departId", sstaff.DepartId);
            SqlParameter sqlpara4 = new SqlParameter("@birthday", sstaff.Birthday.ToString());
            SqlParameter sqlpara5 = new SqlParameter("@gender", sstaff.Gender);
            SqlParameter sqlpara6 = new SqlParameter("@hometown", sstaff.Hometown);
            SqlParameter sqlpara7 = new SqlParameter("@idCard", sstaff.IdCard);
            SqlParameter sqlpara8 = new SqlParameter("@phoneNumber", sstaff.PhoneNumber);
            SqlParameter sqlpara9 = new SqlParameter("@entryTime", sstaff.EntryTime.ToString());
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            para.Add(sqlpara8);
            para.Add(sqlpara9);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多个员工.
        /// </summary>
        /// <param name="staffs">员工类对象泛型集合</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool addStaffs(List<Model.staff> staffs)
        {
            for (int j = 0; j < staffs.Count; j++)
            {
                string sqltext = "insert staff(staffNum,staffName,departId,birthday,gender,hometown,idCard,phoneNumber,entryTime) values(@staffNum,@staffName,@departId,@birthday,@gender,@hometown,@idCard,@phoneNumber,@entryTime)";
                List<SqlParameter> para = new List<SqlParameter>();
                SqlParameter sqlpara1 = new SqlParameter("@staffNum", staffs[j].StaffNum);
                SqlParameter sqlpara2 = new SqlParameter("@staffName", staffs[j].StaffName);
                SqlParameter sqlpara3 = new SqlParameter("@departId", staffs[j].DepartId);
                SqlParameter sqlpara4 = new SqlParameter("@birthday", staffs[j].Birthday.ToString());
                SqlParameter sqlpara5 = new SqlParameter("@gender", staffs[j].Gender);
                SqlParameter sqlpara6 = new SqlParameter("@hometown", staffs[j].Hometown);
                SqlParameter sqlpara7 = new SqlParameter("@idCard", staffs[j].IdCard);
                SqlParameter sqlpara8 = new SqlParameter("@phoneNumber", staffs[j].PhoneNumber);
                SqlParameter sqlpara9 = new SqlParameter("@entryTime", staffs[j].EntryTime.ToString());

                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara4);
                para.Add(sqlpara5);
                para.Add(sqlpara6);
                para.Add(sqlpara7);
                para.Add(sqlpara8);
                para.Add(sqlpara9);
                int i = DBTools.exenonquerySQL(sqltext,para);
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 删除所有员工.
        /// </summary>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool deleteAllStaffs()
        {
            string sqltext = "delete from staff";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除某个员工编号的员工.
        /// </summary>
        /// <param name="nnum">员工编号.</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool deleteStaffByNum(string nnum)
        {
            string sqltext = "delete from staff where staffNum=@staffNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@staffNum", nnum);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获得所有的员工对象.
        /// </summary>
        /// <returns>员工对象泛型集合.</returns>
        public List<Model.staff> getStaffs()
        {
            List<Model.staff> staff = new List<Model.staff>();
            string sqltext = "select * from staff";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.staff s = new Model.staff();
                s.StaffNum = sdr["staffNum"].ToString();
                s.StaffName = sdr["staffName"].ToString();
                s.DepartId = sdr["DepartId"].ToString();
                s.Department = new DAL.DepartmentDAO().getDepartById(s.DepartId);
                s.Birthday = DateTime.Parse(sdr["birthday"].ToString());
                s.Gender = sdr["gender"].ToString();
                s.Hometown = sdr["hometown"].ToString();
                s.IdCard = sdr["idCard"].ToString();
                s.PhoneNumber = sdr["phoneNumber"].ToString();
                s.EntryTime = DateTime.Parse(sdr["entryTime"].ToString());
                staff.Add(s);
            }
            sdr.Close();
            DBTools.DBClose();
            return staff;
        }

        /// <summary>
        /// 获得具有某个员工编号的员工.
        /// </summary>
        /// <param name="nnum">员工编号.</param>
        /// <returns>符合条件的员工类对象泛型集合.</returns>
        public Model.staff getStaffByNum(string nnum)
        {
            Model.staff staff =null;
            string sqltext = "select * from staff where staffNum=@staffNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@staffNum", nnum);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                staff = new Model.staff();
                staff.StaffNum = sdr["staffNum"].ToString();
                staff.StaffName = sdr["staffName"].ToString();
                staff.DepartId = sdr["DepartId"].ToString();
                staff.Department = new DAL.DepartmentDAO().getDepartById(staff.DepartId);
                staff.Birthday = DateTime.Parse(sdr["birthday"].ToString());
                staff.Gender = sdr["gender"].ToString();
                staff.Hometown = sdr["hometown"].ToString();
                staff.IdCard = sdr["idCard"].ToString();
                staff.PhoneNumber = sdr["phoneNumber"].ToString();
                staff.EntryTime = DateTime.Parse(sdr["entryTime"].ToString());
            }
            sdr.Close();
            DBTools.DBClose();
            return staff;
        }

        /// <summary>
        /// 更新某个员工信息，员工编号不变。
        /// </summary>
        /// <param name="sstaff">员工类对象.</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool updateStaff(Model.staff sstaff)
        {
            string sqltext = "update staff set staffName=@staffName,departId=@departId,birthday=@birthday,gender=@gender,hometown=@hometown,idCard=@idCard,phoneNumber=@phoneNumber where staffNum=@staffNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@staffNum", sstaff.StaffNum);
            SqlParameter sqlpara2 = new SqlParameter("@staffName", sstaff.StaffName);
            SqlParameter sqlpara3 = new SqlParameter("@departId", sstaff.DepartId);
            SqlParameter sqlpara4 = new SqlParameter("@birthday", sstaff.Birthday.ToString());
            SqlParameter sqlpara5 = new SqlParameter("@gender", sstaff.Gender);
            SqlParameter sqlpara6 = new SqlParameter("@hometown", sstaff.Hometown);
            SqlParameter sqlpara7 = new SqlParameter("@idCard", sstaff.IdCard);
            SqlParameter sqlpara8 = new SqlParameter("@phoneNumber", sstaff.PhoneNumber);
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
        /// 是否已有相同编号的员工.
        /// </summary>
        /// <returns>如果有,则返回True;没有,则返回False.</returns>
        public bool hasStaffOfNum(string staffnum)
        {
            Model.staff staff = new Model.staff();
            string sqltext = "select * from staff where staffNum=@staffNum";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@staffNum", staffnum);
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
