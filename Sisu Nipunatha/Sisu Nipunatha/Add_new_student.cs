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
    public partial class Add_new_student : Form
    {
        public Add_new_student()
        {
            InitializeComponent();
        }

        private void Add_new_student_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dahampasalaDataSet3.dahampasaltable' table. You can move, or remove it, as needed.
            this.dahampasaltableTableAdapter.Fill(this.dahampasalaDataSet3.dahampasaltable);
            // TODO: This line of code loads data into the 'dahampasalaDataSet2.competitiontable' table. You can move, or remove it, as needed.
            this.competitiontableTableAdapter.Fill(this.dahampasalaDataSet2.competitiontable);
            // TODO: This line of code loads data into the 'dahampasalaDataSet1.gradetable' table. You can move, or remove it, as needed.
            this.gradetableTableAdapter.Fill(this.dahampasalaDataSet1.gradetable);
            numericUpDown1_ValueChanged(sender, e);
            
            

        }
        private static Add_new_student inst7;

        public static Add_new_student getInstance()
        {
            if (inst7 == null || inst7.IsDisposed)
            {
                inst7 = new Add_new_student();
                return inst7;
            }
            else
            {
                return inst7;
            }
        }
        private void refreshComboBox(ComboBox comboBox1, String table,String column)
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
        private void refreshgradeComboBox(ComboBox comboBox1)       //updating the values of grade combo box checking the birthday
        {
            comboBox1.DataSource = null;
            //String table1 = table;
            //String column1 = column;
            //String test = "Select * from gradetable where birthday_after <"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+";";

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from gradetable where birthday_after <'"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox1.ValueMember = "grade";

            comboBox1.DisplayMember = "grade";
            comboBox1.DataSource = dt;


        }
        private void refreshcompetitionComboBox()       //updating the values of grade combo box checking the birthday
        {
            comboBox2.DataSource = null;
            //String table1 = table;
            //String column1 = column;
            //String test = "Select * from gradetable where birthday_after <"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+";";

            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from competitiontable where grade ='" + comboBox1.Text + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox2.ValueMember = "competitionname";

            comboBox2.DisplayMember = "competitionname";
            comboBox2.DataSource = dt;


        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)  //update the grade combobox with the correct values when it is clicked
        {
            if (checkBox1.Checked)
            {
                refreshComboBox(comboBox1, "gradetable", "grade");
            }
            else
            {
                refreshgradeComboBox(comboBox1);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)  
        {
            
            if (avail_lbl.Text == "Unavailable")
            {
                MessageBox.Show("තරග අංකය භාවිතයේ පවතී","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("නම ඇතුලත් කර නොමැත", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dateTimePicker1.Value == DateTime.Today)
            {
                MessageBox.Show("උපන්දිනය ඇතුලත් කර නොමැත", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("ලිපිනය ඇතුලත් කර නොමැත", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(comboBox1.SelectedItem==null)
            {
                MessageBox.Show("ශ්‍රේණියක් තෝරා නොමැත", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("තරගයක් තෝරා නොමැත", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String competitionID = getCompetitionID(comboBox1.Text, comboBox2.Text);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = SqlCon.con;
                DateTime max_birthday = getMaximumAge(comboBox1.Text);          //get the maximum date for the selected student
                try
                {
                    if (dateTimePicker1.Value >= max_birthday)      //checking for over age students
                    {
                        cmd.CommandText = "INSERT INTO `studentstable`(`StudentID`, `Name`, `Birthday`, `Address`, `Telephone No`, `CompetitionID`, `dahampasala`) VALUES('" + numericUpDown1.Value.ToString() + "','" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox2.Text + "','" + textBox3.Text + "','" + competitionID + "','" + comboBox3.Text + "');";
                        SqlCon.con.Open();
                        cmd.ExecuteNonQuery();
                        SqlCon.con.Close();
                        MessageBox.Show("දත්ත ඇතුලත් කිරීම සාර්ථකයි", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetValues();          //reset values
                    }
                    else                        //adding one to the over age students
                    {
                        cmd.CommandText = "INSERT INTO `studentstable`(`StudentID`, `Name`, `Birthday`, `Address`, `Telephone No`, `CompetitionID`, `dahampasala`,`overage`) VALUES('" + numericUpDown1.Value.ToString() + "','" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + textBox2.Text + "','" + textBox3.Text + "','" + competitionID + "','" + comboBox3.Text + "',1);";
                        SqlCon.con.Open();
                        cmd.ExecuteNonQuery();
                        SqlCon.con.Close();
                        MessageBox.Show("දත්ත ඇතුලත් කිරීම සාර්ථකයි", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetValues();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //resetValues();          //reset values
        }
        private void resetValues()
        {
            comboBox1.DataSource = null;    //resetting the values
            comboBox2.DataSource = null;
            numericUpDown1.ResetText();
            textBox1.ResetText();
            dateTimePicker1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
        }

        private String getCompetitionID(String grade,String competition)            //getting the competitionID
        {
            MySqlDataAdapter cmd = new MySqlDataAdapter("select competitionid from competitiontable where competitionname='" + competition + "' and grade ='" + grade + "'; ",SqlCon.con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            if (dt.Rows.Count != 1)
            {
                MessageBox.Show("Multiple entries in the grade table with same name and grade");
                return "None";
            }
            else
            {
                String ID = dt.Rows[0][0].ToString();
                return ID;
            }

        }

        private void comboBox1_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            comboBox1.Enabled = true;           //enabling grade combobox
            comboBox1.DataSource = null;        //resetting grade combo box if the birthday changed twice
            comboBox2.DataSource = null;        //resetting competition combo box if the birthday changed twice
            checkBox1.Enabled = true;           //enabling checkbox
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;       //enabling competition combo box after selecting the grade
            comboBox2.DataSource = null;    //resetting the values of competiton combo box
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)  //refreshing competitios values in the combo box
        {
            refreshcompetitionComboBox();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select studentID from studentstable where studentID = '" + numericUpDown1.Value.ToString() + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0 )
            {
                avail_lbl.Text = "Unavailable";
                avail_lbl.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                avail_lbl.Text = "Available";
                avail_lbl.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private DateTime getMaximumAge(String grade)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "select birthday_after from gradetable where grade = '" + grade + "';";
            SqlCon.con.Open();
            DateTime maxdate =Convert.ToDateTime(cmd.ExecuteScalar().ToString());
            SqlCon.con.Close();
            return maxdate;

        }
    }
}
