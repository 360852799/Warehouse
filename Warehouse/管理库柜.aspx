<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="管理库柜.aspx.cs" Inherits="Warehouse.库柜管理" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" Font-Size="22px"></asp:SiteMapPath>
     <div style="position: absolute; left: 240px; top: 210px">
        <asp:Button ID="Button5" runat="server" Text="新增库柜" Style="border: 2px solid #8e8585; border-radius: 15px; behavior: url(PIE/PIE.htc); background-color: #e8e6e6; width: 120px; height: 40px; font-size: 16px;" OnClick="Button5_Click" OnInit="Button5_Init" />
        <asp:Button ID="Button4" runat="server" Text="全删" Style="behavior: url(PIE/PIE.htc); border: none; width: 60px; height: 30px; font-size: 16px; margin-left: 30px" OnClick="Button4_Click" OnClientClick='if (!confirm("确定要删除吗？")) {return false;}' />
         <asp:ListBox ID="ListBox1" runat="server" Rows="1" Style="width: 200px; font-size: 22px; position: absolute; left: 255px; top: 4.5px" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" OnTextChanged="ListBox1_TextChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>根据库柜编号</asp:ListItem>
            <asp:ListItem>根据库柜名称</asp:ListItem>
            <asp:ListItem>根据备注要求</asp:ListItem>
        </asp:ListBox>
         <asp:TextBox ID="TextBox1" runat="server" Style="width: 200px; font-size: 19px; height: 23px; position: absolute; left: 460px; top: 4.5px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查询" Style="width: 80px; height: 35px; border: none; position: absolute; left: 680px; top: 1.2px" OnClick="Button1_Click" />
    </div>
     <div runat="server" id="ideas" style="height: 180px; width: 300px; background-color: #e3dbe3; border: 1px solid #000; position: absolute; left: 500px; top: 380px; display: none;z-index:5">
        <div style="height: 100px; width: 300px; background-color: white;">
            <asp:Label ID="Label100" runat="server" Text="确定要删除吗？" Style="line-height: 80px; font-size: 22px; margin-left: 73px"></asp:Label>
        </div>
        <div style="height: 50px; width: 300px; background-color: white; margin-top: 20px; background-color: #e3dbe3;">
            <asp:Button ID="Button200" runat="server" Text="确认" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 60px; border: 1px solid #1377f0" OnClick="Button200_Click" />
            <asp:Button ID="Button300" runat="server" Text="取消" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 30px" OnClick="Button300_Click" />
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_1" Width="800px" RowStyle-Height="40px" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
   <div style="position: absolute; width:1000px; height: 600px; left: 200px; top: 250px; z-index: 1;background-color:#e8e6e6" runat="server" id="Div1">
        <table style="margin-top: 30px; margin-left: 260px">
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label2" runat="server" Text="房间编号:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="TextBox13" runat="server" Style="width: 180px" OnTextChanged="TextBox13_TextChanged" AutoPostBack="true" placeholder="左侧选择房间" ReadOnly="true" Font-Size="23px" MaxLength="3"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height:50px">
                <td>
                    <asp:Label ID="Label10" runat="server" Text="库柜编号:" Font-Size="23px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px" OnTextChanged="TextBox10_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label12" runat="server" Text="库柜名称:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Style="width: 180px" Font-Size="23px" OnTextChanged="TextBox11_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label3" runat="server" Text="您的库柜名称输入不合理,请重新输入" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label5" runat="server" Text="可放面积:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server" Style="width: 180px" AutoPostBack="true" Font-Size="23px"  OnTextChanged="TextBox333_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label1" runat="server" Text="您的面积输入不合理,请输入一个非负数" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label4" runat="server" Text="高度:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Style="width: 180px" AutoPostBack="true" Font-Size="23px"  OnTextChanged="TextBox334_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label7" runat="server" Text="您的高度输入不合理,请输入一个非负数" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label14" runat="server" Text="备注:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox14" runat="server" Text="无要求" Style="width: 180px" OnTextChanged="TextBox14_TextChanged" AutoPostBack="true" Font-Size="23px" ></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" style="margin-left:20px" Visible="true" />
                    <asp:Label ID="Label6" runat="server" Text="请填写备注，没有请填写无" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label15" runat="server" Text="创建时间:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px"></asp:TextBox>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label16" runat="server" Text="更新时间:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox16" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Button ID="Button9" runat="server" Text="增加" Style="margin-left: 80px;font-size:23px" OnClick="Button9_Click" Height="40px" Width="89px" />
                </td>
                <td>
                    <asp:Button ID="Button13" runat="server" Text="返回" Style="margin-left: 60px;font-size:23px" OnClick="Button13_Click" Height="36px" Width="94px" />
                </td>
            </tr>
        </table>
       <asp:Button ID="Button2" runat="server" Text="新增房间" style="position:absolute;top:43px; left:78px; height:40px;width:105px;font-size:23px;color:blue;border:1px solid #fff;border-radius:15px" OnClick="Button2_Click" /> 
       <asp:ListBox ID="ListBox2" runat="server" Rows="6" Style="position: absolute; left: 37px; top: 97px; width: 185px; height: 214px; font-size:23px" AutoPostBack="true" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
        <asp:Button ID="Button6" runat="server" Text="获取房间编号" Style="position: absolute; left: 58px; top: 340px; width: 137px; height:40px;font-size:21px" OnClick="Button6_Click" OnInit="Button6_Init" />
    </div>
</asp:Content>


