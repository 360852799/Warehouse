<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="库位类型管理.aspx.cs" Inherits="Warehouse.库位类型管理" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link type="text/css" rel="stylesheet" href="StyleSheet.css" />
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Size="22px"></asp:SiteMapPath>
    <div style="position: absolute; left: 200px; top: 180px">
        <asp:Button ID="Button5" runat="server" Text="新增库柜" Style="border: 2px solid #8e8585; border-radius: 15px; behavior: url(PIE/PIE.htc); background-color: #e8e6e6; width: 120px; height: 40px; font-size: 16px;" OnClick="Button5_Click" OnInit="Button5_Init" />
        <asp:Button ID="Button4" runat="server" Text="全删" Style="behavior: url(PIE/PIE.htc); border: none; width: 60px; height: 30px; font-size: 16px; margin-left: 30px" OnClick="Button4_Click" OnClientClick='if (!confirm("确定要删除吗？")) {return false;}' />
        <asp:ListBox ID="ListBox1" runat="server" Rows="1" Style="width: 200px; font-size: 22px; position: absolute; left: 255px; top: 4.5px" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>根据库位类型编号</asp:ListItem>
            <asp:ListItem>根据库位类型名称</asp:ListItem>
            <asp:ListItem>根据备注要求</asp:ListItem>
        </asp:ListBox>
        <asp:TextBox ID="TextBox1" runat="server" Style="width: 200px; font-size: 19px; height: 23px; position: absolute; left: 460px; top: 4.5px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查询" Style="width: 80px; height: 35px; border: none; position: absolute; left: 680px; top: 1.2px" OnClick="Button1_Click" />
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_1m" Width="900px" RowStyle-Height="42px" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PreviousPageText="上一页" Mode="NextPreviousFirstLast" />
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
    <div style="position: absolute; width: 1000px; height: 600px; left: 200px; top: 250px" runat="server" id="Div1">
        <table style="margin-top: 30px; margin-left: 200px">
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label10" runat="server" Text="库位类型编号:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px" OnTextChanged="TextBox10_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label12" runat="server" Text="库位类型名称:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Style="width: 180px" Font-Size="23px" OnTextChanged="TextBox11_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label3" runat="server" Text="您的库柜类型名称输入不合理,请重新输入" Font-Size="16px" ForeColor="Red" Visible="false" Style="margin-left: 20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label13" runat="server" Text="长度:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server" Style="width: 180px" OnTextChanged="TextBox12_TextChanged" AutoPostBack="true" placeholder="单位为cm" Font-Size="23px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label4" runat="server" Text="您的库位长度输入不合理,请输入一个整数" Font-Size="16px" ForeColor="Red" Visible="false" Style="margin-left: 20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label14" runat="server" Text="宽度:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" runat="server" Style="width: 180px" OnTextChanged="TextBox13_TextChanged" AutoPostBack="true" placeholder="单位为cm" Font-Size="23px"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label5" runat="server" Text="您的库位宽度输入不合理,请输入一个整数" Font-Size="16px" ForeColor="Red" Visible="false" Style="margin-left: 20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label15" runat="server" Text="高度:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox14" runat="server" Style="width: 180px" OnTextChanged="TextBox14_TextChanged" AutoPostBack="true" placeholder="单位为cm" Font-Size="23px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label6" runat="server" Text="您的库位高度输入不合理,请输入一个整数" Font-Size="16px" ForeColor="Red" Visible="false" Style="margin-left: 20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label16" runat="server" Text="备注:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server" Text="无要求" Style="width: 180px" OnTextChanged="TextBox15_TextChanged" AutoPostBack="true" Font-Size="23px"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="true" />
                    <asp:Label ID="Label7" runat="server" Text="请填写备注，没有请填写无" Font-Size="16px" ForeColor="Red" Visible="false" Style="margin-left: 20px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Button ID="Button9" runat="server" Text="增加" Style="margin-left: 80px; font-size: 23px" OnClick="Button9_Click" Height="40px" Width="89px" />
                </td>
                <td>
                    <asp:Button ID="Button13" runat="server" Text="返回" Style="margin-left: 60px; font-size: 23px" OnClick="Button13_Click" Height="36px" Width="94px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
