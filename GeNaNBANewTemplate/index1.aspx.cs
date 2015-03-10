using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridGame_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex;
        selectedRowIndex = GridGame.SelectedIndex;
        GridViewRow row = GridGame.Rows[selectedRowIndex];
        Session["name"] = row.Cells[1].Text;
        // ViewState["name"] = row.Cells[1].Text;
        //string name1 = ViewState["name"].ToString();
        string name1 = (string)(Session["name"]);
        //detailsLabel.Text = "You selected " + name1 + ".";
        Response.Redirect("BoxScore.aspx");
    }
}