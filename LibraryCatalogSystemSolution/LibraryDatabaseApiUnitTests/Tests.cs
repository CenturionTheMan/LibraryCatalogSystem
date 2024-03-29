namespace LibraryDatabaseApiUnitTests;

public class Tests
{
    const string PROVIDER = ".NET Framework Data Provider for SQL Server";
    const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryDataBase;Integrated Security=True";
    private DatabaseApi api = new DatabaseApi(PROVIDER, CONNECTION_STRING);

    [Fact]
    public void GetUserByLoginTest()
    {
        var users = api.GetUsers();
        Assert.NotNull(users);
        Assert.NotEmpty(users);

        var user = api.GetUserByLogin(users[0].Login);
        Assert.NotNull(user);

        Assert.Equal(users[0].UserID, user.UserID);
        Assert.Equal(users[0].FirstName, user.FirstName);
        Assert.Equal(users[0].LastName, user.LastName);
        Assert.Equal(users[0].Login, user.Login);
        Assert.Equal(users[0].Password, user.Password);
        Assert.Equal(users[0].UserType, user.UserType);
    }

    [Fact]
    public void GetUserByIdTest()
    {
        var users = api.GetUsers();
        Assert.NotNull(users);
        Assert.NotEmpty(users);

        var user = api.GetUserById(users[0].UserID);
        Assert.NotNull(user);

        Assert.Equal(users[0].UserID, user.UserID);
        Assert.Equal(users[0].FirstName, user.FirstName);
        Assert.Equal(users[0].LastName, user.LastName);
        Assert.Equal(users[0].Login, user.Login);
        Assert.Equal(users[0].Password, user.Password);
        Assert.Equal(users[0].UserType, user.UserType);
    }

    [Fact]
    public void GetUsersTest()
    {
        var users = api.GetUsers();
        Assert.NotNull(users);
    }

    [Fact]
    public void GetResourceAmountsTest()
    {
        var resources = api.GetResources();
        Assert.NotNull(resources);
        Assert.NotEmpty(resources);

        var tmp = api.GetResourceAmounts(resources[0].ResourceID);
        Assert.NotNull(tmp);
        Assert.Equal(tmp.Value.amount, tmp.Value.borrowed + tmp.Value.available);
    }

    [Fact]
    public void GetBorrowRequestsTest()
    {
        var allReq = api.GetBorrowRequests();
        Assert.NotNull(allReq);
        Assert.NotEmpty(allReq);

        var returnedReq = api.GetBorrowRequests(Status.Returned);
        var approvedReq = api.GetBorrowRequests(Status.Approved);
        var pendingReq = api.GetBorrowRequests(Status.Pending);

        Assert.NotNull(returnedReq);
        Assert.NotNull(approvedReq);
        Assert.NotNull(pendingReq);

        Assert.Equal(allReq.FindAll(r => r.Status == Status.Returned).Count(), returnedReq.Count());
        Assert.Equal(allReq.FindAll(r => r.Status == Status.Approved).Count(), approvedReq.Count());
        Assert.Equal(allReq.FindAll(r => r.Status == Status.Pending).Count(), pendingReq.Count());

        Assert.True(pendingReq.TrueForAll(r => r.DueDate == null && r.CopyID == null));
        Assert.True(approvedReq.TrueForAll(r => r.DueDate != null && r.CopyID != null));
        Assert.True(returnedReq.TrueForAll(r => r.DueDate != null && r.CopyID != null));
    }

    [Fact]
    public void GetResourceCopiesTest()
    {
        var resAll = api.GetResourceCopies();
        Assert.NotNull(resAll);
    }

    [Fact]
    public void GetResourcesTest()
    {
        var resAll = api.GetResources();
        Assert.NotNull(resAll);
        Assert.NotEmpty(resAll);

        var fil = api.GetResources(resAll[0].Title, resAll[0].Author, resAll[0].YearPublished, resAll[0].ResourceType);
        Assert.NotNull(fil);
        Assert.NotEmpty(fil);

        foreach (var item in fil)
        {
            Assert.Equal(resAll[0].ResourceID, item.ResourceID);
            Assert.Equal(resAll[0].Title, item.Title);
            Assert.Equal(resAll[0].Author, item.Author);
            Assert.Equal(resAll[0].YearPublished, item.YearPublished);
            Assert.Equal(resAll[0].ResourceType, item.ResourceType);
        }
    }

