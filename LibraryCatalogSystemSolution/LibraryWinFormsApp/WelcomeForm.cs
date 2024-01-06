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

        private void login_Click(object sender, EventArgs e)
        {
            // Tworzymy tylko jedno okno logowania, jeœli jeszcze nie istnieje
            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new LoginForm(this); // Poprawka: przypisz do pola klasy
            }
            // Otwieramy okno logowania
            loginForm.ShowDialog();
        }

        private void register_Click(object sender, EventArgs e)
        {
            // Tworzymy tylko jedno okno rejestracji, jeœli jeszcze nie istnieje
            if (registrationForm == null || registrationForm.IsDisposed)
            {
                registrationForm = new RegistrationForm();
               
            }

            // Otwieramy okno rejestracji
            registrationForm.Show();
        }

        public void CloseWelcomeForm()
        {
            this.Close();
        }

        public void HideWelcomeForm()
        {
            this.Hide();
        }

        private void firstLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
