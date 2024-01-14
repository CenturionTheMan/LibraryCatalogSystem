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
            InitializeComponent();

            // Initialize LibraryDatabaseApi
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);
        }

        private void AddResource_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(authorTextBox.Text) ||
                string.IsNullOrWhiteSpace(yearPublishedTextBox.Text) || string.IsNullOrWhiteSpace(resourceTypeTextBox.Text))
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the year of publication consists of digits and is a positive number
            if (!int.TryParse(yearPublishedTextBox.Text, out int yearPublished) || yearPublished <= 0)
            {
                MessageBox.Show("Year of publication should consist of digits and be a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if a resource with the same title, author, year of publication, and type does not already exist in the database
            string title = titleTextBox.Text;
            string author = authorTextBox.Text;
            string yearPublishedText = yearPublishedTextBox.Text;
            string resourceType = resourceTypeTextBox.Text;

            if (!Enum.TryParse<ResourceType>(resourceType, out ResourceType parsedResourceType))
            {
                MessageBox.Show("Error parsing resource type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(yearPublishedText, out int yearPublishedValue))
            {
                MessageBox.Show("Error parsing year of publication.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Resource> existingResources = api.GetResources(title, author, yearPublishedValue, parsedResourceType);
            if (existingResources != null && existingResources.Count > 0)
            {
                MessageBox.Show("A resource with the same title, author, year of publication, and type already exists in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add a new resource to the database
            bool success = api.PostNewResource(title, author, yearPublished, parsedResourceType);

            if (success)
            {
                MessageBox.Show("The resource has been successfully added to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFormFields();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error adding resource to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
