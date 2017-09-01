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
    public partial class Search_Student : Form
    {
        public Search_Student()
        {
            InitializeComponent();
        }
        private static Search_Student inst9;
       
        public static Search_Student getInstance()
        {
            if (inst9 == null || inst9.IsDisposed)
            {
                inst9 = new Search_Student();
                return inst9;
            }
            else
            {
                return inst9;
            }
        }
        private void Search_Student_Load(object sender, EventArgs e)
        {
            updateDatagridview();
            DataGridViewButtonColumn edit_button = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(edit_button);
            DataGridViewButtonColumn delete_button = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(delete_button);
            edit_button.Name = "Edit";
            delete_button.Name = "Delete";
            dataGridView1.Columns[9].DefaultCellStyle.NullValue = "Edit";
            dataGridView1.Columns[10].DefaultCellStyle.NullValue = "Delete";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            if (numericUpDown1.Value!=0)
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.dahampasala,studentstable.Name_english,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID where studentstable.studentID like'" + numericUpDown1.Value.ToString() + "%" + "';", SqlCon.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
            else
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.dahampasala,studentstable.Name_english,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID;", SqlCon.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value= 0;
            if (textBox1.Text!=null)
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.dahampasala,studentstable.Name_english,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID where studentstable.name like '%" + textBox1.Text + "%';", SqlCon.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
            else
            {
                updateDatagridview();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
             var senderGrid = (DataGridView)sender;

             if (senderGrid.Columns[e.ColumnIndex].Name=="Delete" &&
                 e.RowIndex >= 0)   //checking whether a delete button is pressed
             {
                 DialogResult result = MessageBox.Show("ඉවත් කිරීමට අවශ්‍යමද?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (result==DialogResult.Yes)
                 {
                     try 
	{	        
		             MySqlCommand cmd = new MySqlCommand();
                     String grade = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() ;
                     cmd.CommandText = "DELETE FROM `studentstable` WHERE `studentid`='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "';";
                     cmd.Connection = SqlCon.con;
                     SqlCon.con.Open();
                     cmd.ExecuteNonQuery();
                     SqlCon.con.Close();
                     MessageBox.Show("ඉවත් කිරීම සාර්ථකයි!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     updateDatagridview();
	}
	catch (Exception )
	{
        SqlCon.con.Close();
		MessageBox.Show("ඉවත් කිරීමට නොහැක වෙනත් දත්ත හා සම්බන්ධතා පවතී","Relationship Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
	};
                 }
             }else if (senderGrid.Columns[e.ColumnIndex].Name=="Edit" &&
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

         public void updateDatagridview()
         {

             MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.dahampasala,studentstable.Name_english,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID order by studentid;", SqlCon.con);
             
             DataTable dt = new DataTable();
             sda.Fill(dt);
             
             dataGridView1.DataSource = dt;
             
             dataGridView1.Refresh();
             
             toolStripStatusLabel1.Text = dataGridView1.RowCount.ToString() + " Students";
             
         }

         private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
         {
             textBox1.Clear();
         }

         private void textBox1_Click(object sender, EventArgs e)
         {
             numericUpDown1.Value = 0;
         }
    }

        
    
}

