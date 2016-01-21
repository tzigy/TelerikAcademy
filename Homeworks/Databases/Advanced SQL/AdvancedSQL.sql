## 05. Advanced SQL
### _Homework_

-------------------------------------------------------------------------
Task 1.	Write a SQL query to find the names and salaries of the employees 
		that take the minimal salary in the company. 
		*Use a nested "SELECT" statement.

		SELECT FirstName, LastName, Salary
		FROM Employees
		WHERE Salary = 
			(SELECT MIN(Salary) FROM Employees)

-------------------------------------------------------------------------
Task 2.	Write a SQL query to find the names and salaries of the employees 
		that have a salary that is up to 10% higher than the minimal salary 
		for the company.

		DECLARE @MinSalary int = (SELECT MIN(Salary) FROM Employees)
		SELECT FirstName, LastName, Salary
		FROM Employees
		WHERE Salary BETWEEN @MinSalary AND 1.1 * @MinSalary
		ORDER BY Salary

-------------------------------------------------------------------------
Task 3.	Write a SQL query to find the full name, salary and department of 
		the employees that take the minimal salary in their department.
	*	Use a nested "SELECT" statement.

		SELECT e.FirstName + ' ' + e.LastName AS [Full Name], 
			   e.Salary, 
			   d.Name
		FROM Employees e 
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
		WHERE Salary =
			(SELECT MIN(Salary) FROM Employees emp
			WHERE emp.DepartmentID = d.DepartmentID)
		ORDER BY Salary

-------------------------------------------------------------------------
Task 4.	Write a SQL query to find the average salary in the department #1.

		SELECT ROUND(AVG(Salary), 2) AS [Average Salary]
		FROM Employees
		WHERE DepartmentID = 1

-------------------------------------------------------------------------
Task 5.	Write a SQL query to find the average salary  in the "Sales" department.

		SELECT ROUND(AVG(Salary), 2) AS [Average Salary]
		FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
		WHERE d.Name = 'Sales'

-------------------------------------------------------------------------
Task 6.	Write a SQL query to find the number of employees in the "Sales" department.

		SELECT COUNT(*) AS [Sales Employees Count]
		FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
		WHERE d.Name = 'Sales'

-------------------------------------------------------------------------
Task 7.	Write a SQL query to find the number of all employees that have manager.

		SELECT COUNT(ManagerID) AS [Number Of Employees With Manager]
		FROM Employees

-------------------------------------------------------------------------
Task 8.	Write a SQL query to find the number of all employees that have no manager.

		SELECT COUNT(*) AS [Number Of Managers]
		FROM Employees
		WHERE ManagerID IS NULL

-------------------------------------------------------------------------
Task 9.	Write a SQL query to find all departments and the average salary for each of them.

		SELECT ROUND(AVG(Salary), 2) AS [Average Salary], 
			   d.Name AS [Department]
		FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
		GROUP BY d.Name
		ORDER BY [Average Salary]

-------------------------------------------------------------------------
Task 10. Write a SQL query to find the count of all employees in each department 
		 and for each town.

		 SELECT COUNT(e.EmployeeID) AS [Employees Count], 
				t.Name AS [Town], 
				d.Name AS [Department]
		 FROM Employees e
		 JOIN Departments d
		 	ON e.DepartmentID = d.DepartmentID
		 JOIN Addresses a
		 	ON e.AddressID = a.AddressID
		 JOIN Towns t
		 	ON a.TownID = t.TownID
		 GROUP BY d.Name, t.Name
		 ORDER BY d.Name

-------------------------------------------------------------------------
Task 11. Write a SQL query to find all managers that have exactly 5 employees. 
		 Display their first name and last name.

		 SELECT e.FirstName + ' ' + e.LastName AS [Manager Full Name],
				COUNT(e.EmployeeID) AS [Number Of Employees]
		FROM Employees e
		JOIN Employees emp
			ON emp.ManagerID = e.EmployeeID
		GROUP BY e.EmployeeID, e.FirstName, e.LastName
		HAVING COUNT(e.EmployeeID) = 5

-------------------------------------------------------------------------
Task 12. Write a SQL query to find all employees along with their managers. 
		 For employees that do not have manager display the value "(no manager)".

		 SELECT e.FirstName + ' ' + e.LastName AS [Employee Full Name],
				COALESCE(emp.FirstName + ' '+ emp.LastName, 'no manager') AS [Manager Full Name]
		 FROM Employees e
		 LEFT JOIN Employees emp
			ON e.ManagerID = emp.EmployeeID

-------------------------------------------------------------------------
Task 13. Write a SQL query to find the names of all employees whose last name 
		 is exactly 5 characters long. Use the built-in `LEN(str)` function.

		SELECT LastName
		FROM Employees
		WHERE LEN(LastName) = 5

-------------------------------------------------------------------------
Task 14. Write a SQL query to display the current date and time in the following 
		 format "day.month.year hour:minutes:seconds:milliseconds".
		* Search in Google to find how to format dates in SQL Server.

		SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff')

