namespace Sisu_Nipunatha
{
    partial class edit_dahampasala
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
            this.cancel_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.landphone_txtbox = new System.Windows.Forms.TextBox();
            this.mobphone_txtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dhmpslName_txtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(260, 123);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(97, 38);
            this.cancel_btn.TabIndex = 19;
            this.cancel_btn.Text = "ඉවත් වන්න";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(380, 123);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(97, 38);
            this.add_btn.TabIndex = 18;
            this.add_btn.Text = "සුරකින්න";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // landphone_txtbox
            // 
            this.landphone_txtbox.Location = new System.Drawing.Point(161, 89);
            this.landphone_txtbox.MaxLength = 10;
            this.landphone_txtbox.Name = "landphone_txtbox";
            this.landphone_txtbox.Size = new System.Drawing.Size(169, 20);
            this.landphone_txtbox.TabIndex = 17;
            this.landphone_txtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.landphone_txtbox_KeyPress);
            // 
            // mobphone_txtbox
            // 
            this.mobphone_txtbox.Location = new System.Drawing.Point(161, 63);
            this.mobphone_txtbox.MaxLength = 10;
            this.mobphone_txtbox.Name = "mobphone_txtbox";
            this.mobphone_txtbox.Size = new System.Drawing.Size(169, 20);
            this.mobphone_txtbox.TabIndex = 16;
            this.mobphone_txtbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mobphone_txtbox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "දුරකථනය-ස්ථාවර";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "දුරකථනය-ජංගම";
            // 
            // dhmpslName_txtbox
            // 
            this.dhmpslName_txtbox.Location = new System.Drawing.Point(161, 33);
            this.dhmpslName_txtbox.Name = "dhmpslName_txtbox";
            this.dhmpslName_txtbox.Size = new System.Drawing.Size(321, 20);
            this.dhmpslName_txtbox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "දහම්පාසලේ නම";
            // 
            // edit_dahampasala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 194);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.landphone_txtbox);
            this.Controls.Add(this.mobphone_txtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dhmpslName_txtbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "edit_dahampasala";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "edit_dahampasala";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.edit_dahampasala_FormClosed);
            this.Load += new System.EventHandler(this.edit_dahampasala_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.TextBox landphone_txtbox;
        private System.Windows.Forms.TextBox mobphone_txtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dhmpslName_txtbox;
        private System.Windows.Forms.Label label1;
    }
}