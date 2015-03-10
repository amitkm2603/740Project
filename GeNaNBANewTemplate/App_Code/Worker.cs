﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;
//using GeNaNBANew.DbConn;
using System.Text;
using System.Web.Providers.Entities;

// namespace GeNaNBANew.App_Start
//{
    public class Worker
    {
    public string getUrl(String url)
{
    HttpWebRequest req= (HttpWebRequest)WebRequest.Create(url);
    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
    StreamReader sr = new StreamReader(res.GetResponseStream());

    String cs = sr.ReadToEnd();
    sr.Close();
    res.Close();
    return cs;

    
    }

        public static string[,] getDateTime(string strn)
    {
        string[] t = { " " };
        string[] test = strn.Split(t, StringSplitOptions.RemoveEmptyEntries);
        string[,] ret = new string[1, 2];
        if (test.Length == 3)
            {
        ret[0, 0] = test[0];
        ret[0, 1] = test[1] + test[2];}
            else
            {
        ret[0, 0] = test[0];
        ret[0, 1] = test[1];
            }
        return ret;
    }
public string processGameTable(string table_name)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(table_name);

        HtmlNodeCollection rows = doc.DocumentNode.SelectNodes("//tr");

        String final = "";
        foreach (var row in rows)
        {
            try
            {
                HtmlNodeCollection cells = row.SelectNodes("th|td");
                 
                if(cells[0].InnerText.ToString().Contains("Date"))
                {
                    final = cells[1].InnerText.ToString();
                    break;
                }
                 


            }
            catch (Exception ex)
            {

            }
        }
        return final;
    }
    public string[,] processTeamNameTable(string table_name)
     {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(table_name);

        HtmlNodeCollection rows = doc.DocumentNode.SelectNodes("//tr");
        int rowCount = 0;
       
        String final = "";

        string[,] teamName = new string[2,2];
        int teamCount = 0;
        foreach (var row in rows)
        {
            try
            {
                string temp = row.WriteTo();

                if(temp.Contains("href"))
                {
                    HtmlNodeCollection cells = row.SelectNodes("th|td");
                    int index = temp.IndexOf("org_id");
                    int index2 = temp.IndexOf("onclick");
                    string tem = temp.Substring(index + 7, index2 - index-7).Trim();
                    int index3 = tem.Length;
                    string tem2 = tem.Substring(0, index3 - 1);

                    teamName[teamCount,0]=cells[0].InnerText.ToString();
                    if (teamName[teamCount, 0] != null && teamName[teamCount, 0].Contains("'"))
                        teamName[teamCount, 0] = teamName[teamCount, 0].Replace("'", "_");
                    teamName[teamCount,1] = tem2;
                    
                    final = final + "*****" + tem2 + " --- " + cells[0].InnerText.ToString();
                    teamCount++;
                }
             
                rowCount++;
            }
            catch (Exception ex)
            {

            }
        }
        return teamName;

    }
    
    public  string processTeamTable(String table)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(table);

        HtmlNodeCollection rows = doc.DocumentNode.SelectNodes("//tr");
        int rowCount = 0;
      InsertPlayer insertPlayer = new InsertPlayer();
        String final = "";
        string teamName = ""; 
        //  String[][] player = {};
        foreach (var row in rows)
        {
           // try
            //{


                HtmlNodeCollection cells = row.SelectNodes("th|td");
 
                //team name
                if(rowCount == 0)
                {
                    teamName = cells[0].InnerText.ToString().Replace("&nbsp;", "null").Trim();
                    if (teamName != null && teamName.Contains("'")) ;
                        teamName = teamName.Replace("'", "_");
                }
                //skipping row 1 since it contains headings
                if (rowCount > 1)
                {
                    string[] s=new string[20];
                     
                    s[1] = cells[0].InnerText.ToString().Replace("&nbsp;", "0").Trim();

                    if (!(s[1].Equals("TEAM")) && !(s[1].Equals("Totals")))
                    {
                        //processing player sequence
                        string player_raw =cells[0].WriteTo();
                        string player_sequence ="not present";
                        if(player_raw.Contains("href"))
                            player_sequence = getPlayerSequence(player_raw);
                        //end
                        s[2] = cells[1].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[3] = cells[2].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[4] = cells[3].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[5] = cells[4].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[6] = cells[5].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[7] = cells[6].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[8] = cells[7].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[9] = cells[8].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[10] = cells[9].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[11] = cells[10].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[12] = cells[11].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[13] = cells[12].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[14] = cells[13].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[15] = cells[14].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[16] = cells[15].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[17] = cells[16].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[18] = cells[17].InnerText.ToString().Replace("&nbsp;", "0").Trim();
                        s[19] = teamName;


                

                            for (int i = 1; i < 20; i++)
                            {
                                if (s[i] != null && (s[i].Trim()).Length < 1)
                                    s[i] = "0";
                                if (s[i].Contains("'"))
                                    s[i] = s[i].Replace("'", "");
                                if (s[i].Contains("\\"))
                                    s[i] = s[i].Replace("\\", "");
                                if (s[i].Contains("/"))
                                    s[i] = s[i].Replace("/", "");

                            }
                         

                        insertPlayer.insertPlayer(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], s[10], s[11], s[12], s[13], s[14], s[15], s[16], s[17], s[18], s[19], s[19], s[19], s[19], s[19], s[19], player_sequence);
                        final = final + "******" + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8] + s[9] + s[10] + s[11] + s[12] + s[13] + s[14] + s[15] + s[16] + s[17] + s[18] + s[19] + s[19] + s[19] + s[19] + s[19] + s[19] ;
                    }
                }
                rowCount++;
            }
         //   catch (Exception ex)
           // {

      //      }
    //    }
        return final;

    }
    
        public int  getMaxCount(string date, string time, string team1, string team2)
    {
        InsertPlayer insertPlayer = new InsertPlayer();
        return insertPlayer.getMaxGameDB(date, time, team1, team2);
    }
         public void insertGameData(string date, string time, string team1, string team2)
        {
            InsertPlayer insertPlayer = new InsertPlayer();
             insertPlayer.insertGameDataDB(date, time, team1, team2);
        }
         public string getPlayerSequence(String str)
{

    string[] tokenizer1 = {"player_seq="};

    string[] temp = str.Split(tokenizer1,StringSplitOptions.RemoveEmptyEntries);
    string[] tokenizer2 = {" target"};
    string[] temp1 = temp[1].Split(tokenizer2, StringSplitOptions.RemoveEmptyEntries);
    temp1[0]=temp1[0].Trim();
    string sequence = temp1[0].Substring(0, temp1[0].Length - 1);
   return sequence;
}
        public void  execBoxScoreCreationWarehouse()
         {
             new InsertPlayer().execBoxScoreCreationWarehouse();
         }
        public void deletePlayer()
        {
            new InsertPlayer().deletePlayer();
        }


    }
   
//}