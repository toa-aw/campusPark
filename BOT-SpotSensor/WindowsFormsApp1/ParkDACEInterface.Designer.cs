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
            this.txtBoxRecievedData.Location = new System.Drawing.Point(13, 86);
            this.txtBoxRecievedData.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxRecievedData.Multiline = true;
            this.txtBoxRecievedData.Name = "txtBoxRecievedData";
            this.txtBoxRecievedData.Size = new System.Drawing.Size(417, 404);
            this.txtBoxRecievedData.TabIndex = 0;
            // 
            // txtBoxFormatedData
            // 
            this.txtBoxFormatedData.Location = new System.Drawing.Point(515, 86);
            this.txtBoxFormatedData.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxFormatedData.Multiline = true;
            this.txtBoxFormatedData.Name = "txtBoxFormatedData";
            this.txtBoxFormatedData.Size = new System.Drawing.Size(422, 181);
            this.txtBoxFormatedData.TabIndex = 1;
            // 
            // lblFormatedData
            // 
            this.lblFormatedData.AutoSize = true;
            this.lblFormatedData.Location = new System.Drawing.Point(512, 65);
            this.lblFormatedData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormatedData.Name = "lblFormatedData";
            this.lblFormatedData.Size = new System.Drawing.Size(106, 17);
            this.lblFormatedData.TabIndex = 3;
            this.lblFormatedData.Text = "Formated Data:";
            // 
            // lblRecieved
            // 
            this.lblRecieved.AutoSize = true;
            this.lblRecieved.Location = new System.Drawing.Point(13, 65);
            this.lblRecieved.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(105, 17);
            this.lblRecieved.TabIndex = 4;
            this.lblRecieved.Text = "Recieved Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Configuration File:";
            // 
            // textBoxXmlFile
            // 
            this.textBoxXmlFile.Location = new System.Drawing.Point(145, 32);
            this.textBoxXmlFile.Name = "textBoxXmlFile";
            this.textBoxXmlFile.Size = new System.Drawing.Size(712, 22);
            this.textBoxXmlFile.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(863, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
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
            this.btnFormatData.Location = new System.Drawing.Point(841, 509);
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
            this.listBox1.Location = new System.Drawing.Point(515, 284);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(422, 196);
            this.listBox1.TabIndex = 9;
            // 
            // ParkDACEInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 556);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnFormatData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxXmlFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRecieved);
            this.Controls.Add(this.lblFormatedData);
            this.Controls.Add(this.txtBoxFormatedData);
            this.Controls.Add(this.txtBoxRecievedData);
            this.Margin = new System.Windows.Forms.Padding(4);
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

