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

        private void ලකනයToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            competition_list cl = competition_list.getInstance();
            cl.MdiParent = this;
            cl.Show();
            cl.WindowState = FormWindowState.Maximized;
            cl.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void දහමපසලToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search_Students_By_Dahampasala ssbdp = Search_Students_By_Dahampasala.getInstance();
            ssbdp.MdiParent = this;
            ssbdp.Show();
            ssbdp.WindowState = FormWindowState.Maximized;
            ssbdp.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void අලතනඑකකරනනToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_new_student ans = Add_new_student.getInstance();
            //ans.MdiParent = this;
            ans.Show();
            //ans.WindowState = FormWindowState.Maximized;
            //ans.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        }
    }

