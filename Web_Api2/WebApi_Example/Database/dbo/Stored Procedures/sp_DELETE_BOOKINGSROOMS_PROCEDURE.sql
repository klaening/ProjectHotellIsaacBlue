------------------------------------------------------------\
------------------------------------------------------------/

--TAR BORT BOOKINGSROOMS FÖR VARJE BOKNING
CREATE PROCEDURE [dbo].[sp_DELETE_BOOKINGSROOMS_PROCEDURE] @BOOKID INT
AS
	DELETE BOOKINGSROOMS
	WHERE BOOKINGSID = @BOOKID