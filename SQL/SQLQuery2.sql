/* Exercise 1*/
use [AdventureWorks2008R2]
go
/*  9  */
[dbo].[uspGetEmployeeManagers]48

/*  1  */
Select * from Sales.SalesPerson
Select COUNT(BusinessEntityID) as 'Number of Records' from  Sales.SalesPerson

/*  2  */
Select * from Person.Person
Select FirstName,LastName from Person.Person where FirstName Like 'B%'
Order By FirstName asc;

/*  3  */
SELECT P.FirstName,p.LastName FROM Person.Person AS P 
INNER JOIN HumanResources.Employee HE 
ON P.BusinessEntityID = HE.BusinessEntityID
WHERE HE.JobTitle = 'Design Engineer' OR
	  HE.JobTitle = 'Tool Designer' OR
	  He.JobTitle = 'Marketing Assistant';

/*  4  */
Select Color,Name,Weight from Production.Product where Weight is not null and Color is not null

/*  5  */
Select Description,Isnull(MaxQty,0.00) from Sales.SpecialOffer 

/*  6  */

SELECT AVG(AverageRate) AS 'Average exchange rate for the day'
FROM Sales.CurrencyRate
WHERE DATEPART(year,CurrencyRateDate)=2005 and FromCurrencyCode = 'USD' AND 
	  ToCurrencyCode = 'GBP';

/*  7  */
Select ROW_NUMBER()over (order by FirstName asc ) As RowNumber, FirstName,LastName 
from Person.Person Where FirstName like '%ss%'


/*  8  */
Select BusinessEntityID AS SalesPersonID,CommissionPct,
'CommissionBand' = Case when CommissionPct = 0 then 'band 0'
                        when CommissionPct>0 and CommissionPct<=0.01 then 'band 1'
						when CommissionPct>0.01 and CommissionPct<=0.015 then 'band 2'
                        when CommissionPct>0.015 then 'band 3'
						end
						from Sales.SalesPerson
						order by CommissionPct



/*  10  */
select ProductID,SafetyStockLevel
FROM Production.Product
WHERE SafetyStockLevel = (SELECT MAX(SafetyStockLevel)
						  FROM Production.Product);

