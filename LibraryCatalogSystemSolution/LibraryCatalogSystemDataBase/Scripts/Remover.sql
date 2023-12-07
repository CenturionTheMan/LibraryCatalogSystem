-- Remove tables
DROP TABLE IF EXISTS dbo.BorrowRequests;
DROP TABLE IF EXISTS dbo.ResourceCopy;
DROP TABLE IF EXISTS dbo.LibraryResource;
DROP TABLE IF EXISTS dbo.Users;

-- Remove views
DROP VIEW IF EXISTS UserDetailsWithBorrowedResources;
DROP VIEW IF EXISTS DelayedBorrowersView;
DROP VIEW IF EXISTS ApprovedBorrowRequests;
DROP VIEW IF EXISTS SummarisedResources;
DROP VIEW IF EXISTS PendingBorrowRequests;