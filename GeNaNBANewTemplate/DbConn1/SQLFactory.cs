using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GeNaNBANew.DbConn
{
    public class SQLFactory
    {


        public SqlConnection getConnection()
        {
            string connString = "Data Source=DELL;Initial Catalog=GeNANBANew;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);

            return conn;

        }


    }
}