using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisu_Nipunatha
{
    public partial class View_Results : Form
    {
        public View_Results()
        {
            InitializeComponent();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.DataSource = null;
            String test = "Select distinct competitionname from competitiontable;";

            MySqlDataAdapter sda = new MySqlDataAdapter(test, SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox1.ValueMember = "competitionname";

            comboBox1.DisplayMember = "competitionname";
            comboBox1.DataSource = dt;
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            refreshComboBox(comboBox2, "gradetable", "grade");
        }
        private void refreshComboBox(ComboBox comboBox1, String table, String column)
        {
            comboBox1.DataSource = null;
            String table1 = table;
            String column1 = column;
            String test = "Select * from " + table1 + ";";

            MySqlDataAdapter sda = new MySqlDataAdapter(test, SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox1.ValueMember = column1;

            comboBox1.DisplayMember = column1;
            comboBox1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT studentid,name,dahampasala,place FROM `studentstable` WHERE `win`=1 and `CompetitionID`=(SELECT `CompetitionID`FROM `competitiontable` WHERE `grade`='" + comboBox2.Text + "' AND `competitionName`='" + comboBox1.Text + "') order by place;", SqlCon.con);
            //cmd.CommandText = "SELECT `CompetitionID`FROM `competitiontable` WHERE `grade`='" + comboBox2.Text + "' AND `competitionName`='" + comboBox1.Text + "';";
            //SqlCon.con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            dataGridView1.Update();
        }
    }
}
