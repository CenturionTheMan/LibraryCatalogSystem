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


    #region GET

    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public User? GetUserByLogin(string login)
    {
        string sql = $"SELECT * FROM Users WHERE Login = '{login}'";
        var reader = connector.GetFromDataBase(sql);
        if (reader == null ||reader.HasRows == false) return null;
        reader.Read();
        var user = User.Create(reader);
        return user;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public User? GetUserById(int userId)
    {
        string sql = $"SELECT * FROM Users WHERE UserID = {userId}";
        var reader = connector.GetFromDataBase(sql);
        if (reader == null || reader.HasRows == false) return null;
        reader.Read();
        var user = User.Create(reader);
        return user;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<User>? GetUsers()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM Users");
        if(reader == null) return null;

        List < User > users = new List< User >();

        while (reader.Read())
        {
            var user = User.Create(reader);
            users.Add(user);
        }

        return users;
    }

    public (int amount, int borrowed, int available)? GetResourceAmounts(int resourceId)
    {
        string sql = $"SELECT * FROM SummarisedResources WHERE ResourceID = {resourceId}";
        var reader = connector.GetFromDataBase(sql);
        if (reader == null ||reader.HasRows == false) return null;

        int amount = reader.GetInt32(2);
        int borrowed = reader.GetInt32(3);
        int available = amount - borrowed;
        return (amount, borrowed, available);
    }


    public List<BorrowRequest>? GetBorrowRequests(Status statusFilter)
    {
        var reader = connector.GetFromDataBase($"SELECT * FROM BorrowRequests WHERE Status = '{statusFilter}'");
        if (reader == null) return null;

        List<BorrowRequest> res = new();

        while (reader.Read())
        {
            var tmp = BorrowRequest.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<BorrowRequest>? GetBorrowRequests()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM BorrowRequests");
        if (reader == null) return null;

        List<BorrowRequest> res = new();

        while (reader.Read())
        {
            var tmp = BorrowRequest.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    public List<ResourceCopy>? GetResourceCopies()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM ResourceCopies");
        if (reader == null) return null;

        List<ResourceCopy> res = new();

        while (reader.Read())
        {
            var tmp = ResourceCopy.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    public List<Resource>? GetResources()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM Resources");
        if (reader == null) return null;

        List<Resource> res = new();

        while (reader.Read())
        {
            var tmp = Resource.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    public List<Resource>? GetResources(string title, string author, int yearPublished, ResourceType resourceType)
    {
        var reader = connector.GetFromDataBase($"SELECT * FROM Resources WHERE Title = '{title}' AND Author = '{author}' AND YearPublished = {yearPublished} AND ResourceType = '{resourceType}'");
        if (reader == null) return null;

        List<Resource> res = new();

        while (reader.Read())
        {
            var tmp = Resource.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    public List<Resource>? GetResourcesBorrowedByUser(int userId)
    {
        string sql = $"SELECT * FROM UserWithBorrowedResources WHERE UserID = {userId}";
        var reader = connector.GetFromDataBase(sql);
        if(reader == null) return null;

        List<Resource> borrowed = new();

        while (reader.Read())
        {
            var tmp = Resource.Create(reader);
            borrowed.Add(tmp);
        }

        return borrowed;
    }

    #endregion GET


    #region UPDATE

    public bool UpdateBorrowRequestStatusToReturned(int returnedResourceCopyId)
    {
        string sql = $"UPDATE BorrowRequests SET Status = '{Status.Returned}' WHERE ResourceID IS NOT NULL AND ResourceID = {returnedResourceCopyId}";
        return connector.PostToDataBase(sql);
    }

    public bool UpdateBorrowRequestStatusToApproved(int borrowRequestId, int assignedResourceCopyId, DateTime assignedDueDate)
    {
        string sql = $"UPDATE BorrowRequests SET DueDate = '{assignedDueDate}', ResourceID = {assignedResourceCopyId} WHERE RequestID = {borrowRequestId}";
        return connector.PostToDataBase(sql);
    }

    #endregion UPDATE

    #region POST

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <param name="userType"></param>
    /// <returns></returns>
    public bool PostNewUser(string firstName, string lastName, string login, string password, UserType userType)
    {
        bool isSuccess = connector.PostToDataBase($"INSERT INTO Users (FirstName, LastName, Login, Password, UserType) VALUES ('{firstName}', '{lastName}', '{login}', '{password}', '{userType.ToString()}')");
        return isSuccess;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="resourceId"></param>
    /// <param name="requestDate"></param>
    /// <param name="copyId"></param>
    /// <param name="dueDate"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    public bool PostNewBorrowRequest(int userId, int resourceId, DateTime requestDate, int? copyId, DateTime? dueDate, Status status)
    {
        var copyIdStr = copyId.HasValue ? copyId.ToString() : "NULL";
        var dueDateStr = dueDate.HasValue ? "'" + dueDate.ToString() + "'" : "NULL";
        string sql = $"INSERT INTO BorrowRequests (UserID, ResourceID, RequestDate, CopyID, DueDate, Status) VALUES ({userId}, {resourceId}, '{requestDate}', {copyIdStr}, '{dueDateStr}', '{status.ToString()}')";
        return connector.PostToDataBase(sql);
    }

    public bool PostNewResourceCopy(int resourceId)
    {
        string sql = $"INSERT INTO ResourceCopies (ResourceID) VALUES ({resourceId})";
        return connector.PostToDataBase(sql);
    }

    public bool PostNewResource(string title, string author, int yearPublished, ResourceType resourceType)
    {
        string sql = $"INSERT INTO Resources (Title, Author, YearPublished, ResourceType) VALUES ('{title}', '{author}', {yearPublished}, '{resourceType.ToString()}')";
        return connector.PostToDataBase(sql);
    }
    #endregion POST



    #region DELETE

    public bool DeleteResourceCopy(int toDeleteCopyId)
    {
        string sql = $"DELETE FROM ResourceCopies WHERE CopyID = {toDeleteCopyId}";
        return connector.PostToDataBase(sql);
    }

    public bool DeleteResource(int toDeleteResourceId)
    {
        string sql = $"DELETE FROM Resources WHERE ResourceID = {toDeleteResourceId}";
        return connector.PostToDataBase(sql);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="toDeleteUserId"></param>
    /// <returns></returns>
    public bool DeleteUser(int toDeleteUserId)
    {
        string sql = $"DELETE FROM Users WHERE UserID = {toDeleteUserId}";
        return connector.PostToDataBase(sql);
    }

    public bool DeleteBorrowRequest(int toDeleteRequestId)
    {
        string sql = $"DELETE FROM BorrowRequests WHERE RequestID = {toDeleteRequestId}";
        return connector.PostToDataBase(sql);
    }

    #endregion DELETE
}
