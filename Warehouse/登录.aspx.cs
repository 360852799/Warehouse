using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
public partial class 登录 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //code.Attributes.Add("OnClick", "createCode()"); 
            //Button2.Attributes.Add("OnClick", "validate()");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>validate();</script>");
        if (TextBox1.Text.Trim() == "" || TextBox1.Text.Trim() == null)        //判断账号框是否为空，为空提示，不为空继续进行
        {
            Response.Write("<script>alert('编号不能为空!')</script>");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('编号不能为空!');", true);
            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>alert('编号不能为空!');</script>");
        }
        else
        {
            if (TextBox2.Text.Trim() == "" || TextBox2.Text.Trim() == null)         //判断密码框是否为空，为空提示，不为空继续进行
            {
                Response.Write("<script>alert('密码不能为空!')</script>");
            }
            else
            {
                if (input.Text.Trim() == "" || input.Text.Trim() == null)           //判断验证码框是否为空，为空提示，否则继续执行
                {
                    Response.Write("<script>alert('验证码不能为空!')</script>");
                }
                else
                {
                    if (input.Text.Trim() != Session["vcode"].ToString())
                    {
                        Response.Write("<script>alert('验证码输入错误!')</script>");
                    }
                    else
                    {
                        SysUser sys = new DAL.SysUserDAO().getUserByNum(TextBox1.Text.Trim());
                        if (sys == null)
                        {
                            Response.Write("<script>alert('用户不存在，请检查账号或密码!')</script>");
                        }
                        else
                        {
                            if (sys.Password == TextBox2.Text.Trim())               //如果密码也和账号关联的用户的密码相同就跳转网页，不同就提示
                            {
                                new Warehouse.Tools.AddSysLog().addlog("1", "登录", "登录");
                                Session.Add("UserName", sys.Staff.StaffName);
                                Session.Add("UserId", sys.UserId);
                                Response.Redirect("主页.aspx");
                            }
                            else
                            {
                                Response.Write("<script>alert('密码错误!')</script>");
                            }//end else --> password is wrong
                        }//end else --> sys==null
                    }
                }
            }// end else --> password is null
        }//end else --> ID is null
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("注册.aspx");
    }

    protected void code_Click(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>createCode();</script>");
    }
}