namespace PatientBookingSystem.Presenters {
    partial class upcomingAppointmentsBox {
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
            this.thirdTheClosestAppointmentLabel = new System.Windows.Forms.Label();
            this.secondTheClosestAppointmentLabel = new System.Windows.Forms.Label();
            this.theClosestAppointmentLabel = new System.Windows.Forms.Label();
            this.upcomingAppointmentsHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // thirdTheClosestAppointmentLabel
            // 
            this.thirdTheClosestAppointmentLabel.BackColor = System.Drawing.Color.Silver;
            this.thirdTheClosestAppointmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thirdTheClosestAppointmentLabel.Location = new System.Drawing.Point(10, 70);
            this.thirdTheClosestAppointmentLabel.Margin = new System.Windows.Forms.Padding(3);
            this.thirdTheClosestAppointmentLabel.Name = "thirdTheClosestAppointmentLabel";
            this.thirdTheClosestAppointmentLabel.Size = new System.Drawing.Size(184, 17);
            this.thirdTheClosestAppointmentLabel.TabIndex = 31;
            this.thirdTheClosestAppointmentLabel.Text = "Thursday, 19th Dec 2016";
            // 
            // secondTheClosestAppointmentLabel
            // 
            this.secondTheClosestAppointmentLabel.BackColor = System.Drawing.Color.Silver;
            this.secondTheClosestAppointmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondTheClosestAppointmentLabel.Location = new System.Drawing.Point(10, 47);
            this.secondTheClosestAppointmentLabel.Margin = new System.Windows.Forms.Padding(3);
            this.secondTheClosestAppointmentLabel.Name = "secondTheClosestAppointmentLabel";
            this.secondTheClosestAppointmentLabel.Size = new System.Drawing.Size(184, 17);
            this.secondTheClosestAppointmentLabel.TabIndex = 30;
            this.secondTheClosestAppointmentLabel.Text = "Thursday, 19th Dec 2016";
            // 
            // theClosestAppointmentLabel
            // 
            this.theClosestAppointmentLabel.BackColor = System.Drawing.Color.Silver;
            this.theClosestAppointmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theClosestAppointmentLabel.Location = new System.Drawing.Point(9, 24);
            this.theClosestAppointmentLabel.Margin = new System.Windows.Forms.Padding(3);
            this.theClosestAppointmentLabel.Name = "theClosestAppointmentLabel";
            this.theClosestAppointmentLabel.Size = new System.Drawing.Size(185, 17);
            this.theClosestAppointmentLabel.TabIndex = 29;
            this.theClosestAppointmentLabel.Text = "Monday, 15th Nov 2015";
            // 
            // upcomingAppointmentsHeader
            // 
            this.upcomingAppointmentsHeader.AutoSize = true;
            this.upcomingAppointmentsHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.upcomingAppointmentsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingAppointmentsHeader.Location = new System.Drawing.Point(1, 1);
            this.upcomingAppointmentsHeader.Margin = new System.Windows.Forms.Padding(3);
            this.upcomingAppointmentsHeader.Name = "upcomingAppointmentsHeader";
            this.upcomingAppointmentsHeader.Size = new System.Drawing.Size(160, 17);
            this.upcomingAppointmentsHeader.TabIndex = 28;
            this.upcomingAppointmentsHeader.Text = "Upcoming appointments";
            // 
            // upcomingAppointmentsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.thirdTheClosestAppointmentLabel);
            this.Controls.Add(this.secondTheClosestAppointmentLabel);
            this.Controls.Add(this.theClosestAppointmentLabel);
            this.Controls.Add(this.upcomingAppointmentsHeader);
            this.Name = "upcomingAppointmentsBox";
            this.Size = new System.Drawing.Size(230, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label thirdTheClosestAppointmentLabel;
        private System.Windows.Forms.Label secondTheClosestAppointmentLabel;
        private System.Windows.Forms.Label theClosestAppointmentLabel;
        private System.Windows.Forms.Label upcomingAppointmentsHeader;
    }
}
