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
            borrowRequest = new Button();
            copiesLabel = new Label();
            resourceTypeLabel = new Label();
            yearPublishedLabel = new Label();
            authorLabel = new Label();
            titleLabel = new Label();
            resourceIdLabel = new Label();
            resourceTypeTextBox = new TextBox();
            copiesTextBox = new TextBox();
            yearPublishedTextBox = new TextBox();
            authorTextBox = new TextBox();
            titleTextBox = new TextBox();
            resourceIdTextBox = new TextBox();
            availability = new Button();
            logOut = new Button();
            requestTab = new TabControl();
            tabPage1 = new TabPage();
            extendRequestTab = new TabPage();
            extendRental = new Button();
            statusLabel = new Label();
            dueDateLabel = new Label();
            copyIdLabel = new Label();
            requestDateLabel = new Label();
            resourceIdReqLabel = new Label();
            requestIdLabelrequestIdLabel = new Label();
            statusTextBox = new TextBox();
            dueDateTextBox = new TextBox();
            copyIdTextBox = new TextBox();
            requestDateTextBox = new TextBox();
            tresourceIdTextBox = new TextBox();
            requestIdTextBox = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            firstNameLabel = new Label();
            panel1 = new Panel();
            lastNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBorrowedResources).BeginInit();
            requestTab.SuspendLayout();
            tabPage1.SuspendLayout();
            extendRequestTab.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewBorrowedResources
            // 
            dataGridViewBorrowedResources.BackgroundColor = SystemColors.Control;
            dataGridViewBorrowedResources.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBorrowedResources.Location = new Point(481, 326);
            dataGridViewBorrowedResources.Name = "dataGridViewBorrowedResources";
            dataGridViewBorrowedResources.RowTemplate.Height = 25;
            dataGridViewBorrowedResources.Size = new Size(771, 334);
            dataGridViewBorrowedResources.TabIndex = 0;
            // 
            // showBorrowedResources
            // 
            showBorrowedResources.Location = new Point(53, 326);
            showBorrowedResources.Name = "showBorrowedResources";
            showBorrowedResources.Size = new Size(356, 80);
            showBorrowedResources.TabIndex = 1;
            showBorrowedResources.Text = "My borrowed books";
            showBorrowedResources.UseVisualStyleBackColor = true;
            showBorrowedResources.Click += showBorrowedResources_Click;
            // 
            // showBorrowRequests
            // 
            showBorrowRequests.Location = new Point(53, 433);
            showBorrowRequests.Name = "showBorrowRequests";
            showBorrowRequests.Size = new Size(356, 98);
            showBorrowRequests.TabIndex = 2;
            showBorrowRequests.Text = "My requests";
            showBorrowRequests.UseVisualStyleBackColor = true;
            showBorrowRequests.Click += showBorrowRequests_Click;
            // 
            // browseResources
            // 
            browseResources.Location = new Point(53, 571);
            browseResources.Name = "browseResources";
            browseResources.Size = new Size(356, 89);
            browseResources.TabIndex = 3;
            browseResources.Text = "Browse resources";
            browseResources.UseVisualStyleBackColor = true;
            browseResources.Click += browseResources_Click;
            // 
            // borrowRequest
            // 
            borrowRequest.Location = new Point(457, 140);
            borrowRequest.Name = "borrowRequest";
            borrowRequest.Size = new Size(268, 100);
            borrowRequest.TabIndex = 4;
            borrowRequest.Text = "Submit a borrow request";
            borrowRequest.UseVisualStyleBackColor = true;
            borrowRequest.Click += borrowRequest_Click;
            // 
            // copiesLabel
            // 
            copiesLabel.AutoSize = true;
            copiesLabel.Location = new Point(19, 220);
            copiesLabel.Name = "copiesLabel";
            copiesLabel.Size = new Size(43, 15);
            copiesLabel.TabIndex = 17;
            copiesLabel.Text = "Copies";
            // 
            // resourceTypeLabel
            // 
            resourceTypeLabel.AutoSize = true;
            resourceTypeLabel.Location = new Point(19, 178);
            resourceTypeLabel.Name = "resourceTypeLabel";
            resourceTypeLabel.Size = new Size(82, 15);
            resourceTypeLabel.TabIndex = 16;
            resourceTypeLabel.Text = "Resource Type";
            // 
            // yearPublishedLabel
            // 
            yearPublishedLabel.AutoSize = true;
            yearPublishedLabel.Location = new Point(19, 140);
            yearPublishedLabel.Name = "yearPublishedLabel";
            yearPublishedLabel.Size = new Size(84, 15);
            yearPublishedLabel.TabIndex = 15;
            yearPublishedLabel.Text = "Year Published";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(19, 100);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(44, 15);
            authorLabel.TabIndex = 14;
            authorLabel.Text = "Author";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(19, 58);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(29, 15);
            titleLabel.TabIndex = 13;
            titleLabel.Text = "Title";
            // 
            // resourceIdLabel
            // 
            resourceIdLabel.AutoSize = true;
            resourceIdLabel.Location = new Point(19, 20);
            resourceIdLabel.Name = "resourceIdLabel";
            resourceIdLabel.Size = new Size(66, 15);
            resourceIdLabel.TabIndex = 12;
            resourceIdLabel.Text = "ResourceID";
            // 
            // resourceTypeTextBox
            // 
            resourceTypeTextBox.Location = new Point(109, 175);
            resourceTypeTextBox.Name = "resourceTypeTextBox";
            resourceTypeTextBox.ReadOnly = true;
            resourceTypeTextBox.Size = new Size(268, 23);
            resourceTypeTextBox.TabIndex = 11;
            // 
            // copiesTextBox
            // 
            copiesTextBox.Location = new Point(109, 217);
            copiesTextBox.Name = "copiesTextBox";
            copiesTextBox.ReadOnly = true;
            copiesTextBox.Size = new Size(268, 23);
            copiesTextBox.TabIndex = 10;
            // 
            // yearPublishedTextBox
            // 
            yearPublishedTextBox.Location = new Point(109, 137);
            yearPublishedTextBox.Name = "yearPublishedTextBox";
            yearPublishedTextBox.ReadOnly = true;
            yearPublishedTextBox.Size = new Size(268, 23);
            yearPublishedTextBox.TabIndex = 9;
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(109, 97);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.ReadOnly = true;
            authorTextBox.Size = new Size(268, 23);
            authorTextBox.TabIndex = 8;
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(109, 55);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.ReadOnly = true;
            titleTextBox.Size = new Size(268, 23);
            titleTextBox.TabIndex = 7;
            // 
            // resourceIdTextBox
            // 
            resourceIdTextBox.Location = new Point(109, 17);
            resourceIdTextBox.Name = "resourceIdTextBox";
            resourceIdTextBox.ReadOnly = true;
            resourceIdTextBox.Size = new Size(268, 23);
            resourceIdTextBox.TabIndex = 6;
            // 
            // availability
            // 
            availability.Location = new Point(457, 12);
            availability.Name = "availability";
            availability.Size = new Size(268, 95);
            availability.TabIndex = 5;
            availability.Text = "Check availability";
            availability.UseVisualStyleBackColor = true;
            availability.Click += availability_Click;
            // 
            // logOut
            // 
            logOut.Location = new Point(7, 178);
            logOut.Name = "logOut";
            logOut.Size = new Size(339, 71);
            logOut.TabIndex = 7;
            logOut.Text = "Log Out";
            logOut.UseVisualStyleBackColor = true;
            logOut.Click += logOut_Click;
            // 
            // requestTab
            // 
            requestTab.Controls.Add(tabPage1);
            requestTab.Controls.Add(extendRequestTab);
            requestTab.Location = new Point(481, 12);
            requestTab.Name = "requestTab";
            requestTab.SelectedIndex = 0;
            requestTab.Size = new Size(771, 289);
            requestTab.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(copiesLabel);
            tabPage1.Controls.Add(resourceIdLabel);
            tabPage1.Controls.Add(resourceTypeLabel);
            tabPage1.Controls.Add(borrowRequest);
            tabPage1.Controls.Add(yearPublishedLabel);
            tabPage1.Controls.Add(availability);
            tabPage1.Controls.Add(authorLabel);
            tabPage1.Controls.Add(resourceIdTextBox);
            tabPage1.Controls.Add(titleLabel);
            tabPage1.Controls.Add(titleTextBox);
            tabPage1.Controls.Add(authorTextBox);
            tabPage1.Controls.Add(resourceTypeTextBox);
            tabPage1.Controls.Add(yearPublishedTextBox);
            tabPage1.Controls.Add(copiesTextBox);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(763, 261);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "New Request";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // extendRequestTab
            // 
            extendRequestTab.Controls.Add(extendRental);
            extendRequestTab.Controls.Add(statusLabel);
            extendRequestTab.Controls.Add(dueDateLabel);
            extendRequestTab.Controls.Add(copyIdLabel);
            extendRequestTab.Controls.Add(requestDateLabel);
            extendRequestTab.Controls.Add(resourceIdReqLabel);
            extendRequestTab.Controls.Add(requestIdLabelrequestIdLabel);
            extendRequestTab.Controls.Add(statusTextBox);
            extendRequestTab.Controls.Add(dueDateTextBox);
            extendRequestTab.Controls.Add(copyIdTextBox);
            extendRequestTab.Controls.Add(requestDateTextBox);
            extendRequestTab.Controls.Add(tresourceIdTextBox);
            extendRequestTab.Controls.Add(requestIdTextBox);
            extendRequestTab.Location = new Point(4, 24);
            extendRequestTab.Name = "extendRequestTab";
            extendRequestTab.Padding = new Padding(3);
            extendRequestTab.Size = new Size(763, 261);
            extendRequestTab.TabIndex = 1;
            extendRequestTab.Text = "Extend your rental";
            extendRequestTab.UseVisualStyleBackColor = true;
            // 
            // extendRental
            // 
            extendRental.Location = new Point(444, 61);
            extendRental.Name = "extendRental";
            extendRental.Size = new Size(268, 100);
            extendRental.TabIndex = 18;
            extendRental.Text = "Send a request to extend your rental";
            extendRental.UseVisualStyleBackColor = true;
            extendRental.Click += extendRental_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(9, 235);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 15);
            statusLabel.TabIndex = 24;
            statusLabel.Text = "Status";
            // 
            // dueDateLabel
            // 
            dueDateLabel.AutoSize = true;
            dueDateLabel.Location = new Point(9, 187);
            dueDateLabel.Name = "dueDateLabel";
            dueDateLabel.Size = new Size(55, 15);
            dueDateLabel.TabIndex = 23;
            dueDateLabel.Text = "Due Date";
            // 
            // copyIdLabel
            // 
            copyIdLabel.AutoSize = true;
            copyIdLabel.Location = new Point(9, 141);
            copyIdLabel.Name = "copyIdLabel";
            copyIdLabel.Size = new Size(46, 15);
            copyIdLabel.TabIndex = 22;
            copyIdLabel.Text = "CopyID";
            // 
            // requestDateLabel
            // 
            requestDateLabel.AutoSize = true;
            requestDateLabel.Location = new Point(9, 106);
            requestDateLabel.Name = "requestDateLabel";
            requestDateLabel.Size = new Size(76, 15);
            requestDateLabel.TabIndex = 21;
            requestDateLabel.Text = "Request Date";
            // 
            // resourceIdReqLabel
            // 
            resourceIdReqLabel.AutoSize = true;
            resourceIdReqLabel.Location = new Point(9, 61);
            resourceIdReqLabel.Name = "resourceIdReqLabel";
            resourceIdReqLabel.Size = new Size(66, 15);
            resourceIdReqLabel.TabIndex = 20;
            resourceIdReqLabel.Text = "ResourceID";
            // 
            // requestIdLabelrequestIdLabel
            // 
            requestIdLabelrequestIdLabel.AutoSize = true;
            requestIdLabelrequestIdLabel.Location = new Point(9, 21);
            requestIdLabelrequestIdLabel.Name = "requestIdLabelrequestIdLabel";
            requestIdLabelrequestIdLabel.Size = new Size(60, 15);
            requestIdLabelrequestIdLabel.TabIndex = 19;
            requestIdLabelrequestIdLabel.Text = "RequestID";
            // 
            // statusTextBox
            // 
            statusTextBox.Location = new Point(101, 227);
            statusTextBox.Name = "statusTextBox";
            statusTextBox.ReadOnly = true;
            statusTextBox.Size = new Size(268, 23);
            statusTextBox.TabIndex = 18;
            // 
            // dueDateTextBox
            // 
            dueDateTextBox.Location = new Point(101, 179);
            dueDateTextBox.Name = "dueDateTextBox";
            dueDateTextBox.ReadOnly = true;
            dueDateTextBox.Size = new Size(268, 23);
            dueDateTextBox.TabIndex = 17;
            // 
            // copyIdTextBox
            // 
            copyIdTextBox.Location = new Point(101, 133);
            copyIdTextBox.Name = "copyIdTextBox";
            copyIdTextBox.ReadOnly = true;
            copyIdTextBox.Size = new Size(268, 23);
            copyIdTextBox.TabIndex = 16;
            // 
            // requestDateTextBox
            // 
            requestDateTextBox.Location = new Point(101, 98);
            requestDateTextBox.Name = "requestDateTextBox";
            requestDateTextBox.ReadOnly = true;
            requestDateTextBox.Size = new Size(268, 23);
            requestDateTextBox.TabIndex = 15;
            // 
            // tresourceIdTextBox
            // 
            tresourceIdTextBox.Location = new Point(101, 53);
            tresourceIdTextBox.Name = "tresourceIdTextBox";
            tresourceIdTextBox.ReadOnly = true;
            tresourceIdTextBox.Size = new Size(268, 23);
            tresourceIdTextBox.TabIndex = 14;
            // 
            // requestIdTextBox
            // 
            requestIdTextBox.Location = new Point(101, 13);
            requestIdTextBox.Name = "requestIdTextBox";
            requestIdTextBox.ReadOnly = true;
            requestIdTextBox.Size = new Size(268, 23);
            requestIdTextBox.TabIndex = 13;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(7, 12);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(339, 63);
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
            panel1.Location = new Point(53, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 261);
            panel1.TabIndex = 12;
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(7, 97);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(337, 58);
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
            Controls.Add(requestTab);
            Controls.Add(browseResources);
            Controls.Add(showBorrowRequests);
            Controls.Add(showBorrowedResources);
            Controls.Add(dataGridViewBorrowedResources);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client";
            Load += ClientForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBorrowedResources).EndInit();
            requestTab.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            extendRequestTab.ResumeLayout(false);
            extendRequestTab.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewBorrowedResources;
        private Button showBorrowedResources;
        private Button showBorrowRequests;
        private Button browseResources;
        private Button borrowRequest;
        private Button availability;
        private TextBox authorTextBox;
        private TextBox titleTextBox;
        private TextBox resourceIdTextBox;
        private Label copiesLabel;
        private Label resourceTypeLabel;
        private Label yearPublishedLabel;
        private Label authorLabel;
        private Label titleLabel;
        private Label resourceIdLabel;
        private TextBox resourceTypeTextBox;
        private TextBox copiesTextBox;
        private TextBox yearPublishedTextBox;
        private Button logOut;
        private TabControl requestTab;
        private TabPage tabPage1;
        private TabPage extendRequestTab;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label firstNameLabel;
        private Panel panel1;
        private Label lastNameLabel;
        private TextBox requestIdTextBox;
        private TextBox statusTextBox;
        private TextBox dueDateTextBox;
        private TextBox copyIdTextBox;
        private TextBox requestDateTextBox;
        private TextBox tresourceIdTextBox;
        private Label resourceIdReqLabel;
        private Label requestIdLabelrequestIdLabel;
        private Label dueDateLabel;
        private Label copyIdLabel;
        private Label requestDateLabel;
        private Label statusLabel;
        private Button extendRental;
    }
}