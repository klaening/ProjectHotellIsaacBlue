using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<Customers>("SELECT * FROM CUSTOMERS");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<Customers> GetCustomer(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Customers>("SELECT * FROM CUSTOMERS WHERE ID = @id", new { id} );
            }
        }

        public async Task<bool> AddCustomer(Customers customer, int accountID)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    customer.ID = await c.QueryFirstAsync<int>("INSERT INTO CUSTOMERS (SOCNUMBER, FIRSTNAME, LASTNAME, EMAIL, STREETADRESS, CITY, COUNTRY, ICE, CUSTOMERTYPESID) OUTPUT INSERTED.Id VALUES (@SocNumber, @FirstName, @LastName, @Email, @StreetAdress, @City, @Country, @ICE, @CustomerTypesID)", new { customer.SOCNUMBER, customer.FIRSTNAME, customer.LASTNAME, customer.EMAIL, customer.STREETADRESS, customer.CITY, customer.COUNTRY, customer.ICE, customer.CUSTOMERTYPESID });
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
