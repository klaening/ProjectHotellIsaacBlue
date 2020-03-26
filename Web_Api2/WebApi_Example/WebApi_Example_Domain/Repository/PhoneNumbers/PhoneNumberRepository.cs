using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly string _connectionString;

        public PhoneNumberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<PhoneNumbers>> GetPhoneNumbers()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<PhoneNumbers>("SELECT * FROM PHONENUMBERS");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<PhoneNumbers> GetPhoneNumber(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<PhoneNumbers>("SELECT * FROM PHONENUMBERS WHERE ID = @id", new { id });
            }
        }

        public async Task<bool> AddPhoneNumber(PhoneNumbers phoneNumber)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    //await c.ExecuteAsync("INSERT INTO Customers (SOCNUMBER, FIRSTNAME, LASTNAME, EMAIL, STREETADDRESS, CITY, COUNTRY, ICE, CUSTOMERTYPESID) VALUES (@SocNumber, @FirstName, @LastName, @Email, @StreetAddress, @City, @Country, @ICE, @CustomerTypesID)", new { user.SOCNUMBER, user.FIRSTNAME, user.LASTNAME, user.EMAIL, user.STREETADDRESS, user.CITY, user.COUNTRY, user.ICE, user.CUSTOMERTYPESID });
                    await c.ExecuteAsync("INSERT INTO PHONENUMBERS (PHONENUMBER, CUSTOMERSID, PHONENUMBERTYPESID) VALUES (@PhoneNumber, @CustomersID, @PhoneNumberTypesID)", new { phoneNumber.PHONENUMBER, phoneNumber.CUSTOMERSID, phoneNumber.PHONENUMBERTYPESID });
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }

            }
        }
    }
}
