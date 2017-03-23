namespace PatientBookingSystem.Presenters.MainViews {
    partial class SingleScheduleDay {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timetable = new System.Windows.Forms.DataGridView();
            this.SlotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dateInfoLabel = new System.Windows.Forms.Label();
            this.schedulePerDayPanel1 = new PatientBookingSystem.Presenters.schedulePerDayPanel();
            ((System.ComponentModel.ISupportInitialize)(this.timetable)).BeginInit();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timetable
            // 
            this.timetable.AllowUserToAddRows = false;
            this.timetable.AllowUserToDeleteRows = false;
            this.timetable.AllowUserToResizeColumns = false;
            this.timetable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.timetable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.timetable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.timetable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.timetable.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.timetable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.timetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timetable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlotId,
            this.col1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.timetable.DefaultCellStyle = dataGridViewCellStyle4;
            this.timetable.EnableHeadersVisualStyles = false;
            this.timetable.Location = new System.Drawing.Point(0, 40);
            this.timetable.MultiSelect = false;
            this.timetable.Name = "timetable";
            this.timetable.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.timetable.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.timetable.RowHeadersVisible = false;
            this.timetable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.timetable.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.timetable.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
            this.timetable.ShowCellErrors = false;
            this.timetable.Size = new System.Drawing.Size(477, 598);
            this.timetable.TabIndex = 1;
            // 
            // SlotId
            // 
            this.SlotId.HeaderText = "slotStartTime";
            this.SlotId.Name = "SlotId";
            this.SlotId.ReadOnly = true;
            this.SlotId.Visible = false;
            // 
            // col1
            // 
            this.col1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.col1.DefaultCellStyle = dataGridViewCellStyle3;
            this.col1.HeaderText = "Time";
            this.col1.Name = "col1";
            this.col1.ReadOnly = true;
            // 
            // actionPanel
            // 
            this.actionPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.actionPanel.Controls.Add(this.button1);
            this.actionPanel.Controls.Add(this.dateInfoLabel);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionPanel.Location = new System.Drawing.Point(0, 0);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(477, 40);
            this.actionPanel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateInfoLabel
            // 
            this.dateInfoLabel.AutoSize = true;
            this.dateInfoLabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dateInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInfoLabel.Location = new System.Drawing.Point(3, 12);
            this.dateInfoLabel.Margin = new System.Windows.Forms.Padding(3);
            this.dateInfoLabel.Name = "dateInfoLabel";
            this.dateInfoLabel.Size = new System.Drawing.Size(38, 17);
            this.dateInfoLabel.TabIndex = 9;
            this.dateInfoLabel.Text = "Date";
            // 
            // schedulePerDayPanel1
            // 
            this.schedulePerDayPanel1.AutoScroll = true;
            this.schedulePerDayPanel1.AutoSize = true;
            this.schedulePerDayPanel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.schedulePerDayPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulePerDayPanel1.Location = new System.Drawing.Point(0, 0);
            this.schedulePerDayPanel1.Name = "schedulePerDayPanel1";
            this.schedulePerDayPanel1.Size = new System.Drawing.Size(477, 634);
            this.schedulePerDayPanel1.TabIndex = 0;
            // 
            // SingleScheduleDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(477, 634);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.timetable);
            this.Controls.Add(this.schedulePerDayPanel1);
            this.Name = "SingleScheduleDay";
            this.Text = "SingleScheduleDay";
            ((System.ComponentModel.ISupportInitialize)(this.timetable)).EndInit();
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView timetable;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label dateInfoLabel;
        private schedulePerDayPanel schedulePerDayPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotId;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
    }
}