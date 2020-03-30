------------------------------------------------------------\
------------------------------------------------------------/

--TAR BORT KUNDENS TELEFONNUMMER
CREATE PROCEDURE [dbo].[sp_DELETE_PHONENUMBER_PROCEDURE] @CUSTID INT
AS
	DELETE PHONENUMBERS
	WHERE CUSTOMERSID = @CUSTID