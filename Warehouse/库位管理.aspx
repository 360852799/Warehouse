<%@ Page Language="C#" AutoEventWireup="true" Inherits="库位管理" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" Codebehind="库位管理.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Style="font-size: 20px; top: 135px; position: absolute;"></asp:SiteMapPath>
    <asp:Button ID="Button1" runat="server" Text="新增库位" Style="position: relative; top: 69px; left: 40px; border: 2px solid #8e8585; border-radius: 15px; height: 36px; width: 121px; font-size: 15px; margin-left: 30px; behavior: url(PIE/PIE.htc);"
        OnClick="Button1_Click" OnInit="Button1_Init"  />
    <div style="position: absolute; top: 230px; left: 340px; width: 300px; height: 220px; background-color: red; background-image: url(Image/蓝天.jpg);" runat="server" id="departmentCreate" >
        <table style="margin-top: 30px; margin-left: 30px">
            <tr style="line-height: 30px">
                <td>
                    <asp:Label ID="Label3" runat="server" Text="库位编号:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Style="width: 120px"></asp:TextBox>
                </td>
            </tr>
            <tr style="line-height: 30px">
                <td>
                    <asp:Label ID="Label4" runat="server" Text="库柜编号:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Style="width: 120px"></asp:TextBox>
                </td>
            </tr>
            <tr style="line-height: 30px">
                <td>
                    <asp:Label ID="Label5" runat="server" Text="房间编号:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Style="width: 120px"></asp:TextBox>
                </td>
            </tr>
            <tr style="line-height: 30px">
                <td>
                    <asp:Label ID="Label2" runat="server" Text="可存物品种类:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Style="width: 120px"></asp:TextBox>
                </td>
            </tr>
            <tr style="line-height: 30px">
                <td>
                    <asp:Label ID="Label6" runat="server" Text="备注:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Style="width: 120px"></asp:TextBox>
                </td>
            </tr>
            <tr style="line-height: 30px">
                <td>
                    <asp:Button ID="Button6" runat="server" Text="增加" Style="margin-left: 30px" OnClick="Button6_Click" />
                </td>
                <td>
                    <asp:Button ID="Button7" runat="server" Text="取消" Style="margin-left: 40px" OnClick="Button7_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:ListBox ID="ListBox1" runat="server" Style="position: absolute; top: 235px; left: 360px; width: 120px;" Rows="1">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>根据部门ID</asp:ListItem>
        <asp:ListItem>根据部门名称</asp:ListItem>
        <asp:ListItem>根据上级部门</asp:ListItem>
        <asp:ListItem>根据负责人</asp:ListItem>
    </asp:ListBox>
    <asp:TextBox ID="TextBox6" runat="server" Style="position: absolute; top: 235px; left: 490px; width: 100px;"></asp:TextBox>
    <asp:Button ID="Button10" runat="server" Text="查询" Style="position: absolute; top: 235px; left: 630px; width: 40px; border: none" OnClick="Button10_Click" />
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_1" Width="500px" RowStyle-Height="40px" AutoGenerateColumns="False" PageSize="10" EnableModelValidation="True" PagerSettings-Visible="false" AllowPaging="True"  DataKeyNames="departId" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  >
        <Columns>
            <asp:BoundField DataField="positionNum" HeaderText="库位编号" ReadOnly="True" SortExpression="positionNum" HeaderStyle-Height="40px" />
            <asp:BoundField DataField="chestNum" HeaderText="库柜编号" SortExpression="chestNum" />
            <asp:BoundField DataField="roomNum" HeaderText="房间编号" SortExpression="roomNum" />
            <asp:BoundField DataField="goodsTypes" HeaderText="物品种类" SortExpression="goodsTypes" />
            <asp:BoundField DataField="remark " HeaderText="备注" SortExpression="remark" />
            <asp:TemplateField HeaderText=" " ControlStyle-Width="50px">
                <ItemTemplate>
                    <asp:Button ID="Button11" runat="server" Text="编辑"  Style="background: none; border: none"   CommandName="editt" OnClick="Button20_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" " ControlStyle-Width="50px">
                <ItemTemplate>
                    <asp:Button ID="Button12" runat="server" Text="删除" Style="background: none; border: none"  CommandName="deletee" OnClick="Button30_Click"  OnClientClick='if (!confirm("确定要删除吗？")) {return false;}'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="第1页" Style="position: absolute; top: 530px; left: 200px; font-size: 20px"></asp:Label>
    <asp:Label ID="Label11" runat="server" Text="共页" Style="position: absolute; top: 530px; left: 260px; font-size: 20px"></asp:Label>
    <asp:Button ID="Button2"  runat="server" Text="上一页" Style="position: absolute; top: 533px; left: 320px; border: none; background: none; height: 23px; " OnClick="Button2_Click"   />
    <asp:Button ID="Button3" runat="server"  Text="下一页" Style="border-style: none; border-color: inherit; border-width: medium; position: absolute; top: 531px; left: 380px; background: none; height: 23px;" OnClick="Button3_Click" />
    <asp:Button ID="Button4" runat="server" Text="全删" Style="border-style: none; border-width: medium; position: absolute; top: 533px; left: 610px; height: 23px;" OnClick="Button4_Click" />
</asp:Content>