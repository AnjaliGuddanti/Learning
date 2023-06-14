/*  Exercise2 */

---using join
SELECT P.FirstName + P.LastName AS 'Customers'
FROM Person.Person P
INNER JOIN Sales.Customer C 
ON P.BusinessEntityID = C.CustomerID
LEFT JOIN Sales.SalesOrderHeader S 
ON C.CustomerID = S.CustomerID
WHERE S.SalesOrderID IS NULL;

----using subquery
SELECT FirstName + LastName AS 'Customers'
FROM Person.Person
Where BusinessEntityID IN (SELECT CustomerID FROM Sales.Customer
							  WHERE CustomerID NOT IN  (SELECT CustomerID FROM Sales.SalesOrderHeader));

---using CTE
WITH UnorderProductCustomers (CustomerName)
AS (
	SELECT P.FirstName + P.LastName AS 'Customers'
	FROM Person.Person P 
	INNER JOIN Sales.Customer C
	ON P.BusinessEntityID = C.CustomerID 
	LEFT JOIN Sales.SalesOrderHeader S ON
	 C.CustomerID = S.CustomerID
	WHERE S.SalesOrderID IS NULL
   )
SELECT CustomerName FROM UnorderProductCustomers;


-----USING EXISTS
SELECT P.FirstName + P.LastName AS 'Customers'
FROM Person.Person P
WHERE EXISTS (SELECT C.CustomerID FROM Sales.Customer C
			  WHERE P.BusinessEntityID = C.CustomerID AND NOT EXISTS(SELECT S.CustomerID
			  FROM Sales.SalesOrderHeader S WHERE C.CustomerID = S.CustomerID));



