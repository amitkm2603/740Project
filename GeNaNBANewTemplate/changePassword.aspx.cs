using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Manually register the event-handling methods.
        ChangePassword1.ChangingPassword += new LoginCancelEventHandler(this.ChangePassword1_ChangedPassword);
    }
    protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
    {
        if (ChangePassword1.CurrentPassword.ToString() == ChangePassword1.NewPassword.ToString())
        {
            Message1.Visible = true;
            Message1.Text = "Old password and new password must be different.  Please try again.";
            e.Cancel = true;
        }
        else
        {
            //This line prevents the error showing up after a first failed attempt.
            Message1.Visible = false;
        }
    }
}