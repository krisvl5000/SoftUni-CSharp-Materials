-- 01. One-To-One Relationship

CREATE DATABASE [EntityRelations]

GO 

CREATE TABLE [Passports]
(
	[PassportId] INT PRIMARY KEY IDENTITY(101, 1),
	[PassportNumber] VARCHAR(8) NOT NULL
)

CREATE TABLE [Persons]
(
	[PersonId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[Salary] DECIMAL(8, 2) NOT NULL,
	[PassportId] INT FOREIGN KEY REFERENCES [Passports]([PassportId]) UNIQUE NOT NULL
)

INSERT INTO [Passports]([PassportNumber])
VALUES
		('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')

INSERT INTO [Persons]([FirstName], [Salary], [PassportId])
VALUES
		('Roberto', 43300.00, 102),
		('Tom', 56100.00, 103),
		('Yana', 60200.00, 101)