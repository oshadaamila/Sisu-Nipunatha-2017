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
            MySqlDataAdapter sda = new MySqlDataAdapter(@"select competitiontable.CompetitionID,competitiontable.competitionName,gradetable.grade
FROM
competitiontable
INNER JOIN
gradetable ON competitiontable.grade=gradetable.gradeID;

;", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
        public String getGradeID(String grade)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "select gradeid from gradetable where grade='" + grade + "'";
            SqlCon.con.Open();
            String gradeID = cmd.ExecuteScalar().ToString();
            SqlCon.con.Close();
            return gradeID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "INSERT INTO `competitiontable`(`CompetitionID`, `competitionName`, `grade`) VALUES ('"+numericUpDown1.Value.ToString()+"','"+textBox1.Text+"','"+getGradeID(comboBox1.SelectedValue.ToString())+"');";
            SqlCon.con.Open();
            cmd.ExecuteNonQuery();
            SqlCon.con.Close();
            updateDatagridview();
        }
    }
}
