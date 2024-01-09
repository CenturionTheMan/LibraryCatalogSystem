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
            log = new Button();
            cancel = new Button();
            returnToMain = new Button();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 131);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(360, 23);
            passwordTextBox.TabIndex = 0;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(12, 60);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(360, 23);
            usernameTextBox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(12, 42);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(60, 15);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(12, 113);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password";
            // 
            // log
            // 
            log.Location = new Point(12, 194);
            log.Name = "log";
            log.Size = new Size(360, 26);
            log.TabIndex = 4;
            log.Text = "Login";
            log.UseVisualStyleBackColor = true;
            log.Click += log_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(12, 237);
            cancel.Name = "cancel";
            cancel.Size = new Size(360, 26);
            cancel.TabIndex = 5;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // returnToMain
            // 
            returnToMain.Location = new Point(12, 282);
            returnToMain.Name = "returnToMain";
            returnToMain.Size = new Size(360, 26);
            returnToMain.TabIndex = 6;
            returnToMain.Text = "Return";
            returnToMain.UseVisualStyleBackColor = true;
            returnToMain.Click += returnToMain_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(returnToMain);
            Controls.Add(cancel);
            Controls.Add(log);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordTextBox);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label usernameLabel;
        private Label passwordLabel;
        private Button log;
        private Button cancel;
        private Button returnToMain;
    }
}