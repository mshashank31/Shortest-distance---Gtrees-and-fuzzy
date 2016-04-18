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

/// <summary>
/// Summary description for FuzzyController
/// </summary>
public class FuzzyController
{
    ArrayList OptimalStore = new ArrayList();
    DataSet dst = new DataSet();
    DataTable table1 = new DataTable();
    float SumOptimal;
    float count;
    NetworkCondition objNetwork = new NetworkCondition();
    public static ArrayList arryBest = new ArrayList();
    public static ArrayList arryBestPath = new ArrayList();
    String Sno, Routes, Distance; public static string OPtimal;
	public FuzzyController()
	{
        table1.Columns.Add("SINo");
        table1.Columns.Add("Route");
        table1.Columns.Add("Distance");
        table1.Columns.Add("Optimal Value");
		//
		// TODO: Add constructor logic here
		//
	}

    public void CheckPath()
    {
        arryBest.Clear();
        arryBestPath.Clear();
        for (int i = 0; i < NetworkCondition.arryOptimzedPath.Count; i++)
        {

            string[] Route = NetworkCondition.arryOptimzedPath[i].ToString().Split('_');
            string[] route = Route[0].Split('-');
            string R = " ";
            for (int j = 1; j < route.Length - 1; j++)
            {
                R = R + "-" + route[j];
            }
            for (int j = 0; j < NetworkCondition.arrySelectedPath.Count; j++)
            {
                if (NetworkCondition.arrySelectedPath[j].ToString() == Route[0])
                {
                    arryBest.Add(NetworkCondition.arryOptimzedPath[i].ToString());


                    if ((Route[1] == OPtimal) || ( float.Parse(Route[1]) - float.Parse(OPtimal)) < 0.15)
                    {
                        //if (count == 0)
                        //{
                        arryBestPath.Add(NetworkCondition.arryOptimzedPath[i].ToString() + "+" +( float.Parse(Route[1]) - float.Parse(OPtimal)));
                        count++;
                        //}
                    }
                   
                }

            }
        }

        if(arryBestPath.Count ==0)
        {
         NetworkCondition.arryOptimzedBestPath.Clear();
         NetworkCondition.arryOptimzedPath.Clear();
         NetworkCondition.arryOptimzedSelectedPath.Clear();
         objNetwork.OptimalValueCalculation();
         CheckPath();
        }
    }
    public void CheckBestpath(DataTable dr1)
    {
        Sno = dr1.Rows[0].ItemArray[0].ToString();
        Routes = dr1.Rows[0].ItemArray[1].ToString();
        Distance = dr1.Rows[0].ItemArray[2].ToString();
        OPtimal = dr1.Rows[0].ItemArray[3].ToString();
        CheckPath();
    }
    public DataTable GetBestOptimalRoute(ArrayList Routes, DataSet ds,ArrayList OptimalSort)
    {
        DataTable table = ds.Tables[0];

        OptimalSort.Reverse();

        for (int i = 0; i < OptimalSort.Count; i++)
        { 

        for (int j = 0; j < table.Rows.Count; j++)
        {
           
            if (OptimalSort[i].ToString() == table.Rows[j].ItemArray[3].ToString())
            {
                
                DataRow row = table1.NewRow();
                row[0] = table.Rows[j].ItemArray[0].ToString();
                row[1] = table.Rows[j].ItemArray[1].ToString();
                row[2] = table.Rows[j].ItemArray[2].ToString();
                row[3] = table.Rows[j].ItemArray[3].ToString();
                table1.Rows.Add(row);
            }
        }
        }
        dst.Tables.Add(table1);
        return dst.Tables[0];
    
    }
}
