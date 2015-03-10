using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for user_management_dao
/// </summary>
public class user_management_dao
{

    public Boolean checkLogin(string user, string password)
    {
        SqlConnection conn = new SQLFactory().getConnection();
        string sql = "select password from USER_TBL where user_id = '" + user + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        if (dt.Rows.Count!= 0 && dt.Rows[0][0].ToString() == password)
        {
            sql = "update USER_TBL set last_login_dttm = '" + DateTime.Now.ToString() + "', failed_attempt=0 where user_id = '" + user + "'";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        else
        {

            if (dt.Rows.Count != 0 && dt.Rows[0][0].ToString() != null)
            {
                sql = "update USER_TBL set last_failed_attempt = '" + DateTime.Now.ToString() + "' , failed_attempt = (select failed_attempt+1 from USER_TBL where user_id = '" + user + "') where user_id = '" + user + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            return false;
        }
    }
}