﻿----------------------------------------------------------------------------- TABLES
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

GO

----------------------------------------------------------------------------- VIEWS
CREATE VIEW UserDetailsWithBorrowedResources AS
SELECT
    U.UserID,
    U.UserName,
    U.Password,
    U.UserType,
    R.Title AS BorrowedResource
FROM
    Users U
LEFT JOIN
    BorrowRequests BR ON U.UserID = BR.UserID
LEFT JOIN
    ResourceCopies RC ON BR.CopyID = RC.CopyID
LEFT JOIN
    Resources R ON RC.ResourceID = R.ResourceID;

GO

CREATE VIEW AvailableResources AS
SELECT
    R.ResourceID,
    R.Title,
    R.Author,
    R.YearPublished,
    R.ResourceType,
    R.TotalCopies,
    R.AvailableCopies
FROM
    Resources R
JOIN
    ResourceCopies RC ON R.ResourceID = RC.ResourceID
WHERE
    RC.Status = 'Available';

GO

CREATE VIEW PendingBorrowRequests AS
SELECT
    BR.RequestID,
    U.UserName AS Borrower,
    R.Title AS RequestedResource,
    BR.RequestDate,
    BR.DueDate
FROM
    BorrowRequests BR
JOIN
    Users U ON BR.UserID = U.UserID
JOIN
    ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN
    Resources R ON RC.ResourceID = R.ResourceID
WHERE
    BR.Status = 'Pending';

GO

CREATE VIEW ApprovedBorrowRequests AS
SELECT
    BR.RequestID,
    U.UserName AS Borrower,
    R.Title AS RequestedResource,
    BR.RequestDate,
    BR.DueDate
FROM
    BorrowRequests BR
JOIN
    Users U ON BR.UserID = U.UserID
JOIN
    ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN
    Resources R ON RC.ResourceID = R.ResourceID
WHERE
    BR.Status = 'Approved';

GO


CREATE VIEW DelayedBorrowersView AS
SELECT
    U.UserID,
    U.UserName,
    R.Title AS BorrowedResource,
    BR.RequestDate,
    BR.DueDate,
    GETDATE() AS CurrentDate,
    DATEDIFF(DAY, BR.DueDate, GETDATE()) AS DaysDelayed
FROM
    Users U
JOIN
    BorrowRequests BR ON U.UserID = BR.UserID
JOIN
    ResourceCopies RC ON BR.CopyID = RC.CopyID
JOIN
    Resources R ON RC.ResourceID = R.ResourceID
WHERE
    BR.Status = 'Borrowed'
    AND GETDATE() > BR.DueDate;

GO

----------------------------------------------------------------------------- EXAMPLE DATA
-- Insert data into Users
INSERT INTO Users (UserName, Password, UserType)
VALUES
    ('JohnDoe', 'password123', 'Client'),
    ('JaneSmith', 'securepwd', 'Employee'),
    ('BobJohnson', 'pass1234', 'Client'),
    ('AliceBrown', 'abc@123', 'Client'),
    ('CharlieDavis', 'qwerty', 'Employee'),
    ('EvaMiller', 'eva@456', 'Client'),
    ('FrankWhite', 'frank!789', 'Employee'),
    ('GraceTaylor', 'gracepass', 'Client'),
    ('HenryJones', 'henry321', 'Employee'),
    ('IvyClark', 'ivy@567', 'Client'),
    ('JackAnderson', 'jackpass', 'Client'),
    ('KatieMoore', 'katie!890', 'Employee'),
    ('LeoPerez', 'leo123', 'Client'),
    ('MiaTurner', 'mia@456', 'Employee'),
    ('NathanHall', 'nathanpass', 'Client'),
    ('OliviaSmith', 'olivia!123', 'Client'),
    ('PeterBrown', 'peter456', 'Employee'),
    ('QuincyTaylor', 'quincy@789', 'Client'),
    ('RachelClark', 'rachelpass', 'Employee'),
    ('SamuelJones', 'samuel321', 'Client'),
    ('TinaMiller', 'tina@567', 'Employee'),
    ('UlyssesTurner', 'ulyssespass', 'Client'),
    ('VictoriaAnderson', 'victoria!890', 'Employee'),
    ('WalterMoore', 'walter123', 'Client'),
    ('XenaPerez', 'xena@456', 'Employee'),
    ('YvonneHall', 'yvonnepass', 'Client'),
    ('ZackSmith', 'zack456', 'Employee'),
    ('JohnDoe', 'password1', 'Client'),
    ('JaneSmith', 'password2', 'Client'),
    ('BobJohnson', 'password3', 'Client'),
    ('EmilyBrown', 'password4', 'Client'),
    ('MikeMiller', 'password5', 'Client');

