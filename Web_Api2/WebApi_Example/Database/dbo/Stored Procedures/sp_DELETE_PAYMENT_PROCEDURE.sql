------------------------------------------------------------\
------------------------------------------------------------/

--TAR BORT KUNDENS PAYMENTS
CREATE PROCEDURE [dbo].[sp_DELETE_PAYMENT_PROCEDURE] @CUSTID INT
AS
	DELETE PAYMENTS
	WHERE CUSTOMERSID = @CUSTID