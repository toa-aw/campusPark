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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxXmlFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFormatData = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtBoxRecievedData
            // 
            this.txtBoxRecievedData.Location = new System.Drawing.Point(10, 70);
            this.txtBoxRecievedData.Multiline = true;
            this.txtBoxRecievedData.Name = "txtBoxRecievedData";
            this.txtBoxRecievedData.Size = new System.Drawing.Size(314, 329);
            this.txtBoxRecievedData.TabIndex = 0;
            // 
            // txtBoxFormatedData
            // 
            this.txtBoxFormatedData.Location = new System.Drawing.Point(386, 70);
            this.txtBoxFormatedData.Multiline = true;
            this.txtBoxFormatedData.Name = "txtBoxFormatedData";
            this.txtBoxFormatedData.Size = new System.Drawing.Size(318, 148);
            this.txtBoxFormatedData.TabIndex = 1;
            this.txtBoxFormatedData.TextChanged += new System.EventHandler(this.txtBoxFormatedData_TextChanged);
            // 
            // lblFormatedData
            // 
            this.lblFormatedData.AutoSize = true;
            this.lblFormatedData.Location = new System.Drawing.Point(384, 53);
            this.lblFormatedData.Name = "lblFormatedData";
            this.lblFormatedData.Size = new System.Drawing.Size(80, 13);
            this.lblFormatedData.TabIndex = 3;
            this.lblFormatedData.Text = "Formated Data:";
            // 
            // lblRecieved
            // 
            this.lblRecieved.AutoSize = true;
            this.lblRecieved.Location = new System.Drawing.Point(10, 53);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(82, 13);
            this.lblRecieved.TabIndex = 4;
            this.lblRecieved.Text = "Recieved Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Configuration File:";
            // 
            // textBoxXmlFile
            // 
            this.textBoxXmlFile.Location = new System.Drawing.Point(109, 26);
            this.textBoxXmlFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxXmlFile.Name = "textBoxXmlFile";
            this.textBoxXmlFile.Size = new System.Drawing.Size(535, 20);
            this.textBoxXmlFile.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(647, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFormatData
            // 
            this.btnFormatData.Location = new System.Drawing.Point(631, 414);
            this.btnFormatData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFormatData.Name = "btnFormatData";
            this.btnFormatData.Size = new System.Drawing.Size(72, 19);
            this.btnFormatData.TabIndex = 8;
            this.btnFormatData.Text = "Format Data";
            this.btnFormatData.UseVisualStyleBackColor = true;
            this.btnFormatData.Click += new System.EventHandler(this.btnFormatData_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(386, 231);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(318, 160);
            this.listBox1.TabIndex = 9;
            // 
            // ParkDACEInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 452);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnFormatData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxXmlFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRecieved);
            this.Controls.Add(this.lblFormatedData);
            this.Controls.Add(this.txtBoxFormatedData);
            this.Controls.Add(this.txtBoxRecievedData);
            this.Name = "ParkDACEInterface";
            this.Text = "ParkDACE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxRecievedData;
        private System.Windows.Forms.TextBox txtBoxFormatedData;
        private System.Windows.Forms.Label lblFormatedData;
        private System.Windows.Forms.Label lblRecieved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxXmlFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFormatData;
        private System.Windows.Forms.ListBox listBox1;
    }
}

