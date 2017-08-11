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
    public partial class select_competition : Form
    {
        public select_competition()
        {
            InitializeComponent();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            comboBox1.DataSource = null;
            String test = "Select * from competitiontable where grade = '"+comboBox2.Text+"';";

            MySqlDataAdapter sda = new MySqlDataAdapter(test, SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox1.ValueMember = "competitionname";

            comboBox1.DisplayMember = "competitionname";
            comboBox1.DataSource = dt;
        }

        private void select_competition_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
           
            comboBox2.DataSource = null;
            String test = "Select * from gradetable ;";

            MySqlDataAdapter sda = new MySqlDataAdapter(test, SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox2.ValueMember = "grade";

            comboBox2.DisplayMember = "grade";
            comboBox2.DataSource = dt;
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }
    }
}
