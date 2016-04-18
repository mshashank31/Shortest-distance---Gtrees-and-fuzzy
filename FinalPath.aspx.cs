using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    DataTable table = new DataTable();
    DataTable table1 = new DataTable();
    ArrayList arryAdd = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {

            table.Columns.Add("SINo");
            table.Columns.Add("Route");
            table.Columns.Add("Distance");
            table.Columns.Add("Optimal Value");
            DataRow row = table.NewRow();
            row["SINo"] = Session["Sno"];
            row["Route"] = Session["Route"];
            row["Distance"] = Session["Distance"];
            row["Optimal Value"] = Session["Optimal Value"];
            table.Rows.Add(row);
            //for (int i = 0; i < FuzzyController.arryBestPath.Count; i++)
            //{
            //    string[] strd = FuzzyController.arryBestPath[i].ToString().Split('+');
            //    arryAdd.Add(float.Parse(strd[1]));
            //}
            //arryAdd.Sort();

            //for (int i = 0; i < FuzzyController.arryBestPath.Count; i++)
            //{
            //    string[] strd = FuzzyController.arryBestPath[i].ToString().Split('+');


            //    //for (int j = 0; j < arryAdd.Count; j++)
            //    //{

            //    if (strd[1] == arryAdd[i].ToString())
            //    {
            //        string[] Route = strd[0].Split('_');
            //        string[] route = Route[0].Split('-');
            //        string R = " ";
            //        for (int k = 1; k < route.Length - 1; k++)
            //        {
            //            R = R + "-" + route[k];

            //        }

            //        row[0] = 1;
            //        row[1] = R;
            //        row[2] = route[route.Length - 1];
            //        row[3] = Route[1];
            //       // table1.Rows.Add(row);
            //    }
            //}

            //GridView3.DataSource = table1;
            //GridView3.DataBind();
       //     DataRow row1 = table.NewRow();
       //     table.Clear();
       //     row1[0] = NetworkCondition.dstab.Rows[0].ItemArray[0];
       //     row1[1] = NetworkCondition.dstab.Rows[0].ItemArray[1];
       //     row1[2] = NetworkCondition.dstab.Rows[0].ItemArray[2]; ;
       //     row1[3] = NetworkCondition.dstab.Rows[0].ItemArray[3]; ;
       //     table.Rows.Add(row1);
            GridView4.DataSource = table;
            GridView4.DataBind();
        }
      

    }
    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       

        Response.Redirect("Home.aspx");

        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
