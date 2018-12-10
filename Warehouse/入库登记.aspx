<%@ Page Language="C#" AutoEventWireup="true" CodeFile="入库登记.aspx.cs" Inherits="入库登记" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <asp:Button ID="Button1" runat="server" Text="新增" CssClass="xinzeng_button" />
    <table border="1" style="top: 250px; left: 200px; position: absolute; border-collapse: collapse">
        <tr>
            <td class="font_f1">
                <a>序号</a>
            </td>
            <td class="font_f1">
                <a>编号</a>
            </td>
            <td class="font_f1">
                <a>物品名称</a>
            </td>
            <td class="font_f1">
                <a>物品类别</a>
            </td>
            <td class="font_f1">
                <a>库位编号</a>
            </td>
            <td class="font_f1">
                <a>重量</a>
            </td>
            <td class="font_f1">
                <a>数量</a>
            </td>
            <td class="font_f1">
                <a>属性一</a>
            </td>
            <td class="font_f1">
                <a>属性二</a>
            </td>
            <td class="font_f1">
                <a>入库时间</a>
            </td>
            <td class="font_f1">
                <a>经办人</a>
            </td>
            <td class="font_f2" style="">
                <a style="display: none">按钮</a>
            </td>
        </tr>
        <tr>
            <td class="font_f1">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f2" style="">
                <asp:Button ID="Button2" runat="server" Text="编辑" CssClass="table_button1" />
                <asp:Button ID="Button3" runat="server" Text="删除" CssClass="table_button2" />
            </td>
        </tr>
        <tr>
            <td class="font_f1">
                <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label15" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label17" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label18" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label19" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label20" runat="server" Text=""></asp:Label>
            </td>
            <td class="font_f1">
                <asp:Label ID="Label21" runat="server" Text=""></asp:Label>
            </td>
             <td class="font_f1">
                <asp:Label ID="Label22" runat="server" Text=""></asp:Label>
            </td>
             <td class="font_f1">
                <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
            </td>
            </tr>
    </table>
</asp:Content>
