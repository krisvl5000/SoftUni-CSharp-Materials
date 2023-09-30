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
    CHECK (DATALENGTH([Picture]) <= 2000000),
    [Height] DECIMAL(3, 2),
    [Weight] DECIMAL(5,2),
    [Gender] CHAR(1) NOT NULL,
    CHECK ([Gender] = 'm' OR [Gender] = 'f'),
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