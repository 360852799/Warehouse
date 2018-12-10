<%@ Page Language="C#" AutoEventWireup="true" Inherits="供应商管理" MasterPageFile="~/MasterPage.master" Codebehind="供应商管理.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .Provider_Control_add_top_btn {
            position: absolute;
            top: 188px;
            left: 940px;
            border: 1px solid #8e8585;
            border-radius: 5px;
            height: 36px;
            width: 124px;
            font-size: 15px;
            behavior: url(PIE/PIE.htc);
        }
    </style>
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <div>
        <asp:Label ID="Label1" runat="server" Text="搜索内容:" CssClass="chaxun_lab"></asp:Label>        
        <asp:TextBox ID="TextBox1" runat="server" CssClass="chaxun_tex" placeholder="请输入供货商名称"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查询" CssClass="chaxun_btn" OnClick="Button1_Click1" />
        <asp:Button ID="Button2" runat="server" Text="新增" CssClass="Provider_Control_add_top_btn" OnClick="Button2_Click1" />
    </div>
    <div runat="server" id="add" style="margin-top:150px;padding-top:50px;border-top:2px double #989292;margin-left:147px;">
        <asp:Label ID="Label6" runat="server" Text="请输入信息：" Font-Size="16"></asp:Label>  
        <table style="margin:0px auto;align-content:center">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="供应商名称："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="负责人："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="联系人："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="联系方式："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="地址："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button3" runat="server" Text="确定添加" CssClass="add_btn" OnClick="Button3_Click"/>
                    <asp:Button ID="Button4" runat="server" Text="取消" CssClass="add_btn" OnClick="Button4_Click"/>
                </td>
                
            </tr>
        </table>
    </div>
    <div style="margin-top:150px;padding-top:100px;border-top:2px double #989292;margin-left:147px;padding-left:250px;" runat="server" id="search"> 
           
        <asp:GridView ID="GridView1" CssClass="grid_style" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" AllowPaging="True" CellPadding="3"  DataKeyNames="ProviderName" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowCommand="GridView1_RowCommand">

            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PreviousPageText="上一页" Visible="False" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView> 
        <br />
        <br />   
        <div>
            <span style="margin-left:-230px;position:absolute;top:650px;">
                <asp:Label ID="Label8" runat="server" Text="总记录数"></asp:Label>&nbsp&nbsp&nbsp
                <asp:Label ID="Label9" runat="server" Text="总页数"></asp:Label>
                <asp:Label ID="Label10" runat="server" Text="当前为"></asp:Label>
            </span>
            <span style="margin-left:170px;position:absolute;top:650px;">
                <asp:Button ID="Button7" runat="server" Text="首页" OnClick="Button7_Click" />
                <asp:Button ID="Button8" runat="server" Text="上一页" OnClick="Button8_Click" />
                <asp:Button ID="Button9" runat="server" Text="下一页" OnClick="Button9_Click" />
                <asp:Button ID="Button10" runat="server" Text="尾页" OnClick="Button10_Click" />
            </span>
        </div>
    </div>
    <div>

    </div>
</asp:Content>
