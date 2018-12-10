<%@ Page Language="C#" AutoEventWireup="True" Inherits="数据恢复" MasterPageFile="~/MasterPage.master" Codebehind="数据恢复.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .restore_bottom_div {
            position:absolute;
            top:350px;
            left:180px;
        }

         .log_top_div_text {
        width:300px;
        height:30px;
        }

         .log_top_div_btn {
            height:38px;
            border-radius:3px;
            width:100px;
        }

         .xinzeng_button11 {
    position: relative;
    top: 40px;
    left: 210px;
    border: 2px solid #8e8585;
    border-radius: 15px;
    height: 50px;
    width: 140px;
    font-size: 15px;
    margin-left: 500px;
    behavior: url(PIE/PIE.htc);
}
    </style>
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <div style="margin-left:400px;margin-top:50px;">
        <asp:TextBox ID="TextBox1" runat="server" CssClass="log_top_div_text" placeholder="请输入管理员账号"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="查询" CssClass="log_top_div_btn" OnClick="Button2_Click" />
    </div>
    <div>
        <asp:Button ID="Button5" runat="server" Text="从所选包恢复" CssClass="xinzeng_button11" OnClick="Button5_Click" />
    </div>
    <div class="restore_bottom_div">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" DataKeyNames="copyId" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" Width="880px" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="Button6" runat="server" Text="删除" Style="background: none; border: none" OnClientClick="return  confirm('您确定要删除吗?');" CommandName="Delete" CausesValidation="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
</asp:Content>

