using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for NetworkCondition
/// </summary>
public class NetworkCondition
{
    //Variable Declaration

    DBConnection objDBCON = new DBConnection();
    ArrayList possiblepath = new ArrayList();
    ArrayList fuzzyvalue = new ArrayList();
    ArrayList fuzzytraffic = new ArrayList();
    public static ArrayList fuzz = new ArrayList();
    public static ArrayList arryOptimzedSelectedPath = new ArrayList();
    public static ArrayList arryOptimzedPath = new ArrayList();
    public static ArrayList arryOptimzedRecursive = new ArrayList();
    public static ArrayList arryOptimzedBestPath = new ArrayList();
    public static ArrayList getestimatedroutes = new ArrayList();
    public static ArrayList routes = new ArrayList();
    Random roadcondition = new Random();
    Random traffic = new Random();
    public static ArrayList arryPossiblePath = new ArrayList();
    public static ArrayList arrySelectedPath = new ArrayList();
    string sql;
    double Getroad, Gettraffic;float Optmal_return;
   
    double Distance, goodroad, lowtraffic, lowdistance,  calr, calt, caldist, values;
    float count;
    public DataTable table = new DataTable();
    public static DataTable table2 = new DataTable();
    public static DataTable dstab = new DataTable();
    
    float optimal = 1;
    float SumOptimal;
    public static DataSet ds = new DataSet();
    public NetworkCondition()
    {
       
       objDBCON.Dumptable(arryPossiblePath.Count);
    }
    
    

    public void FuzzyvalueCalculation(string Location, DataTable table_Opt)
    {
        for (int k = 0; k < table_Opt.Rows.Count; k++)
        {
            string Destn = table_Opt.Rows[k].ItemArray[0].ToString();
            sql = "select ANO,Source,Dest,Dist,Road,Traffic from Distance where source='" + Location + "' and Dest='" + Destn + "'";
            table2 = objDBCON.DumpRoute(sql);
            if (table2.Rows.Count == 0)
            {
                sql = "select ANO,Source,Dest,Dist,Road,Traffic from Distance where source='" + Destn + "' and Dest='" + Location + "'";
                table = objDBCON.DumpRoute(sql);
            }
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                if (((Location == table2.Rows[i].ItemArray[1].ToString()) && (Destn == table2.Rows[i].ItemArray[2].ToString())) || ((Destn == table2.Rows[i].ItemArray[1].ToString()) && (Location == table2.Rows[i].ItemArray[2].ToString())))
                {

                    Distance = Convert.ToDouble(table2.Rows[i].ItemArray[3].ToString());
                    Getroad = Convert.ToDouble(table2.Rows[i].ItemArray[4].ToString());
                    Gettraffic = Convert.ToDouble(table2.Rows[i].ItemArray[5].ToString());
                    //Road Condition
                    if (Getroad == 0)
                    {
                        calr = 0;

                    }
                    else if ((Getroad == 5))
                    {
                        calr = 0.5;
                    }
                    else
                    {
                        calr = 1;
                    }

                    goodroad = (1 - calr);

                    //Traffic Condition
                    if (Gettraffic == 0)
                    {
                        calt = 0;
                    }
                    else if (Gettraffic == 5)
                    {
                        calt = 0.5;
                    }
                    else
                    {
                        calt = 1;
                    }

                    lowtraffic = (1 - calt);

                    //Distance
                    if (Distance <= 60)
                    {
                        caldist = 0;
                    }
                    else if ((Distance > 60) && (Distance <= 100))
                    {
                        caldist = 0.5;
                    }
                    else
                    {
                        caldist = 1;
                    }

                    lowdistance = (1 - caldist);

                    values = ((goodroad + lowtraffic + lowdistance) / 3);

                    //double Optimalvalue = OptimalValueCalculation(goodroad,lowtraffic,lowdistance,values);

                    sql = "update Distance set FuzzyValue='" + values + "'where Source='" + Location + "' and Dest='" + Destn + "'";

                    objDBCON.DataExcute(sql);
                }
            }
        }
    }
    public void OptimalValueCalculation()
    {
        for (int i = 0; i < arryPossiblePath.Count; i++)
        {
            string[] Route = arryPossiblePath[i].ToString().Split('-');
            SumOptimal = 0;
            count = 0;
            for (int j = 1; j < Route.Length -1; j++)
            {
                for(int k=0;k<ds.Tables[i].Rows.Count;k++)
                {

                    if (((Route[j] == ds.Tables[i].Rows[k].ItemArray[1].ToString()) && (Route[j + 1] == ds.Tables[i].Rows[k].ItemArray[2].ToString())))
                    {
                       
                        float FuzzyValue = float.Parse(ds.Tables[i].Rows[k].ItemArray[6].ToString());
                        float TrafficVal = float.Parse(ds.Tables[i].Rows[k].ItemArray[5].ToString());
                        float OptVa = GetOptimalValue(ref FuzzyValue, TrafficVal);
                        ds.Tables[i].Rows[k]["FuzzyValue"] = FuzzyValue;
                        ds.Tables[i].Rows[k]["OptimalValue"] = OptVa;
                        SumOptimal = SumOptimal + OptVa;
                        count++;
                    }
                    else if ((Route[j + 1] == ds.Tables[i].Rows[k].ItemArray[1].ToString()) && (Route[j] == ds.Tables[i].Rows[k].ItemArray[2].ToString()))
                    {
                        float FuzzyValue = float.Parse(ds.Tables[i].Rows[k].ItemArray[6].ToString());
                        float TrafficVal = float.Parse(ds.Tables[i].Rows[k].ItemArray[5].ToString());
                        float OptVa = GetOptimalValue(ref FuzzyValue, TrafficVal);
                      
                        ds.Tables[i].Rows[k]["FuzzyValue"] = FuzzyValue;
                        ds.Tables[i].Rows[k]["OptimalValue"] = OptVa;
                     

                        //sql = "Update Route" + i + " SET FuzzyValue ='" + FuzzyValue + "' , OptimalValue ='" + OptVa + "'where Source='" + Route[j].ToString() + "' and Dest='" + Route[j + 1].ToString() + "'";
                        //objDBCON.DataExcute(sql);
                        SumOptimal = SumOptimal + OptVa;
                        count++;
                    }
                
                }
            }

            float FinalOptimal = SumOptimal / count;

            if (FinalOptimal > optimal)
            {
               
                arryOptimzedBestPath.Add(arryPossiblePath[i].ToString() + "_" + FinalOptimal);
                arryOptimzedPath.Add(arryPossiblePath[i].ToString() + "_" + FinalOptimal);


                for (int x = 0; x < arrySelectedPath.Count; x++)
                {

                    if (arryPossiblePath[i].ToString() == arrySelectedPath[x].ToString())
                    {
                        arryOptimzedSelectedPath.Add(arrySelectedPath[x].ToString() + "_" + FinalOptimal);
                    }
                }


            }
            else
            {
                arryOptimzedPath.Add(arryPossiblePath[i].ToString() + "_" + FinalOptimal);

                for (int x = 0; x < arrySelectedPath.Count; x++)
                {

                    if (arryPossiblePath[i].ToString() == arrySelectedPath[x].ToString())
                    {
                        arryOptimzedSelectedPath.Add(arrySelectedPath[x].ToString() + "_" + FinalOptimal);
                    }

                }
            }

           
        }

        if (arryOptimzedBestPath.Count == 0)
        {
            //new NetworkCondition();
            arryOptimzedBestPath.Clear();
            arryOptimzedPath.Clear();
            arryOptimzedSelectedPath.Clear();
            OptimalValueCalculation();
        }
      


       
    }
    public float GetOptimalValue(ref float FuzzVal, float Traff)
    {

        if (Traff == 0)
        {
            FuzzVal = FuzzVal + (float) 0.125;

            //if (FuzzVal > optimal)
            //{

                Optmal_return = FuzzVal;
            
            //}
        }
        else
        {
            FuzzVal = FuzzVal + (float)0.225;

            //if (FuzzVal > optimal)
            //{

                Optmal_return = FuzzVal;

            //}

        
        
        }
        return Optmal_return;
    }
}




