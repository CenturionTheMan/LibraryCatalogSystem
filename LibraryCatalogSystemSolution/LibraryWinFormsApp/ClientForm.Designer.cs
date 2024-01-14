namespace LibraryWinFormsApp
{
    partial class ClientForm
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
            dataGridViewClient = new DataGridView();
            borrowedResourcesButton = new Button();
            borrowRequestsButton = new Button();
            allResourcesButton = new Button();
            logOutButton = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            firstNameLabel = new Label();
            panel1 = new Panel();
            lastNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClient).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewClient
            // 
            dataGridViewClient.AllowUserToAddRows = false;
            dataGridViewClient.AllowUserToDeleteRows = false;
            dataGridViewClient.AllowUserToResizeColumns = false;
            dataGridViewClient.AllowUserToResizeRows = false;
            dataGridViewClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewClient.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewClient.BackgroundColor = SystemColors.Control;
            dataGridViewClient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClient.Location = new Point(12, 118);
            dataGridViewClient.MultiSelect = false;
            dataGridViewClient.Name = "dataGridViewClient";
            dataGridViewClient.RowTemplate.Height = 25;
            dataGridViewClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClient.Size = new Size(1240, 622);
            dataGridViewClient.TabIndex = 0;
            // 
            // borrowedResourcesButton
            // 
            borrowedResourcesButton.Location = new Point(12, 72);
            borrowedResourcesButton.Name = "borrowedResourcesButton";
            borrowedResourcesButton.Size = new Size(340, 40);
            borrowedResourcesButton.TabIndex = 1;
            borrowedResourcesButton.Text = "My Borrowed Resources";
            borrowedResourcesButton.UseVisualStyleBackColor = true;
            borrowedResourcesButton.Click += borrowedResourcesButton_Click;
            // 
            // borrowRequestsButton
            // 
            borrowRequestsButton.Location = new Point(372, 72);
            borrowRequestsButton.Name = "borrowRequestsButton";
            borrowRequestsButton.Size = new Size(340, 40);
            borrowRequestsButton.TabIndex = 2;
            borrowRequestsButton.Text = "My Requests";
            borrowRequestsButton.UseVisualStyleBackColor = true;
            borrowRequestsButton.Click += borrowRequestsButton_Click;
            // 
            // allResourcesButton
            // 
            allResourcesButton.Location = new Point(12, 12);
            allResourcesButton.Name = "allResourcesButton";
            allResourcesButton.Size = new Size(700, 40);
            allResourcesButton.TabIndex = 3;
            allResourcesButton.Text = "Browse the Library's resources";
            allResourcesButton.UseVisualStyleBackColor = true;
            allResourcesButton.Click += allResourcesButton_Click;
            // 
            // logOutButton
            // 
            logOutButton.Location = new Point(266, 30);
            logOutButton.Name = "logOutButton";
            logOutButton.Size = new Size(234, 40);
            logOutButton.TabIndex = 7;
            logOutButton.Text = "Log Out";
            logOutButton.UseVisualStyleBackColor = true;
            logOutButton.Click += logOutButton_Click;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(10, 13);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(250, 30);
            firstNameLabel.TabIndex = 9;
            firstNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lastNameLabel);
            panel1.Controls.Add(firstNameLabel);
            panel1.Controls.Add(logOutButton);
            panel1.Location = new Point(736, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(516, 100);
            panel1.TabIndex = 12;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(10, 57);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(250, 30);
            lastNameLabel.TabIndex = 10;
            lastNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1262, 752);
            Controls.Add(panel1);
            Controls.Add(allResourcesButton);
            Controls.Add(borrowRequestsButton);
            Controls.Add(borrowedResourcesButton);
            Controls.Add(dataGridViewClient);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClient).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewClient;
        private Button borrowedResourcesButton;
        private Button borrowRequestsButton;
        private Button allResourcesButton;
        private Button logOutButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label firstNameLabel;
        private Panel panel1;
        private Label lastNameLabel;
    }
}