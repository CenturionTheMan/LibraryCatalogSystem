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
            this.TopMost = true;
            this.currentUser = user;
            InitializeComponent();

            // Inicjalizacja LibraryDatabaseApi
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);

            // Dodanie obsługi zdarzeń zaznaczenia
            DataGridViewResources.SelectionChanged += DataGridViewResources_SelectionChanged;

            // Wyświetl informacje o użytkowniku
            firstNameLabel.Text += currentUser.FirstName;
            lastNameLabel.Text += currentUser.LastName;

            // Dodanie obsługi zdarzenia CellContentClick
            DataGridViewResources.CellContentClick += DataGridViewResources_CellContentClick;
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseResources_Click(object sender, EventArgs e)
        {
            RefreshResourcesView();
        }

        private void DataGridViewResources_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void addResource_Click(object sender, EventArgs e)
        {

            AddResourceForm addResourceForm = new AddResourceForm();


            addResourceForm.FormClosed += (s, args) =>
            {
                RefreshResourcesView();
            };

            // Pokaż okno
            addResourceForm.Show();
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
                DataGridViewResources.DataSource = modifiedList;

                if (!DataGridViewResources.Columns.Contains("CheckAvailability") && !DataGridViewResources.Columns.Contains("ManageCopies"))
                {
                    AddCheckAvailabilityButtonColumn();
                    AddManageCopiesButtonColumn();
                }
                // Ustaw kolejność kolumn w dataGridViewBorrowedResources
                DataGridViewResources.Columns["ResourceID"].DisplayIndex = 0;
                DataGridViewResources.Columns["Title"].DisplayIndex = 1;
                DataGridViewResources.Columns["Author"].DisplayIndex = 2;
                DataGridViewResources.Columns["YearPublished"].DisplayIndex = 3;
                DataGridViewResources.Columns["ResourceType"].DisplayIndex = 4;
                DataGridViewResources.Columns["Copies"].DisplayIndex = 5;
                DataGridViewResources.Columns["CheckAvailability"].DisplayIndex = 6;
                DataGridViewResources.Columns["ManageCopies"].DisplayIndex = 7;
            }
            else
            {
                MessageBox.Show("Brak zasobów w bibliotece.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DataGridViewResources_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Sprawdź, czy wiersz nie jest null
                if (DataGridViewResources.Rows[e.RowIndex] != null)
                {
                    // Sprawdź, czy kliknięto w kolumnę "CheckAvailability"
                    if (DataGridViewResources.Columns.Contains("CheckAvailability") &&
                        e.ColumnIndex == DataGridViewResources.Columns["CheckAvailability"].Index)
                    {
                        int resourceID = (int)DataGridViewResources.Rows[e.RowIndex].Cells["ResourceID"].Value;
                        HandleCheckResourceAvailability(resourceID);
                    }
                    // Sprawdź, czy kliknięto w kolumnę "BorrowRequest"
                    else if (DataGridViewResources.Columns.Contains("ManageCopies") &&
                             e.ColumnIndex == DataGridViewResources.Columns["ManageCopies"].Index)
                    {
                        int resourceID = (int)DataGridViewResources.Rows[e.RowIndex].Cells["ResourceID"].Value;
                        HandleManageCopies(resourceID);
                    }
                }
            }
        }

        private void deleteChosenResource_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy coś jest zaznaczone w DataGridViewResources
            if (DataGridViewResources.SelectedRows.Count > 0)
            {
                // Pobierz identyfikator zaznaczonego zasobu
                int resourceID = (int)DataGridViewResources.SelectedRows[0].Cells["ResourceID"].Value;

                // Wyświetl komunikat z potwierdzeniem
                DialogResult result = MessageBox.Show($"Czy na pewno chcesz usunąć zasób o ID: {resourceID}?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Usuń zasób
                    bool success = api.DeleteResource(resourceID);

                    if (success)
                    {
                        MessageBox.Show("Zasób został pomyślnie usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshResourcesView();
                    }
                    else
                    {
                        MessageBox.Show("Błąd podczas usuwania zasobu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnego zasobu do usunięcia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        private void HandleManageCopies(int resourceID)
        {
            var resources = api.GetResources();
            Resource selectedResource = resources.FirstOrDefault(resource => resource.ResourceID == resourceID);

            if (selectedResource != null)
            {
                // Wyświetl komunikat z potwierdzeniem
                DialogResult result = MessageBox.Show($"Czy na pewno przejść do zarządzania egzemplarzami zasobu:\n{selectedResource}?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Otwórz okno ManagingResourceCopies z przekazanym resourceID
                    ManagingResourceCopies managingResourceCopiesForm = new ManagingResourceCopies(resourceID);
                    managingResourceCopiesForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Nie można znaleźć zasobu o podanym ID.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DataGridViewResources.Columns.Add(checkAvailabilityButtonColumn);
        }

        private void AddManageCopiesButtonColumn()
        {
            DataGridViewButtonColumn ManageCopiesButtonColumn = new DataGridViewButtonColumn
            {
                Name = "ManageCopies",
                Text = "Manage Copies",
                UseColumnTextForButtonValue = true
            };
            DataGridViewResources.Columns.Add(ManageCopiesButtonColumn);
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

        private void browseRequests_Click(object sender, EventArgs e)
        {
            // Pobierz wszystkie żądania i posortuj po statusie i dacie RequestDate
            var allRequests = api.GetBorrowRequests()?.OrderBy(request => request.Status)
                                                       .ThenByDescending(request => request.RequestDate)
                                                       .ToList();

            if (allRequests != null && allRequests.Count > 0)
            {
                // Utwórz listę do wyświetlenia w DataGridViewResources
                var requestList = allRequests.Select(request =>
                {
                    var resource = api.GetResources().FirstOrDefault(r => r.ResourceID == request.ResourceID);
                    var firstName = api.GetUserById(request.UserID)?.FirstName;
                    var lastName = api.GetUserById(request.UserID)?.LastName;

                    return new
                    {
                        RequestID = request.RequestID,
                        UserID = request.UserID,
                        ResourceID = request.ResourceID,
                        CopyID = request.CopyID,
                        FirstName = firstName,
                        LastName = lastName,
                        ResourceTitle = resource?.Title,
                        RequestDate = request.RequestDate,
                        DueDate = request.DueDate,
                        Status = request.Status
                    };
                }).ToList();

                DataGridViewResources.DataSource = requestList;

                string[] columnsToRemove = { "CheckAvailability", "ManageCopies" };

                foreach (string columnName in columnsToRemove)
                {
                    if (DataGridViewResources.Columns.Contains(columnName))
                    {
                        DataGridViewResources.Columns.Remove(columnName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Brak żądań w systemie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addNewCopy_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy coś jest zaznaczone w DataGridViewResources
            if (DataGridViewResources.SelectedRows.Count > 0)
            {
                // Pobierz identyfikator zaznaczonego zasobu
                int resourceID = (int)DataGridViewResources.SelectedRows[0].Cells["ResourceID"].Value;

                // Wywołaj funkcję dodającą nową kopię
                bool success = api.PostNewResourceCopy(resourceID);

                if (success)
                {
                    MessageBox.Show("Nowa kopia została pomyślnie dodana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshResourcesView();
                }
                else
                {
                    MessageBox.Show("Błąd podczas dodawania nowej kopii.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono żadnego zasobu, do którego można dodać nową kopię.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
