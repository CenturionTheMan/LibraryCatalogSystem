CREATE VIEW UserDetailsWithBorrowedResources AS
SELECT
    U.UserID,
    U.UserName,
    U.Password,
    U.UserType,
    R.Title AS BorrowedResource
FROM
    Users U
LEFT JOIN
    BorrowRequests BR ON U.UserID = BR.UserID
LEFT JOIN
    ResourceCopies RC ON BR.CopyID = RC.CopyID
LEFT JOIN
    Resources R ON RC.ResourceID = R.ResourceID;

GO

CREATE VIEW AvailableResources AS
SELECT
    R.ResourceID,
    R.Title,
    R.Author,
    R.YearPublished,
    R.ResourceType,
    R.TotalCopies,
    R.AvailableCopies
FROM
    Resources R
JOIN
    ResourceCopies RC ON R.ResourceID = RC.ResourceID
WHERE
    RC.Status = 'Available';

GO

CREATE VIEW PendingBorrowRequests AS
SELECT
    BR.RequestID,
    U.UserName AS Borrower,
    R.Title AS RequestedResource,
    BR.RequestDate,
    BR.DueDate
FROM
    BorrowRequests BR
JOIN
    Users U ON BR.UserID = U.UserID
JOIN
    ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN
    Resources R ON RC.ResourceID = R.ResourceID
WHERE
    BR.Status = 'Pending';

GO

CREATE VIEW ApprovedBorrowRequests AS
SELECT
    BR.RequestID,
    U.UserName AS Borrower,
    R.Title AS RequestedResource,
    BR.RequestDate,
    BR.DueDate
FROM
    BorrowRequests BR
JOIN
    Users U ON BR.UserID = U.UserID
JOIN
    ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN
    Resources R ON RC.ResourceID = R.ResourceID
WHERE
    BR.Status = 'Approved';

GO


CREATE VIEW DelayedBorrowersView AS
SELECT
    U.UserID,
    U.UserName,
    R.Title AS BorrowedResource,
    BR.RequestDate,
    BR.DueDate,
    GETDATE() AS CurrentDate,
    DATEDIFF(DAY, BR.DueDate, GETDATE()) AS DaysDelayed
FROM
    Users U
JOIN
    BorrowRequests BR ON U.UserID = BR.UserID
JOIN
    ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN
    Resources R ON RC.ResourceID = R.ResourceID
WHERE
    BR.Status = 'Borrowed' -- Change this to match your actual status for borrowed items
    AND GETDATE() > BR.DueDate; -- Customers who are delayed with returning borrowed items

GO

