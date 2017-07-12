using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sisu_Nipunatha
{
    public partial class AddNewDahampasala : Form
    {
        public AddNewDahampasala()
        {
            InitializeComponent();
        }

        private void mobphone_txtbox_TextChanged(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(mobphone_txtbox.Text))
            {
                MessageBox.Show("දුරකථන අංකය නැවත පරික්ෂා කරන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void landphone_txtbox_TextChanged(object sender, EventArgs e)
        {
            if (!IsDigitsOnly(landphone_txtbox.Text))
            {
                MessageBox.Show("දුරකථන අංකය නැවත පරික්ෂා කරන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dhmpasalNo_nud_ValueChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from dahampasaltable where DP_ID = '"+dhmpasalNo_nud.Value.ToString()+"';",SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count>0)
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

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (avail_lbl.Text == "Available" && IsDigitsOnly(mobphone_txtbox.Text) && IsDigitsOnly(landphone_txtbox.Text))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = SqlCon.con;
                cmd.CommandText = "INSERT INTO `dahampasaltable`(`DP_ID`, `Name`, `Telephone_Mobile`, `Telephone_Home`) VALUES ('"+dhmpasalNo_nud.Value.ToString()+"','"+dhmpslName_txtbox.Text.ToString()+"','"+mobphone_txtbox.Text+"','"+landphone_txtbox.Text+"'); ";
                SqlCon.con.Open();
                cmd.ExecuteNonQuery();
                SqlCon.con.Close();
                MessageBox.Show("දත්ත ඇතුලත් කරන ලදී!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dhmpasalNo_nud.ResetText();
                dhmpslName_txtbox.ResetText();
                mobphone_txtbox.ResetText();
                landphone_txtbox.ResetText();
            }
            else
            {
                MessageBox.Show("දත්ත නැවත පරික්ෂා කර බලන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewDahampasala_Load(object sender, EventArgs e)
        {
            dhmpasalNo_nud_ValueChanged(sender, e);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }



}
