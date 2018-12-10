<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="物品类型管理.aspx.cs" Inherits="Warehouse.物品类型管理" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Size="22px"></asp:SiteMapPath>
    <div style="position: absolute; left: 200px; top: 180px">
        <asp:Button ID="Button2" runat="server" Text="新增物品类型" Style="border: 2px solid #8e8585; border-radius: 15px; behavior: url(PIE/PIE.htc); background-color: #e8e6e6; width: 120px; height: 40px; font-size: 16px;" OnClick="Button2_Click" />
        <asp:Button ID="Button4" runat="server" Text="全删" Style="behavior: url(PIE/PIE.htc); border: none; width: 60px; height: 30px; font-size: 16px; margin-left: 30px" OnClientClick='if (!confirm("确定要删除吗？")) {return false;}' OnClick="Button4_Click" />
        <asp:ListBox ID="ListBox4" runat="server" Rows="1" Style="width: 210px; font-size: 22px; position: absolute; left: 255px; top: 4.5px" AutoPostBack="true" OnSelectedIndexChanged="ListBox4_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>根据物品类型编号</asp:ListItem>
            <asp:ListItem>根据物品类型名称</asp:ListItem>
            <asp:ListItem>根据父类别编号</asp:ListItem>
            <asp:ListItem>根据备注要求</asp:ListItem>
        </asp:ListBox>
        <asp:TextBox ID="TextBox2" runat="server" Style="width: 200px; font-size: 19px; height: 23px; position: absolute; left: 500px; top: 4.5px"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="查询" Style="border-style: none; border-color: inherit; border-width: medium; width: 80px; height: 35px; position: absolute; left: 740px; top: 2px" OnClick="Button3_Click" />
    </div>
    <div runat="server" id="ideas" style="height: 180px; width: 300px; background-color: #e3dbe3; border: 1px solid #000; position: absolute; left: 500px; top: 380px; display: none;z-index:5">
        <div style="height: 100px; width: 300px; background-color: white;">
            <asp:Label ID="Label100" runat="server" Text="确定要删除吗？" Style="line-height: 80px; font-size: 22px; margin-left: 73px"></asp:Label>
        </div>
        <div style="height: 50px; width: 300px; background-color: white; margin-top: 20px; background-color: #e3dbe3;">
            <asp:Button ID="Button200" runat="server" Text="确认" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 60px; border: 1px solid #1377f0" OnClick="Button200_Click" />
            <asp:Button ID="Button300" runat="server" Text="取消" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 30px" OnClick="Button300_Click" />
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_1m" Width="900px" RowStyle-Height="42px" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PreviousPageText="上一页" Mode="NextPreviousFirstLast" />
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
    <div style="position: absolute; top: 250px; left: 250px; width: 800px; height: 474px; z-index: 1" runat="server" id="Div1" visible="false">
        <asp:ListBox ID="ListBox2" runat="server" Rows="4" Style="position: absolute; top: 30px; left: -38px; width: 200px;font-size:22px"></asp:ListBox>
        <asp:Button ID="Button6" runat="server" Text="获取父类别" Style="position: absolute; top: 172px; left: 5px; width: 122px; font-size: 19px" OnClick="Button6_Click" />
        <table style="margin-left: 180px;">
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label10" runat="server" Text="物品类型编号:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="19px"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label12" runat="server" Text="物品类型名称:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Style="width: 180px" Font-Size="19px" OnTextChanged="TextBox11_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label1" runat="server" Text="名称输入不合理,请重新输入" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label13" runat="server" Text="父类型编号:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="19px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>

            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label14" runat="server" Text="物品类别状态:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="ListBox3" runat="server" Rows="1" Style="width: 180px; height: 25px;" AutoPostBack="true" Font-Size="19px">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>固态</asp:ListItem>
                        <asp:ListItem>液态</asp:ListItem>
                        <asp:ListItem>气态</asp:ListItem>
                        <asp:ListItem>其他</asp:ListItem>
                    </asp:ListBox>
                    <asp:Image ID="Image4" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label15" runat="server" Text="备注:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox14" runat="server" Style="width: 180px" Font-Size="19px" Text="无" OnTextChanged="TextBox14_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label16" runat="server" Text="创建时间:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="19px"></asp:TextBox>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label2" runat="server" Text="更新时间:" ReadOnly="true" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server" Style="width: 180px" Font-Size="19px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Button ID="Button9" runat="server" Text="增加" Style="margin-left: 30px" Height="39px" Width="64px" Font-Size="19px" OnClick="Button9_Click" />
                </td>
                <td>
                    <asp:Button ID="Button13" runat="server" Text="返回" Style="margin-left: 40px" Height="39px" Width="64px" Font-Size="19px" OnClick="Button13_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
