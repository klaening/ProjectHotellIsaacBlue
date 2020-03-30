------------------------------------------------------------\
------------------------------------------------------------/

--TAR BORT KUNDENS BOKNINGAR
CREATE PROCEDURE [dbo].[sp_DELETE_BOOKINGS_PROCEDURE] @BOOKID INT
AS
	DELETE BOOKINGS
	WHERE ID = @BOOKID