    [Fact]
    public void GetResourcesBorrowedByUserTest()
    {
        var users = api.GetUsers();
        Assert.NotNull(users);
        Assert.NotEmpty(users);

        List<Resource>? borrowed = null;
        int userID = 0;
        foreach (var user in users)
        {
            borrowed = api.GetResourcesBorrowedByUser(user.UserID);
            Assert.NotNull(borrowed);
            userID = user.UserID;
            if (borrowed.Count > 0)
            {
                break;
            }
        }
        Assert.NotNull(borrowed);

        var reqAll = api.GetBorrowRequests();
        Assert.NotNull(reqAll);

        var resCopiesAll = api.GetResourceCopies();
        Assert.NotNull(resCopiesAll);

        var customResIds = reqAll.FindAll(r => r.UserID == userID && r.Status == Status.Approved).Select(r => r.ResourceID);


        Assert.True(borrowed.TrueForAll(b => customResIds.Contains(b.ResourceID)));
    }

    [Fact]
    public void UpdateBorrowRequestStatusToReturnedTest()
    {
        var borrowedReq = api.GetBorrowRequests();
        Assert.NotNull(borrowedReq);
        Assert.NotEmpty(borrowedReq);

        var approvedAll = borrowedReq.FindAll(b => b.Status == Status.Approved);
        Assert.NotNull(approvedAll);

        foreach (var item in approvedAll)
        {
            Assert.NotNull(item.CopyID);
            Assert.True(api.UpdateBorrowRequestStatusToReturned(item.CopyID.Value));
        }

        var updatedBorrowedReq = api.GetBorrowRequests();
        Assert.NotNull(updatedBorrowedReq);
        Assert.True(updatedBorrowedReq.TrueForAll(ubr => ubr.Status == Status.Returned || ubr.Status == Status.Pending));

        foreach (var item in approvedAll)
        {
            Assert.True(api.UpdateBorrowRequest(item.RequestID, item.CopyID, item.DueDate, Status.Approved));
        }
    }

    [Fact]
    public void UpdateBorrowRequestStatusToApprovedTest()
    {
        var borrowedReq = api.GetBorrowRequests();
        Assert.NotNull(borrowedReq);
        Assert.NotEmpty(borrowedReq);

        var pendingAll = borrowedReq.FindAll(b => b.Status == Status.Pending);
        Assert.NotNull(pendingAll);

        var date = new DateOnly(2023, 1, 1);
        foreach (var item in pendingAll)
        {
            Assert.True(api.UpdateBorrowRequestStatusToApproved(item.RequestID, 1, date));
        }

        var updatedBorrowedReq = api.GetBorrowRequests();
        Assert.NotNull(updatedBorrowedReq);
        Assert.True(updatedBorrowedReq.TrueForAll(ubr => ubr.Status == Status.Returned || ubr.Status == Status.Approved));

        foreach (var item in pendingAll)
        {
            Assert.True(api.UpdateBorrowRequest(item.RequestID, item.CopyID, item.DueDate, item.Status));
        }
    }

    [Fact]
    public void UpdateBorrowRequestTest()
    {
        var borrowedReq = api.GetBorrowRequests();
        Assert.NotNull(borrowedReq);
        Assert.NotEmpty(borrowedReq);

        var pendingAll = borrowedReq.FindAll(b => b.Status == Status.Pending);
        Assert.NotNull(pendingAll);
        var approvedAll = borrowedReq.FindAll(b => b.Status == Status.Approved);
        Assert.NotNull(approvedAll);


        var date = new DateOnly(2023, 1, 1);
        foreach (var item in borrowedReq)
        {
            Assert.True(api.UpdateBorrowRequest(item.RequestID, 1, date, Status.Returned));
        }

        var updatedBorrowedReq = api.GetBorrowRequests();
        Assert.NotNull(updatedBorrowedReq);
        Assert.True(updatedBorrowedReq.TrueForAll(ubr => ubr.Status == Status.Returned));
        Assert.True(updatedBorrowedReq.TrueForAll(ubr => ubr.CopyID == 1));
        Assert.True(updatedBorrowedReq.TrueForAll(ubr => ubr.DueDate == date));

        foreach (var item in borrowedReq)
        {
            Assert.True(api.UpdateBorrowRequest(item.RequestID, item.CopyID, item.DueDate, item.Status));
        }
    }

