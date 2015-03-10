using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for user_worker
/// </summary>
public class user_worker
{
	 public Boolean validateLogin(string user, string password)
    {
            return      new user_management_dao().checkLogin(user, password);
    }
}