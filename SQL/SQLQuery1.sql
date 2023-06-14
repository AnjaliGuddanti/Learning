
/*Exercise 3 */

SELECT TOP 5 SalesOrderID AS 'Order ID',
	   OrderDate AS 'Date Of Order',
	   AccountNumber AS 'Account Number',
	   SUM(TotalDue) AS 'Total Amount Spent'
FROM Sales.SalesOrderHeader
GROUP BY AccountNumber,
		 OrderDate,
		 SalesOrderID
Having SUM(TotalDue) > 70000
ORDER BY OrderDate DESC;



