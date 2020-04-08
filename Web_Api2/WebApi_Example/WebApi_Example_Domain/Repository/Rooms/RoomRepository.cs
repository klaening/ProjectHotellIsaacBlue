using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly string _connectionString;

        public RoomRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<Rooms>("SELECT * FROM ROOMS");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<Rooms> GetRoom(short id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Rooms>("SELECT * FROM ROOMS WHERE ID = @id", new { id} );
            }
        }
        public async Task<IEnumerable<Rooms>> GetRooms(short id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryAsync<Rooms>("SELECT * FROM ROOMS WHERE ROOMTYPESID = @id", new { id });
            }
        }

        public async Task<IEnumerable<Rooms>> GetAvailableRooms(DateTime startDate, DateTime endDate, short roomType)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                //Bokningar som inte är mellan vissa datum och sen i bookingsrooms där rumstyp är av det valda rumstypen
                return await c.QueryAsync<Rooms>(@"SELECT R.ID, R.ROOMNUM, R.ROOMTYPESID FROM ROOMS R WHERE R.ID NOT IN
(
    SELECT BR.ROOMSID
    FROM BOOKINGSROOMS BR
    INNER JOIN BOOKINGS B ON BR.BOOKINGSID = B.ID
        WHERE
            (@startDate BETWEEN B.STARTDATE AND B.ENDDATE OR 
            @endDate BETWEEN B.STARTDATE AND B.ENDDATE OR
            @startDate <= B.STARTDATE AND @endDate >= B.ENDDATE)
)
AND R.ROOMTYPESID = @roomtype",
        new { startDate, endDate, roomType });
            }
        }
    }
}
