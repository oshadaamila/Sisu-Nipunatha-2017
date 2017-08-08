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
            MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.address,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.overage  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID where studentstable.dahampasala='" + comboBox1.Text + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            refreshComboBox(comboBox1, "dahampasaltable", "name");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDatagridview();
        }
    }
}
