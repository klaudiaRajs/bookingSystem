namespace PatientBookingSystem.Presenters.MinorElements {
    partial class appointmentCancellation {
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
            this.doctorCheck = new System.Windows.Forms.CheckBox();
            this.staffMemberDropDown = new System.Windows.Forms.ComboBox();
            this.patientsDropDown = new System.Windows.Forms.ComboBox();
            this.patientCheck = new System.Windows.Forms.CheckBox();
            this.dateCheck = new System.Windows.Forms.CheckBox();
            this.appointmentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.searchButton = new System.Windows.Forms.Button();
            this.appointmentBoxesContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // doctorCheck
            // 
            this.doctorCheck.AutoSize = true;
            this.doctorCheck.Location = new System.Drawing.Point(114, 36);
            this.doctorCheck.Name = "doctorCheck";
            this.doctorCheck.Size = new System.Drawing.Size(15, 14);
            this.doctorCheck.TabIndex = 0;
            this.doctorCheck.UseVisualStyleBackColor = true;
            this.doctorCheck.CheckedChanged += new System.EventHandler(this.staffMemberCheck_CheckedChanged);
            // 
            // staffMemberDropDown
            // 
            this.staffMemberDropDown.Enabled = false;
            this.staffMemberDropDown.FormattingEnabled = true;
            this.staffMemberDropDown.Location = new System.Drawing.Point(135, 33);
            this.staffMemberDropDown.Name = "staffMemberDropDown";
            this.staffMemberDropDown.Size = new System.Drawing.Size(121, 21);
            this.staffMemberDropDown.TabIndex = 1;
            this.staffMemberDropDown.SelectionChangeCommitted += new System.EventHandler(this.staffMembersDropDown_SelectionChangeCommitted);
            // 
            // patientsDropDown
            // 
            this.patientsDropDown.Enabled = false;
            this.patientsDropDown.FormattingEnabled = true;
            this.patientsDropDown.Location = new System.Drawing.Point(318, 33);
            this.patientsDropDown.Name = "patientsDropDown";
            this.patientsDropDown.Size = new System.Drawing.Size(121, 21);
            this.patientsDropDown.TabIndex = 3;
            this.patientsDropDown.SelectionChangeCommitted += new System.EventHandler(this.patientsDropDown_SelectionChangeCommitted);
            // 
            // patientCheck
            // 
            this.patientCheck.AutoSize = true;
            this.patientCheck.Location = new System.Drawing.Point(297, 36);
            this.patientCheck.Name = "patientCheck";
            this.patientCheck.Size = new System.Drawing.Size(15, 14);
            this.patientCheck.TabIndex = 2;
            this.patientCheck.UseVisualStyleBackColor = true;
            this.patientCheck.CheckedChanged += new System.EventHandler(this.patientCheck_CheckedChanged);
            // 
            // dateCheck
            // 
            this.dateCheck.AutoSize = true;
            this.dateCheck.Location = new System.Drawing.Point(473, 36);
            this.dateCheck.Name = "dateCheck";
            this.dateCheck.Size = new System.Drawing.Size(15, 14);
            this.dateCheck.TabIndex = 4;
            this.dateCheck.UseVisualStyleBackColor = true;
            // 
            // appointmentDatePicker
            // 
            this.appointmentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.appointmentDatePicker.Location = new System.Drawing.Point(494, 34);
            this.appointmentDatePicker.Name = "appointmentDatePicker";
            this.appointmentDatePicker.Size = new System.Drawing.Size(93, 20);
            this.appointmentDatePicker.TabIndex = 5;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(644, 33);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Search!";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // appointmentBoxesContainer
            // 
            this.appointmentBoxesContainer.AutoScroll = true;
            this.appointmentBoxesContainer.Location = new System.Drawing.Point(3, 69);
            this.appointmentBoxesContainer.Name = "appointmentBoxesContainer";
            this.appointmentBoxesContainer.Size = new System.Drawing.Size(844, 427);
            this.appointmentBoxesContainer.TabIndex = 7;
            // 
            // appointmentCancellation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.appointmentBoxesContainer);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.appointmentDatePicker);
            this.Controls.Add(this.dateCheck);
            this.Controls.Add(this.patientsDropDown);
            this.Controls.Add(this.patientCheck);
            this.Controls.Add(this.staffMemberDropDown);
            this.Controls.Add(this.doctorCheck);
            this.Name = "appointmentCancellation";
            this.Size = new System.Drawing.Size(850, 499);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox doctorCheck;
        private System.Windows.Forms.ComboBox staffMemberDropDown;
        private System.Windows.Forms.ComboBox patientsDropDown;
        private System.Windows.Forms.CheckBox patientCheck;
        private System.Windows.Forms.CheckBox dateCheck;
        private System.Windows.Forms.DateTimePicker appointmentDatePicker;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.FlowLayoutPanel appointmentBoxesContainer;
    }
}
