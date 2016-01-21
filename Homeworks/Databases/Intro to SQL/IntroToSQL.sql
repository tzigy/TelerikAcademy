## 03. Database Modelling
### _Homework_

--------------------------------------------------------------------------------------------------------------------------------------------
Task 1.	What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
	
	- Structured Query Language(SQL) is a programming language designed for managing data held in a relational database management system (RDBMS), 
		or for stream processing in a relational data stream management system (RDSMS). 
	- Data manipulation language(DML) is a family of syntax elements similar to a computer programming language used for selecting, inserting, 
		deleting and updating data in a database.
	- Data definition language(DDL) is a syntax similar to a computer programming language for defining data structures, especially database schemas.
	- SELECT, INSERT, DELETE, UPDATE, DROP...

--------------------------------------------------------------------------------------------------------------------------------------------
Task 2.	What is Transact-SQL (T-SQL)?

	- Transact-SQL(T-SQL) is Microsofts proprietary extension to SQL. It expands on the SQL standard to include procedural programming, local 
		variables, various support functions for string processing, date processing, mathematics, etc. and changes to the DELETE and UPDATE statements. These additional features make Transact-SQL Turing complete.

--------------------------------------------------------------------------------------------------------------------------------------------
Task 4.	Write a SQL query to find all information about all departments (use "TelerikAcademy" database).

	USE TelerikAcademy

	SELECT * 
	FROM [dbo].[Departments];

--------------------------------------------------------------------------------------------------------------------------------------------
Task 5.	Write a SQL query to find all department names.

	USE TelerikAcademy

	SELECT Name 
	FROM [dbo].[Departments];

--------------------------------------------------------------------------------------------------------------------------------------------
Task 6.	Write a SQL query to find the salary of each employee.

	USE TelerikAcademy

	SELECT FirstName + ' ' + LastName AS [FullName],  Salary 
	FROM [dbo].[Employees]

--------------------------------------------------------------------------------------------------------------------------------------------
Task 7.	Write a SQL to find the full name of each employee.
	
	USE TelerikAcademy

	SELECT FirstName + ' ' + LastName AS [FullName]
	FROM [dbo].[Employees]

--------------------------------------------------------------------------------------------------------------------------------------------
Task 8.	Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. 
		Emails should look like "John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
	
	USE TelerikAcademy

	SELECT FirstName + '.' + LastName + '@telerik.com'AS [Full Email Addresses]
	FROM [dbo].[Employees]


--------------------------------------------------------------------------------------------------------------------------------------------
Task 9.	Write a SQL query to find all different employee salaries.

	USE TelerikAcademy

	SELECT DISTINCT Salary
	FROM [dbo].[Employees]


--------------------------------------------------------------------------------------------------------------------------------------------
Task 10. Write a SQL query to find all information about the employees whose job title is "Sales Representative".

	USE TelerikAcademy

	SELECT *
	FROM [dbo].[Employees]
	WHERE JobTitle = 'Sales Representative'	

--------------------------------------------------------------------------------------------------------------------------------------------
Task 11. Write a SQL query to find the names of all employees whose first name starts with "SA".

	USE TelerikAcademy

	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM [dbo].[Employees]
	WHERE FirstName LIKE 'SA%'

--------------------------------------------------------------------------------------------------------------------------------------------
Task 12.	Write a SQL query to find the names of all employees whose last name contains "ei".

	USE TelerikAcademy

	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM [dbo].[Employees]
	WHERE LastName LIKE '%ei%'

--------------------------------------------------------------------------------------------------------------------------------------------
Task 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

	USE TelerikAcademy

	SELECT FirstName + ' ' + LastName AS [Full Name], Salary
	FROM [dbo].[Employees]
	WHERE Salary BETWEEN 20000 AND 30000

--------------------------------------------------------------------------------------------------------------------------------------------
Task 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

	USE TelerikAcademy

	SELECT FirstName + ' ' + LastName AS [Full Name], Salary
	FROM [dbo].[Employees]
	WHERE Salary IN (25000, 14000, 12500, 23600)

--------------------------------------------------------------------------------------------------------------------------------------------
Task 15. Write a SQL query to find all employees that do not have manager.

	USE TelerikAcademy

	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM [dbo].[Employees]
	WHERE ManagerID IS NULL

