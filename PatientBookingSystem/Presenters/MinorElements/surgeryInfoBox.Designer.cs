namespace PatientBookingSystem.Presenters {
    partial class surgeryInfoBox {
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
            this.surgeryName = new System.Windows.Forms.Label();
            this.surgeryPhoneNumberLabel = new System.Windows.Forms.Label();
            this.secondLineOfAddressLabel = new System.Windows.Forms.Label();
            this.firstLineOfAddressLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // surgeryName
            // 
            this.surgeryName.BackColor = System.Drawing.Color.Silver;
            this.surgeryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surgeryName.Location = new System.Drawing.Point(9, 24);
            this.surgeryName.Margin = new System.Windows.Forms.Padding(3);
            this.surgeryName.Name = "surgeryName";
            this.surgeryName.Size = new System.Drawing.Size(181, 17);
            this.surgeryName.TabIndex = 44;
            this.surgeryName.Text = "Name:";
            // 
            // surgeryPhoneNumberLabel
            // 
            this.surgeryPhoneNumberLabel.BackColor = System.Drawing.Color.Silver;
            this.surgeryPhoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surgeryPhoneNumberLabel.Location = new System.Drawing.Point(9, 93);
            this.surgeryPhoneNumberLabel.Margin = new System.Windows.Forms.Padding(3);
            this.surgeryPhoneNumberLabel.Name = "surgeryPhoneNumberLabel";
            this.surgeryPhoneNumberLabel.Size = new System.Drawing.Size(181, 17);
            this.surgeryPhoneNumberLabel.TabIndex = 43;
            this.surgeryPhoneNumberLabel.Text = "Call: ";
            // 
            // secondLineOfAddressLabel
            // 
            this.secondLineOfAddressLabel.BackColor = System.Drawing.Color.Silver;
            this.secondLineOfAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondLineOfAddressLabel.Location = new System.Drawing.Point(9, 70);
            this.secondLineOfAddressLabel.Margin = new System.Windows.Forms.Padding(3);
            this.secondLineOfAddressLabel.Name = "secondLineOfAddressLabel";
            this.secondLineOfAddressLabel.Size = new System.Drawing.Size(181, 17);
            this.secondLineOfAddressLabel.TabIndex = 42;
            // 
            // firstLineOfAddressLabel
            // 
            this.firstLineOfAddressLabel.BackColor = System.Drawing.Color.Silver;
            this.firstLineOfAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstLineOfAddressLabel.Location = new System.Drawing.Point(9, 47);
            this.firstLineOfAddressLabel.Margin = new System.Windows.Forms.Padding(3);
            this.firstLineOfAddressLabel.Name = "firstLineOfAddressLabel";
            this.firstLineOfAddressLabel.Size = new System.Drawing.Size(181, 17);
            this.firstLineOfAddressLabel.TabIndex = 41;
            this.firstLineOfAddressLabel.Text = "Address: ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1, 1);
            this.label16.Margin = new System.Windows.Forms.Padding(3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 17);
            this.label16.TabIndex = 40;
            this.label16.Text = "Your surgery:";
            // 
            // surgeryInfoBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.surgeryName);
            this.Controls.Add(this.surgeryPhoneNumberLabel);
            this.Controls.Add(this.secondLineOfAddressLabel);
            this.Controls.Add(this.firstLineOfAddressLabel);
            this.Controls.Add(this.label16);
            this.Name = "surgeryInfoBox";
            this.Size = new System.Drawing.Size(250, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label surgeryName;
        private System.Windows.Forms.Label surgeryPhoneNumberLabel;
        private System.Windows.Forms.Label secondLineOfAddressLabel;
        private System.Windows.Forms.Label firstLineOfAddressLabel;
        private System.Windows.Forms.Label label16;
    }
}
