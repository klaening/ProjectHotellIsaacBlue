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

        public async Task<bool> AddBooking(Bookings bookings, int roomID)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("EXEC sp_BOOKINGS_INSERT @CUSTOMERSID = @customersID, @QTYPERSONS = @qtyPersons, @STARTDATE = @startDate, " +
                        "@ENDDATE = @endDate, @ETA = @eta, @TIMEARRIVAL = @timeArrival, @SPECIALNEEDS = @specialNeeds, @EXTRABED = @extraBed, @PARKING = " +
                        "@parking, @BREAKFAST = @breakfast, @STAFFID = @staffID, @ROOMID = @roomID", new {
    bookings.QTYPERSONS,
    bookings.STARTDATE,
    bookings.ENDDATE,
    bookings.ETA,
    bookings.TIMEARRIVAL,
    bookings.TIMEDEPARTURE,
    bookings.SPECIALNEEDS, 
    bookings.EXTRABED, 
    bookings.PARKING, 
    bookings.BREAKFAST, 
    bookings.CUSTOMERSID, 
    bookings.STAFFID,
    roomID });
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }

            }
        }

        public async Task<bool> UpdateBooking(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("UPDATE BOOKINGS SET BREAKFAST = 0 WHERE ID = @id", new { id });
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