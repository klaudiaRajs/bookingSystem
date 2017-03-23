namespace PatientBookingSystem {
    partial class upcomingAppointmentsContainer {
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
            this.appointmentsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.surgeryInfoBox1 = new PatientBookingSystem.Presenters.surgeryInfoBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appointmentsContainer
            // 
            this.appointmentsContainer.AutoScroll = true;
            this.appointmentsContainer.Location = new System.Drawing.Point(0, 20);
            this.appointmentsContainer.Name = "appointmentsContainer";
            this.appointmentsContainer.Size = new System.Drawing.Size(853, 377);
            this.appointmentsContainer.TabIndex = 1;
            // 
            // surgeryInfoBox1
            // 
            this.surgeryInfoBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.surgeryInfoBox1.Location = new System.Drawing.Point(603, 398);
            this.surgeryInfoBox1.Name = "surgeryInfoBox1";
            this.surgeryInfoBox1.Size = new System.Drawing.Size(250, 150);
            this.surgeryInfoBox1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Home > Upcoming appointments";
            // 
            // upcomingAppointmentsContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.appointmentsContainer);
            this.Controls.Add(this.surgeryInfoBox1);
            this.Name = "upcomingAppointmentsContainer";
            this.Size = new System.Drawing.Size(856, 551);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Presenters.surgeryInfoBox surgeryInfoBox1;
        private System.Windows.Forms.FlowLayoutPanel appointmentsContainer;
        private System.Windows.Forms.Label label7;
    }
}
