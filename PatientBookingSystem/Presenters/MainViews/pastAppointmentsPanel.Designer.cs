namespace PatientBookingSystem.Presenters.MainViews {
    partial class pastAppointmentsPanel {
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
            this.pastAppointmentsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pastAppointmentsContainer
            // 
            this.pastAppointmentsContainer.AutoScroll = true;
            this.pastAppointmentsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pastAppointmentsContainer.Location = new System.Drawing.Point(0, 0);
            this.pastAppointmentsContainer.Name = "pastAppointmentsContainer";
            this.pastAppointmentsContainer.Size = new System.Drawing.Size(856, 551);
            this.pastAppointmentsContainer.TabIndex = 0;
            // 
            // pastAppointmentsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.pastAppointmentsContainer);
            this.Name = "pastAppointmentsPanel";
            this.Size = new System.Drawing.Size(856, 551);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pastAppointmentsContainer;
    }
}
