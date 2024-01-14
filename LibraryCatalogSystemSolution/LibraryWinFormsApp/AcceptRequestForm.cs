using LibraryDatabaseAPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryWinFormsApp;

public partial class AcceptRequestForm : Form
{
    private int currentResourceID;
    private int currentRequestID;
    const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

    DatabaseApi api;

    public AcceptRequestForm(int requestID, int resourceID)
    {
        InitializeComponent();
        this.currentResourceID = resourceID;
        this.currentRequestID = requestID;

        api = new DatabaseApi(PROVIDER, CONNECTION_STRING);

        // Wypełnij ComboBox dostępnymi kopiami dla danego zasobu
        List<ResourceCopy> availableCopies = api.GetAvailableResourceCopies(currentResourceID);
        foreach (ResourceCopy copy in availableCopies)
        {
            CopyIdComboBox.Items.Add(copy.CopyID);
        }

        // Ustaw domyślną wartość w ComboBox, jeśli dostępne kopie istnieją
        if (CopyIdComboBox.Items.Count > 0)
        {
            CopyIdComboBox.SelectedIndex = 0;
        }

        this.FormBorderStyle = FormBorderStyle.FixedSingle;
    }

    private void AcceptButton_Click(object sender, EventArgs e)
    {
        // Sprawdź, czy wybrano kopię
        if (CopyIdComboBox.SelectedItem == null)
        {
            MessageBox.Show("Please select a copy ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Pobierz wybrane wartości
        int selectedCopyID = (int)CopyIdComboBox.SelectedItem;
        DateOnly selectedDueDate = DateOnly.FromDateTime(DueDateMonthCalendar.SelectionStart.Date);

        // Wykonaj operację aktualizacji
        bool success = api.UpdateBorrowRequestStatusToApproved(currentRequestID, selectedCopyID, selectedDueDate);

        // Sprawdź, czy operacja się powiodła
        if (success)
        {
            MessageBox.Show("Borrow request approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        else
        {
            MessageBox.Show("Failed to approve borrow request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}


