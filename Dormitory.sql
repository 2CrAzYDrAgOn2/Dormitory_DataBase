CREATE DATABASE Dormitory
USE Dormitory

CREATE TABLE Faculties (
    FacultyID INT PRIMARY KEY IDENTITY(1,1),
    FacultyName VARCHAR(50)
);

CREATE TABLE Groups (
    GroupID INT PRIMARY KEY IDENTITY(1,1),
    GroupName VARCHAR(10)
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(255) NOT NULL,
    GroupID INT,
    FacultyID INT,
    PassportNumber VARCHAR(10),
    FOREIGN KEY (GroupID) REFERENCES Groups (GroupID),
    FOREIGN KEY (FacultyID) REFERENCES Faculties (FacultyID)
);

CREATE TABLE HousingOrders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    OrderNumber VARCHAR(20),
    FacultyID INT,
    StudentID INT,
    FOREIGN KEY (FacultyID) REFERENCES Faculties (FacultyID),
    FOREIGN KEY (StudentID) REFERENCES Students (StudentID)
);

CREATE TABLE HousingPayments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    PaymentDate DATE,
    PaidAmount INT,
    StudentID INT,
    FOREIGN KEY (StudentID) REFERENCES Students (StudentID)
);

CREATE TABLE Dormitories (
    DormitoryID INT PRIMARY KEY IDENTITY(1,1),
    DormitoryName VARCHAR(50)
);

CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber VARCHAR(10),
    Capacity INT,
    NumberOfCabinets INT,
    NumberOfChairs INT,
    AdditionalInfo VARCHAR(255),
    DormitoryID INT,
    FOREIGN KEY (DormitoryID) REFERENCES Dormitories (DormitoryID)
);

CREATE TABLE RoomAssignment (
    RoomAssignmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT,
    RoomID INT,
    FOREIGN KEY (StudentID) REFERENCES Students (StudentID),
    FOREIGN KEY (RoomID) REFERENCES Rooms (RoomID)
);

CREATE TABLE Registration (
	UserID INT PRIMARY KEY IDENTITY(1,1),
	UserLogin VARCHAR(50),
	UserPassword VARCHAR(50)
);

INSERT INTO Faculties (FacultyName)
VALUES
    ('Факультет 1'),
    ('Факультет 2'),
    ('Факультет 3');

INSERT INTO Groups (GroupName)
VALUES
    ('Группа 101'),
    ('Группа 102'),
    ('Группа 103');

INSERT INTO Students (FullName, GroupID, FacultyID, PassportNumber)
VALUES
    ('Иванов Иван Иванович', 1, 1, '1719123978'),
    ('Петров Петр Петрович', 2, 1, '1719312756'),
    ('Сидоров Алексей Васильевич', 3, 2, '1719195357');

INSERT INTO HousingOrders (OrderNumber, FacultyID, StudentID)
VALUES
    ('Заявка 1', 1, 1),
    ('Заявка 2', 1, 2),
    ('Заявка 3', 2, 3);

INSERT INTO HousingPayments (PaymentDate, PaidAmount, StudentID)
VALUES
    ('2023-10-01', 5000, 1),
    ('2023-10-02', 6000, 2),
    ('2023-10-03', 7000, 3);

INSERT INTO Dormitories (DormitoryName)
VALUES
    ('Общежитие 1'),
    ('Общежитие 2');

INSERT INTO Rooms (RoomNumber, Capacity, NumberOfCabinets, NumberOfChairs, AdditionalInfo, DormitoryID)
VALUES
    ('101', 2, 1, 2, 'С двумя кроватями и одним столом', 1),
    ('102', 3, 1, 3, 'С тремя кроватями и одним столом', 1),
    ('201', 2, 1, 2, 'С двумя кроватями и одним столом', 2);

INSERT INTO RoomAssignment (StudentID, RoomID)
VALUES
    (1, 1),
    (2, 2),
    (3, 3);

INSERT INTO Registration (UserLogin, UserPassword)
VALUES
	('admin', 'admin');

SELECT * FROM Faculties;
SELECT * FROM Groups;
SELECT * FROM Students;
SELECT * FROM HousingOrders;
SELECT * FROM HousingPayments;
SELECT * FROM Dormitories;
SELECT * FROM Rooms;
SELECT * FROM RoomAssignment;
SELECT * FROM Registration;
