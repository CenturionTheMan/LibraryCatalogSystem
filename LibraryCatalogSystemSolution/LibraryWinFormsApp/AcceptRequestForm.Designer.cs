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
            CopyIdComboBox.Location = new Point(83, 16);
            CopyIdComboBox.Name = "CopyIdComboBox";
            CopyIdComboBox.Size = new Size(195, 23);
            CopyIdComboBox.TabIndex = 0;
            // 
            // DueDateMonthCalendar
            // 
            DueDateMonthCalendar.Location = new Point(12, 45);
            DueDateMonthCalendar.Name = "DueDateMonthCalendar";
            DueDateMonthCalendar.TabIndex = 1;
            // 
            // acceptButton
            // 
            acceptButton.Location = new Point(12, 221);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(269, 29);
            acceptButton.TabIndex = 2;
            acceptButton.Text = "Accept";
            acceptButton.UseVisualStyleBackColor = true;
            acceptButton.Click += AcceptButton_Click;
            // 
            // copyIdLabel
            // 
            copyIdLabel.AutoSize = true;
            copyIdLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            copyIdLabel.Location = new Point(9, 16);
            copyIdLabel.Name = "copyIdLabel";
            copyIdLabel.Size = new Size(65, 20);
            copyIdLabel.TabIndex = 3;
            copyIdLabel.Text = "Copy ID:";
            // 
            // AcceptRequestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 266);
            Controls.Add(copyIdLabel);
            Controls.Add(acceptButton);
            Controls.Add(DueDateMonthCalendar);
            Controls.Add(CopyIdComboBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AcceptRequestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Accept New Request";
            TopMost = true;
            Load += AcceptRequestForm_Load;
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