<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="管理部门.aspx.cs" Inherits="Warehouse.管理部门" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link type="text/css" rel="stylesheet" href="Depart.css" />
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Size="22px"></asp:SiteMapPath>
    <div runat="server" id="ideas" style="height: 180px; width: 300px; background-color: #e3dbe3; border: 1px solid #000; position: absolute; left: 500px; top: 380px; display: none">
        <div style="height: 100px; width: 300px; background-color: white;">
            <asp:Label ID="Label100" runat="server" Text="确定要删除吗？" Style="line-height: 80px; font-size: 22px; margin-left: 73px"></asp:Label>
        </div>
        <div style="height: 50px; width: 300px; background-color: white; margin-top: 20px; background-color: #e3dbe3;">
            <asp:Button ID="Button200" runat="server" Text="确认" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 60px; border: 1px solid #1377f0" OnClick="Button200_Click" />
            <asp:Button ID="Button300" runat="server" Text="取消" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 30px" OnClick="Button300_Click" />
        </div>
    </div>
    <div id="div1" class="div1">
        <asp:Button ID="Button5" runat="server" Text="新增部门" OnClick="Button5_Click" OnInit="Button5_Init" CssClass="Button5" />
        <asp:Button ID="Button4" runat="server" Text="全删" CssClass="Button4" OnClick="Button4_Click" OnClientClick='if (!confirm("确定要删除吗？")) {return false;}' />
        <asp:ListBox ID="ListBox1" CssClass="Listbox1" runat="server" Rows="1" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>根据部门ID</asp:ListItem>
            <asp:ListItem>根据部门名称</asp:ListItem>
            <asp:ListItem>根据上级部门</asp:ListItem>
            <asp:ListItem>根据负责人</asp:ListItem>
        </asp:ListBox>
        <asp:TextBox ID="TextBox5" CssClass="TextBox5" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CssClass="Button1" Text="查询" OnClick="Button1_Click" />
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="Girdview1" Width="800px" RowStyle-Height="40px" AutoGenerateColumns="False" PageSize="2" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
    <div runat="server" id="Div1" class="Div1">
        <div id="div2" class="div2">
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </div>
        <asp:ListBox ID="ListBox2" CssClass="Listbox2" runat="server" Rows="6" AutoPostBack="true" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
        <asp:Button ID="Button2" runat="server" CssClass="Button2" Text="获取上级部门" OnClick="Button2_Click" />
        <asp:Button ID="Button14" runat="server" CssClass="Button14" Text="重新选取" OnClick="Button14_Click" />
        <table id="Table1" class="Table1">
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label2" runat="server" Text="部门ID:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="180px" ReadOnly="true" Font-Size="19px"></asp:TextBox>
                    <asp:Image ID="Image11" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Visible="false" />
                    <asp:Label ID="Label11" runat="server" Text=" " Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label3" runat="server" Text="部门名称:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="180px" Font-Size="19px" OnTextChanged="TextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image12" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Visible="false" />
                    <asp:Label ID="Label12" runat="server" Text="您的房间名称输入不合理,请重新输入" Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label4" runat="server" Text="上级部门:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="180px" Font-Size="19px" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label5" runat="server" Text="负责人:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="180px" Font-Size="19px" AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Button ID="Button9" runat="server" Text="增加" CssClass="Button9" OnClick="Button9_Click" OnInit="Button9_Init" />
                </td>
                <td>
                    <asp:Button ID="Button13" runat="server" Text="返回" CssClass="Button13" OnClick="Button13_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
