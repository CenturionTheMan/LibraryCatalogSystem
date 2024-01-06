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

            // Dodanie obsługi zdarzeń zaznaczenia
            dataGridViewBorrowedResources.SelectionChanged += DataGridViewBorrowedResources_SelectionChanged;

            // Wyświetl informacje o użytkowniku
            firstNameLabel.Text += currentUser.FirstName;
            lastNameLabel.Text += currentUser.LastName;
        }

        private void showBorrowedResources_Click(object sender, EventArgs e)
        {
            // Pobierz wypożyczone zasoby dla bieżącego użytkownika
            var borrowedResources = api.GetResourcesBorrowedByUser(currentUser.UserID);

            if (borrowedResources != null && borrowedResources.Count > 0)
            {
                // Wypełnij kontrolkę DataGridView danymi
                dataGridViewBorrowedResources.DataSource = borrowedResources;
            }
            else
            {
                // Jeśli brak wypożyczonych zasobów, wyświetl komunikat
                MessageBox.Show("Brak wypożyczonych zasobów.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void showBorrowRequests_Click(object sender, EventArgs e)
        {
            var borrowRequests = api.GetBorrowRequestsByUser(currentUser.UserID);

            if (borrowRequests != null && borrowRequests.Count > 0)
            {
                dataGridViewBorrowedResources.DataSource = borrowRequests;
            }
            else
            {
                MessageBox.Show("Brak próśb o wypożyczenie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void browseResources_Click(object sender, EventArgs e)
        {
            var resources = api.GetResources();

            if (resources != null && resources.Count > 0)
            {
                dataGridViewBorrowedResources.DataSource = resources;
            }
            else
            {
                MessageBox.Show("Brak zasobów w bibliotece.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void DataGridViewBorrowedResources_SelectionChanged(object sender, EventArgs e)
        {
            // Obsługa zdarzenia zmiany zaznaczenia w dataGridViewBorrowedResources
            if (dataGridViewBorrowedResources.CurrentRow?.DataBoundItem is Resource selectedResource)
            {
                FillResourceDetailsInTextBoxes(selectedResource);
            }

            // Obsługa zdarzenia zmiany zaznaczenia w dataGridViewBorrowedResources
            if (dataGridViewBorrowedResources.CurrentRow?.DataBoundItem is BorrowRequest selectedRequest)
            {
                FillRequestsDetailsInTextBoxes(selectedRequest);
            }
        }





        private void FillResourceDetailsInTextBoxes(Resource selectedResource)
        {
            // Ustaw odpowiednie wartości w TextBoxach
            resourceIdTextBox.Text = selectedResource.ResourceID.ToString();
            titleTextBox.Text = selectedResource.Title;
            authorTextBox.Text = selectedResource.Author;
            yearPublishedTextBox.Text = selectedResource.YearPublished.ToString();
            resourceTypeTextBox.Text = selectedResource.ResourceType.ToString();

            // Pobierz ilość kopii danego zasobu (resourceID)
            var resourceCopies = api.GetResourceCopies();

            if (resourceCopies != null)
            {
                // Zlicz ilość kopii danego zasobu
                int copiesCount = resourceCopies.Count(copy => copy.ResourceID == selectedResource.ResourceID);

                // Aktualizuj wartość w copiesTextBox
                copiesTextBox.Text = copiesCount.ToString();
            }
            else
            {
                // Obsłuż sytuację, gdy nie uda się pobrać kopii zasobu
                copiesTextBox.Text = "Błąd przy pobieraniu ilości kopii";
            }

        }



        private void FillRequestsDetailsInTextBoxes(BorrowRequest selectedRequest)
        {
            // Przykładowe uzupełnienie TextBox-ów z informacjami z żądania wypożyczenia
            requestIdTextBox.Text = selectedRequest.RequestID.ToString();
            tresourceIdTextBox.Text = selectedRequest.ResourceID.ToString();
            requestDateTextBox.Text = selectedRequest.RequestDate.ToString("dd.MM.yyyy");
            copyIdTextBox.Text = selectedRequest.CopyID?.ToString() ?? "Brak";
            dueDateTextBox.Text = selectedRequest.DueDate?.ToString("dd.MM.yyyy") ?? "Brak";
            statusTextBox.Text = selectedRequest.Status.ToString();

        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void availability_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy pole resourceIdTextBox nie jest puste
            if (string.IsNullOrEmpty(resourceIdTextBox.Text))
            {
                MessageBox.Show("Wprowadź ID zasobu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pobierz ilość kopii danego zasobu (resourceID)
            var resourceCopies = api.GetResourceCopies();

            if (resourceCopies != null)
            {
                // Pobierz ilość kopii danego zasobu
                int copiesCount = resourceCopies.Count(copy => copy.ResourceID == int.Parse(resourceIdTextBox.Text));

                // Pobierz ilość wypożyczeń danego zasobu
                var borrowRequests = api.GetBorrowRequests();
                int borrowedCount = borrowRequests?.Count(request => request.ResourceID == int.Parse(resourceIdTextBox.Text)) ?? 0;

                // Oblicz dostępną ilość sztuk
                int availableCount = copiesCount - borrowedCount;

                // Sprawdź dostępność i wyświetl odpowiedni komunikat
                if (availableCount > 0)
                {
                    MessageBox.Show($"Produkt dostępny w ilości {availableCount} sztuk.", "Dostępność", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Brak dostępności.", "Dostępność", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Obsłuż sytuację, gdy nie uda się pobrać kopii zasobu
                MessageBox.Show("Błąd przy pobieraniu ilości kopii.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void borrowRequest_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy pole resourceIdTextBox nie jest puste
            if (string.IsNullOrEmpty(resourceIdTextBox.Text))
            {
                MessageBox.Show("Wprowadź ID zasobu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pobierz ilość kopii danego zasobu (resourceID)
            var resourceCopies = api.GetResourceCopies();

            if (resourceCopies != null)
            {
                // Pobierz ilość kopii danego zasobu
                int copiesCount = resourceCopies.Count(copy => copy.ResourceID == int.Parse(resourceIdTextBox.Text));

                // Pobierz ilość wypożyczeń danego zasobu
                var borrowRequests = api.GetBorrowRequests();
                int borrowedCount = borrowRequests?.Count(request => request.ResourceID == int.Parse(resourceIdTextBox.Text)) ?? 0;

                // Oblicz dostępną ilość sztuk
                int availableCount = copiesCount - borrowedCount;

                // Sprawdź dostępność
                if (availableCount > 0)
                {
                    // Dostępne sztuki - utwórz nowe żądanie wypożyczenia
               
                    DateOnly requestDate = DateOnly.FromDateTime(DateTime.Now);

                    // Stwórz nowe żądanie wypożyczenia
                    bool requestSuccess = api.PostNewBorrowRequest(currentUser.UserID, int.Parse(resourceIdTextBox.Text), requestDate, null, null, Status.Pending);

                    if (requestSuccess)
                    {
                        MessageBox.Show("Wysłano prośbę o wypożyczenie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

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



        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void extendRental_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy pole requestIdTextBox nie jest puste
            if (string.IsNullOrEmpty(requestIdTextBox.Text))
            {
                MessageBox.Show("Wprowadź ID żądania wypożyczenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Spróbuj przekonwertować requestID na int
            if (int.TryParse(requestIdTextBox.Text, out int requestId))
            {
                // Pobierz obecny status żądania wypożyczenia
                var borrowRequests = api.GetBorrowRequests();
                var selectedRequest = borrowRequests?.FirstOrDefault(request => request.RequestID == requestId);

                if (selectedRequest != null && selectedRequest.Status == Status.Approved)
                {
                    // Pobierz obecną kopię zasobu dla żądania wypożyczenia
                    var resourceCopyId = selectedRequest.CopyID;

                    // Aktualizuj żądanie wypożyczenia
                    // Przykład przedłużenia wypożyczenia o 7 dni, możesz dostosować do swoich wymagań
                    DateOnly newDueDate;
                   
                    if (selectedRequest.DueDate.HasValue)
                    {
                        // Jeśli DueDate ma wartość, dodaj 7 dni do obecnej daty
                        newDueDate = selectedRequest.DueDate.Value.AddDays(7);
                    }
                    else
                    {
                        // Jeśli DueDate jest null, ustaw nową datę na dzisiaj + 7 dni
                        newDueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
                    }

                    bool updateSuccess = api.UpdateBorrowRequest(requestId, resourceCopyId, newDueDate, Status.Pending);

                    if (updateSuccess)
                    {
                        MessageBox.Show("Pomyślnie przedłużono wypożyczenie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Aktualizuj interfejs użytkownika lub wykonaj dodatkowe czynności, jeśli konieczne.
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
            else
            {
                MessageBox.Show("Nieprawidłowe ID żądania wypożyczenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
