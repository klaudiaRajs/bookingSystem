namespace PatientBookingSystem.Presenters.MinorElements {
    partial class addStaffExceptionDay {
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
            this.staffName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.allTheDoctors = new System.Windows.Forms.ComboBox();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.reasonText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.wholeDayCheckBox = new System.Windows.Forms.CheckBox();
            this.singleDayCheckBox = new System.Windows.Forms.CheckBox();
            this.wholeSurgeryCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // staffName
            // 
            this.staffName.AutoSize = true;
            this.staffName.BackColor = System.Drawing.Color.LightSteelBlue;
            this.staffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffName.Location = new System.Drawing.Point(233, 141);
            this.staffName.Margin = new System.Windows.Forms.Padding(3);
            this.staffName.Name = "staffName";
            this.staffName.Size = new System.Drawing.Size(84, 17);
            this.staffName.TabIndex = 16;
            this.staffName.Text = "Staff name: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Start date: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(251, 289);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Reason: ";
            // 
            // allTheDoctors
            // 
            this.allTheDoctors.FormattingEnabled = true;
            this.allTheDoctors.Location = new System.Drawing.Point(361, 137);
            this.allTheDoctors.Name = "allTheDoctors";
            this.allTheDoctors.Size = new System.Drawing.Size(200, 21);
            this.allTheDoctors.TabIndex = 19;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(361, 169);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(84, 20);
            this.startDatePicker.TabIndex = 20;
            this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
            // 
            // reasonText
            // 
            this.reasonText.Location = new System.Drawing.Point(361, 289);
            this.reasonText.Name = "reasonText";
            this.reasonText.Size = new System.Drawing.Size(200, 20);
            this.reasonText.TabIndex = 21;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(361, 333);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(361, 200);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(84, 20);
            this.endDatePicker.TabIndex = 24;
            this.endDatePicker.ValueChanged += new System.EventHandler(this.endDatePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "End date: ";
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(361, 231);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.RightToLeftLayout = true;
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(84, 20);
            this.startTimePicker.TabIndex = 26;
            this.startTimePicker.Value = new System.DateTime(2017, 3, 13, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Start time: ";
            // 
            // endTimePicker
            // 
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimePicker.Location = new System.Drawing.Point(360, 259);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(85, 20);
            this.endTimePicker.TabIndex = 28;
            this.endTimePicker.Value = new System.DateTime(2017, 3, 15, 0, 0, 0, 0);
            this.endTimePicker.ValueChanged += new System.EventHandler(this.endTimePicker_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(246, 259);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "End time: ";
            // 
            // wholeDayCheckBox
            // 
            this.wholeDayCheckBox.AutoSize = true;
            this.wholeDayCheckBox.Location = new System.Drawing.Point(452, 236);
            this.wholeDayCheckBox.Name = "wholeDayCheckBox";
            this.wholeDayCheckBox.Size = new System.Drawing.Size(77, 17);
            this.wholeDayCheckBox.TabIndex = 29;
            this.wholeDayCheckBox.Text = "Whole day";
            this.wholeDayCheckBox.UseVisualStyleBackColor = true;
            this.wholeDayCheckBox.CheckedChanged += new System.EventHandler(this.wholeDayCheckBox_CheckedChanged);
            // 
            // singleDayCheckBox
            // 
            this.singleDayCheckBox.AutoSize = true;
            this.singleDayCheckBox.Location = new System.Drawing.Point(452, 202);
            this.singleDayCheckBox.Name = "singleDayCheckBox";
            this.singleDayCheckBox.Size = new System.Drawing.Size(75, 17);
            this.singleDayCheckBox.TabIndex = 30;
            this.singleDayCheckBox.Text = "Single day";
            this.singleDayCheckBox.UseVisualStyleBackColor = true;
            this.singleDayCheckBox.CheckedChanged += new System.EventHandler(this.singleDayCheckBox_CheckedChanged);
            // 
            // wholeSurgeryCheckBox
            // 
            this.wholeSurgeryCheckBox.AutoSize = true;
            this.wholeSurgeryCheckBox.Location = new System.Drawing.Point(579, 141);
            this.wholeSurgeryCheckBox.Name = "wholeSurgeryCheckBox";
            this.wholeSurgeryCheckBox.Size = new System.Drawing.Size(94, 17);
            this.wholeSurgeryCheckBox.TabIndex = 31;
            this.wholeSurgeryCheckBox.Text = "Whole surgery";
            this.wholeSurgeryCheckBox.UseVisualStyleBackColor = true;
            this.wholeSurgeryCheckBox.CheckedChanged += new System.EventHandler(this.wholeSurgeryCheckBox_CheckedChanged);
            // 
            // addStaffExceptionDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.wholeSurgeryCheckBox);
            this.Controls.Add(this.singleDayCheckBox);
            this.Controls.Add(this.wholeDayCheckBox);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.reasonText);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.allTheDoctors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.staffName);
            this.Name = "addStaffExceptionDay";
            this.Size = new System.Drawing.Size(850, 499);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label staffName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox allTheDoctors;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.TextBox reasonText;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox wholeDayCheckBox;
        private System.Windows.Forms.CheckBox singleDayCheckBox;
        private System.Windows.Forms.CheckBox wholeSurgeryCheckBox;
    }
}
