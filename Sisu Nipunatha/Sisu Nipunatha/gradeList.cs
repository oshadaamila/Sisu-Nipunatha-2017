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
    public partial class gradeList : Form
    {
        public gradeList()
        {
            InitializeComponent();
        }
        private static gradeList inst3;

        public static gradeList getInstance()
        {
            if (inst3 == null || inst3.IsDisposed)
            {
                inst3 = new gradeList();
                return inst3;
            }
            else
            {
                return inst3;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gradeList_Load(object sender, EventArgs e)
        {
            updateDatagridview();   //updating the datagridview when loading the form
            //DataGridViewButtonColumn edit_button = new DataGridViewButtonColumn();
            //dataGridView1.Columns.Add(edit_button);
            DataGridViewButtonColumn delete_button = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(delete_button);
            //edit_button.Name = "Edit";
            delete_button.Name = "Delete";
            //dataGridView1.Columns[3].DefaultCellStyle.NullValue = "Edit";
            dataGridView1.Columns[3].DefaultCellStyle.NullValue = "Delete";
        }
        private DateTime calculateBirthDay(int age)
        {
            int thisYear = DateTime.Today.Year;
            DateTime date = Convert.ToDateTime(""+thisYear+"-01-31");
            DateTime correctDate = date.AddYears(-age);
            return correctDate;
        }

        private void button1_Click(object sender, EventArgs e)  //button for adding content to database
        {
            if(textBox1.Text!="")   // check for null values
            {
            int age =Convert.ToInt32(numericUpDown1.Value);
            DateTime correctDate = calculateBirthDay(age);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "INSERT INTO `gradetable`(`grade`, `maximumAge`, `Birthday_After`) VALUES ('" + textBox1.Text + "','" + numericUpDown1.Value.ToString() + "','" + correctDate.ToString("yyyy-MM-dd") + "');";
            SqlCon.con.Open();
            cmd.ExecuteNonQuery();
            SqlCon.con.Close();
            updateDatagridview();
            MessageBox.Show("දත්ත ඇතුලත් කරන ලදී","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            textBox1.ResetText();
            numericUpDown1.ResetText();
            }
            else
            {
                MessageBox.Show("ශ්‍රේණියක් ඇතුලත් කරන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
            

        }
         public void updateDatagridview() //this method updates the datagrid view can use after any data changes
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from gradetable;",SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
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
                     String grade = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() ;
                     cmd.CommandText = "DELETE FROM `gradetable` WHERE `grade`='" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "';";
                     cmd.Connection = SqlCon.con;
                     SqlCon.con.Open();
                     cmd.ExecuteNonQuery();
                     SqlCon.con.Close();
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
                  handle_editing(e.RowIndex,dataGridView1);
              }
         }
         private void handle_editing(int row_index,DataGridView dgv)    //this method will handle the editing via another form
         {
             edit_grades eg = new edit_grades(row_index, dgv);
             eg.Show();
             this.Enabled = false;
         }
        
    }
}
