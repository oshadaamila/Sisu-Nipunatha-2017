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
    public partial class set_up_database_connection : Form
    {
        public set_up_database_connection()
        {
            InitializeComponent();
        }

        private void set_up_database_connection_Load(object sender, EventArgs e)
        {
            textBox1.Text = SqlCon.server;
            textBox2.Text = SqlCon.database;
            textBox3.Text = SqlCon.username;
            textBox4.Text = SqlCon.password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
