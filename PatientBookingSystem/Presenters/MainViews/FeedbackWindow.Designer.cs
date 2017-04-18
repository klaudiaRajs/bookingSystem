namespace PatientBookingSystem.Presenters {
	partial class FeedbackWindow {
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
            this.feedbackMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // feedbackMessage
            // 
            this.feedbackMessage.BackColor = System.Drawing.Color.LightSlateGray;
            this.feedbackMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedbackMessage.Location = new System.Drawing.Point(0, 0);
            this.feedbackMessage.MinimumSize = new System.Drawing.Size(211, 75);
            this.feedbackMessage.Name = "feedbackMessage";
            this.feedbackMessage.Size = new System.Drawing.Size(234, 111);
            this.feedbackMessage.TabIndex = 0;
            this.feedbackMessage.Text = "WRONG!";
            this.feedbackMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FeedbackWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this.feedbackMessage);
            this.ForeColor = System.Drawing.Color.Cornsilk;
            this.MinimumSize = new System.Drawing.Size(250, 114);
            this.Name = "FeedbackWindow";
            this.Text = "FeedbackWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FeedbackWindow_FormClosing);
            this.Shown += new System.EventHandler(this.FeedbackWindow_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyHandler);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label feedbackMessage;
	}
}