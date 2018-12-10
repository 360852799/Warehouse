<%@ Page Language="C#" AutoEventWireup="True" Inherits="用户管理" MasterPageFile="~/MasterPage.master" Codebehind="用户管理.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
       
    </style>
    
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <div>
        <div style="position:absolute;top:200px;left:400px">
            <asp:TextBox ID="TextBox10" runat="server" placeholder="请输入用户编号进行查询..." CssClass="usermanage_top_search_tex"></asp:TextBox>
            <asp:Button ID="Button8" runat="server" Text="查询" CssClass="usermanage_top_search_btn" OnClick="Button8_Click1" />
        </div>
        <asp:Button ID="Button1" runat="server" Text="注册管理员" CssClass="usermanage_top_add_btn" OnClick="Button1_Click" />
    </div>
    <div style="position:absolute;top:280px;left:200px; width: 297px;" id="search" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" Width="813px" DataKeyNames="staffNum" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
            <Columns>
                
                <%--<asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:Button ID="Button2" runat="server" Text="重置密码" Style="background: none; border: none" CausesValidation="false" OnClick="Button2_Click" OnClientClick="return  confirm('您确定要重置吗?');"/>
                        <asp:Button ID="Button3" runat="server" Text="编辑" Style="border-style: none; border-color: inherit;background: none; border-width: medium; height: 23px;" CausesValidation="false" OnClick="Button3_Click"/>
                        <asp:Button ID="Button4" runat="server" Text="删除"  Style="background: none; border: none" OnClientClick="return  confirm('您确定要删除吗?');" CommandName="Delete" CausesValidation="true"/>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
            <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
    <div style="position:absolute;top:280px;left:200px; width: 297px;margin-left:200px;" runat="server" id="update">
        <table style="margin:0px auto;align-content:center">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="用户ID：" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="378px" Height="34px" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="编号："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="378px" Height="34px" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="用户名："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="身份证号："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="联系方式："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label26" runat="server" Text="密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Width="378px" Height="34px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label27" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>

                <td colspan="2">
                    <asp:Button ID="Button5" runat="server" Text="确定修改" CssClass="register_btn" OnClick="Button5_Click"/>
                    <asp:Button ID="Button6" runat="server" Text="取消修改" CssClass="register_btn" OnClick="Button6_Click"/>
                </td>                
            </tr>
        </table>
    </div>
    <div style="position:absolute;top:280px;left:150px; width: 600px;margin-left:200px;" runat="server" id="add">
        <table style="margin:0px auto;align-content:center">
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="编号："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label14" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="确认密码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label16" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>                
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label17" runat="server" Text="角色："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="38px" Width="382px">
                        <asp:ListItem>管理员</asp:ListItem>
                        <asp:ListItem>高级管理员</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
           <tr>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="身份证号："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label19" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button7" runat="server" Text="确定注册" CssClass="register_btn" OnClick="Button7_Click" />
                    <asp:Button ID="Button2" runat="server" Text="取消注册" CssClass="register_btn" OnClick="Button2_Click1" />
                </td>
                
            </tr>
        </table>
    </div>

    
</asp:Content>