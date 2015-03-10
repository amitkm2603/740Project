using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
     
    protected void Page_Load(object sender, EventArgs e)
    {

        if (HttpContext.Current.Session["user"] == null)
        {

            Response.Redirect("/login.aspx");
        }
        else
            Label1.Text = "Hello, " +  HttpContext.Current.Session["user"].ToString();
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
