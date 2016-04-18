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
using System.Collections.Generic;
using System.Linq;

public partial class _Default : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    DataTable table = new DataTable();
    ArrayList arryOptimalAdd = new ArrayList();
    FuzzyController objFuzzyCont = new FuzzyController();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            table.Columns.Add("SINo");
            table.Columns.Add("Route");
            table.Columns.Add("Distance");
            table.Columns.Add("Optimal Value");
            Best(NetworkCondition.arryOptimzedBestPath);
            arryOptimalAdd.Sort();
            ds.Tables.Add(table);
            DataSet dst = new DataSet();
            DataRow row1, row2;
            NetworkCondition.dstab = objFuzzyCont.GetBestOptimalRoute(NetworkCondition.arryOptimzedPath, ds, arryOptimalAdd);
            objFuzzyCont.CheckBestpath(NetworkCondition.dstab);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            Best(NetworkCondition.arryOptimzedSelectedPath);
            GridView2.DataSource = table;
            GridView2.DataBind();
        }

        
    }
    public void Best(ArrayList ListV)
    {
        ArrayList arryList = new ArrayList();

        arryList = ListV;
        table.Clear();
        for (int i = 0; i < arryList.Count; i++)
        {
            DataRow row = table.NewRow();

            string[] Route = arryList[i].ToString().Split('_');
            string[] route = Route[0].Split('-');
            string R = " ";
            for (int j = 1; j < route.Length - 1; j++)
            {
                R = R + "-" + route[j];

            }

            row[0] = i;
            row[1] = R;
            row[2] = route[route.Length - 1];
            row[3] = Route[1];
            table.Rows.Add(row);
            arryOptimalAdd.Add(float.Parse(Route[1]));
            //CheckBoxList1.Items.Add(NetworkCondition.arryOptimzedPath[i].ToString());
        }






    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int index = 0;
        List<double> ms = new List<double>();
        foreach (GridViewRow row in GridView1.Rows)
        {
            string value = row.Cells[3].Text;
            ms.Add(Convert.ToDouble(value));
        }
        double max = ms.OfType<double>().Min();
        TextBox1.Text = max.ToString();
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.Cells[3].Text == TextBox1.Text)
            {
                index = row.RowIndex;
            }
        }
        TextBox1.Text = index.ToString();
        Session["Sno"] = GridView1.Rows[index].Cells[0].Text;
        Session["Route"] = GridView1.Rows[index].Cells[1].Text;
        Session["Distance"] = GridView1.Rows[index].Cells[2].Text;
        Session["Optimal Value"] = GridView1.Rows[index].Cells[3].Text;
        int index2 = 0;
        List<double> ms2 = new List<double>();
        foreach (GridViewRow row in GridView2.Rows)
        {
            string value2 = row.Cells[3].Text;
            ms2.Add(Convert.ToDouble(value2));
        }
        double max2 = ms2.OfType<double>().Min();
        TextBox2.Text = max2.ToString();
        foreach (GridViewRow row in GridView2.Rows)
        {
            if (row.Cells[3].Text == TextBox2.Text)
            {
                index2 = row.RowIndex;
            }
        }
        TextBox1.Text = index2.ToString();
        Session["Sno2"] = GridView2.Rows[index2].Cells[0].Text;
        Session["Route2"] = GridView2.Rows[index2].Cells[1].Text;
        Session["Distance2"] = GridView2.Rows[index2].Cells[2].Text;
        Session["Optimal Value2"] = GridView2.Rows[index2].Cells[3].Text;
        Response.Redirect("FinalPath.aspx");
       
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int index = 0;
        List<double> ms = new List<double>();
        foreach (GridViewRow row in GridView1.Rows)
        {
            string value = row.Cells[3].Text;
            ms.Add(Convert.ToDouble(value));
        }
        double max = ms.OfType<double>().Min();
        TextBox1.Text = max.ToString();
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.Cells[3].Text == TextBox1.Text)
            {
                index = row.RowIndex;
            }
        }
        TextBox1.Text = index.ToString();
        Session["Sno"] = GridView1.Rows[index].Cells[0].Text;
        Session["Route"] = GridView1.Rows[index].Cells[1].Text;
        Session["Distance"] = GridView1.Rows[index].Cells[2].Text;
        Session["Optimal Value"] = GridView1.Rows[index].Cells[3].Text;
    }
}
