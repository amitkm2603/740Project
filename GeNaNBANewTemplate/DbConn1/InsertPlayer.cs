using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GeNaNBANew.App_Start;

namespace GeNaNBANew.DbConn
{
    public class InsertPlayer
    {

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
            conn.Open();
          int x=  cmd.ExecuteNonQuery();
            conn.Close();


        }

        public void insertGameDataDB(string date, string time, string team1, string team2)
        {
            SqlConnection conn = new SQLFactory().getConnection();
            string sql = "insert into game values ((select ISNULL(max(game_id),0)+1 from game),'" + date + "','" + time + "','" + team1 + "','" + team2 + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public int getMaxGameDB(string date, string time, string team1, string team2)
        {
            SqlConnection conn = new SQLFactory().getConnection();

            /*and game_time=CAST('"+time+"' AS Time) */
            string sql = "select max(game_id) from game where game_date = CAST('"+date+"' AS DATE) and team1_id in ('"+team1+"','"+team2+"') and team2_id in ('"+team1+"','"+team2+"') ";
            SqlCommand cmd = new SqlCommand(sql,conn) ;

            conn.Open();
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
    }
}