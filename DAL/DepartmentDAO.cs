using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DepartmentDAO
    {
        /// <summary>
        /// 添加一个部门。
        /// </summary>
        /// <param name="depart">部门对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addDepart(Model.Department depart)
        {
            string sqltext = "insert Department(num,departId,departName,staffNum,parentdepartName) values(@num,@departId,@departName,@staffNum,@parentdepartName)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", depart.Num);
            SqlParameter sqlpara1 = new SqlParameter("@departId", depart.DepartId);
            SqlParameter sqlpara2 = new SqlParameter("@departName", depart.DepartName);
            SqlParameter sqlpara3 = new SqlParameter("@staffNum", depart.StaffNum);
            SqlParameter sqlpara4 = new SqlParameter("@parentdepartName", depart.ParentdepartName);
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多个部门。
        /// </summary>
        /// <param name="departs">部门对象泛型集合。</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addDeparts(List<Model.Department> departs)
        {
            for (int j = 0; j < departs.Count; j++)
            {
                string sqltext = "insert department(departId,departName,staffNum,parentdepartName) values(@departId,@departName,@staffNum,@parentdepartName)";
                List<SqlParameter> para = new List<SqlParameter>();
                string maxid = DBTools.searchID("department", "departId");
                int id = maxid != null ? int.Parse(maxid) : 0;
                SqlParameter sqlpara1 = new SqlParameter("@departId", (id + 1).ToString());
                SqlParameter sqlpara2 = new SqlParameter("@departName", departs[j].DepartName);
                SqlParameter sqlpara3 = new SqlParameter("@staffNum", departs[j].SysUser.StaffNum);
                SqlParameter sqlpara4 = new SqlParameter("@parentdepartName", departs[j].ParentdepartName);
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
        /// 删除所有部门。
        /// </summary>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteAllDeparts()
        {
            string sqltext = "delete from department";
            int i = DBTools.exenonquerySQL(sqltext, new List<SqlParameter>()); ;
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据部门ID，删除某个部门。
        /// </summary>
        /// /// <param name="did">部门ID。</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool deleteDepartById(string did)
        {
            string sqltext = "delete from department where departId=@departId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@departId", did);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新某个部门信息。部门ID不能更改。
        /// </summary>
        /// <param name="depart">部门对象。</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateDepart(Model.Department depart)
        {
            string sqltext = "update department set departName=@departName,staffNum=@staffNum,parentdepartName=@parentdepartName where departId=@departId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@departId", depart.DepartId);
            SqlParameter sqlpara2 = new SqlParameter("@departName", depart.DepartName);
            SqlParameter sqlpara3 = new SqlParameter("@staffNum", depart.StaffNum);
            SqlParameter sqlpara4 = new SqlParameter("@parentdepartName", depart.ParentdepartName);
            para.Add(sqlpara2);
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
        /// 获取所有部门对象。
        /// </summary>
        public List<Model.Department> getAllDeparts()
        {
            List<Model.Department> depar = new List<Model.Department>();
            string sqltext = "select * from department";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, new List<SqlParameter>());
            while (sdr.Read())
            {
                Model.Department d = new Model.Department();
                d.DepartId = sdr["departId"].ToString();
                d.DepartName = sdr["departName"].ToString();
                d.SysUser = new DAL.SysUserDAO().getUserByNum(sdr["staffNum"].ToString());
                //d.ParentdepartName = new DAL.DepartmentDAO().getDepartById(sdr["parentdepartName"].ToString());
                depar.Add(d);
            }
            sdr.Close();
            DBTools.DBClose();
            return depar;
        }

        /// <summary>
        /// 根据部门ID，获取某个部门对象。
        /// </summary>
        /// <param name="iid">部门ID</param>
        public Model.Department getDepartById(string iid)
        {
            Model.Department depar = null;
            string sqltext = "select * from department where departId=@departId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@departId", iid);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                depar = new Model.Department();
                depar.DepartId = sdr["departId"].ToString();
                depar.DepartName = sdr["departName"].ToString();
                depar.StaffNum = sdr["staffNum"].ToString();
                depar.ParentdepartName = sdr["parentdepartName"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return depar;
        }

        /// <summary>
        /// 是否已经有相同名称的部门。
        /// </summary>
        /// <param name="nname">部门名称</param>
        /// <returns>有，则返回true；没有，则返回false。</returns>
        public bool hasDepartOfName(string nname)
        {
            Model.Department depar = new Model.Department();
            string sqltext = "select * from department where departName=@departName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@departName", nname);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                sdr.Close();
                DBTools.DBClose();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 修改所有以参数depar的ID为上级部门的部门的上级部门为"无"
        /// </summary>
        /// <param name="depar">Department对象</param>
        /// <returns>修改成功或失败返回True或False</returns>
        public int updateParentDepartName(Model.Department depart)
        {
            string sqltext = "update department set parentdepartName='无' where parentdepartName=@departId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@departId", depart.DepartId);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i > 0)
                return i;
            else
                return 0;
        }

    }
}
