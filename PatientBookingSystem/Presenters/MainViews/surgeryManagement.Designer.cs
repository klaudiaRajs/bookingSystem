namespace PatientBookingSystem.Presenters.MainViews {
    partial class surgeryManagement {
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
            this.managementMenuPanel = new System.Windows.Forms.Panel();
            this.cancelAppointmentButton = new System.Windows.Forms.Label();
            this.addPatient = new System.Windows.Forms.Label();
            this.addExceptionDayForStaffMember = new System.Windows.Forms.Label();
            this.addStaffMember = new System.Windows.Forms.Label();
            this.managementContentPanel = new System.Windows.Forms.Panel();
            this.addScheduleButton = new System.Windows.Forms.Label();
            this.managementMenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // managementMenuPanel
            // 
            this.managementMenuPanel.Controls.Add(this.addScheduleButton);
            this.managementMenuPanel.Controls.Add(this.cancelAppointmentButton);
            this.managementMenuPanel.Controls.Add(this.addPatient);
            this.managementMenuPanel.Controls.Add(this.addExceptionDayForStaffMember);
            this.managementMenuPanel.Controls.Add(this.addStaffMember);
            this.managementMenuPanel.Location = new System.Drawing.Point(2, 0);
            this.managementMenuPanel.Name = "managementMenuPanel";
            this.managementMenuPanel.Size = new System.Drawing.Size(854, 43);
            this.managementMenuPanel.TabIndex = 0;
            // 
            // cancelAppointmentButton
            // 
            this.cancelAppointmentButton.AutoSize = true;
            this.cancelAppointmentButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cancelAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelAppointmentButton.Location = new System.Drawing.Point(495, 13);
            this.cancelAppointmentButton.Margin = new System.Windows.Forms.Padding(3);
            this.cancelAppointmentButton.Name = "cancelAppointmentButton";
            this.cancelAppointmentButton.Size = new System.Drawing.Size(133, 17);
            this.cancelAppointmentButton.TabIndex = 26;
            this.cancelAppointmentButton.Text = "Cancel appointment";
            this.cancelAppointmentButton.Click += new System.EventHandler(this.cancelAppointmentButton_Click);
            // 
            // addPatient
            // 
            this.addPatient.AutoSize = true;
            this.addPatient.BackColor = System.Drawing.Color.LightSteelBlue;
            this.addPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPatient.Location = new System.Drawing.Point(210, 13);
            this.addPatient.Margin = new System.Windows.Forms.Padding(3);
            this.addPatient.Name = "addPatient";
            this.addPatient.Size = new System.Drawing.Size(109, 17);
            this.addPatient.TabIndex = 25;
            this.addPatient.Text = "Add new patient";
            this.addPatient.Click += new System.EventHandler(this.addPatient_Click);
            // 
            // addExceptionDayForStaffMember
            // 
            this.addExceptionDayForStaffMember.AutoSize = true;
            this.addExceptionDayForStaffMember.BackColor = System.Drawing.Color.LightSteelBlue;
            this.addExceptionDayForStaffMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addExceptionDayForStaffMember.Location = new System.Drawing.Point(325, 13);
            this.addExceptionDayForStaffMember.Margin = new System.Windows.Forms.Padding(3);
            this.addExceptionDayForStaffMember.Name = "addExceptionDayForStaffMember";
            this.addExceptionDayForStaffMember.Size = new System.Drawing.Size(164, 17);
            this.addExceptionDayForStaffMember.TabIndex = 23;
            this.addExceptionDayForStaffMember.Text = "Enter exceptional day off";
            this.addExceptionDayForStaffMember.Click += new System.EventHandler(this.addExceptionDayForStaffMember_Click);
            // 
            // addStaffMember
            // 
            this.addStaffMember.AutoSize = true;
            this.addStaffMember.BackColor = System.Drawing.Color.LightSteelBlue;
            this.addStaffMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStaffMember.Location = new System.Drawing.Point(85, 13);
            this.addStaffMember.Margin = new System.Windows.Forms.Padding(3);
            this.addStaffMember.Name = "addStaffMember";
            this.addStaffMember.Size = new System.Drawing.Size(119, 17);
            this.addStaffMember.TabIndex = 22;
            this.addStaffMember.Text = "Add staff member";
            this.addStaffMember.Click += new System.EventHandler(this.addStaffMember_Click);
            // 
            // managementContentPanel
            // 
            this.managementContentPanel.Location = new System.Drawing.Point(3, 49);
            this.managementContentPanel.Name = "managementContentPanel";
            this.managementContentPanel.Size = new System.Drawing.Size(850, 499);
            this.managementContentPanel.TabIndex = 1;
            // 
            // addScheduleButton
            // 
            this.addScheduleButton.AutoSize = true;
            this.addScheduleButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.addScheduleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addScheduleButton.Location = new System.Drawing.Point(634, 13);
            this.addScheduleButton.Margin = new System.Windows.Forms.Padding(3);
            this.addScheduleButton.Name = "addScheduleButton";
            this.addScheduleButton.Size = new System.Drawing.Size(94, 17);
            this.addScheduleButton.TabIndex = 27;
            this.addScheduleButton.Text = "Add schedule";
            this.addScheduleButton.Click += new System.EventHandler(this.addScheduleButton_Click);
            // 
            // surgeryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.managementContentPanel);
            this.Controls.Add(this.managementMenuPanel);
            this.Name = "surgeryManagement";
            this.Size = new System.Drawing.Size(856, 551);
            this.managementMenuPanel.ResumeLayout(false);
            this.managementMenuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel managementMenuPanel;
        private System.Windows.Forms.Panel managementContentPanel;
        private System.Windows.Forms.Label addPatient;
        private System.Windows.Forms.Label addExceptionDayForStaffMember;
        private System.Windows.Forms.Label addStaffMember;
        private System.Windows.Forms.Label cancelAppointmentButton;
        private System.Windows.Forms.Label addScheduleButton;
    }
}
