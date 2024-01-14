namespace LibraryWinFormsApp
{
    partial class AddResourceForm
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
            AuthorLabel = new Label();
            titleLabel = new Label();
            titleTextBox = new TextBox();
            authorTextBox = new TextBox();
            resourceTypeLabel = new Label();
            uearPublishedLabel = new Label();
            yearPublishedTextBox = new TextBox();
            resourceTypeTextBox = new TextBox();
            addResource = new Button();
            SuspendLayout();
            // 
            // AuthorLabel
            // 
            AuthorLabel.AutoSize = true;
            AuthorLabel.Location = new Point(12, 62);
            AuthorLabel.Name = "AuthorLabel";
            AuthorLabel.Size = new Size(44, 15);
            AuthorLabel.TabIndex = 7;
            AuthorLabel.Text = "Author";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(12, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(29, 15);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Title";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(12, 27);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(360, 23);
            titleTextBox.TabIndex = 5;
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(12, 80);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(360, 23);
            authorTextBox.TabIndex = 4;
            // 
            // resourceTypeLabel
            // 
            resourceTypeLabel.AutoSize = true;
            resourceTypeLabel.Location = new Point(12, 171);
            resourceTypeLabel.Name = "resourceTypeLabel";
            resourceTypeLabel.Size = new Size(82, 15);
            resourceTypeLabel.TabIndex = 11;
            resourceTypeLabel.Text = "Resource Type";
            // 
            // uearPublishedLabel
            // 
            uearPublishedLabel.AutoSize = true;
            uearPublishedLabel.Location = new Point(12, 117);
            uearPublishedLabel.Name = "uearPublishedLabel";
            uearPublishedLabel.Size = new Size(84, 15);
            uearPublishedLabel.TabIndex = 10;
            uearPublishedLabel.Text = "Year Published";
            // 
            // yearPublishedTextBox
            // 
            yearPublishedTextBox.Location = new Point(12, 135);
            yearPublishedTextBox.Name = "yearPublishedTextBox";
            yearPublishedTextBox.Size = new Size(360, 23);
            yearPublishedTextBox.TabIndex = 9;
            // 
            // resourceTypeTextBox
            // 
            resourceTypeTextBox.Location = new Point(12, 189);
            resourceTypeTextBox.Name = "resourceTypeTextBox";
            resourceTypeTextBox.Size = new Size(360, 23);
            resourceTypeTextBox.TabIndex = 8;
            // 
            // addResource
            // 
            addResource.Location = new Point(12, 227);
            addResource.Name = "addResource";
            addResource.Size = new Size(360, 38);
            addResource.TabIndex = 12;
            addResource.Text = "Add Resource";
            addResource.UseVisualStyleBackColor = true;
            addResource.Click += AddResource_Click;
            // 
            // AddResourceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 272);
            Controls.Add(addResource);
            Controls.Add(resourceTypeLabel);
            Controls.Add(uearPublishedLabel);
            Controls.Add(yearPublishedTextBox);
            Controls.Add(resourceTypeTextBox);
            Controls.Add(AuthorLabel);
            Controls.Add(titleLabel);
            Controls.Add(titleTextBox);
            Controls.Add(authorTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddResourceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add New Resource";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AuthorLabel;
        private Label titleLabel;
        private TextBox titleTextBox;
        private TextBox authorTextBox;
        private Label resourceTypeLabel;
        private Label uearPublishedLabel;
        private TextBox yearPublishedTextBox;
        private TextBox resourceTypeTextBox;
        private Button addResource;
    }
}