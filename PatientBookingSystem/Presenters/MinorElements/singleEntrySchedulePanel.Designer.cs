namespace PatientBookingSystem.Presenters.MinorElements {
    partial class singleEntrySchedulePanel {
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateToBeScheduled = new System.Windows.Forms.DateTimePicker();
            this.allTheStaffMembers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.workStartTime = new System.Windows.Forms.DateTimePicker();
            this.workEndTime = new System.Windows.Forms.DateTimePicker();
            this.breakStartTime = new System.Windows.Forms.DateTimePicker();
            this.breakEndTime = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.noBreakCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(308, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date: ";
            // 
            // dateToBeScheduled
            // 
            this.dateToBeScheduled.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateToBeScheduled.Location = new System.Drawing.Point(381, 78);
            this.dateToBeScheduled.Name = "dateToBeScheduled";
            this.dateToBeScheduled.Size = new System.Drawing.Size(90, 20);
            this.dateToBeScheduled.TabIndex = 1;
            // 
            // allTheStaffMembers
            // 
            this.allTheStaffMembers.FormattingEnabled = true;
            this.allTheStaffMembers.Location = new System.Drawing.Point(381, 36);
            this.allTheStaffMembers.Name = "allTheStaffMembers";
            this.allTheStaffMembers.Size = new System.Drawing.Size(159, 21);
            this.allTheStaffMembers.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(254, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Staff member: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(278, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start time: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(283, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "End time: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(269, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Break start: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(273, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Break end: ";
            // 
            // workStartTime
            // 
            this.workStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.workStartTime.Location = new System.Drawing.Point(381, 119);
            this.workStartTime.Name = "workStartTime";
            this.workStartTime.ShowUpDown = true;
            this.workStartTime.Size = new System.Drawing.Size(90, 20);
            this.workStartTime.TabIndex = 8;
            this.workStartTime.Value = new System.DateTime(2017, 3, 23, 9, 0, 0, 0);
            // 
            // workEndTime
            // 
            this.workEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.workEndTime.Location = new System.Drawing.Point(381, 160);
            this.workEndTime.Name = "workEndTime";
            this.workEndTime.ShowUpDown = true;
            this.workEndTime.Size = new System.Drawing.Size(90, 20);
            this.workEndTime.TabIndex = 9;
            this.workEndTime.Value = new System.DateTime(2017, 3, 23, 17, 0, 0, 0);
            // 
            // breakStartTime
            // 
            this.breakStartTime.Enabled = false;
            this.breakStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.breakStartTime.Location = new System.Drawing.Point(381, 201);
            this.breakStartTime.Name = "breakStartTime";
            this.breakStartTime.ShowUpDown = true;
            this.breakStartTime.Size = new System.Drawing.Size(90, 20);
            this.breakStartTime.TabIndex = 10;
            this.breakStartTime.Value = new System.DateTime(2017, 3, 23, 12, 0, 0, 0);
            // 
            // breakEndTime
            // 
            this.breakEndTime.Enabled = false;
            this.breakEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.breakEndTime.Location = new System.Drawing.Point(381, 242);
            this.breakEndTime.Name = "breakEndTime";
            this.breakEndTime.ShowUpDown = true;
            this.breakEndTime.Size = new System.Drawing.Size(90, 20);
            this.breakEndTime.TabIndex = 11;
            this.breakEndTime.Value = new System.DateTime(2017, 3, 23, 13, 0, 0, 0);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(381, 303);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // noBreakCheckBox
            // 
            this.noBreakCheckBox.AutoSize = true;
            this.noBreakCheckBox.Checked = true;
            this.noBreakCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noBreakCheckBox.Location = new System.Drawing.Point(495, 204);
            this.noBreakCheckBox.Name = "noBreakCheckBox";
            this.noBreakCheckBox.Size = new System.Drawing.Size(76, 17);
            this.noBreakCheckBox.TabIndex = 14;
            this.noBreakCheckBox.Text = "No break! ";
            this.noBreakCheckBox.UseVisualStyleBackColor = true;
            this.noBreakCheckBox.CheckedChanged += new System.EventHandler(this.noBreakCheckBox_CheckedChanged);
            // 
            // singleEntrySchedulePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.noBreakCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.breakEndTime);
            this.Controls.Add(this.breakStartTime);
            this.Controls.Add(this.workEndTime);
            this.Controls.Add(this.workStartTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.allTheStaffMembers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateToBeScheduled);
            this.Controls.Add(this.label1);
            this.Name = "singleEntrySchedulePanel";
            this.Size = new System.Drawing.Size(850, 503);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateToBeScheduled;
        private System.Windows.Forms.ComboBox allTheStaffMembers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker workStartTime;
        private System.Windows.Forms.DateTimePicker workEndTime;
        private System.Windows.Forms.DateTimePicker breakStartTime;
        private System.Windows.Forms.DateTimePicker breakEndTime;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox noBreakCheckBox;
    }
}
