/* Exercise 4*/
Go
CREATE FUNCTION Sales.uf_Function(@SalesOrderId int,@CurrencyCode nchar(3),@Date datetime)
RETURNS TABLE
AS
RETURN 
	SELECT od.ProductID AS 'Product ID',
		   od.OrderQty AS ' Order Quantity',
		   od.UnitPrice As 'Unit Price',
		   od.UnitPrice*cr.EndOfDayRate AS 'Target Price'
	FROM Sales.SalesOrderDetail AS od,Sales.CurrencyRate AS cr
	WHERE cr.ToCurrencyCode = @CurrencyCode AND
		  cr.ModifiedDate = @Date AND 
		  od.SalesOrderID = @SalesOrderID
Go


Select * from Sales.uf_Function(43662,'ARS','2005-07-01');
