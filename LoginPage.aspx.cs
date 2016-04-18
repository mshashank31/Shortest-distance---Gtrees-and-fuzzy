using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DBConnection con = new DBConnection();
        string query = "select count(*) from Signup where UserName='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
        int ans = con.Resu(query);
        if (ans == 1)
        {
            Response.Write("<script>alert('Welcome To the Page');</script>");
        }
        else
        {
            Response.Write("<script>alert('Sorry... SignUp your Details First');</script>");
        }

    }
}