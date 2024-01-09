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
            dataGridViewBorrowedResources = new DataGridView();
            showBorrowedResources = new Button();
            showBorrowRequests = new Button();
            browseResources = new Button();
            logOut = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            firstNameLabel = new Label();
            panel1 = new Panel();
            lastNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBorrowedResources).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewBorrowedResources
            // 
            dataGridViewBorrowedResources.BackgroundColor = SystemColors.Control;
            dataGridViewBorrowedResources.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBorrowedResources.Location = new Point(254, 12);
            dataGridViewBorrowedResources.Name = "dataGridViewBorrowedResources";
            dataGridViewBorrowedResources.RowTemplate.Height = 25;
            dataGridViewBorrowedResources.Size = new Size(998, 657);
            dataGridViewBorrowedResources.TabIndex = 0;
            // 
            // showBorrowedResources
            // 
            showBorrowedResources.Location = new Point(12, 250);
            showBorrowedResources.Name = "showBorrowedResources";
            showBorrowedResources.Size = new Size(219, 44);
            showBorrowedResources.TabIndex = 1;
            showBorrowedResources.Text = "My borrowed books";
            showBorrowedResources.UseVisualStyleBackColor = true;
            showBorrowedResources.Click += showBorrowedResources_Click;
            // 
            // showBorrowRequests
            // 
            showBorrowRequests.Location = new Point(12, 314);
            showBorrowRequests.Name = "showBorrowRequests";
            showBorrowRequests.Size = new Size(219, 40);
            showBorrowRequests.TabIndex = 2;
            showBorrowRequests.Text = "My requests";
            showBorrowRequests.UseVisualStyleBackColor = true;
            showBorrowRequests.Click += showBorrowRequests_Click;
            // 
            // browseResources
            // 
            browseResources.Location = new Point(12, 370);
            browseResources.Name = "browseResources";
            browseResources.Size = new Size(214, 40);
            browseResources.TabIndex = 3;
            browseResources.Text = "Browse resources";
            browseResources.UseVisualStyleBackColor = true;
            browseResources.Click += browseResources_Click;
            // 
            // logOut
            // 
            logOut.Location = new Point(7, 165);
            logOut.Name = "logOut";
            logOut.Size = new Size(196, 41);
            logOut.TabIndex = 7;
            logOut.Text = "Log Out";
            logOut.UseVisualStyleBackColor = true;
            logOut.Click += logOut_Click;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(7, 12);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(196, 51);
            firstNameLabel.TabIndex = 9;
            firstNameLabel.TextAlign = ContentAlignment.MiddleCenter;
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
            panel1.Size = new Size(219, 217);
            panel1.TabIndex = 12;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(7, 97);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(196, 51);
            lastNameLabel.TabIndex = 10;
            lastNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel1);
            Controls.Add(browseResources);
            Controls.Add(showBorrowRequests);
            Controls.Add(showBorrowedResources);
            Controls.Add(dataGridViewBorrowedResources);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBorrowedResources).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewBorrowedResources;
        private Button showBorrowedResources;
        private Button showBorrowRequests;
        private Button browseResources;
        private Button logOut;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label firstNameLabel;
        private Panel panel1;
        private Label lastNameLabel;
    }
}