-- Insert data into Resources
INSERT INTO Resources (Title, Author, YearPublished, ResourceType, TotalCopies, AvailableCopies)
VALUES
    ('The Art of Programming', 'John Smith', 2020, 'Book', 10, 5),
    ('Science Today', 'Alice Johnson', 2019, 'Magazine', 20, 15),
    ('History Uncovered', 'Robert Brown', 2021, 'Book', 15, 10),
    ('Nature and Wildlife', 'Emily White', 2022, 'Book', 12, 8),
    ('Tech Trends', 'David Green', 2021, 'Magazine', 25, 20),
    ('Cooking Essentials', 'Emma Turner', 2020, 'Book', 8, 4),
    ('Health and Fitness', 'George Miller', 2022, 'Magazine', 18, 14),
    ('Travel Adventures', 'Olivia Davis', 2019, 'Book', 14, 10),
    ('Business Insights', 'Samuel Wilson', 2021, 'Magazine', 22, 18),
    ('Artistic Expressions', 'Sophia Perez', 2020, 'Book', 10, 6),
    ('Science Fiction Wonders', 'Michael Clark', 2022, 'Book', 15, 10),
    ('Technology Today', 'Isabella Smith', 2021, 'Magazine', 30, 25),
    ('Historical Journeys', 'Daniel White', 2018, 'Book', 20, 15),
    ('Healthy Living', 'Ava Turner', 2020, 'Magazine', 15, 12),
    ('Literary Masterpieces', 'William Davis', 2019, 'Book', 18, 12),
    ('Digital Design', 'Eva Miller', 2023, 'Book', 10, 8),
    ('Financial Strategies', 'Frank White', 2022, 'Magazine', 25, 20),
    ('Photography Tips', 'Grace Taylor', 2021, 'Book', 12, 10),
    ('Career Development', 'Henry Jones', 2020, 'Magazine', 18, 15),
    ('Gardening Guide', 'Ivy Clark', 2022, 'Book', 15, 12),
    ('Travel Photography', 'Jack Anderson', 2023, 'Magazine', 22, 18),
    ('Healthy Recipes', 'Katie Moore', 2021, 'Book', 10, 6),
    ('Mindfulness Techniques', 'Leo Perez', 2020, 'Magazine', 20, 15),
    ('Art of Negotiation', 'Mia Turner', 2019, 'Book', 15, 10),
    ('Space Exploration', 'Nathan Hall', 2022, 'Magazine', 28, 22),
    ('DIY Home Decor', 'Olivia Smith', 2023, 'Book', 12, 8),
    ('Effective Communication', 'Peter Brown', 2021, 'Magazine', 15, 12),
    ('Personal Finance', 'Quincy Taylor', 2020, 'Book', 18, 14),
    ('Leadership Skills', 'Rachel Clark', 2022, 'Magazine', 25, 20),
    ('Healthy Living Habits', 'Samuel Jones', 2019, 'Book', 20, 15),
    ('Time Management', 'Tina Miller', 2023, 'Magazine', 15, 12),
    ('Entrepreneurship', 'Ulysses Turner', 2021, 'Book', 10, 6),
    ('Environmental Sustainability', 'Victoria Anderson', 2020, 'Magazine', 18, 15),
    ('World History', 'Walter Moore', 2022, 'Book', 22, 18),
    ('Creative Writing', 'Xena Perez', 2023, 'Magazine', 12, 8),
    ('Mindful Parenting', 'Yvonne Hall', 2021, 'Book', 15, 10),
    ('Virtual Reality', 'Zack Smith', 2020, 'Magazine', 20, 15),
    ('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Book', 5, 5),
    ('To Kill a Mockingbird', 'Harper Lee', 1960, 'Book', 3, 3),
    ('The Catcher in the Rye', 'J.D. Salinger', 1951, 'Book', 4, 4),
    ('National Geographic', NULL, NULL, 'Magazine', 10, 10),
    ('Scientific American', NULL, NULL, 'Magazine', 8, 8);

