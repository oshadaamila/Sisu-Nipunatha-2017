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
            refreshgradeComboBox(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)  
        {
            comboBox1.DataSource = null;    //resetting the values
            comboBox2.DataSource = null;
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;       //enabling competition combo box after selecting the grade
            comboBox2.DataSource = null;    //resetting the values of competiton combo box
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            refreshcompetitionComboBox();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from studentstable where studentID = '" + numericUpDown1.Value.ToString() + "';", SqlCon.con);
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
    }
}
