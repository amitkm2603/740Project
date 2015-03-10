<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Default4" %>

<!DOCTYPE html>
<!--[if lt IE 7]> <html class="lt-ie9 lt-ie8 lt-ie7" lang="en"> <![endif]-->
<!--[if IE 7]>    <html class="lt-ie9 lt-ie8" lang="en"> <![endif]-->
<!--[if IE 8]>    <html class="lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]><!--><html lang="en"><!--<![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <!-- Viewport Metatag -->
    <meta name="viewport" content="width=device-width,initial-scale=1.0">

    <!-- Required Stylesheets -->
    <link rel="stylesheet" type="text/css" href="bootstrap/css/bootstrap.min.css" media="screen">
    <link rel="stylesheet" type="text/css" href="css/fonts/ptsans/stylesheet.css" media="screen">
    <link rel="stylesheet" type="text/css" href="css/fonts/icomoon/style.css" media="screen">

    <link rel="stylesheet" type="text/css" href="css/login.css" media="screen">

    <link rel="stylesheet" type="text/css" href="css/mws-theme.css" media="screen">

    <title>Gena Analytics-Login</title>
</head>
<body>
    <form id="login" runat="server">
   <div id="mws-login-wrapper">
        <div id="mws-login">
            <h1>GeNa Analytics Login</h1>
            <div class="mws-login-lock"><i class="icon-lock"></i></div>
            <div id="mws-login-form">
                
                    <div class="mws-form-row">
                        <div class="mws-form-item">
                            <asp:TextBox   runat="server"   type="text" id= "UserName" name="username" class="mws-login-username required" placeholder="username"/>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <div class="mws-form-item">
                            
                            <asp:TextBox   runat="server"  type="password" id= "Password"  name="password" class="mws-login-password required" placeholder="password"/>
                        </div>
                    </div>
                    <div id="mws-login-remember" class="mws-form-row mws-inset">
                        <ul class="mws-form-list inline">
                            <li>
                                <input id="remember" type="checkbox"> 
                                <label for="remember">Remember me</label>
                            </li>
                        </ul>
                    </div>
                    <div class="mws-form-row">
                       
                        <asp:Button ID="Login_Submit" runat="server" Text="Login" class="btn btn-success mws-login-button" OnClick="Login_Submit_Click" />
                    </div>
              
            </div>
        </div>
    </div>
    </form>

      <!-- JavaScript Plugins -->
    <script src="js/libs/jquery-1.8.3.min.js"></script>
    <script src="js/libs/jquery.placeholder.min.js"></script>
    <script src="custom-plugins/fileinput.js"></script>
    
    <!-- jQuery-UI Dependent Scripts -->
    <script src="jui/js/jquery-ui-effects.min.js"></script>

    <!-- Plugin Scripts -->
    <script src="plugins/validate/jquery.validate-min.js"></script>

    <!-- Login Script -->
    <script src="js/core/login.js"></script>

</body>
</html>
 

