using System;
using System.Windows.Forms;
using LibraryDatabaseAPI;

namespace LibraryWinFormsApp;

public partial class LoginForm : Form
{
    const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

    DatabaseApi api;

    public LoginForm()
    {
        api = new DatabaseApi(PROVIDER, CONNECTION_STRING);
        InitializeComponent();
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

    }

    private void ReturnToMainButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        string username = usernameTextBox.Text;
        string password = passwordTextBox.Text;

        User? user = api.GetUserByLogin(username);

        if (user is not null && user.Password == password)
        {
            OpenUserPanel(user);
            usernameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
            this.Close();
        }
        else
        {
            MessageBox.Show("Invalid login credentials!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            passwordTextBox.Text = string.Empty;
        }
    }

    private void ClearButton_Click(object sender, EventArgs e)
    {
        usernameTextBox.Text = string.Empty;
        passwordTextBox.Text = string.Empty;
    }

    private void OpenUserPanel(User user)
    {
        if (user.UserType == UserType.Employee)
        {
            // Open Employee Form
            EmployeeForm employeeForm = new EmployeeForm(user);
            employeeForm.Show();
        }
        else if (user.UserType == UserType.Client)
        {
            // Open Client Form
            ClientForm clientForm = new ClientForm(user);
            clientForm.Show();
        }
    }
}
