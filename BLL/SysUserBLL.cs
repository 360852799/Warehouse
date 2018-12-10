using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SysUserBLL
    {
        /// <summary>
        /// 添加一个用户对象.
        /// </summary>
        /// <param name="su">用户类对象</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool addUser(Model.SysUser su)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 添加多个用户对象.
        /// </summary>
        /// <param name="sus">用户对象泛型列表</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool addUsers(List<Model.SysUser> sus)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除所有用户
        /// </summary>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool deleteAllUsers()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 删除某个员工编号的用户信息.
        /// </summary>
        /// <param name="nnum">员工编号</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool deleteUserByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取所有用户对象.
        /// </summary>
        /// <returns>用户对象泛型集合.</returns>
        public List<Model.SysUser> getAllUsers()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取某个员工编号的用户对象.
        /// </summary>
        /// <param name="nnum">员工编号</param>
        /// <returns>用户类对象.</returns>
        public Model.SysUser getUserByNum(string nnum)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 更新某个用户的信息,员工编号保持不变.
        /// </summary>
        /// <param name="su">要更新的用户类对象</param>
        /// <returns>通过布尔值提示是否完成.</returns>
        public bool updateUser(Model.SysUser su)
        {
            throw new System.NotImplementedException();
        }
    }
}
