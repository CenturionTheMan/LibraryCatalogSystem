using LibraryDatabaseAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryWinFormsApp
{
    public partial class AddResourceForm : Form
    {
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;

        public AddResourceForm()
        {
            this.TopMost = true;
            InitializeComponent();

            // Inicjalizacja LibraryDatabaseApi
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);
        }

        private void addResource_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy wszystkie pola są wypełnione
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(authorTextBox.Text) ||
                string.IsNullOrWhiteSpace(yearPublishedTextBox.Text) || string.IsNullOrWhiteSpace(resourceTypeTextBox.Text))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sprawdź, czy rok publikacji składa się z cyfr i czy jest liczbą dodatnią
            if (!int.TryParse(yearPublishedTextBox.Text, out int yearPublished) || yearPublished <= 0)
            {
                MessageBox.Show("Rok publikacji powinien składać się z cyfr i być liczbą dodatnią.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sprawdź, czy zasób o takim samym tytule, autorze, roku publikacji i typie nie istnieje już w bazie
            string title = titleTextBox.Text;
            string author = authorTextBox.Text;
            string yearPublishedText = yearPublishedTextBox.Text;
            string resourceType = resourceTypeTextBox.Text;

            if (!Enum.TryParse<ResourceType>(resourceType, out ResourceType parsedResourceType))
            {
                MessageBox.Show("Błąd podczas parsowania typu zasobu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(yearPublishedText, out int yearPublishedValue))
            {
                MessageBox.Show("Błąd podczas parsowania roku publikacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Resource> existingResources = api.GetResources(title, author, yearPublishedValue, parsedResourceType);
            if (existingResources != null && existingResources.Count > 0)
            {
                MessageBox.Show("Zasób o takim samym tytule, autorze, roku publikacji i typie już istnieje w bazie danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Dodaj nowy zasób do bazy danych
            bool success = api.PostNewResource(title, author, yearPublished, parsedResourceType);

            if (success)
            {
                MessageBox.Show("Zasób został pomyślnie dodany do bazy danych.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFormFields();
                this.Close();

            }
            else
            {
                MessageBox.Show("Błąd podczas dodawania zasobu do bazy danych.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormFields()
        {
            titleTextBox.Text = string.Empty;
            authorTextBox.Text = string.Empty;
            yearPublishedTextBox.Text = string.Empty;
            resourceTypeTextBox.Text = string.Empty;
        }



 
    }
}
