namespace Sisu_Nipunatha
{
    partial class AddNewDahampasala
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dhmpslName_txtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dhmpasalNo_nud = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mobphone_txtbox = new System.Windows.Forms.TextBox();
            this.landphone_txtbox = new System.Windows.Forms.TextBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.avail_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dhmpasalNo_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "දහම්පාසලේ නම";
            // 
            // dhmpslName_txtbox
            // 
            this.dhmpslName_txtbox.Location = new System.Drawing.Point(164, 43);
            this.dhmpslName_txtbox.Name = "dhmpslName_txtbox";
            this.dhmpslName_txtbox.Size = new System.Drawing.Size(321, 20);
            this.dhmpslName_txtbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "දහම්පාසලේ අංකය";
            // 
            // dhmpasalNo_nud
            // 
            this.dhmpasalNo_nud.Location = new System.Drawing.Point(164, 17);
            this.dhmpasalNo_nud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dhmpasalNo_nud.Name = "dhmpasalNo_nud";
            this.dhmpasalNo_nud.Size = new System.Drawing.Size(120, 20);
            this.dhmpasalNo_nud.TabIndex = 1;
            this.dhmpasalNo_nud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dhmpasalNo_nud.ValueChanged += new System.EventHandler(this.dhmpasalNo_nud_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "දුරකථනය-ජංගම";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "දුරකථනය-ස්ථාවර";
            // 
            // mobphone_txtbox
            // 
            this.mobphone_txtbox.Location = new System.Drawing.Point(164, 73);
            this.mobphone_txtbox.MaxLength = 10;
            this.mobphone_txtbox.Name = "mobphone_txtbox";
            this.mobphone_txtbox.Size = new System.Drawing.Size(169, 20);
            this.mobphone_txtbox.TabIndex = 3;
            this.mobphone_txtbox.TextChanged += new System.EventHandler(this.mobphone_txtbox_TextChanged);
            this.mobphone_txtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mobphone_txtbox_KeyPress);
            // 
            // landphone_txtbox
            // 
            this.landphone_txtbox.Location = new System.Drawing.Point(164, 99);
            this.landphone_txtbox.MaxLength = 10;
            this.landphone_txtbox.Name = "landphone_txtbox";
            this.landphone_txtbox.Size = new System.Drawing.Size(169, 20);
            this.landphone_txtbox.TabIndex = 4;
            this.landphone_txtbox.TextChanged += new System.EventHandler(this.landphone_txtbox_TextChanged);
            this.landphone_txtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.landphone_txtbox_KeyPress);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(376, 133);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(97, 38);
            this.add_btn.TabIndex = 5;
            this.add_btn.Text = "එක් කරන්න";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(263, 133);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(97, 38);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.Text = "ඉවත් වන්න";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // avail_lbl
            // 
            this.avail_lbl.AutoSize = true;
            this.avail_lbl.ForeColor = System.Drawing.Color.Red;
            this.avail_lbl.Location = new System.Drawing.Point(290, 19);
            this.avail_lbl.Name = "avail_lbl";
            this.avail_lbl.Size = new System.Drawing.Size(63, 13);
            this.avail_lbl.TabIndex = 10;
            this.avail_lbl.Text = "Unavailable";
            // 
            // AddNewDahampasala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 183);
            this.Controls.Add(this.avail_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.landphone_txtbox);
            this.Controls.Add(this.mobphone_txtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dhmpasalNo_nud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dhmpslName_txtbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "AddNewDahampasala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "දහම් පාසලක් එක්කරන්න";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewDahampasala_FormClosed);
            this.Load += new System.EventHandler(this.AddNewDahampasala_Load);
            this.Leave += new System.EventHandler(this.AddNewDahampasala_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dhmpasalNo_nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dhmpslName_txtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown dhmpasalNo_nud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mobphone_txtbox;
        private System.Windows.Forms.TextBox landphone_txtbox;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label avail_lbl;
    }
}