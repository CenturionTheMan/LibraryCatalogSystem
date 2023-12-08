----------------------------------------------------------------------------- TABLES
CREATE TABLE LibraryUser (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Login VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    UserType VARCHAR(50) NOT NULL -- Client / Employee
);

GO

CREATE TABLE LibraryResource (
    ResourceID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    YearPublished INT NOT NULL,
    ResourceType VARCHAR(50) NOT NULL, -- Book / Magazine / ....
);

GO

-- represents individual copies of resources
CREATE TABLE ResourceCopy (
    CopyID INT PRIMARY KEY IDENTITY(1,1),
    ResourceID INT NOT NULL,
    FOREIGN KEY (ResourceID) REFERENCES LibraryResource(ResourceID),
);

GO

CREATE TABLE BorrowRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    ResourceID INT NOT NULL,
    RequestDate DATE NOT NULL,
    CopyID INT, -- Assigned by Employee after acceptance
    DueDate DATE, -- Assigned by Employee after acceptance
    Status VARCHAR(50) NOT NULL, -- Pending / Approved / Returned
    FOREIGN KEY (UserID) REFERENCES LibraryUser(UserID),
    FOREIGN KEY (CopyID) REFERENCES ResourceCopy(CopyID),
    FOREIGN KEY (ResourceID) REFERENCES LibraryResource(ResourceID),
);

GO


----------------------------------------------------------------------------- VIEWS
CREATE VIEW SummarisedResources AS
SELECT
    R.ResourceID,
    R.Title,
    COUNT(RC.CopyID) AS TotalCopies,
    COUNT(CASE WHEN BR.Status = 'Approved' THEN 1 END) AS BorrowedCopies
FROM LibraryResource R
LEFT JOIN ResourceCopy RC ON R.ResourceID = RC.ResourceID
LEFT JOIN BorrowRequests BR ON RC.CopyID = BR.CopyID
GROUP BY R.ResourceID, R.Title;
GO

CREATE VIEW UserDetailsWithBorrowedResources AS
SELECT
    U.UserID,
    U.FirstName,
    U.LastName,
    U.Login,
    U.UserType,
    BR.RequestID,
    BR.RequestDate,
    BR.CopyID,
    BR.DueDate,
    R.Title AS BorrowedResource
FROM LibraryUser U
JOIN BorrowRequests BR ON U.UserID = BR.UserID
JOIN ResourceCopy RC ON BR.CopyID = RC.CopyID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
WHERE BR.Status = 'Approved';
GO

CREATE VIEW DelayedBorrowersView AS
SELECT
    U.UserID,
    U.FirstName,
    U.LastName,
    BR.RequestID,
    R.Title AS BorrowedResource,
    BR.DueDate,
    DATEDIFF(DAY, BR.DueDate, GETDATE()) AS DaysLate
FROM LibraryUser U
JOIN BorrowRequests BR ON U.UserID = BR.UserID
JOIN ResourceCopy RC ON BR.CopyID = RC.CopyID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
WHERE BR.Status = 'Returned' AND BR.DueDate < GETDATE();
GO

CREATE VIEW ApprovedBorrowRequests AS
SELECT
    BR.RequestID,
    U.FirstName,
    U.LastName,
    R.Title AS BorrowedResource,
    BR.RequestDate,
    BR.DueDate,
    BR.Status
FROM BorrowRequests BR
JOIN LibraryUser U ON BR.UserID = U.UserID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
WHERE BR.Status = 'Approved';
GO

CREATE VIEW PendingBorrowRequests AS
SELECT
    BR.RequestID,
    U.FirstName,
    U.LastName,
    R.Title AS RequestedResource,
    BR.RequestDate,
    BR.DueDate
FROM BorrowRequests BR
JOIN LibraryUser U ON BR.UserID = U.UserID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
WHERE BR.Status = 'Pending';
GO
