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
            reg = new Button();
            returnToMain = new Button();
            cencel = new Button();
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
            // reg
            // 
            reg.Location = new Point(12, 332);
            reg.Name = "reg";
            reg.Size = new Size(460, 35);
            reg.TabIndex = 0;
            reg.Text = "Regsiter";
            reg.UseVisualStyleBackColor = true;
            reg.Click += reg_Click;
            // 
            // returnToMain
            // 
            returnToMain.Location = new Point(12, 414);
            returnToMain.Name = "returnToMain";
            returnToMain.Size = new Size(460, 35);
            returnToMain.TabIndex = 1;
            returnToMain.Text = "Return";
            returnToMain.UseVisualStyleBackColor = true;
            returnToMain.Click += returnToMain_Click;
            // 
            // cencel
            // 
            cencel.Location = new Point(12, 373);
            cencel.Name = "cencel";
            cencel.Size = new Size(460, 35);
            cencel.TabIndex = 2;
            cencel.Text = "Cancel";
            cencel.UseVisualStyleBackColor = true;
            cencel.Click += cencel_Click;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(12, 37);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(460, 23);
            firstNameTextBox.TabIndex = 3;
            firstNameTextBox.TextChanged += firstNameTextBox_TextChanged;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(12, 141);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(460, 23);
            usernameTextBox.TabIndex = 4;
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 196);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(460, 23);
            passwordTextBox.TabIndex = 5;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(12, 250);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.Size = new Size(460, 23);
            confirmPasswordTextBox.TabIndex = 6;
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            confirmPasswordTextBox.TextChanged += confirmPasswordTextBox_TextChanged;
            // 
            // keyTextBox
            // 
            keyTextBox.Location = new Point(12, 303);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.Size = new Size(460, 23);
            keyTextBox.TabIndex = 7;
            keyTextBox.TextChanged += keyTextBox_TextChanged;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(12, 19);
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
            lastNameLabel.Location = new Point(12, 73);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(63, 15);
            lastNameLabel.TabIndex = 14;
            lastNameLabel.Text = "Last Name";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(12, 89);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(460, 23);
            lastNameTextBox.TabIndex = 13;
            lastNameTextBox.TextChanged += lastNameTextBox_TextChanged;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 461);
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
            Controls.Add(cencel);
            Controls.Add(returnToMain);
            Controls.Add(reg);
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button reg;
        private Button returnToMain;
        private Button cencel;
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