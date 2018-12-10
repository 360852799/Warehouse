using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class DepartmentBLL
    {
        /// <summary>
        /// 添加一个部门。
        /// </summary>
        /// <param name="SysUser">部门对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addDepart(Model.Department depart)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多个部门。
        /// </summary>
        /// <param name="departs">部门对象集合</param>
        public bool addDeparts(List<Model.Department> departs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有部门。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteAllDeparts()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据部门Id，删除某个部门
        /// </summary>
        /// <param name="iid">部门ID</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteDepartById(string iid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有的部门。
        /// </summary>
        public List<Model.Department> getAllDeparts()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 根据部门ID，获取某个部门。
        /// </summary>
        /// <param name="iid">部门ID</param>
        public Model.Department getDepartById(string iid)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 是否已有相同名称的部门。
        /// </summary>
        /// <param name="nname">部门名称</param>
        /// <returns>有，则返回True；没有，则返回false.</returns>
        public bool hasDepartOfname(string nname)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个部门信息。部门ID不变。
        /// </summary>
        /// <param name="SysUser">部门对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateDepart(Model.Department depart)
        {
            throw new System.NotImplementedException();
        }
    }
}
