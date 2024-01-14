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
            addCopyButton = new Button();
            returnToResourcesButton = new Button();
            dataGridViewCopies = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCopies).BeginInit();
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
            panel1.Size = new Size(231, 213);
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
            // addCopyButton
            // 
            addCopyButton.Location = new Point(12, 231);
            addCopyButton.Name = "addCopyButton";
            addCopyButton.Size = new Size(231, 33);
            addCopyButton.TabIndex = 5;
            addCopyButton.Text = "Add New Copy";
            addCopyButton.UseVisualStyleBackColor = true;
            addCopyButton.Click += AddCopyButton_Click;
            // 
            // returnToResourcesButton
            // 
            returnToResourcesButton.Location = new Point(12, 270);
            returnToResourcesButton.Name = "returnToResourcesButton";
            returnToResourcesButton.Size = new Size(231, 33);
            returnToResourcesButton.TabIndex = 6;
            returnToResourcesButton.Text = "Return";
            returnToResourcesButton.UseVisualStyleBackColor = true;
            returnToResourcesButton.Click += ReturnToResourcesButton_Click;
            // 
            // dataGridViewCopies
            // 
            dataGridViewCopies.AllowUserToAddRows = false;
            dataGridViewCopies.AllowUserToDeleteRows = false;
            dataGridViewCopies.AllowUserToResizeColumns = false;
            dataGridViewCopies.AllowUserToResizeRows = false;
            dataGridViewCopies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCopies.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCopies.BackgroundColor = SystemColors.Control;
            dataGridViewCopies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCopies.Location = new Point(260, 12);
            dataGridViewCopies.Name = "dataGridViewCopies";
            dataGridViewCopies.RowTemplate.Height = 25;
            dataGridViewCopies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCopies.Size = new Size(454, 291);
            dataGridViewCopies.TabIndex = 7;
            // 
            // ManagingResourceCopies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 310);
            Controls.Add(dataGridViewCopies);
            Controls.Add(returnToResourcesButton);
            Controls.Add(addCopyButton);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ManagingResourceCopies";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resource Copies";
            TopMost = true;
            Load += ManagingResourceCopies_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCopies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label resourceIdLabel;
        private Label titleLabel;
        private Label authorLabel;
        private Label yearPublishedLabel;
        private Panel panel1;
        private Label typeLabel;
        private Button addCopyButton;
        private Button returnToResourcesButton;
        private DataGridView dataGridViewCopies;
    }
}