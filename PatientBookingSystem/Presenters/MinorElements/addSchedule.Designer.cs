namespace PatientBookingSystem.Presenters.MinorElements {
    partial class addSchedule {
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
            this.label3 = new System.Windows.Forms.Label();
            this.multipleEntries = new System.Windows.Forms.Label();
            this.addScheduleContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(269, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Single entry";
            // 
            // multipleEntries
            // 
            this.multipleEntries.AutoSize = true;
            this.multipleEntries.BackColor = System.Drawing.Color.LightSteelBlue;
            this.multipleEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.multipleEntries.Location = new System.Drawing.Point(434, 18);
            this.multipleEntries.Name = "multipleEntries";
            this.multipleEntries.Size = new System.Drawing.Size(103, 17);
            this.multipleEntries.TabIndex = 7;
            this.multipleEntries.Text = "Multiple entries";
            this.multipleEntries.Click += new System.EventHandler(this.multipleEntries_Click);
            // 
            // addScheduleContent
            // 
            this.addScheduleContent.Location = new System.Drawing.Point(3, 38);
            this.addScheduleContent.Name = "addScheduleContent";
            this.addScheduleContent.Size = new System.Drawing.Size(850, 510);
            this.addScheduleContent.TabIndex = 8;
            // 
            // addSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.addScheduleContent);
            this.Controls.Add(this.multipleEntries);
            this.Controls.Add(this.label3);
            this.Name = "addSchedule";
            this.Size = new System.Drawing.Size(856, 551);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label multipleEntries;
        private System.Windows.Forms.Panel addScheduleContent;
    }
}
