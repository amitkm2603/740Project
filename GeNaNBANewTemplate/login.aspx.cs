using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
       string action = Request.QueryString["action"];
        if(action == null)
            Session.Clear();
        else
        {
            Show("Successfully logged out!");
            Session.Clear();
        }
        if(HttpContext.Current.Session["user"]!=null)
            Response.Redirect("/DashBoard.aspx");
    }
    protected void Login_Submit_Click(object sender, EventArgs e)
    {

        Boolean validate = new user_worker().validateLogin(UserName.Text.ToString(), Password.Text.ToString());
        if (validate)
        {
            
            HttpContext.Current.Session["user"] = UserName.Text.ToString();
            Response.Redirect("/DashBoard.aspx");
        }
        else
        {
            Show("Invalid UserId or Password! Please try again!");
            HttpContext.Current.Session["user"] = null;
            UserName.Text = "";
            Password.Text = "";
        }
    }
    private void Show(string message)
    {
        string cleanMessage = message.Replace("'", "\'");
        Page page = HttpContext.Current.CurrentHandler as Page;
        string script = string.Format("alert('{0}');", cleanMessage);
        if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
        }
    } 
}