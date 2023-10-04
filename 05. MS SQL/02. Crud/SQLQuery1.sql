-- 02. Find All Infromation About Departments

SELECT * FROM [Departments]

-- 03. Find all Department Names

SELECT [Name]
  FROM [Departments]

-- 04. Find Salary of Each Employee

SELECT [FirstName], [LastName], [Salary]
  From [Employees]

-- 05. Find Full Name of Each Employee

SELECT [FirstName], [MiddleName], [LastName]
  From [Employees]

-- 06. Find Email Address of Each Employee

SELECT CONCAT([FirstName], '.', [LastName], '@', 'softuni.bg')
	       AS [Full Email Address]
         FROM [Employees]

--  07. Find All Different Employee’s Salaries

SELECT DISTINCT [Salary]
           FROM [Employees]

-- 08. Find all Information About Employees

SELECT * FROM [Employees]
        WHERE [JobTitle] = 'Sales Representative'

-- 09. Find Names of All Employees by Salary in Range

SELECT [FirstName], [LastName], [JobTitle]
  FROM [Employees]
 WHERE [Salary] BETWEEN 20000 AND 30000

-- 10. Find Names of All Employees

SELECT CONCAT_WS(' ', [FirstName], [MiddleName], [LastName])
           AS [Full Name]
	     FROM [Employees]
        WHERE [Salary] IN (25000, 14000, 12500, 23600)