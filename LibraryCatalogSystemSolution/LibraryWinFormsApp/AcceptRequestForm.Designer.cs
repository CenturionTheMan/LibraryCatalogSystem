namespace LibraryWinFormsApp
{
    partial class AcceptRequestForm
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
            CopyIdComboBox = new ComboBox();
            DueDateMonthCalendar = new MonthCalendar();
            acceptButton = new Button();
            copyIdLabel = new Label();
            SuspendLayout();
            // 
            // CopyIdComboBox
            // 
            CopyIdComboBox.FormattingEnabled = true;
            CopyIdComboBox.Location = new Point(98, 21);
            CopyIdComboBox.Margin = new Padding(3, 4, 3, 4);
            CopyIdComboBox.Name = "CopyIdComboBox";
            CopyIdComboBox.Size = new Size(222, 28);
            CopyIdComboBox.TabIndex = 0;
            // 
            // DueDateMonthCalendar
            // 
            DueDateMonthCalendar.Location = new Point(38, 65);
            DueDateMonthCalendar.Margin = new Padding(10, 12, 10, 12);
            DueDateMonthCalendar.Name = "DueDateMonthCalendar";
            DueDateMonthCalendar.TabIndex = 1;
            // 
            // acceptButton
            // 
            acceptButton.Location = new Point(14, 295);
            acceptButton.Margin = new Padding(3, 4, 3, 4);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(307, 39);
            acceptButton.TabIndex = 2;
            acceptButton.Text = "Accept";
            acceptButton.UseVisualStyleBackColor = true;
            acceptButton.Click += AcceptButton_Click;
            // 
            // copyIdLabel
            // 
            copyIdLabel.AutoSize = true;
            copyIdLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            copyIdLabel.Location = new Point(10, 21);
            copyIdLabel.Name = "copyIdLabel";
            copyIdLabel.Size = new Size(82, 25);
            copyIdLabel.TabIndex = 3;
            copyIdLabel.Text = "Copy ID:";
            // 
            // AcceptRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 355);
            Controls.Add(copyIdLabel);
            Controls.Add(acceptButton);
            Controls.Add(DueDateMonthCalendar);
            Controls.Add(CopyIdComboBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AcceptRequestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Accept New Request";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CopyIdComboBox;
        private MonthCalendar DueDateMonthCalendar;
        private Button acceptButton;
        private Label copyIdLabel;
    }
}