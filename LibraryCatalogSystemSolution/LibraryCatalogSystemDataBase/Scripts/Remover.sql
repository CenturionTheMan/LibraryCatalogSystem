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