using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
//using System.Windows.Forms;

public partial class _Default : System.Web.UI.Page
{
    DBConnection objdbcon = new DBConnection();
    DistanceCheckingR objdis = new DistanceCheckingR();
    NetworkCondition objNetwork = new NetworkCondition();
    DataTable table, table2;
    //StringBuilder strb;
    string route;
    DataTable tab = new DataTable();
    DataTable tab1 = new DataTable();
    ArrayList arryRoute1 = new ArrayList();
    ArrayList arryRoute2 = new ArrayList();
    //DataRow dr;
    //string area, area1, sql;
    string  sql;

    DataSet ds1 = new DataSet();
    string[] rec = new string[2];
    bool flag;
    DataSet ds = new DataSet();
    ArrayList arryConnection = new ArrayList();
    ArrayList arryConnection1 = new ArrayList();
    ArrayList arryRoute = new ArrayList();
    DataTable tablec;
    System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();


    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack )
       {
           NetworkCondition.arryOptimzedBestPath.Clear();
           NetworkCondition.arryOptimzedPath.Clear();
           NetworkCondition.arryOptimzedRecursive.Clear();
           NetworkCondition.arryOptimzedSelectedPath.Clear();
           NetworkCondition.arryPossiblePath.Clear();
           NetworkCondition.arrySelectedPath.Clear();
           NetworkCondition.ds.Tables.Clear();
           NetworkCondition.fuzz.Clear();
           NetworkCondition.getestimatedroutes.Clear();
           FuzzyController.arryBest.Clear();
           FuzzyController.arryBestPath.Clear();
           arryConnection.Clear();
           arryConnection1.Clear();
           arryRoute.Clear();
           arryRoute1.Clear();
           arryRoute2.Clear();
           DistanceCalculation.arryConnection.Clear();
           DistanceCalculation.PossiblePath.Clear();
           DistanceCalculation.PossiblePathDistance.Clear();
           DistanceCalculation.distance.Clear();

       }

        if (!Page.IsPostBack)
        {

            sql = "select Area from Location";

           tablec = objdbcon.DumpRoute(sql);



           for (int i = 0; i < tablec.Rows.Count; i++)
           {
               DropDownList1.Items.Add(tablec.Rows[i].ItemArray[0].ToString());
               DropDownList2.Items.Add(tablec.Rows[i].ItemArray[0].ToString());
                      
           }
        
        
        }

     }
    protected void Button1_Click(object sender, EventArgs e)
    {
        sWatch.Start();
        tab.Columns.Add("Route1");
        tab1.Columns.Add("Route2");
        //rec = Request.QueryString["id"].ToString().Split('-');
        rec[0] =DropDownList1.SelectedItem.Text;
        rec[1] = DropDownList2.SelectedItem.Text;
        sql = "select IDF from Location where Area='" + DropDownList1.SelectedItem.Text + "' ";
        int ret = int.Parse(objdbcon.DataRead(sql));
        objdbcon.dr.Close();
        sql = "select IDF from Location where Area='" + DropDownList2.SelectedItem.Text + "' ";
        
        
        int ret1 = int.Parse(objdbcon.DataRead(sql));
        objdbcon.dr.Close();
        if (ret == 1 && ret1 == 1)
        {
            sql = "select * from Neighbour";
            Function(rec[0], rec[1], sql);
        }
        else if (ret == 1 && ret1 == 2)
        {
            flag = true;
            sql = "select * from Neighbour";
            FromNorthToSouth_Begin(rec[0], rec[1], sql);
            sql = "select * from NEI";
            FromNorthToSouth_End(rec[0], rec[1], sql);
            DataSetToData();
        }
        else if (ret == 2 && ret1 == 1)
        {
            flag = false;
            sql = "select * from NEI";
            FromNorthToSouth_Begin(rec[0], rec[1], sql);
            sql = "select * from Neighbour";
            FromNorthToSouth_End(rec[0], rec[1], sql);
            DataSetToData();

        }
        else if ((ret == 1 && ret1 == 0) || (ret == 0 && ret1 == 1))
        {
            sql = "select * from Neighbour";
            Function(rec[0], rec[1], sql);
        }
        else if ((ret == 2 && ret1 == 0) || (ret == 0 && ret1 == 2))
        {
            sql = "select * from NEI";
            Function(rec[0], rec[1], sql);

        }
        else
        {
            sql = "select * from NEI";
            Function(rec[0], rec[1], sql);
        }
    }
    public void Function(string source, string destination, string sql)
    {
        table = objdbcon.DumpRoute(sql);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            arryConnection.Add(table.Rows[i].ItemArray[1].ToString() + "-" + table.Rows[i].ItemArray[2].ToString() + "-" + table.Rows[i].ItemArray[3].ToString());

        }
        ///========================
        ///
        DistanceCalculation.PossiblePathDistance = arryConnection;
        objdis.Connectivity(source, destination, arryConnection);
        //  arryRoute1 = (ArrayList)DistanceCalculation.PossiblePath;


        ArrayList Calc;
        for (int i = 0; i < DistanceCalculation.PossiblePath.Count; i++)
        {
            Calc = new ArrayList();
            Calc = (ArrayList)DistanceCalculation.PossiblePath[i];
            route = "";
            for (int j = 0; j < Calc.Count; j++)
            {
                route = route + "-" + Calc[j].ToString();
            }
            arryRoute.Add(route);
        }
        ArrayList ArryRoute = new ArrayList();
        ArrayList ArryWithSortDist = new ArrayList();

        for (int i = 0; i < arryRoute.Count; i++)
        {
            ArryRoute.Add(arryRoute[i] + "_" + DistanceCalculation.distance[i].ToString());
        }

        DistanceCalculation.distance.Sort();

        for (int j = 0; j < DistanceCalculation.distance.Count; j++)
        {
            for (int i = 0; i < ArryRoute.Count; i++)
            {
                string[] rec1 = ArryRoute[i].ToString().Split('_');

                if (DistanceCalculation.distance[j].ToString() == rec1[1])
                {
                    ArryWithSortDist.Add(rec1[0] + "-" + DistanceCalculation.distance[j].ToString());

                }
            }
        }
        DistanceCalculation.PossiblePath.Clear();
        DataSet ds = new DataSet();


        int count12 = 10;

        if (count12 <= ArryWithSortDist.Count)
        {
            count12 = 5;

        }
        else { count12 = ArryWithSortDist.Count; }

        sWatch.Stop();
        Label4.Text = "Total Execution Time: " + sWatch.ElapsedMilliseconds.ToString() + " milliseconds";
        for (int i = 0; i < count12; i++)
        {
            DataRow drow = tab.NewRow();
            drow[0] = ArryWithSortDist[i];
            tab.Rows.Add(drow);
        }
        ds.Tables.Add(tab);

        //string sql1 = "select count(*) from Neighbour where Source='" + DropDownList1.SelectedItem.Text + "' and DEST='" + DropDownList2.SelectedItem.Text + "';";
        //int result = objdbcon.Resu(sql);
        // if (result >= 1)
        //    {
        //     for (int i = 0; i < tab.Rows.Count-1; i++)
        //         {
           
        //        CheckBoxList1.Items.Add(tab.Rows[i + 1].ItemArray[0].ToString());
        //        NetworkCondition.arryPossiblePath.Add(tab.Rows[i+1].ItemArray[0].ToString());
        //     }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < tab.Rows.Count; i++)
        //        {
           
        //        CheckBoxList1.Items.Add(tab.Rows[i].ItemArray[0].ToString());
        //        NetworkCondition.arryPossiblePath.Add(tab.Rows[i].ItemArray[0].ToString());
        //        }
        //    }


        for (int i = 0; i < tab.Rows.Count; i++)
        {

            CheckBoxList1.Items.Add(tab.Rows[i].ItemArray[0].ToString());
            NetworkCondition.arryPossiblePath.Add(tab.Rows[i].ItemArray[0].ToString());
        }


        //GridView1.DataSource = ds;
        //GridView1.DataBind();

    }
    public void FromNorthToSouth_Begin(string source1, string destination1, string sql)
    {
        table = objdbcon.DumpRoute(sql);
        for (int i = 0; i < table.Rows.Count; i++)
        {
            arryConnection.Add(table.Rows[i].ItemArray[1].ToString() + "-" + table.Rows[i].ItemArray[2].ToString() + "-" + table.Rows[i].ItemArray[3].ToString());
        }
        ///========================
        ///
        DistanceCalculation.PossiblePathDistance = arryConnection;
        objdis.Connectivity(source1, "Trichy", arryConnection);

        // arryRoute1 = (ArrayList)DistanceCalculation.PossiblePath;

        ArrayList Calc;
        for (int i = 0; i < DistanceCalculation.PossiblePath.Count; i++)
        {
            Calc = new ArrayList();
            Calc = (ArrayList)DistanceCalculation.PossiblePath[i];
            route = "";
            for (int j = 0; j < Calc.Count; j++)
            {
                route = route + "-" + Calc[j].ToString();
            }
            arryRoute1.Add(route);
            //arryRoute1.Sort();

        }

        ArrayList ArryRoute1 = new ArrayList();
        ArrayList ArryWithSortDist1 = new ArrayList();

        for (int i = 0; i < arryRoute1.Count; i++)
        {
            ArryRoute1.Add(arryRoute1[i] + "_" + DistanceCalculation.distance[i].ToString());
        }


        DistanceCalculation.distance.Sort();

        for (int j = 0; j < DistanceCalculation.distance.Count; j++)
        {
            for (int i = 0; i < ArryRoute1.Count; i++)
            {
                string[] rec2 = ArryRoute1[i].ToString().Split('_');

                if (DistanceCalculation.distance[j].ToString() == rec2[1])
                {
                    ArryWithSortDist1.Add(rec2[0] + "_" + DistanceCalculation.distance[j].ToString());

                }
            }
        }


        int count12 = 10;

        if (count12 <= ArryWithSortDist1.Count)
        {
            count12 = 5;

        }
        else { count12 = ArryWithSortDist1.Count; }
        
        for (int i = 0; i < count12; i++)
        {
            DataRow drow = tab.NewRow();
            drow[0] = ArryWithSortDist1[i];
            tab.Rows.Add(drow);
        }
        ds.Tables.Add(tab);
    }
    public void FromNorthToSouth_End(string source1, string destination1, string sql)
    {

        table2 = objdbcon.DumpRoute(sql);
        for (int i = 0; i < table2.Rows.Count; i++)
        {
            arryConnection1.Add(table2.Rows[i].ItemArray[1].ToString() + "-" + table2.Rows[i].ItemArray[2].ToString() + "-" + table2.Rows[i].ItemArray[3].ToString());

        }
        DistanceCalculation.PossiblePathDistance.Clear();
        DistanceCalculation.PossiblePathDistance = arryConnection1;
        DistanceCalculation.PossiblePath.Clear();
        DistanceCalculation.distance.Clear();
        objdis.Connectivity("Trichy", destination1, arryConnection1);
        ArrayList Calc1;

        for (int i = 0; i < DistanceCalculation.PossiblePath.Count; i++)
        {
            Calc1 = new ArrayList();

            Calc1 = (ArrayList)DistanceCalculation.PossiblePath[i];
            route = "";
            for (int j = 0; j < Calc1.Count; j++)
            {
                route = route + "-" + Calc1[j].ToString();
            }
            arryRoute2.Add(route);
        }
        ArrayList ArryRoute2 = new ArrayList();
        ArrayList ArryWithSortDist2 = new ArrayList();
        for (int i = 0; i < arryRoute2.Count; i++)
        {
            ArryRoute2.Add(arryRoute2[i] + "_" + DistanceCalculation.distance[i].ToString());
        }
        DistanceCalculation.distance.Sort();
        for (int j = 0; j < DistanceCalculation.distance.Count; j++)
        {
            for (int i = 0; i < ArryRoute2.Count; i++)
            {
                string[] rec3 = ArryRoute2[i].ToString().Split('_');

                if (DistanceCalculation.distance[j].ToString() == rec3[1])
                {
                    ArryWithSortDist2.Add(rec3[0] + "_" + DistanceCalculation.distance[j].ToString());
                }
            }
        }
        sWatch.Stop();
        Label4.Text = "Total Execution Time: " + sWatch.ElapsedMilliseconds.ToString() + " milliseconds";
        for (int i = 0; i < ArryWithSortDist2.Count; i++)
        {
            DataRow drow1 = tab1.NewRow();
            drow1[0] = ArryWithSortDist2[i];
            tab1.Rows.Add(drow1);
        }
        ds.Tables.Add(tab1);
    }
    public void DataSetToData()
    {
        DataSet dset = new DataSet();
        DataTable dtab = new DataTable();
        DataTable Dtable = new DataTable();
        DataTable Dtable1 = new DataTable();
        dtab.Columns.Add("Route");
        // dtab.Columns.Add("Distance");
        StringBuilder strbuild;
        for (int t = 0; t < 1; t++)
        {
            //if (flag == false)
            //{
            //    Dtable = ds1.Tables[t];
            //}
            //else
            //{
            Dtable = ds.Tables[t];
            // }



            for (int t1 = 0; t1 < 5; t1++)
            {
                string[] st = Dtable.Rows[t1].ItemArray[0].ToString().Split('_');

                //   if (flag == false)
                // {
                //  Dtable1 = ds1.Tables[t+1];
                //}
                //else
                // {
                Dtable1 = ds.Tables[t + 1];
                // }
                int count1 = 5;

                if (count1 <= Dtable1.Rows.Count)
                {
                    count1 = 5;

                }
                else { count1 = Dtable1.Rows.Count; }
                for (int t2 = 0; t2 < count1; t2++)
                {
                    DataRow Drow = dtab.NewRow();
                    string[] st1 = Dtable1.Rows[t2].ItemArray[0].ToString().Split('_');
                    string[] scut = st[0].Split('-');
                    strbuild = new StringBuilder();
                    string strMrger = "";
                    for (int s = 0; s < scut.Length - 1; s++)
                    {
                        if (scut[s] != "")
                        {
                            strMrger = strMrger + "-" + scut[s];
                        }
                    }
                    string routP = strMrger + "" + st1[0];
                    int dis = int.Parse(st[1]) + int.Parse(st1[1]);
                    Drow[0] = routP + "-" + dis;
                    // Drow[1] = dis;
                    dtab.Rows.Add(Drow);
                }
            }
        }
        dset.Tables.Add(dtab);
        for (int i = 0; i < dtab.Rows.Count; i++)
        {
            CheckBoxList1.Items.Add(dtab.Rows[i].ItemArray[0].ToString());
            NetworkCondition.arryPossiblePath.Add(dtab.Rows[i].ItemArray[0].ToString());
        }
        //string sql = "select count(*) from Neighbour where Source='" + DropDownList1.SelectedItem.Text + "' and DEST='" + DropDownList2.SelectedItem.Text + "';";
        //int result = objdbcon.Resu(sql);
        //for (int i = 0; i < dtab.Rows.Count; i++)
        //{
        //    if (result >= 1)
        //    {
        //        CheckBoxList1.Items.Add(dtab.Rows[i+1].ItemArray[0].ToString());
        //        NetworkCondition.arryPossiblePath.Add(dtab.Rows[i].ItemArray[0].ToString());
        //    }
        //    else
        //    {
        //        CheckBoxList1.Items.Add(dtab.Rows[i].ItemArray[0].ToString());
        //        NetworkCondition.arryPossiblePath.Add(dtab.Rows[i].ItemArray[0].ToString());
        //    }
        //}
    }
   

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (CheckBoxList1.SelectedIndex != -1)
        {
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    NetworkCondition.arrySelectedPath.Add(CheckBoxList1.Items[i]);
                }

            }

            objNetwork.OptimalValueCalculation();
            Response.Redirect("Path.aspx");
        }
        else
        {
            //MessageBox.Show("Please select the Possible Root(s)");
        }
        
    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList1.Items.Clear();
        if (IsPostBack)
        {
            NetworkCondition.arryOptimzedBestPath.Clear();
            NetworkCondition.arryOptimzedPath.Clear();
            NetworkCondition.arryOptimzedRecursive.Clear();
            NetworkCondition.arryOptimzedSelectedPath.Clear();
            NetworkCondition.arryPossiblePath.Clear();
            NetworkCondition.arrySelectedPath.Clear();
            NetworkCondition.ds.Tables.Clear();
            NetworkCondition.fuzz.Clear();
            NetworkCondition.getestimatedroutes.Clear();
            FuzzyController.arryBest.Clear();
            FuzzyController.arryBestPath.Clear();
            arryConnection.Clear();
            arryConnection1.Clear();
            arryRoute.Clear();
            arryRoute1.Clear();
            arryRoute2.Clear();
            DistanceCalculation.arryConnection.Clear();
            DistanceCalculation.PossiblePath.Clear();
            DistanceCalculation.PossiblePathDistance.Clear();
            DistanceCalculation.distance.Clear();

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList1.Items.Clear();
        if (IsPostBack)
        {
            NetworkCondition.arryOptimzedBestPath.Clear();
            NetworkCondition.arryOptimzedPath.Clear();
            NetworkCondition.arryOptimzedRecursive.Clear();
            NetworkCondition.arryOptimzedSelectedPath.Clear();
            NetworkCondition.arryPossiblePath.Clear();
            NetworkCondition.arrySelectedPath.Clear();
            NetworkCondition.ds.Tables.Clear();
            NetworkCondition.fuzz.Clear();
            NetworkCondition.getestimatedroutes.Clear();
            FuzzyController.arryBest.Clear();
            FuzzyController.arryBestPath.Clear();
            arryConnection.Clear();
            arryConnection1.Clear();
            arryRoute.Clear();
            arryRoute1.Clear();
            arryRoute2.Clear();
            DistanceCalculation.arryConnection.Clear();
            DistanceCalculation.PossiblePath.Clear();
            DistanceCalculation.PossiblePathDistance.Clear();
            DistanceCalculation.distance.Clear();

        }
    }
}
