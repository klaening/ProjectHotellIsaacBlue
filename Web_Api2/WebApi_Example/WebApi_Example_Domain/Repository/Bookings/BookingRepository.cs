using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly string _connectionString;

        public BookingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Bookings>> GetBookings()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<Bookings>("SELECT * FROM BOOKINGS");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<Bookings> GetBooking(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Bookings>("SELECT * FROM BOOKINGS WHERE ID = @id", new { id });
            }
        }

        public async Task<bool> AddBooking(Bookings bookings)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO BOOKINGS (QTYPERSONS, STARTDATE, ENDDATE, ETA, TIMEARRIVAL, TIMEDEPARTURE, SPECIALNEEDS" +
                        "EXTRABED, PARKING, BREAKFAST, CUSTOMERSID, STAFFID) VALUES (@qtypersons, @startdate, @enddate, @eta" +
                        "@timearrival, @timedeparture, @specialneeds, @extrabed, @parking, @breakfast, @customersid, @staffid)",
                        new { bookings.QTYPERSONS, bookings.STARTDATE, bookings.ENDDATE, bookings.ETA, bookings.TIMEARRIVAL, bookings.TIMEDEPARTURE,
                        bookings.SPECIALNEEDS, bookings.EXTRABED, bookings.PARKING, bookings.BREAKFAST, bookings.CUSTOMERSID, bookings.STAFFID});
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