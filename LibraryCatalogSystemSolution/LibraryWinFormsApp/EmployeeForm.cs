using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryDatabaseAPI;
using LibraryWinFormsApp.Properties;

namespace LibraryWinFormsApp
{
    public partial class EmployeeForm : Form
    {
        private User currentUser;
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;

        public EmployeeForm(User user)
        {
            this.currentUser = user;
            InitializeComponent();

            // Initialization of the LibraryDatabaseApi
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);

            // Display user information
            firstNameLabel.Text += currentUser.FirstName;
            lastNameLabel.Text += currentUser.LastName;

            // Adding the CellContentClick event handler
            dataGridViewEmployee.CellContentClick += DataGridViewEmployee_CellContentClick;
        }


        // Log out button click event
        private void LogOut_Click(object sender, EventArgs e)
        {
           this.Close();
        }


        // CellContentClick event handler
        private void DataGridViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewEmployee.Rows[e.RowIndex] != null)
            {
                string column = dataGridViewEmployee.Columns[e.ColumnIndex].Name;

                switch (column)
                {
                    case "ManageCopies":
                        HandleManageCopies((int)dataGridViewEmployee.Rows[e.RowIndex].Cells["ResourceID"].Value);
                        break;
                    case "DeleteResource":
                        HandleDeleteResource((int)dataGridViewEmployee.Rows[e.RowIndex].Cells["ResourceID"].Value);
                        break;
                    case "DeleteRequest":
                        HandleDeleteRequest((int)dataGridViewEmployee.Rows[e.RowIndex].Cells["RequestID"].Value);
                        break;
                    case "ReturnedCopy":
                        HandleReturn((int)dataGridViewEmployee.Rows[e.RowIndex].Cells["CopyID"].Value);
                        break;
                    case "ConsiderBorrowRequest":
                        HandleNewRequest((int)dataGridViewEmployee.Rows[e.RowIndex].Cells["RequestID"].Value,
                                         (int)dataGridViewEmployee.Rows[e.RowIndex].Cells["ResourceID"].Value);
                        break;
                    case "ConsiderExtension":
                        HandleExtendRequest((int)dataGridViewEmployee.Rows[e.RowIndex].Cells["RequestID"].Value,
                                            (int)dataGridViewEmployee.Rows[e.RowIndex].Cells["CopyID"].Value);
                        break;
                }
            }
        }




        private void BrowseResourcesButton_Click(object sender, EventArgs e)
        {
            RefreshResourcesView();
        }

        private void RequestsButton_Click(object sender, EventArgs e)
        {
            RefreshRequestsView();
        }

        private void NewRequestsButton_Click(object sender, EventArgs e)
        {
            RefreshNewRequestsView();
        }

        private void ExtensionRequests_Click(object sender, EventArgs e)
        {
            RefreshExtensionsRequestsView();
        }

        private void AwaitingReturnButton_Click(object sender, EventArgs e)
        {
            RefreshAwaitingReturnRequestsView();
        }

        private void AddResourceButton_Click(object sender, EventArgs e)
        {

            AddResourceForm addResourceForm = new AddResourceForm();


            addResourceForm.FormClosed += (s, args) =>
            {
                RefreshResourcesView();
            };
            addResourceForm.Show();
        }

        // Refresh the view of resources
        private void RefreshResourcesView()
        {
            // Get resources from the database
            var resources = api.GetResources();

            if (resources != null && resources.Count > 0)
            {
                // Modify the list for display
                var modifiedList = resources.Select(resource =>
                {
                    // Get additional information for each resource
                    var resourceAvailability = GetResourceAvailability(resource.ResourceID);
                    var resourceCopies = GetResourceCopyCount(resource.ResourceID);

                    // Add information to the list
                    return new
                    {
                        Title = resource.Title,
                        Author = resource.Author,
                        YearPublished = resource.YearPublished,
                        ResourceType = resource.ResourceType,
                        Copies = resourceCopies,
                        Availability = resourceAvailability,
                        ResourceID = resource.ResourceID
                    };
                }).ToList();


                // Clear DataGridView
                ClearDataGridView();

                // Set the modified list as the data source
                dataGridViewEmployee.DataSource = modifiedList;

                // Configure columns for the DataGridView
                ConfigureDataGridViewColumns(new List<string> { "ManageCopies", "DeleteResource" });


                dataGridViewEmployee.Columns["ResourceID"].DisplayIndex = 0;
                dataGridViewEmployee.Columns["Title"].DisplayIndex = 1;
                dataGridViewEmployee.Columns["Author"].DisplayIndex = 2;
                dataGridViewEmployee.Columns["YearPublished"].DisplayIndex = 3;
                dataGridViewEmployee.Columns["ResourceType"].DisplayIndex = 4;
                dataGridViewEmployee.Columns["Copies"].DisplayIndex = 5;
                dataGridViewEmployee.Columns["Availability"].DisplayIndex = 6;
                dataGridViewEmployee.Columns["ManageCopies"].DisplayIndex = 7;
                dataGridViewEmployee.Columns["DeleteResource"].DisplayIndex = 8;


                dataGridViewEmployee.Columns["ResourceID"].HeaderText = "Resource ID";
                dataGridViewEmployee.Columns["YearPublished"].HeaderText = "Year of Publication";
                dataGridViewEmployee.Columns["ResourceType"].HeaderText = "Type";
                dataGridViewEmployee.Columns["ManageCopies"].HeaderText = "Manage Copies";
                dataGridViewEmployee.Columns["DeleteResource"].HeaderText = "Delete Resource";


                DataGridViewButtonColumn manageCopiesButtonColumn = (DataGridViewButtonColumn)dataGridViewEmployee.Columns["ManageCopies"];
                manageCopiesButtonColumn.Text = "Manage";

                DataGridViewButtonColumn deleteResourceButtonColumn = (DataGridViewButtonColumn)dataGridViewEmployee.Columns["DeleteResource"];
                deleteResourceButtonColumn.Text = "Delete";

            }
            else
            {
                MessageBox.Show("No resources in the library.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDataGridView();
            }
        }


        private void RefreshRequestsView()
        {
            // Retrieve all requests and sort them by status and RequestDate
            var allRequests = api.GetBorrowRequests()?.OrderBy(request => request.ResourceID)
                                                       .ThenByDescending(request => request.RequestDate)
                                                       .ToList();

            if (allRequests != null && allRequests.Count > 0)
            {
                // Create a list for displaying in the DataGridViewResources
                var requestList = allRequests.Select(request =>
                {
                    var resource = api.GetResources().FirstOrDefault(r => r.ResourceID == request.ResourceID);

                    return new
                    {
                        RequestID = request.RequestID,
                        ResourceID = request.ResourceID,
                        CopyID = request?.CopyID,
                        ResourceTitle = resource.Title,
                        RequestDate = request?.RequestDate,
                        DueDate = request?.DueDate,
                        Status = request.Status
                    };
                }).ToList();

                ClearDataGridView();

                dataGridViewEmployee.DataSource = requestList;

                if (!dataGridViewEmployee.Columns.Contains("DeleteRequest"))
                {
                    ConfigureDataGridViewColumns(new List<string> { "DeleteRequest" });
                }

                dataGridViewEmployee.Columns["RequestID"].DisplayIndex = 0;
                dataGridViewEmployee.Columns["CopyID"].DisplayIndex = 1;
                dataGridViewEmployee.Columns["ResourceTitle"].DisplayIndex = 2;
                dataGridViewEmployee.Columns["RequestDate"].DisplayIndex = 3;
                dataGridViewEmployee.Columns["DueDate"].DisplayIndex = 4;
                dataGridViewEmployee.Columns["Status"].DisplayIndex = 5;
                dataGridViewEmployee.Columns["DeleteRequest"].DisplayIndex = 6;
                dataGridViewEmployee.Columns["ResourceID"].Visible = false;

                dataGridViewEmployee.Columns["RequestID"].HeaderText = "Resource ID";
                dataGridViewEmployee.Columns["CopyID"].HeaderText = "Copy ID";
                dataGridViewEmployee.Columns["RequestDate"].HeaderText = "Request Date";
                dataGridViewEmployee.Columns["DueDate"].HeaderText = "Due Date";
                dataGridViewEmployee.Columns["DeleteRequest"].HeaderText = "Delete Request";

                DataGridViewButtonColumn deleteRequestButtonColumn = (DataGridViewButtonColumn)dataGridViewEmployee.Columns["DeleteRequest"];
                deleteRequestButtonColumn.Text = "Delete";
            }
            else
            {
                MessageBox.Show("No requests in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDataGridView();
            }
        }

        private void RefreshNewRequestsView()
        {
            // Retrieve all requests and order them by RequestDate
            var allRequests = api.GetBorrowRequests()?.OrderBy(request => request.RequestDate).ToList();

            if (allRequests != null && allRequests.Count > 0)
            {
                // Select only borrowing requests that do not have an assigned CopyID
                var newRequests = allRequests.Where(request => request.CopyID == null).ToList();

                // Create a list for displaying in the DataGridViewResources
                var requestList = newRequests.Select(request =>
                {
                    var resource = api.GetResources().FirstOrDefault(r => r.ResourceID == request.ResourceID);

                    return new
                    {
                        RequestID = request.RequestID,
                        ResourceID = request.ResourceID,
                        ResourceTitle = resource.Title,
                        RequestDate = request.RequestDate,
                        Status = request.Status
                    };
                }).ToList();

                ClearDataGridView();

                dataGridViewEmployee.DataSource = requestList;

                if (!dataGridViewEmployee.Columns.Contains("ConsiderBorrowRequest"))
                {
                    ConfigureDataGridViewColumns(new List<string> { "ConsiderBorrowRequest" });
                }

                dataGridViewEmployee.Columns["RequestID"].DisplayIndex = 0;
                dataGridViewEmployee.Columns["ResourceTitle"].DisplayIndex = 1;
                dataGridViewEmployee.Columns["RequestDate"].DisplayIndex = 2;
                dataGridViewEmployee.Columns["Status"].DisplayIndex = 3;
                dataGridViewEmployee.Columns["ConsiderBorrowRequest"].DisplayIndex = 4;
                dataGridViewEmployee.Columns["ResourceID"].Visible = false;

                dataGridViewEmployee.Columns["RequestID"].HeaderText = "Resource ID";
                dataGridViewEmployee.Columns["ResourceTitle"].HeaderText = "Title";
                dataGridViewEmployee.Columns["RequestDate"].HeaderText = "Request Date";
                dataGridViewEmployee.Columns["ConsiderBorrowRequest"].HeaderText = "Consider Borrow Request";

                DataGridViewButtonColumn considerBorrowButtonColumn = (DataGridViewButtonColumn)dataGridViewEmployee.Columns["ConsiderBorrowRequest"];
                considerBorrowButtonColumn.Text = "Consider";
            }
            else
            {
                MessageBox.Show("No borrowing requests in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDataGridView();
            }
        }


        private void RefreshExtensionsRequestsView()
        {
            // Retrieve all borrowing requests and order them by status and RequestDate
            var allRequests = api.GetBorrowRequests()?.OrderBy(request => request.RequestDate).ToList();

            if (allRequests != null && allRequests.Count > 0)
            {
                // Select only borrowing requests with status "Pending" and have an assigned CopyID
                var filteredRequests = allRequests.Where(request => request.Status.ToString() == "Pending" && request.CopyID != null).ToList();

                // Create a list for displaying in the DataGridViewResources
                var requestList = filteredRequests.Select(request =>
                {
                    var resource = api.GetResources().FirstOrDefault(r => r.ResourceID == request.ResourceID);

                    return new
                    {
                        RequestID = request.RequestID,
                        ResourceID = request.ResourceID,
                        CopyID = request?.CopyID,
                        ResourceTitle = resource.Title,
                        RequestDate = request.RequestDate,
                        DueDate = request?.DueDate,
                        Status = request.Status
                    };
                }).ToList();

                ClearDataGridView();

                dataGridViewEmployee.DataSource = requestList;

                if (!dataGridViewEmployee.Columns.Contains("ConsiderExtension"))
                {
                    ConfigureDataGridViewColumns(new List<string> { "ConsiderExtension" });
                }

                dataGridViewEmployee.Columns["RequestID"].DisplayIndex = 0;
                dataGridViewEmployee.Columns["CopyID"].DisplayIndex = 1;
                dataGridViewEmployee.Columns["ResourceTitle"].DisplayIndex = 2;
                dataGridViewEmployee.Columns["RequestDate"].DisplayIndex = 3;
                dataGridViewEmployee.Columns["DueDate"].DisplayIndex = 4;
                dataGridViewEmployee.Columns["Status"].DisplayIndex = 5;
                dataGridViewEmployee.Columns["ConsiderExtension"].DisplayIndex = 6;
                dataGridViewEmployee.Columns["ResourceID"].Visible = false;

                dataGridViewEmployee.Columns["RequestID"].HeaderText = "Resource ID";
                dataGridViewEmployee.Columns["CopyID"].HeaderText = "Copy ID";
                dataGridViewEmployee.Columns["ResourceTitle"].HeaderText = "Title";
                dataGridViewEmployee.Columns["RequestDate"].HeaderText = "Request Date";
                dataGridViewEmployee.Columns["DueDate"].HeaderText = "Due Date";
                dataGridViewEmployee.Columns["ConsiderExtension"].HeaderText = "Consider Extension";

                DataGridViewButtonColumn considerExtensionButtonColumn = (DataGridViewButtonColumn)dataGridViewEmployee.Columns["ConsiderExtension"];
                considerExtensionButtonColumn.Text = "Consider";
            }
            else
            {
                MessageBox.Show("No borrowing requests in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDataGridView();
            }
        }
        private void RefreshAwaitingReturnRequestsView()
        {
            // Retrieve all borrowing requests and order them by status and RequestDate
            var allRequests = api.GetBorrowRequests()?.OrderBy(request => request.RequestDate).ToList();

            if (allRequests != null && allRequests.Count > 0)
            {
                // Select only borrowing requests with status "Approved"
                var approvedRequests = allRequests.Where(request => request.Status.ToString() == "Approved").ToList();

                // Create a list for displaying in the DataGridViewResources
                var requestList = approvedRequests.Select(request =>
                {
                    var resource = api.GetResources().FirstOrDefault(r => r.ResourceID == request.ResourceID);

                    return new
                    {
                        RequestID = request.RequestID,
                        ResourceID = request.ResourceID,
                        CopyID = request?.CopyID,
                        ResourceTitle = resource.Title,
                        RequestDate = request.RequestDate,
                        DueDate = request?.DueDate,
                        Status = request.Status
                    };
                }).ToList();

                ClearDataGridView();

                dataGridViewEmployee.DataSource = requestList;

                if (!dataGridViewEmployee.Columns.Contains("ReturnedCopy"))
                {
                    ConfigureDataGridViewColumns(new List<string> { "ReturnedCopy" });
                }

                dataGridViewEmployee.Columns["RequestID"].DisplayIndex = 0;
                dataGridViewEmployee.Columns["CopyID"].DisplayIndex = 1;
                dataGridViewEmployee.Columns["ResourceTitle"].DisplayIndex = 2;
                dataGridViewEmployee.Columns["RequestDate"].DisplayIndex = 3;
                dataGridViewEmployee.Columns["DueDate"].DisplayIndex = 4;
                dataGridViewEmployee.Columns["Status"].DisplayIndex = 5;
                dataGridViewEmployee.Columns["ReturnedCopy"].DisplayIndex = 6;
                dataGridViewEmployee.Columns["ResourceID"].Visible = false;

                dataGridViewEmployee.Columns["RequestID"].HeaderText = "Resource ID";
                dataGridViewEmployee.Columns["CopyID"].HeaderText = "Copy ID";
                dataGridViewEmployee.Columns["ResourceTitle"].HeaderText = "Title";
                dataGridViewEmployee.Columns["RequestDate"].HeaderText = "Request Date";
                dataGridViewEmployee.Columns["DueDate"].HeaderText = "Due Date";
                dataGridViewEmployee.Columns["ReturnedCopy"].HeaderText = "Return a Copy";

                DataGridViewButtonColumn returnCopyButtonColumn = (DataGridViewButtonColumn)dataGridViewEmployee.Columns["ReturnedCopy"];
                returnCopyButtonColumn.Text = "Return";
            }
            else
            {
                MessageBox.Show("No borrowing requests in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDataGridView();
            }
        }


        private void HandleManageCopies(int resourceID)
        {
            var resources = api.GetResources();
            Resource selectedResource = resources.FirstOrDefault(resource => resource.ResourceID == resourceID);

            // Display a confirmation message
            DialogResult result = MessageBox.Show($"Are you sure you want to proceed to manage copies for the resource:\n{selectedResource}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Open the ManagingResourceCopies window with the provided resourceID
                ManagingResourceCopies managingResourceCopiesForm = new ManagingResourceCopies(resourceID);

                // Add handling for the FormClosed event
                managingResourceCopiesForm.FormClosed += (sender, e) =>
                {
                    // After closing the form, refresh the DataGridView
                    RefreshResourcesView();
                };

                managingResourceCopiesForm.Show();
            }
        }


        private void HandleDeleteResource(int resourceID)
        {
            // Get the list of resources
            var resources = api.GetResources();
            Resource selectedResource = resources.FirstOrDefault(resource => resource.ResourceID == resourceID);

            // Display a confirmation message
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the selected resource:\n{selectedResource}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Check if there are approved borrow requests for this resource
                var approvedRequests = api.GetBorrowRequests(Status.Approved);

                if (approvedRequests != null && approvedRequests.Any(request => request.ResourceID == resourceID))
                {
                    MessageBox.Show("Cannot delete the resource as there are approved borrow requests.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if there are borrow requests for this resource
                var requestsToDelete = api.GetBorrowRequestsByResource(resourceID);

                if (requestsToDelete != null && requestsToDelete.Any())
                {
                    // Display a confirmation message
                    DialogResult confirmation = MessageBox.Show($"Deleting the resource will also delete {requestsToDelete.Count} borrow request(s). Do you want to continue?", "Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmation == DialogResult.No)
                    {
                        return;
                    }

                    // Delete borrow requests
                    foreach (var request in requestsToDelete)
                    {
                        bool requestDeleted = api.DeleteBorrowRequest(request.RequestID);

                        if (!requestDeleted)
                        {
                            MessageBox.Show("Error deleting borrow request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Delete resource copies
                var resourceCopiesToDelete = api.GetResourceCopiesByResource(resourceID);

                if (resourceCopiesToDelete != null && resourceCopiesToDelete.Any())
                {
                    foreach (var copy in resourceCopiesToDelete)
                    {
                        bool copyDeleted = api.DeleteResourceCopy(copy.CopyID);

                        if (!copyDeleted)
                        {
                            MessageBox.Show("Error deleting resource copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Delete the resource
                bool resourceDeleted = api.DeleteResource(resourceID);

                if (resourceDeleted)
                {
                    MessageBox.Show("Resource successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshResourcesView();
                }
                else
                {
                    MessageBox.Show("Error deleting resource.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HandleDeleteRequest(int requestID)
        {
            var request = api.GetBorrowRequestById(requestID);

            if (request == null)
            {
                MessageBox.Show("No borrow request found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display a confirmation message
            DialogResult result = MessageBox.Show($"Do you want to delete the following borrow request:\n{request}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool shouldDeleteRequest = request.Status == Status.Returned || (request.Status == Status.Pending && request.CopyID == null);

                if (shouldDeleteRequest)
                {
                    bool requestDeleted = api.DeleteBorrowRequest(requestID);

                    if (requestDeleted)
                    {
                        MessageBox.Show("The request has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshRequestsView();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting the borrow request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot delete the borrow request. Check the status and CopyID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HandleReturn(int copyID)
        {
            // Check if there is an approved borrow request for the given CopyID
            var approvedRequest = api.GetBorrowRequests(Status.Approved)
                                        .FirstOrDefault(request => request.CopyID == copyID);

            if (approvedRequest == null)
            {
                MessageBox.Show("No approved borrow request found for the given copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display a confirmation message
            DialogResult result = MessageBox.Show($"Do you want to confirm the return of the following copy:\n{copyID}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Update the borrow request status to "Returned"
                bool updateSuccess = api.UpdateBorrowRequestStatusToReturned(copyID);

                if (updateSuccess)
                {
                    MessageBox.Show("Return has been successfully registered.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshAwaitingReturnRequestsView();
                }
                else
                {
                    MessageBox.Show("Error updating the borrow request status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void HandleNewRequest(int requestID, int resourceID)
        {
            var currentRequest = api.GetBorrowRequestById(requestID);

            // Display a confirmation message
            DialogResult result = MessageBox.Show($"Do you want to review the submitted request:\n{currentRequest}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Check if there are available copies
                int availableCopies = GetResourceAvailability(resourceID);

                if (availableCopies > 0)
                {
                    // Ask the user if they want to accept the request
                    DialogResult decision = MessageBox.Show("There are available copies for this request. Do you want to accept the request?", "Accept Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (decision == DialogResult.Yes)
                    {
                        // Open the AcceptRequestForm
                        AcceptRequestForm acceptRequestForm = new AcceptRequestForm(requestID, resourceID);

                        // Show the form
                        acceptRequestForm.ShowDialog();
                        RefreshNewRequestsView();
                    }
                }
                else
                {
                    MessageBox.Show("No available copies for this request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void HandleExtendRequest(int requestID, int copyID)
        {
            // Retrieve the request
            var currentRequest = api.GetBorrowRequestById(requestID);

            if (currentRequest != null)
            {

                // Display a confirmation message
                DialogResult result = MessageBox.Show($"Do you want to review the submitted request:\n{currentRequest}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Ask the user if they want to extend the borrowing period
                    var decision = MessageBox.Show("Do you want to extend the borrowing period?", "Extending Period", MessageBoxButtons.YesNo);

                    if (decision == DialogResult.Yes)
                    {
                        // Create the acceptance form with the original request date
                        ExtendRequestForm acceptRequestForm = new ExtendRequestForm(requestID, copyID);
                        acceptRequestForm.ShowDialog();
                        RefreshExtensionsRequestsView();
                    }
                    else
                    {
                        DateOnly dueDate = currentRequest.DueDate.Value;
                        bool success = api.UpdateBorrowRequestStatusToApproved(requestID, copyID, dueDate);
                        RefreshExtensionsRequestsView();
                    }
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

                dataGridViewEmployee.Columns.Add(columnNameButton);
            }
        }

        private int GetResourceAvailability(int resourceID)
        {

            // Get resource amounts using the GetResourceAmounts function
            var resourceAmounts = api.GetResourceAmounts(resourceID);


            if (resourceAmounts.HasValue)
            {
                return resourceAmounts.Value.available;
            }
            else
            {
                MessageBox.Show("Error retrieving resource amounts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetResourceCopyCount(int resourceID)
        {
            // Retrieve the number of copies for the given resource (resourceID)
            var resourceAmounts = api.GetResourceAmounts(resourceID);

            if (resourceAmounts.HasValue)
            {
                // Return the number of copies for the given resource
                return resourceAmounts.Value.amount;
            }
            else
            {
                // Handle the situation when it's not possible to retrieve the resource count
                return -1; // Or any other value indicating an error
            }
        }



        private void ClearDataGridView()
        {
            dataGridViewEmployee.DataSource = null;
            dataGridViewEmployee.Rows.Clear();
            dataGridViewEmployee.Columns.Clear();
        }

        
    }
}
