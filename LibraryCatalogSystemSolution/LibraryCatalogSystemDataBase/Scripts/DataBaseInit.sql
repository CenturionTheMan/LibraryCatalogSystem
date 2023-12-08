----------------------------------------------------------------------------- TABLES
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Login VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    UserType VARCHAR(50) NOT NULL -- Client / Employee
);

GO

CREATE TABLE Resources (
    ResourceID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    YearPublished INT NOT NULL,
    ResourceType VARCHAR(50) NOT NULL, -- Book / Magazine / ....
);

GO

-- represents individual copies of resources
CREATE TABLE ResourceCopies (
    CopyID INT PRIMARY KEY IDENTITY(1,1),
    ResourceID INT NOT NULL,
    FOREIGN KEY (ResourceID) REFERENCES Resources(ResourceID),
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
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (CopyID) REFERENCES ResourceCopies(CopyID),
    FOREIGN KEY (ResourceID) REFERENCES Resources(ResourceID),
);

GO


----------------------------------------------------------------------------- VIEWS
CREATE VIEW UserWithBorrowedResources AS
SELECT
    U.UserID,
    R.ResourceID,
    R.Title,
    R.Author,
    R.YearPublished,
    R.ResourceType
FROM Users U
JOIN BorrowRequests BR ON U.UserID = BR.UserID
JOIN ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN Resources R ON BR.ResourceID = R.ResourceID
WHERE BR.Status = 'Approved';
GO

CREATE VIEW SummarisedResources AS
SELECT
    R.ResourceID,
    R.Title,
    COUNT(RC.CopyID) AS TotalCopies,
    COUNT(CASE WHEN BR.Status = 'Approved' THEN 1 END) AS BorrowedCopies
FROM Resources R
LEFT JOIN ResourceCopies RC ON R.ResourceID = RC.ResourceID
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
FROM Users U
JOIN BorrowRequests BR ON U.UserID = BR.UserID
JOIN ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN Resources R ON BR.ResourceID = R.ResourceID
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
FROM Users U
JOIN BorrowRequests BR ON U.UserID = BR.UserID
JOIN ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN Resources R ON BR.ResourceID = R.ResourceID
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
JOIN Users U ON BR.UserID = U.UserID
JOIN Resources R ON BR.ResourceID = R.ResourceID
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
JOIN Users U ON BR.UserID = U.UserID
JOIN Resources R ON BR.ResourceID = R.ResourceID
WHERE BR.Status = 'Pending';
GO
