using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace Warehouse
{
    public partial class 库位管理 : System.Web.UI.Page
    {
        public int m = 10;
        public string checkboxCondition = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Refreshs("select * from Department", "departId desc");
            //m = Gridviewcount();
            //m = Gridviewcount();//获得gridview的总数据数
            //DAL.DepartmentDAO Query = new DAL.DepartmentDAO();
            //Query.getAllDeparts();//得到所有的部门对象，并展示在gridview中
            //Button8.Text = Select();
            //Label1.Style["top"]="'"+(GridView1.PageSize*40+330)+"'px";
            //Refreshs("")
            Label1.Style["top"] = GridView1.PageSize * 40 + 330 + "px";
            Label11.Style["top"] = GridView1.PageSize * 40 + 330 + "px";
            Button2.Style["top"] = GridView1.PageSize * 40 + 333 + "px";
            Button3.Style["top"] = GridView1.PageSize * 40 + 333 + "px";
            Button4.Style["top"] = GridView1.PageSize * 40 + 333 + "px";
            departmentCreate.Style["display"] = "none";
            Label11.Text = "共" + GridView1.PageCount + "页";
        }
        private void Refreshs(string str)
        {
            GridView1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            GridView1.AutoGenerateColumns = false;
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            //string sql = str1;
            string sql = "select * from department";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            //ds.Tables[0].DefaultView.Sort = str2;
            ds.Tables[0].DefaultView.Sort = "departId asc";
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        private void Refreshs1(string str)
        {
            GridView1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            GridView1.AutoGenerateColumns = false;
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            //string sql = str1;
            string sql = "select * from Department where departId='" + str + "'";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            //ds.Tables[0].DefaultView.Sort = str2;
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        private void Refreshs2(string str)
        {
            GridView1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            GridView1.AutoGenerateColumns = false;
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            //string sql = str1;
            string sql = "select * from department where departName='" + str + "'";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            //ds.Tables[0].DefaultView.Sort = str2;
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        private void Refreshs3(string str)
        {
            GridView1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            GridView1.AutoGenerateColumns = false;
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            //string sql = str1;
            string sql = "select * from department where StaffNum='" + str + "'";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            //ds.Tables[0].DefaultView.Sort = str2;
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        private void Refreshs4(string str)
        {
            GridView1.DataSourceID = null;
            System.Data.DataView dv = new System.Data.DataView();
            GridView1.AutoGenerateColumns = false;
            System.Data.SqlClient.SqlConnection coon = new System.Data.SqlClient.SqlConnection();
            coon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connection"].ToString();
            //string sql = str1;
            string sql = "select * from Department where parentdepartName='" + str + "'";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sql, coon);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            //ds.Tables[0].DefaultView.Sort = str2;
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        public int Gridviewcount()
        {
            int b = GridView1.PageIndex;
            GridView1.PageIndex = GridView1.PageCount;
            GridView1.DataBind();
            m = GridView1.Rows.Count + (GridView1.PageCount - 1) * GridView1.PageSize;
            GridView1.PageIndex = b;
            return m;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            if (GridView1.Visible == true)
            {
                Label1.Visible = true;
                Label11.Visible = true;
                Button2.Visible = true;
                Button3.Visible = true;
                Button4.Visible = true;
                Button10.Visible = true;
                ListBox1.Visible = true;
                TextBox5.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Label1.Visible = false;
                Label11.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                Button10.Visible = false;
                ListBox1.Visible = false;
                TextBox5.Visible = false;
            }
            departmentCreate.Style["display"] = "inline";
            Button6.Text = "增加";
            ////SqlConnection coon = new SqlConnection();
            ////coon.ConnectionString = "server=LAPTOP-VOKC3UU6;database=Warehouse;uid=register;pwd=123456";
            ////SqlCommand cmd = new SqlCommand();
            ////cmd.Connection = coon;
            ////coon.Open();
            ////cmd.CommandText = "insert into Department(departId,departName,staffNum,parentdepartName) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
            ////cmd.ExecuteNonQuery();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.PageIndex == 0)
            {
                Response.Write("<script>alert('这是首页！')</script>");
                GridView1.PageIndex = 1;
            }
            GridView1.PageIndex = GridView1.PageIndex - 1;
            Label1.Text = "第" + (GridView1.PageIndex + 1) + "页";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.PageIndex == GridView1.PageCount - 1)
            {
                Response.Write("<script>alert('这是末页！')</script>");
                GridView1.PageIndex = GridView1.PageCount;
            }
            else
            {
                GridView1.PageIndex = GridView1.PageIndex + 1;
                Label1.Text = "第" + (GridView1.PageIndex + 1) + "页";
            }
            //clear(arrrr, GridView1.Columns.Count);
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            if (GridView1.Visible == true)
            {
                Label1.Visible = true;
                Label11.Visible = true;
                Button2.Visible = true;
                Button3.Visible = true;
                Button4.Visible = true;
                Button10.Visible = true;
                ListBox1.Visible = true;
                TextBox5.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Label1.Visible = false;
                Label11.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                Button10.Visible = false;
                ListBox1.Visible = false;
                TextBox5.Visible = false;
            }
            departmentCreate.Style["display"] = "none";
        }
        protected void Button100_Click(object sender, EventArgs e)
        {
            DAL.DepartmentDAO DeleteAll = new DAL.DepartmentDAO();
            DeleteAll.deleteAllDeparts();//删除所有部门
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            switch (ListBox1.Text)
            {
                case "根据部门ID":
                    //根据部门ID得到对象，并刷新gridview的内容
                    Refreshs1(TextBox5.Text);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            Response.Write("<script>alert('查询成功！')</script>");
                        }
                    }
                    catch
                    {
                        Response.Write("<script>alert('查询失败！')</script>");
                        Refreshs("");
                    }
                    break;
                case "根据部门名称":
                    //根据部门名称得到对象，并刷新gridview的内容
                    Refreshs2(TextBox5.Text);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            Response.Write("<script>alert('查询成功！')</script>");
                        }
                    }
                    catch
                    {
                        Response.Write("<script>alert('查询失败！')</script>");
                        Refreshs("");
                    }
                    break;
                case "根据上级部门":
                    //根据上级部门得到对象，并刷新gridview的内容
                    Refreshs4(TextBox5.Text);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            Response.Write("<script>alert('查询成功！')</script>");
                        }
                    }
                    catch
                    {
                        Response.Write("<script>alert('查询失败！')</script>");
                        Refreshs("");
                    }
                    break;
                case "根据负责人":
                    //根据负责人得到对象，并刷新gridview的内容
                    Refreshs3(TextBox5.Text);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            Response.Write("<script>alert('查询成功！')</script>");
                        }
                    }
                    catch
                    {
                        Response.Write("<script>alert('查询失败！')</script>");
                        Refreshs("");
                    }
                    break;
                case "":
                    TextBox5.Text = "";
                    Refreshs("");
                    break;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button20_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            if (btn.CommandName == "editt")
            {
                departmentCreate.Style["display"] = "inline";
                Button6.Text = "确定";
                GridView1.Visible = false;
                if (GridView1.Visible == true)
                {
                    Label1.Visible = true;
                    Label11.Visible = true;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    Button4.Visible = true;
                    Button10.Visible = true;
                    ListBox1.Visible = true;
                    TextBox5.Visible = true;
                }
                else if (GridView1.Visible == false)
                {
                    Label1.Visible = false;
                    Label11.Visible = false;
                    Button2.Visible = false;
                    Button3.Visible = false;
                    Button4.Visible = false;
                    Button10.Visible = false;
                    ListBox1.Visible = false;
                    TextBox5.Visible = false;
                }
                TextBox1.Text = row.Cells[0].Text;
                TextBox2.Text = row.Cells[1].Text;
                TextBox3.Text = row.Cells[2].Text;
                TextBox4.Text = row.Cells[3].Text;
                TextBox1.ReadOnly = true;
            }
        }
        //Response.Write("<script>alert('请选择一个部门进行编辑！')</script>");
        public GridViewRow Row(object sender)
        {
            Button btnn = (Button)sender;
            GridViewRow row = (GridViewRow)btnn.NamingContainer;//查找button所在行数
            return row;
        }
        protected void Button30_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Model.Department delete = new Model.Department();
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            delete.DepartId = row.Cells[0].Text;
            int xx = new DAL.DepartmentDAO().updateParentDepartName(delete);
            bool yy = new DAL.DepartmentDAO().deleteDepartById(delete.DepartId);
            if (yy && xx > 0)
            {
                Response.Write("<script>alert('删除成功，并将其下属部门的上级部门重置！')</script>");
                Refreshs("");
            }
            else
            {
                Response.Write("<script>alert('删除失败!')</script>");
            }
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            switch (Button6.Text)
            {
                case "增加":
                    {
                        Model.Department add = new Department();
                        add.SysUser = new DAL.SysUserDAO().getUserById(TextBox4.Text);
                        if (add.SysUser != null)
                        {
                            add.DepartId = TextBox1.Text;
                            add.DepartName = TextBox2.Text;
                            add.ParentdepartName = new DAL.DepartmentDAO().getDepartById(TextBox3.Text);
                            bool xx = new DAL.DepartmentDAO().addDepart(add);
                            if (xx == true)//添加一个部门
                            {
                                Response.Write("<script>alert('添加成功!')</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('添加失败!')</script>");
                        }
                    }
                    break;
                case "确定":
                    {
                        Button btn = sender as Button;
                        Model.Department update = new Department();
                        update.DepartId = TextBox1.Text;
                        update.DepartName = TextBox2.Text;
                        update.SysUser = new DAL.SysUserDAO().getUserById(TextBox4.Text);
                        update.ParentdepartName = new DAL.DepartmentDAO().getDepartById(TextBox3.Text);
                        update.SysUser.StaffNum = TextBox4.Text;
                        update.ParentdepartName.DepartName = TextBox3.Text;
                        bool xx = new DAL.DepartmentDAO().updateDepart(update);
                        if (xx)
                        {
                            Response.Write("<script>alert('修改成功!')</script>");
                            Refreshs("");
                        }
                        else
                        {
                            Response.Write("<script>alert('修改失败!')</script>");
                        }
                    }
                    break;
            }
        }

        protected void Button1_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Init(object sender, EventArgs e)
        {
            Refreshs("");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            bool xx = new DAL.DepartmentDAO().deleteAllDeparts();
            if (xx)
            {
                Response.Write("<script>alert('删除成功!')</script>");
                Refreshs("");
            }
            else
            {
                Response.Write("<script>alert('删除失败!')</script>");
            }
        }
    }
}