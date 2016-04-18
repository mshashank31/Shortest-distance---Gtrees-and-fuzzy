using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn1_Click(object sender, EventArgs e)
     {
         SqlConnection con = new SqlConnection("server=HEMA;Database=FLGA;Integrated Security=true");
         SqlCommand cmd = new SqlCommand("select * from Signup where UserName=@UserName and Password=@Password",con);
         cmd.Parameters.AddWithValue("@username",txt1.Text);
         cmd.Parameters.AddWithValue("@password",txt2.Text);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataTable dt = new DataTable();
         da.Fill(dt);
         if(dt.Rows.Count>0)
         {
         Response.Redirect("Home.aspx");
        }
        else
        {
      ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>"); 
         }
       }
    protected void btn3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Signup.aspx");
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        txt1.Text = "";
        txt2.Text = "";
    }
}


