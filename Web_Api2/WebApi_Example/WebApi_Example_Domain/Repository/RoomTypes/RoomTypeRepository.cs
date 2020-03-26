using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly string _connectionString;

        public RoomTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<RoomTypes>> GetRoomTypes()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<RoomTypes>("SELECT * FROM ROOMTYPES");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<RoomTypes> GetRoomType(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<RoomTypes>("SELECT * FROM ROOMTYPES WHERE ID = @id", new { id} );
            }
        }
    }
}
