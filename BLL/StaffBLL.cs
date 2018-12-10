using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class StaffBLL
    {
        /// <summary>
        /// 添加一个员工.
        /// </summary>
        /// <param name="sstaff">员工类对象</param>
        /// <returns>通过布尔值判断是否成功.</returns>
        public bool addStaff(Model.staff sstaff)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多个员工对象.
        /// </summary>
        /// <param name="staffs">员工类对象泛型集合.</param>
        /// <returns>通过布尔值判断是否成功.</returns>
        public bool addStaffs(List<Model.staff> staffs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有的员工记录.
        /// </summary>
        /// <returns>通过布尔值判断是否成功.</returns>
        public bool deleteAllStaffs()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除某个员工编号的员工.
        /// </summary>
        /// <param name="nnum">员工编号.</param>
        /// <returns>通过布尔值判断是否成功.</returns>
        public bool deleteStaffByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的员工对象.
        /// </summary>
        /// <returns>员工类对象的泛型集合.</returns>
        public List<Model.staff> getStaffs()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取具有某个员工编号的员工.
        /// </summary>
        /// <param name="nnum">员工编号。</param>
        /// <returns>员工对象的泛型集合.</returns>
        public Model.staff getStaffByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新员工信息。员工编号不能更新。
        /// </summary>
        /// <param name="sstaff">员工类对象.</param>
        /// <returns>通过布尔值判断是否成功.</returns>
        public bool updateStaff(Model.staff sstaff)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除某个部门的所有员工.
        /// </summary>
        /// <param name="departId">部门ID</param>
        /// <returns>通过布尔值判断是否成功.</returns>
        public bool deleteStaffsByDepart(string departId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取具有某个姓名的所有员工.
        /// </summary>
        /// <returns>员工类对象的泛型集合.</returns>
        public List<Model.staff> getStaffsByName()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取某个身份证ID的员工.
        /// </summary>
        /// <returns>员工类对象.</returns>
        public Model.staff getStaffByIdCard()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据入职时间获取员工.
        /// </summary>
        /// <param name="ttime">入职时间</param>
        /// <returns>员工类对象的泛型集合.</returns>
        public List<Model.staff> getStaffsByTime(DateTime ttime)
        {
            throw new System.NotImplementedException();
        }
    }
}
