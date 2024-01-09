using System;
using System.Windows.Forms;
using LibraryDatabaseAPI;
using LibraryWinFormsApp.Properties;

namespace LibraryWinFormsApp
{
    public partial class ClientForm : Form
    {
        private User currentUser;
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;

        public ClientForm(User user)
        {
            this.TopMost = true;
            this.currentUser = user;
            InitializeComponent();

            // Inicjalizacja LibraryDatabaseApi
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);

            // Wyświetl informacje o użytkowniku
            firstNameLabel.Text += currentUser.FirstName;
            lastNameLabel.Text += currentUser.LastName;
            // Dodanie obsługi zdarzenia CellContentClick
            dataGridViewBorrowedResources.CellContentClick += dataGridViewBorrowedResources_CellContentClick;
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showBorrowedResources_Click(object sender, EventArgs e)
        {
            RefreshBorrowedResourcesView();
        }

        private void showBorrowRequests_Click(object sender, EventArgs e)
        {
            RefreshBorrowRequestsView();
        }

        private void browseResources_Click(object sender, EventArgs e)
        {
            RefreshResourcesView();
        }


        private void RefreshBorrowedResourcesView()
        {
            var borrowedResources = api.GetResourcesBorrowedByUser(currentUser.UserID);

            if (borrowedResources != null && borrowedResources.Count > 0)
            {
                // Utwórz nową listę obiektów z interesującymi polami
                var modifiedList = borrowedResources.Select(resource =>
                {
                    // Znajdź zasób na podstawie ResourceID w bazie danych
                    var resourceCopyCount = GetResourceCopyCount(resource.ResourceID);

                    // Dodaj informacje do listy
                    return new
                    {
                        Title = resource.Title,
                        Author = resource.Author,
                        YearPublished = resource.YearPublished,
                        ResourceType = resource.ResourceType,
                        Copies = resourceCopyCount,
                        ResourceID = resource.ResourceID // Dodaj ID zasobu do przekazania do CheckResourceAvailability
                    };
                }).ToList();

                // Ustaw nową listę jako źródło danych
                dataGridViewBorrowedResources.DataSource = modifiedList;

                
                if (!dataGridViewBorrowedResources.Columns.Contains("CheckAvailability") && !dataGridViewBorrowedResources.Columns.Contains("BorrowRequest"))
                {
                    AddCheckAvailabilityButtonColumn();
                    AddBorrowRequestButtonColumn();
                }
                // Ustaw kolejność kolumn w dataGridViewBorrowedResources
                dataGridViewBorrowedResources.Columns["Title"].DisplayIndex = 0;
                dataGridViewBorrowedResources.Columns["Author"].DisplayIndex = 1;
                dataGridViewBorrowedResources.Columns["YearPublished"].DisplayIndex = 2;
                dataGridViewBorrowedResources.Columns["ResourceType"].DisplayIndex = 3;
                dataGridViewBorrowedResources.Columns["Copies"].DisplayIndex = 4;
                dataGridViewBorrowedResources.Columns["CheckAvailability"].DisplayIndex = 5;
                dataGridViewBorrowedResources.Columns["BorrowRequest"].DisplayIndex = 6;
                dataGridViewBorrowedResources.Columns["ResourceID"].Visible = false;

                if (dataGridViewBorrowedResources.Columns.Contains("ExtendRental"))
                {
                    dataGridViewBorrowedResources.Columns.Remove("ExtendRental");
                }
            }
            else
            {
                MessageBox.Show("Brak wypożyczonych zasobów.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshResourcesView()
        {
            var resources = api.GetResources();

            if (resources != null && resources.Count > 0)
            {
                var modifiedList = resources.Select(resource =>
                {
                    // Znajdź ilość kopii danego zasobu
                    var resourceCopyCount = GetResourceCopyCount(resource.ResourceID);

                    // Dodaj informacje do listy
                    return new
                    {
                        Title = resource.Title,
                        Author = resource.Author,
                        YearPublished = resource.YearPublished,
                        ResourceType = resource.ResourceType,
                        Copies = resourceCopyCount,
                        ResourceID = resource.ResourceID 
                    };
                }).ToList();

                // Ustaw nową listę jako źródło danych
                dataGridViewBorrowedResources.DataSource = modifiedList;

                if (!dataGridViewBorrowedResources.Columns.Contains("CheckAvailability") && !dataGridViewBorrowedResources.Columns.Contains("BorrowRequest"))
                {
                    AddCheckAvailabilityButtonColumn();
                    AddBorrowRequestButtonColumn();
                }
                // Ustaw kolejność kolumn w dataGridViewBorrowedResources
                dataGridViewBorrowedResources.Columns["Title"].DisplayIndex = 0;
                dataGridViewBorrowedResources.Columns["Author"].DisplayIndex = 1;
                dataGridViewBorrowedResources.Columns["YearPublished"].DisplayIndex = 2;
                dataGridViewBorrowedResources.Columns["ResourceType"].DisplayIndex = 3;
                dataGridViewBorrowedResources.Columns["Copies"].DisplayIndex = 4;
                dataGridViewBorrowedResources.Columns["CheckAvailability"].DisplayIndex = 5;
                dataGridViewBorrowedResources.Columns["BorrowRequest"].DisplayIndex = 6;
                dataGridViewBorrowedResources.Columns["ResourceID"].Visible = false;


                if (dataGridViewBorrowedResources.Columns.Contains("ExtendRental"))
                {
                    dataGridViewBorrowedResources.Columns.Remove("ExtendRental");
                }
            }
            else
            {
                MessageBox.Show("Brak zasobów w bibliotece.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshBorrowRequestsView()
        {
            var borrowRequests = api.GetBorrowRequestsByUser(currentUser.UserID);

            if (borrowRequests != null && borrowRequests.Count > 0)
            {
                // Utwórz nową listę obiektów z interesującymi polami
                var modifiedList = new List<object>();

                foreach (var request in borrowRequests)
                {
                    // Znajdź zasób na podstawie ResourceID w bazie danych
                    var resource = api.GetResources().FirstOrDefault(r => r.ResourceID == request.ResourceID);

                    if (resource != null)
                    {
                        // Dodaj informacje do listy
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

                // Ustaw nową listę jako źródło danych
                dataGridViewBorrowedResources.DataSource = modifiedList;

                if (!dataGridViewBorrowedResources.Columns.Contains("ExtendRental"))
                {
                    AddExtendRentalButtonColumn(); 
                }

                // Ustaw kolejność kolumn w dataGridViewBorrowedResources
                dataGridViewBorrowedResources.Columns["RequestID"].DisplayIndex = 0;
                dataGridViewBorrowedResources.Columns["Status"].DisplayIndex = 1;
                dataGridViewBorrowedResources.Columns["Title"].DisplayIndex = 2;
                dataGridViewBorrowedResources.Columns["RequestDate"].DisplayIndex = 3;
                dataGridViewBorrowedResources.Columns["DueDate"].DisplayIndex = 4;
                dataGridViewBorrowedResources.Columns["Author"].DisplayIndex = 5;
                dataGridViewBorrowedResources.Columns["ResourceType"].DisplayIndex = 6;
                dataGridViewBorrowedResources.Columns["ExtendRental"].DisplayIndex = 7;

                string[] columnsToRemove = { "CheckAvailability", "BorrowRequest" };

                foreach (string columnName in columnsToRemove)
                {
                    if (dataGridViewBorrowedResources.Columns.Contains(columnName))
                    {
                        dataGridViewBorrowedResources.Columns.Remove(columnName);
                    }
                }

            }
            else
            {
                MessageBox.Show("Brak próśb o wypożyczenie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewBorrowedResources_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Sprawdź, czy wiersz nie jest null
                if (dataGridViewBorrowedResources.Rows[e.RowIndex] != null)
                {
                    // Sprawdź, czy kliknięto w kolumnę "CheckAvailability"
                    if (dataGridViewBorrowedResources.Columns.Contains("CheckAvailability") &&
                        e.ColumnIndex == dataGridViewBorrowedResources.Columns["CheckAvailability"].Index)
                    {
                        int resourceID = (int)dataGridViewBorrowedResources.Rows[e.RowIndex].Cells["ResourceID"].Value;
                        HandleCheckResourceAvailability(resourceID);
                    }
                    // Sprawdź, czy kliknięto w kolumnę "BorrowRequest"
                    else if (dataGridViewBorrowedResources.Columns.Contains("BorrowRequest") &&
                             e.ColumnIndex == dataGridViewBorrowedResources.Columns["BorrowRequest"].Index)
                    {
                        int resourceID = (int)dataGridViewBorrowedResources.Rows[e.RowIndex].Cells["ResourceID"].Value;
                        HandleBorrowRequest(resourceID);
                    }
                    // Sprawdź, czy kliknięto w kolumnę "ExtendRental"
                    else if (dataGridViewBorrowedResources.Columns.Contains("ExtendRental") &&
                             e.ColumnIndex == dataGridViewBorrowedResources.Columns["ExtendRental"].Index)
                    {
                        int requestID = (int)dataGridViewBorrowedResources.Rows[e.RowIndex].Cells["RequestID"].Value;
                        HandleExtendRental(requestID);
                    }
                }
            }
        }


        private void HandleCheckResourceAvailability(int resourceID)
        {
        
            // Get resource amounts using the GetResourceAmounts function
            var resourceAmounts = api.GetResourceAmounts(resourceID);


            if (resourceAmounts.HasValue)
            {
                int availableCount = resourceAmounts.Value.available;

                // Check availability and display the appropriate message
                if (availableCount > 0)
                {
                    MessageBox.Show($"Product available in quantity {availableCount} units.", "Availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Out of stock.", "Availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Handle the situation where the resource amounts couldn't be retrieved
                MessageBox.Show("Error retrieving resource amounts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void HandleBorrowRequest(int resourceID)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz wysłać prośbę o wypożyczenie?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                // Pobierz ilość kopii danego zasobu (resourceID)
                var resourceCopies = api.GetResourceCopies();

                if (resourceCopies != null)
                {
                    // Pobierz ilość kopii danego zasobu
                    int copiesCount = resourceCopies.Count(copy => copy.ResourceID == resourceID);

                    // Pobierz ilość wypożyczeń danego zasobu
                    var borrowRequests = api.GetBorrowRequests();
                    int borrowedCount = borrowRequests?.Count(request => request.ResourceID == resourceID) ?? 0;

                    // Oblicz dostępną ilość sztuk
                    int availableCount = copiesCount - borrowedCount;

                    // Sprawdź dostępność
                    if (availableCount > 0)
                    {
                        // Dostępne sztuki - utwórz nowe żądanie wypożyczenia

                        DateOnly requestDate = DateOnly.FromDateTime(DateTime.Now);

                        // Stwórz nowe żądanie wypożyczenia
                        bool requestSuccess = api.PostNewBorrowRequest(currentUser.UserID, resourceID, requestDate, null, null, Status.Pending);

                        if (requestSuccess)
                        {
                            MessageBox.Show("Wysłano prośbę o wypożyczenie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshBorrowRequestsView();
                            // Możesz również zaktualizować interfejs użytkownika lub wykonać dodatkowe czynności.
                        }
                        else
                        {
                            MessageBox.Show("Błąd podczas wysyłania prośby o wypożyczenie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Brak dostępności
                        MessageBox.Show("Brak dostępności.", "Dostępność", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Obsłuż sytuację, gdy nie uda się pobrać kopii zasobu
                    MessageBox.Show("Błąd przy pobieraniu ilości kopii.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HandleExtendRental(int requestID)
        {

            DialogResult result = MessageBox.Show("Czy na pewno chcesz przedłużyć wypożyczenie?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Pobierz obecny status żądania wypożyczenia
                var borrowRequests = api.GetBorrowRequests();
                var selectedRequest = borrowRequests?.FirstOrDefault(request => request.RequestID == requestID);

                if (selectedRequest != null && selectedRequest.Status == Status.Approved && selectedRequest.CopyID.HasValue)
                {
                    // Pobierz obecną kopię zasobu dla żądania wypożyczenia
                    var resourceCopyId = selectedRequest.CopyID;

                    DateOnly newDueDate;
                    newDueDate = selectedRequest.DueDate.Value.AddDays(7);
                    
                   
                    bool updateSuccess = api.UpdateBorrowRequest(requestID, resourceCopyId, newDueDate, Status.Pending);

                    if (updateSuccess)
                    {
                        MessageBox.Show("Pomyślnie przedłużono wypożyczenie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshBorrowRequestsView();
                    }
                    else
                    {
                        MessageBox.Show("Błąd podczas przedłużania wypożyczenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nieprawidłowy status żądania wypożyczenia do przedłużenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }






        private void AddCheckAvailabilityButtonColumn()
        {
            // Dodaj kolumnę z przyciskiem do sprawdzania dostępności
            DataGridViewButtonColumn checkAvailabilityButtonColumn = new DataGridViewButtonColumn
            {
                Name = "CheckAvailability",
                Text = "Check",
                UseColumnTextForButtonValue = true
            };
            dataGridViewBorrowedResources.Columns.Add(checkAvailabilityButtonColumn);
        }

        private void AddBorrowRequestButtonColumn()
        {
            DataGridViewButtonColumn borrowRequestButtonColumn = new DataGridViewButtonColumn
            {
                Name = "BorrowRequest",
                Text = "Borrow Request",
                UseColumnTextForButtonValue = true
            };
            dataGridViewBorrowedResources.Columns.Add(borrowRequestButtonColumn);
        }

        private void AddExtendRentalButtonColumn()
        {
            DataGridViewButtonColumn borrowRequestButtonColumn = new DataGridViewButtonColumn
            {
                Name = "ExtendRental",
                Text = "Extend Rental",
                UseColumnTextForButtonValue = true
            };
            dataGridViewBorrowedResources.Columns.Add(borrowRequestButtonColumn);
        }



        private int GetResourceCopyCount(int resourceID)
        {
            // Pobierz ilość kopii danego zasobu (resourceID)
            var resourceAmounts = api.GetResourceAmounts(resourceID);

            if (resourceAmounts.HasValue)
            {
                // Zwróć ilość kopii danego zasobu
                return resourceAmounts.Value.amount;
            }
            else
            {
                // Obsłuż sytuację, gdy nie uda się pobrać ilości zasobu
                return -1; // Lub inna wartość oznaczająca błąd
            }
        }

    }

}
