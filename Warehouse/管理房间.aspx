<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="管理房间.aspx.cs" Inherits="Warehouse.管理房间" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server" >
    <div id="div_kkk">
        <a id="A1" runat="server" style="font-size: 20px; top: 135px; left: 150px; position: absolute; width: 50px; color: blue" href="主页.aspx">主页</a>
        <a id="A2" runat="server" style="font-size: 20px; top: 135px; left: 200px; position: absolute; width: 30px">>></a>
        <a id="A3" runat="server" style="font-size: 20px; top: 135px; left: 230px; position: absolute; width: 130px">基础信息管理</a>
        <a id="A4" runat="server" style="font-size: 20px; top: 135px; left: 360px; position: absolute; width: 30px">>></a>
        <a id="A5" runat="server" style="font-size: 20px; top: 135px; left: 390px; position: absolute; width: 90px; color: blue" href="管理库位.aspx">房间管理</a>
        <a id="A6" runat="server" style="font-size: 20px; top: 135px; left: 480px; position: absolute; width: 30px"></a>
        <a id="A7" runat="server" style="font-size: 20px; top: 135px; left: 510px; position: absolute; width: 90px"></a>
    </div>
    <div style="position: absolute; left: 240px; top: 210px">
        <asp:Button ID="Button5" runat="server" Text="新增房间" Style="border: 2px solid #8e8585; border-radius: 15px; behavior: url(PIE/PIE.htc); background-color: #e8e6e6; width: 120px; height: 40px; font-size: 16px;" OnClick="Button5_Click" OnInit="Button5_Init" />
        <asp:Button ID="Button4" runat="server" Text="全删" Style="behavior: url(PIE/PIE.htc); border: none; width: 60px; height: 30px; font-size: 16px; margin-left: 30px" OnClick="Button4_Click" OnClientClick='if (!confirm("确定要删除吗？")) {return false;}' />
        <asp:ListBox ID="ListBox1" runat="server" Rows="1" Style="width: 200px; font-size: 22px; position: absolute; left: 255px; top: 4.3px" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>根据房间编号</asp:ListItem>
            <asp:ListItem>根据房间名称</asp:ListItem>
            <asp:ListItem>根据备注要求</asp:ListItem>
        </asp:ListBox>
        <asp:TextBox ID="TextBox1" runat="server" Style="width: 200px; font-size: 19px; height: 23px; position: absolute; left: 460px; top: 4.5px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查询" Style="width: 80px; height: 35px; border: none; position: absolute; left: 680px; top: 1.2px" OnClick="Button1_Click" />
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_1" Width="800px" RowStyle-Height="40px" AutoGenerateColumns="False" PageSize="2" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
    <div runat="server" id="ideas" style="height: 180px; width: 300px; background-color: #e3dbe3; border: 1px solid #000; position: absolute; left: 500px; top: 380px; display: none ">
        <div style="height: 100px; width: 300px; background-color: white;">
            <asp:Label ID="Label100" runat="server" Text="确定要删除吗？" Style="line-height: 80px; font-size: 22px; margin-left: 73px"></asp:Label>
        </div>
        <div style="height: 50px; width: 300px; background-color: white; margin-top: 20px; background-color: #e3dbe3;">
            <asp:Button ID="Button200" runat="server" Text="确认" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 60px; border: 1px solid #1377f0" OnClick="Button200_Click" />
            <asp:Button ID="Button300" runat="server" Text="取消" Style="font-size: 22px; width: 80px; height: 40px; margin-left: 30px" OnClick="Button300_Click" />
        </div>
    </div>
    <div style="position: absolute; width: 750px; height: 600px; left: 250px; top: 250px; z-index: 1;background-color:#e8e6e6" runat="server" id="Div1">
        <table style="position: absolute; left: 88px; top: 68px">
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label10" runat="server" Text="房间编号:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label1" runat="server" Text=" " Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label12" runat="server" Text="房间名称:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Style="width: 180px" Font-Size="23px" OnTextChanged="TextBox11_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label2" runat="server" Text="您的房间名称输入不合理,请重新输入" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
             <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label5" runat="server" Text="可放面积:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox12" runat="server" Style="width: 180px" AutoPostBack="true" Font-Size="23px"  OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label3" runat="server" Text="您的面积输入不合理,请输入一个非负数" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label6" runat="server" Text="高度:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Style="width: 180px" AutoPostBack="true" Font-Size="23px"  OnTextChanged="TextBox22_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label7" runat="server" Text="您的高度输入不合理,请输入一个非负数" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label14" runat="server" Text="备注:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox13" runat="server" Text="无要求" Style="width: 180px" OnTextChanged="TextBox13_TextChanged" AutoPostBack="true" Font-Size="23px" ></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" style="margin-left:20px" Visible="false" />
                    <asp:Label ID="Label4" runat="server" Text="请填写备注，没有请填写无" Font-Size="16px" ForeColor="Red" Visible="false" style="margin-left:20px"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label15" runat="server" Text="创建时间:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox14" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px"></asp:TextBox>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label16" runat="server" Text="更新时间:" Font-Size="24px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox15" runat="server" Style="width: 180px" ReadOnly="true" Font-Size="23px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Button ID="Button9" runat="server" Text="增加" Style="margin-left: 30px;width:70px;height:40px;font-size:20px" OnClick="Button9_Click" OnInit="Button9_Init" />
                </td>
                <td>
                    <asp:Button ID="Button13" runat="server" Text="返回" Style="margin-left: 50px;width:70px;height:40px;font-size:20px" OnClick="Button13_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

