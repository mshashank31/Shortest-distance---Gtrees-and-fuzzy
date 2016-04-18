using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    DBConnection objdbcon = new DBConnection();
    //SqlDataAdapter sqlda = new SqlDataAdapter();
    //SqlCommand sqlcmd;
    DataTable table, table2;
    string sql, Area;
    Pen pen = new Pen(Brushes.Red, 3);
    CircleHotSpot c;
    protected void Page_Load(object sender, EventArgs e)
    {
        sql = "select Area from Location";
        table = objdbcon.DumpRoute(sql);
        sql = "select a.Point,b.Area from Table2 a inner join Location b on a.ANO=b.ANO";
        table2 = objdbcon.DumpRoute(sql);

        if (!IsPostBack)
        {

            for (int j = 0; j < table2.Rows.Count; j++)
            {
                c = new CircleHotSpot();
                Area = table2.Rows[j].ItemArray[1].ToString();
                string[] rec = table2.Rows[j].ItemArray[0].ToString().Split('-');
                c.AlternateText = Area;
                c.Radius = 15;
                c.X = int.Parse(rec[0]);
                c.Y = int.Parse(rec[1]);
                c.NavigateUrl = "ControlCenter_Login.aspx?id=" + Area;
                ImageMap1.HotSpots.Add(c);
            }

        }




    }
    protected void ImageMap1_Click1(object sender, ImageMapEventArgs e)
    {

    }
}
