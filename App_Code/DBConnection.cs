using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Sql;

/// <summary>
/// Summary description for DBConnection
/// </summary>
public class DBConnection
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    public SqlDataReader dr;
    DataSet ds;
    string sql,i;
    DataTable tab;

	public DBConnection()
	{
        //con = new SqlConnection(@"Data Source=.\SQLExpress;Integrated Security=True;User Instance=True;AttachDBFilename=|DataDirectory|Fuzzy.mdf");
        con = new SqlConnection("server=SHASHANK-PC;Database=FLGA;Integrated Security=true");
        con.Open();
	}
    public DataTable  DumpRoute(String sql)
    {
       ds = new DataSet();
       da = new SqlDataAdapter(sql, con);
       da.Fill(ds, "Temp");
       DataTable dtable = ds.Tables["Temp"];
       return dtable;

    }
    public void Dumptable(int Count)
    {
        if (NetworkCondition.ds.Tables.Count == 0)
        {

            for (int i = 0; i < Count; i++)
            {
                tab = new DataTable();
                sql = "select * from Distance";
                da = new SqlDataAdapter(sql, con);
                tab.TableName = i.ToString();
                da.Fill(tab);
                NetworkCondition.ds.Tables.Add(tab);
            }
        }
    }
    public string DataRead(String sql)
    {
        cmd = new SqlCommand(sql, con);
        dr = cmd.ExecuteReader();
        dr.Read();
        try
        {
            i = dr.GetValue(0).ToString();
        }
        catch { i = null; }
        return i;
    }
    public void DataExcute(String sql)
    {
       
        cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        
    }
    public int Resu(String sql)
    {
        cmd = new SqlCommand(sql, con);
        int ress=(int)cmd.ExecuteScalar();
        return ress;
    }
}
