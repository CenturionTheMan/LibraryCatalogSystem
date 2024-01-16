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
            extendButton.Location = new Point(11, 300);
            extendButton.Margin = new Padding(3, 4, 3, 4);
            extendButton.Name = "extendButton";
            extendButton.Size = new Size(307, 39);
            extendButton.TabIndex = 4;
            extendButton.Text = "Extend";
            extendButton.UseVisualStyleBackColor = true;
            extendButton.Click += ExtendButton_Click;
            // 
            // ExtendDateMonthCalendar
            // 
            ExtendDateMonthCalendar.Location = new Point(35, 69);
            ExtendDateMonthCalendar.Margin = new Padding(10, 12, 10, 12);
            ExtendDateMonthCalendar.Name = "ExtendDateMonthCalendar";
            ExtendDateMonthCalendar.TabIndex = 3;
            // 
            // extendlabel
            // 
            extendlabel.Anchor = AnchorStyles.None;
            extendlabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            extendlabel.Location = new Point(14, 12);
            extendlabel.Name = "extendlabel";
            extendlabel.Size = new Size(305, 45);
            extendlabel.TabIndex = 5;
            extendlabel.Text = "Select Date";
            extendlabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExtendRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 355);
            Controls.Add(extendlabel);
            Controls.Add(extendButton);
            Controls.Add(ExtendDateMonthCalendar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
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