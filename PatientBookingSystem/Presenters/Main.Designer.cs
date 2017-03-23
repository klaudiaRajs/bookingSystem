namespace PatientBookingSystem
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.logInButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.loginField = new System.Windows.Forms.TextBox();
            this.LogInPanel = new System.Windows.Forms.Panel();
            this.HomePanel = new System.Windows.Forms.Panel();
            this.windowContentContainer = new System.Windows.Forms.Panel();
            this.dockOfHeader = new System.Windows.Forms.Panel();
            this.leftPanelContainer = new System.Windows.Forms.Panel();
            this.LogInPanel.SuspendLayout();
            this.HomePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(202, 133);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(121, 133);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 12;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(40, 133);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(75, 23);
            this.logInButton.TabIndex = 11;
            this.logInButton.Text = "Log in";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Login";
            // 
            // passwordField
            // 
            this.passwordField.BackColor = System.Drawing.SystemColors.MenuBar;
            this.passwordField.Location = new System.Drawing.Point(106, 82);
            this.passwordField.Name = "passwordField";
            this.passwordField.Size = new System.Drawing.Size(151, 20);
            this.passwordField.TabIndex = 8;
            this.passwordField.UseSystemPasswordChar = true;
            this.passwordField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginField_KeyDown);
            // 
            // loginField
            // 
            this.loginField.BackColor = System.Drawing.SystemColors.MenuBar;
            this.loginField.Location = new System.Drawing.Point(106, 45);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(151, 20);
            this.loginField.TabIndex = 7;
            this.loginField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginField_KeyDown);
            // 
            // LogInPanel
            // 
            this.LogInPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.LogInPanel.Controls.Add(this.loginField);
            this.LogInPanel.Controls.Add(this.exitButton);
            this.LogInPanel.Controls.Add(this.passwordField);
            this.LogInPanel.Controls.Add(this.helpButton);
            this.LogInPanel.Controls.Add(this.label1);
            this.LogInPanel.Controls.Add(this.logInButton);
            this.LogInPanel.Controls.Add(this.label2);
            this.LogInPanel.Location = new System.Drawing.Point(0, 0);
            this.LogInPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LogInPanel.Name = "LogInPanel";
            this.LogInPanel.Size = new System.Drawing.Size(300, 210);
            this.LogInPanel.TabIndex = 14;
            this.LogInPanel.Visible = false;
            // 
            // HomePanel
            // 
            this.HomePanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.HomePanel.Controls.Add(this.windowContentContainer);
            this.HomePanel.Controls.Add(this.dockOfHeader);
            this.HomePanel.Controls.Add(this.leftPanelContainer);
            this.HomePanel.Location = new System.Drawing.Point(0, 0);
            this.HomePanel.Name = "HomePanel";
            this.HomePanel.Size = new System.Drawing.Size(1081, 651);
            this.HomePanel.TabIndex = 15;
            // 
            // windowContentContainer
            // 
            this.windowContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowContentContainer.Location = new System.Drawing.Point(225, 100);
            this.windowContentContainer.Name = "windowContentContainer";
            this.windowContentContainer.Size = new System.Drawing.Size(856, 551);
            this.windowContentContainer.TabIndex = 2;
            // 
            // dockOfHeader
            // 
            this.dockOfHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockOfHeader.Location = new System.Drawing.Point(225, 0);
            this.dockOfHeader.Name = "dockOfHeader";
            this.dockOfHeader.Size = new System.Drawing.Size(856, 100);
            this.dockOfHeader.TabIndex = 1;
            // 
            // leftPanelContainer
            // 
            this.leftPanelContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanelContainer.Location = new System.Drawing.Point(0, 0);
            this.leftPanelContainer.Name = "leftPanelContainer";
            this.leftPanelContainer.Size = new System.Drawing.Size(225, 651);
            this.leftPanelContainer.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1087, 656);
            this.Controls.Add(this.HomePanel);
            this.Controls.Add(this.LogInPanel);
            this.Name = "Main";
            this.Text = "PBS";
            this.LogInPanel.ResumeLayout(false);
            this.LogInPanel.PerformLayout();
            this.HomePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.Panel LogInPanel;
        private System.Windows.Forms.Panel HomePanel;
        private System.Windows.Forms.Panel windowContentContainer;
        private System.Windows.Forms.Panel dockOfHeader;
        private System.Windows.Forms.Panel leftPanelContainer;
    }
}

