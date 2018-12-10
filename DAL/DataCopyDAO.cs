using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DataCopyDAO
    {
        /// <summary>
        /// 获取所有的数据备份。
        /// </summary>
        public List<Model.DataCopy> getAllCopy()
        {
            List<Model.DataCopy> data = new List<Model.DataCopy>();
            string sqltext = "select * from datacopy";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,new List<SqlParameter> ());
            while (sdr.Read())
            {
                Model.DataCopy d = new Model.DataCopy();
                d.CopyId = sdr["copyId"].ToString();
                d.DataName = sdr["dataName"].ToString();
                d.CopyTime = DateTime.Parse(sdr["copyTime"].ToString());
                d.CopyType = sdr["copyType"].ToString();
                d.CopySize = int.Parse(sdr["copySize"].ToString());
                d.SysUser = new DAL.SysUserDAO().getUserById(sdr["userId"].ToString());
                d.CopyLocation = sdr["copyLocation"].ToString();
                d.CopyState = sdr["copyState"].ToString();
                data.Add(d);
            }
            sdr.Close();
            DBTools.DBClose();
            return data;
        }

        /// <summary>
        /// 通过备份ID，获取某个数据备份。
        /// </summary>
        /// <param name="iid">数据备份ID</param>
        /// <returns>数据备份对象。</returns>
        public Model.DataCopy getCopyById(string iid)
        {
            Model.DataCopy data = null;
            string sqltext = "select * from datacopy where copyId=@copyId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@copyId", iid);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext,para);
            while (sdr.Read())
            {
                data = new Model.DataCopy();
                data.CopyId = sdr["copyId"].ToString();
                data.DataName = sdr["dataName"].ToString();
                data.CopyTime = DateTime.Parse(sdr["copyTime"].ToString());
                data.CopyType = sdr["copyType"].ToString();
                data.CopySize = int.Parse(sdr["copySize"].ToString());
                data.SysUser = new DAL.SysUserDAO().getUserById(sdr["userId"].ToString());
                data.CopyLocation = sdr["copyLocation"].ToString();
                data.CopyState = sdr["copyState"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return data;
        }


        /// <summary>
        /// 通过管理员ID，获取某个数据备份。
        /// </summary>
        /// <param name="userid">管理员ID</param>
        /// <returns>数据备份对象。</returns>
        public Model.DataCopy getCopyByUserId(string userid)
        {
            Model.DataCopy data = null;
            string sqltext = "select * from datacopy where userid=@userid";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@userid", userid);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                data = new Model.DataCopy();
                data.CopyId = sdr["copyId"].ToString();
                data.DataName = sdr["dataName"].ToString();
                data.CopyTime = DateTime.Parse(sdr["copyTime"].ToString());
                data.CopyType = sdr["copyType"].ToString();
                data.CopySize = int.Parse(sdr["copySize"].ToString());
                data.SysUser = new DAL.SysUserDAO().getUserById(sdr["userId"].ToString());
                data.CopyLocation = sdr["copyLocation"].ToString();
                data.CopyState = sdr["copyState"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return data;
        }


        /// <summary>
        /// 通过备份Name，获取某个数据备份。
        /// </summary>
        /// <param name="nname">数据备份name</param>
        /// <returns>数据备份对象。</returns>
        public Model.DataCopy getCopyByName(string nname)
        {
            Model.DataCopy data = null;
            string sqltext = "select * from datacopy where dataName=@dataName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@dataName", nname);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                data = new Model.DataCopy();
                data.CopyId = sdr["copyId"].ToString();
                data.DataName = sdr["dataName"].ToString();
                data.CopyTime = DateTime.Parse(sdr["copyTime"].ToString());
                data.CopyType = sdr["copyType"].ToString();
                data.CopySize = int.Parse(sdr["copySize"].ToString());
                data.SysUser = new DAL.SysUserDAO().getUserById(sdr["userId"].ToString());
                data.CopyLocation = sdr["copyLocation"].ToString();
                data.CopyState = sdr["copyState"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return data;
        }

        /// <summary>
        /// 删除所有的备份
        /// </summary>
        public bool deleteAllCopy()
        {
            string sqltext = "delete from datacopy";
            int i = DBTools.exenonquerySQL(sqltext,new List<SqlParameter> ());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据ID，删除某个备份。
        /// </summary>
        /// <param name="iid">数据备份ID</param>
        public bool deleteCopyById(string iid)
        {
            string sqltext = "delete from datacopy where copyId=@copyId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@copyId", iid);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加一个数据备份。
        /// </summary>
        /// <param name="ccopy">数据备份对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addCopy(Model.DataCopy ccopy)
        {
            string sqltext = "insert datacopy(copyId,dataName,copyTime,copyType,copySize,userId,copyLocation,copyState) values(@copyId,@dataName,@copyTime,@copyType,@copySize,@userId,@copyLocation,@copyState)";
            List<SqlParameter> para = new List<SqlParameter>();
            string maxid = DBTools.searchID("datacopy", "copyId");
            int id = maxid != null ? int.Parse(maxid) : 0;
            SqlParameter sqlpara1 = new SqlParameter("@copyId", (id+1).ToString());
            SqlParameter sqlpara2 = new SqlParameter("@dataName", ccopy.DataName);
            SqlParameter sqlpara3 = new SqlParameter("@copyTime", ccopy.CopyTime);
            SqlParameter sqlpara4 = new SqlParameter("@copyType", ccopy.CopyType);
            SqlParameter sqlpara5 = new SqlParameter("@copySize", ccopy.CopySize);
            SqlParameter sqlpara6 = new SqlParameter("@userId", ccopy.SysUser.UserId);
            SqlParameter sqlpara7 = new SqlParameter("@copyLocation", ccopy.CopyLocation);
            SqlParameter sqlpara8 = new SqlParameter("@copyState", ccopy.CopyState);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara7);
            para.Add(sqlpara8);
            int i = DBTools.exenonquerySQL(sqltext,para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多个数据备份对象。
        /// </summary>
        /// <param name="ccopies">数据备份对象集合</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool addCopies(List<Model.DataCopy> ccopies)
        {
            for (int j = 0; j < ccopies.Count; j++)
            {
                string sqltext = "insert datacopy(copyId,dataName,copyTime,copyType,copySize,userId,copyLocation,copyState) values(@copyId,@dataName,@copyTime,@copyType,@copySize,@userId,@copyLocation,@copyState)";
                List<SqlParameter> para = new List<SqlParameter>();
                string maxid = DBTools.searchID("datacopy", "copyId");
                int id = maxid != null ? int.Parse(maxid) : 0;
                SqlParameter sqlpara1 = new SqlParameter("@copyId", (id + 1).ToString());
                SqlParameter sqlpara2 = new SqlParameter("@dataName", ccopies[j].DataName);
                SqlParameter sqlpara3 = new SqlParameter("@copyTime", ccopies[j].CopyTime);
                SqlParameter sqlpara4 = new SqlParameter("@copyType", ccopies[j].CopyType);
                SqlParameter sqlpara5 = new SqlParameter("@copySize", ccopies[j].CopySize);
                SqlParameter sqlpara6 = new SqlParameter("@userId", ccopies[j].SysUser.UserId);
                SqlParameter sqlpara7 = new SqlParameter("@copyLocation", ccopies[j].CopyLocation);
                SqlParameter sqlpara8 = new SqlParameter("@copyState", ccopies[j].CopyState);
                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara4);
                para.Add(sqlpara5);
                para.Add(sqlpara6);
                para.Add(sqlpara7);
                para.Add(sqlpara8);
                int i = DBTools.exenonquerySQL(sqltext,para);
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 更改数据备份信息
        /// </summary>
        /// <param name="ccopy">数据备份对象</param>
        /// <returns>通过布尔值判断操作是否成功。</returns>
        public bool updateCopy(Model.DataCopy ccopy)
        {
            string sqltext = "update datacopy set dataName=@dataName,copyTime=@copyTime,copyType=@copyType,copySize=@copySize,userId=@userId,copyLocation=@copyLocation,copyState=@copyState where copyId=@copyId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@copyId", ccopy.CopyId);
            SqlParameter sqlpara2 = new SqlParameter("@dataName", ccopy.DataName);
            SqlParameter sqlpara3 = new SqlParameter("@copyTime", ccopy.CopyTime);
            SqlParameter sqlpara4 = new SqlParameter("@copyType", ccopy.CopyType);
            SqlParameter sqlpara5 = new SqlParameter("@copySize", ccopy.CopySize);
            SqlParameter sqlpara6 = new SqlParameter("@userId", ccopy.SysUser.UserId);
            SqlParameter sqlpara7 = new SqlParameter("@copyLocation", ccopy.CopyLocation);
            SqlParameter sqlpara8 = new SqlParameter("@copyState", ccopy.CopyState);

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
        /// 查找是否有相同名字的数据包
        /// </summary>
        /// <param name="dataCopyName"></param>
        /// <returns>true为存在，false为不存在</returns>
        public bool HaveSameDataCopyName(string dataCopyName)
        {
            string sqltext = "select * from datacopy where dataName=@dataName";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@dataName", dataCopyName);
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
        /// 还原数据库文件
        /// </summary>
        /// <param name="restoreFileName">数据库名字</param>
        public static void Restore(string restoreFileName)
        {
            //1.获取还原数据库和文件  
            string dbName = DBTools.GetDbName();
            string dbFullName = DBTools.GetDbPath() + restoreFileName;
            try
            {
                //2.执行还原操作  
                SqlConnection con = DBTools.GetConnection();
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                try
                {
                    cmd.CommandText = "use master";
                    cmd.ExecuteNonQuery();

                    StringBuilder sql = new StringBuilder();
                    //sql.Append("exec proc_Restore @dbFullName,@dbName");  

                    sql.Append(@"--1.1修改为单用模式  
                    exec(N'ALTER DATABASE '+@dbName+' SET SINGLE_USER WITH ROLLBACK IMMEDIATE');  
                --1.2结束链接进程  
                    DECLARE @kid varchar(max)    
                    SET @kid=''    
                    SELECT @kid=@kid+'KILL '+CAST(spid as Varchar(10))  FROM master..sysprocesses    
                    WHERE dbid=DB_ID(@dbName)  ;  
                    EXEC(@kid) ;  
                --2.执行还原语句  
                    restore database @dbName from  disk=@dbFullName  
                    with replace  --覆盖现有的数据库  
                --3.重置数据库为多用户模式  
                    exec(N'ALTER DATABASE '+@dbName+' SET MULTI_USER WITH ROLLBACK IMMEDIATE');");
                    SqlParameter[] parameters = new SqlParameter[]{  
                new SqlParameter("@dbName",SqlDbType.NVarChar,200),  
                new SqlParameter("@dbFullName",SqlDbType.NVarChar,200),  
            };
                    parameters[0].Value = dbName;
                    parameters[1].Value = dbFullName;

                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("还原数据库出错" + ex);
            }
        }

        /// <summary>
        /// 生成备份包
        /// </summary>
        public static void CreateBackup()
        {
            string dbname = DBTools.GetDbName();
            //要备份的位置  
            string dbfullname = DBTools.GetDbPath() + string.Format("{0}_{1}.mdf", dbname, DateTime.Now.ToString("yyyyMMddhhmmss"));
            //判断文件是否存在  
            if (File.Exists(dbfullname))
            {
                throw new Exception(dbfullname + "的备份文件已经存在，请稍后再试");
            }
            try
            {
                SqlConnection con = DBTools.GetConnection();

                SqlCommand cmd = con.CreateCommand();
                con.Open();
                try
                {
                    cmd.CommandText = "use master";
                    cmd.ExecuteNonQuery();

                    //1. 执行备份操作  
                    StringBuilder sql = new StringBuilder();
                    //sql.Append("exec master.dbo.proc_Backup @dbName,@dbFullName");  

                    sql.Append(@"DECLARE @kid varchar(100)    
                    SET @kid=''    
                    SELECT @kid=@kid+'KILL '+CAST(spid as Varchar(10))  FROM master..sysprocesses    
                    WHERE dbid=DB_ID(@dbName)    
                    PRINT @kid    
                    EXEC(@kid);  
                    backup database te to disk=@dbFullName;");

                    SqlParameter[] parameters = new SqlParameter[]{  
                    new SqlParameter("@dbName",SqlDbType.NVarChar,200),  
                    new SqlParameter("@dbFullName",SqlDbType.NVarChar,200),  
                    };
                    parameters[0].Value = dbname;
                    parameters[1].Value = dbfullname;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                    cmd.CommandText = sql.ToString();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("创建数据库备份出错：" + ex);
            }
        }
    }
}
