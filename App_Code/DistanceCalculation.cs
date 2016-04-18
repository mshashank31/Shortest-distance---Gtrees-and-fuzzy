using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Summary description for DistanceCalculation
/// </summary>
public class DistanceCalculation
{
    //Variable Declaration
    //Creating The Referrence And Object For The Classes To Access
    public static ArrayList arryConnection = new ArrayList();
    public static ArrayList PossiblePath = new ArrayList();
    public static ArrayList PossiblePathDistance = new ArrayList();
    ArrayList arraylink = new ArrayList();
    ArrayList middlearray = new ArrayList();
    ArrayList result = new ArrayList();
    ArrayList Distancecalc = new ArrayList();
    ArrayList addarea = new ArrayList();
    ArrayList nooflink = new ArrayList();
    public static ArrayList distance = new ArrayList();
    Double km;
    String rec, middle;
    String[] splt;
    string path;
  

    //To Find All PossiblePaths Between The Source And The Destination Till The End In A Recursive Manner
    public void getpath(string source, string destination, ArrayList mid, string midarea)
    {
        
        arraylink = arryConnection;

        for (int i = 0; i < arraylink.Count; i++)
        {
            rec = arraylink[i].ToString();
            splt = rec.Split('-');

            if (midarea.Equals(splt[0]))
            {
                middle = splt[1];
            }
            else if (midarea.Equals(splt[1]))
            {
                middle = splt[0];
            }
            else { continue; }

            if (middle.Equals(destination))
            {
                middlearray = new ArrayList();
                for (int j = 0; j < mid.Count; j++)
                {
                    middlearray.Add(mid[j]);
                }
                middlearray.Add(middle);
                addarea.Clear();
                km = 0;
                for (int a = 0; a < middlearray.Count; a++)
                {
                    addarea.Add(middlearray[a]);
                }
                for (int k = 0; k < addarea.Count; k++)
                {
                    if ((k + 1) != addarea.Count)
                    {
                        path = addarea[k].ToString() + "-" + addarea[k + 1].ToString();

                        for (int x = 0; x < PossiblePathDistance.Count; x++)
                        {
                            rec = PossiblePathDistance[x].ToString();
                            splt = rec.Split('-');
                            if ((path == (splt[0] + "-" + splt[1])) || (path == (splt[1] + "-" + splt[0])))
                            {
                                km = km + Convert.ToDouble(splt[2]);

                            }
                        }

                    }
                }
                //TO ADD DISTANCE
                distance.Add(km);
                //TO ADD ROUTERS POSSIBLE DISTANCE
                PossiblePath.Add(middlearray);
            }
            else if (!(source.Equals(middle)) && (!mid.Contains(middle)))
            {
                //  RouteCalculation rc = new RouteCalculation();
                middlearray = new ArrayList();

                for (int j = 0; j < mid.Count; j++)
                {
                    middlearray.Add(mid[j]);
                }
                middlearray.Add(middle);
                //TO CALL GETPATH METHOD AS A RECURSIVE METHOD
                getpath(source, destination, middlearray, middle);

            }
        }
    }
}