//public void findpossibepaths()
//{

//    for (int k = 0; k < table.Rows.Count; k++)
//    { 







//    }





//    //if (arryPossiblePath.Count > 0)
//    //{
//    //    for (int i = 0; i < arryPossiblePath.Count; i++)
//    //    {
//    //        root = arryPossiblePath[i].ToString().Split('-');

//    //        for (int j = 0; j < root.Length; j++)
//    //        { 

//    //            for(int k=0;k<table.Rows.Count;k++)
//    //            {
//    //                if (((root[j] == table.Rows[k].ItemArray[1].ToString()) && (root[j + 1] == table.Rows[k].ItemArray[2].ToString())) || ((root[j + 1] == table.Rows[k].ItemArray[1].ToString()) && (root[j] == table.Rows[k].ItemArray[2].ToString())))
//    //                {
//    //                    Distance = table.Rows[k].ItemArray[3].ToString();
//    //                    Getroad =table.Rows[k].ItemArray[4].ToString();
//    //                    Gettraffic = table.Rows[k].ItemArray[5].ToString();


//    //                }
//    //            }
//    //        }
//    //        //path=root[0];
//    //        //Distance=double.Parse (root [1].ToString ());
//    //        //road= roadcondition.Next(1, 100);
//    //        //Getroad = road.ToString();
//    //        //traff = traffic.Next(1, 150);
//    //        //Gettraffic = traff.ToString();
//    //        //possiblepath.Add(Getroad + "-" + Gettraffic+"="+path+"="+Distance);
//    //    }
//    //}
//    getoptimalpath();
//}

