using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Default2 : System.Web.UI.Page
{
    string sql;
    DBConnection objdbcon = new DBConnection();
    public static DataTable table;
    string Location;
    bool flag,flag1;
    NetworkCondition objNetwok = new NetworkCondition();
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList4.Items.Clear();
        Location = Request.QueryString["id"];

        Page.Title = "Welcome To Control Center of " + Location;
        if (!Page.IsPostBack)
        {
                sql = "select dest from Route where source='" + Location + "'";
                table = objdbcon.DumpRoute(sql);
                if (table.Rows.Count == 0)
                {
                    sql = "select source from Route where Dest='" + Location + "'";
                    table = objdbcon.DumpRoute(sql);
                }
           
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownList3.Items.Add(table.Rows[i].ItemArray[0].ToString());
            }

            
                sql = "select dist from Distance where source='" + Location + "' and Dest ='" + DropDownList3.SelectedItem.Text + "'";
                string  dist = objdbcon.DataRead(sql);
                objdbcon.dr.Close();

            
            
           
            

            if (dist == null)
            {
                sql = "select dist from Distance where Dest='" + Location + "' and source ='" + DropDownList3.SelectedItem.Text + "'";
                dist = objdbcon.DataRead(sql);

            }
            DropDownList4.Items.Add(dist.ToString());
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Dis = DropDownList3.SelectedItem.Text;
        sql = "select dist from Distance where source='" + Location + "' and Dest ='"+Dis+"'";
        string dist =objdbcon.DataRead(sql);
        objdbcon.dr.Close();

        if (dist == null)
        {
            sql = "select dist from Distance where Dest='" + Location + "' and source ='" + Dis + "'";
            dist = objdbcon.DataRead(sql);
        
        }
        DropDownList4.Items.Add(dist.ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        sql = "update Distance set Road ='" + DropDownList1.SelectedItem.Value +"',Traffic='"+  DropDownList2.SelectedItem.Value +"'where source='" + Location + "' and Dest ='" + DropDownList3.SelectedItem.Text + "'";

        objdbcon.DataExcute(sql);

        sql = "select dist from Distance where source='" + Location + "' and Dest ='" + DropDownList3.SelectedItem.Text + "'";
        string dist = objdbcon.DataRead(sql);
        objdbcon.dr.Close();
        if (dist == null)
        {
            sql = "select dist from Distance where Dest='" + Location + "' and source ='" + DropDownList3.SelectedItem.Text + "'";
            dist = objdbcon.DataRead(sql);
        }
        DropDownList4.Items.Add(dist.ToString());
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            objNetwok.FuzzyvalueCalculation(Location, table);
            SqlConnection con = new SqlConnection("server=SHASHANK-PC;Database=FLGA;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string str;
            str = "insert into fuzzyvalues values(@Route,@Distance,@RoadCondition,@TrafficCondition)";
            con.Open();
            {
                cmd.Parameters.Add(new SqlParameter("@Route", DropDownList3.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@Distance", DropDownList4.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@RoadCondition", DropDownList1.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@TrafficCondition", DropDownList2.SelectedValue));
                cmd.CommandText = str;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        catch(Exception ex)
        {
            Response.Write("USER CAN'T ACCESS THIS PROCESS");
        }
    }
}
