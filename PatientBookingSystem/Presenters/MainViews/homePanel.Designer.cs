namespace PatientBookingSystem {
    partial class homePanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.homeContent = new System.Windows.Forms.Panel();
            this.personalStatistics = new PatientBookingSystem.Presenters.statisticsOverviewBox();
            this.surgeryInfoBox1 = new PatientBookingSystem.Presenters.surgeryInfoBox();
            this.upcomingAppointmentsBox1 = new PatientBookingSystem.Presenters.upcomingAppointmentsBox();
            this.label7 = new System.Windows.Forms.Label();
            this.theMostRecentAppointment = new System.Windows.Forms.Label();
            this.theMostAttendendedNurse = new System.Windows.Forms.Label();
            this.theMostAttendandedDoctor = new System.Windows.Forms.Label();
            this.essentailInformationLabel = new System.Windows.Forms.Label();
            this.homeContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // homeContent
            // 
            this.homeContent.Controls.Add(this.personalStatistics);
            this.homeContent.Controls.Add(this.surgeryInfoBox1);
            this.homeContent.Controls.Add(this.upcomingAppointmentsBox1);
            this.homeContent.Controls.Add(this.label7);
            this.homeContent.Controls.Add(this.theMostRecentAppointment);
            this.homeContent.Controls.Add(this.theMostAttendendedNurse);
            this.homeContent.Controls.Add(this.theMostAttendandedDoctor);
            this.homeContent.Controls.Add(this.essentailInformationLabel);
            this.homeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeContent.Location = new System.Drawing.Point(0, 0);
            this.homeContent.Name = "homeContent";
            this.homeContent.Size = new System.Drawing.Size(856, 551);
            this.homeContent.TabIndex = 3;
            // 
            // personalStatistics
            // 
            this.personalStatistics.BackColor = System.Drawing.Color.LightSlateGray;
            this.personalStatistics.Location = new System.Drawing.Point(78, 303);
            this.personalStatistics.Name = "personalStatistics";
            this.personalStatistics.Size = new System.Drawing.Size(250, 150);
            this.personalStatistics.TabIndex = 41;
            // 
            // surgeryInfoBox1
            // 
            this.surgeryInfoBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.surgeryInfoBox1.Location = new System.Drawing.Point(449, 303);
            this.surgeryInfoBox1.Name = "surgeryInfoBox1";
            this.surgeryInfoBox1.Size = new System.Drawing.Size(250, 150);
            this.surgeryInfoBox1.TabIndex = 40;
            // 
            // upcomingAppointmentsBox1
            // 
            this.upcomingAppointmentsBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.upcomingAppointmentsBox1.Location = new System.Drawing.Point(78, 42);
            this.upcomingAppointmentsBox1.Name = "upcomingAppointmentsBox1";
            this.upcomingAppointmentsBox1.Size = new System.Drawing.Size(230, 140);
            this.upcomingAppointmentsBox1.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(16, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Home";
            // 
            // theMostRecentAppointment
            // 
            this.theMostRecentAppointment.AutoSize = true;
            this.theMostRecentAppointment.BackColor = System.Drawing.Color.Silver;
            this.theMostRecentAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theMostRecentAppointment.Location = new System.Drawing.Point(454, 111);
            this.theMostRecentAppointment.Margin = new System.Windows.Forms.Padding(3);
            this.theMostRecentAppointment.Name = "theMostRecentAppointment";
            this.theMostRecentAppointment.Size = new System.Drawing.Size(125, 17);
            this.theMostRecentAppointment.TabIndex = 38;
            this.theMostRecentAppointment.Text = "Last appointment: ";
            // 
            // theMostAttendendedNurse
            // 
            this.theMostAttendendedNurse.AutoSize = true;
            this.theMostAttendendedNurse.BackColor = System.Drawing.Color.Silver;
            this.theMostAttendendedNurse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theMostAttendendedNurse.Location = new System.Drawing.Point(455, 88);
            this.theMostAttendendedNurse.Margin = new System.Windows.Forms.Padding(3);
            this.theMostAttendendedNurse.Name = "theMostAttendendedNurse";
            this.theMostAttendendedNurse.Size = new System.Drawing.Size(125, 17);
            this.theMostAttendendedNurse.TabIndex = 37;
            this.theMostAttendendedNurse.Text = "Your nurse name: ";
            // 
            // theMostAttendandedDoctor
            // 
            this.theMostAttendandedDoctor.AutoSize = true;
            this.theMostAttendandedDoctor.BackColor = System.Drawing.Color.Silver;
            this.theMostAttendandedDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theMostAttendandedDoctor.Location = new System.Drawing.Point(454, 65);
            this.theMostAttendandedDoctor.Margin = new System.Windows.Forms.Padding(3);
            this.theMostAttendandedDoctor.Name = "theMostAttendandedDoctor";
            this.theMostAttendandedDoctor.Size = new System.Drawing.Size(139, 17);
            this.theMostAttendandedDoctor.TabIndex = 36;
            this.theMostAttendandedDoctor.Text = "Your doctor\'s name: ";
            // 
            // essentailInformationLabel
            // 
            this.essentailInformationLabel.AutoSize = true;
            this.essentailInformationLabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.essentailInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.essentailInformationLabel.Location = new System.Drawing.Point(446, 42);
            this.essentailInformationLabel.Margin = new System.Windows.Forms.Padding(3);
            this.essentailInformationLabel.Name = "essentailInformationLabel";
            this.essentailInformationLabel.Size = new System.Drawing.Size(139, 17);
            this.essentailInformationLabel.TabIndex = 35;
            this.essentailInformationLabel.Text = "Essential information";
            // 
            // homePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.homeContent);
            this.Name = "homePanel";
            this.Size = new System.Drawing.Size(856, 551);
            this.homeContent.ResumeLayout(false);
            this.homeContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel homeContent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label theMostRecentAppointment;
        private System.Windows.Forms.Label theMostAttendendedNurse;
        private System.Windows.Forms.Label theMostAttendandedDoctor;
        private System.Windows.Forms.Label essentailInformationLabel;
        private Presenters.statisticsOverviewBox personalStatistics;
        private Presenters.surgeryInfoBox surgeryInfoBox1;
        private Presenters.upcomingAppointmentsBox upcomingAppointmentsBox1;
    }
}