--------------------------------------------------------------------------------------------------------------------------------------------
Task 16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

	USE TelerikAcademy

	SELECT FirstName + ' ' + LastName AS [Full Name], Salary
	FROM [dbo].[Employees]
	WHERE Salary > 5000 
	ORDER BY Salary DESC

--------------------------------------------------------------------------------------------------------------------------------------------
Task 17. Write a SQL query to find the top 5 best paid employees.

	USE TelerikAcademy

	SELECT TOP 5 FirstName + ' ' + LastName AS [Full Name], Salary
	FROM [dbo].[Employees] 
	ORDER BY Salary DESC

--------------------------------------------------------------------------------------------------------------------------------------------
Task 18. Write a SQL query to find all employees along with their address. Use inner join with `ON` clause.

	USE TelerikAcademy

	SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText
	FROM [dbo].[Employees] e
	INNER JOIN [dbo].[Addresses] a
	ON e.AddressID = a.AddressID

--------------------------------------------------------------------------------------------------------------------------------------------
Task 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the `WHERE` clause).

	USE TelerikAcademy

	SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.AddressText
	FROM [dbo].[Employees] e, [dbo].[Addresses] a
	WHERE e.AddressID = a.AddressID

--------------------------------------------------------------------------------------------------------------------------------------------
Task 20. Write a SQL query to find all employees along with their manager.

	USE TelerikAcademy

	SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name], m.FirstName + ' ' + m.LastName AS [Manager Full Name]
	FROM [dbo].[Employees] e, [dbo].[Employees] m
	WHERE e.ManagerID = m.EmployeeID

--------------------------------------------------------------------------------------------------------------------------------------------
Task 21. Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: `Employees e`, `Employees m` and `Addresses a`.

	USE TelerikAcademy

	SELECT	e.FirstName + ' ' + e.LastName AS [Employee Full Name], 
		m.FirstName + ' ' + m.LastName AS [Manager Full Name], 
		a.AddressText
	FROM [dbo].[Employees] e 
	JOIN [dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID
	JOIN [dbo].[Addresses] a	 
		ON e.AddressID = a.AddressID

Another solution:

	SELECT  e.FirstName + ' ' + e.LastName AS [Employee Full Name], 
			m.FirstName + ' ' + m.LastName AS [Manager Full Name], 
			a.AddressText
	FROM [dbo].[Employees] e, [dbo].[Employees] m, [dbo].[Addresses] a
	WHERE e.ManagerID = m.EmployeeID AND e.AddressID = a.AddressID

--------------------------------------------------------------------------------------------------------------------------------------------
Task 22. Write a SQL query to find all departments and all town names as a single list. Use `UNION`.

	USE TelerikAcademy

	SELECT Name AS [Departments/Towns]
	FROM [dbo].[Departments]
	UNION
	SELECT Name AS [Departments/Towns]
	FROM [dbo].[Towns]

--------------------------------------------------------------------------------------------------------------------------------------------
Task 23. Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
		 Use right outer join. Rewrite the query to use left outer join.

	USE TelerikAcademy

	SELECT  ISNULL(e.FirstName + ' ' + e.LastName, ' - ') AS Employee,
			m.FirstName + ' ' + m.LastName AS Manager
	FROM [dbo].[Employees] e
	RIGHT JOIN [dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID

	-------------------------

	SELECT  e.FirstName + ' ' + e.LastName AS Employee,
			ISNULL(m.FirstName + ' ' + m.LastName, ' - ') AS Manager
	FROM [dbo].[Employees] e
	LEFT JOIN [dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID
--------------------------------------------------------------------------------------------------------------------------------------------
Task 24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

	USE TelerikAcademy

	SELECT e.FirstName + ' ' + e.LastName AS [Full Name], 		
			d.Name AS [Department Name]
	FROM [dbo].[Employees] e, [dbo].[Departments] d
	WHERE e.DepartmentID = d.DepartmentID AND 
		  d.Name IN ('Sales', 'Finance') AND 
		  e.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-12-31 00:00:00'

--------------------------------------------------------------------------------------------------------------------------------------------
