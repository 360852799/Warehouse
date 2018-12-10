using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class PositionType_Bind
    {
        public void Bind1(GridView G1)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号"; bf1.DataField = "num";
            BoundField bf2 = new BoundField(); bf2.DataField = "positionTypeId"; bf2.HeaderText = "库位类型编号"; bf2.ReadOnly = true; bf2.SortExpression = "positionTypeId"; bf2.HeaderStyle.Height = Unit.Parse("40px");
            BoundField bf3 = new BoundField(); bf3.DataField = "positionTypeName"; bf3.HeaderText = "库柜类型名称"; bf3.SortExpression = "positionTypeName";
            BoundField bf4 = new BoundField(); bf4.DataField = "length"; bf4.HeaderText = "长度/cm"; bf4.SortExpression = "length";
            BoundField bf5 = new BoundField(); bf5.DataField = "width"; bf5.HeaderText = "宽度/cm"; bf5.SortExpression = "width";
            BoundField bf6 = new BoundField(); bf6.DataField = "height"; bf6.HeaderText = "高度/cm"; bf6.SortExpression = "height";
            BoundField bf7 = new BoundField(); bf7.DataField = "remark"; bf7.HeaderText = "备注"; bf7.SortExpression = "remark";
            ButtonField bf8 = new ButtonField(); bf8.CommandName = "editt"; bf8.Text = "编辑"; bf8.ControlStyle.BorderStyle = BorderStyle.None; bf8.ControlStyle.BackColor = System.Drawing.Color.White; bf8.ButtonType = ButtonType.Button; bf8.HeaderText = ""; bf8.ControlStyle.Width = Unit.Parse("60px"); bf8.ControlStyle.Font.Size = FontUnit.Parse("17px");
            ButtonField bf9 = new ButtonField(); bf9.CommandName = "deletee"; bf9.Text = "删除"; bf9.ControlStyle.BorderStyle = BorderStyle.None; bf9.ControlStyle.BackColor = System.Drawing.Color.White; bf9.ButtonType = ButtonType.Button; bf9.HeaderText = ""; bf9.ControlStyle.Width = Unit.Parse("60px"); bf9.ControlStyle.Font.Size = FontUnit.Parse("17px");
            G1.Columns.Add(bf1);
            G1.Columns.Add(bf2);
            G1.Columns.Add(bf3);
            G1.Columns.Add(bf4);
            G1.Columns.Add(bf5);
            G1.Columns.Add(bf6);
            G1.Columns.Add(bf7);
            G1.Columns.Add(bf8);
            G1.Columns.Add(bf9);
        }
        public void Bind2(GridView G1)
        {
            BoundField bf11 = G1.Columns[0] as BoundField; bf11.ItemStyle.Font.Bold = true;
            ButtonField bf88 = G1.Columns[7] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White; bf88.ControlStyle.Width = Unit.Parse("60px"); bf88.ControlStyle.Font.Size = FontUnit.Parse("17px");
            ButtonField bf99 = G1.Columns[8] as ButtonField; bf99.ControlStyle.BorderStyle = BorderStyle.None; bf99.ControlStyle.BackColor = System.Drawing.Color.White; bf99.ControlStyle.Width = Unit.Parse("60px"); bf99.ControlStyle.Font.Size = FontUnit.Parse("17px");
        }
    }
}