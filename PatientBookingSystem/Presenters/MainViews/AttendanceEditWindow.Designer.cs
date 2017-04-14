namespace PatientBookingSystem.Presenters.MainViews {
    partial class AttendanceEditWindow {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.patientNameLabel = new System.Windows.Forms.Label();
            this.patientsName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.appointmentDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.attendanceOptions = new System.Windows.Forms.ComboBox();
            this.appointmentTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // patientNameLabel
            // 
            this.patientNameLabel.AutoSize = true;
            this.patientNameLabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.patientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.patientNameLabel.Location = new System.Drawing.Point(50, 22);
            this.patientNameLabel.Name = "patientNameLabel";
            this.patientNameLabel.Size = new System.Drawing.Size(95, 17);
            this.patientNameLabel.TabIndex = 0;
            this.patientNameLabel.Text = "Patient name:";
            // 
            // patientsName
            // 
            this.patientsName.BackColor = System.Drawing.Color.Silver;
            this.patientsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientsName.Location = new System.Drawing.Point(151, 22);
            this.patientsName.Margin = new System.Windows.Forms.Padding(3);
            this.patientsName.Name = "patientsName";
            this.patientsName.Size = new System.Drawing.Size(148, 17);
            this.patientsName.TabIndex = 37;
            this.patientsName.Text = "Patient\'s name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(103, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Date:";
            // 
            // appointmentDate
            // 
            this.appointmentDate.BackColor = System.Drawing.Color.Silver;
            this.appointmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentDate.Location = new System.Drawing.Point(151, 47);
            this.appointmentDate.Margin = new System.Windows.Forms.Padding(3);
            this.appointmentDate.Name = "appointmentDate";
            this.appointmentDate.Size = new System.Drawing.Size(148, 17);
            this.appointmentDate.TabIndex = 39;
            this.appointmentDate.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(65, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Attendance";
            // 
            // attendanceOptions
            // 
            this.attendanceOptions.FormattingEnabled = true;
            this.attendanceOptions.Location = new System.Drawing.Point(151, 100);
            this.attendanceOptions.Name = "attendanceOptions";
            this.attendanceOptions.Size = new System.Drawing.Size(148, 21);
            this.attendanceOptions.TabIndex = 41;
            // 
            // appointmentTime
            // 
            this.appointmentTime.BackColor = System.Drawing.Color.Silver;
            this.appointmentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTime.Location = new System.Drawing.Point(151, 73);
            this.appointmentTime.Margin = new System.Windows.Forms.Padding(3);
            this.appointmentTime.Name = "appointmentTime";
            this.appointmentTime.Size = new System.Drawing.Size(148, 17);
            this.appointmentTime.TabIndex = 43;
            this.appointmentTime.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(103, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 42;
            this.label5.Text = "Time:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(119, 149);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 44;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AttendanceEditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(318, 193);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.appointmentTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.attendanceOptions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.appointmentDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.patientsName);
            this.Controls.Add(this.patientNameLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.Name = "AttendanceEditWindow";
            this.Text = "Edit the attendance";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AttendanceEditWindow_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label patientNameLabel;
        private System.Windows.Forms.Label patientsName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label appointmentDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox attendanceOptions;
        private System.Windows.Forms.Label appointmentTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveButton;
    }
}