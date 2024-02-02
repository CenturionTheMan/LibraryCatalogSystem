using System;
using System.Text;
using System.Windows.Forms;
using LibraryDatabaseAPI;
using LibraryWinFormsApp.Properties;
using Microsoft.VisualBasic;

namespace LibraryWinFormsApp
{
    public partial class ManagingResourceCopies : Form
    {
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        DatabaseApi api;
        private int currentResourceID;

        // Constructor with added resourceId parameter
        public ManagingResourceCopies(int resourceID)
        {
            this.currentResourceID = resourceID;
            InitializeComponent();

            // Initialize LibraryDatabaseApi
            api = new DatabaseApi(PROVIDER, CONNECTION_STRING);

            dataGridViewCopies.CellContentClick += DataGridViewCopies_CellContentClick;

            // Call the method to load data when the form is opened
            ManagingResourceCopies_Load(this, EventArgs.Empty);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void ReturnToResourcesButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagingResourceCopies_Load(object sender, EventArgs e)
        {
            // Get information about the resource based on resourceId
            Resource? resource = api.GetResourceById(currentResourceID);

            // Check if the resource was found
            if (resource is not null)
            {
                // Set label values based on resource information
                resourceIdLabel.Text = $"Resource ID: {resource.ResourceID}";
                titleLabel.Text = $"Title: {resource.Title}";
                authorLabel.Text = $"Author: {resource.Author}";
                yearPublishedLabel.Text = $"Year Published: {resource.YearPublished}";
                typeLabel.Text = $"Type: {resource.ResourceType}";
                RefreshCopiesView(currentResourceID);
            }
            else
            {
                // If the resource was not found, display a message or take appropriate action
                MessageBox.Show("Resource not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // You can also close the window if the resource does not exist
            }
        }

        private void AddCopyButton_Click(object sender, EventArgs e)
        {
            Resource? selectedResource = api.GetResourceById(currentResourceID);

            if(selectedResource is null)
            {
                MessageBox.Show("Resource not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Do you want to add a new copy of the resource:\n{selectedResource}?", "Confirmation to Add Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = api.PostNewResourceCopy(currentResourceID);

                if (success)
                {
                    MessageBox.Show("New copy has been successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCopiesView(currentResourceID);
                }
                else
                {
                    MessageBox.Show("Error adding a new copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshCopiesView(int currentResourceID)
        {
            var copies = api.GetResourceCopiesByResource(currentResourceID);
            var borrowRequests = api.GetBorrowRequestsByResource(currentResourceID);

            if(borrowRequests is null)
            {
                MessageBox.Show("Error loading borrow requests.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (copies is not null && copies.Count > 0)
            {
                var modifiedList = copies
                    .Select(copy =>
                    {
                        var borrowRequest = borrowRequests.FirstOrDefault(request => request.CopyID == copy.CopyID
                            && (request.Status.ToString() == "Approved" || request.Status.ToString() == "Pending"));

                        var isBorrowed = borrowRequest != null;
                        var dueDate = borrowRequest?.DueDate;

                        return new
                        {
                            copy.CopyID,
                            Status = isBorrowed ? "Borrowed" : "Ready",
                            DueDate = dueDate
                        };
                    }).ToList();


                
                dataGridViewCopies.DataSource = modifiedList;

                if (!dataGridViewCopies.Columns.Contains("Delete"))
                {
                    ConfigureDataGridViewColumns(new List<string> { "Delete" });
                }

                dataGridViewCopies.Columns["CopyID"].DisplayIndex = 0;
                dataGridViewCopies.Columns["Status"].DisplayIndex = 1;
                dataGridViewCopies.Columns["DueDate"].DisplayIndex = 2;
                dataGridViewCopies.Columns["Delete"].DisplayIndex = 3;

                dataGridViewCopies.Columns["CopyID"].HeaderText = "CopyID";
                dataGridViewCopies.Columns["Status"].HeaderText = "Status";
                dataGridViewCopies.Columns["DueDate"].HeaderText = "Due Date";
                dataGridViewCopies.Columns["Delete"].HeaderText = "Delete Copy";
            }
            else
            {
                ClearDataGridView();
            }
        }

        private void DataGridViewCopies_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridViewCopies.Rows[e.RowIndex] != null)
                {
                    if (dataGridViewCopies.Columns.Contains("Delete") && e.ColumnIndex == dataGridViewCopies.Columns["Delete"].Index)
                    {
                        HandleDeleteCopies((int)dataGridViewCopies.Rows[e.RowIndex].Cells["CopyID"].Value,
                                            (DateOnly?)dataGridViewCopies.Rows[e.RowIndex].Cells["DueDate"].Value);
                    }

                }
            }
        }

        private void HandleDeleteCopies(int toDeleteCopy, DateOnly? CopyDueDate)
        {

            DialogResult result = MessageBox.Show($"Are you sure you want to delete copy: {toDeleteCopy}?", "Confirmation to Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (CopyDueDate == null) {

                    bool success = api.DeleteResourceCopy(toDeleteCopy);

                    if (success)
                    {
                        MessageBox.Show("Copy has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshCopiesView(currentResourceID);
                    }
                    else
                    {
                        MessageBox.Show("Error deleting the copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The copy is borrowed and cannot be removed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
   
            }
        }

        private void ConfigureDataGridViewColumns(List<string> columnNames)
        {
            foreach (var columnName in columnNames)
            {
                DataGridViewButtonColumn columnNameButton = new DataGridViewButtonColumn
                {
                    Name = columnName,
                    Text = columnName,
                    UseColumnTextForButtonValue = true
                };

                dataGridViewCopies.Columns.Add(columnNameButton);
            }
        }

        private void ClearDataGridView()
        {
            dataGridViewCopies.DataSource = null;
            dataGridViewCopies.Rows.Clear();
            dataGridViewCopies.Columns.Clear();
        }
    }
}
