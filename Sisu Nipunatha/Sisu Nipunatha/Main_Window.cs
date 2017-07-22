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
    public partial class Main_Window : Form
    {
        public Main_Window()
        {
            InitializeComponent();
        }

        private void Main_Window_Load(object sender, EventArgs e)
        {

        }

        private void අලතනඑකකරනනToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewDahampasala and = new AddNewDahampasala();
            and.Show();
        }

        private void ලකනයToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDahamPasalList dpl = ViewDahamPasalList.getInstance();
            dpl.MdiParent = this;
            dpl.Show();
            dpl.WindowState = FormWindowState.Maximized;
            dpl.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ශරණලයසතවToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradeList gl = gradeList.getInstance();
            gl.MdiParent = this;
            gl.Show();
            gl.WindowState = FormWindowState.Maximized;
            gl.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        }
    }

