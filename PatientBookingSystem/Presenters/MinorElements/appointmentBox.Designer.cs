namespace PatientBookingSystem.Presenters.MinorElements {
    partial class appointmentBox {
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
            this.appointmentDateLabel = new System.Windows.Forms.Label();
            this.typeOfAppointmentLabel = new System.Windows.Forms.Label();
            this.doctorsNameLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.printConfirmationButton = new System.Windows.Forms.Button();
            this.cancelAppointmentButton = new System.Windows.Forms.Button();
            this.Reschedule = new System.Windows.Forms.Button();
            this.patientNameLabel = new System.Windows.Forms.Label();
            this.patientLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.attendanceLabel = new System.Windows.Forms.Label();
            this.attendanceStatusLabel = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // appointmentDateLabel
            // 
            this.appointmentDateLabel.AutoSize = true;
            this.appointmentDateLabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.appointmentDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentDateLabel.Location = new System.Drawing.Point(9, 18);
            this.appointmentDateLabel.Margin = new System.Windows.Forms.Padding(3);
            this.appointmentDateLabel.Name = "appointmentDateLabel";
            this.appointmentDateLabel.Size = new System.Drawing.Size(69, 17);
            this.appointmentDateLabel.TabIndex = 16;
            this.appointmentDateLabel.Text = "DateTime";
            // 
            // typeOfAppointmentLabel
            // 
            this.typeOfAppointmentLabel.BackColor = System.Drawing.Color.Silver;
            this.typeOfAppointmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeOfAppointmentLabel.Location = new System.Drawing.Point(175, 41);
            this.typeOfAppointmentLabel.Margin = new System.Windows.Forms.Padding(3);
            this.typeOfAppointmentLabel.Name = "typeOfAppointmentLabel";
            this.typeOfAppointmentLabel.Size = new System.Drawing.Size(148, 17);
            this.typeOfAppointmentLabel.TabIndex = 30;
            this.typeOfAppointmentLabel.Text = "Type of appointment";
            // 
            // doctorsNameLabel
            // 
            this.doctorsNameLabel.BackColor = System.Drawing.Color.Silver;
            this.doctorsNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorsNameLabel.Location = new System.Drawing.Point(175, 64);
            this.doctorsNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.doctorsNameLabel.Name = "doctorsNameLabel";
            this.doctorsNameLabel.Size = new System.Drawing.Size(148, 17);
            this.doctorsNameLabel.TabIndex = 31;
            this.doctorsNameLabel.Text = "Doctor\'s name";
            // 
            // commentLabel
            // 
            this.commentLabel.BackColor = System.Drawing.Color.Silver;
            this.commentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentLabel.Location = new System.Drawing.Point(175, 87);
            this.commentLabel.Margin = new System.Windows.Forms.Padding(3);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(148, 17);
            this.commentLabel.TabIndex = 32;
            this.commentLabel.Text = "Comment";
            // 
            // printConfirmationButton
            // 
            this.printConfirmationButton.AutoSize = true;
            this.printConfirmationButton.Location = new System.Drawing.Point(35, 167);
            this.printConfirmationButton.Name = "printConfirmationButton";
            this.printConfirmationButton.Size = new System.Drawing.Size(98, 23);
            this.printConfirmationButton.TabIndex = 33;
            this.printConfirmationButton.Text = "Print confirmation";
            this.printConfirmationButton.UseVisualStyleBackColor = true;
            this.printConfirmationButton.Click += new System.EventHandler(this.printConfirmationButton_Click);
            // 
            // cancelAppointmentButton
            // 
            this.cancelAppointmentButton.Location = new System.Drawing.Point(220, 167);
            this.cancelAppointmentButton.Name = "cancelAppointmentButton";
            this.cancelAppointmentButton.Size = new System.Drawing.Size(75, 23);
            this.cancelAppointmentButton.TabIndex = 34;
            this.cancelAppointmentButton.Text = "Cancel";
            this.cancelAppointmentButton.UseVisualStyleBackColor = true;
            this.cancelAppointmentButton.Click += new System.EventHandler(this.cancelAppointment_Click);
            // 
            // Reschedule
            // 
            this.Reschedule.Location = new System.Drawing.Point(139, 167);
            this.Reschedule.Name = "Reschedule";
            this.Reschedule.Size = new System.Drawing.Size(75, 23);
            this.Reschedule.TabIndex = 35;
            this.Reschedule.Text = "Reschedule";
            this.Reschedule.UseVisualStyleBackColor = true;
            this.Reschedule.Click += new System.EventHandler(this.Reschedule_Click);
            // 
            // patientNameLabel
            // 
            this.patientNameLabel.BackColor = System.Drawing.Color.Silver;
            this.patientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientNameLabel.Location = new System.Drawing.Point(175, 133);
            this.patientNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.patientNameLabel.Name = "patientNameLabel";
            this.patientNameLabel.Size = new System.Drawing.Size(148, 17);
            this.patientNameLabel.TabIndex = 36;
            this.patientNameLabel.Text = "Patient\'s name";
            this.patientNameLabel.Visible = false;
            // 
            // patientLabel
            // 
            this.patientLabel.BackColor = System.Drawing.Color.Silver;
            this.patientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientLabel.Location = new System.Drawing.Point(9, 133);
            this.patientLabel.Margin = new System.Windows.Forms.Padding(3);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(147, 17);
            this.patientLabel.TabIndex = 40;
            this.patientLabel.Text = "Patient\'s name";
            this.patientLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Comment";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Doctor\'s name";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "Type of appointment: ";
            // 
            // attendanceLabel
            // 
            this.attendanceLabel.BackColor = System.Drawing.Color.Silver;
            this.attendanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendanceLabel.Location = new System.Drawing.Point(9, 110);
            this.attendanceLabel.Margin = new System.Windows.Forms.Padding(3);
            this.attendanceLabel.Name = "attendanceLabel";
            this.attendanceLabel.Size = new System.Drawing.Size(147, 17);
            this.attendanceLabel.TabIndex = 42;
            this.attendanceLabel.Text = "Attendance";
            // 
            // attendanceStatusLabel
            // 
            this.attendanceStatusLabel.BackColor = System.Drawing.Color.Silver;
            this.attendanceStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendanceStatusLabel.Location = new System.Drawing.Point(175, 110);
            this.attendanceStatusLabel.Margin = new System.Windows.Forms.Padding(3);
            this.attendanceStatusLabel.Name = "attendanceStatusLabel";
            this.attendanceStatusLabel.Size = new System.Drawing.Size(148, 17);
            this.attendanceStatusLabel.TabIndex = 41;
            this.attendanceStatusLabel.Text = "Attendance";
            // 
            // editButton
            // 
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.editButton.Location = new System.Drawing.Point(330, 109);
            this.editButton.Margin = new System.Windows.Forms.Padding(0);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(33, 20);
            this.editButton.TabIndex = 43;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Visible = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // appointmentBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.attendanceLabel);
            this.Controls.Add(this.attendanceStatusLabel);
            this.Controls.Add(this.patientLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.patientNameLabel);
            this.Controls.Add(this.Reschedule);
            this.Controls.Add(this.cancelAppointmentButton);
            this.Controls.Add(this.printConfirmationButton);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.doctorsNameLabel);
            this.Controls.Add(this.typeOfAppointmentLabel);
            this.Controls.Add(this.appointmentDateLabel);
            this.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.Name = "appointmentBox";
            this.Size = new System.Drawing.Size(369, 205);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appointmentDateLabel;
        private System.Windows.Forms.Label typeOfAppointmentLabel;
        private System.Windows.Forms.Label doctorsNameLabel;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.Button printConfirmationButton;
        private System.Windows.Forms.Button cancelAppointmentButton;
        private System.Windows.Forms.Button Reschedule;
        private System.Windows.Forms.Label patientNameLabel;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label attendanceLabel;
        private System.Windows.Forms.Label attendanceStatusLabel;
        private System.Windows.Forms.Button editButton;
    }
}
