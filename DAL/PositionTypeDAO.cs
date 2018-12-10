using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PositionTypeDAO
    {
        /// <summary>
        /// 获取所有的库位类型.
        /// </summary>
        /// <returns>库位类型对象泛型集合.</returns>
        public List<Model.PositionType> getAllPositionsType()
        {
            List<Model.PositionType> posity = new List<Model.PositionType>();
            string sqltext = "select * from positiontype";
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, new List<SqlParameter>());
            while (sdr.Read())
            {
                Model.PositionType p = new Model.PositionType();
                p.PositionTypeId = sdr["positionTypeId"].ToString();
                p.PositionTypeName = sdr["positionTypeName"].ToString();
                p.Length = sdr["length"].ToString();
                p.Width = sdr["width"].ToString();
                p.Height = sdr["height"].ToString();
                p.Remark = sdr["remark"].ToString();
                
                posity.Add(p);
            }
            sdr.Close();
            DBTools.DBClose();
            return posity;
        }

        /// <summary>
        /// 删除所有的库位类型
        /// </summary>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool deleteAllPositionsType()
        {
            string sqltext = "delete from positiontype";
            int i = DBTools.exenonquerySQL(sqltext, new List<SqlParameter>());
            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加一个库位类型.库位类型ID是主键.
        /// </summary>
        /// <param name="posity">库位类型对象.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addPositionType(Model.PositionType posity)
        {
            string sqltext = "insert positiontype(num,positionTypeId,positionTypeName,length,width,height,remark) values(@num,@positionTypeId,@positionTypeName,@length,@width,@height,@remark)";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara = new SqlParameter("@num", posity.Num);
            SqlParameter sqlpara1 = new SqlParameter("@positionTypeId",posity.PositionTypeId);
            SqlParameter sqlpara2 = new SqlParameter("@positionTypeName", posity.PositionTypeName);
            SqlParameter sqlpara3 = new SqlParameter("@length", posity.Length);
            SqlParameter sqlpara4 = new SqlParameter("@width", posity.Width);
            SqlParameter sqlpara5 = new SqlParameter("@height", posity.Height);
            SqlParameter sqlpara6 = new SqlParameter("@remark", posity.Remark);
            para.Add(sqlpara);
            para.Add(sqlpara1);
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加多个库位类型.
        /// </summary>
        /// <param name="posisty">库位类型对象泛型集合.</param>
        /// <returns>通过布尔类型判断操作是否成功.</returns>
        public bool addPositionsType(List<Model.PositionType> posisty)
        {
            for (int j = 0; j < posisty.Count; j++)
            {
                string sqltext = "insert positiontype(positionTypeId,positionTypeName,length,width,height,remark) values(@positionTypeId,@positionTypeName,@length,@width,@height,@remark)";
                List<SqlParameter> para = new List<SqlParameter>();
                string maxid = DBTools.searchID("position", "positionTypeId");
                int id = maxid != null ? int.Parse(maxid) : 0;
                SqlParameter sqlpara1 = new SqlParameter("@positionTypeId", (id + 1).ToString());
                SqlParameter sqlpara2 = new SqlParameter("@positionTypeName", posisty[j].PositionTypeName);
                SqlParameter sqlpara3 = new SqlParameter("@length", posisty[j].Length);
                SqlParameter sqlpara4 = new SqlParameter("@width", posisty[j].Width);
                SqlParameter sqlpara5 = new SqlParameter("@height", posisty[j].Height);
                SqlParameter sqlpara6 = new SqlParameter("@remark", posisty[j].Remark);
                para.Add(sqlpara1);
                para.Add(sqlpara2);
                para.Add(sqlpara3);
                para.Add(sqlpara4);
                para.Add(sqlpara5);
                para.Add(sqlpara6);
                int i = DBTools.exenonquerySQL(sqltext, para);
                if (i == 1)
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 更新某个库位.库位ID不可更改.
        /// </summary>
        /// <param name="posity">库位类型对象.</param>
        public bool updatePositionType(Model.PositionType posity)
        {
            string sqltext = "update positiontype set positionTypeName=@positionTypeName,length=@length,width=@width,height=@height,remark=@remark where positionTypeId=@positionTypeId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionTypeId",posity.PositionTypeId);
            SqlParameter sqlpara2 = new SqlParameter("@positionTypeName", posity.PositionTypeName);
            SqlParameter sqlpara3 = new SqlParameter("@length", posity.Length);
            SqlParameter sqlpara4 = new SqlParameter("@width", posity.Width);
            SqlParameter sqlpara5 = new SqlParameter("@height", posity.Height);
            SqlParameter sqlpara6 = new SqlParameter("@remark", posity.Remark);
            
            para.Add(sqlpara2);
            para.Add(sqlpara3);
            para.Add(sqlpara4);
            para.Add(sqlpara5);
            para.Add(sqlpara6);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 通过ID找到库位类型.
        /// </summary>
        /// <param name="iid">库位类型ID.</param>
        public Model.PositionType getPositionTypeByid(string iid)
        {
            Model.PositionType p = null;
            string sqltext = "select * from positiontype where positionTypeId=@positionTypeId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionTypeId", iid);
            para.Add(sqlpara1);
            SqlDataReader sdr = DBTools.exereaderSQL(sqltext, para);
            while (sdr.Read())
            {
                p = new Model.PositionType();
                p.PositionTypeId = sdr["positionTypeId"].ToString();
                p.PositionTypeName = sdr["positionTypeName"].ToString();
                p.Length = sdr["length"].ToString();
                p.Width = sdr["width"].ToString();
                p.Height = sdr["height"].ToString();
                p.Remark = sdr["remark"].ToString();
            }
            sdr.Close();
            DBTools.DBClose();
            return p;
        }

        /// <summary>
        /// 通过ID,删除某个库位类型.
        /// </summary>
        public bool deletePositionTypeByid(string posityid)
        {
            string sqltext = "delete from positiontype where positionTypeId=@positionTypeId";
            List<SqlParameter> para = new List<SqlParameter>();
            SqlParameter sqlpara1 = new SqlParameter("@positionTypeId", posityid);
            para.Add(sqlpara1);
            int i = DBTools.exenonquerySQL(sqltext, para);
            if (i == 1)
                return true;
            else
                return false;
        }
    }
}
