using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Warehouse
{
    public partial class 图形化显示 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pie.Visible = false;
                refre_zhu();
                new Warehouse.Tools.AddSysLog().addlog("1", "图形化展示", "查询");
            }
        }

        public void refre_zhu()
        {
            List<string> list1 = new List<string>();
            List<int> list2 = new List<int> ();
            Chart1.Height = 400;
            Chart1.Width = 900;
            new Warehouse.Tools.AddSysLog().addlog("1", "图形化展示", "查询");
            List<Model.Amount> amos = new DAL.AmountDAO().getAllAmounts();
            for (int i=0; i<amos.Count;i++ )
            {
                list1.Add(amos[i].Goods.GoodsName);
                list2.Add(amos[i].Goods.GoodsCount);
            }
            
            //title属性说明
            //边框样式设置
            Chart1.ChartAreas["ChartArea1"].BorderColor = Color.Black;
            Chart1.ChartAreas["ChartArea1"].BorderWidth = 2;
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            Chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
            Chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;

            Chart1.Series.Add("现有数量");
            Chart1.Series["现有数量"]["PixelPointWidth"] = "20";
            Chart1.Series["现有数量"].Points.DataBindXY(list1, list2); //添加数据源，X、Y轴（结合这里是动态数组）
            for (int i = 0; i < list1.Count; i++)
            {
                Chart1.Series["现有数量"].Points[i].Label = list2[i].ToString();//柱状图顶部添加说明数据
            }

            //设置图例说明
            Chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("微软雅黑", float.Parse("8"), FontStyle.Regular);
            Chart1.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.FromName("Black");
            Chart1.ChartAreas["ChartArea1"].AxisY.Title = "数量";
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("微软雅黑", float.Parse("8"), FontStyle.Regular);
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.FromName("Black");
            Chart1.ChartAreas["ChartArea1"].AxisX.Title = "物品名称";
        }


        public void refre_pie()
        {
             //<summary>
             //2013年5月22日 修改 并添加说明
             //ToolTip：鼠标放在图标上显示数据（#VALX：指标名称，#VALY指标值）
             //LegendToolTip：鼠标放在图例上显示数据（#PERCENT：百分比）
             //PostBackValue：返回值（#INDEX：索引值）
             //LegendPostBackValue：图例返回值
             //LegendText：图例值
             //Label：饼图值
             //</summary>
            List<string> list1 = new List<string>();
            List<int> list2 = new List<int>();

            List<Model.Amount> amos = new DAL.AmountDAO().getAllAmounts();
            for (int i = 0; i < amos.Count; i++)
            {
                list1.Add(amos[i].Goods.GoodsName);
                list2.Add(amos[i].Goods.GoodsCount);
            }
            new Warehouse.Tools.AddSysLog().addlog("1", "图形化展示", "查询");
            Series series = Chart2.Series.Add("My Series");
            series.ToolTip = "#VALX:#VALY 数量";
            series.LegendToolTip = "#PERCENT";
            series.PostBackValue = "#INDEX";
            series.LegendPostBackValue = "#INDEX";
            series.LegendText = "#VALX";
            series.Label = "#VALX[#PERCENT]";
            series.Points.DataBindXY(list1, list2);
            Chart2.Series[0]["PieLabelStyle"] = "Outside";//饼图说明显示方式（外面）
            series.ChartType = SeriesChartType.Pie; //图标的显示风格（饼图）
            series.ShadowOffset = 2;
            series.BorderColor = Color.DarkGray;
            Chart2.Width = 880;
            Chart2.Height = 400;         
 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            zhu.Visible = true;
            pie.Visible = false;
            refre_zhu();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            zhu.Visible = false;
            pie.Visible = true;
            refre_pie();
        }
    }
}