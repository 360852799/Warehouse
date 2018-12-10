<%@ Page Language="C#" AutoEventWireup="True" Inherits="在库汇总" MasterPageFile="~/MasterPage.master" Codebehind="出入库汇总.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <style type="text/css">
        .inout_count_center_div {
            position:relative;
            top:360px;
            left:50px;
        }
        .inout_count_bottom_div {
            position:relative;
            top:400px;
            left:100px;
        }
        .div_div_div_style {
            border:2px ridge #c2bebe;
            left: 150px;
            top: 190px;
            position: absolute;
            width: 900px;
            height: 230px;
            
        }
        .button_style2 {
            border: 2px solid #8e8585;
            border-radius: 5px;
            margin-left: 10px;
            width: 60px;
            height: 30px;
            behavior: url(PIE/PIE.htc);
        }
        .button_style4 {
            border: 2px solid #8e8585;
            border-radius: 5px;
            margin-left: 70px;
            width: 110px;
            height: 30px;
            behavior: url(PIE/PIE.htc);
        }
        .button_style5 {
            border: 2px solid #8e8585;
            border-radius: 5px;
            margin-left: 70px;
            width: 80px;
            height: 30px;
            margin-left: 50px;
            behavior: url(PIE/PIE.htc);
        }
    </style>
    <div class="div_div_div_style">
        <br />
        <asp:Label ID="Label1" runat="server" Text="按入库时间:" CssClass="lab1_lab_style"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="从"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="div_textbox"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="到"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="div_textbox"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="按出库时间:" CssClass="lab1_lab_style"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="从"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="div_textbox"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="到"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="div_textbox"></asp:TextBox>
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label7" runat="server" Text="且物品类别:" CssClass="lab1_lab_style"></asp:Label>
                <asp:ListBox ID="ListBox1" runat="server" CssClass="div_textbox1" Rows="1" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
                <asp:Label ID="Label8" runat="server" Text="→→"></asp:Label>
                <asp:ListBox ID="ListBox2" runat="server" CssClass="div_textbox1" Rows="1" AutoPostBack="True" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
                <asp:Label ID="Label9" runat="server" Text="→→"></asp:Label>
                <asp:ListBox ID="ListBox3" runat="server" CssClass="div_textbox1" Rows="1"></asp:ListBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:Label ID="Label10" runat="server" Text="且库柜:" CssClass="lab1_lab_style"></asp:Label>
        <asp:ListBox ID="ListBox4" runat="server" CssClass="div_textbox1" Rows="1"></asp:ListBox>
        <asp:Label ID="Label11" runat="server" Text="且经办人:" CssClass="lab1_lab_style"></asp:Label>
        <asp:ListBox ID="ListBox5" runat="server" CssClass="div_textbox1" Rows="1"></asp:ListBox>
        <br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="且供应商:" CssClass="lab1_lab_style"></asp:Label>
        <asp:ListBox ID="ListBox6" runat="server" CssClass="div_textbox1" Rows="1"></asp:ListBox>
        
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="重置" CssClass="button_style5" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="查询" CssClass="button_style2" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="在结果在查找" CssClass="button_style4" OnClick="Button3_Click" />
        <br />
        <br />
    </div>
    <div class="div_div_div_style2">
        <asp:Button ID="Button4" runat="server" Text="所有入库" CssClass="button_style8" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="所有出库" CssClass="button_style9" OnClick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="导出" CssClass="button_style10" />
        <asp:Button ID="Button7" runat="server" Text="打印" CssClass="button_style11" />
    </div>
    <div class="inout_count_center_div" id="receive" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"  Width="841px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" EnableModelValidation="False"  >
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
    <div class="inout_count_center_div" id="provide" runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"  Width="841px" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound"  >
            
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
    <%--<div class="inout_count_bottom_div">
        <asp:Label ID="Label65" runat="server" Text="总量:" ></asp:Label>&nbsp&nbsp&nbsp
        <asp:Label ID="Label66" runat="server" Text="xx" ></asp:Label>&nbsp&nbsp&nbsp
        <asp:Label ID="Label67" runat="server" Text="xx" ></asp:Label>
    </div>--%>
</asp:Content>

