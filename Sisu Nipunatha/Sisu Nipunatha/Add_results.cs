using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sisu_Nipunatha
{
    public partial class Add_results : Form
    {
        public Add_results()
        {
            InitializeComponent();
        }
        private static Add_results inst12;

        public static Add_results getInstance()
        {
            if (inst12 == null || inst12.IsDisposed)
            {
                inst12 = new Add_results();
                return inst12;
            }
            else
            {
                return inst12;
            }
        }

        private void Add_results_Load(object sender, EventArgs e)
        {
            refreshGradeComboBox();
            refreshcompetitionComboBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dtforID.Select("StudentID='"+comboBox3.Text+"'");
            DataRow dr1 = dr[0];
            first_name.Text = dr1[1].ToString();
            first_dp.Text = dr1[2].ToString();
            comboBox3.Enabled = false;
            String id = comboBox3.Text;
            id_1.Text = id;
            comboBox3.DataSource = null;
            dtforID.Rows.Remove(dr1);
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            refreshGradeComboBox();
        }
        public void refreshGradeComboBox()
        {
            comboBox2.DataSource = null;
            //String table1 = table;
            //String column1 = column;
            //String test = "Select * from gradetable where birthday_after <"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+";";

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from gradetable", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox2.ValueMember = "grade";

            comboBox2.DisplayMember = "grade";
            comboBox2.DataSource = dt;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            refreshcompetitionComboBox();
        }
        private void refreshcompetitionComboBox()       //updating the values of grade combo box checking the birthday
        {
            comboBox1.DataSource = null;
            //String table1 = table;
            //String column1 = column;
            //String test = "Select * from gradetable where birthday_after <"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+";";

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from competitiontable where grade ='" + comboBox2.Text + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox1.ValueMember = "competitionname";

            comboBox1.DisplayMember = "competitionname";
            comboBox1.DataSource = dt;


        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox3.DataSource = null;
            
            comboBox3.ValueMember = "StudentID";

            comboBox3.DisplayMember = "StudentID";
            comboBox3.DataSource = dtforID;


            /*String[] postSource= new String[dt.Rows.Count];
            int b=0;
            foreach (DataRow a in dt.Rows)
            {
                postSource[b] = a[0].ToString();
                b = b + 1;
            }

            var source = new AutoCompleteStringCollection();
            source.AddRange(postSource);
            comboBox3.AutoCompleteCustomSource = source;
            comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            refreshDatatable();
            
        }
        DataTable dtforID= new DataTable();
        
        private void refreshDatatable()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "SELECT `CompetitionID`FROM `competitiontable` WHERE `grade`='" + comboBox2.Text + "' AND `competitionName`='" + comboBox1.Text + "';";
            SqlCon.con.Open();
            String competitionID = cmd.ExecuteScalar().ToString();
            SqlCon.con.Close();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT `StudentID`,`Name`,`dahampasala` FROM `studentstable` WHERE `CompetitionID`='" + competitionID + "';", SqlCon.con);
            sda.Fill(dtforID);
        }

        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox4.DataSource = null;

            comboBox4.ValueMember = "StudentID";

            comboBox4.DisplayMember = "StudentID";
            comboBox4.DataSource = dtforID;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dtforID.Select("StudentID='" + comboBox4.Text + "'");
            DataRow dr1 = dr[0];
            second_name.Text = dr1[1].ToString();
            second_dp.Text = dr1[2].ToString();
            comboBox4.Enabled = false;
            String id = comboBox4.Text;
            id_2.Text = id;
            comboBox4.DataSource = null;
            dtforID.Rows.Remove(dr1);
        }

        private void comboBox5_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox5.DataSource = null;

            comboBox5.ValueMember = "StudentID";

            comboBox5.DisplayMember = "StudentID";
            comboBox5.DataSource = dtforID;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dtforID.Select("StudentID='" + comboBox5.Text + "'");
            DataRow dr1 = dr[0];
            third_name.Text = dr1[1].ToString();
            third_dp.Text = dr1[2].ToString();
            comboBox5.Enabled = false;
            String id = comboBox5.Text;
            id_3.Text = id;
            comboBox5.DataSource = null;
            dtforID.Rows.Remove(dr1);
        }

        private void comboBox6_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox6.DataSource = null;

            comboBox6.ValueMember = "StudentID";

            comboBox6.DisplayMember = "StudentID";
            comboBox6.DataSource = dtforID;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dtforID.Select("StudentID='" + comboBox6.Text + "'");
            DataRow dr1 = dr[0];
            fourth_name.Text = dr1[1].ToString();
            fourth_dp.Text = dr1[2].ToString();
            comboBox6.Enabled = false;
            String id = comboBox6.Text;
            id_4.Text = id;
            comboBox6.DataSource = null;
            dtforID.Rows.Remove(dr1);
        }

        private void comboBox7_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox7.DataSource = null;

            comboBox7.ValueMember = "StudentID";

            comboBox7.DisplayMember = "StudentID";
            comboBox7.DataSource = dtforID;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dtforID.Select("StudentID='" + comboBox7.Text + "'");
            DataRow dr1 = dr[0];
            fifth_name.Text = dr1[1].ToString();
            fifth_dp.Text = dr1[2].ToString();
            comboBox7.Enabled = false;
            String id = comboBox7.Text;
            id_5.Text = id;
            comboBox7.DataSource = null;
            dtforID.Rows.Remove(dr1);
        }
    }
}
