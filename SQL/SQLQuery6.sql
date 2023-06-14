GO
CREATE TRIGGER Production.UpdateTrigger
ON Production.Product
INSTEAD OF UPDATE
AS
BEGIN
	IF UPDATE(ListPrice)						
	DECLARE @OldListPrice money
	DECLARE @InsertedListPrice money
	DECLARE @ID int
	SELECT @OldListPrice = p.ListPrice,
		   @InsertedListPrice=inserted.ListPrice,
		   @ID = inserted.ProductID
	FROM Production.Product p, inserted
	WHERE p.ProductID = inserted.ProductID;

	IF( @InsertedListPrice > ( @OldListPrice + (0.15*@OldListPrice) ) ) 
	BEGIN
		RAISERROR('LIST PRICE MORE THAN 15 PERCENT, TRANSACTION FAILED',16,0)
		ROLLBACK TRANSACTION
	END
	ELSE
	BEGIN
		Update Production.Product SET ListPrice=@InsertedListPrice 
		WHERE Production.Product.ProductID = @ID;
	END
	
END;
SELECT Production.Product.ProductID,
	   Production.Product.ListPrice
FROM Production.Product;

UPDATE Production.Product  SET ListPrice=15  WHERE Product.ProductID=518;