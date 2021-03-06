﻿using System;
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

        private void තරගයඅනවToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search_by_competition ssbdp = search_by_competition.getInstance();
            ssbdp.MdiParent = this;
            ssbdp.Show();
            ssbdp.WindowState = FormWindowState.Maximized;
            ssbdp.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void සයලලToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_Student ss = Search_Student.getInstance();
            ss.MdiParent = this;
            ss.Show();
            ss.WindowState = FormWindowState.Maximized;
            ss.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void සසකරණයToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //edit_student es = edit_student.getInstance();
            //es.Show();
        }

        private void ඇතලතකරනනToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            Add_results dpl = Add_results.getInstance();
            //dpl.MdiParent = this;
            dpl.Show();
           // dpl.WindowState = FormWindowState.Maximized;
            dpl.FormBorderStyle = FormBorderStyle.FixedSingle;
          
        }

        private void connectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ලකනයToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            View_Results vr = new View_Results();
            vr.Show();
        }

        
        }
    }

