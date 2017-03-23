namespace PatientBookingSystem.Presenters.MinorElements {
    partial class addStaffMember {
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
            this.doctorsFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.doctorsLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.doctorsPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.staffTypes = new System.Windows.Forms.ComboBox();
            this.staffType = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // doctorsFirstName
            // 
            this.doctorsFirstName.Location = new System.Drawing.Point(347, 136);
            this.doctorsFirstName.Name = "doctorsFirstName";
            this.doctorsFirstName.Size = new System.Drawing.Size(200, 20);
            this.doctorsFirstName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "First name: ";
            // 
            // doctorsLastName
            // 
            this.doctorsLastName.Location = new System.Drawing.Point(347, 167);
            this.doctorsLastName.Name = "doctorsLastName";
            this.doctorsLastName.Size = new System.Drawing.Size(200, 20);
            this.doctorsLastName.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(237, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Last name: ";
            // 
            // doctorsPhoneNumber
            // 
            this.doctorsPhoneNumber.Location = new System.Drawing.Point(347, 198);
            this.doctorsPhoneNumber.Name = "doctorsPhoneNumber";
            this.doctorsPhoneNumber.Size = new System.Drawing.Size(200, 20);
            this.doctorsPhoneNumber.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(242, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Phone no: ";
            // 
            // staffTypes
            // 
            this.staffTypes.FormattingEnabled = true;
            this.staffTypes.Location = new System.Drawing.Point(347, 231);
            this.staffTypes.Name = "staffTypes";
            this.staffTypes.Size = new System.Drawing.Size(200, 21);
            this.staffTypes.TabIndex = 29;
            // 
            // staffType
            // 
            this.staffType.AutoSize = true;
            this.staffType.BackColor = System.Drawing.Color.LightSteelBlue;
            this.staffType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffType.Location = new System.Drawing.Point(243, 231);
            this.staffType.Margin = new System.Windows.Forms.Padding(3);
            this.staffType.Name = "staffType";
            this.staffType.Size = new System.Drawing.Size(76, 17);
            this.staffType.TabIndex = 28;
            this.staffType.Text = "Staff type: ";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(347, 290);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 30;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addStaffMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.staffTypes);
            this.Controls.Add(this.staffType);
            this.Controls.Add(this.doctorsPhoneNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.doctorsLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.doctorsFirstName);
            this.Controls.Add(this.label2);
            this.Name = "addStaffMember";
            this.Size = new System.Drawing.Size(850, 499);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox doctorsFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox doctorsLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox doctorsPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox staffTypes;
        private System.Windows.Forms.Label staffType;
        private System.Windows.Forms.Button saveButton;
    }
}
