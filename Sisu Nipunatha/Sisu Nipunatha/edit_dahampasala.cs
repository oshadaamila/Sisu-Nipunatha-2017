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
    public partial class edit_dahampasala : Form
    {
        DataGridView data;
        String selectedID;
        public edit_dahampasala(DataGridView dgv)
        {
            InitializeComponent();
            this.data = dgv;
            this.selectedID = dgv.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            /*if (avail_lbl.Text != "Available")
            {
                MessageBox.Show("දහම්පාසල් අංකය පරික්ෂා කර බලන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else*/ 
            if (!(mobphone_txtbox.TextLength == 10 || mobphone_txtbox.TextLength == 0))
            {
                MessageBox.Show("ජංගම දුරකථන අංකය පරික්ෂා කර බලන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(landphone_txtbox.TextLength == 10 || landphone_txtbox.TextLength == 0))
            {
                MessageBox.Show("ස්ථාවර දුරකථන අංකය පරික්ෂා කර බලන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd1 = new MySqlCommand("delete from dahampasaltable where Name='" + selectedID + "';",SqlCon.con);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = SqlCon.con;
                cmd.CommandText = "INSERT INTO `dahampasaltable`(`Name`, `Telephone_Mobile`, `Telephone_Home`) VALUES ('" + dhmpslName_txtbox.Text.ToString() + "','" + mobphone_txtbox.Text + "','" + landphone_txtbox.Text + "'); ";
                SqlCon.con.Open();
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                SqlCon.con.Close();
                MessageBox.Show("දත්ත ඇතුලත් කරන ලදී!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewDahamPasalList.getInstance().updateDatagridview();
                //dhmpasalNo_nud.ResetText();
                dhmpslName_txtbox.ResetText();
                mobphone_txtbox.ResetText();
                landphone_txtbox.ResetText();
                this.Close();
            }
        }

        private void edit_dahampasala_Load(object sender, EventArgs e)
        {
            loadData();
            //dhmpasalNo_nud_ValueChanged(sender,e);
        }

        private void loadData()
        {
            //dhmpasalNo_nud.Value = Convert.ToDecimal(data.SelectedRows[0].Cells[0].Value.ToString());
            dhmpslName_txtbox.Text = data.SelectedRows[0].Cells[0].Value.ToString();
            mobphone_txtbox.Text = "0"+data.SelectedRows[0].Cells[1].Value.ToString();
            landphone_txtbox.Text = "0"+data.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void dhmpasalNo_nud_ValueChanged(object sender, EventArgs e)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from dahampasaltable where DP_ID = '" + dhmpasalNo_nud.Value.ToString() + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0 && dhmpasalNo_nud.Value!= Convert.ToDecimal(selectedID))
            {
                avail_lbl.Text = "Unavailable";
                avail_lbl.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                avail_lbl.Text = "Available";
                avail_lbl.ForeColor = System.Drawing.Color.Green;
            }
        }*/
        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void mobphone_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void landphone_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void edit_dahampasala_FormClosed(object sender, FormClosedEventArgs e)
        {
            ViewDahamPasalList vdl = ViewDahamPasalList.getInstance();
            vdl.Enabled = true;
        }
    }
}
