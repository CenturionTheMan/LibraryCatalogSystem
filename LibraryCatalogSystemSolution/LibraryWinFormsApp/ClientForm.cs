using LibraryDatabaseAPI;

namespace LibraryWinFormsApp;

public partial class ClientForm : Form
{
    const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

    private DatabaseApi api;
    private User currentUser;

    public ClientForm(User user)
    {
        this.currentUser = user;
        InitializeComponent();

        // Initialize the LibraryDatabaseApi
        api = new DatabaseApi(PROVIDER, CONNECTION_STRING);

        // Display user information
        firstNameLabel.Text += currentUser.FirstName;
        lastNameLabel.Text += currentUser.LastName;
        // Add CellContentClick event handling
        dataGridViewClient.CellContentClick += dataGridViewClient_CellContentClick;
    }

    private void dataGridViewClient_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dataGridViewClient.Rows[e.RowIndex] != null)
        {
            string column = dataGridViewClient.Columns[e.ColumnIndex].Name;

            switch (column)
            {
                case "Borrow":
                    HandleBorrowRequest((int)dataGridViewClient.Rows[e.RowIndex].Cells["ResourceID"].Value);
                    break;
                case "Extend":
                    HandleExtendRental((int)dataGridViewClient.Rows[e.RowIndex].Cells["RequestID"].Value);
                    break;
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

            dataGridViewClient.Columns.Add(columnNameButton);
        }
    }

    private void logOutButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void borrowedResourcesButton_Click(object sender, EventArgs e)
    {
        RefreshMyResourcesView();
    }

    private void borrowRequestsButton_Click(object sender, EventArgs e)
    {
        RefreshBorrowRequestsView();
    }

    private void allResourcesButton_Click(object sender, EventArgs e)
    {
        RefreshAllResourcesView();
    }

    //private void RefreshBorrowedResourcesView()
    //{
    //    var borrowedResources = api.GetResourcesBorrowedByUser(currentUser.UserID);

    //    if (borrowedResources != null && borrowedResources.Any())
    //    {
    //        RefreshResourcesView(borrowedResources);
    //    }
    //    else
    //    {
    //        MessageBox.Show("No borrowed resources.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    }
    //}

    private void RefreshAllResourcesView()
    {
        var resources = api.GetResources();

        if (resources != null && resources.Any())
        {
            RefreshResourcesView(resources);
        }
        else
        {
            MessageBox.Show("No resources in the library.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void RefreshResourcesView(IEnumerable<Resource> source)
    {
        var modifiedList = source.Select(resource =>
        {
            var resourceAvailability = GetResourceAvailabilityForClient(resource.ResourceID);

            // Add information to the list
            return new
            {
                Title = resource.Title,
                Author = resource.Author,
                YearPublished = resource.YearPublished,
                ResourceType = resource.ResourceType,
                Availability = resourceAvailability,
                ResourceID = resource.ResourceID
            };
        }).ToList();

        ClearDataGridView();

        // Set the new list as the data source
        dataGridViewClient.DataSource = modifiedList;

        if (!dataGridViewClient.Columns.Contains("Borrow"))
        {
            ConfigureDataGridViewColumns(new List<string> { "Borrow" });
        }

        // Set the column order in dataGridViewClient
        dataGridViewClient.Columns["Title"].DisplayIndex = 0;
        dataGridViewClient.Columns["Author"].DisplayIndex = 1;
        dataGridViewClient.Columns["YearPublished"].DisplayIndex = 2;
        dataGridViewClient.Columns["ResourceType"].DisplayIndex = 3;
        dataGridViewClient.Columns["Availability"].DisplayIndex = 4;
        dataGridViewClient.Columns["Borrow"].DisplayIndex = 5;

        dataGridViewClient.Columns["ResourceID"].Visible = false;

        dataGridViewClient.Columns["Title"].HeaderText = "Title";
        dataGridViewClient.Columns["Author"].HeaderText = "Author";
        dataGridViewClient.Columns["YearPublished"].HeaderText = "Year of Publication";
        dataGridViewClient.Columns["ResourceType"].HeaderText = "Type";
        dataGridViewClient.Columns["Availability"].HeaderText = "Number of Copies Available";
        dataGridViewClient.Columns["Borrow"].HeaderText = "Borrow a Resource";
    }

    private void RefreshMyResourcesView()
    {
        var userRes = api.GetResourcesBorrowedByUser(currentUser.UserID);
        var userBorrowed = api.GetBorrowRequestsByUser(currentUser.UserID);

        if(userBorrowed == null || userRes == null)
        {
            MessageBox.Show("No borrowed resources.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        userBorrowed = userBorrowed.Where(r => r.Status == Status.Approved).ToList();

        var modifiedList = userBorrowed.Select(req =>
        {
            var resource = userRes.FirstOrDefault(res => res.ResourceID == req.ResourceID)!;
            var resourceAvailability = GetResourceAvailabilityForClient(resource.ResourceID);

            // Add information to the list
            return new
            {
                Title = resource.Title,
                Author = resource.Author,
                YearPublished = resource.YearPublished,
                ResourceType = resource.ResourceType,
                DueDate = req.DueDate,
            };
        }).ToList();

        ClearDataGridView();

        // Set the new list as the data source
        dataGridViewClient.DataSource = modifiedList;

        // Set the column order in dataGridViewClient
        dataGridViewClient.Columns["Title"].DisplayIndex = 0;
        dataGridViewClient.Columns["Author"].DisplayIndex = 1;
        dataGridViewClient.Columns["YearPublished"].DisplayIndex = 2;
        dataGridViewClient.Columns["ResourceType"].DisplayIndex = 3;
        dataGridViewClient.Columns["DueDate"].DisplayIndex = 4;

        dataGridViewClient.Columns["Title"].HeaderText = "Title";
        dataGridViewClient.Columns["Author"].HeaderText = "Author";
        dataGridViewClient.Columns["YearPublished"].HeaderText = "Year of Publication";
        dataGridViewClient.Columns["ResourceType"].HeaderText = "Type";
        dataGridViewClient.Columns["DueDate"].HeaderText = "Due date";
    }

    private void RefreshBorrowRequestsView()
    {
        var borrowRequests = api.GetBorrowRequestsByUser(currentUser.UserID);

        if (borrowRequests != null && borrowRequests.Count > 0)
        {
            // Create a new list of objects with relevant fields
            var modifiedList = new List<object>();

            foreach (var request in borrowRequests)
            {
                // Find the resource based on ResourceID in the database
                var resource = api.GetResourceById(request.ResourceID);

                if (resource != null)
                {
                    // Add information to the list
                    modifiedList.Add(new
                    {
                        RequestID = request.RequestID,
                        Status = request.Status,
                        Title = resource.Title,
                        Author = resource.Author,
                        ResourceType = resource.ResourceType,
                        RequestDate = request.RequestDate,
                        DueDate = request.DueDate,
                    });
                }
            }

            ClearDataGridView();

            // Set the new list as the data source
            dataGridViewClient.DataSource = modifiedList;

            if (!dataGridViewClient.Columns.Contains("Extend"))
            {
                ConfigureDataGridViewColumns(new List<string> { "Extend" });
            }

            dataGridViewClient.Columns["RequestID"].DisplayIndex = 0;
            dataGridViewClient.Columns["Status"].DisplayIndex = 1;
            dataGridViewClient.Columns["Title"].DisplayIndex = 2;
            dataGridViewClient.Columns["RequestDate"].DisplayIndex = 3;
            dataGridViewClient.Columns["DueDate"].DisplayIndex = 4;
            dataGridViewClient.Columns["Author"].DisplayIndex = 5;
            dataGridViewClient.Columns["ResourceType"].DisplayIndex = 6;
            dataGridViewClient.Columns["Extend"].DisplayIndex = 7;


            dataGridViewClient.Columns["RequestID"].HeaderText = "Request ID";
            dataGridViewClient.Columns["Status"].HeaderText = "Status";
            dataGridViewClient.Columns["Title"].HeaderText = "Title";
            dataGridViewClient.Columns["RequestDate"].HeaderText = "Request Date";
            dataGridViewClient.Columns["DueDate"].HeaderText = "Due Date";
            dataGridViewClient.Columns["Author"].HeaderText = "Author";
            dataGridViewClient.Columns["ResourceType"].HeaderText = "Type";
            dataGridViewClient.Columns["Extend"].HeaderText = "Extend Renatal";

        }
        else
        {
            MessageBox.Show("No borrow requests found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void HandleBorrowRequest(int resourceID)
    {
        DialogResult result = MessageBox.Show("Are you sure you want to send a borrow request?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            // Get the number of copies for the given resourceID
            var resourceCopies = api.GetResourceCopiesByResource(resourceID);

            if (resourceCopies != null)
            {

                // Calculate the available quantity
                int availableCount = GetResourceAvailabilityForClient(resourceID);

                // Check availability
                if (availableCount > 0)
                {
                    // Available copies - create a new borrow request

                    DateOnly requestDate = DateOnly.FromDateTime(DateTime.Now);

                    // Create a new borrow request
                    bool requestSuccess = api.PostNewBorrowRequest(currentUser.UserID, resourceID, requestDate, null, null, Status.Pending);

                    if (requestSuccess)
                    {
                        MessageBox.Show("Borrow request sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshBorrowRequestsView();
                        // You can also update the user interface or perform additional actions.
                    }
                    else
                    {
                        MessageBox.Show("Error sending borrow request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // No availability
                    MessageBox.Show("No availability.", "Availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Handle the situation when it fails to retrieve resource copies
                MessageBox.Show("Error retrieving the number of copies.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void HandleExtendRental(int requestID)
    {

        DialogResult result = MessageBox.Show("Are you sure you want to extend the rental?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            // Get the current status of the borrow request
            var borrowRequests = api.GetBorrowRequests();
            var selectedRequest = borrowRequests?.FirstOrDefault(request => request.RequestID == requestID);

            if (selectedRequest != null && selectedRequest.Status == Status.Approved && selectedRequest.CopyID.HasValue)
            {
                // Get the current resource copy for the borrow request
                var resourceCopyId = selectedRequest.CopyID;

                DateOnly dueDate = selectedRequest.DueDate!.Value;

                bool updateSuccess = api.UpdateBorrowRequest(requestID, resourceCopyId, dueDate, Status.Pending);

                if (updateSuccess)
                {
                    MessageBox.Show("Rental successfully extended.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshBorrowRequestsView();
                }
                else
                {
                    MessageBox.Show("Error extending the rental.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid rental state for extension.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private int GetResourceAvailabilityForClient(int resourceID)
    {
        // Get resource amounts using the GetResourceAmounts function
        var resourceAmounts = api.GetResourceAmounts(resourceID);

        // Check if resource amounts retrieval was successful
        if (resourceAmounts.HasValue)
        {
            // Get the total amount of resources
            int totalAmount = resourceAmounts.Value.amount;

            // Get the count of borrow requests with status "Pending" or "Approved"
            var borrowRequests = api.GetBorrowRequestsByResource(resourceID);
            int requestCount = borrowRequests?.Count(request => request.Status == Status.Pending || request.Status == Status.Approved) ?? 0;

            // Calculate and return the available resource count
            int availableResources = totalAmount - requestCount;
            return availableResources;
        }
        else
        {
            MessageBox.Show("Error retrieving resource avaible amounts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
    }

    private void ClearDataGridView()
    {
        dataGridViewClient.DataSource = null;
        dataGridViewClient.Rows.Clear();
        dataGridViewClient.Columns.Clear();
    }
}
