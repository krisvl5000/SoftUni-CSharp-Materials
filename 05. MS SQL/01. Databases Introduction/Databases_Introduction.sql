-- 01. Create Database
CREATE DATABASE [Minions]

-- 02. Create Tables

CREATE TABLE [Minions] (
    [Id] INT PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [Age] INT NOT NULL
);

CREATE TABLE [Towns](
    [Id] INT PRIMARY KEY,
    [Name] NVARCHAR(70) NOT NULL
);

-- 03. Alter Minions Table

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

GO

-- 04. Insert Records in Both Tables

INSERT INTO [Towns] ([Id], [Name])
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId])
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

-- 05. Truncate Table Minions

TRUNCATE TABLE [Minions]

-- 06. Drop All Tables

DROP TABLE [Minions]

GO

DROP TABLE [Towns]

-- 07. Create Table People

CREATE TABLE [People](
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL,
    [Picture] VARBINARY(MAX),
    CHECK(DATALENGTH([Picture]) <= 2000000),
    [Height] DECIMAL(3, 2),
    [Weight] DECIMAL(5,2),
    [Gender] CHAR(1) NOT NULL,
    CHECK([Gender] = 'm' OR [Gender] = 'f'),
    [Birthdate] DATE NOT NULL,
    [Biography] NVARCHAR(MAX)
    )

	INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
    VALUES
    ('Pesho', 1.77, 75.2, 'm', '1998-05-25'),
	('Gosho', NULL, NULL, 'm', '1977-11-05'),
	('Maria', 1.65, 42.2, 'f', '1998-06-27'),
	('Viki', NULL, NULL, 'f', '1986-02-02'),
	('Vancho', 1.69, 77.8, 'm', '1999-03-03')

-- 08. Create Table Users

CREATE TABLE [Users] (
	[Id] BIGINT PRIMARY KEY IDENTITY(1, 1),
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK(DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME,
	[IsDeleted] VARCHAR(5) NOT NULL,
	CHECK(IsDeleted = 'true' OR IsDeleted = 'false')
	)

INSERT INTO [Users] ([Username], [Password], [LastLoginTime], [IsDeleted])
	VALUES
	('krisvl5000', 'stefanegei123', '2023-02-01', 'true'),
    ('stefanzcu', 'krisvlegei123', '2022-05-04', 'false'),
    ('peshotraktora', 'peshoegotin333', '2019-06-09', 'false'),
    ('petio', 'petiomama', '2023-05-06', 'true'),
    ('kakababa', 'mamabrato', '2020-06-08', 'false')

-- 09. Change Primary Key

ALTER TABLE [Users]
DROP PRIMARY KEY

ALTER TABLE [Users]
ADD CONSTRAINT PK_Combination
PRIMARY KEY([Id], [Username])

-- 10. Add Check Constraint

ALTER TABLE [Users]
ADD CHECK(LEN([Password]) >= 5)

-- 11. Set Default Value of a Field

ALTER TABLE [Users]
ADD CONSTRAINT df_LoginTime
DEFAULT GETDATE() FOR [LastLoginTime];

-- 12. Set Unique Field

ALTER TABLE [Users]
DROP CONSTRAINT PK_Combination

ALTER TABLE [Users]
ADD CONSTRAINT PK_Id
PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CHECK(LEN(Username) >= 3)

-- 13. Movies Database

CREATE DATABASE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR (150),
)

INSERT INTO [Directors] ([DirectorName], [Notes])
VALUES
	('Stephen Spielberg', 'Something'),
	('Ivan Stoyanov', 'Something else'),
	('Gosho Ivanov', NULL),
	('Petur Zahariev', 'Some notes'),
	('Evtim Petrov', NULL)


