<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="图形化显示.aspx.cs" Inherits="Warehouse.图形化显示" MasterPageFile="~/MasterPage.master"%>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="柱形图" style="margin-left:60px;margin-top:40px;height:30px;width:90px;border-radius:5px;border: 2px solid #8e8585;behavior: url(PIE/PIE.htc);" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="饼状图" style="margin-left:60px;margin-top:40px;height:30px;width:90px;border-radius:5px;border: 2px solid #8e8585;behavior: url(PIE/PIE.htc);" OnClick="Button2_Click" />
        <br />
    </div>
    <div style="position:absolute;left:200px;top:260px;" id="zhu" runat="server">
        <asp:Chart ID="Chart1" runat="server">
            <Legends>
                 <asp:Legend Name="Legend1" >
                  </asp:Legend>
                  </Legends>
                  <Series>    
                  </Series>
                  <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                <AxisX>
	                <MajorTickMark Enabled="False" LineColor="White" LineDashStyle="NotSet" />
	                <MajorGrid Enabled="false" />
	                <MinorTickMark LineColor="White" />
                </AxisX>
                <AxisY>
	                <MajorTickMark LineColor="White" />
	                <MajorGrid Enabled="False" />
	                <MinorTickMark LineColor="White" />
                </AxisY>
                </asp:ChartArea>
                </ChartAreas>
                <Titles>
	                <asp:Title Name="Title1">
	                </asp:Title>
                </Titles>
        </asp:Chart>
    </div>
    <div style="position:absolute;left:200px;top:260px;" id="pie" runat="server">
        <asp:Chart ID="Chart2" runat="server" ImageType="Jpeg" ChartDashStyle="solid" Height="322px" Width="440px">
	            <Legends>
		            <asp:Legend Name="Legend1" >
		            </asp:Legend>
	            </Legends>
	            <Series>
	            </Series>
	            <ChartAreas>
		            <asp:ChartArea Name="ChartArea1">
		            </asp:ChartArea>
	            </ChartAreas>
	            <Titles>
		            <asp:Title Name="Title1">
		            </asp:Title>
	            </Titles>
            </asp:Chart>
    </div>
</asp:Content>