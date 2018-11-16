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
            this.components = new System.ComponentModel.Container();
            this.txtBoxRecievedData = new System.Windows.Forms.TextBox();
            this.txtBoxFormatedData = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblFormatedData = new System.Windows.Forms.Label();
            this.lblRecieved = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxRecievedData
            // 
            this.txtBoxRecievedData.Location = new System.Drawing.Point(12, 46);
            this.txtBoxRecievedData.Multiline = true;
            this.txtBoxRecievedData.Name = "txtBoxRecievedData";
            this.txtBoxRecievedData.Size = new System.Drawing.Size(314, 372);
            this.txtBoxRecievedData.TabIndex = 0;
            // 
            // txtBoxFormatedData
            // 
            this.txtBoxFormatedData.Location = new System.Drawing.Point(387, 46);
            this.txtBoxFormatedData.Multiline = true;
            this.txtBoxFormatedData.Name = "txtBoxFormatedData";
            this.txtBoxFormatedData.Size = new System.Drawing.Size(318, 372);
            this.txtBoxFormatedData.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblFormatedData
            // 
            this.lblFormatedData.AutoSize = true;
            this.lblFormatedData.Location = new System.Drawing.Point(384, 30);
            this.lblFormatedData.Name = "lblFormatedData";
            this.lblFormatedData.Size = new System.Drawing.Size(80, 13);
            this.lblFormatedData.TabIndex = 3;
            this.lblFormatedData.Text = "Formated Data:";
            // 
            // lblRecieved
            // 
            this.lblRecieved.AutoSize = true;
            this.lblRecieved.Location = new System.Drawing.Point(12, 30);
            this.lblRecieved.Name = "lblRecieved";
            this.lblRecieved.Size = new System.Drawing.Size(82, 13);
            this.lblRecieved.TabIndex = 4;
            this.lblRecieved.Text = "Recieved Data:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 452);
            this.Controls.Add(this.lblRecieved);
            this.Controls.Add(this.lblFormatedData);
            this.Controls.Add(this.txtBoxFormatedData);
            this.Controls.Add(this.txtBoxRecievedData);
            this.Name = "Form1";
            this.Text = "ParkDACE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxRecievedData;
        private System.Windows.Forms.TextBox txtBoxFormatedData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblFormatedData;
        private System.Windows.Forms.Label lblRecieved;
    }
}

