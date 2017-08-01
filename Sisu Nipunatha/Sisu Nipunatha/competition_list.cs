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
    public partial class competition_list : Form
    {
        public competition_list()
        {
            InitializeComponent();
        }

        private void competition_list_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dahampasalaDataSet.gradetable' table. You can move, or remove it, as needed.
            this.gradetableTableAdapter.Fill(this.dahampasalaDataSet.gradetable);
            updateDatagridview();
            numericUpDown1_ValueChanged(sender, e);

        }
        private static competition_list inst4;

        public static competition_list getInstance()
        {
            if (inst4 == null || inst4.IsDisposed)
            {
                inst4 = new competition_list();
                return inst4;
            }
            else
            {
                return inst4;
            }
        }
        public void updateDatagridview()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(@"select competitiontable.CompetitionID,competitiontable.competitionName,gradetable.grade,gradetable.birthday_after
FROM
competitiontable
INNER JOIN
gradetable ON competitiontable.grade=gradetable.grade;

;", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
        /*public String getGradeID(String grade)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "select gradeid from gradetable where grade='" + grade + "'";
            SqlCon.con.Open();
            String gradeID = cmd.ExecuteScalar().ToString();
            SqlCon.con.Close();
            return gradeID;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (avail_lbl.Text == "Unavailable")
            {
                MessageBox.Show("තරඟ අංකය භාවිතයේ පවතී","Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("තරගය ඇතුලත් කර නොමැත!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = SqlCon.con;
                cmd.CommandText = "INSERT INTO `competitiontable`( `competitionid`,`competitionName`, `grade`) VALUES ('"+numericUpDown1.Value.ToString()+"','" + textBox1.Text + "','" + comboBox1.SelectedValue.ToString() + "');";
                SqlCon.con.Open();
                cmd.ExecuteNonQuery();
                SqlCon.con.Close();
                updateDatagridview();
                numericUpDown1.ResetText();
                textBox1.ResetText();
                comboBox1.ResetText();
                numericUpDown1_ValueChanged(sender, e);
            }
        }

        

       private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from competitiontable where competitionID = '" + numericUpDown1.Value.ToString() + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
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

       private void button3_Click(object sender, EventArgs e)
       {
           DialogResult result = MessageBox.Show("ඉවත් කිරීමට අවශ්‍යමද?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (result == DialogResult.Yes)
           {
               try
               {
                   MySqlCommand cmd = new MySqlCommand();
                   cmd.Connection = SqlCon.con;
                   cmd.CommandText = "delete from competitiontable where competitionid='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "';";
                   SqlCon.con.Open();
                   cmd.ExecuteNonQuery();
                   SqlCon.con.Close();
                   
                   MessageBox.Show("දත්ත ඉවත් කිරීම සාර්ථකයි!");
                   updateDatagridview();
               }
               catch (Exception ex)
               {
                   SqlCon.con.Close();
                   MessageBox.Show("දත්ත ඉවත් කිරීම අසාර්ථකයි!"+ ex.ToString());
                   
               }
           }
       }
    }
}
