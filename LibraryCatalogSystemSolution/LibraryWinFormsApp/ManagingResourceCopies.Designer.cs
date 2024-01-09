namespace LibraryWinFormsApp
{
    partial class ManagingResourceCopies
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
            resourceIdLabel = new Label();
            titleLabel = new Label();
            authorLabel = new Label();
            yearPublishedLabel = new Label();
            panel1 = new Panel();
            typeLabel = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // resourceIdLabel
            // 
            resourceIdLabel.AutoSize = true;
            resourceIdLabel.Location = new Point(8, 5);
            resourceIdLabel.Name = "resourceIdLabel";
            resourceIdLabel.Size = new Size(72, 15);
            resourceIdLabel.TabIndex = 0;
            resourceIdLabel.Text = "ResourceID: ";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(8, 41);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(35, 15);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Title: ";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(8, 85);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(50, 15);
            authorLabel.TabIndex = 2;
            authorLabel.Text = "Author: ";
            // 
            // yearPublishedLabel
            // 
            yearPublishedLabel.AutoSize = true;
            yearPublishedLabel.Location = new Point(8, 132);
            yearPublishedLabel.Name = "yearPublishedLabel";
            yearPublishedLabel.Size = new Size(90, 15);
            yearPublishedLabel.TabIndex = 3;
            yearPublishedLabel.Text = "Year Published: ";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(typeLabel);
            panel1.Controls.Add(yearPublishedLabel);
            panel1.Controls.Add(authorLabel);
            panel1.Controls.Add(titleLabel);
            panel1.Controls.Add(resourceIdLabel);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 203);
            panel1.TabIndex = 4;
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(8, 173);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(34, 15);
            typeLabel.TabIndex = 4;
            typeLabel.Text = "Type:";
            // 
            // button1
            // 
            button1.Location = new Point(12, 231);
            button1.Name = "button1";
            button1.Size = new Size(231, 33);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 290);
            button2.Name = "button2";
            button2.Size = new Size(231, 33);
            button2.TabIndex = 6;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(12, 344);
            button3.Name = "button3";
            button3.Size = new Size(231, 33);
            button3.TabIndex = 7;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // ManagingResourceCopies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "ManagingResourceCopies";
            StartPosition = FormStartPosition.CenterScreen;
            Text = ";";
            Load += ManagingResourceCopies_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label resourceIdLabel;
        private Label titleLabel;
        private Label authorLabel;
        private Label yearPublishedLabel;
        private Panel panel1;
        private Label typeLabel;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}