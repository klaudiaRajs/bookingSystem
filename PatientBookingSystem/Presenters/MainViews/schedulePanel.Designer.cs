namespace PatientBookingSystem {
    partial class schedulePanel {
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
            this.scheduleBoxPanel = new System.Windows.Forms.Panel();
            this.scheduleHeaderPanel = new System.Windows.Forms.Panel();
            this.allTheStaffMembers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.afternoonAppointmentsCheckbox = new System.Windows.Forms.CheckBox();
            this.morningAppointmentsCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.previousMonthButton = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.nextMonthButton = new System.Windows.Forms.Label();
            this.appointmentDaysPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.scheduleBoxPanel.SuspendLayout();
            this.scheduleHeaderPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.appointmentDaysPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleBoxPanel
            // 
            this.scheduleBoxPanel.Controls.Add(this.scheduleHeaderPanel);
            this.scheduleBoxPanel.Controls.Add(this.appointmentDaysPanel);
            this.scheduleBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.scheduleBoxPanel.Name = "scheduleBoxPanel";
            this.scheduleBoxPanel.Size = new System.Drawing.Size(856, 551);
            this.scheduleBoxPanel.TabIndex = 49;
            // 
            // scheduleHeaderPanel
            // 
            this.scheduleHeaderPanel.Controls.Add(this.allTheStaffMembers);
            this.scheduleHeaderPanel.Controls.Add(this.label2);
            this.scheduleHeaderPanel.Controls.Add(this.afternoonAppointmentsCheckbox);
            this.scheduleHeaderPanel.Controls.Add(this.morningAppointmentsCheckbox);
            this.scheduleHeaderPanel.Controls.Add(this.label1);
            this.scheduleHeaderPanel.Controls.Add(this.flowLayoutPanel1);
            this.scheduleHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.scheduleHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.scheduleHeaderPanel.Name = "scheduleHeaderPanel";
            this.scheduleHeaderPanel.Size = new System.Drawing.Size(856, 72);
            this.scheduleHeaderPanel.TabIndex = 56;
            // 
            // allTheStaffMembers
            // 
            this.allTheStaffMembers.FormattingEnabled = true;
            this.allTheStaffMembers.Location = new System.Drawing.Point(252, 35);
            this.allTheStaffMembers.Name = "allTheStaffMembers";
            this.allTheStaffMembers.Size = new System.Drawing.Size(121, 21);
            this.allTheStaffMembers.TabIndex = 41;
            this.allTheStaffMembers.SelectedIndexChanged += new System.EventHandler(this.allTheStaffMembers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(182, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Doctor:";
            // 
            // afternoonAppointmentsCheckbox
            // 
            this.afternoonAppointmentsCheckbox.AutoSize = true;
            this.afternoonAppointmentsCheckbox.Location = new System.Drawing.Point(104, 50);
            this.afternoonAppointmentsCheckbox.Name = "afternoonAppointmentsCheckbox";
            this.afternoonAppointmentsCheckbox.Size = new System.Drawing.Size(72, 17);
            this.afternoonAppointmentsCheckbox.TabIndex = 38;
            this.afternoonAppointmentsCheckbox.Text = "Afternoon";
            this.afternoonAppointmentsCheckbox.UseVisualStyleBackColor = true;
            this.afternoonAppointmentsCheckbox.CheckedChanged += new System.EventHandler(this.afternoonAppointmentsCheckbox_CheckedChanged);
            // 
            // morningAppointmentsCheckbox
            // 
            this.morningAppointmentsCheckbox.AutoSize = true;
            this.morningAppointmentsCheckbox.Location = new System.Drawing.Point(104, 31);
            this.morningAppointmentsCheckbox.Name = "morningAppointmentsCheckbox";
            this.morningAppointmentsCheckbox.Size = new System.Drawing.Size(64, 17);
            this.morningAppointmentsCheckbox.TabIndex = 37;
            this.morningAppointmentsCheckbox.Text = "Morning";
            this.morningAppointmentsCheckbox.UseVisualStyleBackColor = true;
            this.morningAppointmentsCheckbox.CheckedChanged += new System.EventHandler(this.morningAppointmentsCheckbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Filter by time:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.previousMonthButton);
            this.flowLayoutPanel1.Controls.Add(this.monthLabel);
            this.flowLayoutPanel1.Controls.Add(this.yearLabel);
            this.flowLayoutPanel1.Controls.Add(this.nextMonthButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(434, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(382, 53);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // previousMonthButton
            // 
            this.previousMonthButton.AutoSize = true;
            this.previousMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.previousMonthButton.Location = new System.Drawing.Point(3, 0);
            this.previousMonthButton.Name = "previousMonthButton";
            this.previousMonthButton.Size = new System.Drawing.Size(43, 46);
            this.previousMonthButton.TabIndex = 32;
            this.previousMonthButton.Text = "<";
            this.previousMonthButton.Click += new System.EventHandler(this.previousMonthButton_Click);
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monthLabel.Location = new System.Drawing.Point(52, 0);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(151, 36);
            this.monthLabel.TabIndex = 33;
            this.monthLabel.Text = "November";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.yearLabel.Location = new System.Drawing.Point(209, 0);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(0, 25);
            this.yearLabel.TabIndex = 55;
            // 
            // nextMonthButton
            // 
            this.nextMonthButton.AutoSize = true;
            this.nextMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextMonthButton.Location = new System.Drawing.Point(215, 0);
            this.nextMonthButton.Name = "nextMonthButton";
            this.nextMonthButton.Size = new System.Drawing.Size(43, 46);
            this.nextMonthButton.TabIndex = 31;
            this.nextMonthButton.Text = ">";
            this.nextMonthButton.Click += new System.EventHandler(this.nextMonthButton_Click);
            // 
            // appointmentDaysPanel
            // 
            this.appointmentDaysPanel.Controls.Add(this.panel5);
            this.appointmentDaysPanel.Location = new System.Drawing.Point(0, 78);
            this.appointmentDaysPanel.Name = "appointmentDaysPanel";
            this.appointmentDaysPanel.Size = new System.Drawing.Size(853, 470);
            this.appointmentDaysPanel.TabIndex = 55;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(0, 0);
            this.panel5.TabIndex = 54;
            // 
            // schedulePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.scheduleBoxPanel);
            this.Name = "schedulePanel";
            this.Size = new System.Drawing.Size(856, 551);
            this.scheduleBoxPanel.ResumeLayout(false);
            this.scheduleHeaderPanel.ResumeLayout(false);
            this.scheduleHeaderPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.appointmentDaysPanel.ResumeLayout(false);
            this.appointmentDaysPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scheduleBoxPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label previousMonthButton;
        private System.Windows.Forms.Label nextMonthButton;
        private System.Windows.Forms.Panel scheduleHeaderPanel;
        private System.Windows.Forms.FlowLayoutPanel appointmentDaysPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.CheckBox afternoonAppointmentsCheckbox;
        private System.Windows.Forms.CheckBox morningAppointmentsCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox allTheStaffMembers;
    }
}
