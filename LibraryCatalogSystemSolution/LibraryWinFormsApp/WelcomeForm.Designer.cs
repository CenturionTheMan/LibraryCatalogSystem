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
            loginWin = new Button();
            registerWin = new Button();
            firstLabel = new Label();
            SuspendLayout();
            // 
            // loginWin
            // 
            loginWin.Location = new Point(46, 199);
            loginWin.Name = "loginWin";
            loginWin.Size = new Size(584, 67);
            loginWin.TabIndex = 0;
            loginWin.Text = "Log in";
            loginWin.UseVisualStyleBackColor = true;
            loginWin.Click += login_Click;
            // 
            // registerWin
            // 
            registerWin.Location = new Point(46, 283);
            registerWin.Name = "registerWin";
            registerWin.Size = new Size(584, 67);
            registerWin.TabIndex = 1;
            registerWin.Text = "Register";
            registerWin.UseVisualStyleBackColor = true;
            registerWin.Click += register_Click;
            // 
            // firstLabel
            // 
            firstLabel.CausesValidation = false;
            firstLabel.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point);
            firstLabel.Location = new Point(46, 45);
            firstLabel.Name = "firstLabel";
            firstLabel.Size = new Size(584, 128);
            firstLabel.TabIndex = 2;
            firstLabel.Text = "LIBRARY";
            firstLabel.TextAlign = ContentAlignment.MiddleCenter;
            firstLabel.Click += firstLabel_Click;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(672, 391);
            Controls.Add(firstLabel);
            Controls.Add(registerWin);
            Controls.Add(loginWin);
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library";
            ResumeLayout(false);
        }

        #endregion

        private Button loginWin;
        private Button registerWin;
        private Label firstLabel;
    }
}
