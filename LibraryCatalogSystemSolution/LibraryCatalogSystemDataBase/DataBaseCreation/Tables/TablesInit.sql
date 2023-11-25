-- Create User table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    UserType VARCHAR(50) NOT NULL -- 'Client' or 'Employee'
);

-- Create Resources table
CREATE TABLE Resources (
    ResourceID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255),
    YearPublished INT,
    ResourceType VARCHAR(50) NOT NULL, -- 'Book', 'Magazine', etc.
    TotalCopies INT NOT NULL,
    AvailableCopies INT NOT NULL,
);

-- Create ResourceCopies table to represent individual copies of resources
CREATE TABLE ResourceCopies (
    CopyID INT PRIMARY KEY IDENTITY(1,1),
    ResourceID INT,
    Status VARCHAR(50) NOT NULL, -- 'Available', 'Borrowed', etc.
    BorrowedByID INT,
    FOREIGN KEY (ResourceID) REFERENCES Resources(ResourceID),
    FOREIGN KEY (BorrowedByID) REFERENCES Users(UserID),
);

-- Create BorrowRequests table
CREATE TABLE BorrowRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    CopyID INT,
    RequestDate DATE,
    DueDate DATE,
    Status VARCHAR(50) NOT NULL, -- 'Pending', 'Approved', 'Returned'
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (CopyID) REFERENCES ResourceCopies(CopyID),
);