    [Fact]
    public void PostDeleteUserTest()
    {
        Assert.True(api.PostNewUser("testname", "testlastname", "testlogin", "123", UserType.Employee));

        var user = api.GetUserByLogin("testlogin");
        Assert.NotNull(user);

        var users = api.GetUsers();
        Assert.NotNull(users);

        Assert.True(api.DeleteUser(user.UserID));

        var newUsers = api.GetUsers();
        Assert.NotNull(newUsers);

        Assert.Equal(users.Count(), newUsers.Count() + 1);
    }

    [Fact]
    public void PostDeleteBorrowRequestTest()
    {
        var users = api.GetUsers();
        var res = api.GetResources();
        Assert.NotNull(users);
        Assert.NotEmpty(users);
        Assert.NotNull(res);
        Assert.NotEmpty(res);

        var req = api.GetBorrowRequests();
        Assert.NotNull(req);
        Assert.NotEmpty(req);

        Assert.True(api.PostNewBorrowRequest(users[0].UserID, res[0].ResourceID, new DateOnly(1900,1,1), null, null, Status.Pending));

        var newReq = api.GetBorrowRequests();
        Assert.NotNull(newReq);

        var selected = newReq.FindAll(e => 
        e.UserID == users[0].UserID && 
        res[0].ResourceID == e.ResourceID && 
        e.RequestDate == new DateOnly(1900, 1, 1) &&
        e.DueDate == null &&
        e.CopyID == null &&
        e.Status == Status.Pending).Single();

        Assert.Equal(req.Count() + 1, newReq.Count());

        Assert.True(api.DeleteBorrowRequest(selected.RequestID));

        var newNewReq = api.GetBorrowRequests();
        Assert.NotNull(newNewReq);
        Assert.Equal(req.Count(), newNewReq.Count());
    }
    
    [Fact]
    public void PostDeleteResourceCopyTest()
    {
        var res = api.GetResources();
        Assert.NotNull(res);
        Assert.NotEmpty(res);

        var resCop = api.GetResourceCopies();
        Assert.NotNull(resCop);
        Assert.NotEmpty(resCop);

        Assert.True(api.PostNewResourceCopy(res[0].ResourceID));

        var newResCop = api.GetResourceCopies();
        Assert.NotNull(newResCop);

        Assert.Equal(resCop.Count() + 1, newResCop.Count());

        var selected = newResCop.FindAll(s => s.ResourceID == res[0].ResourceID).MaxBy(s => s.CopyID);
        Assert.NotNull(selected);

        Assert.True(api.DeleteResourceCopy(selected.CopyID));

        var newNewResCop = api.GetResourceCopies();
        Assert.NotNull(newNewResCop);
        Assert.Equal(resCop.Count(), newNewResCop.Count());
    }

    [Fact]
    public void PostDeleteResourceTest()
    {
        var res = api.GetResources();
        Assert.NotNull(res);
        Assert.NotEmpty(res);

        Assert.True(api.PostNewResource("Testtitle", "testauth", 1000, ResourceType.Magazine));
        
        var newRes = api.GetResources();
        Assert.NotNull(newRes);

        Assert.Equal(res.Count() + 1, newRes.Count());

        var added = api.GetResources("Testtitle", "testauth", 1000, ResourceType.Magazine);
        Assert.NotNull(added);

        Assert.True(api.DeleteResource(added[0].ResourceID));

        var newNewRes = api.GetResources();
        Assert.NotNull(newNewRes);
        Assert.Equal(res.Count(), newNewRes.Count());
    }
}