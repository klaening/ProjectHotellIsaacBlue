Nu ska vi se.

Skrev en liten snabb applikation, har inte testat denna men detta är ungefär hur det brukar se ut.

Om ni börjar att gå in i appsettings där har ni en "connectionstring" Ni kan lägga in eran som ni får från Azure i där.
När ni har gjort det så får ni skapa en Users table i databasen som har Id, FirstName, LastName och Email
Id ska vara primär nyckel och även auto increment.

Sen kan ni testa att köra api't

Som om ni lägger en breakpoint i varje funktion i UsersControler så kan ni sedan göra följande request:
GET: https://localhost:44341/api/users (Ni får alla användare)
GET: https://localhost:44341/api/users/1 (ni får användare med id: 1)
POST:  https://localhost:44341/api/users 
{
	"FirstName": "Daniel",
	"LastName": "Hosseini",
	"Email": "valid@valid.com"
	
}


Notera att porten är 44341 för mig. Men kanske är ngt annat för dig, så det är bara att ändra när du kör applikationen.
När du gör en GET kan du göra dessa direkt i browsern.
Jag rekommenderar att köra POSTMAN då du inte kan göra en post direkt i browsern utan att skriva lite kod
Så du kan köra POSTMAN med alla url'er ovan.

Hoppas detta hjäper något.

Fråga gärna om du har fler frågor.

Vill ni ha mer hjälp så får ni gärna posta azure connection strängen så kan jag hooka upp den.



[Hur man anropar en Stored Procedure via Dapper]

[Stored Procedure]
CREATE PROCEDURE [dbo].[GetUser]
    @vcnId nvarchar(50)
AS
  SELECT VcnId, Firstname, Lastname, Email FROM [User]
  WHERE VcnId = @vcnId


[Hur man anropar via Dapper]
						[Stored Procedure]    [id]		[Default är vanlig SQL command. Här specar vi stored procedure]
var result = await c.QueryFirstOrDefaultAsync<User>("GetUser", new { vcnId }, commandType: CommandType.StoredProcedure);
