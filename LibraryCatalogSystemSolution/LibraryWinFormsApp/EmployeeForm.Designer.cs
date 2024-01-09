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
            DataGridViewResources = new DataGridView();
            browseResources = new Button();
            addResource = new Button();
            deleteChosenResource = new Button();
            browseRequests = new Button();
            addNewCopy = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewResources).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lastNameLabel);
            panel1.Controls.Add(firstNameLabel);
            panel1.Controls.Add(logOut);
            panel1.Location = new Point(26, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(239, 242);
            panel1.TabIndex = 13;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(23, 94);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(178, 58);
            lastNameLabel.TabIndex = 10;
            lastNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(23, 24);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(178, 58);
            firstNameLabel.TabIndex = 9;
            firstNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // logOut
            // 
            logOut.Location = new Point(23, 178);
            logOut.Name = "logOut";
            logOut.Size = new Size(178, 47);
            logOut.TabIndex = 7;
            logOut.Text = "Log Out";
            logOut.UseVisualStyleBackColor = true;
            logOut.Click += logOut_Click;
            // 
            // DataGridViewResources
            // 
            DataGridViewResources.BackgroundColor = SystemColors.Control;
            DataGridViewResources.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewResources.Location = new Point(291, 12);
            DataGridViewResources.Name = "DataGridViewResources";
            DataGridViewResources.RowTemplate.Height = 25;
            DataGridViewResources.Size = new Size(961, 648);
            DataGridViewResources.TabIndex = 0;
            // 
            // browseResources
            // 
            browseResources.Location = new Point(26, 282);
            browseResources.Name = "browseResources";
            browseResources.Size = new Size(239, 40);
            browseResources.TabIndex = 1;
            browseResources.Text = "Browse Resources";
            browseResources.UseVisualStyleBackColor = true;
            browseResources.Click += browseResources_Click;
            // 
            // addResource
            // 
            addResource.Location = new Point(26, 339);
            addResource.Name = "addResource";
            addResource.Size = new Size(239, 40);
            addResource.TabIndex = 2;
            addResource.Text = "Add New Resource";
            addResource.UseVisualStyleBackColor = true;
            addResource.Click += addResource_Click;
            // 
            // deleteChosenResource
            // 
            deleteChosenResource.Location = new Point(26, 396);
            deleteChosenResource.Name = "deleteChosenResource";
            deleteChosenResource.Size = new Size(239, 40);
            deleteChosenResource.TabIndex = 3;
            deleteChosenResource.Text = "Delete Chosen Resource";
            deleteChosenResource.UseVisualStyleBackColor = true;
            deleteChosenResource.Click += deleteChosenResource_Click;
            // 
            // browseRequests
            // 
            browseRequests.Location = new Point(26, 517);
            browseRequests.Name = "browseRequests";
            browseRequests.Size = new Size(239, 40);
            browseRequests.TabIndex = 14;
            browseRequests.Text = "Browse Requests";
            browseRequests.UseVisualStyleBackColor = true;
            browseRequests.Click += browseRequests_Click;
            // 
            // addNewCopy
            // 
            addNewCopy.Location = new Point(26, 457);
            addNewCopy.Name = "addNewCopy";
            addNewCopy.Size = new Size(239, 40);
            addNewCopy.TabIndex = 15;
            addNewCopy.Text = "Add New Copy ";
            addNewCopy.UseVisualStyleBackColor = true;
            addNewCopy.Click += addNewCopy_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(addNewCopy);
            Controls.Add(browseRequests);
            Controls.Add(deleteChosenResource);
            Controls.Add(addResource);
            Controls.Add(panel1);
            Controls.Add(browseResources);
            Controls.Add(DataGridViewResources);
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridViewResources).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lastNameLabel;
        private Label firstNameLabel;
        private Button logOut;
        private DataGridView DataGridViewResources;
        private Button browseResources;
        private Button addResource;
        private Button deleteChosenResource;
        private Button browseRequests;
        private Button addNewCopy;
    }
}