CREATE TABLE Genres(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[GenreName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(150),
)

INSERT INTO [Genres] ([GenreName], [Notes])
VALUES
	('Horror', 'Very scary'),
	('Comedy', 'Very funny'),
	('Thriller', 'Very tense'),
	('Action', 'Very fast-paced'),
	('Documentary', 'Very interesting')

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[CategoryName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(150),
)

INSERT INTO [Categories] ([CategoryName], [Notes])
VALUES
	('I dont know what is meant by category', 'Something'),
	('They didnt say what it is supposed to be', 'Something else'),
	('But whatever', NULL),
	('I will just write something', 'Some notes'),
	('So it isnt empty', NULL)

CREATE TABLE Movies(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY
	REFERENCES Directors(Id),
	[CopyrightYear] INT,
	[Length] INT
)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length])
VALUES
	('American Pie', 2, 1999, 110),
	('Scary Movie', 3, 2001, 120),
	('Die Hard', 1, 1998, 130),
	('Die Hard 3', 4, 2003, 100),
	('The Matrix', 5, 1999, 120)

-- 14. Car Rental Database

CREATE DATABASE CarRental

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(10, 2) NOT NULL,
	[WeeklyRate] DECIMAL(10, 2) NOT NULL,
	[MonthlyRate] DECIMAL(10, 2) NOT NULL,
	[WeekendRate] DECIMAL(10, 2) NOT NULL
)

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
    ('A', 1.00, 2.00, 3.00, 4.00),
    ('B', 1.00, 2.00, 3.00, 4.00),
    ('C', 1.00, 2.00, 3.00, 4.00)

CREATE TABLE Cars(
	[Id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[PlateNumber] NVARCHAR(50) NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear] DATE NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Doors] INT,
	[Picture] IMAGE,
	[Condition] NVARCHAR(50) NOT NULL,
	[Available] VARCHAR(50) NOT NULL
		CHECK([Available] = 'true' OR [Available] = 'false')
)

INSERT INTO [Cars]
    ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Condition], [Available])
VALUES
    ('123AAA', 'BMW', 'X6', '1993-04-01', 1, 'Used', 'true'),
    ('456BBB', 'Audi', 'RS7', '2000-05-06', 2, 'New', 'false'),
    ('789CCC', 'Mercedes', 'S350', '2012-01-04', 3, 'Broken', 'false')

CREATE TABLE Employees(
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title])
VALUES
    ('Nekoi', 'Si', 'CEO'),
    ('Nekoi', 'Drug', 'CTO'),
    ('Nekoi', 'Treti', 'MafiaBoss')

CREATE TABLE [Customers]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [DriverLicenseNumber] INT NOT NULL,
    [FullName] NVARCHAR(100) NOT NULL,
    [Address] NVARCHAR(250) NOT NULL,
    [City] NVARCHAR(100) NOT NULL,
    [ZIPCode] INT NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers] ([DriverLicenseNumber], [FullName], [Address], [City], [ZIPCode])
VALUES
    (123456789, 'Stefcho Popov', 'Ivan Vazov 21', 'Sofia', 1000),
    (987654321, 'Kris Velkov', 'Pangaris Boy 45', 'Budeshte', 1495),
    (767676767, 'Stefan Zhivkov', 'Preslav 5', 'Bojurishte', 4321)

CREATE TABLE [RentalOrders]
(
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
    [CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
    [CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
    [TankLevel] NVARCHAR(50) NOT NULL,
    [KilometrageStart] INT NOT NULL,
    [KilometrageEnd] INT NOT NULL,
    [TotalKilometrage] INT NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [TotalDays] INT NOT NULL,
    [RateApplied] DECIMAL(18, 2) NOT NULL,
    [TaxRate] DECIMAL(18, 2) NOT NULL,
    [OrderStatus] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus])
VALUES
    (1, 3, 2, 100, 190000, 190500, 500, '1994-01-01', '1994-01-21', 20, 50.0, 10.0, 'Pending'),
    (2, 1, 1, 90, 190000, 190500, 500, '1994-01-01', '1994-01-21', 20, 50.0, 10.0, 'Pending'),
    (3, 2, 3, 50, 20000, 25000, 5000, '2020-10-01', '2022-12-01', 100, 50.0, 10.0, 'Approved')

-- 16. Create SoftUni Database

CREATE DATABASE SoftUni

CREATE TABLE Towns(
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[AddressText] NVARCHAR(200) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE Departments(
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	[Id] INT IDENTITY(1, 1) PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MIddleName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[JobTitle] NVARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL,
	[HireDate] DATETIME2 NOT NULL,
	[Salary] DECIMAL(10, 2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)
