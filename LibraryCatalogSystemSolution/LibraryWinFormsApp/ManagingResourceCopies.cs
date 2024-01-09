using System;
using System.Windows.Forms;
using LibraryDatabaseAPI;

namespace LibraryWinFormsApp
{
    public partial class ManagingResourceCopies : Form
    {
        private int currentResourceID;
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;

        // Konstruktor z dodanym parametrem resourceID
        public ManagingResourceCopies(int resourceID)
        {
            this.TopMost = true;
            this.currentResourceID = resourceID;
            InitializeComponent();

            // Inicjalizacja LibraryDatabaseApi
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);

            // Wywołanie metody ładującej dane przy otwarciu formularza
            ManagingResourceCopies_Load(this, EventArgs.Empty);
        }

        private void ManagingResourceCopies_Load(object sender, EventArgs e)
        {
            // Pobierz informacje o zasobie na podstawie resourceID
            Resource resource = api.GetResources().FirstOrDefault(r => r.ResourceID == currentResourceID);

            // Sprawdź, czy zasób został znaleziony
            if (resource != null)
            {
                // Ustaw wartości etykiet na podstawie informacji o zasobie
                resourceIdLabel.Text = $"Resource ID: {resource.ResourceID}";
                titleLabel.Text = $"Title: {resource.Title}";
                authorLabel.Text = $"Author: {resource.Author}";
                yearPublishedLabel.Text = $"Year Published: {resource.YearPublished}";
                typeLabel.Text = $"Type: {resource.ResourceType}";
            }
            else
            {
                // Jeśli zasób nie został znaleziony, wyświetl komunikat lub podejmij odpowiednie działania
                MessageBox.Show("Resource not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Możesz także zamknąć okno, jeśli zasób nie istnieje
            }
        }

        // Dalsze przetwarzanie z wykorzystaniem resourceID
    }
}
