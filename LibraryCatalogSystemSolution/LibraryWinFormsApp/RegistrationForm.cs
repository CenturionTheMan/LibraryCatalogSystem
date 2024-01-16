using System;
using System.Windows.Forms;
using LibraryDatabaseAPI;

namespace LibraryWinFormsApp;

public partial class RegistrationForm : Form
{
    const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

    DatabaseApi api;

    public RegistrationForm()
    {
        api = new DatabaseApi(PROVIDER, CONNECTION_STRING);
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

    }

    private void RegisterButton_Click(object sender, EventArgs e)
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
            MessageBox.Show("Fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Check if passwords match
        if (password != confirmPassword)
        {
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Check if a user with the given username already exists
        var existingUser = api.GetUserByLogin(username);
        if (existingUser != null)
        {
            MessageBox.Show("A user with the provided username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // If a valid key is provided, assign the appropriate UserType
        UserType userType = key.ToLower() == DatabaseApi.EMPLOYEE_KEY.ToLower() ? UserType.Employee : UserType.Client;

        // Register a new user
        bool registrationSuccess = api.PostNewUser(firstName, lastName, username, password, userType);
        if (registrationSuccess)
        {
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearTextBoxes();
            Close();
        }
        else
        {
            MessageBox.Show("An error occurred during registration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        ClearTextBoxes();
    }

    private void ReturnToMainButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void ClearTextBoxes()
    {
        firstNameTextBox.Text = string.Empty;
        lastNameTextBox.Text = string.Empty;
        usernameTextBox.Text = string.Empty;
        passwordTextBox.Text = string.Empty;
        confirmPasswordTextBox.Text = string.Empty;
        keyTextBox.Text = string.Empty;
    }
}
