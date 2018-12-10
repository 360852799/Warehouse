<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="登记入库.aspx.cs" Inherits="Warehouse.登记入库" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style>
        input::-webkit-input-placeholder { /* WebKit browsers */
            font-size: 15px;
            color: black;
        }

        input:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
            font-size: 15px;
            color: black;
        }

        input::-moz-placeholder { /* Mozilla Firefox 19+ */
            font-size: 15px;
            color: black;
        }

        input:-ms-input-placeholder { /* Internet Explorer 10+ */
            font-size: 15px;
            color: black;
        }
    </style>
   <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Size="22px"></asp:SiteMapPath>
    <div runat="server" id="ideas" style="height: 180px; width: 300px; background-color: #e3dbe3; border: 1px solid #000; position: absolute; left: 500px; top: 380px; display: none; z-index: 5">
        <div style="height: 100px; width: 300px; background-color: white;">
            <asp:Label ID="Label100" runat="server" Text="确定要删除吗？" Style="line-height: 80px; font-size: 22px; margin-left: 73px"></asp:Label>
        </div>
        <div style="height: 50px; width: 300px; background-color: white; margin-top: 20px; background-color: #e3dbe3;">
            <asp:Button ID="Button200" runat="server" Text="确认" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 60px; border: 1px solid #1377f0" OnClick="Button200_Click" />
            <asp:Button ID="Button300" runat="server" Text="取消" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 30px" OnClick="Button300_Click" />
        </div>
    </div>
    <div style="position: absolute; left: 240px; top: 210px">
        <asp:Button ID="Button1" runat="server" Text="新增入库" Style="border: 2px solid #8e8585; border-radius: 15px; behavior: url(PIE/PIE.htc); background-color: #e8e6e6; width: 120px; height: 40px; font-size: 16px;" OnClick="Button1_Click" />
        <asp:Button ID="Button4" runat="server" Text="全删" Style="behavior: url(PIE/PIE.htc); border: none; width: 60px; height: 30px; font-size: 16px; margin-left: 30px" OnClientClick='if (!confirm("确定要删除吗？")) {return false;}' OnClick="Button4_Click" />
        <asp:ListBox ID="ListBox11" runat="server" Rows="1" Style="width: 200px; font-size: 22px; position: absolute; left: 255px; top: 4.5px" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>根据出库编号</asp:ListItem>
            <asp:ListItem>根据库位编号</asp:ListItem>
            <asp:ListItem>根据物品编号</asp:ListItem>
            <asp:ListItem>根据批次编号</asp:ListItem>
            <asp:ListItem>根据经办人</asp:ListItem>
        </asp:ListBox>
        <asp:TextBox ID="TextBox1" runat="server" Style="width: 200px; font-size: 19px; height: 23px; position: absolute; left: 460px; top: 5.45px"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" Text="查询" Style="width: 80px; height: 35px; border: none; position: absolute; left: 680px; top: 1.2px" OnClick="Button5_Click" />
    </div>
    <div style="position: absolute; top: 240px; left: 200px; width: 1000px; height: 700px;" runat="server" id="Div1">
        <asp:ListBox ID="ListBox5" runat="server" Rows="6" Style="position: absolute; left: 60px; top: 50px; width: 180px; font-size: 19px"></asp:ListBox>
        <asp:Button ID="Button9" runat="server" Text="获取库位" Style="position: absolute; left: 90px; top: 230px; height: 41px; width: 128px; font-size: 19px" OnClick="Button9_Click" />
        <table style="margin-left: 300px">
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label9" runat="server" Text="入库编号:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Style="width: 180px" Font-Size="19px" ReadOnly="true" placeholder="请先选择类型编号" OnTextChanged="TextBox11_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label10" runat="server" Text="物品编号:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server" Style="width: 180px" Font-Size="19px" Text="" AutoPostBack="true" OnTextChanged="TextBox12_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label17" runat="server" Text="库位编号:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server" Style="width: 180px" Font-Size="19px" ReadOnly="true"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label1" runat="server" Text="单位体积:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Style="width: 180px" placeholder="每单位物品的体积   m³" Font-Size="19px" Text="" AutoPostBack="true" OnTextChanged="TextBox7_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image9" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label18" runat="server" Text="入库量:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Style="width: 180px; height: 25px;" Font-Size="19px" Text="" AutoPostBack="true" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label19" runat="server" Text="批次编号:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Style="width: 180px" Font-Size="19px" ReadOnly="true" Text="" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label20" runat="server" Text="日期:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Style="width: 180px" Font-Size="19px" Text="" ReadOnly="true" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label21" runat="server" Text="经办人:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Style="width: 180px" Font-Size="19px" Text="" AutoPostBack="true" OnTextChanged="TextBox13_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image7" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label12" runat="server" Text="备注:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Style="width: 180px" Font-Size="19px" Text="无" AutoPostBack="true" OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image8" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Button ID="Button66" runat="server" Text="增加" Style="margin-left: 30px" TabIndex="1" Font-Size="19px" Height="34px" Width="69px" OnClick="Button66_Click" />
                </td>
                <td>
                    <asp:Button ID="Button77" runat="server" Text="取消" Style="margin-left: 40px" TabIndex="1" Font-Size="19px" Height="34px" Width="69px" OnClick="Button77_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_2m" Width="1200px" RowStyle-Height="40px" AutoGenerateColumns="False" PageSize="2" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
</asp:Content>
