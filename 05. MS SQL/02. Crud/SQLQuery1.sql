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
