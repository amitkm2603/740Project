using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//using GeNaNBANew.App_Start;

//mespace GeNaNBANew.DbConn
//{


    public class InsertPlayer
    {

        public void deletePlayer()
        {
            SqlConnection conn = new SQLFactory().getConnection();
            string sql = "delete from player";

            SqlCommand cmd = new SqlCommand(sql, conn);
            
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void insertPlayer(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12, string s13, string s14, string s15, string s16, string s17, string s18, string s19, string s20, string s191, string s192, string s193, string s194, string player_sequence)
        {
            /* assigning team id with respect to team name*/
            string[,] team_dict = (string[,])HttpContext.Current.Session["team_dict"];
            if(team_dict!=null)
            {
                if (team_dict[0,0].Equals(s19))
                    s20 = team_dict[0,1];
                else
                    s20 = team_dict[1,1];
            }
            /* assigning game time*/

            string game_date = (string)HttpContext.Current.Session["game_date"];
            string game_time = (string)HttpContext.Current.Session["game_time"];

            if (game_time!= null && game_date!= null)
            {

                s194 = game_time;
                s193 = game_date;
            }
            string season_id = (string)HttpContext.Current.Session["season"]; 
            if(season_id!=null)
            {
                s192 = season_id;
            }
            string playing_half= (string)HttpContext.Current.Session["playing_half"];

            SqlConnection conn = new SQLFactory().getConnection();
            string sql= "insert into player values ('" + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "','" + s5 + "','" + s6 + "','" + s7 + "','" + s8 + "','" + s9 + "','" + s10 + "','" + s11 + "','" + s12 + "','" + s13 + "','" + s14 + "','" + s15 + "','" + s16 + "','" + s17 + "','" + s18 + "','" + s19 + "','" + s20 + "', (select ISNULL(max(game_id),0) from game) ,'" + s192 + "','" + s193 + "','" + s194 + "','" + player_sequence + "','" + playing_half + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
    //        conn.Open();
          int x=  cmd.ExecuteNonQuery();
            conn.Close();


        }

        public int insertGameDataDB(string date, string time, string team1, string team2)
        {
            SqlConnection conn = new SQLFactory().getConnection();
            //get game_id
            string sql = "select ISNULL(max(game_id),0)+1 from game";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int game_id = (int)dt.Rows[0][0];
            sda.Dispose();
            //insert into game table
            sql = "insert into game values ("+game_id+",'" + date + "','" + time + "','" + team1 + "','" + team2 + "')";
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return game_id;

        }
        public int getMaxGameDB(string date, string time, string team1, string team2)
        {
            SqlConnection conn = new SQLFactory().getConnection();

            /*and game_time=CAST('"+time+"' AS Time) */
            string sql = "select max(game_id) from game where game_date = CAST('"+date+"' AS DATE) and team1_id in ('"+team1+"','"+team2+"') and team2_id in ('"+team1+"','"+team2+"') ";
            SqlCommand cmd = new SqlCommand(sql,conn) ;

         //   conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();

            if(sdr.IsDBNull(0))
            {
                conn.Close();
                return 0;
               
            }
            else
            {
                 
                conn.Close();
                return 1;
               
            }
            
        }

          public void execBoxScoreCreationWarehouse()
        {
            SqlConnection conn = new SQLFactory().getConnection();
            string sql = "procBoxScoreCreation";
           
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void insertPlayByPlay(List<string[]> row_list)
          {
              SqlConnection conn = new SQLFactory().getConnection();
            foreach (string[] row in row_list)
            {
                string sql = "INSERT INTO play_by_play (game_id,game_time,team_name_1,team_id_1,team_1_comments,team_1_score,team_2_score,team_name_2,team_id_2,team_2_comments,game_half,load_dttm)" +
                    "values ("+row[0]+",'"+row[1]+"','"+row[2]+"','"+row[3]+"','"+row[4]+"',"+row[5]+","+row[6]+
                    ",'" + row[7] + "','" + row[8] + "','" + row[9] + "','" + row[10] + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
          }
    }
//}