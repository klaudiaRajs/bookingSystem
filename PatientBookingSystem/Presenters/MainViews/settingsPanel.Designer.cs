namespace PatientBookingSystem {
    partial class settingsPanel {
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.emailConfirmation = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.emailVerification = new System.Windows.Forms.CheckBox();
            this.onThePhoneVerification = new System.Windows.Forms.CheckBox();
            this.confirmationMethodLabel = new System.Windows.Forms.Label();
            this.saveUserSettings = new System.Windows.Forms.Button();
            this.sameDayNotification = new System.Windows.Forms.CheckBox();
            this.oneWeekNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.printableConfirmation = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.emailConfirmation);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.emailVerification);
            this.panel4.Controls.Add(this.onThePhoneVerification);
            this.panel4.Controls.Add(this.confirmationMethodLabel);
            this.panel4.Controls.Add(this.saveUserSettings);
            this.panel4.Controls.Add(this.sameDayNotification);
            this.panel4.Controls.Add(this.oneWeekNotificationCheckBox);
            this.panel4.Controls.Add(this.printableConfirmation);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(856, 551);
            this.panel4.TabIndex = 2;
            // 
            // emailConfirmation
            // 
            this.emailConfirmation.AutoSize = true;
            this.emailConfirmation.Enabled = false;
            this.emailConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailConfirmation.Location = new System.Drawing.Point(306, 222);
            this.emailConfirmation.Name = "emailConfirmation";
            this.emailConfirmation.Size = new System.Drawing.Size(58, 19);
            this.emailConfirmation.TabIndex = 42;
            this.emailConfirmation.Text = "Email";
            this.emailConfirmation.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 18);
            this.label1.TabIndex = 41;
            this.label1.Text = "Booking confirmation";
            // 
            // emailVerification
            // 
            this.emailVerification.AutoSize = true;
            this.emailVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailVerification.Location = new System.Drawing.Point(306, 157);
            this.emailVerification.Name = "emailVerification";
            this.emailVerification.Size = new System.Drawing.Size(58, 19);
            this.emailVerification.TabIndex = 40;
            this.emailVerification.Text = "Email";
            this.emailVerification.UseVisualStyleBackColor = true;
            // 
            // onThePhoneVerification
            // 
            this.onThePhoneVerification.AutoSize = true;
            this.onThePhoneVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onThePhoneVerification.Location = new System.Drawing.Point(306, 132);
            this.onThePhoneVerification.Name = "onThePhoneVerification";
            this.onThePhoneVerification.Size = new System.Drawing.Size(47, 19);
            this.onThePhoneVerification.TabIndex = 39;
            this.onThePhoneVerification.Text = "Call";
            this.onThePhoneVerification.UseVisualStyleBackColor = true;
            // 
            // confirmationMethodLabel
            // 
            this.confirmationMethodLabel.AutoSize = true;
            this.confirmationMethodLabel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.confirmationMethodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmationMethodLabel.Location = new System.Drawing.Point(145, 131);
            this.confirmationMethodLabel.Name = "confirmationMethodLabel";
            this.confirmationMethodLabel.Size = new System.Drawing.Size(134, 18);
            this.confirmationMethodLabel.TabIndex = 38;
            this.confirmationMethodLabel.Text = "Verification method";
            // 
            // saveUserSettings
            // 
            this.saveUserSettings.Location = new System.Drawing.Point(306, 313);
            this.saveUserSettings.Name = "saveUserSettings";
            this.saveUserSettings.Size = new System.Drawing.Size(75, 23);
            this.saveUserSettings.TabIndex = 5;
            this.saveUserSettings.Text = "Save";
            this.saveUserSettings.UseVisualStyleBackColor = true;
            this.saveUserSettings.Click += new System.EventHandler(this.saveUserSettings_Click);
            // 
            // sameDayNotification
            // 
            this.sameDayNotification.AutoSize = true;
            this.sameDayNotification.BackColor = System.Drawing.Color.Transparent;
            this.sameDayNotification.Enabled = false;
            this.sameDayNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sameDayNotification.Location = new System.Drawing.Point(306, 74);
            this.sameDayNotification.Name = "sameDayNotification";
            this.sameDayNotification.Size = new System.Drawing.Size(286, 19);
            this.sameDayNotification.TabIndex = 4;
            this.sameDayNotification.Text = "Upcoming appointments - same day notification";
            this.sameDayNotification.UseVisualStyleBackColor = false;
            // 
            // oneWeekNotificationCheckBox
            // 
            this.oneWeekNotificationCheckBox.AutoSize = true;
            this.oneWeekNotificationCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.oneWeekNotificationCheckBox.Enabled = false;
            this.oneWeekNotificationCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneWeekNotificationCheckBox.Location = new System.Drawing.Point(306, 49);
            this.oneWeekNotificationCheckBox.Name = "oneWeekNotificationCheckBox";
            this.oneWeekNotificationCheckBox.Size = new System.Drawing.Size(272, 19);
            this.oneWeekNotificationCheckBox.TabIndex = 3;
            this.oneWeekNotificationCheckBox.Text = "Upcoming appointments - 1 week notification";
            this.oneWeekNotificationCheckBox.UseVisualStyleBackColor = false;
            // 
            // printableConfirmation
            // 
            this.printableConfirmation.AutoSize = true;
            this.printableConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printableConfirmation.Location = new System.Drawing.Point(306, 247);
            this.printableConfirmation.Name = "printableConfirmation";
            this.printableConfirmation.Size = new System.Drawing.Size(51, 19);
            this.printableConfirmation.TabIndex = 2;
            this.printableConfirmation.Text = "Print";
            this.printableConfirmation.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(159, 48);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 18);
            this.label21.TabIndex = 1;
            this.label21.Text = "Email notification";
            // 
            // settingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.panel4);
            this.Name = "settingsPanel";
            this.Size = new System.Drawing.Size(856, 551);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button saveUserSettings;
        private System.Windows.Forms.CheckBox sameDayNotification;
        private System.Windows.Forms.CheckBox oneWeekNotificationCheckBox;
        private System.Windows.Forms.CheckBox printableConfirmation;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox emailConfirmation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox emailVerification;
        private System.Windows.Forms.CheckBox onThePhoneVerification;
        private System.Windows.Forms.Label confirmationMethodLabel;
    }
}
