<%@ Page Language="C#" AutoEventWireup="true" Inherits="未完成出库" MasterPageFile="~/MasterPage.master" Codebehind="未完成出入库.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style>
        .fail_to_out {
            position:absolute;
            top:260px;
            left:200px;
            width: 852px;
        }
        .xinzeng_button {
            position: absolute;
            top: 188px;
            left: 930px;
            border: 1px solid #8e8585;
            border-radius: 5px;
            height: 36px;
            width: 121px;
            font-size: 15px;
            behavior: url(PIE/PIE.htc);
        }

        .fail_to_out_btn {
            position: absolute;
            top: 186px;
            left: 400px;
            border: 1px solid #8e8585;
            border-radius: 5px;
            height: 36px;
            width: 121px;
            font-size: 15px;
        }
        .fail_to_in_btn {
            position: absolute;
            top: 188px;
            left: 200px;
            border: 1px solid #8e8585;
            border-radius: 5px;
            height: 36px;
            width: 121px;
            font-size: 15px;
        }
    </style>
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 126px; position: absolute;"></asp:SiteMapPath>
    <asp:Button ID="Button1" runat="server" Text="新增" CssClass="xinzeng_button" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="未完成出库" CssClass="fail_to_out_btn" OnClick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="未完成入库" CssClass="fail_to_in_btn" OnClick="Button3_Click"  />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="fail_to_out" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
        <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />

    </asp:GridView>

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="fail_to_out" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPreviousFirstLast" NextPageText="下一页" PreviousPageText="上一页" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
        <RowStyle ForeColor="#000066"  HorizontalAlign ="Center"/>
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />

    </asp:GridView>

    <div style="position:absolute;top:280px;left:150px; width: 750px;margin-left:200px;" id="addIn" runat="server" visible="false">
        <table style="margin:0px auto;align-content:center">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="位置编号：" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="物品编号：" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="378px" Height="34px" ></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="预入库量：" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="378px" Height="34px"></asp:TextBox>
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
                    <asp:Label ID="Label7" runat="server" Text="供应商号：" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="378px" Height="34px"></asp:TextBox>
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
                    <asp:Label ID="Label9" runat="server" Text="标注：" Width="100px"></asp:Label>
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
                    <asp:Label ID="Label11" runat="server" Text="入库时间：" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="378px" Height="34px"></asp:TextBox>
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
                <td colspan="2">
                    <asp:Button ID="Button4" runat="server" Text="确定添加" CssClass="register_btn" OnClick="Button4_Click"/>
                    <asp:Button ID="Button5" runat="server" Text="取消添加" CssClass="register_btn" OnClick="Button5_Click"/>
                </td>                
            </tr>
       </table>
    </div>
    <div style="position:absolute;top:280px;left:150px; width: 750px;margin-left:200px;" id="addOut" runat="server">
        <table style="margin:0px auto;align-content:center">
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="入库ID：" Width="100px"></asp:Label>
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
                    <asp:Label ID="Label15" runat="server" Text="物品编号：" Width="100px"></asp:Label>
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
                    <asp:Label ID="Label17" runat="server" Text="预出库量：" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label18" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="收货商编号：" Width="122px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label20" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label21" runat="server" Text="标注：" Width="100px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label22" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label23" runat="server" Text="预出库时间：" Width="125px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server" Width="378px" Height="34px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label24" runat="server" CssClass="register_label" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>               
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button6" runat="server" Text="确定添加" CssClass="register_btn" OnClick="Button6_Click"/>
                    <asp:Button ID="Button7" runat="server" Text="取消添加" CssClass="register_btn" OnClick="Button7_Click"/>
                </td>                
            </tr>
       </table>
    </div>
    
</asp:Content>