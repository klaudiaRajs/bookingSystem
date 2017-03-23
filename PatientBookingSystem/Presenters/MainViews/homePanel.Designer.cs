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
            this.label7 = new System.Windows.Forms.Label();
            this.theMostRecentAppointment = new System.Windows.Forms.Label();
            this.theMostAttendendedNurse = new System.Windows.Forms.Label();
            this.theMostAttendandedDoctor = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.upcomingAppointmentsBox1 = new PatientBookingSystem.Presenters.upcomingAppointmentsBox();
            this.surgeryInfoBox1 = new PatientBookingSystem.Presenters.surgeryInfoBox();
            this.statisticsOverviewBox1 = new PatientBookingSystem.Presenters.statisticsOverviewBox();
            this.homeContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // homeContent
            // 
            this.homeContent.Controls.Add(this.statisticsOverviewBox1);
            this.homeContent.Controls.Add(this.surgeryInfoBox1);
            this.homeContent.Controls.Add(this.upcomingAppointmentsBox1);
            this.homeContent.Controls.Add(this.label7);
            this.homeContent.Controls.Add(this.theMostRecentAppointment);
            this.homeContent.Controls.Add(this.theMostAttendendedNurse);
            this.homeContent.Controls.Add(this.theMostAttendandedDoctor);
            this.homeContent.Controls.Add(this.label24);
            this.homeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeContent.Location = new System.Drawing.Point(0, 0);
            this.homeContent.Name = "homeContent";
            this.homeContent.Size = new System.Drawing.Size(856, 551);
            this.homeContent.TabIndex = 3;
            this.homeContent.Paint += new System.Windows.Forms.PaintEventHandler(this.homeContent_Paint);
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
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(446, 42);
            this.label24.Margin = new System.Windows.Forms.Padding(3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(139, 17);
            this.label24.TabIndex = 35;
            this.label24.Text = "Essential information";
            // 
            // upcomingAppointmentsBox1
            // 
            this.upcomingAppointmentsBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.upcomingAppointmentsBox1.Location = new System.Drawing.Point(78, 42);
            this.upcomingAppointmentsBox1.Name = "upcomingAppointmentsBox1";
            this.upcomingAppointmentsBox1.Size = new System.Drawing.Size(230, 140);
            this.upcomingAppointmentsBox1.TabIndex = 39;
            // 
            // surgeryInfoBox1
            // 
            this.surgeryInfoBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.surgeryInfoBox1.Location = new System.Drawing.Point(449, 303);
            this.surgeryInfoBox1.Name = "surgeryInfoBox1";
            this.surgeryInfoBox1.Size = new System.Drawing.Size(250, 150);
            this.surgeryInfoBox1.TabIndex = 40;
            // 
            // statisticsOverviewBox1
            // 
            this.statisticsOverviewBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.statisticsOverviewBox1.Location = new System.Drawing.Point(78, 303);
            this.statisticsOverviewBox1.Name = "statisticsOverviewBox1";
            this.statisticsOverviewBox1.Size = new System.Drawing.Size(250, 150);
            this.statisticsOverviewBox1.TabIndex = 41;
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
        private System.Windows.Forms.Label label24;
        private Presenters.statisticsOverviewBox statisticsOverviewBox1;
        private Presenters.surgeryInfoBox surgeryInfoBox1;
        private Presenters.upcomingAppointmentsBox upcomingAppointmentsBox1;
    }
}
