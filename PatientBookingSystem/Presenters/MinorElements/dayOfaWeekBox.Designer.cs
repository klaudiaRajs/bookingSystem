namespace PatientBookingSystem {
    partial class dayOfaWeekBox {
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
            this.dayNumber = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.numberOfAfternoonAppointmentsLabel = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.numberOfMorningAppointmentsLabel = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.numberOfFreeAppointmentsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dayNumber
            // 
            this.dayNumber.AutoSize = true;
            this.dayNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayNumber.Location = new System.Drawing.Point(67, 3);
            this.dayNumber.Name = "dayNumber";
            this.dayNumber.Size = new System.Drawing.Size(28, 26);
            this.dayNumber.TabIndex = 1;
            this.dayNumber.Text = "D";
            this.dayNumber.Click += new System.EventHandler(this.openSingleDayAppointmentsView_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(3, 32);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 17);
            this.label34.TabIndex = 3;
            this.label34.Text = "Free:";
            this.label34.Click += new System.EventHandler(this.openSingleDayAppointmentsView_Click);
            // 
            // numberOfAfternoonAppointmentsLabel
            // 
            this.numberOfAfternoonAppointmentsLabel.AutoSize = true;
            this.numberOfAfternoonAppointmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfAfternoonAppointmentsLabel.Location = new System.Drawing.Point(73, 71);
            this.numberOfAfternoonAppointmentsLabel.Name = "numberOfAfternoonAppointmentsLabel";
            this.numberOfAfternoonAppointmentsLabel.Size = new System.Drawing.Size(0, 17);
            this.numberOfAfternoonAppointmentsLabel.TabIndex = 9;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(3, 71);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(74, 17);
            this.label32.TabIndex = 8;
            this.label32.Text = "Afternoon:";
            this.label32.Click += new System.EventHandler(this.openSingleDayAppointmentsView_Click);
            // 
            // numberOfMorningAppointmentsLabel
            // 
            this.numberOfMorningAppointmentsLabel.AutoSize = true;
            this.numberOfMorningAppointmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfMorningAppointmentsLabel.Location = new System.Drawing.Point(65, 54);
            this.numberOfMorningAppointmentsLabel.Name = "numberOfMorningAppointmentsLabel";
            this.numberOfMorningAppointmentsLabel.Size = new System.Drawing.Size(0, 17);
            this.numberOfMorningAppointmentsLabel.TabIndex = 7;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(3, 53);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(63, 17);
            this.label35.TabIndex = 6;
            this.label35.Text = "Morning:";
            this.label35.Click += new System.EventHandler(this.openSingleDayAppointmentsView_Click);
            // 
            // numberOfFreeAppointmentsLabel
            // 
            this.numberOfFreeAppointmentsLabel.AutoSize = true;
            this.numberOfFreeAppointmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfFreeAppointmentsLabel.Location = new System.Drawing.Point(47, 32);
            this.numberOfFreeAppointmentsLabel.Name = "numberOfFreeAppointmentsLabel";
            this.numberOfFreeAppointmentsLabel.Size = new System.Drawing.Size(0, 17);
            this.numberOfFreeAppointmentsLabel.TabIndex = 10;
            // 
            // dayOfaWeekBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.numberOfFreeAppointmentsLabel);
            this.Controls.Add(this.numberOfAfternoonAppointmentsLabel);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.numberOfMorningAppointmentsLabel);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.dayNumber);
            this.Name = "dayOfaWeekBox";
            this.Size = new System.Drawing.Size(100, 100);
            this.Click += new System.EventHandler(this.openSingleDayAppointmentsView_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dayNumber;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label numberOfAfternoonAppointmentsLabel;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label numberOfMorningAppointmentsLabel;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label numberOfFreeAppointmentsLabel;
    }
}
