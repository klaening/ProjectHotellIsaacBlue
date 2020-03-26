﻿---------------------------------------------------------------------------------\
-------------NÄR DESSA ÄR UTFÖRDA KAN MAN ANVÄNDA SIG AV FÖLJANDE LOOP-----------|
---------------------------------------------------------------------------------/

--LOOPA IGENOM ALLA GAMLA KUNDERS BOKNINGAR OCH HÄMTA ID FÖR ATT SENARE KUNNA TA BORT KUNDERNA
CREATE PROCEDURE [dbo].[sp_PERMANENTLY_DELETE_OLD_CUSTOMERS_PROCEDURE] AS

	DECLARE @YEARS INT
	SET @YEARS = 10;

	DECLARE @CUSTID INT

	DECLARE CUSTIDCURSOR CURSOR
	FOR

		SELECT CUSTOMERSID
		FROM f_SHOWCUSTOMERSOLDERTHAN(@YEARS) SCOT
		ORDER BY SCOT.CUSTOMERSID

		OPEN CUSTIDCURSOR
			FETCH NEXT FROM CUSTIDCURSOR INTO @CUSTID

	WHILE @@FETCH_STATUS = 0
		BEGIN

------------------------------------------------------------------------------------------------------
		
			--KALLA PÅ EN PROCEDURE SOM TAR BORT ALLT SOM HAR MED BOOKINGS FÖR EN KUND ATT GÖRA FÖRST
			--SPn HITTAR KUNDENS ALLA BOKNINGSNUMMER FÖRST OCH SEN RADERAR ALLA BOKNINGAR GENOM EN LOOP
			EXEC sp_DELETE_CUSTOMERS_BOOKINGS @CUSTID
	
------------------------------------------------------------|

			--TAR BORT ALLT MED KUNDEN ATT GÖRA SEN
			EXEC sp_DELETE_PAYMENT_PROCEDURE @CUSTID
			EXEC sp_DELETE_PHONENUMBER_PROCEDURE @CUSTID
			EXEC sp_DELETE_CUSTOMER_PROCEDURE @CUSTID

------------------------------------------------------------------------------------------------------

			FETCH NEXT FROM CUSTIDCURSOR INTO @CUSTID
		END

	CLOSE CUSTIDCURSOR
		DEALLOCATE CUSTIDCURSOR