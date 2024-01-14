using LibraryDatabaseAPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryWinFormsApp
{
    public partial class ExtendRequestForm : Form
    {
        private int currentCopyID;
        private int currentRequestID;
        const string PROVIDER = ".NET Framework Data Provider for SQL Server";
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

        LibraryDatabaseApi api;

        public ExtendRequestForm(int requestID, int copyID)
        {
            InitializeComponent();
            this.currentCopyID = copyID;
            this.currentRequestID = requestID;

            api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);


        }

        private void ExtendButton_Click(object sender, EventArgs e)
        {
            DateOnly selectedDueDate = DateOnly.FromDateTime(ExtendDateMonthCalendar.SelectionStart.Date);

            bool success = api.UpdateBorrowRequestStatusToApproved(currentRequestID, currentCopyID, selectedDueDate);

            if (success)
            {
                MessageBox.Show("Extend request approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to approve extend request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



