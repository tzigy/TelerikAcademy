--06. Transact SQL Homework
--
--Task 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--		  Insert few records for testing.
--		  Write a stored procedure that selects the full names of all persons.

USE master

CREATE DATABASE Bank
GO

USE Bank

CREATE TABLE Persons(
	Id INT IDENTITY NOT NULL PRIMARY KEY, 
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	SSN NVARCHAR(10) NOT NULL)

	 
CREATE TABLE Accounts(
	Id INT IDENTITY NOT NULL PRIMARY KEY,		
	PersonId INT NOT NULL FOREIGN KEY REFERENCES Persons(Id), 
	Balance MONEY NOT NULL)


INSERT INTO Persons (FirstName, LastName, SSN) 
VALUES 
	('Ivan', 'Ivanov', '1234567891'),
	('Petar', 'Petrov', '1234567892'),
	('Georgi', 'Georgiev', '1234567893')
GO

INSERT INTO Accounts (PersonId, Balance)
VALUES
	(1, 1258.54),
	(2, 10259.00),
	(3, 359.48)
GO

--Write a stored procedure that selects the full names of all persons.
USE Bank
GO

CREATE PROCEDURE dbo.usp_SelectAllPersonsFullName
AS
	(SELECT CONCAT(FirstName, ' ', LastName) AS [FullName]
	 FROM Persons)
GO

EXEC usp_SelectAllPersonsFullName


--Task 2. Create a stored procedure that accepts a number as a parameter and returns all persons 
-- 		  who have more money in their accounts than the supplied number.

	USE Bank
	GO

	CREATE PROC usp_SelectAllWithAmountBiggerThan(
		@minAmount MONEY)
	AS
		SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [FullName]
		FROM Persons p, Accounts a
		WHERE a.Balance > @minAmount AND a.PersonId = p.Id
	GO 

	EXEC usp_SelectAllWithAmountBiggerThan 100

	EXEC usp_SelectAllWithAmountBiggerThan 2000

-- Task 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--		    * It should calculate and return the new sum.
--			* Write a SELECT to test whether the function works as expected.

	USE Bank
	GO

	CREATE FUNCTION ufn_CalculateSumPlusInterest(
			@startSum MONEY, 
			@yearlyInterestRate FLOAT, 
			@numberOfMonths INT)
		RETURNS MONEY
	AS
		BEGIN
			RETURN (@startSum + ((@startSum * (@yearlyInterestRate/12/100)) * @numberOfMonths))
		END
	GO

	SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [FullName],
		   a.Balance AS [BalanceWithoutInterest],
		   dbo.ufn_CalculateSumPlusInterest(a.Balance, 10, 12) AS [BalanceWithInterest]
	FROM Accounts a, Persons p
	WHERE a.PersonId = p.Id
	GO

-- Task4. Create a stored procedure that uses the function from the previous example to give an interest
--		  to a persons account for one month.
--		  * It should take the AccountId and the interest rate as parameters.

	USE Bank
	GO

	CREATE PROC usp_ShowInterestForOneMonth(
		@accountID INT, 
		@interestRate FLOAT)
	AS
		SELECT  CONCAT(p.FirstName, ' ', p.LastName) AS [FullName],
				dbo.ufn_CalculateSumPlusInterest(a.Balance, @interestRate, 1) - a.Balance AS [Interest/Month]
		FROM Accounts a, Persons p
		WHERE a.Id = @accountID AND a.PersonId = p.Id
	GO

	EXEC usp_ShowInterestForOneMonth 1, 10

--Task 5. Add two more stored procedures WithdrawMoney(AccountId, money) and 
--		  DepositMoney(AccountId, money) that operate in transactions.
	USE Bank
	GO

	CREATE PROC usp_WithdrawMoney(
		@accountId INT, 
		@withrawAmount MONEY)
	AS 
		DECLARE @currentBalance MONEY
		SET @currentBalance = 
			(SELECT Balance
			 FROM Accounts
			 WHERE Id = @accountId)
		DECLARE @newBalance MONEY
			SET @newBalance = @currentBalance - @withrawAmount
		UPDATE Accounts
		SET Balance = @newBalance
		WHERE Id = @accountID
	GO

	EXEC usp_WithdrawMoney 1, 100

