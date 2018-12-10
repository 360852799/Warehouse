<%@ Page Language="C#" AutoEventWireup="True" Inherits="系统日志" MasterPageFile="~/MasterPage.master" Codebehind="系统日志.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
.log_top_div_text {
    width:300px;
    height:30px;
}

.log_top_div_btn {
    height:38px;
    border-radius:3px;
    width:100px;
}

.log_bottom_div {
    position:absolute;
    top:300px;
    left:160px;
}

.log_top_div_daochu_btn {
    border-radius:3px;
    width:100px;
    height:40px;
    position: relative;
    top: 20px;
    left: 30px;
    font-size: 15px;
    margin-left: 30px;
    behavior: url(PIE/PIE.htc);
}
    </style>
    <div class="log_top_div">
        <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
        <div style="margin-left:400px;margin-top:50px;">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="log_top_div_text" placeholder="请输入用户账号"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="查询" CssClass="log_top_div_btn" OnClick="Button2_Click" />
        </div>
        <asp:Button ID="Button1" runat="server" Text="导出" CssClass="log_top_div_daochu_btn" />
        <asp:Button ID="Button4" runat="server" Text="清除日志" CssClass="log_top_div_daochu_btn" OnClick="Button4_Click"  OnClientClick="return  confirm('您确定要清除吗?');"/>
    </div>
    <div class="log_bottom_div">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="905px" OnPageIndexChanging="GridView1_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </div>
</asp:Content>


