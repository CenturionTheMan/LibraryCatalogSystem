﻿/*
Deployment script for LibraryDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "LibraryDatabase"
:setvar DefaultFilePrefix "LibraryDatabase"
:setvar DefaultDataPath "C:\Users\dzied\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\dzied\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
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
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
-- Remove tables
DROP TABLE IF EXISTS BorrowRequests;
DROP TABLE IF EXISTS ResourceCopy;
DROP TABLE IF EXISTS LibraryResource;
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
PRINT N'Creating Table [dbo].[LibraryResource]...';


GO
CREATE TABLE [dbo].[LibraryResource] (
    [ResourceID]    INT           IDENTITY (1, 1) NOT NULL,
    [Title]         VARCHAR (255) NOT NULL,
    [Author]        VARCHAR (255) NOT NULL,
    [YearPublished] INT           NOT NULL,
    [ResourceType]  VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([ResourceID] ASC)
);


GO
PRINT N'Creating Table [dbo].[LibraryUser]...';


GO
CREATE TABLE [dbo].[LibraryUser] (
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
PRINT N'Creating Table [dbo].[ResourceCopy]...';


GO
CREATE TABLE [dbo].[ResourceCopy] (
    [CopyID]     INT IDENTITY (1, 1) NOT NULL,
    [ResourceID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CopyID] ASC)
);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[BorrowRequests]...';


GO
ALTER TABLE [dbo].[BorrowRequests]
    ADD FOREIGN KEY ([UserID]) REFERENCES [dbo].[LibraryUser] ([UserID]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[BorrowRequests]...';


GO
ALTER TABLE [dbo].[BorrowRequests]
    ADD FOREIGN KEY ([CopyID]) REFERENCES [dbo].[ResourceCopy] ([CopyID]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[BorrowRequests]...';


GO
ALTER TABLE [dbo].[BorrowRequests]
    ADD FOREIGN KEY ([ResourceID]) REFERENCES [dbo].[LibraryResource] ([ResourceID]);


GO
PRINT N'Creating Foreign Key unnamed constraint on [dbo].[ResourceCopy]...';


GO
ALTER TABLE [dbo].[ResourceCopy]
    ADD FOREIGN KEY ([ResourceID]) REFERENCES [dbo].[LibraryResource] ([ResourceID]);


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
JOIN LibraryUser U ON BR.UserID = U.UserID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
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
FROM LibraryUser U
JOIN BorrowRequests BR ON U.UserID = BR.UserID
JOIN ResourceCopy RC ON BR.CopyID = RC.CopyID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
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
JOIN LibraryUser U ON BR.UserID = U.UserID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
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
FROM LibraryResource R
LEFT JOIN ResourceCopy RC ON R.ResourceID = RC.ResourceID
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
FROM LibraryUser U
JOIN BorrowRequests BR ON U.UserID = BR.UserID
JOIN ResourceCopy RC ON BR.CopyID = RC.CopyID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
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
FROM LibraryUser U
JOIN BorrowRequests BR ON U.UserID = BR.UserID
JOIN ResourceCopy RC ON BR.CopyID = RC.CopyID
JOIN LibraryResource R ON BR.ResourceID = R.ResourceID
WHERE BR.Status = 'Approved';
GO
------------------------------------------------------------------------------- EXAMPLE DATA
-- Users
INSERT INTO LibraryUser (FirstName, LastName, Login, Password, UserType) VALUES
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
INSERT INTO LibraryResource (Title, Author, YearPublished, ResourceType) VALUES
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

-- ResourceCopy
INSERT INTO ResourceCopy (ResourceID) VALUES
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
(3, 2, '2023-01-02', 3, '2023-01-16', 'Pending'),
(5, 3, '2023-01-03', NULL, NULL, 'Pending'),
(2, 4, '2023-01-04', NULL, NULL, 'Approved'),
(4, 5, '2023-01-05', 5, '2023-01-20', 'Returned'),
(6, 6, '2023-01-06', 6, '2023-01-21', 'Approved'),
(8, 7, '2023-01-07', 8, '2023-01-22', 'Pending'),
(10, 8, '2023-01-08', NULL, NULL, 'Approved'),
(7, 9, '2023-01-09', NULL, NULL, 'Pending'),
(9, 10, '2023-01-10', 10, '2023-01-25', 'Approved'),
(11, 1, '2023-01-11', 11, '2023-01-26', 'Returned'),
(7, 2, '2023-01-12', 12, '2023-01-27', 'Pending'),
(9, 3, '2023-01-13', NULL, NULL, 'Pending'),
(12, 4, '2023-01-14', 13, '2023-01-28', 'Approved'),
(1, 5, '2023-01-15', 14, '2023-01-29', 'Approved'),
(4, 6, '2023-01-16', 15, '2023-01-30', 'Returned'),
(3, 7, '2023-01-17', NULL, NULL, 'Approved'),
(5, 8, '2023-01-18', 16, '2023-01-31', 'Pending'),
(4, 9, '2023-01-19', 17, '2023-02-01', 'Returned'),
(1, 10, '2023-01-20', 18, '2023-02-02', 'Pending');
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