-----------------------------------------------------------------
	USE Bank
	GO
		CREATE PROC usp_DepositMoney(
		@accountId INT, 
		@depositAmount MONEY)
	AS 		
		UPDATE Accounts
		SET Balance += @depositAmount
		WHERE Id = @accountID
	GO

	EXEC usp_DepositMoney 1, 100


-- Task 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--		  Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

	USE Bank
	GO

	CREATE TABLE Logs(
		LogID int IDENTITY NOT NULL PRIMARY KEY, 
		AccountID INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id), 
		OldSum MONEY, 
		NewSum MONEY)
	GO

	USE Bank
	GO

	CREATE TRIGGER tr_LogTransaction 
		ON Accounts 
		FOR UPDATE
	AS	
		INSERT INTO Logs (AccountID, OldSum, NewSum)	
			(SELECT i.Id, d.Balance, i.Balance
			 FROM INSERTED i, DELETED d)
	GO

--Task 7. Define a function in the database TelerikAcademy that returns all Employee's 
-- 		  names (first or middle or last name) and all town's names that are comprised of given set of letters.
--		  Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

	USE TelerikAcademy
	GO
	
	CREATE FUNCTION ufn_CheckName(
			@nameToCheck NVARCHAR(50), 
			@letters NVARCHAR(50))
		RETURNS INT
	AS
		BEGIN
	        DECLARE @i INT = 1
			DECLARE @currentChar NVARCHAR(1)
	        WHILE (@i <= LEN(@nameToCheck))
				BEGIN
					SET @currentChar = SUBSTRING(@nameToCheck,@i, 1)
						IF (CHARINDEX(LOWER(@currentChar),LOWER(@letters)) <= 0) 
							BEGIN  
								RETURN 0
							END
					SET @i = @i + 1
				END
	        RETURN 1
	END
	GO
	
	CREATE FUNCTION dbo.ufn_AllEmploeeysAndTownByStringPattern(@format nvarchar(50))
	RETURNS @table TABLE
		([Name] nvarchar(50) NOT NULL)
	AS
	BEGIN
		INSERT @table
		SELECT newTbl.LastName FROM
			(SELECT LastName FROM Employees
			UNION
			SELECT Name FROM Towns) as newTbl
			WHERE dbo.ufn_CheckName(newTbl.LastName, @format) > 0
		 RETURN
	END
	GO
	
	SELECT * FROM ufn_AllEmploeeysAndTownByStringPattern('oiseltmiahf')
	
	
--Task 8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints 
--		  all pairs of employees that live in the same town.

	DECLARE empCursor CURSOR READ_ONLY FOR
	  SELECT e.FirstName, e.LastName, t.Name 
	  FROM Employees e
	  JOIN Addresses a
		ON e.AddressID = a.AddressID
	  JOIN Towns t
		ON a.TownID = t.TownID
	
	OPEN empCursor
	DECLARE @firstName NVARCHAR(50), @lastName NVARCHAR(50), @town NVARCHAR(50)
	FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town
	
	WHILE @@FETCH_STATUS = 0
	  BEGIN
	  		DECLARE empCursor1 CURSOR READ_ONLY FOR
			SELECT e.FirstName, e.LastName, t.Name FROM Employees e
			JOIN Addresses a
			  ON e.AddressID = a.AddressID
			JOIN Towns t
			 ON a.TownID = t.TownID
	
			OPEN empCursor1
			DECLARE @firstName1 nvarchar(50), @lastName1 nvarchar(50), @town1 nvarchar(50)
			FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1
	
			WHILE @@FETCH_STATUS = 0
			  BEGIN
			  IF(@town=@town1 AND @firstName != @firstName1 AND @lastName != @lastName1)
				  BEGIN
					PRINT @town+':'+ @firstName + ' ' + @lastName + ':' + @firstName1 + ' ' + @lastName1 
				  END
				FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1
			  END
	
			CLOSE empCursor1
			DEALLOCATE empCursor1
	
	    FETCH NEXT FROM empCursor  INTO @firstName, @lastName, @town
	  END
	
	CLOSE empCursor
	DEALLOCATE empCursor