using LibraryDatabaseAPI;

namespace LibraryWinFormsApp;

public partial class WelcomeForm : Form
{
    LoginForm? loginForm = null;
    RegistrationForm? registrationForm = null;

    public WelcomeForm()
    {
        InitializeComponent();

        this.FormBorderStyle = FormBorderStyle.FixedSingle;
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        if (loginForm == null || loginForm.IsDisposed)
        {
            loginForm = new LoginForm();
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
