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
            updateDataGridView();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.ResetText();
            MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.address,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID where studentstable.studentID='" + numericUpDown1.Value.ToString() + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            numericUpDown1.ResetText();
            MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.address,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID where studentstable.name='"+textBox1.Text + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
        public void updateDataGridView()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.address,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID;", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}