////Method To Find The FuzzyValue For All The Paths By Using The RoadCondition,Traffic and Distance
//public void getoptimalpath()
//{
//    if (possiblepath.Count > 0)
//    {
//        for (int i = 0; i < possiblepath.Count; i++)
//        {
//            receive = possiblepath[i].ToString();
//            split = receive.Split('=');
//            r = (int.Parse(split[0].ToString()));
//            t = (int.Parse(split[1].ToString()));
//            string path = split[2];
//            d = Convert.ToDouble(split[3].ToString());
//            if (r <= 10)
//            {
//                calr = 0;

//            }
//            else if ((r > 10) && (r <= 70))
//            {
//                calr = ((r - 10) / 60);
//            }
//            else
//            {
//                calr = 1;
//            }
//            goodroad = (1 - calr);


//            if (t <= 50)
//            {
//                calt = 0;
//            }
//            else if ((t > 50) && (t <= 100))
//            {
//                calt = (t - 50) / 50;
//            }
//            else
//            {
//                calt = 1;
//            } 

//            lowtraffic = (1 - calt);


//            if (d <= 100)
//            {
//                caldist = 0;
//            }
//            else if ((d > 100) && (d <= 500))
//            {
//                caldist =((d - 100) / 400);
//            }
//            else
//            {
//                caldist = 1;
//            } lowdistance =(1 - caldist);

//           values=((goodroad + lowtraffic + lowdistance) / 3);

//           fuzzyvalue.Add(values.ToString());
//           fuzzytraffic.Add(values + "=" + lowdistance);
//           routes.Add(path + "=" + r + "=" + t + "=" + d + "=" + values);

//           //for (int dis = 0; dis < POSSIBLE_ROUTES.getselectedpaths.Count; dis++)
//           //{
//           //    string distan = (POSSIBLE_ROUTES.getselectedpaths[dis].ToString ());
//           //    if (path.Equals ( distan ))
//           //    {
//           //        getestimatedroutes.Add(path + "=" + r + "=" + t + "=" + d + "=" + values);
//           //    }

//           //}
//        }
//    }
//    optimalvalue();
//    getestimatedroute();
//}

////Method To Find The OptimalValue For All The Paths By Using The FuzzyValue
//public void optimalvalue()
//{
//   float optimal=1;
//    for (int j = 0; j < fuzzyvalue.Count; j++)
//        {
//            float compare= float.Parse (fuzzyvalue[j].ToString ());
//            if (compare >= optimal)
//            {
//             // FuzzyController.output.Add(compare);
//            }
//            else
//            {
//             fuzz.Add (fuzzytraffic[j]);
//            }
//        }
//      //  fuzzyclass.getoptimizedpath();
//}

////Method To Store The Selected Routes Along With The FuzzyValue And OptimalValue In The DataTable Named BestPath
//public void getestimatedroute()
//{
//    sql = "delete BestPath";
//    cmd = new SqlCommand(sql, con);
//    cmd.ExecuteNonQuery();
//    if (getestimatedroutes .Count >0)
//    {
//        for (int x = 0; x < getestimatedroutes.Count; x++)
//        {
//         //  selectfuzzvalue= FuzzyController.addselectedfuzzyvalue[x].ToString();
//           selecfuzzyonly = selectfuzzvalue.Split('=');
//           Optimal = selecfuzzyonly[0].ToString();
//            str = getestimatedroutes[x].ToString();
//            root = str.Split('=');
//            string Path = root[0];
//            float Roadcondition =float.Parse (root[1].ToString ());
//            float Traffic = float.Parse (root[2].ToString ());
//            double Distance = double.Parse(root[3].ToString());
//            float Fuzzyvalue = float.Parse(root[4].ToString());


//            sql = "insert into BestPath values('" + Path + "'," + Roadcondition + "," + Traffic + "," + Distance + "," + Fuzzyvalue + "," + Optimal + ")";
//            cmd = new SqlCommand(sql, con);
//            cmd.ExecuteNonQuery();
//         }
//     } 
//    bestpath();

// }

////Method To Store The All The Possible Paths Along With The OptimalValue And FuzzyValue In DataTable Named Output
//public void bestpath()
//{


//    sql = "delete output";
//    cmd = new SqlCommand(sql, con);
//    cmd.ExecuteNonQuery();
//    if (routes.Count > 0)
//    {
//        for (int x = 0; x < routes.Count; x++)
//        {
//         //   selectfuzzvalue = FuzzyController.repeatfuzzy[x].ToString();
//            selecfuzzyonly = selectfuzzvalue.Split('=');
//            Optimal = selecfuzzyonly[0].ToString();
//            str = routes[x].ToString();
//            root = str.Split('=');
//            string Path = root[0];
//            float Roadcondition = float.Parse(root[1].ToString());
//            float Traffic = float.Parse(root[2].ToString());
//            double Distance = double.Parse(root[3].ToString());
//            float Fuzzyvalue = float.Parse(root[4].ToString());

//            sql = "insert into output  values('" + Path + "'," + Roadcondition + "," + Traffic + "," + Distance + "," + Fuzzyvalue + "," + Optimal + ")";
//            cmd = new SqlCommand(sql, con);
//            cmd.ExecuteNonQuery();
//        }
//    } 
//}


