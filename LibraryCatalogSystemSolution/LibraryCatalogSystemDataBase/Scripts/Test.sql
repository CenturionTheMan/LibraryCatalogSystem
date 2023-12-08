SELECT * FROM Users;

SELECT * FROM BorrowRequests;

SELECT * FROM UserDetailsWithBorrowedResources;
SELECT * FROM DelayedBorrowersView;
SELECT * FROM ApprovedBorrowRequests;
SELECT * FROM SummarisedResources WHERE ResourceID = 2;
SELECT * FROM PendingBorrowRequests;

SELECT * FROM Users WHERE UserID = 1;

SELECT * FROM Users WHERE Login = '';

SELECT * FROM UserWithBorrowedResources WHERE UserID = 1;


UPDATE BorrowRequests SET DueDate = '??', ResourceID = 1 WHERE RequestID = 1;

DELETE FROM ResourceCopies WHERE CopyID = 1;

DELETE FROM Resources WHERE ResourceID = 1;

DELETE FROM Users WHERE UserID = 1;

DELETE FROM BorrowRequests WHERE RequestID = 1;