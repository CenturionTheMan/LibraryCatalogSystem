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
            dataGridViewClient.Location = new Point(14, 157);
            dataGridViewClient.Margin = new Padding(3, 4, 3, 4);
            dataGridViewClient.MultiSelect = false;
            dataGridViewClient.Name = "dataGridViewClient";
            dataGridViewClient.RowHeadersWidth = 51;
            dataGridViewClient.RowTemplate.Height = 25;
            dataGridViewClient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClient.Size = new Size(1417, 829);
            dataGridViewClient.TabIndex = 0;
            // 
            // borrowedResourcesButton
            // 
            borrowedResourcesButton.Location = new Point(14, 96);
            borrowedResourcesButton.Margin = new Padding(3, 4, 3, 4);
            borrowedResourcesButton.Name = "borrowedResourcesButton";
            borrowedResourcesButton.Size = new Size(389, 53);
            borrowedResourcesButton.TabIndex = 1;
            borrowedResourcesButton.Text = "Borrowed By Me";
            borrowedResourcesButton.UseVisualStyleBackColor = true;
            borrowedResourcesButton.Click += borrowedResourcesButton_Click;
            // 
            // borrowRequestsButton
            // 
            borrowRequestsButton.Location = new Point(425, 96);
            borrowRequestsButton.Margin = new Padding(3, 4, 3, 4);
            borrowRequestsButton.Name = "borrowRequestsButton";
            borrowRequestsButton.Size = new Size(389, 53);
            borrowRequestsButton.TabIndex = 2;
            borrowRequestsButton.Text = "My Requests";
            borrowRequestsButton.UseVisualStyleBackColor = true;
            borrowRequestsButton.Click += borrowRequestsButton_Click;
            // 
            // allResourcesButton
            // 
            allResourcesButton.Location = new Point(14, 16);
            allResourcesButton.Margin = new Padding(3, 4, 3, 4);
            allResourcesButton.Name = "allResourcesButton";
            allResourcesButton.Size = new Size(800, 53);
            allResourcesButton.TabIndex = 3;
            allResourcesButton.Text = "Browse Library Resources";
            allResourcesButton.UseVisualStyleBackColor = true;
            allResourcesButton.Click += allResourcesButton_Click;
            // 
            // logOutButton
            // 
            logOutButton.Location = new Point(304, 40);
            logOutButton.Margin = new Padding(3, 4, 3, 4);
            logOutButton.Name = "logOutButton";
            logOutButton.Size = new Size(267, 53);
            logOutButton.TabIndex = 7;
            logOutButton.Text = "Log Out";
            logOutButton.UseVisualStyleBackColor = true;
            logOutButton.Click += logOutButton_Click;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(11, 17);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(286, 40);
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
            panel1.Location = new Point(841, 16);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(589, 133);
            panel1.TabIndex = 12;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(11, 76);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(286, 40);
            lastNameLabel.TabIndex = 10;
            lastNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1442, 1003);
            Controls.Add(panel1);
            Controls.Add(allResourcesButton);
            Controls.Add(borrowRequestsButton);
            Controls.Add(borrowedResourcesButton);
            Controls.Add(dataGridViewClient);
            Margin = new Padding(3, 4, 3, 4);
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