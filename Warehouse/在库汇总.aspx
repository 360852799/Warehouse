<%@ Page Language="C#" AutoEventWireup="true" Inherits="出入库汇总" MasterPageFile="~/MasterPage.master" Codebehind="在库汇总.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <style type="text/css">
        .house_count_center_div {
            position:relative;
            top:300px;
            left:50px;
        }
        .house_count_bottom_div {
            position:relative;
            top:400px;
            left:350px;
        }
        .div_div_div_style {
            border: 2px ridge;
            left: 150px;
            top: 190px;
            position: absolute;
            width: 900px;
            height: 230px;
            
        }
        .button_style5 {
            border-radius: 5px;
            margin-left: 20px;
            width: 80px;
            height: 30px;
            border-radius: 5px;
            border: 2px solid #8e8585;
            behavior: url(PIE/PIE.htc);
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
    </style>
    <div class="div_div_div_style">
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>       
                <asp:Label ID="Label7" runat="server" Text="且物品类别:" CssClass="lab1_lab_style"></asp:Label>
                <asp:ListBox ID="ListBox1" runat="server" CssClass="div_textbox1" Rows="1" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:ListBox>
                <asp:Label ID="Label8" runat="server" Text="→→"></asp:Label>
                <asp:ListBox ID="ListBox2" runat="server" CssClass="div_textbox1" Rows="1" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged" AutoPostBack="True">
                </asp:ListBox>
                <asp:Label ID="Label9" runat="server" Text="→→"></asp:Label>
                <asp:ListBox ID="ListBox3" runat="server" CssClass="div_textbox1" Rows="1" AutoPostBack="True">
                </asp:ListBox>

            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="且物品:" CssClass="lab1_lab_style"></asp:Label>
        <%--<asp:ListBox ID="ListBox4" runat="server" CssClass="div_textbox1" Rows="1">
            <asp:ListItem Selected="True"></asp:ListItem>
        </asp:ListBox>--%>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="163px"></asp:DropDownList>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="重置" CssClass="button_style5" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="查询" CssClass="button_style2" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="在结果中查找" CssClass="button_style4" OnClick="Button3_Click" />
        <br />
        <br />
    </div>
    <div class="house_count_center_div">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"  Width="841px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>

    </div>
    <%--<div class="house_count_bottom_div">
        <asp:Label ID="Label65" runat="server" Text="总量:" ></asp:Label>&nbsp&nbsp
        <asp:Label ID="Label66" runat="server" Text="xx" ></asp:Label>&nbsp&nbsp
        <asp:Label ID="Label67" runat="server" Text="xx" ></asp:Label>

    </div>--%>
</asp:Content>
