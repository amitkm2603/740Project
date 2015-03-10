using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    //string name;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex;
        selectedRowIndex = GridView1.SelectedIndex;
        GridViewRow row = GridView1.Rows[selectedRowIndex];
        Session["name"] = row.Cells[1].Text;
       // ViewState["name"] = row.Cells[1].Text;
        //string name1 = ViewState["name"].ToString();
        string name1 = (string)(Session["name"]);
        detailsLabel.Text = "You selected " + name1 + ".";
        Response.Redirect("Default4.aspx");

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
           // BindGrid();
        
    }

    /*private void BindGrid()
    {
        string name1 = ViewState["name"].ToString();
        detailsLabel1.Text = "You selected " + name1 + ".";
       
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT first_name,FGA,FGM2 " +
        "FROM playerwarehouse1 where game_id=@game_id", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar,30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
        conn.Open();
        reader = comm.ExecuteReader();
        grid.DataSource = reader;
        grid.DataBind();
        reader.Close();
        }
        finally
        {
        conn.Close();
        }
    }*/
}
