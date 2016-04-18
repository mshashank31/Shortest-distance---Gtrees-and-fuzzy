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
using System.Text;


    public class DistanceCheckingR
    {
        //VARIABLE DECLARATION
       
        StringBuilder strbuild = new StringBuilder();
        ArrayList arryNeighR1;
        ArrayList arryNeighR2 = new ArrayList();
        ArrayList arryNeigh = new ArrayList();
        ArrayList aR = new ArrayList();
        ArrayList aR1 = new ArrayList();
        ArrayList arryCon = new ArrayList();
        string[] splt, splt1;
        string Machine,rec,strngB, middle,source, destination;
        double km;
        //TO FIND ALL ROUTER CONNECTION AND ROUTER CINNECTED LINK
        public void Connectivity(string SR,string DR,ArrayList arryConnection)
        {
            DistanceCalculation.arryConnection.Clear();
            DistanceCalculation.arryConnection = arryConnection;
            arryCon = arryConnection;//LINK BETWEEN SOURCE AND DESTINATION
            destination = DR;//DESSTINATION
            source = SR;//SOURCE
           
            for (int i = 0; i < arryConnection.Count; i++)
            {
                rec = arryConnection[i].ToString();
                splt = rec.Split('-');

                if (source.Equals(splt[0]))
                {
                    middle = splt[1];
                }
                else if (source.Equals(splt[1]))
                {
                    middle = splt[0];
                }
                else
                {
                    continue;
                }

                if (middle.Equals(destination))
                {
                    arryNeighR1 = new ArrayList();
                    arryNeighR1.Add(source);
                    arryNeighR1.Add(middle);
                    //ADD NEIGHBOUR NODE FOR EACH ROUTER
                   DistanceCalculation.PossiblePath.Add(arryNeighR1);
                   for (int k = 0; k < DistanceCalculation.PossiblePathDistance.Count; k++)
                   {
                       strngB = DistanceCalculation.PossiblePathDistance[k].ToString();
                       splt1 = strngB.Split('-');

                       if (((splt1[0] == source) && splt1[1] == destination) || ((splt1[1] == source) && (splt1[0] == destination)))
                       {
                           km = Convert.ToDouble(splt1[2]);
                           break;

                       }

                   }
                  // ADD ROUTER DISTANCE
                   DistanceCalculation.distance.Add(km);
                }
                else
                {
                    arryNeighR1 = new ArrayList();
                    arryNeighR1.Add(source);
                    arryNeighR1.Add(middle);
                    DistanceCalculation dc = new DistanceCalculation();
                    //TO CALL GETPATH METHOD FOR CHECK ROUTER LINK
                    dc.getpath(source, destination, arryNeighR1, middle);
                }
            }


        }
    }
