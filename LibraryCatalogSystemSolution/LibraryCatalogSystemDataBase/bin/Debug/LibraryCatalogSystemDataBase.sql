﻿/*
Deployment script for LibraryCatalogSystemDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "LibraryCatalogSystemDatabase"
:setvar DefaultFilePrefix "LibraryCatalogSystemDatabase"
:setvar DefaultDataPath "C:\Users\dzied\AppData\Local\Microsoft\VisualStudio\SSDT\LibraryCatalogSystemSolution"
:setvar DefaultLogPath "C:\Users\dzied\AppData\Local\Microsoft\VisualStudio\SSDT\LibraryCatalogSystemSolution"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
-- Remove tables
DROP TABLE IF EXISTS BorrowRequests;
DROP TABLE IF EXISTS ResourceCopies;
DROP TABLE IF EXISTS Resources;
DROP TABLE IF EXISTS Users;

-- Remove views
DROP VIEW IF EXISTS UserDetailsWithBorrowedResources;
DROP VIEW IF EXISTS DelayedBorrowersView;
DROP VIEW IF EXISTS ApprovedBorrowRequests;
DROP VIEW IF EXISTS SummarisedResources;
DROP VIEW IF EXISTS PendingBorrowRequests;
GO

GO
PRINT N'Creating Table [dbo].[BorrowRequests]...';


GO
CREATE TABLE [dbo].[BorrowRequests] (
    [RequestID]   INT          IDENTITY (1, 1) NOT NULL,
    [UserID]      INT          NOT NULL,
    [ResourceID]  INT          NOT NULL,
    [RequestDate] DATE         NOT NULL,
    [CopyID]      INT          NULL,
    [DueDate]     DATE         NULL,
    [Status]      VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([RequestID] ASC)
);


GO
PRINT N'Creating Table [dbo].[ResourceCopies]...';


GO
CREATE TABLE [dbo].[ResourceCopies] (
    [CopyID]     INT IDENTITY (1, 1) NOT NULL,
    [ResourceID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CopyID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Resources]...';


GO
CREATE TABLE [dbo].[Resources] (
    [ResourceID]    INT           IDENTITY (1, 1) NOT NULL,
    [Title]         VARCHAR (255) NOT NULL,
    [Author]        VARCHAR (255) NOT NULL,
    [YearPublished] INT           NOT NULL,
    [ResourceType]  VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([ResourceID] ASC)
);


GO
PRINT N'Creating Table [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [UserID]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (255) NOT NULL,
    [LastName]  VARCHAR (255) NOT NULL,
    [Login]     VARCHAR (255) NOT NULL,
    [Password]  VARCHAR (255) NOT NULL,
    [UserType]  VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    UNIQUE NONCLUSTERED ([Login] ASC)
);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[BorrowRequests]...';


GO
ALTER TABLE [dbo].[BorrowRequests] WITH NOCHECK
    ADD FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[BorrowRequests]...';


GO
ALTER TABLE [dbo].[BorrowRequests] WITH NOCHECK
    ADD FOREIGN KEY ([CopyID]) REFERENCES [dbo].[ResourceCopies] ([CopyID]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[BorrowRequests]...';


GO
ALTER TABLE [dbo].[BorrowRequests] WITH NOCHECK
    ADD FOREIGN KEY ([ResourceID]) REFERENCES [dbo].[Resources] ([ResourceID]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[ResourceCopies]...';


GO
ALTER TABLE [dbo].[ResourceCopies] WITH NOCHECK
    ADD FOREIGN KEY ([ResourceID]) REFERENCES [dbo].[Resources] ([ResourceID]);


GO
PRINT N'Creating View [dbo].[ApprovedBorrowRequests]...';


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
PRINT N'Creating View [dbo].[DelayedBorrowersView]...';


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
PRINT N'Creating View [dbo].[PendingBorrowRequests]...';


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
PRINT N'Creating View [dbo].[SummarisedResources]...';


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
PRINT N'Creating View [dbo].[UserDetailsWithBorrowedResources]...';


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
PRINT N'Creating View [dbo].[UserWithBorrowedResources]...';


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
------------------------------------------------------------------------------- EXAMPLE DATA
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

GO

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

GO

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

GO

-- BorrowRequest
INSERT INTO BorrowRequests (UserID, ResourceID, RequestDate, CopyID, DueDate, Status) VALUES
(1, 1, '2023-01-01', 1, '2023-01-15', 'Approved'),
(3, 2, '2023-01-02',NULL, NULL, 'Pending'),
(5, 3, '2023-01-03', NULL, NULL, 'Pending'),
(2, 4, '2023-01-04', 4, '2024-01-15', 'Approved'),
(4, 5, '2023-01-05', 5, '2023-01-20', 'Returned'),
(6, 6, '2023-01-06', 6, '2023-01-21', 'Approved'),
(8, 7, '2023-01-07', NULL, NULL, 'Pending'),
(10, 8, '2023-01-08', 11, '2024-01-26', 'Approved'),
(7, 9, '2023-01-09', NULL, NULL, 'Pending'),
(9, 10, '2023-01-10', 10, '2023-01-25', 'Approved'),
(11, 1, '2023-01-11', 11, '2023-01-26', 'Returned'),
(7, 2, '2023-01-12', NULL, NULL, 'Pending'),
(9, 3, '2023-01-13', NULL, NULL, 'Pending'),
(12, 4, '2023-01-14', 13, '2023-01-28', 'Approved'),
(1, 5, '2023-01-15', 14, '2023-01-29', 'Approved'),
(4, 6, '2023-01-16', 15, '2023-01-30', 'Returned'),
(3, 7, '2023-01-17', 1, '2023-08-30', 'Approved'),
(5, 8, '2023-01-18', NULL, NULL, 'Pending'),
(4, 9, '2023-01-19', 17, '2023-02-01', 'Returned'),
(1, 10, '2023-01-20', NULL, NULL, 'Pending');
GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.BorrowRequests'), OBJECT_ID(N'dbo.ResourceCopies'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Checking constraint: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Constraint verification failed:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'An error occurred while verifying constraints', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Update complete.';


GO
