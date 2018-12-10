<%@ Page Language="C#" AutoEventWireup="true" Inherits="物资盘点" MasterPageFile="~/MasterPage.master" Codebehind="物资盘点.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .WareCount_search_btn {
            position: relative;
            top: 0px;
            left: 20px;
            border: 2px solid #8e8585;
            border-radius: 8px;
            height: 30px;
            width: 80px;
            font-size: 15px;
            margin-left: 30px;
            behavior: url(PIE/PIE.htc);
        }
    </style>
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <div style="position:absolute;top:160px;left:150px;border:1px ridge;width:700px;height:57px;">
        <asp:Label ID="Label1" runat="server" Text="按入库时间:" CssClass="lab1_lab_style"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="从" style="margin-left:60px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="div_textbox"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="到"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="div_textbox"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="查询" CssClass="WareCount_search_btn" OnClick="Button2_Click" />
    </div>
    <div style="position:absolute;top:230px;left:150px;border:1px ridge;width:700px;height:155px;">
        <asp:Label ID="Label4" runat="server" Text="按名称:" CssClass="lab1_lab_style"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <asp:Label ID="Label5" runat="server" Text="类别一" style="margin-left:60px"></asp:Label>
                <asp:ListBox ID="ListBox3" runat="server" CssClass="div_textbox" Rows="1" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                <asp:Label ID="Label6" runat="server" Text="类别二" style="margin-left:80px"></asp:Label>
                <asp:ListBox ID="ListBox4" runat="server" CssClass="div_textbox" Rows="1" OnSelectedIndexChanged="ListBox4_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="类别三" style="margin-left:60px"></asp:Label>
                <asp:ListBox ID="ListBox1" runat="server" CssClass="div_textbox" Rows="1" AutoPostBack="True"></asp:ListBox>
                <asp:Label ID="Label8" runat="server" Text="按名称" style="margin-left:80px"></asp:Label>
                <asp:ListBox ID="ListBox2" runat="server" CssClass="div_textbox" Rows="1" AutoPostBack="True"></asp:ListBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:Button ID="Button1" runat="server" Text="盘点" CssClass="xinzeng_button4" OnClick="Button1_Click" />
    <div style="position:absolute;left:200px;top:400px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="654px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066" HorizontalAlign ="Center" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

        <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="False" Width="654px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066" HorizontalAlign ="Center" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

    </div>
    
</asp:Content>
