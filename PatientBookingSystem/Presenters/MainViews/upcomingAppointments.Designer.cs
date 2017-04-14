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
            this.SuspendLayout();
            // 
            // appointmentsContainer
            // 
            this.appointmentsContainer.AutoScroll = true;
            this.appointmentsContainer.Location = new System.Drawing.Point(0, 20);
            this.appointmentsContainer.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.appointmentsContainer.Name = "appointmentsContainer";
            this.appointmentsContainer.Size = new System.Drawing.Size(853, 528);
            this.appointmentsContainer.TabIndex = 1;
            // 
            // upcomingAppointmentsContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.appointmentsContainer);
            this.Name = "upcomingAppointmentsContainer";
            this.Size = new System.Drawing.Size(856, 551);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel appointmentsContainer;
    }
}
