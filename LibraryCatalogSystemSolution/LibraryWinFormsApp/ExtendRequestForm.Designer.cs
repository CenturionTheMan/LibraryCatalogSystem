namespace LibraryWinFormsApp
{
    partial class ExtendRequestForm
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
            extendButton = new Button();
            ExtendDateMonthCalendar = new MonthCalendar();
            extendlabel = new Label();
            SuspendLayout();
            // 
            // extendButton
            // 
            extendButton.Location = new Point(10, 225);
            extendButton.Name = "extendButton";
            extendButton.Size = new Size(269, 29);
            extendButton.TabIndex = 4;
            extendButton.Text = "Extend";
            extendButton.UseVisualStyleBackColor = true;
            extendButton.Click += ExtendButton_Click;
            // 
            // ExtendDateMonthCalendar
            // 
            ExtendDateMonthCalendar.Location = new Point(10, 51);
            ExtendDateMonthCalendar.Name = "ExtendDateMonthCalendar";
            ExtendDateMonthCalendar.TabIndex = 3;
            // 
            // extendlabel
            // 
            extendlabel.Anchor = AnchorStyles.None;
            extendlabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            extendlabel.Location = new Point(12, 9);
            extendlabel.Name = "extendlabel";
            extendlabel.Size = new Size(267, 34);
            extendlabel.TabIndex = 5;
            extendlabel.Text = "Select Date";
            extendlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExtendRequestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 266);
            Controls.Add(extendlabel);
            Controls.Add(extendButton);
            Controls.Add(ExtendDateMonthCalendar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ExtendRequestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Extend Request";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Button extendButton;
        private MonthCalendar ExtendDateMonthCalendar;
        private Label extendlabel;
    }
}