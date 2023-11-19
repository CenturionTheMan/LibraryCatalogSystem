-- Create User table
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    UserName VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    UserType VARCHAR(50) NOT NULL -- 'Client' or 'Employee'
);

-- Create Resources table
CREATE TABLE Resources (
    ResourceID INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255),
    YearPublished INT,
    ResourceType VARCHAR(50) NOT NULL, -- 'Book', 'Magazine', etc.
    TotalCopies INT NOT NULL
);

-- Create ResourceCopies table to represent individual copies of resources
CREATE TABLE ResourceCopies (
    CopyID INT PRIMARY KEY,
    ResourceID INT,
    Status VARCHAR(50) NOT NULL, -- 'Available', 'Borrowed', etc.
    FOREIGN KEY (ResourceID) REFERENCES Resources(ResourceID)
);

-- Create BorrowRequests table
CREATE TABLE BorrowRequests (
    RequestID INT PRIMARY KEY,
    UserID INT,
    CopyID INT,
    RequestDate DATE,
    DueDate DATE,
    Status VARCHAR(50) NOT NULL, -- 'Pending', 'Approved', 'Rejected'
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (CopyID) REFERENCES ResourceCopies(CopyID)
);

-- Create ReturnRecords table
CREATE TABLE ReturnRecords (
    ReturnID INT PRIMARY KEY,
    CopyID INT,
    UserID INT,
    ReturnDate DATE,
    FOREIGN KEY (CopyID) REFERENCES ResourceCopies(CopyID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
