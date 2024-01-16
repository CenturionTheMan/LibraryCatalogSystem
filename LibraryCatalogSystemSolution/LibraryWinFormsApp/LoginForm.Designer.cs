namespace LibraryWinFormsApp
{
    partial class LoginForm
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
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            usernameLabel = new Label();
            passwordLabel = new Label();
            loginButton = new Button();
            clearButton = new Button();
            returnToMainButton = new Button();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 88);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(360, 23);
            passwordTextBox.TabIndex = 0;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(12, 30);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(360, 23);
            usernameTextBox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(12, 12);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(60, 15);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(12, 70);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(12, 117);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(360, 26);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += LoginButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(12, 149);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(360, 26);
            clearButton.TabIndex = 5;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += ClearButton_Click;
            // 
            // returnToMainButton
            // 
            returnToMainButton.Location = new Point(12, 181);
            returnToMainButton.Name = "returnToMainButton";
            returnToMainButton.Size = new Size(360, 26);
            returnToMainButton.TabIndex = 6;
            returnToMainButton.Text = "Return";
            returnToMainButton.UseVisualStyleBackColor = true;
            returnToMainButton.Click += ReturnToMainButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 214);
            Controls.Add(returnToMainButton);
            Controls.Add(clearButton);
            Controls.Add(loginButton);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label usernameLabel;
        private Label passwordLabel;
        private Button loginButton;
        private Button clearButton;
        private Button returnToMainButton;
    }
}