namespace AppProj.View
{
    partial class RegisterForm
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
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.firstNameConfirmationLabel = new System.Windows.Forms.Label();
            this.lastNameConfirmationLabel = new System.Windows.Forms.Label();
            this.usernameConfirmationLabel = new System.Windows.Forms.Label();
            this.passwordConfirmationLabel = new System.Windows.Forms.Label();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.notificationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(118, 106);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameTextBox.TabIndex = 0;
            this.firstNameTextBox.Text = "First Name";
            this.firstNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.firstNameTextBox.Click += new System.EventHandler(this.firstNameTextBox_Click);
            this.firstNameTextBox.TextChanged += new System.EventHandler(this.firstNameTextBox_TextChanged);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(118, 132);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameTextBox.TabIndex = 1;
            this.lastNameTextBox.Text = "Last Name";
            this.lastNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lastNameTextBox.Click += new System.EventHandler(this.lastNameTextBox_Click);
            this.lastNameTextBox.TextChanged += new System.EventHandler(this.lastNameTextBox_TextChanged);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(118, 158);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 2;
            this.usernameTextBox.Text = "Username";
            this.usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usernameTextBox.Click += new System.EventHandler(this.usernameTextBox_Click);
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(118, 184);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextBox.Click += new System.EventHandler(this.passwordTextBox_Click);
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(13, 112);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(63, 13);
            this.firstNameLabel.TabIndex = 4;
            this.firstNameLabel.Text = "First Name :";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(13, 135);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(64, 13);
            this.lastNameLabel.TabIndex = 5;
            this.lastNameLabel.Text = "Last Name :";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 161);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(61, 13);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Username :";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(13, 187);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(59, 13);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Password :";
            // 
            // firstNameConfirmationLabel
            // 
            this.firstNameConfirmationLabel.AutoSize = true;
            this.firstNameConfirmationLabel.Location = new System.Drawing.Point(241, 111);
            this.firstNameConfirmationLabel.Name = "firstNameConfirmationLabel";
            this.firstNameConfirmationLabel.Size = new System.Drawing.Size(35, 13);
            this.firstNameConfirmationLabel.TabIndex = 8;
            this.firstNameConfirmationLabel.Text = "label1";
            this.firstNameConfirmationLabel.Visible = false;
            // 
            // lastNameConfirmationLabel
            // 
            this.lastNameConfirmationLabel.AutoSize = true;
            this.lastNameConfirmationLabel.Location = new System.Drawing.Point(241, 135);
            this.lastNameConfirmationLabel.Name = "lastNameConfirmationLabel";
            this.lastNameConfirmationLabel.Size = new System.Drawing.Size(35, 13);
            this.lastNameConfirmationLabel.TabIndex = 9;
            this.lastNameConfirmationLabel.Text = "label2";
            this.lastNameConfirmationLabel.Visible = false;
            // 
            // usernameConfirmationLabel
            // 
            this.usernameConfirmationLabel.AutoSize = true;
            this.usernameConfirmationLabel.Location = new System.Drawing.Point(241, 161);
            this.usernameConfirmationLabel.Name = "usernameConfirmationLabel";
            this.usernameConfirmationLabel.Size = new System.Drawing.Size(35, 13);
            this.usernameConfirmationLabel.TabIndex = 10;
            this.usernameConfirmationLabel.Text = "label3";
            this.usernameConfirmationLabel.Visible = false;
            // 
            // passwordConfirmationLabel
            // 
            this.passwordConfirmationLabel.AutoSize = true;
            this.passwordConfirmationLabel.Location = new System.Drawing.Point(241, 187);
            this.passwordConfirmationLabel.Name = "passwordConfirmationLabel";
            this.passwordConfirmationLabel.Size = new System.Drawing.Size(35, 13);
            this.passwordConfirmationLabel.TabIndex = 11;
            this.passwordConfirmationLabel.Text = "label4";
            this.passwordConfirmationLabel.Visible = false;
            // 
            // createAccountButton
            // 
            this.createAccountButton.Enabled = false;
            this.createAccountButton.Location = new System.Drawing.Point(143, 298);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(89, 23);
            this.createAccountButton.TabIndex = 12;
            this.createAccountButton.Text = "Create Account";
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(143, 327);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(89, 23);
            this.backButton.TabIndex = 13;
            this.backButton.Text = "Go Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // notificationLabel
            // 
            this.notificationLabel.AutoSize = true;
            this.notificationLabel.Location = new System.Drawing.Point(143, 260);
            this.notificationLabel.Name = "notificationLabel";
            this.notificationLabel.Size = new System.Drawing.Size(60, 13);
            this.notificationLabel.TabIndex = 14;
            this.notificationLabel.Text = "Notification";
            this.notificationLabel.Visible = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 432);
            this.Controls.Add(this.notificationLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.createAccountButton);
            this.Controls.Add(this.passwordConfirmationLabel);
            this.Controls.Add(this.usernameConfirmationLabel);
            this.Controls.Add(this.lastNameConfirmationLabel);
            this.Controls.Add(this.firstNameConfirmationLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.MaximumSize = new System.Drawing.Size(425, 471);
            this.MinimumSize = new System.Drawing.Size(425, 471);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label firstNameConfirmationLabel;
        private System.Windows.Forms.Label lastNameConfirmationLabel;
        private System.Windows.Forms.Label usernameConfirmationLabel;
        private System.Windows.Forms.Label passwordConfirmationLabel;
        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label notificationLabel;
    }
}