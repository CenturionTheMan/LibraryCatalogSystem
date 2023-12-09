namespace LibraryDatabaseApiUnitTests;

public class Tests
{
    const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";
    private LibraryDatabaseApi api = new LibraryDatabaseApi(PROVIDER, CONNECTION_STRING);

    [Fact]
    public void UsersTableTests()
    {
        var users = api.GetUsers();
        Assert.NotNull(users);
        Assert.NotEmpty(users);

        int amount = users.Count();

        Assert.True(api.PostNewUser("TEST", "TEST", "TEST", "TEST", UserType.Employee));
        var posted = api.GetUserByLogin("TEST");
        Assert.NotNull(posted);

        var user1 = api.GetUserById(posted.UserID);
        Assert.NotNull(user1);

        Assert.Equal(user1.UserID, posted.UserID);

        users = api.GetUsers();
        Assert.NotNull(users);
        Assert.Equal(amount + 1, users.Count());

        Assert.True(api.DeleteUser(posted.UserID));

        users = api.GetUsers();
        Assert.NotNull(users);
        Assert.Equal(amount, users.Count());
    }


    [Fact]
    public void BorrowRequestsTableTests()
    {
        var req = api.GetBorrowRequests();
        Assert.NotNull(req);

        Assert.True(api.PostNewUser("TEST", "TEST", "TEST", "TEST", UserType.Employee));
        var user = api.GetUserByLogin("TEST");
        Assert.NotNull(user);

        Assert.True(api.PostNewResource("TEST", "TEST", 1111, ResourceType.Book));
        var resources = api.GetResources("TEST", "TEST", 1111, ResourceType.Book);
        Assert.NotNull(resources);
        Assert.Single(resources);

        Assert.True(api.PostNewBorrowRequest(user.UserID, resources[0].ResourceID, new DateTime(2023, 11, 1), null, null, Status.Pending));


        Assert.True(api.DeleteResource(resources[0].ResourceID));
        Assert.True(api.DeleteUser(user.UserID));
    }
}