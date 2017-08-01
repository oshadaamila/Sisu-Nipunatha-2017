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
    public partial class ViewDahamPasalList : Form
    {
        public ViewDahamPasalList()
        {
            InitializeComponent();
        }
        private static ViewDahamPasalList inst3;

        public static ViewDahamPasalList getInstance()
        {
            if (inst3 == null || inst3.IsDisposed)
            {
                inst3 = new ViewDahamPasalList();
                return inst3;
            }
            else
            {
                return inst3;
            }
        }

        private void ViewDahamPasalList_Load(object sender, EventArgs e)
        {
            updateDatagridview();
        }
        public void updateDatagridview()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("Select * from dahampasaltable;",SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewDahampasala adn = new AddNewDahampasala();
            adn.Show();
            this.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                //String dp_ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String dp_name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result= MessageBox.Show(""+dp_name+" ඉවත් කිරීමට අවශ්‍යද?","Delete?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(result==DialogResult.Yes)
                {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "delete from dahampasaltable where name='" + dp_name + "';";
                cmd.Connection = SqlCon.con;
                SqlCon.con.Open();
                cmd.ExecuteNonQuery();
                SqlCon.con.Close();
                MessageBox.Show("තෝරාගත් දහම්පාසල ඉවත් කරන ලදි", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updateDatagridview();
                }
                
            }
            else
            {
                MessageBox.Show("ඉවත් කිරීමට ප්‍රථම දහම්පාසලක් තෝරන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit_dahampasala edit = new edit_dahampasala(dataGridView1);
                edit.Show();
                this.Enabled = false;
            }
            else
            {
                MessageBox.Show("සංස්කරණයට දහම්පාසලක් තෝරන්න!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
