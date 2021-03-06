﻿CREATE PROCEDURE [dbo].[sp_UPDATE_PAYMENTS_TOTAL_COST] @BOOKID INT, @CUSTID INT AS
	--GÖR EN UPDATE TABLE NÄR BOKNINGEN CHECKAS UT

	DECLARE @TOTCOST DECIMAL

	SELECT @TOTCOST = TOTALDAYS * ROOMCOST
	FROM v_SHOWPAYMENTINFO
	WHERE BOOKINGSID = @BOOKID

	--KOLLAR IFALL KUNDENS DISCOUNT ÄR NULL OCH HOPPAR ÖVER DETTA STEG ISF
	IF EXISTS(
		SELECT * 
		FROM v_SHOWPAYMENTINFO
		WHERE CUSTOMERSID=@CUSTID AND [DISCOUNTPERCENT] != 0)
			BEGIN
				DECLARE @TOTDISCOUNT DECIMAL

				SELECT @TOTDISCOUNT = TOTALDAYS * ROOMCOST * [DISCOUNTPERCENT] / 100
				FROM v_SHOWPAYMENTINFO
				WHERE BOOKINGSID = @BOOKID

				SET @TOTCOST = @TOTCOST - @TOTDISCOUNT
			END

	--KOLLAR IFALL KUNDEN BOKAT EXTRASÄNG, ISF LÄGGS 100 KR PÅ TOTALKOSTNADEN
	IF EXISTS(
		SELECT *
		FROM v_SHOWPAYMENTINFO
		WHERE EXTRABED != 0)
			BEGIN
				SET @TOTCOST = @TOTCOST + 100
			END

	UPDATE PAYMENTS
	SET TOTALCOST = @TOTCOST,
	[DISCOUNTMONEY] = @TOTDISCOUNT
	WHERE CUSTOMERSID = @CUSTID AND BOOKINGSID = @BOOKID