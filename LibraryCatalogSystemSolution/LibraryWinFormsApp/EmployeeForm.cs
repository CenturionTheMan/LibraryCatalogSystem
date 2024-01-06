using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryDatabaseAPI;

namespace LibraryWinFormsApp
{
    public partial class EmployeeForm : Form
    {
        private User currentUser;
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;
        public EmployeeForm(User user)
        {
            this.TopMost = true; 
            this.currentUser = user;
            InitializeComponent();
        }


    }
}
