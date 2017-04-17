namespace PatientBookingSystem.Presenters.MainViews {
    partial class SingleScheduleDayWindow {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timetable = new System.Windows.Forms.DataGridView();
            this.SlotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.dateInfoLabel = new System.Windows.Forms.Label();
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
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Silver;
            this.timetable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.timetable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.timetable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.timetable.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.timetable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.timetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timetable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlotId,
            this.col1});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.timetable.DefaultCellStyle = dataGridViewCellStyle16;
            this.timetable.EnableHeadersVisualStyles = false;
            this.timetable.Location = new System.Drawing.Point(0, 40);
            this.timetable.MultiSelect = false;
            this.timetable.Name = "timetable";
            this.timetable.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.timetable.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.timetable.RowHeadersVisible = false;
            this.timetable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Silver;
            this.timetable.RowsDefaultCellStyle = dataGridViewCellStyle18;
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
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Silver;
            this.col1.DefaultCellStyle = dataGridViewCellStyle15;
            this.col1.HeaderText = "Time";
            this.col1.Name = "col1";
            this.col1.ReadOnly = true;
            // 
            // actionPanel
            // 
            this.actionPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.actionPanel.Controls.Add(this.exitButton);
            this.actionPanel.Controls.Add(this.dateInfoLabel);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionPanel.Location = new System.Drawing.Point(0, 0);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(477, 40);
            this.actionPanel.TabIndex = 2;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(390, 8);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Close";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
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
            // SingleScheduleDayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(477, 634);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.timetable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SingleScheduleDayWindow";
            this.Text = "SingleScheduleDay";
            this.Shown += new System.EventHandler(this.SingleScheduleDayWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.timetable)).EndInit();
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView timetable;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label dateInfoLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotId;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
    }
}