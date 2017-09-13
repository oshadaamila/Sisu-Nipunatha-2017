using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sisu_Nipunatha
{
    class tweetHandling
    {
        String firstid;
        String secondid;
        String thirdid;
        String fourthid;
        String fifthid;
        String first_name;
        String second_name;
        String third_name;
        String fourth_name;
        String fifth_name;
        String competition_id;
        String competitionname;
        public tweetHandling(String first, String second, String third, String fourth, String fifth,String competition_id)
        {
            this.firstid = first;
            this.secondid = second;
            this.thirdid=third;
            this.fourthid = fourth;
            this.fifthid = fifth;
            this.competition_id = competition_id;
        }
        public void setNames(){
            MySqlDataAdapter sda = new MySqlDataAdapter("select `Name_english` from studentstable where `StudentID` in ('" + firstid + "','" + secondid + "','" + thirdid + "','" + fourthid + "','" + fifthid + "') order by place asc;", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            first_name = dt.Rows[0][0].ToString();
            second_name = dt.Rows[1][0].ToString();
            third_name = dt.Rows[2][0].ToString();
            fourth_name = dt.Rows[3][0].ToString();
            fifth_name = dt.Rows[4][0].ToString();
        }
        public async void sendTweet()
        {
            setNames();
            setcompetitionname();
            var twitter = new TwitterApi("9RBBNE48Ynjsw4azdcsurV0D5", "hTNYIRrTZ4dgc1Bnz4gJwlVdd3klWPEgCN0IjsBj9mQSTeo4Bz", "903434854917857280-bsIfQ02vxGi0YgCvSUSTS2eeX4fEvXo", "sgAfuc58pPmDsohLhioLL1zYmrrAAWnWt27b7cnHNQ5qT");
            var response = await twitter.Tweet(competitionname+" 1-"+first_name+" 2-"+second_name+" 3-"+third_name+" 4-"+fourth_name+" 5-"+fifth_name);
            MessageBox.Show(response);
        }
        public void setcompetitionname()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT `Name_english` FROM `competitiontable` WHERE `CompetitionID`='"+competition_id+"';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            competitionname = dt.Rows[0][0].ToString();
        }
    }
}
