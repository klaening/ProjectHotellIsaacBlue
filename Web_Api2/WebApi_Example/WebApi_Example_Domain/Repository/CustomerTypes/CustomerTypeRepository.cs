using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class CustomerTypeRepository : ICustomerTypeRepository
    {
        private readonly string _connectionString;

        public CustomerTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<CustomerTypes>> GetCustomerTypes()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<CustomerTypes>("SELECT * FROM CUSTOMERTYPES");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<CustomerTypes> GetCustomerType(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<CustomerTypes>("SELECT * FROM CUSTOMERTYPES WHERE ID = @id", new { id });
            }
        }
    }
}
