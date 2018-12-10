<%@ Page Language="C#" AutoEventWireup="true" Inherits="出库日报" MasterPageFile="~/MasterPage.master" Codebehind="出库日报.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .outoutjournal_bottom_div {
            position:absolute;
            top:280px;
            left:171px;
            width: 926px;
        }
    </style>
    <div style="width: 650px; position: absolute; top: 150px; left: 200px; height: 80px; border: 2px solid #cfcaca;">
        <asp:Label ID="Label1" runat="server" Text="按出库时间" CssClass="lab1_style"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="日期:" CssClass="lab1_style2"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查询" CssClass="button_style2" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="导出" Style="border: 2px solid #8e8585; border-radius: 5px; margin-left: 110px; width: 60px; height: 30px; behavior: url(PIE/PIE.htc);" />
        <asp:Button ID="Button3" runat="server" Text="打印" Style="border: 2px solid #8e8585; border-radius: 5px; margin-left: 10px; width: 60px; height: 30px; behavior: url(PIE/PIE.htc);" />
        <br />
    </div>
    <div id="search" runat="server" class="outoutjournal_bottom_div">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound" Width="918px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
           
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
    
</asp:Content>
