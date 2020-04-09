using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class BookingRoomRepository : IBookingRoomRepository
    {
        private readonly string _connectionString;

        public BookingRoomRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<BookingsRooms>> GetBookingRooms()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<BookingsRooms>("SELECT * FROM BOOKINGSROOMS");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<BookingsRooms> GetBookingRoom(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<BookingsRooms>("SELECT * FROM BOOKINGSROOMS WHERE ID = @id", new { id });
            }
        }

        public async Task<IEnumerable<BookingsRooms>> GetRoomID(long bookingID)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryAsync<BookingsRooms>("SELECT * FROM BOOKINGSROOMS WHERE BOOKINGSID = @bookingID", new { bookingID });
            }
        }

        public async Task<bool> AddBookingRoom(BookingsRooms bookingsRooms)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO BOOKINGSROOMS (BOOKINGSID, ROOMSID) VALUES (@id, @roomsid)",
                        new
                        {
                            bookingsRooms.BOOKINGSID, bookingsRooms.ROOMSID
                          
                        });
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