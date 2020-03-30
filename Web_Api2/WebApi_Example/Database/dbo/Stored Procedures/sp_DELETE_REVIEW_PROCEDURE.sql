---------------------------------------\
-----------STORED PROCEDURES-----------|
---------------------------------------/

--TAR BORT KUNDENS REVIEWS
CREATE PROCEDURE [dbo].[sp_DELETE_REVIEW_PROCEDURE] @BOOKID INT
AS
	DELETE REVIEWS
	WHERE BOOKINGSID = @BOOKID