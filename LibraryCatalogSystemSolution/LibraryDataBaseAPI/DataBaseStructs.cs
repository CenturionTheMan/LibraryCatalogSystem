using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataBaseAPI;




public class LibraryUser
{
    public int UserID { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Login { get; private set; }
    public string Password { get; private set; }
    public UserType UserType { get; private set; }

    internal static LibraryUser Create(IDataRecord record)
    {
        return new LibraryUser(
            (int)record[nameof(UserID)],
            (string)record[nameof(FirstName)],
            (string)record[nameof(LastName)],
            (string)record[nameof(Login)],
            (string)record[nameof(Password)],
            ((string)record[nameof(UserType)]).ParseToUserType());
    }

    internal LibraryUser(int userID, string firstName, string lastName, string login, string password, UserType userType)
    {
        UserID = userID;
        FirstName = firstName;
        LastName = lastName;
        Login = login;
        Password = password;
        UserType = userType;
    }

    public override string ToString()
    {
        PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
        StringBuilder builder = new StringBuilder();
        foreach (PropertyDescriptor pd in coll)
        {
            object? val = pd.GetValue(this);
            string? valStr = (val == null) ? "null" : val.ToString();
            builder.Append(string.Format("{0}: {1}\n", pd.Name, valStr));
        }
        return builder.ToString();
    }
}


public class LibraryResource
{
    public int ResourceID { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int YearPublished { get; private set; }
    public string ResourceType { get; private set; }

    internal static LibraryResource Create(IDataRecord record)
    {
        return new LibraryResource(
            (int)record[nameof(ResourceID)],
            (string)record[nameof(Title)],
            (string)record[nameof(Author)],
            (int)record[nameof(YearPublished)],
            (string)record[nameof(ResourceType)]);
    }

    internal LibraryResource(int resourceID, string title, string author, int yearPublished, string resourceType)
    {
        ResourceID = resourceID;
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        ResourceType = resourceType;
    }

    public override string ToString()
    {
        PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
        StringBuilder builder = new StringBuilder();
        foreach (PropertyDescriptor pd in coll)
        {
            object? val = pd.GetValue(this);
            string? valStr = (val == null) ? "null" : val.ToString();
            builder.Append(string.Format("{0}: {1}\n", pd.Name, valStr));
        }
        return builder.ToString();
    }
}


public class BorrowRequests
{
    public int RequestID { get; private set; }
    public int UserID { get; private set; }
    public int ResourceID { get; private set; }
    public DateTime RequestDate { get; private set; }
    public int? CopyID { get; private set; }
    public DateTime? DueDate { get; private set; }
    public string Status { get; private set; }

    internal static BorrowRequests Create(IDataRecord record)
    {

        var requestID = (int)record[nameof(RequestID)];
        var userId = (int)record[nameof(UserID)];
        var resourceId = (int)record[nameof(ResourceID)];
        var requestDate =(DateTime)record[nameof(RequestDate)];
        int? copyID = null;

        try
        {
            int tmp = (int)record[nameof(CopyID)];
            copyID = tmp;
        }
        catch { }
        
        
        DateTime? dueDate = null;
        try
        {
            object dueDateObj = (DateTime)record[nameof(DueDate)];
            dueDate = (DateTime)dueDateObj;
        }
        catch { }
        var status = (string)record[nameof(Status)];

        return new BorrowRequests(requestID, userId, resourceId, requestDate, copyID, dueDate, status);
    }

    internal BorrowRequests(int requestID, int userID, int resourceID, DateTime requestDate, int? copyID, DateTime? dueDate, string status)
    {
        RequestID = requestID;
        UserID = userID;
        ResourceID = resourceID;
        RequestDate = requestDate;
        CopyID = copyID;
        DueDate = dueDate;
        Status = status;
    }

    public override string ToString()
    {
        PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
        StringBuilder builder = new StringBuilder();
        foreach (PropertyDescriptor pd in coll)
        {
            object? val = pd.GetValue(this);
            string? valStr = (val == null) ? "null" : val.ToString();
            builder.Append(string.Format("{0}: {1}\n", pd.Name, valStr));
        }
        return builder.ToString();
    }
}


public class ResourceCopy
{
    public int CopyID { get; private set; }
    public int ResourceID { get; private set; }

    internal static ResourceCopy Create(IDataRecord record)
    {
        return new ResourceCopy(
            (int)record[nameof(CopyID)],
            (int)record[nameof(ResourceID)]);
    }

    internal ResourceCopy(int copyID, int resourceID)
    {
        CopyID = copyID;
        ResourceID = resourceID;
    }

    public override string ToString()
    {
        PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
        StringBuilder builder = new StringBuilder();
        foreach (PropertyDescriptor pd in coll)
        {
            object? val = pd.GetValue(this);
            string? valStr = (val == null) ? "null" : val.ToString();
            builder.Append(string.Format("{0}: {1}\n", pd.Name, valStr));
        }
        return builder.ToString();
    }
}