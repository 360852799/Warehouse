using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Warehouse.Controllor
{
    public class Staff_Bind
    {
        public void Bind1(GridView G1)
        {
            BoundField bf1 = new BoundField(); bf1.HeaderText = "序号"; bf1.DataField = "num";
            BoundField bf2 = new BoundField(); bf2.DataField = "staffNum"; bf2.HeaderText = "员工编号"; bf2.ReadOnly = true; bf2.SortExpression = "staffNum"; bf2.HeaderStyle.Height = Unit.Parse("40px");
            BoundField bf3 = new BoundField(); bf3.DataField = "staffName"; bf3.HeaderText = "员工姓名"; bf3.SortExpression = "staffName";
            BoundField bf4 = new BoundField(); bf4.DataField = "departId"; bf4.HeaderText = "部门Id"; bf4.SortExpression = "departId";
            BoundField bf5 = new BoundField(); bf5.DataField = "birthday"; bf5.HeaderText = "出生年月"; bf5.SortExpression = "birthday"; bf5.DataFormatString = "{0:d}";
            BoundField bf6 = new BoundField(); bf6.DataField = "gender"; bf6.HeaderText = "性别"; bf6.SortExpression = "gender";
            BoundField bf7 = new BoundField(); bf7.DataField = "hometown"; bf7.HeaderText = "籍贯"; bf7.SortExpression = "hometown";
            BoundField bf11 = new BoundField(); bf11.DataField = "idCard"; bf11.HeaderText = "身份证号"; bf11.SortExpression = "idCard";
            BoundField bf12 = new BoundField(); bf12.DataField = "phoneNumber"; bf12.HeaderText = "联系方式"; bf12.SortExpression = "phoneNumber";
            BoundField bf13 = new BoundField(); bf13.DataField = "entryTime"; bf13.HeaderText = "入职时间"; bf13.SortExpression = "entryTime"; bf13.DataFormatString = "{0:d}";
            ButtonField bf8 = new ButtonField(); bf8.CommandName = "editt"; bf8.Text = "编辑"; bf8.ControlStyle.BorderStyle = BorderStyle.None; bf8.ControlStyle.BackColor = System.Drawing.Color.White; bf8.ButtonType = ButtonType.Button; bf8.HeaderText = "";
            ButtonField bf9 = new ButtonField(); bf9.CommandName = "deletee"; bf9.Text = "删除"; bf9.ControlStyle.BorderStyle = BorderStyle.None; bf9.ControlStyle.BackColor = System.Drawing.Color.White; bf9.ButtonType = ButtonType.Button; bf9.HeaderText = "";
            G1.Columns.Add(bf1);
            G1.Columns.Add(bf2);
            G1.Columns.Add(bf3);
            G1.Columns.Add(bf4);
            G1.Columns.Add(bf5);
            G1.Columns.Add(bf6);
            G1.Columns.Add(bf7);
            G1.Columns.Add(bf11);
            G1.Columns.Add(bf12);
            G1.Columns.Add(bf13);
            G1.Columns.Add(bf8);
            G1.Columns.Add(bf9);
        }
        public void Bind2(GridView G1)
        {
            BoundField bf11 = G1.Columns[0] as BoundField; bf11.ItemStyle.Font.Bold = true;
            ButtonField bf88 = G1.Columns[10] as ButtonField; bf88.ControlStyle.BorderStyle = BorderStyle.None; bf88.ControlStyle.BackColor = System.Drawing.Color.White;
            ButtonField bf99 = G1.Columns[11] as ButtonField; bf99.ControlStyle.BorderStyle = BorderStyle.None; bf99.ControlStyle.BackColor = System.Drawing.Color.White;
        }
    }
}