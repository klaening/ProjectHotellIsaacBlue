---------------------------------------------------------------------------------------------\
--FÖR ATT KUNNA KÖRA LOOPEN MÅSTE DESSA FUNCTIONS, VIEWS OCH STORED PROCEDURES FINNAS FÖRST--|
---------------------------------------------------------------------------------------------/


-------------------------------\
-----------FUNCTIONS-----------|
-------------------------------/

--VAR TVUNGEN ATT SKAPA EN FUNCTION ISTÄLLET FÖR EN VIEW EFTERSOM EN VIEW INTE KUNDE HANTERA PARAMETRAR
CREATE FUNCTION [dbo].[f_SHOWCUSTOMERSBOOKINGS] (@CUSTID INT)
RETURNS TABLE
AS
	RETURN
		SELECT * FROM BOOKINGS WHERE CUSTOMERSID=@CUSTID;