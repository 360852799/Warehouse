using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Warehouse
{
    public partial class 管理库位 : System.Web.UI.Page
    {
        Warehouse.Controllor.RefreshListbox pr = new Controllor.RefreshListbox();
        Warehouse.Controllor.RefreshGridview pg = new Controllor.RefreshGridview();
        Warehouse.Controllor.Position_Bind pb = new Controllor.Position_Bind();
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Sort so = new DAL.Sort();
            so.sort("Position", "positionNum");
            if (!IsPostBack)
            {
                departmentCreate.Style["display"] = "none";
                Div1.Style["display"] = "none";
            }
            pb.Bind2(GridView1);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            GridView1.Visible = false;
            if (GridView1.Visible == true)
            {
                Button1.Visible = true;
                Button4.Visible = true;
                Button10.Visible = true;
                ListBox1.Visible = true;
                TextBox5.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Button1.Visible = true;
                Button4.Visible = false;
                Button10.Visible = false;
                ListBox1.Visible = false;
                TextBox5.Visible = false;
            }
            Div1.Style["display"] = "inline";
            departmentCreate.Style["display"] = "inline";
            Button6.Text = "增加";
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            if (GridView1.Visible == true)
            {
                Button1.Visible = true;
                Button4.Visible = true;
                Button10.Visible = true;
                ListBox1.Visible = true;
                TextBox5.Visible = true;
            }
            else if (GridView1.Visible == false)
            {
                Button1.Visible = false;
                Button4.Visible = false;
                Button10.Visible = false;
                ListBox1.Visible = false;
                TextBox5.Visible = false;
            }
            //Warehouse.TextBox_Clear txt = new Warehouse.TextBox_Clear();
            //txt.clear(departmentCreate);
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox7.Text = "";
            ListBox3.Items.Clear();
            Div1.Style["display"] = "none";
            departmentCreate.Style["display"] = "none";
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            switch (ListBox1.Text)
            {
                case "根据库位编号":
                    pg.Queryequal("positionNum", "Position", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
                    }
                    break;
                case "根据库柜编号":
                    pg.Queryequal("chestNum", "Position", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
                    }
                    break;
                case "根据房间编号":
                    pg.Queryequal("roomNum", "Position", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
                    }
                    break;
                case "根据物品种类":
                    pg.Queryequal("goodsTypes", "Position", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {

                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
                    }
                    break;
                case "根据备注要求":
                    pg.Querylike("remark", "Position", TextBox5.Text, GridView1);
                    try
                    {
                        if (GridView1.Rows[0].Cells[0].Text != null)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询成功！');", true);
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('查询失败！');", true);
                        pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
                    }
                    break;
                case "":
                    TextBox5.Text = "";
                    pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
                    break;
            }
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            switch (Button6.Text)
            {
                case "增加":
                    {
                        Warehouse.Tools.queryV qu = new Tools.queryV();
                        Warehouse.Tools.apartV ap = new Tools.apartV();
                        Warehouse.Tools.tiqushuzi quu = new Tools.tiqushuzi();
                        string L = qu.query("select length from PositionType where PositionTypeId='" + TextBox7.Text + "'  ");
                        string W = qu.query("select width from PositionType where PositionTypeId='" + TextBox7.Text + "'  ");
                        string H = qu.query("select height from PositionType where PositionTypeId='" + TextBox7.Text + "'  ");
                        double a = double.Parse(qu.query("select M from Chest where chestNum='" + TextBox2.Text + "'"));
                        double b = double.Parse(qu.query("select Height from Chest where chestNum='" + TextBox2.Text + "'"));
                        double c=a * b - new Warehouse.Tools.positionSum().Sum(TextBox2.Text);
                        if ((quu.tiqu(L) * quu.tiqu(W) *(quu.tiqu(H)) < c))
                        {
                            try
                            {
                                DAL.Query nn = new DAL.Query();
                                int n = nn.query("position");
                                string nnn = "";
                                Model.Position add = new Model.Position();
                                add.Num = (n + 1).ToString();
                                add.PositionNum = TextBox1.Text;
                                add.ChestNum = TextBox2.Text;
                                add.RoomNum = TextBox3.Text;
                                add.PositiontypeId = TextBox7.Text;
                                add.M = (Convert.ToDouble(ap.apart(L)) * Convert.ToDouble(ap.apart(W))).ToString();
                                add.Height = (Convert.ToDouble(ap.apart(H))).ToString();
                                Warehouse.Tools.tiqushuzi tiqu = new Tools.tiqushuzi();
                                add.Rest = (tiqu.tiqu(add.M) * tiqu.tiqu(add.Height)).ToString();
                                for (int i = 0; i < ListBox3.Items.Count; i++)
                                {
                                    if (nnn == "")
                                    {
                                        nnn += ListBox3.Items[i].Text;
                                    }
                                    else
                                    {
                                        nnn += "、" + ListBox3.Items[i].Text;
                                    }
                                }
                                add.GoodsTypes = nnn;
                                add.Remark = TextBox6.Text;
                                add.CreateTime = DateTime.Now;
                                add.UpdateTime = DateTime.Now;
                                bool xx = new DAL.PositionDAO().addPosition(add);
                                //if (xx == true)
                                //{
                                //    double kk = Convert.ToDouble(ap.apart(qu.query("select M from Chest where chestNum='" + TextBox2.Text + "' "))) - (Convert.ToDouble(ap.apart(L)) * Convert.ToDouble(ap.apart(W)));
                                //    Warehouse.Tools.updateChestM up = new Tools.updateChestM();
                                //    up.update(kk + "m²", TextBox2.Text);
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加成功!');window.location.href='管理库位.aspx'", true);
                                //}
                            }
                            catch
                            {
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败！');", true);
                            }
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('添加失败，最大体积为" + (a * b - new Warehouse.Tools.positionSum().Sum(TextBox1.Text)) + "！');", true);
                        }
                    }
                    break;

                case "确定":
                    {
                        Button btn = sender as Button;
                        Model.Position update = new Model.Position();
                        update.PositionNum = TextBox1.Text;
                        update.ChestNum = TextBox2.Text;
                        update.RoomNum = TextBox3.Text;
                        update.PositiontypeId = TextBox7.Text;
                        string nnn = "";
                        for (int bbb = 0; bbb < ListBox3.Items.Count; bbb++)
                        {
                            if (nnn == "")
                            {
                                nnn += ListBox3.Items[bbb].Text;
                            }
                            else
                            {
                                nnn += "、" + ListBox3.Items[bbb].Text;
                            }
                        }
                        update.GoodsTypes = nnn;
                        update.Remark = TextBox6.Text;
                        update.UpdateTime = DateTime.Now;
                        bool xx = new DAL.PositionDAO().updatePosition(update);
                        if (xx)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改成功！');", true);
                            pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('修改失败！');", true);
                        }
                    }
                    break;
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            bool xx = new DAL.PositionDAO().deleteAllPositions();
            if (xx)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,NgoodsTypes,remark from Position", "positionNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
            }
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            Server.Transfer("库位类型管理.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Button5.Text == "获取库柜")
                {
                    A10.Style["color"] = "blue";
                    A8.Style["color"] = "black";
                    A9.Style["color"] = "black";
                    A11.Style["color"] = "black";
                    TextBox2.Text = ListBox2.SelectedItem.Value;
                    Warehouse.Tools.positionNum pos = new Tools.positionNum();
                    TextBox1.Text = pos.protect_positionNum(TextBox2.Text);
                    Button5.Text = "获取类型";
                    pr.Refresh("positionTypeId", "positionTypeName", "Positiontype", ListBox2);
                }
                else if (Button5.Text == "获取房间")
                {
                    A9.Style["color"] = "blue";
                    A8.Style["color"] = "black";
                    A10.Style["color"] = "black";
                    A11.Style["color"] = "black";
                    TextBox3.Text = ListBox2.SelectedItem.Value;
                    Button5.Text = "获取库柜";
                    pr.Refreshs("chestNum", "chestName", "Chest", TextBox3.Text, "roomNum", ListBox2);
                }
                else if (Button5.Text == "获取类型")
                {
                    A9.Style["color"] = "black";
                    A8.Style["color"] = "black";
                    A10.Style["color"] = "black";
                    A11.Style["color"] = "blue";
                    TextBox7.Text = ListBox2.SelectedItem.Value;
                    Button5.Text = "获取种类";
                    pr.Refresh("goodsTypeNum", "goodsTypeName", "Goodstype", ListBox2);
                }
                else if (Button5.Text == "获取种类")
                {
                    int k = 0;
                    for (int i = 0; i < ListBox3.Items.Count; i++)
                    {
                        if (ListBox3.Items[i].Text == ListBox2.SelectedItem.Value)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('已有该种类，请重新选择！');", true);
                            k = 1;
                        }
                    }
                    if (k != 1)
                    {
                        ListBox3.Items.Add(ListBox2.SelectedItem.Value);
                    }
                }
            }
            catch
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('请先在左侧列表选择！');", true);
            }
        }
        protected void Button101_Click(object sender, EventArgs e)
        {
            Server.Transfer("管理房间.aspx");
        }

        protected void Button90_Click(object sender, EventArgs e)
        {
            Server.Transfer("管理库柜.aspx");
        }
        protected void Button14_Click(object sender, EventArgs e)
        {
            pr.Refresh("roomNum", "roomName", "Room", ListBox2);
            //Warehouse.TextBox_Clear txt = new Warehouse.TextBox_Clear();
            //txt.clear(Div1); 
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox7.Text = "";
            ListBox3.Items.Clear();
            Button5.Text = "获取房间";
            A8.Style["color"] = "blue";
            A9.Style["color"] = "black";
            A10.Style["color"] = "black";
            ListBox2.Visible = true;
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox5.Style["top"] = "4.5px";
            if (ListBox1.SelectedItem.Text == "")
            {
                TextBox5.Style["top"] = "4.5px";
                TextBox5.Text = "";
                pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {
                pr.Refresh("goodsTypeNum", "goodsTypeName", "Goodstype", ListBox2);
                Button5.Text = "获取种类";
                Button14.Visible = false;
                int xy = Convert.ToInt32(e.CommandArgument);
                Div1.Style["display"] = "inline";
                Button6.Text = "确定";
                GridView1.Visible = false;
                if (GridView1.Visible == true)
                {
                    Button1.Visible = true;
                    Button4.Visible = true;
                    Button10.Visible = true;
                    ListBox1.Visible = true;
                    TextBox5.Visible = true;
                }
                else if (GridView1.Visible == false)
                {
                    Button1.Visible = false;
                    Button4.Visible = false;
                    Button10.Visible = false;
                    ListBox1.Visible = false;
                    TextBox5.Visible = false;
                }
                TextBox1.Text = GridView1.Rows[xy].Cells[1].Text;
                Model.Position pos = new DAL.PositionDAO().getPositionByNum(GridView1.Rows[xy].Cells[1].Text);
                TextBox2.Text = pos.ChestNum;
                TextBox3.Text = pos.RoomNum;
                string xx = pos.CreateTime.ToString();
                string yy = pos.UpdateTime.ToString();
                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();
                foreach (char x in xx)
                {
                    if (Convert.ToInt32(x) != 32)
                    {
                        sb1.Append(x);
                    }
                    else if (Convert.ToInt32(x) == 32)
                    {
                        break;
                    }
                }
                foreach (char x in yy)
                {
                    if (Convert.ToInt32(x) != 32)
                    {
                        sb2.Append(x);
                    }
                    else if (Convert.ToInt32(x) == 32)
                    {
                        break;
                    }
                }
                StringBuilder sb3 = new StringBuilder();
                int m = 0;
                foreach (char ff in pos.GoodsTypes)
                {
                    if (Convert.ToInt32(ff) == 12289)
                    {
                        m = m + 1;
                    }
                }
                m = m + 1;
                for (int c = 0; c < m; c++)
                {
                    foreach (char ff in pos.GoodsTypes)
                    {
                        if (Convert.ToInt32(ff) != 96)
                        {
                            sb3.Append(ff);
                        }
                        if (Convert.ToInt32(ff) == 96)
                        {
                            break;
                        }
                    }
                    if (c + 1 == m)
                    {
                        string vbn = pos.GoodsTypes.Substring(0, 6);
                        ListBox3.Items.Add(vbn);
                        sb3.Clear();
                    }
                    else
                    {
                        string vbnn = pos.GoodsTypes.Substring(0, 6);
                        pos.GoodsTypes = pos.GoodsTypes.Substring(7, pos.GoodsTypes.Length - 7);
                        ListBox3.Items.Add(vbnn);
                        sb3.Clear();
                    }
                }
                TextBox6.Text = pos.Remark;
                TextBox7.Text = pos.PositiontypeId;
                TextBox8.Text = sb1.ToString();
                TextBox9.Text = sb2.ToString();
                TextBox1.ReadOnly = true;
            }
            if (e.CommandName == "deletee")
            {
                ideas.Style["display"] = "inline";
                int x = Convert.ToInt32(e.CommandArgument);
                Session["e"] = x;
            }

        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Init(object sender, EventArgs e)
        {
            pb.Bind1(GridView1);
            pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
            pr.Refresh("roomNum", "roomName", "Room", ListBox2);
        }

        protected void Button200_Click(object sender, EventArgs e)
        {
            Model.Position delete = new Model.Position();
            int x = Convert.ToInt32(Session["e"]);
            delete.PositionNum = GridView1.Rows[x].Cells[1].Text;
            Warehouse.Tools.queryV qu = new Tools.queryV();
            Warehouse.Tools.apartV qp = new Tools.apartV();
            string chestNum = qu.query("select chestNum from Position where PositionNum='" + delete.PositionNum + "' ");
            string positionM = qu.query("select M from Position where PositionNum='" + delete.PositionNum + "' ");
            string M = qu.query("select M from Chest where chestNum='" + chestNum + "' ");
            bool yy = new DAL.PositionDAO().deletePositionByNum(delete.PositionNum);
            if (yy)
            {
                Warehouse.Tools.updateChestM up = new Tools.updateChestM();
                double bb = (Convert.ToDouble(qp.apart(M)) + Convert.ToDouble(qp.apart(positionM)));
                up.update((bb.ToString() + "平方米"), chestNum);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除成功！');", true);
                ideas.Style["display"] = "none";
                pg.Refresh("select num,positionNum,chestNum,roomNum,positionTypeId,goodsTypes,M,remark from Position", "positionNum", GridView1);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('删除失败！');", true);
                ideas.Style["display"] = "none";
            }
        }
        protected void Button300_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ListBox3.Items.Count == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "msg", "alert('至少存放一种物品！');", true);
            }
            else
            {
                ListBox3.Items.RemoveAt(ListBox3.SelectedIndex);
            }
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (TextBox6.Text == "")
            {
                TextBox6.Text = "无";
            }
        }
    }
}