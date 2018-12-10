using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class Control_Bind
    {
        public void Bind1(GridView G1)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号"; bf1.DataField = "num";
            BoundField bf2 = new BoundField(); bf2.DataField = "goodsNum"; bf2.HeaderText = "物品编号"; bf2.ReadOnly = true; bf2.SortExpression = "goodsNum"; bf2.HeaderStyle.Height = Unit.Parse("40px");
            BoundField bf3 = new BoundField(); bf3.DataField = "goodsName"; bf3.HeaderText = "物品名称"; bf3.SortExpression = "goodsName";
            BoundField bf4 = new BoundField(); bf4.DataField = "goodsTypeName"; bf4.HeaderText = "物品类别"; bf4.SortExpression = "goodsTypeName";
            BoundField bf5 = new BoundField(); bf5.DataField = "amount"; bf5.HeaderText = "物品数量"; bf5.SortExpression = "amount";
            BoundField bf55 = new BoundField(); bf55.DataField = "per"; bf55.HeaderText = "物品单位"; bf55.SortExpression = "per";
            BoundField bf10 = new BoundField(); bf10.DataField = "max"; bf10.HeaderText = "库存上限"; bf10.SortExpression = "max";
            BoundField bf6 = new BoundField(); bf6.DataField = "rest"; bf6.HeaderText = "库存差额"; bf6.SortExpression = "rest";
            ButtonField bf8 = new ButtonField(); bf8.CommandName = "editt"; bf8.Text = "编辑"; bf8.ControlStyle.BorderStyle = BorderStyle.None; bf8.ControlStyle.BackColor = System.Drawing.Color.White; bf8.ButtonType = ButtonType.Button; bf8.HeaderText = "";
            ButtonField bf9 = new ButtonField(); bf9.CommandName = "deletee"; bf9.Text = "删除"; bf9.ControlStyle.BorderStyle = BorderStyle.None; bf9.ControlStyle.BackColor = System.Drawing.Color.White; bf9.ButtonType = ButtonType.Button; bf9.HeaderText = "";
            G1.Columns.Add(bf1);
            G1.Columns.Add(bf2);
            G1.Columns.Add(bf3);
            G1.Columns.Add(bf4);
            G1.Columns.Add(bf5);
            G1.Columns.Add(bf10);
            G1.Columns.Add(bf6);
            G1.Columns.Add(bf55);
            G1.Columns.Add(bf8);
            G1.Columns.Add(bf9);
        }
        public void Bind2(GridView G1)
        {
            BoundField bf11 = G1.Columns[0] as BoundField; bf11.ItemStyle.Font.Bold = true;
            ButtonField bf88 = G1.Columns[8] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White;
            ButtonField bf99 = G1.Columns[9] as ButtonField; bf99.ControlStyle.BorderStyle = BorderStyle.None; bf99.ControlStyle.BackColor = System.Drawing.Color.White;
        }
        public void Bind3(GridView G1)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号"; bf1.DataField = "num";
            BoundField bf44 = new BoundField(); bf44.DataField = "goodsTypeNum"; bf44.HeaderText = "物品类别编号"; bf44.SortExpression = "goodsTypeNum";
            BoundField bf4 = new BoundField(); bf4.DataField = "goodsTypeName"; bf4.HeaderText = "物品类别名称"; bf4.SortExpression = "goodsTypeName";
            BoundField bf5 = new BoundField(); bf5.DataField = "amount"; bf5.HeaderText = "物品数量"; bf5.SortExpression = "amount";
            BoundField bf55 = new BoundField(); bf55.DataField = "per"; bf55.HeaderText = "物品单位"; bf55.SortExpression = "per";
            BoundField bf10 = new BoundField(); bf10.DataField = "max"; bf10.HeaderText = "库存上限"; bf10.SortExpression = "max";
            BoundField bf6 = new BoundField(); bf6.DataField = "rest"; bf6.HeaderText = "库存差额"; bf6.SortExpression = "rest";
            ButtonField bf8 = new ButtonField(); bf8.CommandName = "editt"; bf8.Text = "编辑"; bf8.ControlStyle.BorderStyle = BorderStyle.None; bf8.ControlStyle.BackColor = System.Drawing.Color.White; bf8.ButtonType = ButtonType.Button; bf8.HeaderText = "";
            ButtonField bf9 = new ButtonField(); bf9.CommandName = "deletee"; bf9.Text = "删除"; bf9.ControlStyle.BorderStyle = BorderStyle.None; bf9.ControlStyle.BackColor = System.Drawing.Color.White; bf9.ButtonType = ButtonType.Button; bf9.HeaderText = "";
            G1.Columns.Add(bf1);
            G1.Columns.Add(bf44);
            G1.Columns.Add(bf4);
            G1.Columns.Add(bf5);
            G1.Columns.Add(bf10);
            G1.Columns.Add(bf6);
            G1.Columns.Add(bf55);
            G1.Columns.Add(bf8);
            G1.Columns.Add(bf9);
        }
        public void Bind4(GridView G1)
        {
            BoundField bf11 = G1.Columns[0] as BoundField; bf11.ItemStyle.Font.Bold = true;
            ButtonField bf88 = G1.Columns[7] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White;
            ButtonField bf99 = G1.Columns[8] as ButtonField; bf99.ControlStyle.BorderStyle = BorderStyle.None; bf99.ControlStyle.BackColor = System.Drawing.Color.White;
        }
    }
}