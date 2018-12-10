<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="部门人员管理.aspx.cs" Inherits="Warehouse.部门人员管理" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="div_kkk" runat="server">
        <a id="A1" runat="server" style="font-size: 20px; top: 135px; left: 150px; position: absolute; width: 50px; color: blue" href="主页.aspx">主页</a>
        <a id="A2" runat="server" style="font-size: 20px; top: 135px; left: 200px; position: absolute; width: 30px">>></a>
        <a id="A3" runat="server" style="font-size: 20px; top: 135px; left: 230px; position: absolute; width: 130px">基础信息管理</a>
        <a id="A4" runat="server" style="font-size: 20px; top: 135px; left: 360px; position: absolute; width: 30px">>></a>
        <a id="A5" runat="server" style="font-size: 20px; top: 135px; left: 390px; position: absolute; width: 130px; color: blue" href="管理库位.aspx">部门人员管理</a>
        <a id="A6" runat="server" style="font-size: 20px; top: 135px; left: 510px; position: absolute; width: 30px"></a>
        <a id="A7" runat="server" style="font-size: 20px; top: 135px; left: 540px; position: absolute; width: 90px"></a>
    </div>
    <div style="position: absolute; left: 240px; top: 210px">
        <asp:Button ID="Button2" runat="server" Text="新增员工" Style="border: 2px solid #8e8585; border-radius: 15px; behavior: url(PIE/PIE.htc); background-color: #e8e6e6; width: 120px; height: 40px; font-size: 16px;" OnClick="Button2_Click" OnInit="Button2_Init" OnCommand="Button2_Command" />
        <asp:Button ID="Button4" runat="server" Text="全删" Style="behavior: url(PIE/PIE.htc); border: none; width: 60px; height: 30px; font-size: 16px; margin-left: 30px" OnClick="Button4_Click" OnClientClick='if (!confirm("确定要删除吗？")) {return false;}' />
        <asp:ListBox ID="ListBox9" runat="server" Rows="1" Style="width: 200px; font-size: 22px; position: absolute; left: 255px; top: 4.5px" AutoPostBack="true" OnSelectedIndexChanged="ListBox9_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>根据员工编号</asp:ListItem>
            <asp:ListItem>根据员工姓名</asp:ListItem>
            <asp:ListItem>根据员工部门</asp:ListItem>
            <asp:ListItem>根据员工出生年月</asp:ListItem>
            <asp:ListItem>根据员工性别</asp:ListItem>
            <asp:ListItem>根据员工身份证号</asp:ListItem>
            <asp:ListItem>根据员工电话</asp:ListItem>
        </asp:ListBox>
        <asp:TextBox ID="TextBox6" runat="server" Style="width: 200px; font-size: 19px; height: 23px; position: absolute; left: 460px; top: 4.5px"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="查询" Style="width: 80px; height: 35px; border: none; position: absolute; left: 680px; top: 1.2px" OnClick="Button1_Click" />
    </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="gridview_1" Width="1200px" RowStyle-Height="40px" AutoGenerateColumns="False" PageSize="2" AllowPaging="True" PagerSettings-Mode="NumericFirstLast" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
        <PagerStyle Font-Names="宋体" Font-Size="20px" HorizontalAlign="Center" />
    </asp:GridView>
    <div style="position: absolute; top: 260px; left: 220px; width: 1000px; height: 600px;" runat="server" id="Div1">
        <asp:ListBox ID="ListBox8" runat="server" Style="position: absolute; top: 31px; left: -28px; width: 200px;font-size:23px" Rows="8"></asp:ListBox>
        <asp:Button ID="Button5" runat="server" Text="获取部门ID" Style="position: absolute; top: 330px; left: 0px; width: 140px;height:40px;font-size:22px" OnClick="Button5_Click" />
        <table style="margin-top: 5px; margin-left: 230px">
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label3" runat="server" Text="员工编号:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Style="width: 237px" ReadOnly="true" Font-Size="19px"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label11" runat="server" Text=" " Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label4" runat="server" Text="员工姓名:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Style="width: 237px" Font-Size="19px" OnTextChanged="TextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label12" runat="server" Text=" " Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label5" runat="server" Text="所在部门:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Style="width: 237px" ReadOnly="true" Font-Size="19px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label13" runat="server" Text=" " Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label6" runat="server" Text="出生年月:" Font-Size="22px"> </asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="ListBox2" runat="server" Rows="1" Width="90px" Font-Size="20px" AutoPostBack="true" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" ></asp:ListBox>
                    <asp:ListBox ID="ListBox3" runat="server" Rows="1" Width="72px" Font-Size="20px" AutoPostBack="true" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged"></asp:ListBox>
                    <asp:ListBox ID="ListBox4" runat="server" Rows="1" Width="72px" Font-Size="20px"></asp:ListBox>
                    <asp:Image ID="Image4" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label14" runat="server" Text=" " Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label7" runat="server" Text="性别:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="ListBox7" runat="server" Rows="1" Width="80px" Font-Size="19px">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:ListBox>
                    <asp:Image ID="Image5" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label15" runat="server" Text="" Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label8" runat="server" Text="籍贯:" Font-Size="22px" ></asp:Label>
                </td>
                <td>
                    <asp:ListBox ID="ListBox5" runat="server" Rows="1" Width="100px" Font-Size="19px" OnSelectedIndexChanged="ListBox5_SelectedIndexChanged" AutoPostBack="true" ></asp:ListBox>
                    <asp:ListBox ID="ListBox6" runat="server" Rows="1" Width="138px" Font-Size="19px" style="position:absolute;left:489px;top:303px" OnSelectedIndexChanged="ListBox6_SelectedIndexChanged" OnTextChanged="ListBox6_TextChanged"></asp:ListBox>
                    <asp:TextBox ID="TextBox4" runat="server" Rows="1" Font-Size="18px" Visible="false" style="position:absolute;left:489px;top:302px" ReadOnly="true"></asp:TextBox>
                    <%--<asp:TextBox ID="TextBox4" runat="server" Font-Size="19px" Width="100px" style="position:absolute;left:678px;top:301px" placeholder="搜索框"></asp:TextBox>--%>
                    <asp:Image ID="Image6" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label16" runat="server" Text=" " Font-Size="16px" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label9" runat="server" Text="身份证号:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Style="width: 237px" Font-Size="19px" AutoPostBack="true" OnTextChanged="TextBox7_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image7" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label17" runat="server" Text="" Font-Size="16px" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Label ID="Label10" runat="server" Text="联系方式:" Font-Size="22px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server" Style="width: 237px" Font-Size="19px" AutoPostBack="true" OnTextChanged="TextBox8_TextChanged"></asp:TextBox>
                    <asp:Image ID="Image8" runat="server" Height="20px" Width="20px" ImageUrl="~/Image/对号.png" Style="margin-left: 20px" Visible="false" />
                    <asp:Label ID="Label18" runat="server" Text="" Font-Size="16px" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr style="line-height: 50px">
                <td>
                    <asp:Button ID="Button9" runat="server" Text="增加" Style="margin-left: 60px; font-size: 20px" OnClick="Button9_Click" OnInit="Button9_Init" Height="50px" Width="87px" />
                </td>
                <td>
                    <asp:Button ID="Button13" runat="server" Text="返回" Style="margin-left: 80px; font-size: 20px" OnClick="Button13_Click" Height="50px" Width="87px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
