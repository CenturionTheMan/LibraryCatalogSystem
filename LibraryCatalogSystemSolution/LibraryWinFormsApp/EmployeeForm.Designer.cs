namespace LibraryWinFormsApp
{
    partial class EmployeeForm
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
            panel1 = new Panel();
            lastNameLabel = new Label();
            firstNameLabel = new Label();
            logOut = new Button();
            dataGridViewEmployee = new DataGridView();
            browseResourcesButton = new Button();
            addResourceButton = new Button();
            requestsButton = new Button();
            newRequestsButton = new Button();
            extensionRequestsButton = new Button();
            awaitingReturnButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployee).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lastNameLabel);
            panel1.Controls.Add(firstNameLabel);
            panel1.Controls.Add(logOut);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(239, 151);
            panel1.TabIndex = 13;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(3, 56);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.RightToLeft = RightToLeft.No;
            lastNameLabel.Size = new Size(231, 43);
            lastNameLabel.TabIndex = 10;
            lastNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(3, 9);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(231, 47);
            firstNameLabel.TabIndex = 9;
            firstNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // logOut
            // 
            logOut.Location = new Point(29, 102);
            logOut.Name = "logOut";
            logOut.Size = new Size(180, 40);
            logOut.TabIndex = 7;
            logOut.Text = "Log Out";
            logOut.UseVisualStyleBackColor = true;
            logOut.Click += LogOut_Click;
            // 
            // dataGridViewEmployee
            // 
            dataGridViewEmployee.AllowUserToAddRows = false;
            dataGridViewEmployee.AllowUserToDeleteRows = false;
            dataGridViewEmployee.AllowUserToResizeColumns = false;
            dataGridViewEmployee.AllowUserToResizeRows = false;
            dataGridViewEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmployee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewEmployee.BackgroundColor = SystemColors.Control;
            dataGridViewEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployee.Location = new Point(257, 12);
            dataGridViewEmployee.Name = "dataGridViewEmployee";
            dataGridViewEmployee.RowTemplate.Height = 25;
            dataGridViewEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmployee.Size = new Size(995, 657);
            dataGridViewEmployee.TabIndex = 0;
            // 
            // browseResourcesButton
            // 
            browseResourcesButton.Location = new Point(12, 169);
            browseResourcesButton.Name = "browseResourcesButton";
            browseResourcesButton.Size = new Size(239, 40);
            browseResourcesButton.TabIndex = 1;
            browseResourcesButton.Text = "Browse the Library's resources";
            browseResourcesButton.UseVisualStyleBackColor = true;
            browseResourcesButton.Click += BrowseResourcesButton_Click;
            // 
            // addResourceButton
            // 
            addResourceButton.Location = new Point(12, 215);
            addResourceButton.Name = "addResourceButton";
            addResourceButton.Size = new Size(239, 40);
            addResourceButton.TabIndex = 2;
            addResourceButton.Text = "Add New Resource";
            addResourceButton.UseVisualStyleBackColor = true;
            addResourceButton.Click += AddResourceButton_Click;
            // 
            // requestsButton
            // 
            requestsButton.Location = new Point(8, 261);
            requestsButton.Name = "requestsButton";
            requestsButton.Size = new Size(239, 40);
            requestsButton.TabIndex = 14;
            requestsButton.Text = "Browse All Requests";
            requestsButton.UseVisualStyleBackColor = true;
            requestsButton.Click += RequestsButton_Click;
            // 
            // newRequestsButton
            // 
            newRequestsButton.Location = new Point(8, 307);
            newRequestsButton.Name = "newRequestsButton";
            newRequestsButton.Size = new Size(239, 40);
            newRequestsButton.TabIndex = 16;
            newRequestsButton.Text = "Browse New Borrow Requests";
            newRequestsButton.UseVisualStyleBackColor = true;
            newRequestsButton.Click += NewRequestsButton_Click;
            // 
            // extensionRequestsButton
            // 
            extensionRequestsButton.Location = new Point(8, 353);
            extensionRequestsButton.Name = "extensionRequestsButton";
            extensionRequestsButton.Size = new Size(239, 40);
            extensionRequestsButton.TabIndex = 17;
            extensionRequestsButton.Text = "Browse Extension Requests";
            extensionRequestsButton.UseVisualStyleBackColor = true;
            extensionRequestsButton.Click += ExtensionRequests_Click;
            // 
            // awaitingReturnButton
            // 
            awaitingReturnButton.Location = new Point(8, 399);
            awaitingReturnButton.Name = "awaitingReturnButton";
            awaitingReturnButton.Size = new Size(239, 40);
            awaitingReturnButton.TabIndex = 18;
            awaitingReturnButton.Text = "Browse Awaiting to Return ";
            awaitingReturnButton.UseVisualStyleBackColor = true;
            awaitingReturnButton.Click += AwaitingReturnButton_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(awaitingReturnButton);
            Controls.Add(extensionRequestsButton);
            Controls.Add(newRequestsButton);
            Controls.Add(requestsButton);
            Controls.Add(addResourceButton);
            Controls.Add(panel1);
            Controls.Add(browseResourcesButton);
            Controls.Add(dataGridViewEmployee);
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee";
            TopMost = true;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployee).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lastNameLabel;
        private Label firstNameLabel;
        private Button logOut;
        private DataGridView dataGridViewEmployee;
        private Button browseResourcesButton;
        private Button addResourceButton;
        private Button requestsButton;
        private Button newRequestsButton;
        private Button extensionRequestsButton;
        private Button awaitingReturnButton;
    }
}