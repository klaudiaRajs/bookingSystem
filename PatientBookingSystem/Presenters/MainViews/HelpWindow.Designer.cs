namespace PatientBookingSystem {
    partial class HelpWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpWindow));
            this.contentText = new System.Windows.Forms.RichTextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contentText
            // 
            this.contentText.BackColor = System.Drawing.Color.LightSlateGray;
            this.contentText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentText.ForeColor = System.Drawing.Color.Black;
            this.contentText.Location = new System.Drawing.Point(0, 0);
            this.contentText.Name = "contentText";
            this.contentText.Size = new System.Drawing.Size(284, 261);
            this.contentText.TabIndex = 1;
            this.contentText.Text = resources.GetString("contentText.Text");
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(92, 226);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Close";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // HelpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.contentText);
            this.Name = "HelpWindow";
            this.Text = "Help";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox contentText;
        private System.Windows.Forms.Button exitButton;
    }
}