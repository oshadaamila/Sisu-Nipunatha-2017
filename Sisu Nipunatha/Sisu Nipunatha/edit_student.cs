﻿using MySql.Data.MySqlClient;
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
    public partial class edit_student : Form
    {
        int studentID;
        DataTable dt = new DataTable();
        public edit_student(int studentID)
        {
            this.studentID = studentID;
            InitializeComponent();
        }

        private void edit_student_Load(object sender, EventArgs e)
        {
            makeReadOnly();
            MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.address,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.dahampasala  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID where studentstable.studentID='" + studentID.ToString() + "';", SqlCon.con);
            sda.Fill(dt);
            loadvalues();
        }
        private static edit_student inst9;

        public static edit_student getInstance(int studentid)
        {
            if (inst9 == null || inst9.IsDisposed)
            {
                inst9 = new edit_student(studentid);
                return inst9;
            }
            else
            {
                return inst9;
            }
        }
        public void makeReadOnly()
        {
            numericUpDown1.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
            checkBox1.Enabled = false;
            
        }
        public void loadvalues()
        {
            
            numericUpDown1.Value = Convert.ToDecimal(dt.Rows[0][0].ToString());
            textBox1.Text = dt.Rows[0][1].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
            textBox2.Text = dt.Rows[0][3].ToString();
            textBox3.Text = dt.Rows[0][4].ToString();
            comboBox1.Text = dt.Rows[0][5].ToString();
            comboBox2.Text = dt.Rows[0][6].ToString();
            comboBox3.Text = dt.Rows[0][7].ToString();
        }

        private void edit_student_FormClosed(object sender, FormClosedEventArgs e)
        {
            Search_Student ss = Search_Student.getInstance();
            ss.updateDatagridview();
            ss.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Edit")
            {
                if (checkforalreadyediting())
                {
                    MessageBox.Show("එකවර දෙකක් සංස්කරණය කල නොහැක","Error",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
                else
                {
                    numericUpDown1.Enabled = true;
                    button2.Enabled = true;
                    button1.Text = "Cancel";
                }
            }
            else
            {
                numericUpDown1.Enabled = false;
                button2.Enabled = false;
                button1.Text = "Edit";
                numericUpDown1.Value = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            
        }
        public void refreshDaatabel()
        {
            MySqlDataAdapter sda = new MySqlDataAdapter("select studentstable.StudentID,studentstable.Name,studentstable.Birthday,studentstable.address,studentstable.telephone,competitiontable.competitionname,competitiontable.grade,studentstable.dahampasala  FROM studentstable INNER JOIN competitiontable ON studentstable.CompetitionID=competitiontable.CompetitionID where studentstable.studentID='" + studentID.ToString() + "';", SqlCon.con);
            dt.Clear();
            sda.Fill(dt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Edit")
            {
                if (checkforalreadyediting())
                {
                    MessageBox.Show("එකවර දෙකක් සංස්කරණය කල නොහැක", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    textBox1.Enabled = true;
                    textBox1.ReadOnly = false;
                    button3.Enabled = true;
                    button4.Text = "Cancel";
                }
            }
            else
            {
                textBox1.Enabled = false;
                button3.Enabled = false;
                button4.Text = "Edit";
                textBox1.Text= (dt.Rows[0][1].ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Edit")
            {
                if (checkforalreadyediting())
                {
                    MessageBox.Show("එකවර දෙකක් සංස්කරණය කල නොහැක", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    textBox2.Enabled = true;
                    textBox2.ReadOnly = false;
                    button5.Enabled = true;
                    button6.Text = "Cancel";
                }
            }
            else
            {
                textBox2.Enabled = false;
                button5.Enabled = false;
                button6.Text = "Edit";
               textBox2.Text= (dt.Rows[0][3].ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "Edit")
            {
                if (checkforalreadyediting())
                {
                    MessageBox.Show("එකවර දෙකක් සංස්කරණය කල නොහැක", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    dateTimePicker1.Enabled = true;
                    button7.Enabled = true;
                    button8.Text = "Cancel";
                }
            }
            else
            {
                dateTimePicker1.Enabled = false;
                button7.Enabled = false;
                button8.Text = "Edit";
                dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            if (button10.Text == "Edit")
            {
                if (checkforalreadyediting())
                {
                    MessageBox.Show("එකවර දෙකක් සංස්කරණය කල නොහැක", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    textBox3.Enabled = true;
                    textBox3.ReadOnly = false;
                    button9.Enabled = true;
                    button10.Text = "Cancel";
                    checkBox1.Enabled = true;
                }
            }
            else
            {
                textBox3.Enabled = false;
                button9.Enabled = false;
                button10.Text = "Edit";
                checkBox1.Enabled = false;
                textBox3.Text= (dt.Rows[0][4].ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text == "Edit")
            {
                if (checkforalreadyediting())
                {
                    MessageBox.Show("එකවර දෙකක් සංස්කරණය කල නොහැක", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    comboBox1.Enabled = true;
                    button11.Enabled = true;
                    button12.Text = "Cancel";
                }

            }
            else
            {
                comboBox1.Enabled = false;
                button11.Enabled = false;
                button12.Text = "Edit";
                comboBox1.Text = (dt.Rows[0][5].ToString());
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.Text == "Edit")
            {
                if (checkforalreadyediting())
                {
                    MessageBox.Show("එකවර දෙකක් සංස්කරණය කල නොහැක", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    comboBox2.Enabled = true;
                    button13.Enabled = true;
                    button14.Text = "Cancel";
                }
            }
            else
            {
                comboBox2.Enabled = false;
                button13.Enabled = false;
                button14.Text = "Edit";
                comboBox2.Text = (dt.Rows[0][6].ToString());
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.Text == "Edit")
            {
                if (checkforalreadyediting())
                {
                    MessageBox.Show("එකවර දෙකක් සංස්කරණය කල නොහැක", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    comboBox3.Enabled = true;
                    button15.Enabled = true;
                    button16.Text = "Cancel";
                }
            }
            else
            {
                comboBox3.Enabled = false;
                button15.Enabled = false;
                button16.Text = "Edit";
                comboBox3.Text = (dt.Rows[0][7].ToString());
            }
        }

        private bool checkforalreadyediting()
        {
            if (button2.Enabled || button3.Enabled || button5.Enabled || button7.Enabled || button9.Enabled || button11.Enabled || button13.Enabled || button15.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            MySqlDataAdapter sda = new MySqlDataAdapter("select studentID from studentstable where studentID = '" + numericUpDown1.Value.ToString() + "';", SqlCon.con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            if (dt1.Rows.Count > 0)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (avail_lbl.Text == "Unavailable")
            {
                MessageBox.Show("තරග අංකය භාවිතයේ පවතී වෙනත් අංකයක් උත්සාහ කරන්න", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = SqlCon.con;
                cmd.CommandText = "UPDATE `studentstable` SET `StudentID`= '" + numericUpDown1.Value.ToString() + "' WHERE `StudentID`= '"+dt.Rows[0][0].ToString()+"';";
                SqlCon.con.Open();
                cmd.ExecuteNonQuery();
                SqlCon.con.Close();
                studentID = Convert.ToInt32(numericUpDown1.Value.ToString());
                refreshDaatabel();
                button1_Click(sender, e);
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "UPDATE `studentstable` SET `name`= '" + textBox1.Text + "' WHERE `StudentID`= '" + dt.Rows[0][0].ToString() + "';";
            SqlCon.con.Open();
            cmd.ExecuteNonQuery();
            SqlCon.con.Close();
            refreshDaatabel();
            button4_Click(sender, e);
            button3.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "UPDATE `studentstable` SET `address`= '" + textBox2.Text + "' WHERE `StudentID`= '" + dt.Rows[0][0].ToString() + "';";
            SqlCon.con.Open();
            cmd.ExecuteNonQuery();
            SqlCon.con.Close();
            refreshDaatabel();
            button6_Click(sender, e);
            button5.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "UPDATE `studentstable` SET `telephone`= '" + textBox3.Text + "' WHERE `StudentID`= '" + dt.Rows[0][0].ToString() + "';";
            SqlCon.con.Open();
            cmd.ExecuteNonQuery();
            SqlCon.con.Close();
            refreshDaatabel();
            button10_Click(sender, e);
            button9.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DataSource = null;
            String test = "Select * from dahampasaltable;";

            MySqlDataAdapter sda = new MySqlDataAdapter(test, SqlCon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr;
            dr = dt.NewRow();
            dr.ItemArray = new object[] { };

            comboBox3.ValueMember ="name";

            comboBox3.DisplayMember = "name";
            comboBox3.DataSource = dt;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = SqlCon.con;
            cmd.CommandText = "UPDATE `studentstable` SET `dahampasala`= '" + comboBox3.Text + "' WHERE `StudentID`= '" + dt.Rows[0][0].ToString() + "';";
            SqlCon.con.Open();
            cmd.ExecuteNonQuery();
            SqlCon.con.Close();
            refreshDaatabel();
            button16_Click(sender, e);
            button15.Enabled = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

        
}