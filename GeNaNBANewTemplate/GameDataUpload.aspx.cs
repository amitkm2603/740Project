using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//namespace GeNaNBANew{

public partial class form1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
     //  if( HttpContext.Current.Session["user"] == null)
       //    Response.Redirect("/login.aspx");
    }

     protected void Button1_Click1(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            string url_main = TextBox1.Text;
            string[] url = new string[3];
            url[0] = url_main;
            if (url_main.Contains("?org_id"))
            {
                string[] temp = { "?org_id" };
                temp = url_main.Split(temp, StringSplitOptions.RemoveEmptyEntries);
                url_main = temp[0];
            }
            url[1] = url_main + "?period_no=1";
            url[2] = url_main + "?period_no=2";
            string[] half = new string[3];
            half[0] = "full";
            half[1] = "1";
            half[2] = "2";

   
            for (int i = 0; i < 3;i++ )
            {

                if (i == 0)
                    worker.deletePlayer();
                bool tableExist = mainProcess(worker, url[i], i, half[i]);
                if (tableExist)
                    break;
                
                if (i == 2)
                   worker.execBoxScoreCreationWarehouse();
            }
                      
          

        }
      
      
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected bool mainProcess(Worker worker, string url, int count, string half)
        {

            HttpContext.Current.Session["playing_half"] = half;
            //string sc = System.IO.File.ReadAllText(@"D:\1.HTML");
            //  StreamWriter sw = new StreamWriter("D:/web1.txt");
            //   System.Console.WriteLine(sc);
            //  sw.Write(sc);

            string sc = worker.getUrl(url);
            String team1, team2, team_table, game_table = "";
            string[,] game_time1 = new string[1, 2];
            string[] words; //storing tables
            string[] st = { "<table " };
            //splitting into tables
            words = sc.Split(st, StringSplitOptions.RemoveEmptyEntries);
            
            string[] tr_tokenizer3 = { "</table>" };
            
            team1 = words[words.Length - 1];  //last table
            team2 = words[words.Length - 2];  //2nd last table
            
            team_table = words[1];   // 1st table.

            //dynamically assigning table with game date data
            foreach (string temp in words)
            {
                if(temp.Contains("Game Date:"))
                 game_table =temp;
            }
            
            //creating table string for table 1
            string[] tr_team1_1 = team1.Split(tr_tokenizer3, StringSplitOptions.RemoveEmptyEntries);
            string team1_str = "<HTML><BODY> <table " + tr_team1_1[0] + "</table> </BODY></HTML>";

            //creating table string for team name table - 1st table
            string[] tr_team_name = team_table.Split(tr_tokenizer3, StringSplitOptions.RemoveEmptyEntries);
            string team_name_str = "<HTML><BODY> <table " + tr_team_name[0] + "</table> </BODY></HTML>";

            //game detail processing
            string game_detail = worker.processGameTable("<HTML><BODY> <table " + game_table + "</BODY></HTML>");

            // extractign team name - team id and assignning to session
            string[,] teamDict = worker.processTeamNameTable(team_name_str);
            HttpContext.Current.Session["team_dict"] = teamDict;

            
            if (game_detail != null)
            {
                game_time1 = Worker.getDateTime(game_detail);
                HttpContext.Current.Session["game_date"] = game_time1[0, 0];
                HttpContext.Current.Session["game_time"] = game_time1[0, 1];
            }


            int tableExist = 0;
            //check only once if the match exist in the database
            if(count==0)
                tableExist = worker.getMaxCount((string)HttpContext.Current.Session["game_date"], (string)HttpContext.Current.Session["game_time"], teamDict[0, 1], teamDict[1, 1]);


 
            if (tableExist < 1)
            {
                if(count==0)
                worker.insertGameData((string)HttpContext.Current.Session["game_date"], (string)HttpContext.Current.Session["game_time"], teamDict[0, 1], teamDict[1, 1]);
                
                string season = DropDownList1.SelectedValue;
                HttpContext.Current.Session["season"] = season;
                //Processing player tables
                string s,s1 = "";
                s=worker.processTeamTable("<HTML><BODY> <table " + team2 + "</BODY></HTML>");
                s1=worker.processTeamTable(team1_str);
                TextBox2.Text = "Tables loaded!";
                return false;
            }
            else
            {
                TextBox2.Text = "The match already exists in the database!";
                return true;
            }
      
     
        }
    }
