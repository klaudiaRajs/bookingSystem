namespace PatientBookingSystem.Presenters {
    partial class statisticsOverviewBox {
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
            this.appointmentsIgnored = new System.Windows.Forms.Label();
            this.appointmentsCancelled = new System.Windows.Forms.Label();
            this.appointmentsAttendedLate = new System.Windows.Forms.Label();
            this.appointmentAttendedOnTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appointmentsIgnored
            // 
            this.appointmentsIgnored.BackColor = System.Drawing.Color.Silver;
            this.appointmentsIgnored.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsIgnored.Location = new System.Drawing.Point(8, 93);
            this.appointmentsIgnored.Margin = new System.Windows.Forms.Padding(3);
            this.appointmentsIgnored.Name = "appointmentsIgnored";
            this.appointmentsIgnored.Size = new System.Drawing.Size(181, 17);
            this.appointmentsIgnored.TabIndex = 39;
            this.appointmentsIgnored.Text = "Ignored: ";
            // 
            // appointmentsCancelled
            // 
            this.appointmentsCancelled.BackColor = System.Drawing.Color.Silver;
            this.appointmentsCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsCancelled.Location = new System.Drawing.Point(8, 70);
            this.appointmentsCancelled.Margin = new System.Windows.Forms.Padding(3);
            this.appointmentsCancelled.Name = "appointmentsCancelled";
            this.appointmentsCancelled.Size = new System.Drawing.Size(181, 17);
            this.appointmentsCancelled.TabIndex = 38;
            this.appointmentsCancelled.Text = "Cancelled: ";
            // 
            // appointmentsAttendedLate
            // 
            this.appointmentsAttendedLate.BackColor = System.Drawing.Color.Silver;
            this.appointmentsAttendedLate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsAttendedLate.Location = new System.Drawing.Point(8, 47);
            this.appointmentsAttendedLate.Margin = new System.Windows.Forms.Padding(3);
            this.appointmentsAttendedLate.Name = "appointmentsAttendedLate";
            this.appointmentsAttendedLate.Size = new System.Drawing.Size(181, 17);
            this.appointmentsAttendedLate.TabIndex = 37;
            this.appointmentsAttendedLate.Text = "Attended late: ";
            // 
            // appointmentAttendedOnTime
            // 
            this.appointmentAttendedOnTime.BackColor = System.Drawing.Color.Silver;
            this.appointmentAttendedOnTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentAttendedOnTime.Location = new System.Drawing.Point(8, 23);
            this.appointmentAttendedOnTime.Margin = new System.Windows.Forms.Padding(3);
            this.appointmentAttendedOnTime.Name = "appointmentAttendedOnTime";
            this.appointmentAttendedOnTime.Size = new System.Drawing.Size(181, 17);
            this.appointmentAttendedOnTime.TabIndex = 36;
            this.appointmentAttendedOnTime.Text = "Attended on time: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "Your statistics overview";
            // 
            // statisticsOverviewBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.appointmentsIgnored);
            this.Controls.Add(this.appointmentsCancelled);
            this.Controls.Add(this.appointmentsAttendedLate);
            this.Controls.Add(this.appointmentAttendedOnTime);
            this.Controls.Add(this.label11);
            this.Name = "statisticsOverviewBox";
            this.Size = new System.Drawing.Size(250, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appointmentsIgnored;
        private System.Windows.Forms.Label appointmentsCancelled;
        private System.Windows.Forms.Label appointmentsAttendedLate;
        private System.Windows.Forms.Label appointmentAttendedOnTime;
        private System.Windows.Forms.Label label11;
    }
}
