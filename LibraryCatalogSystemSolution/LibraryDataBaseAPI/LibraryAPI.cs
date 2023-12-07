using Dapper;
using System.Data.Common;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace LibraryDataBaseAPI;

public static class LibraryApi
{
    internal const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    internal const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";

    private static Connector connector;

    static LibraryApi()
    {
        connector = new(PROVIDER, CONNECTION_STRING);
    }

    public static List<LibraryUser>? GetLibraryUsers()
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

    public static List<BorrowRequests>? GetBorrowRequests()
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

    public static List<ResourceCopy>? GetResourceCopies()
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

    public static List<LibraryResource>? GetLibraryResources()
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

    public static void PostLibraryUser(string firstName, string lastName, string login, string password, string userType)
    {
        connector.PostToDataBase($"INSERT INTO LibraryUser (FirstName, LastName, Login, Password, UserType) VALUES ('{firstName}', '{lastName}', '{login}', '{password}', '{userType}')");
    }
}
