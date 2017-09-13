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
    public partial class Search_Students_By_Dahampasala : Form
    {
        public Search_Students_By_Dahampasala()
        {
            InitializeComponent();
        }

        private void Search_Students_By_Dahampasala_Load(object sender, EventArgs e)
        {
            updateDatagridview();
            DataGridViewButtonColumn edit_button = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(edit_button);
            DataGridViewButtonColumn delete_button = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(delete_button);
            edit_button.Name = "Edit";
            delete_button.Name = "Delete";
            dataGridView1.Columns[8].DefaultCellStyle.NullValue = "Edit";
            dataGridView1.Columns[9].DefaultCellStyle.NullValue = "Delete";
        }
        private static Search_Students_By_Dahampasala inst6;

        public static Search_Students_By_Dahampasala getInstance()
        {
            if (inst6 == null || inst6.IsDisposed)
            {
                inst6 = new Search_Students_By_Dahampasala();
                return inst6;
            }
            else
            {
                return inst6;
            }
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
        public void updateDatagridview()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.Name_english,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID where studentstable.dahampasala='" + comboBox1.Text + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            label2.Text = comboBox1.Text+"-අයදුම් කල තරගකරුවන් ගණන-"+dataGridView1.Rows.Count;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            refreshComboBox(comboBox1, "dahampasaltable", "name");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex].Name == "Delete" &&
                e.RowIndex >= 0)   //checking whether a delete button is pressed
            {
                DialogResult result = MessageBox.Show("ඉවත් කිරීමට අවශ්‍යමද?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand();
                        String grade = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        cmd.CommandText = "DELETE FROM `studentstable` WHERE `studentid`='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "';";
                        cmd.Connection = SqlCon.con;
                        SqlCon.con.Open();
                        cmd.ExecuteNonQuery();
                        SqlCon.con.Close();
                        MessageBox.Show("ඉවත් කිරීම සාර්ථකයි!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        updateDatagridview();
                    }
                    catch (Exception)
                    {
                        SqlCon.con.Close();
                        MessageBox.Show("ඉවත් කිරීමට නොහැක වෙනත් දත්ත හා සම්බන්ධතා පවතී", "Relationship Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    };
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex].Name == "Edit" &&
               e.RowIndex >= 0)       //checking whether an edit button is clicked
            {
                int a = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                handle_editing(a);
            }
        }
        private void handle_editing(int row_index)    //this method will handle the editing via another form
        {
            edit_student eg = new edit_student(row_index);
            eg.Show();
            this.Enabled = false;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateDatagridview();
        }

       
    }
}
