<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="管理库位.aspx.cs" Inherits="Warehouse.管理库位" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Size="22px"></asp:SiteMapPath>
    <div style="position: absolute; left: 240px; top: 210px">
        <asp:Button ID="Button1" runat="server" Text="新增库位" Style="border: 2px solid #8e8585; border-radius: 15px; behavior: url(PIE/PIE.htc); background-color: #e8e6e6; width: 120px; height: 40px; font-size: 16px;" OnClick="Button1_Click" OnInit="Button1_Init" />
        <asp:Button ID="Button4" runat="server" Text="全删" Style="behavior: url(PIE/PIE.htc); border: none; width: 60px; height: 30px; font-size: 16px; margin-left: 30px" OnClick="Button4_Click" OnClientClick='if (!confirm("确定要删除吗？")) {return false;}' />
        <asp:ListBox ID="ListBox1" runat="server" Rows="1" Style="width: 200px; font-size: 22px; position: absolute; left: 255px; top: 4.5px" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>根据库位编号</asp:ListItem>
            <asp:ListItem>根据库柜编号</asp:ListItem>
            <asp:ListItem>根据房间编号</asp:ListItem>
            <asp:ListItem>根据物品种类</asp:ListItem>
            <asp:ListItem>根据备注要求</asp:ListItem>
        </asp:ListBox>
        <asp:TextBox ID="TextBox5" runat="server" Style="width: 200px; font-size: 19px; height: 23px; position: absolute; left: 460px; top: 4.5px"></asp:TextBox>
        <asp:Button ID="Button10" runat="server" Text="查询" Style="width: 80px; height: 35px; border: none; position: absolute; left: 680px; top: 1.2px" OnClick="Button10_Click" />
    </div>
    <div style="position: absolute; left: 300px; top: 248px; width: 700px; height: 30px" runat="server" id="departmentCreate">
        <div style="position: absolute; width: 200px; height: 30px; display: inline-block">
            <a id="A8" runat="server" href="管理房间.aspx" style="line-height: 30px; font-size: 22px; margin-left: 18px; color: blue; text-decoration: none">新增房间</a>
        </div>
        <div style="position: absolute; left: 160px; width: 200px; height: 30px; display: inline-block">
            <a id="A9" runat="server" href="管理库柜.aspx" style="line-height: 30px; font-size: 22px; margin-left: 18px; color: black; text-decoration: none">新增库柜</a>
        </div>
        <div style="position: absolute; left: 310px; width: 200px; height: 30px; display: inline-block">
            <a id="A10" runat="server" href="库位类型管理.aspx" style="line-height: 30px; font-size: 22px; margin-left: 18px; color: black; text-decoration: none">新增库位类型</a>
        </div>
        <div style="position: absolute; left: 500px; width: 200px; height: 30px; display: inline-block">
            <a id="A11" runat="server" href="物品类型管理.aspx" style="line-height: 30px; font-size: 22px; margin-left: 58px; color: black; text-decoration: none">新增物品种类</a>
        </div>
    </div>
    <div runat="server" id="ideas" style="height: 180px; width: 300px; background-color: #e3dbe3; border: 1px solid #000; position: absolute; left: 500px; top: 380px; display: none">
        <div style="height: 100px; width: 300px; background-color: white;">
            <asp:Label ID="Label100" runat="server" Text="确定要删除吗？" Style="line-height: 80px; font-size: 22px; margin-left: 73px"></asp:Label>
        </div>
        <div style="height: 50px; width: 300px; background-color: white; margin-top: 20px; background-color: #e3dbe3;">
            <asp:Button ID="Button200" runat="server" Text="确认" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 60px; border: 1px solid #1377f0" OnClick="Button200_Click" />
            <asp:Button ID="Button300" runat="server" Text="取消" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 30px" OnClick="Button300_Click" />
        </div>
    </div>
    <div style="position: absolute; top: 286px; left: 300px; width: 700px; height: 600px; background-color: #e8e6e6" runat="server" id="Div1">
        <div style="position: absolute; width: 300px; height: 600px">
            <asp:ListBox ID="ListBox2" runat="server" Rows="6" Style="position: absolute; left: 70px; top: 40px; width: 180px; font-size: 20px" AutoPostBack="true" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
            <asp:Button ID="Button5" runat="server" Text="获取房间" Style="position: absolute; left: 90px; top: 230px; width: 147px; font-size: 23px" OnClick="Button5_Click" />
            <asp:Button ID="Button14" runat="server" Text="重新选取" Style="position: absolute; left: 90px; top: 290px; width: 147px; font-size: 23px" OnClick="Button14_Click" />
        </div>
        <div style="position: absolute; width: 600px; height: 600px; left: 300px" runat="server">
            <table id="table1" runat="server" style="position: absolute; left: 30px; top: 30px">
                <tr style="line-height: 50px">
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="房间编号:" Font-Size="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Style="width: 180px" Font-Size="23px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr style="line-height: 50px">
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="库位编号:" Font-Size="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="line-height: 50px">
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="库柜编号:" Font-Size="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="line-height: 50px">
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="库位类型编号:" Font-Size="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" Font-Size="23px" Style="width: 180px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr style="line-height: 50px">
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="可存物品种类:" Font-Size="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:ListBox ID="ListBox3" runat="server" Font-Size="23px" Style="width: 180px" Rows="1"></asp:ListBox>
                        <asp:Button ID="Button2" runat="server" Text="X" Style="border: none; background: none; cursor: pointer; font-size: 20px" OnClick="Button2_Click" />
                    </td>
                </tr>
                <tr style="line-height: 50px">
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="备注:" Font-Size="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" Font-Size="23px" Style="width: 180px" Text="无" AutoPostBack="true" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr style="line-height: 50px">
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="创建时间:" Font-Size="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" Font-Size="23px" Style="width: 180px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr style="line-height: 50px">
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="更新时间:" Font-Size="24px"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server" Font-Size="23px" Style="width: 180px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr style="line-height: 50px">
                    <td>
                        <asp:Button ID="Button6" runat="server" Text="增加" Width="100px" Height="40px" Style="margin-left: 30px; border-radius: 15px; border: 2px solid #808080" OnClick="Button6_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button7" runat="server" Text="返回" Width="100px" Height="40px" Style="margin-left: 40px; border-radius: 15px; border: 2px solid #808080" OnClick="Button7_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_1" Width="800px" RowStyle-Height="40px" AutoGenerateColumns="False" PageSize="1" AllowPaging="True" PagerSettings-Mode="NumericFirstLast"
        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
</asp:Content>
