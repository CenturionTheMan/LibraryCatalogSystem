using System;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using LibraryDatabaseAPI;

namespace LibraryWinFormsApp
{
    public partial class RegistrationForm : Form
    {
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;

        public RegistrationForm()
        {
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);
            InitializeComponent();
        }

        private void reg_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;
            string key = keyTextBox.Text;



            // Check for null or empty values in input fields
            if (string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Wypełnij wszystkie wymagane rubryki.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sprawdź, czy hasła są identyczne
            if (password != confirmPassword)
            {
                MessageBox.Show("Hasła nie są identyczne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sprawdź, czy istnieje już użytkownik o podanym loginie
            var existingUser = api.GetUserByLogin(username);
            if (existingUser != null)
            {
                MessageBox.Show("Użytkownik o podanym loginie już istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sprawdź, czy istnieje już użytkownik o podanym imieniu i nazwisku
            var existingUserByName = api.GetUsers()?.Find(u => u.FirstName == firstName && u.LastName == lastName);
            if (existingUserByName != null)
            {
                MessageBox.Show("Użytkownik o podanym imieniu i nazwisku już istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Jeżeli wpisano poprawny klucz, nadaj odpowiedni UserType
            UserType userType = key.ToLower() == "key1" ? UserType.Employee : UserType.Client;

            // Zarejestruj nowego użytkownika
            bool registrationSuccess = api.PostNewUser(firstName, lastName, username, password, userType);
            if (registrationSuccess)
            {
                MessageBox.Show("Rejestracja zakończona sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Wystąpił problem podczas rejestracji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cencel_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void returnToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearTextBoxes()
        {
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            confirmPasswordTextBox.Text = "";
            keyTextBox.Text = "";
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
