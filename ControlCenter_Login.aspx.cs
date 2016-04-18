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

public partial class Default2 : System.Web.UI.Page
{
    string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        str = Request.QueryString["id"].ToString();
        Label1.Text = "Welcome To " + str + " Control Center";
        Login1.UserName = str;
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (Login1.Password == str)
        {
            Response.Redirect("ControlCenter.aspx?id=" + str);

        }

    }
}
