-----------Exercise 5 ------------------

GO
Alter  PROCEDURE Person.NameInfo
	@FirstName nvarchar(20) = 'Zoe'
AS
BEGIN
	SELECT BusinessEntityID AS 'ID',
		   FirstName + LastName AS 'NAME'
	FROM Person.Person
	WHERE FirstName = @FirstName
END

EXECUTE NameInfo
EXECUTE NameInfo @FirstName = 'Zachary'

GO

