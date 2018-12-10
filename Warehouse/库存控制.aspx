<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="库存控制.aspx.cs" Inherits="Warehouse.库存控制" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_1_2" Width="1000px" RowStyle-Height="40px" Visible="true" AutoGenerateColumns="False" PageSize="10" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server" CssClass="gridview_1_3" Width="1000px" RowStyle-Height="40px" Visible="true" AutoGenerateColumns="False" PageSize="10" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
</asp:Content>