-- Insert data into ResourceCopies
INSERT INTO ResourceCopies (ResourceID, Status, BorrowedByID)
VALUES
    (1, 'Available', NULL),
    (1, 'Available', NULL),
    (1, 'Borrowed', 1),
    (2, 'Available', NULL),
    (2, 'Borrowed', 2),
    (2, 'Available', NULL),
    (3, 'Available', NULL),
    (3, 'Borrowed', 3),
    (3, 'Available', NULL),
    (4, 'Borrowed', 4),
    (4, 'Available', NULL),
    (4, 'Available', NULL),
    (5, 'Available', NULL),
    (5, 'Borrowed', 5),
    (5, 'Borrowed', 1),
    (6, 'Available', NULL),
    (6, 'Available', NULL),
    (6, 'Borrowed', 2),
    (7, 'Borrowed', 3),
    (7, 'Available', NULL),
    (7, 'Available', NULL),
    (8, 'Available', NULL),
    (8, 'Borrowed', 4),
    (8, 'Available', NULL),
    (9, 'Borrowed', 5),
    (9, 'Available', NULL),
    (9, 'Available', NULL),
    (10, 'Borrowed', 1),
    (10, 'Available', NULL),
    (10, 'Borrowed', 2),
    (1, 'Available', NULL),
    (1, 'Borrowed', 1),
    (2, 'Available', NULL),
    (2, 'Borrowed', 2),
    (3, 'Available', NULL),
    (3, 'Borrowed', 3),
    (4, 'Available', NULL),
    (5, 'Available', NULL),
    (5, 'Borrowed', 4);

-- Insert data into BorrowRequests
INSERT INTO BorrowRequests (UserID, CopyID, RequestDate, DueDate, Status)
VALUES
    (1, 1, '2023-01-01', '2023-01-15', 'Pending'),
    (2, 3, '2023-02-05', '2023-02-20', 'Approved'),
    (3, 5, '2023-03-10', '2023-03-25', 'Returned'),
    (4, 7, '2023-04-15', '2023-04-30', 'Pending'),
    (5, 10, '2023-05-20', '2023-06-05', 'Approved'),
    (6, 12, '2023-07-01', '2023-07-15', 'Pending'),
    (7, 14, '2023-08-10', '2023-08-25', 'Approved'),
    (8, 16, '2023-09-15', '2023-09-30', 'Returned'),
    (9, 18, '2023-10-20', '2023-11-05', 'Pending'),
    (10, 20, '2023-12-01', '2023-12-15', 'Approved'),
    (11, 22, '2024-01-10', '2024-01-25', 'Pending'),
    (12, 24, '2024-02-15', '2024-02-28', 'Approved'),
    (13, 26, '2024-03-10', '2024-03-25', 'Pending'),
    (14, 28, '2024-04-15', '2024-04-30', 'Approved'),
    (15, 30, '2024-05-01', '2024-05-15', 'Pending'),
    (1, 1, '2023-01-01', '2023-01-15', 'Returned'),
    (2, 3, '2023-02-05', '2023-02-20', 'Returned'),
    (3, 5, '2023-03-10', '2023-03-25', 'Returned'),
    (4, 7, '2023-04-15', '2023-04-30', 'Borrowed'),
    (5, 10, '2023-05-20', '2023-06-05', 'Borrowed');
