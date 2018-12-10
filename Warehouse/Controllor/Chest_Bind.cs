using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace Warehouse.Controllor
{
    public class Chest_Bind
    {
        public void Bind1(GridView G1)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号"; bf1.DataField = "num";
            BoundField bf2 = new BoundField(); bf2.DataField = "chestNum"; bf2.HeaderText = "库柜编号"; bf2.ReadOnly = true; bf2.SortExpression = "chestNum"; bf2.HeaderStyle.Height = Unit.Parse("40px");
            BoundField bf3 = new BoundField(); bf3.DataField = "chestName"; bf3.HeaderText = "库柜名称"; bf3.SortExpression = "chestName";
            BoundField bf4 = new BoundField(); bf4.DataField = "M"; bf4.HeaderText = "可放面积"; bf4.SortExpression = "M";
            BoundField bf5 = new BoundField(); bf5.DataField = "roomNum"; bf5.HeaderText = "房间编号"; bf5.SortExpression = "roomNum";
            BoundField bf10 = new BoundField(); bf10.DataField = "remark"; bf10.HeaderText = "备注"; bf10.SortExpression = "remark";
            BoundField bf6 = new BoundField(); bf6.DataField = "createTime"; bf6.HeaderText = "创建时间"; bf6.SortExpression = "createTime"; bf6.DataFormatString = "{0:d}";
            ButtonField bf8 = new ButtonField(); bf8.CommandName = "editt"; bf8.Text = "编辑"; bf8.ControlStyle.BorderStyle = BorderStyle.None; bf8.ControlStyle.BackColor = System.Drawing.Color.White; bf8.ButtonType = ButtonType.Button; bf8.HeaderText = "";
            ButtonField bf9 = new ButtonField(); bf9.CommandName = "deletee"; bf9.Text = "删除"; bf9.ControlStyle.BorderStyle = BorderStyle.None; bf9.ControlStyle.BackColor = System.Drawing.Color.White; bf9.ButtonType = ButtonType.Button; bf9.HeaderText = "";
            G1.Columns.Add(bf1);
            G1.Columns.Add(bf2);
            G1.Columns.Add(bf3);
            G1.Columns.Add(bf4);
            G1.Columns.Add(bf5);
            G1.Columns.Add(bf10);
            G1.Columns.Add(bf6);
            G1.Columns.Add(bf8);
            G1.Columns.Add(bf9);
        }
        public void Bind2(GridView G1)
        {
            BoundField bf11 = G1.Columns[0] as BoundField; bf11.ItemStyle.Font.Bold = true;
            ButtonField bf88 = G1.Columns[7] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White;
            ButtonField bf99 = G1.Columns[8] as ButtonField; bf99.ControlStyle.BorderStyle = BorderStyle.None; bf99.ControlStyle.BackColor = System.Drawing.Color.White;
        }
    }
}