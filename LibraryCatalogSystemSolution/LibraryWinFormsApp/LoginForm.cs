using System;
using System.Windows.Forms;
using LibraryDatabaseAPI;

namespace LibraryWinFormsApp
{
    public partial class LoginForm : Form
    {
        private WelcomeForm welcomeForm;
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;

        public LoginForm(WelcomeForm welcomeForm)
        {
            this.welcomeForm = welcomeForm;
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);
            InitializeComponent();
        }

        private void returnToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void log_Click(object sender, EventArgs e)
        {
            // Pobieranie danych z formularza
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Weryfikacja użytkownika przy użyciu bazy danych
            User user = api.GetUserByLogin(username);

            if (user != null && user.Password == password)
            {
                MessageBox.Show("Logowanie udane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                // Otwieranie odpowiedniego panelu w zależności od UserType
                OpenUserPanel(user);
                // Czyszczenie wpisanych danych
                usernameTextBox.Text = string.Empty;
                passwordTextBox.Text = string.Empty;
                this.Close();
            }
            else
            {
                MessageBox.Show("Błędne dane logowania!", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            // Czyszczenie wpisanych danych
            usernameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
        }

        private void OpenUserPanel(User user)
        {
            // Otwieranie odpowiedniego panelu w zależności od UserType
            if (user.UserType == UserType.Employee)
            {
                // Utwórz i otwórz panel pracownika
                EmployeeForm employeeForm = new EmployeeForm(user);
                employeeForm.Show();
            }
            else if (user.UserType == UserType.Client)
            {
                // Utwórz i otwórz panel klienta
                ClientForm clientForm = new ClientForm(user);
                clientForm.Show();
            }
            // Dodaj inne przypadki, jeśli występują inne UserType
        }
    }
}
