using System.Data.Common;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualBasic;

namespace LibraryDatabaseAPI;

public class LibraryDatabaseApi
{
    
    private Connector connector;

    public LibraryDatabaseApi(string provider, string connectionString)
    {
        this.connector = new(provider, connectionString);
    }


    public List<LibraryUser>? GetLibraryUsers()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM LibraryUser");
        if(reader == null) return null;

        List < LibraryUser > users = new List< LibraryUser >();

        while (reader.Read())
        {
            var libraryUser = LibraryUser.Create(reader);
            users.Add(libraryUser);
        }

        return users;
    }

    public List<BorrowRequests>? GetBorrowRequests()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM BorrowRequests");
        if (reader == null) return null;

        List<BorrowRequests> res = new();

        while (reader.Read())
        {
            var tmp = BorrowRequests.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    public List<ResourceCopy>? GetResourceCopies()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM ResourceCopy");
        if (reader == null) return null;

        List<ResourceCopy> res = new();

        while (reader.Read())
        {
            var tmp = ResourceCopy.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    public List<LibraryResource>? GetLibraryResources()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM LibraryResource");
        if (reader == null) return null;

        List<LibraryResource> res = new();

        while (reader.Read())
        {
            var tmp = LibraryResource.Create(reader);
            res.Add(tmp);
        }

        return res;
    }


    public void GetUsersWithBorrowedResources()
    {
        string sql = "SELECT * FROM UserDetailsWithBorrowedResources";
        var reader = connector.GetFromDataBase(sql);
        if(reader == null) return;

        List <(int userId, List<(int copyId, string title, DateTime dueDate)> borrowed) > res = new();

        while (reader.Read())
        {
            int userId = reader.GetInt32(0);

            var borrowed = res.Exists(e => e.userId == userId)? res.Find(e => e.userId == userId).borrowed : new();

            int copyId = reader.GetInt32();
            string title, 
            DateTime dueDate
            //TODO
        }
    }


    ///TEST POSTS!!!

    public bool PostLibraryUser(string firstName, string lastName, string login, string password, UserType userType)
    {
        bool isSuccess = connector.PostToDataBase($"INSERT INTO LibraryUser (FirstName, LastName, Login, Password, UserType) VALUES ('{firstName}', '{lastName}', '{login}', '{password}', '{userType.ToString()}')");
        return isSuccess;
    }

    public bool PostBorrowRequest(int userId, int resourceId, DateTime requestDate, int? copyId, DateTime? dueDate, Status status)
    {
        var copyIdStr = copyId.HasValue ? copyId.ToString() : "NULL";
        var dueDateStr = dueDate.HasValue ? "'" + dueDate.ToString() + "'" : "NULL";
        string sql = $"INSERT INTO BorrowRequests (UserID, ResourceID, RequestDate, CopyID, DueDate, Status) VALUES ({userId}, {resourceId}, '{requestDate}', {copyIdStr}, '{dueDateStr}', '{status.ToString()}')";
        return connector.PostToDataBase(sql);
    }

    public bool PostResourceCopy(int resourceId)
    {
        string sql = $"INSERT INTO ResourceCopy (ResourceID) VALUES ({resourceId})";
        return connector.PostToDataBase(sql);
    }

    public bool PostLibraryResource(string title, string author, int yearPublished, ResourceType resourceType)
    {
        string sql = $"INSERT INTO LibraryResource (Title, Author, YearPublished, ResourceType) VALUES ('{title}', '{author}', {yearPublished}, '{resourceType.ToString()}')";
        return connector.PostToDataBase(sql);
    }
}
