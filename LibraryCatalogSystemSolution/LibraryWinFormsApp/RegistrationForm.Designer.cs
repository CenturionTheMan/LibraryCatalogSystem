namespace LibraryWinFormsApp
{
    partial class RegistrationForm
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
            registerButton = new Button();
            returnToMainButton = new Button();
            clearButton = new Button();
            firstNameTextBox = new TextBox();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            confirmPasswordTextBox = new TextBox();
            keyTextBox = new TextBox();
            firstNameLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            confirmPasswordLabel = new Label();
            keylabel = new Label();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // registerButton
            // 
            registerButton.Location = new Point(12, 332);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(360, 26);
            registerButton.TabIndex = 0;
            registerButton.Text = "Regsiter";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += RegisterButton_Click;
            // 
            // returnToMainButton
            // 
            returnToMainButton.Location = new Point(12, 396);
            returnToMainButton.Name = "returnToMainButton";
            returnToMainButton.Size = new Size(360, 26);
            returnToMainButton.TabIndex = 1;
            returnToMainButton.Text = "Return";
            returnToMainButton.UseVisualStyleBackColor = true;
            returnToMainButton.Click += ReturnToMainButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(13, 364);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(360, 26);
            clearButton.TabIndex = 2;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += ClearButton_Click;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(13, 30);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(360, 23);
            firstNameTextBox.TabIndex = 3;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(12, 141);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(360, 23);
            usernameTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 196);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(360, 23);
            passwordTextBox.TabIndex = 5;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(12, 250);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.Size = new Size(360, 23);
            confirmPasswordTextBox.TabIndex = 6;
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // keyTextBox
            // 
            keyTextBox.Location = new Point(12, 303);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(360, 23);
            keyTextBox.TabIndex = 7;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(12, 12);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(64, 15);
            firstNameLabel.TabIndex = 8;
            firstNameLabel.Text = "First Name";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(12, 123);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(60, 15);
            usernameLabel.TabIndex = 9;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(12, 178);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 10;
            passwordLabel.Text = "Password";
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.Location = new Point(12, 232);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new Size(104, 15);
            confirmPasswordLabel.TabIndex = 11;
            confirmPasswordLabel.Text = "Confirm Password";
            // 
            // keylabel
            // 
            keylabel.AutoSize = true;
            keylabel.Location = new Point(12, 285);
            keylabel.Name = "keylabel";
            keylabel.Size = new Size(81, 15);
            keylabel.TabIndex = 12;
            keylabel.Text = "Key (optional)";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(13, 71);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(63, 15);
            lastNameLabel.TabIndex = 14;
            lastNameLabel.Text = "Last Name";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(12, 89);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(360, 23);
            lastNameTextBox.TabIndex = 13;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 428);
            Controls.Add(lastNameLabel);
            Controls.Add(lastNameTextBox);
            Controls.Add(keylabel);
            Controls.Add(confirmPasswordLabel);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(keyTextBox);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(clearButton);
            Controls.Add(returnToMainButton);
            Controls.Add(registerButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button registerButton;
        private Button returnToMainButton;
        private Button clearButton;
        private TextBox firstNameTextBox;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private TextBox confirmPasswordTextBox;
        private TextBox keyTextBox;
        private Label firstNameLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label confirmPasswordLabel;
        private Label keylabel;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
    }
}