namespace ParkDashboard
{
    partial class ParkingSpotsForm
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
            this.listBoxAllSpots = new System.Windows.Forms.ListBox();
            this.textBoxSpotData = new System.Windows.Forms.TextBox();
            this.btnGetAllSpotsForAMoment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPark = new System.Windows.Forms.TextBox();
            this.btnGetSpotsStatusInAPeriod = new System.Windows.Forms.Button();
            this.btnGetFreeSpotsInAMoment = new System.Windows.Forms.Button();
            this.btnGetAllSpotsInAPark = new System.Windows.Forms.Button();
            this.btnGetSpotInfo = new System.Windows.Forms.Button();
            this.btnGetSpotsToBeReplaced = new System.Windows.Forms.Button();
            this.btnGetSpotsToBeReplacedInAPark = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerSpecificDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGreen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parking Spots:";
            // 
            // listBoxAllSpots
            // 
            this.listBoxAllSpots.FormattingEnabled = true;
            this.listBoxAllSpots.ItemHeight = 16;
            this.listBoxAllSpots.Location = new System.Drawing.Point(18, 183);
            this.listBoxAllSpots.Name = "listBoxAllSpots";
            this.listBoxAllSpots.Size = new System.Drawing.Size(471, 260);
            this.listBoxAllSpots.TabIndex = 1;
            // 
            // textBoxSpotData
            // 
            this.textBoxSpotData.Location = new System.Drawing.Point(18, 486);
            this.textBoxSpotData.Multiline = true;
            this.textBoxSpotData.Name = "textBoxSpotData";
            this.textBoxSpotData.Size = new System.Drawing.Size(471, 179);
            this.textBoxSpotData.TabIndex = 2;
            // 
            // btnGetAllSpotsForAMoment
            // 
            this.btnGetAllSpotsForAMoment.Location = new System.Drawing.Point(6, 142);
            this.btnGetAllSpotsForAMoment.Name = "btnGetAllSpotsForAMoment";
            this.btnGetAllSpotsForAMoment.Size = new System.Drawing.Size(376, 30);
            this.btnGetAllSpotsForAMoment.TabIndex = 3;
            this.btnGetAllSpotsForAMoment.Text = "Get All Parking Spots Status For A Given Moment";
            this.btnGetAllSpotsForAMoment.UseVisualStyleBackColor = true;
            this.btnGetAllSpotsForAMoment.Click += new System.EventHandler(this.btnGetAllSpotsForAMoment_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Park:";
            // 
            // textBoxPark
            // 
            this.textBoxPark.Location = new System.Drawing.Point(114, 66);
            this.textBoxPark.Name = "textBoxPark";
            this.textBoxPark.Size = new System.Drawing.Size(276, 22);
            this.textBoxPark.TabIndex = 5;
            // 
            // btnGetSpotsStatusInAPeriod
            // 
            this.btnGetSpotsStatusInAPeriod.Location = new System.Drawing.Point(6, 178);
            this.btnGetSpotsStatusInAPeriod.Name = "btnGetSpotsStatusInAPeriod";
            this.btnGetSpotsStatusInAPeriod.Size = new System.Drawing.Size(376, 30);
            this.btnGetSpotsStatusInAPeriod.TabIndex = 3;
            this.btnGetSpotsStatusInAPeriod.Text = "Get All Parking Spots Status For A Given Period Of Time";
            this.btnGetSpotsStatusInAPeriod.UseVisualStyleBackColor = true;
            this.btnGetSpotsStatusInAPeriod.Click += new System.EventHandler(this.btnGetSpotsStatusInAPeriod_Click);
            // 
            // btnGetFreeSpotsInAMoment
            // 
            this.btnGetFreeSpotsInAMoment.Location = new System.Drawing.Point(6, 214);
            this.btnGetFreeSpotsInAMoment.Name = "btnGetFreeSpotsInAMoment";
            this.btnGetFreeSpotsInAMoment.Size = new System.Drawing.Size(376, 30);
            this.btnGetFreeSpotsInAMoment.TabIndex = 3;
            this.btnGetFreeSpotsInAMoment.Text = "Get Free Parking Spots From A Park In A Given Moment";
            this.btnGetFreeSpotsInAMoment.UseVisualStyleBackColor = true;
            this.btnGetFreeSpotsInAMoment.Click += new System.EventHandler(this.btnGetFreeSpotsInAMoment_Click);
            // 
            // btnGetAllSpotsInAPark
            // 
            this.btnGetAllSpotsInAPark.Location = new System.Drawing.Point(6, 250);
            this.btnGetAllSpotsInAPark.Name = "btnGetAllSpotsInAPark";
            this.btnGetAllSpotsInAPark.Size = new System.Drawing.Size(376, 30);
            this.btnGetAllSpotsInAPark.TabIndex = 3;
            this.btnGetAllSpotsInAPark.Text = "Get All Parking Spots From A Specific Park";
            this.btnGetAllSpotsInAPark.UseVisualStyleBackColor = true;
            this.btnGetAllSpotsInAPark.Click += new System.EventHandler(this.btnGetAllSpotsInAPark_Click);
            // 
            // btnGetSpotInfo
            // 
            this.btnGetSpotInfo.Location = new System.Drawing.Point(6, 286);
            this.btnGetSpotInfo.Name = "btnGetSpotInfo";
            this.btnGetSpotInfo.Size = new System.Drawing.Size(376, 30);
            this.btnGetSpotInfo.TabIndex = 3;
            this.btnGetSpotInfo.Text = "Get Parking Spot Info For A Given Moment";
            this.btnGetSpotInfo.UseVisualStyleBackColor = true;
            this.btnGetSpotInfo.Click += new System.EventHandler(this.btnGetSpotInfo_Click);
            // 
            // btnGetSpotsToBeReplaced
            // 
            this.btnGetSpotsToBeReplaced.Location = new System.Drawing.Point(6, 322);
            this.btnGetSpotsToBeReplaced.Name = "btnGetSpotsToBeReplaced";
            this.btnGetSpotsToBeReplaced.Size = new System.Drawing.Size(376, 30);
            this.btnGetSpotsToBeReplaced.TabIndex = 3;
            this.btnGetSpotsToBeReplaced.Text = "Get Parking Spots To Be Replaced";
            this.btnGetSpotsToBeReplaced.UseVisualStyleBackColor = true;
            this.btnGetSpotsToBeReplaced.Click += new System.EventHandler(this.btnGetSpotsToBeReplaced_Click);
            // 
            // btnGetSpotsToBeReplacedInAPark
            // 
            this.btnGetSpotsToBeReplacedInAPark.Location = new System.Drawing.Point(6, 356);
            this.btnGetSpotsToBeReplacedInAPark.Name = "btnGetSpotsToBeReplacedInAPark";
            this.btnGetSpotsToBeReplacedInAPark.Size = new System.Drawing.Size(376, 30);
            this.btnGetSpotsToBeReplacedInAPark.TabIndex = 3;
            this.btnGetSpotsToBeReplacedInAPark.Text = "Get Parking Spots To Be Replaced In A Specific Park";
            this.btnGetSpotsToBeReplacedInAPark.UseVisualStyleBackColor = true;
            this.btnGetSpotsToBeReplacedInAPark.Click += new System.EventHandler(this.btnGetSpotsToBeReplacedInAPark_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Specific Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Start Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "End Date:";
            // 
            // dateTimePickerSpecificDate
            // 
            this.dateTimePickerSpecificDate.CustomFormat = "dd-MM-yyyy HH:mm:ss tt";
            this.dateTimePickerSpecificDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSpecificDate.Location = new System.Drawing.Point(540, 67);
            this.dateTimePickerSpecificDate.Name = "dateTimePickerSpecificDate";
            this.dateTimePickerSpecificDate.Size = new System.Drawing.Size(275, 22);
            this.dateTimePickerSpecificDate.TabIndex = 18;
            this.dateTimePickerSpecificDate.Value = new System.DateTime(2018, 12, 19, 3, 32, 31, 0);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "dd-MM-yyyy HH:mm:ss tt";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(114, 111);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(276, 22);
            this.dateTimePickerStartDate.TabIndex = 19;
            this.dateTimePickerStartDate.Value = new System.DateTime(2018, 12, 19, 3, 32, 18, 0);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "dd-MM-yyyy HH:mm:ss tt";
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(539, 111);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(276, 22);
            this.dateTimePickerEndDate.TabIndex = 20;
            this.dateTimePickerEndDate.Value = new System.DateTime(2018, 12, 19, 3, 32, 22, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Parking Spots:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Parking Spot Info:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetAllSpotsForAMoment);
            this.groupBox1.Controls.Add(this.btnGetSpotsStatusInAPeriod);
            this.groupBox1.Controls.Add(this.btnGetFreeSpotsInAMoment);
            this.groupBox1.Controls.Add(this.btnGetAllSpotsInAPark);
            this.groupBox1.Controls.Add(this.btnGetSpotInfo);
            this.groupBox1.Controls.Add(this.btnGetSpotsToBeReplaced);
            this.groupBox1.Controls.Add(this.btnGetSpotsToBeReplacedInAPark);
            this.groupBox1.Location = new System.Drawing.Point(515, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 482);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // ParkingSpotsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 677);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.dateTimePickerSpecificDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSpotData);
            this.Controls.Add(this.listBoxAllSpots);
            this.Controls.Add(this.label1);
            this.Name = "ParkingSpotsForm";
            this.Text = "ParkingSpotsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParkingSpotsForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAllSpots;
        private System.Windows.Forms.TextBox textBoxSpotData;
        private System.Windows.Forms.Button btnGetAllSpotsForAMoment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPark;
        private System.Windows.Forms.Button btnGetSpotsStatusInAPeriod;
        private System.Windows.Forms.Button btnGetFreeSpotsInAMoment;
        private System.Windows.Forms.Button btnGetAllSpotsInAPark;
        private System.Windows.Forms.Button btnGetSpotInfo;
        private System.Windows.Forms.Button btnGetSpotsToBeReplaced;
        private System.Windows.Forms.Button btnGetSpotsToBeReplacedInAPark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerSpecificDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}