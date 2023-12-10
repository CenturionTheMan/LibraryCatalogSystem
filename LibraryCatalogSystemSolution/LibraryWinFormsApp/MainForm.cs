using LibraryDatabaseAPI;

namespace LibraryWinFormsApp;

public partial class MainForm : Form
{
    const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";


    LibraryDatabaseApi api;

    public MainForm()
    {
        
        api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);

        InitializeComponent();
    }
}
