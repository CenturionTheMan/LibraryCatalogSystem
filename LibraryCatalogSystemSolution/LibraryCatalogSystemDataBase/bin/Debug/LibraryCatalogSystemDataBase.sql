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
PRINT N'Update complete.';


GO
