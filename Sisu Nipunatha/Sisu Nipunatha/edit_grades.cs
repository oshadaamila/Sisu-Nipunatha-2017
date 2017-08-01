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
    public partial class edit_grades : Form
    {
        int row_index;
        DataGridView dgv;
        String loaded_grade;    //for temporary saving the loaded object to editing

        public edit_grades(int row_index,DataGridView dgv)
        {
            InitializeComponent();
            this.row_index = row_index;
            this.dgv = dgv;
            
        }

        private void edit_grades_Load(object sender, EventArgs e)
        {
            //numericUpDown2.Value = Convert.ToDecimal(dgv.Rows[row_index].Cells[2].Value.ToString()); //loading values to respected textboxes for editing
            textBox1.Text = dgv.Rows[row_index].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dgv.Rows[row_index].Cells[3].Value.ToString());
            loaded_grade = textBox1.Text;
        }

        private void edit_grades_FormClosed(object sender, FormClosedEventArgs e)
        {
            gradeList gl = gradeList.getInstance();
            gl.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private String calculateBirthDay(int age)
        {
            int thisYear = DateTime.Today.Year;
            DateTime date = Convert.ToDateTime(""+thisYear+"-01-31");
            DateTime correctDate = date.AddYears(-age);
            return correctDate.ToString("yyyy-MM-dd");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.CommandText = "DELETE FROM `gradetable` WHERE grade= '" + loaded_grade.ToString() + "';";
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.CommandText = "INSERT INTO `gradetable`( `grade`, `maximumAge`, `Birthday_After`) VALUES ('"+textBox1.Text+"','"+numericUpDown1.Value.ToString()+"','"+calculateBirthDay(Convert.ToInt32(numericUpDown1.Value.ToString()))+"');";
            cmd1.Connection = SqlCon.con;
            cmd2.Connection = SqlCon.con;
            SqlCon.con.Open();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            SqlCon.con.Close();
            gradeList gl = gradeList.getInstance();
            gl.updateDatagridview();
            
        }
    }
    
}
