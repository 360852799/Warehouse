using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class Inin_Bind
    {
        public void Bind1(GridView G1)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号"; bf1.DataField = "num";
            BoundField bf2 = new BoundField(); bf2.DataField = "inID"; bf2.HeaderText = "入库编号"; bf2.ReadOnly = true; bf2.SortExpression = "inID"; bf2.HeaderStyle.Height = Unit.Parse("40px");
            BoundField bf3 = new BoundField(); bf3.DataField = "positionNum"; bf3.HeaderText = "库位编号"; bf3.SortExpression = "positionNum";
            BoundField bf4 = new BoundField(); bf4.DataField = "goodsNum"; bf4.HeaderText = "物品编号"; bf4.SortExpression = "goodsNum";
            BoundField bf5 = new BoundField(); bf5.DataField = "inAmount"; bf5.HeaderText = "入库量"; bf5.SortExpression = "inAmount";
            BoundField bf6 = new BoundField(); bf6.DataField = "batchNum"; bf6.HeaderText = "批次编号"; bf6.SortExpression = "batchNum";
            BoundField bf7 = new BoundField(); bf7.DataField = "date"; bf7.HeaderText = "日期"; bf7.SortExpression = "date";
            BoundField bf10 = new BoundField(); bf10.DataField = "userId"; bf10.HeaderText = "经办人"; bf10.SortExpression = "userId";
            BoundField bf11 = new BoundField(); bf11.DataField = "remark"; bf11.HeaderText = "备注"; bf11.SortExpression = "remark";
            ButtonField bf9 = new ButtonField(); bf9.CommandName = "deletee"; bf9.Text = "删除"; bf9.ControlStyle.BorderStyle = BorderStyle.None; bf9.ControlStyle.BackColor = System.Drawing.Color.White; bf9.ButtonType = ButtonType.Button; bf9.HeaderText = "";
            G1.Columns.Add(bf1);
            G1.Columns.Add(bf2);
            G1.Columns.Add(bf3);
            G1.Columns.Add(bf4);
            G1.Columns.Add(bf5);
            G1.Columns.Add(bf6);
            G1.Columns.Add(bf7);
            G1.Columns.Add(bf10);
            G1.Columns.Add(bf11);
            G1.Columns.Add(bf9);
        }
        public void Bind2(GridView G1)
        {
            BoundField bf11 = G1.Columns[0] as BoundField; bf11.ItemStyle.Font.Bold = true;
            ButtonField bf88 = G1.Columns[9] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White;
        }
    }
}