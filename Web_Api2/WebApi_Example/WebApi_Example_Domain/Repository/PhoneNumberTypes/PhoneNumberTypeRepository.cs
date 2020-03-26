using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class PhoneNumberTypeRepository : IPhoneNumberTypeRepository
    {
        private readonly string _connectionString;

        public PhoneNumberTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<PhoneNumberTypes>> GetPhoneNumberTypes()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<PhoneNumberTypes>("SELECT * FROM PHONENUMBERTYPES");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<PhoneNumberTypes> GetPhoneNumberType(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<PhoneNumberTypes>("SELECT * FROM PHONENUMBERTYPES WHERE ID = @id", new { id} );
            }
        }
    }
}
