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
    /// Retrieves a user based on login.
    /// </summary>
    /// <param name="login">The login of the user.</param>
    /// <returns>The user object if found, otherwise null.</returns>
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
    /// Retrieves a user based on their user ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>The user object if found, otherwise null.</returns>
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
    /// Retrieves a list of all users.
    /// </summary>
    /// <returns>A list of User objects if success, otherwise null.</returns>
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

    /// <summary>
    /// Retrieves the amounts related to a specific resource.
    /// </summary>
    /// <param name="resourceId">The ID of the resource.</param>
    /// <returns>
    /// A tuple containing the total amount, borrowed amount, and available amount (total - borrowed).
    /// Null if the resource is not found.
    /// </returns>
    public (int amount, int borrowed, int available)? GetResourceAmounts(int resourceId)
    {
        string sql = $"SELECT * FROM SummarisedResources WHERE ResourceID = {resourceId}";
        var reader = connector.GetFromDataBase(sql);

        if (reader == null || !reader.HasRows)
            return null;

        reader.Read();
        int amount = reader.GetInt32(2);
        int borrowed = reader.GetInt32(3);
        int available = amount - borrowed;

        return (amount, borrowed, available);
    }

    /// <summary>
    /// Retrieves a list of borrow requests filtered by status.
    /// </summary>
    /// <param name="statusFilter">The status to filter by.</param>
    /// <returns>
    /// A list of BorrowRequest objects if success, otherwise null.
    /// </returns>
    public List<BorrowRequest>? GetBorrowRequests(Status statusFilter)
    {
        var reader = connector.GetFromDataBase($"SELECT * FROM BorrowRequests WHERE Status = '{statusFilter}'");

        if (reader == null)
            return null;

        List<BorrowRequest> res = new();

        while (reader.Read())
        {
            var tmp = BorrowRequest.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    /// <summary>
    /// Retrieves a list of all borrow requests.
    /// </summary>
    /// <returns>
    /// A list of BorrowRequest objects if success, otherwise null.
    /// </returns>
    public List<BorrowRequest>? GetBorrowRequests()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM BorrowRequests");

        if (reader == null)
            return null;

        List<BorrowRequest> res = new();

        while (reader.Read())
        {
            var tmp = BorrowRequest.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    /// <summary>
    /// Retrieves a list of all resource copies.
    /// </summary>
    /// <returns>
    /// A list of ResourceCopy objects if success, otherwise null.
    /// </returns>
    public List<ResourceCopy>? GetResourceCopies()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM ResourceCopies");

        if (reader == null)
            return null;

        List<ResourceCopy> res = new();

        while (reader.Read())
        {
            var tmp = ResourceCopy.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    /// <summary>
    /// Retrieves a list of all resources.
    /// </summary>
    /// <returns>
    /// A list of Resource objects if success, otherwise null.
    /// </returns>
    public List<Resource>? GetResources()
    {
        var reader = connector.GetFromDataBase("SELECT * FROM Resources");

        if (reader == null)
            return null;

        List<Resource> res = new();

        while (reader.Read())
        {
            var tmp = Resource.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    /// <summary>
    /// Retrieves a list of resources based on the specified criteria.
    /// </summary>
    /// <param name="title">The title of the resource.</param>
    /// <param name="author">The author of the resource.</param>
    /// <param name="yearPublished">The year the resource was published.</param>
    /// <param name="resourceType">The type of the resource.</param>
    /// <returns>
    /// A list of Resource objects if success, otherwise null.
    /// </returns>
    public List<Resource>? GetResources(string title, string author, int yearPublished, ResourceType resourceType)
    {
        var reader = connector.GetFromDataBase($"SELECT * FROM Resources WHERE Title = '{title}' AND Author = '{author}' AND YearPublished = {yearPublished} AND ResourceType = '{resourceType}'");

        if (reader == null)
            return null;

        List<Resource> res = new();

        while (reader.Read())
        {
            var tmp = Resource.Create(reader);
            res.Add(tmp);
        }

        return res;
    }

    /// <summary>
    /// Retrieves a list of resources borrowed by a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>
    /// A list of Resource objects if success, otherwise null.
    /// </returns>
    public List<Resource>? GetResourcesBorrowedByUser(int userId)
    {
        string sql = $"SELECT * FROM UserWithBorrowedResources WHERE UserID = {userId}";
        var reader = connector.GetFromDataBase(sql);

        if (reader == null)
            return null;

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

    /// <summary>
    /// Updates the status of a borrow request to "Returned" based on the returned resource copy ID.
    /// </summary>
    /// <param name="returnedResourceCopyId">The ID of the returned resource copy.</param>
    /// <returns>
    /// True if the update is successful, otherwise false.
    /// </returns>
    public bool UpdateBorrowRequestStatusToReturned(int returnedResourceCopyId)
    {
        string sql = $"UPDATE BorrowRequests SET Status = '{Status.Returned}' WHERE ResourceID IS NOT NULL AND CopyID = {returnedResourceCopyId} AND Status = '{Status.Approved}'";
        return connector.PostToDataBase(sql);
    }

    /// <summary>
    /// Updates the status of a borrow request to "Approved" and assigns a resource copy and due date.
    /// </summary>
    /// <param name="borrowRequestId">The ID of the borrow request.</param>
    /// <param name="assignedResourceCopyId">The ID of the assigned resource copy.</param>
    /// <param name="assignedDueDate">The assigned due date.</param>
    /// <returns>
    /// True if the update is successful, otherwise false.
    /// </returns>
    public bool UpdateBorrowRequestStatusToApproved(int borrowRequestId, int assignedResourceCopyId, DateOnly assignedDueDate)
    {
        string sql = $"UPDATE BorrowRequests SET Status = '{Status.Approved}', DueDate = '{assignedDueDate}', CopyID = {assignedResourceCopyId} WHERE RequestID = {borrowRequestId} AND Status = '{Status.Pending}'";
        return connector.PostToDataBase(sql);
    }

    /// <summary>
    /// Updates a borrow request with the specified parameters.
    /// </summary>
    /// <param name="borrowRequestId">The ID of the borrow request.</param>
    /// <param name="assignedResourceCopyId">The ID of the assigned resource copy.</param>
    /// <param name="assignedDueDate">The assigned due date.</param>
    /// <param name="statusToSet">The status to set for the borrow request.</param>
    /// <returns>
    /// True if the update is successful, otherwise false.
    /// </returns>
    public bool UpdateBorrowRequest(int borrowRequestId, int? assignedResourceCopyId, DateOnly? assignedDueDate, Status statusToSet)
    {
        string sql = $"UPDATE BorrowRequests SET Status = '{statusToSet}', DueDate = {assignedDueDate.ToNullableSQLString(true)}, CopyID = {assignedResourceCopyId.ToNullableSQLString()} WHERE RequestID = {borrowRequestId}";
        return connector.PostToDataBase(sql);
    }


    #endregion UPDATE

    #region POST

    /// <summary>
    /// Posts a new user to the database.
    /// </summary>
    /// <param name="firstName">The first name of the user.</param>
    /// <param name="lastName">The last name of the user.</param>
    /// <param name="login">The login of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <param name="userType">The type of the user.</param>
    /// <returns>
    /// True if the post is successful, otherwise false.
    /// </returns>
    public bool PostNewUser(string firstName, string lastName, string login, string password, UserType userType)
    {
        bool isSuccess = connector.PostToDataBase($"INSERT INTO Users (FirstName, LastName, Login, Password, UserType) VALUES ('{firstName}', '{lastName}', '{login}', '{password}', '{userType.ToString()}')");
        return isSuccess;
    }

    /// <summary>
    /// Posts a new borrow request to the database.
    /// </summary>
    /// <param name="userId">The ID of the user making the request.</param>
    /// <param name="resourceId">The ID of the requested resource.</param>
    /// <param name="requestDate">The date of the request.</param>
    /// <param name="copyId">The ID of the resource copy, if applicable.</param>
    /// <param name="dueDate">The due date for the request, if applicable.</param>
    /// <param name="status">The status of the request.</param>
    /// <returns>
    /// True if the post is successful, otherwise false.
    /// </returns>
    public bool PostNewBorrowRequest(int userId, int resourceId, DateOnly requestDate, int? copyId, DateOnly? dueDate, Status status)
    {
        var copyIdStr = copyId.HasValue ? copyId.ToString() : "NULL";
        var dueDateStr = dueDate.HasValue ? "'" + dueDate.ToString() + "'" : "NULL";
        string sql = $"INSERT INTO BorrowRequests (UserID, ResourceID, RequestDate, CopyID, DueDate, Status) VALUES ({userId}, {resourceId}, '{requestDate}', {copyIdStr}, {dueDateStr}, '{status.ToString()}')";
        return connector.PostToDataBase(sql);
    }

    /// <summary>
    /// Posts a new resource copy to the database.
    /// </summary>
    /// <param name="resourceId">The ID of the associated resource.</param>
    /// <returns>
    /// True if the post is successful, otherwise false.
    /// </returns>
    public bool PostNewResourceCopy(int resourceId)
    {
        string sql = $"INSERT INTO ResourceCopies (ResourceID) VALUES ({resourceId})";
        return connector.PostToDataBase(sql);
    }

    /// <summary>
    /// Posts a new resource to the database.
    /// </summary>
    /// <param name="title">The title of the resource.</param>
    /// <param name="author">The author of the resource.</param>
    /// <param name="yearPublished">The year the resource was published.</param>
    /// <param name="resourceType">The type of the resource.</param>
    /// <returns>
    /// True if the post is successful, otherwise false.
    /// </returns>
    public bool PostNewResource(string title, string author, int yearPublished, ResourceType resourceType)
    {
        string sql = $"INSERT INTO Resources (Title, Author, YearPublished, ResourceType) VALUES ('{title}', '{author}', {yearPublished}, '{resourceType.ToString()}')";
        return connector.PostToDataBase(sql);
    }


    #endregion POST



    #region DELETE

    /// <summary>
    /// Deletes a resource copy from the database.
    /// </summary>
    /// <param name="toDeleteCopyId">The ID of the resource copy to delete.</param>
    /// <returns>
    /// True if the deletion is successful, otherwise false.
    /// </returns>
    public bool DeleteResourceCopy(int toDeleteCopyId)
    {
        string sql = $"DELETE FROM ResourceCopies WHERE CopyID = {toDeleteCopyId}";
        return connector.PostToDataBase(sql);
    }

    /// <summary>
    /// Deletes a resource from the database.
    /// </summary>
    /// <param name="toDeleteResourceId">The ID of the resource to delete.</param>
    /// <returns>
    /// True if the deletion is successful, otherwise false.
    /// </returns>
    public bool DeleteResource(int toDeleteResourceId)
    {
        string sql = $"DELETE FROM Resources WHERE ResourceID = {toDeleteResourceId}";
        return connector.PostToDataBase(sql);
    }

    /// <summary>
    /// Deletes a user from the database.
    /// </summary>
    /// <param name="toDeleteUserId">The ID of the user to delete.</param>
    /// <returns>
    /// True if the deletion is successful, otherwise false.
    /// </returns>
    public bool DeleteUser(int toDeleteUserId)
    {
        string sql = $"DELETE FROM Users WHERE UserID = {toDeleteUserId}";
        return connector.PostToDataBase(sql);
    }

    /// <summary>
    /// Deletes a borrow request from the database.
    /// </summary>
    /// <param name="toDeleteRequestId">The ID of the borrow request to delete.</param>
    /// <returns>
    /// True if the deletion is successful, otherwise false.
    /// </returns>
    public bool DeleteBorrowRequest(int toDeleteRequestId)
    {
        string sql = $"DELETE FROM BorrowRequests WHERE RequestID = {toDeleteRequestId}";
        return connector.PostToDataBase(sql);
    }


    #endregion DELETE
}
