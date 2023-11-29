----------------------------------------------------------------------------- TABLES
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Login VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    UserType VARCHAR(50) NOT NULL -- Client / Employee
);

CREATE TABLE Resources (
    ResourceID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255) NOT NULL,
    YearPublished INT NOT NULL,
    ResourceType VARCHAR(50) NOT NULL, -- Book / Magazine / ....
);

-- represents individual copies of resources
CREATE TABLE ResourceCopies (
    CopyID INT PRIMARY KEY IDENTITY(1,1),
    ResourceID INT NOT NULL,
    FOREIGN KEY (ResourceID) REFERENCES Resources(ResourceID),
);

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


----------------------------------------------------------------------------- EXAMPLE DATA
-- Users
INSERT INTO Users (FirstName, LastName, Login, Password, UserType) VALUES
('Adam', 'Nowak', 'anowak', 'pass123', 'Client'),
('Ewa', 'Kowalska', 'ekowalska', 'securepass', 'Client'),
('Mateusz', 'Wójcik', 'mwojcik', 'pass456', 'Client'),
('Karolina', 'Lis', 'klis', 'strongpass', 'Client'),
('Marcin', 'Kaczmarek', 'mkaczmarek', 'userpass', 'Client'),
('Alicja', 'Pawlak', 'apawlak', 'pass789', 'Client'),
('Michał', 'Duda', 'mduda', 'testpass', 'Client'),
('Katarzyna', 'Szymańska', 'kszymanska', 'mypassword', 'Client'),
('Piotr', 'Kowalczyk', 'pkowalczyk', 'pass1234', 'Client'),
('Anna', 'Jankowska', 'ajankowska', 'pass5678', 'Client'),
('Tomasz', 'Wiśniewski', 'twisniewski', 'securepass', 'Client'),
('Magdalena', 'Zając', 'mzajac', 'pass987', 'Client'),
('Grzegorz', 'Kowal', 'gkowal', 'testpass', 'Employee'),
('Agnieszka', 'Nowicka', 'anowicka', 'mypass', 'Employee'),
('Łukasz', 'Sikora', 'lsikora', 'pass654', 'Employee');

-- Resources
INSERT INTO Resources (Title, Author, YearPublished, ResourceType) VALUES
('Database Management', 'John Smith', 2020, 'Book'),
('Web Development Basics', 'Alice Johnson', 2019, 'Book'),
('Data Science in Practice', 'Michael Brown', 2022, 'Magazine'),
('Java Programming', 'Emily Davis', 2021, 'Book'),
('Introduction to Python', 'Daniel Wilson', 2018, 'Magazine'),
('Artificial Intelligence Fundamentals', 'Sophie White', 2020, 'Book'),
('Network Security', 'Andrew Miller', 2019, 'Book'),
('Software Engineering Principles', 'Olivia Taylor', 2022, 'Magazine'),
('Machine Learning Applications', 'William Brown', 2021, 'Book'),
('Mobile App Development', 'Emma Turner', 2018, 'Magazine');

-- ResourceCopies
INSERT INTO ResourceCopies (ResourceID) VALUES
(1),
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10),
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10),
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10),
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10);

-- BorrowRequests
INSERT INTO BorrowRequests (UserID, ResourceID, RequestDate, CopyID, DueDate, Status) VALUES
(1, 1, '2023-01-01', 1, '2023-01-15', 'Approved'),
(3, 2, '2023-01-02', 3, '2023-01-16', 'Pending'),
(5, 3, '2023-01-03', NULL, NULL, 'Pending'),
(2, 4, '2023-01-04', NULL, '2023-11-29', 'Approved'),
(4, 5, '2023-01-05', 5, '2023-01-20', 'Returned'),
(6, 6, '2023-01-06', 6, '2023-01-21', 'Approved'),
(8, 7, '2023-01-07', 8, '2023-01-22', 'Pending'),
(10, 8, '2023-01-08', NULL, '2024-01-01', 'Approved'),
(7, 9, '2023-01-09', NULL, NULL, 'Pending'),
(9, 10, '2023-01-10', 10, '2023-01-25', 'Approved'),
(11, 1, '2023-01-11', 11, '2023-01-26', 'Returned'),
(7, 2, '2023-01-12', 12, '2023-01-27', 'Pending'),
(9, 3, '2023-01-13', NULL, NULL, 'Pending'),
(12, 4, '2023-01-14', 13, '2023-01-28', 'Approved'),
(1, 5, '2023-01-15', 14, '2023-01-29', 'Approved'),
(4, 6, '2023-01-16', 15, '2023-01-30', 'Returned'),
(3, 7, '2023-01-17', NULL, '2024-02-01', 'Approved'),
(5, 8, '2023-01-18', 16, '2023-01-31', 'Pending'),
(4, 9, '2023-01-19', 17, '2023-02-01', 'Returned'),
(1, 10, '2023-01-20', 18, '2023-02-02', 'Pending');
