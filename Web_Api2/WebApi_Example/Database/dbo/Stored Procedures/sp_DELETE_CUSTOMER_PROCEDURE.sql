------------------------------------------------------------\
------------------------------------------------------------/

--TAR SLUTLIGEN BORT KUNDEN
CREATE PROCEDURE [dbo].[sp_DELETE_CUSTOMER_PROCEDURE] @CUSTID INT
AS
	DELETE CUSTOMERS
	WHERE ID = @CUSTID