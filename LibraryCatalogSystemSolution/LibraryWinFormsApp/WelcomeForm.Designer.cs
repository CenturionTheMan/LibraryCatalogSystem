namespace LibraryWinFormsApp
{
    partial class WelcomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            loginButton = new Button();
            signUpButton = new Button();
            firstLabel = new Label();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(12, 213);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(271, 38);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += LoginButton_Click;
            // 
            // signUpButton
            // 
            signUpButton.Location = new Point(289, 213);
            signUpButton.Name = "signUpButton";
            signUpButton.Size = new Size(271, 38);
            signUpButton.TabIndex = 1;
            signUpButton.Text = "Sign Up";
            signUpButton.UseVisualStyleBackColor = true;
            signUpButton.Click += SignUpButton_Click;
            // 
            // firstLabel
            // 
            firstLabel.CausesValidation = false;
            firstLabel.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point);
            firstLabel.Location = new Point(12, 9);
            firstLabel.Name = "firstLabel";
            firstLabel.Size = new Size(548, 188);
            firstLabel.TabIndex = 2;
            firstLabel.Text = "LIBRARY";
            firstLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = SystemColors.Control;
            ClientSize = new Size(571, 261);
            Controls.Add(firstLabel);
            Controls.Add(signUpButton);
            Controls.Add(loginButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library";
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button loginButton;
        private Button signUpButton;
        private Label firstLabel;
    }
}
