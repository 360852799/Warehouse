<%@ Page Language="C#" AutoEventWireup="True" Inherits="注册" MasterPageFile="~/MasterPage2.master" Codebehind="注册.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">

    </style>
    <div style="height: 430px; width: 750px; position: absolute; left: 330px; top: 160px; border: 2px ridge;margin-left:100px;padding-top:50px">
       <table style="margin:0px auto;align-content:center">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="员工编号："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="378px" Height="34px" placeholder="请输入密码（最多16位）" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="确认密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="378px" Height="34px" placeholder="请确认密码" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>                
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="选择角色："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="38px" Width="382px">
                        <asp:ListItem>管理员</asp:ListItem>
                        <asp:ListItem>高级管理员</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
           <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="身份证号："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="确定注册" CssClass="register_btn" OnClick="Button1_Click"/>
                    <asp:Button ID="Button2" runat="server" Text="取消注册" CssClass="register_btn" OnClick="Button2_Click"/>
                </td>
                
            </tr>
        </table>
    </div>
</asp:Content>
