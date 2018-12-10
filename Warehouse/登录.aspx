<%@ Page Language="C#" AutoEventWireup="True" Inherits="登录" MasterPageFile="~/MasterPage2.master" Codebehind="登录.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .btn_yanzheng {
            font-family:Arial;  
            font-style:italic;  
            font-weight:bold;  
            border:0;  
            letter-spacing:2px;  
            color:blue;  
            position:absolute;
            left:150px;
            top:135px;
            
        }
    </style>
   
    <asp:Image ID="Image1" runat="server" Style="width: 400px; height: 300px; position: absolute; top: 150px; left: 250px" ImageUrl="Image/图形化展示.png" />
    <div style="width: 400px; height: 300px; position: absolute; top: 150px; left: 680px; border: 2px ridge">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="用户编号:"  style="position:absolute;top:40px;left:25px;" ></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="position:absolute;top:40px;left:100px;"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="密码:" style="position:absolute;top:90px;left:58px;" ></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="position:absolute;top:90px;left:100px;" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Image ID="Image2" runat="server" alt="验证码"  style="position:absolute;top:135px;left:113px;" Width="100px" Height="30px" ImageUrl="~/验证码.aspx"/>
        <a href="登录.aspx" style="font-size:12px;position:absolute;top:140px;left:223px;text-decoration:none">看不清,换一张</a>
        <asp:Label ID="Label3" runat="server" Text="验证码:" style="position:absolute;top:180px;left:43px;"></asp:Label>
        <asp:TextBox ID="input" runat="server" style="position:absolute;top:180px;left:100px;"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="登录" style="position:absolute;top:240px;left:100px;border-radius:5px;border:2px ridge;width:60px;height:40px" OnClick="Button2_Click"  />
        <asp:Button ID="Button3" runat="server" Text="注册" style="position:absolute;top:240px;left:190px;border-radius:5px;border:2px ridge;width:60px;height:40px" OnClick="Button3_Click" />
    </div>
</asp:Content>
