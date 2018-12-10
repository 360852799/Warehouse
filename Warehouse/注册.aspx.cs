using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
public partial class 注册 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        clea();
        if (TextBox2.Text.Trim() == "" || TextBox6.Text.Trim() == "" || TextBox3.Text.Trim() == "" || TextBox1.Text.Trim() == "")
        {
            Response.Write("<script>alert('所有信息不能为空！')</script>");
        }
        else
        { 
            if (TextBox6.Text.Length > 16||TextBox6.Text.Length<6)
            {
                Label6.Text = "密码长度为6-16位";
            }
            else
            {
                if (TextBox6.Text.Trim() != TextBox3.Text.Trim())
                {
                    Label8.Text = "两次输入的密码不一致";
                }
                else
                {
                    SysUser s = new DAL.SysUserDAO().getUserByNum(TextBox2.Text.Trim());
                    if (s != null)
                    {
                        Label1.Text = "此人已注册，请更换注册员工";
                    }
                    else
                    {
                        staff sta = new DAL.StaffDAO().getStaffByNum(TextBox2.Text.Trim());
                        if (sta == null)
                        {
                            Label1.Text = "查无此人，请确定无误再输入";
                        }
                        else
                        {
                            if (sta.IdCard != TextBox1.Text.Trim())
                            {
                                Label12.Text = "您输入的身份证号和本人不符，请重新输入";
                            }
                            else
                            {
                                SysUser su = new SysUser();
                                su.Job = DropDownList1.SelectedValue.ToString();
                                su.Password = TextBox3.Text.Trim();
                                su.StaffNum = TextBox2.Text.Trim();
                                bool addsuccess = new DAL.SysUserDAO().addUser(su);
                                if (addsuccess)
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('注册成功');window.location='登录.aspx';</script>");
                                    //RegisterStartupScript("false", "<script>alert('注册成功');window.location.href='登录.aspx'</script>"); 
                                    
                                }
                                else
                                {
                                    Response.Write("<script>alert('注册失败！')</script>");
                                }
                            }
                        }
                    }
                }
            }
            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("登录.aspx");
    }

    public void refresh()
    {
        TextBox2.Text = "";
        TextBox6.Text = "";
        TextBox3.Text = "";
        TextBox1.Text = "";
    }

    public void clea()
    {
        Label1.Text = "";
        Label6.Text = "";
        Label8.Text = "";
        Label12.Text = "";
    }

}