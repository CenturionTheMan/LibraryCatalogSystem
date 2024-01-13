using LibraryDatabaseAPI;

namespace LibraryWinFormsApp
{
    public partial class WelcomeForm : Form
    {
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;
        LoginForm loginForm;
        RegistrationForm registrationForm;

        public WelcomeForm()
        {
            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new LoginForm(this);
            }

            loginForm.ShowDialog();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {

            if (registrationForm == null || registrationForm.IsDisposed)
            {
                registrationForm = new RegistrationForm();

            }

            registrationForm.ShowDialog();
        }
    }
}
