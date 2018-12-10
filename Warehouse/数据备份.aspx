<%@ Page Language="C#" AutoEventWireup="True" Inherits="数据备份" MasterPageFile="~/MasterPage.master" Codebehind="数据备份.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .copy_bottom_search_div {
            position:absolute;
            top:350px;
            left:180px;
        }
        .copy_bottom_label {
            font-size:20px;
        }
        .copy_bottom_textbox {
            width:300px;
            height:25px;
        }

        .copy_bottom_add_div {
            position:absolute;
            top:350px;
            left:380px;
        }
        .copy_bottom_add_btn {
            margin-left:50px;
            border:1px solid black;
            border-radius:3px;
            width:100px;
            height:30px;
        }
        .copy_bottom_add_lab {
            color:red;
        }

        .copy_top_search_btn {
            width:100px;
            height:35px;
            border-radius:3px;
        }
        .copy_top_search_tex {
            width:200px;
            height:30px;
        }
    </style>
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <div style="top:160px;position:absolute;left:160px;">
        <div style="position:absolute;top:20px;left:280px">
            <asp:TextBox ID="TextBox5" runat="server" CssClass="copy_top_search_tex" placeholder="请输入数据包名字"></asp:TextBox>
            <asp:Button ID="Button9" runat="server" Text="查询" CssClass="copy_top_search_btn" OnClick="Button9_Click" />
        </div>
        <asp:Button ID="Button1" runat="server" Text="导入备份包" CssClass="xinzeng_button8" OnClick="Button1_Click" />
        <asp:Button ID="Button4" runat="server" Text="增加备份" CssClass="xinzeng_button9" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Text="生成完全备份包" CssClass="xinzeng_button10" />
    </div>
    <div class="copy_bottom_search_div" id="search" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" AllowPaging="True" DataKeyNames="copyId" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" Width="895px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand">
            <Columns>
                
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
    <div class="copy_bottom_add_div" id="add" runat="server">
        <table style="margin:0 auto">
            
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="数据包名：" CssClass="copy_bottom_label"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="copy_bottom_textbox" ReadOnly="true"></asp:TextBox>--%>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="" CssClass="copy_bottom_add_lab"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>

            <%--<tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="文件名：" CssClass="copy_bottom_label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="copy_bottom_textbox" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="" CssClass="copy_bottom_add_lab"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="大小(单位KB)：" CssClass="copy_bottom_label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="copy_bottom_textbox" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="" CssClass="copy_bottom_add_lab"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="位置：" CssClass="copy_bottom_label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="copy_bottom_textbox" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="" CssClass="copy_bottom_add_lab"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>--%>
                 <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="类型：" CssClass="copy_bottom_label"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="copy_bottom_textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="" CssClass="copy_bottom_add_lab"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="确定导入" CssClass="copy_bottom_add_btn" OnClick="Button2_Click"/>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="取消导入" CssClass="copy_bottom_add_btn" OnClick="Button3_Click" />
                </td>
            </tr>      
        </table>
    </div>
</asp:Content>

