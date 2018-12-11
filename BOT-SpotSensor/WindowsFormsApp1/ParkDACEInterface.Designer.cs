namespace WindowsFormsApp1
{
    partial class ParkDACEInterface
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
            this.txtBoxRecievedData = new System.Windows.Forms.TextBox();
            this.txtBoxFormatedData = new System.Windows.Forms.TextBox();
            this.lblFormatedData = new System.Windows.Forms.Label();
            this.lblRecieved = new System.Windows.Forms.Label();
            this.btnFormatData = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtBoxRecievedData
            // 
            this.txtBoxRecievedData.Location = new System.Drawing.Point(13, 30);
            this.txtBoxRecievedData.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxRecievedData.Multiline = true;
            this.txtBoxRecievedData.Name = "txtBoxRecievedData";
            this.txtBoxRecievedData.Size = new System.Drawing.Size(417, 476);
            this.txtBoxRecievedData.TabIndex = 0;
            // 
            // txtBoxFormatedData
            // 
            this.txtBoxFormatedData.Location = new System.Drawing.Point(552, 13);
            this.txtBoxFormatedData.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxFormatedData.Multiline = true;
            this.txtBoxFormatedData.Name = "txtBoxFormatedData";
            this.txtBoxFormatedData.Size = new System.Drawing.Size(1182, 40);
            this.txtBoxFormatedData.TabIndex = 1;
            // 
            // lblFormatedData
            // 
            this.lblFormatedData.AutoSize = true;
            this.lblFormatedData.Location = new System.Drawing.Point(438, 30);
            this.lblFormatedData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormatedData.Name = "lblFormatedData";
            this.lblFormatedData.Size = new System.Drawing.Size(106, 17);
            this.lblFormatedData.TabIndex = 3;
            this.lblFormatedData.Text = "Formated Data:";
            // 
            // lblRecieved
            // 
            this.lblRecieved.AutoSize = true;
            this.lblRecieved.Location = new System.Drawing.Point(10, 9);
            this.lblRecieved.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(105, 17);
            this.lblRecieved.TabIndex = 4;
            this.lblRecieved.Text = "Recieved Data:";
            // 
            // btnFormatData
            // 
            this.btnFormatData.Location = new System.Drawing.Point(19, 521);
            this.btnFormatData.Name = "btnFormatData";
            this.btnFormatData.Size = new System.Drawing.Size(96, 23);
            this.btnFormatData.TabIndex = 8;
            this.btnFormatData.Text = "Format Data";
            this.btnFormatData.UseVisualStyleBackColor = true;
            this.btnFormatData.Click += new System.EventHandler(this.btnFormatData_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(437, 60);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1298, 196);
            this.listBox1.TabIndex = 9;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(437, 278);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(1298, 228);
            this.listBox2.TabIndex = 10;
            // 
            // ParkDACEInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1747, 556);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnFormatData);
            this.Controls.Add(this.lblRecieved);
            this.Controls.Add(this.lblFormatedData);
            this.Controls.Add(this.txtBoxFormatedData);
            this.Controls.Add(this.txtBoxRecievedData);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ParkDACEInterface";
            this.Text = "ParkDACE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxRecievedData;
        private System.Windows.Forms.TextBox txtBoxFormatedData;
        private System.Windows.Forms.Label lblFormatedData;
        private System.Windows.Forms.Label lblRecieved;
        private System.Windows.Forms.Button btnFormatData;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}

