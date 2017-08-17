﻿using CrystalDecisions.CrystalReports.Engine;
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
    public partial class search_by_competition : Form
    {
        public search_by_competition()
        {
            InitializeComponent();
        }
        private static search_by_competition inst8;
        public DataTable dt1 = new DataTable();

        public static search_by_competition getInstance()
        {
            if (inst8 == null || inst8.IsDisposed)
            {
                inst8 = new search_by_competition();
                return inst8;
            }
            else
            {
                return inst8;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.DataSource = null;
            String test = "Select distinct competitionname from competitiontable;";

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

        private void search_by_competition_Load(object sender, EventArgs e)
        {
            refreshComboBox(comboBox2, "gradetable", "grade");
            refreshcompetitioncombobox();
            updateDataGridView();
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
        public void refreshcompetitioncombobox()
        {
            comboBox1.DataSource = null;
            String test = "Select distinct competitionname from competitiontable;";

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

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            refreshComboBox(comboBox2, "gradetable", "grade");
        }
        public void updateDataGridView()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(@"select studentstable.StudentID,studentstable.Name,studentstable.Birthday,CASE WHEN `overage`= 0 THEN NULL ELSE '****' END AS `overage`  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID WHERE competitiontable.competitionName='" + comboBox1.Text + "' and competitiontable.grade='" + comboBox2.Text + "';", SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridView();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[4,1];
                xlWorkSheet.Cells[3, 2] = "තරග අංකය";
                xlWorkSheet.Cells[3, 3] = "තරගකරුගේ නම";
                xlWorkSheet.Cells[3, 4] = "උපන්දිනය";
                xlWorkSheet.Columns["C"].ColumnWidth = 48;
                xlWorkSheet.Columns["B"].ColumnWidth = 11;
                xlWorkSheet.Columns["D"].ColumnWidth = 15;
                xlWorkSheet.Columns["E"].autofit();
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                
                CR.Font.Size = 13;
                //Microsoft.Office.Interop.Excel.Range BR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.get_Range();
            }
            else
            {
                MessageBox.Show("No Data Selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

    }
}
