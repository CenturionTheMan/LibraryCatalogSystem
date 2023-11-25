DROP TABLE IF EXISTS dbo.BorrowRequests;
DROP TABLE IF EXISTS dbo.ResourceCopies;
DROP TABLE IF EXISTS dbo.Resources;
DROP TABLE IF EXISTS dbo.Users;

-- Remove the views
DROP VIEW IF EXISTS UserDetailsWithBorrowedResources;
DROP VIEW IF EXISTS AvailableResources;
DROP VIEW IF EXISTS PendingBorrowRequests;
DROP VIEW IF EXISTS ApprovedBorrowRequests;
DROP VIEW IF EXISTS DelayedBorrowersView;