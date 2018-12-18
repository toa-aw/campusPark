﻿namespace ParkDashboard
{
    partial class ParksForm
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
            this.btnGetAllParks = new System.Windows.Forms.Button();
            this.listBoxAllParks = new System.Windows.Forms.ListBox();
            this.btnGetParkInfo = new System.Windows.Forms.Button();
            this.textBoxOccupancyRate = new System.Windows.Forms.TextBox();
            this.textBoxParkInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetOccupancyRate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetAllParks
            // 
            this.btnGetAllParks.Location = new System.Drawing.Point(13, 56);
            this.btnGetAllParks.Name = "btnGetAllParks";
            this.btnGetAllParks.Size = new System.Drawing.Size(99, 23);
            this.btnGetAllParks.TabIndex = 0;
            this.btnGetAllParks.Text = "Get All Parks";
            this.btnGetAllParks.UseVisualStyleBackColor = true;
            this.btnGetAllParks.Click += new System.EventHandler(this.btnGetAllParks_Click);
            // 
            // listBoxAllParks
            // 
            this.listBoxAllParks.FormattingEnabled = true;
            this.listBoxAllParks.ItemHeight = 16;
            this.listBoxAllParks.Location = new System.Drawing.Point(13, 85);
            this.listBoxAllParks.Name = "listBoxAllParks";
            this.listBoxAllParks.Size = new System.Drawing.Size(363, 164);
            this.listBoxAllParks.TabIndex = 1;
            // 
            // btnGetParkInfo
            // 
            this.btnGetParkInfo.Location = new System.Drawing.Point(398, 56);
            this.btnGetParkInfo.Name = "btnGetParkInfo";
            this.btnGetParkInfo.Size = new System.Drawing.Size(101, 23);
            this.btnGetParkInfo.TabIndex = 2;
            this.btnGetParkInfo.Text = "Get Park Info";
            this.btnGetParkInfo.UseVisualStyleBackColor = true;
            // 
            // textBoxOccupancyRate
            // 
            this.textBoxOccupancyRate.Location = new System.Drawing.Point(12, 290);
            this.textBoxOccupancyRate.Name = "textBoxOccupancyRate";
            this.textBoxOccupancyRate.Size = new System.Drawing.Size(364, 22);
            this.textBoxOccupancyRate.TabIndex = 3;
            // 
            // textBoxParkInfo
            // 
            this.textBoxParkInfo.Location = new System.Drawing.Point(398, 85);
            this.textBoxParkInfo.Multiline = true;
            this.textBoxParkInfo.Name = "textBoxParkInfo";
            this.textBoxParkInfo.Size = new System.Drawing.Size(390, 164);
            this.textBoxParkInfo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Parks:";
            // 
            // btnGetOccupancyRate
            // 
            this.btnGetOccupancyRate.Location = new System.Drawing.Point(12, 318);
            this.btnGetOccupancyRate.Name = "btnGetOccupancyRate";
            this.btnGetOccupancyRate.Size = new System.Drawing.Size(150, 27);
            this.btnGetOccupancyRate.TabIndex = 6;
            this.btnGetOccupancyRate.Text = "Get Occupancy Rate";
            this.btnGetOccupancyRate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Occupancy Rate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetOccupancyRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxParkInfo);
            this.Controls.Add(this.textBoxOccupancyRate);
            this.Controls.Add(this.btnGetParkInfo);
            this.Controls.Add(this.listBoxAllParks);
            this.Controls.Add(this.btnGetAllParks);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetAllParks;
        private System.Windows.Forms.ListBox listBoxAllParks;
        private System.Windows.Forms.Button btnGetParkInfo;
        private System.Windows.Forms.TextBox textBoxOccupancyRate;
        private System.Windows.Forms.TextBox textBoxParkInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetOccupancyRate;
        private System.Windows.Forms.Label label2;
    }
}

