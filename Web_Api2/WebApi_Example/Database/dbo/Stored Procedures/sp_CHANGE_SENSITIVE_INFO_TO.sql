﻿--EN PROCEDURE SOM TAR BORT KÄNSLIG IDENTIFIERANDE INFORMATION MEN SPARAR ANNAN INFORMATION
CREATE PROCEDURE [dbo].[sp_CHANGE_SENSITIVE_INFO_TO] @NEWINFO VARCHAR(MAX), @CUSTID INT AS
	
	UPDATE CUSTOMERS
	SET FIRSTNAME = @NEWINFO, LASTNAME = @NEWINFO, EMAIL = @NEWINFO, STREETADRESS = @NEWINFO, ICE = @NEWINFO
	WHERE ID = @CUSTID

	UPDATE PHONENUMBERS
	SET PHONENUMBER = @NEWINFO
	WHERE CUSTOMERSID = @CUSTID