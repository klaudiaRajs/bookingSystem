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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.previousMonthButton = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.nextMonthButton = new System.Windows.Forms.Label();
            this.appointmentDaysPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
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
            this.scheduleHeaderPanel.Controls.Add(this.label7);
            this.scheduleHeaderPanel.Controls.Add(this.flowLayoutPanel1);
            this.scheduleHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.scheduleHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.scheduleHeaderPanel.Name = "scheduleHeaderPanel";
            this.scheduleHeaderPanel.Size = new System.Drawing.Size(856, 72);
            this.scheduleHeaderPanel.TabIndex = 56;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.previousMonthButton);
            this.flowLayoutPanel1.Controls.Add(this.monthLabel);
            this.flowLayoutPanel1.Controls.Add(this.yearLabel);
            this.flowLayoutPanel1.Controls.Add(this.nextMonthButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(426, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(390, 53);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(5, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Home > Find appointment";
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
        private System.Windows.Forms.Label label7;
    }
}
