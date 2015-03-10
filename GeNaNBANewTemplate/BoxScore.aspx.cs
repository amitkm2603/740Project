using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Field_Goals_Click(object sender, EventArgs e)
    {
        BindGridTeam1();
        BindGridTeam2();

    }

    private void BindGridTeam1()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);
        
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,FGM,FGA,FG_Percent,FGM2,FGA2,FG2_Percent " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MIN(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);
       
        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam1.DataSource = reader;
            gridteam1.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }


    private void BindGridTeam2()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,FGM,FGA,FG_Percent,FGM2,FGA2,FG2_Percent " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MAX(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam2.DataSource = reader;
            gridteam2.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }


    protected void FreeThrows_Click(object sender, EventArgs e)
    {
        FreeThrowsBindGridTeam1();
        FreeThrowsBindGridTeam2();
    }

    private void FreeThrowsBindGridTeam1()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,FTM,FTA,FT_PERCENT,PPP,PPS " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MIN(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam1.DataSource = reader;
            gridteam1.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    private void FreeThrowsBindGridTeam2()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,FTM,FTA,FT_PERCENT,PPP,PPS " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MAX(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam2.DataSource = reader;
            gridteam2.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }


    protected void Rebounds_Click(object sender, EventArgs e)
    {
        ReboundsBindGridTeam1();
        ReboundsBindGridTeam2();

    }



    private void ReboundsBindGridTeam1()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,MIN,OREB,DREB,TREB,OREB_PERCENT,DREB_PRECENT " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MIN(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);
        

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam1.DataSource = reader;
            gridteam1.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    private void ReboundsBindGridTeam2()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,MIN,OREB,DREB,TREB,OREB_PERCENT,DREB_PRECENT " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MAX(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam2.DataSource = reader;
            gridteam2.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void Assists_Click(object sender, EventArgs e)
    {
        AssistsBindGridTeam1();
        AssistsBindGridTeam2();

    }

    private void AssistsBindGridTeam1()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,MIN,AST,TS_PERCENT " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MIN(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);
        

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam1.DataSource = reader;
            gridteam1.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    private void AssistsBindGridTeam2()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,MIN,AST,TS_PERCENT " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MAX(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam2.DataSource = reader;
            gridteam2.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }


    protected void Points_3_Click(object sender, EventArgs e)
    {
        Points_3_BindGridTeam1();
        Points_3_BindGridTeam2();

    }

    private void Points_3_BindGridTeam1()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,FGM,FGA3,FG3_PERCENT,PPP,PPS,Poss " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MIN(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam1.DataSource = reader;
            gridteam1.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    private void Points_3_BindGridTeam2()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,FGM,FGA3,FG3_PERCENT,PPP,PPS,Poss " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MAX(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam2.DataSource = reader;
            gridteam2.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void Steals_Click(object sender, EventArgs e)
    {
        StealsBindGridTeam1();
        StealsBindGridTeam2();

    }
    private void StealsBindGridTeam1()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,MIN,BLK,STL " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MIN(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam1.DataSource = reader;
            gridteam1.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    private void StealsBindGridTeam2()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,MIN,BLK,STL " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MAX(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam2.DataSource = reader;
            gridteam2.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void Turnovers_Click(object sender, EventArgs e)
    {
        TurnoversBindGridTeam1();
        TurnoversBindGridTeam2();

    }
    private void TurnoversBindGridTeam1()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,MIN,T_O,TOV_PERCENT,ESCR,GSCR " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MIN(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);
        

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam1.DataSource = reader;
            gridteam1.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    private void TurnoversBindGridTeam2()
    {
        //string name1 = ViewState["name"].ToString();
        //detailsLabel1.Text = "You selected " + name1 + ".";
        string name1 = (string)(Session["name"]);

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString =
        ConfigurationManager.ConnectionStrings[
        "GeNaNBANewConnectionString"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand(
        "SELECT code,first_name,last_name,MIN,T_O,TOV_PERCENT,ESCR,GSCR " +
        "FROM playerwarehouse1 where game_id=@game_id and team_id=(select MAX(distinct(team_id)) from playerWarehouse1 where GAME_ID=@game_id)", conn);

        comm.Parameters.Add("game_id", System.Data.SqlDbType.NVarChar, 30);
        comm.Parameters["game_id"].Value = name1;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gridteam2.DataSource = reader;
            gridteam2.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }
    
}