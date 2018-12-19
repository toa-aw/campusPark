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
            this.lblFormatedData = new System.Windows.Forms.Label();
            this.lblRecieved = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtBoxRecievedData
            // 
            this.txtBoxRecievedData.Location = new System.Drawing.Point(13, 37);
            this.txtBoxRecievedData.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxRecievedData.Multiline = true;
            this.txtBoxRecievedData.Name = "txtBoxRecievedData";
            this.txtBoxRecievedData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxRecievedData.Size = new System.Drawing.Size(417, 500);
            this.txtBoxRecievedData.TabIndex = 0;
            // 
            // lblFormatedData
            // 
            this.lblFormatedData.AutoSize = true;
            this.lblFormatedData.Location = new System.Drawing.Point(438, 9);
            this.lblFormatedData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormatedData.Name = "lblFormatedData";
            this.lblFormatedData.Size = new System.Drawing.Size(106, 17);
            this.lblFormatedData.TabIndex = 3;
            this.lblFormatedData.Text = "Formated Data:";
            // 
            // lblRecieved
            // 
            this.lblRecieved.AutoSize = true;
            this.lblRecieved.Location = new System.Drawing.Point(11, 9);
            this.lblRecieved.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(105, 17);
            this.lblRecieved.TabIndex = 4;
            this.lblRecieved.Text = "Recieved Data:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(445, 37);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(874, 500);
            this.listBox1.TabIndex = 9;
            // 
            // ParkDACEInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 556);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblRecieved);
            this.Controls.Add(this.lblFormatedData);
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
        private System.Windows.Forms.Label lblFormatedData;
        private System.Windows.Forms.Label lblRecieved;
        private System.Windows.Forms.ListBox listBox1;
    }
}