-------------------------------------------------------------------------
Task 15. Write a SQL statement to create a table "Users". Users should have username,
		 password, full name and last login time.
		* Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
		* Define the primary key column as identity to facilitate inserting records.
		* Define unique constraint to avoid repeating usernames.
		* Define a check constraint to ensure the password is at least 5 characters long.

		CREATE TABLE Users (
		UserId int IDENTITY PRIMARY KEY,
		Username nvarchar(50) NOT NULL CHECK (LEN(Username) > 3) UNIQUE,
		Pass nvarchar(256) NOT NULL CHECK (LEN(Pass) > 5),
		FullName nvarchar(50) NOT NULL CHECK (LEN(FullName) > 5),
		LastLoginTime DATETIME NOT NULL,
		) 
		GO

-------------------------------------------------------------------------
Task 16. Write a SQL statement to create a view that displays the users from 
		 the "Users" table that have been in the system today.
		* Test if the view works correctly.

		CREATE VIEW [Logged Users Today] AS 
		SELECT Username FROM Users
		WHERE DATEDIFF(DAY, LastLoginTime, GETDATE()) = 0

-------------------------------------------------------------------------
Task 17. Write a SQL statement to create a table "Groups". Groups should have 
		 unique name (use unique constraint).
		* Define primary key and identity column.

		CREATE TABLE Groups(
		GroupId int IDENTITY PRIMARY KEY,
		Name nvarchar(50) NOT NULL UNIQUE
		)
		GO

-------------------------------------------------------------------------
Task 18. Write a SQL statement to add a column "GroupID" to the table "Users".
		* Fill some data in this new column and as well in the `Groups table.
		* Write a SQL statement to add a foreign key constraint between tables 
		  "Users" and "Groups" tables.

		ALTER TABLE Users
			ADD GroupID int NOT NULL
		GO

		ALTER TABLE Users
			ADD CONSTRAINT FK_Users_Groups
			FOREIGN KEY (GroupId)
			REFERENCES Groups(GroupId)
		GO

-------------------------------------------------------------------------
Task 19. Write SQL statements to insert several records in the "Users" and "Groups" tables.

		INSERT INTO Groups
		VALUES 
			('G #1'),
			('G #2'),
			('G #3'),
			('G #4'),
			('G #5')
		GO

		INSERT INTO Users
		VALUES 
			('i.ivanov', 'password1', 'Ivan Ivanov', GetDate(), 1),
			('s.stefan ', 'password2', 'Stefan Stefanov', GetDate(), 2),
			('g.georgiev', 'password3', 'Georgi Georgiev', GetDate(), 1)		
		GO

-------------------------------------------------------------------------
Task 20. Write SQL statements to update some of the records in the "Users" and "Groups" tables.

		UPDATE Users 
		SET [Pass] = 'password4'
		WHERE Username = 'i.ivanov'
		GO

-------------------------------------------------------------------------
Task 21. Write SQL statements to delete some of the records from the "Users" and "Groups" tables.

		DELETE Users 
		WHERE Username = 'g.georgiev'
		GO

-------------------------------------------------------------------------
Task 22. Write SQL statements to insert in the "Users" table the names of all employees from the "Employees" table.
		* Combine the first and last names as a full name.
		* For username use the first letter of the first name + the last name (in lowercase).
		* Use the same for the password, and "NULL" for last login time.

		INSERT INTO Users
		SELECT 
			LOWER(LEFT(FirstName, 3)) + '.' + LOWER(LastName) AS [Username],
			'password' + LastName AS [Pass],
			FirstName + ' ' + LastName AS [FullName],
			CONVERT(DATE, '01.03.2010') AS [LastLoginTime],
			1 AS [GroupID]
		FROM Employees	
		GO

-------------------------------------------------------------------------
1.	Write a SQL statement that changes the password to `NULL` for all users that have not been in the system since 10.03.2010.

-------------------------------------------------------------------------
1.	Write a SQL statement that deletes all users without passwords (`NULL` password).


-------------------------------------------------------------------------
1.	Write a SQL query to display the average employee salary by department and job title.

-------------------------------------------------------------------------
1.	Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

-------------------------------------------------------------------------
1.	Write a SQL query to display the town where maximal number of employees work.

-------------------------------------------------------------------------
1.	Write a SQL query to display the number of managers from each town.

-------------------------------------------------------------------------
1.	Write a SQL to create table `WorkHours` to store work reports for each employee (employee id, date, task, hours, comments).
	*	Do not forget to define  identity, primary key and appropriate foreign key. 
	*	Issue few SQL statements to insert, update and delete of some data in the table.
	*	Define a table "WorkHoursLogs" to track all changes in the "WorkHours" table with triggers.
		*	For each change keep the old record data, the new record data and the command (insert / update / delete).

-------------------------------------------------------------------------
1.	Start a database transaction, delete all employees from the "Sales" department along with all dependent records from the pother tables.
	*	At the end rollback the transaction.

-------------------------------------------------------------------------
1.	Start a database transaction and drop the table `EmployeesProjects`.
	*	Now how you could restore back the lost table data?

-------------------------------------------------------------------------
1.	Find how to use temporary tables in SQL Server.
	*	Using temporary tables backup all records from `EmployeesProjects` and restore them back after dropping and re-creating the table.
