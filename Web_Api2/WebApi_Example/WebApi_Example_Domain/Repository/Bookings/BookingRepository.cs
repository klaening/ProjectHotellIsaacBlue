﻿using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
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

        public async Task<bool> AddBooking(Bookings bookings, short roomID)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    var syntax = new StringBuilder();

                    syntax.Append($"EXEC sp_BOOKINGS_INSERT ");
                    syntax.Append($"@CUSTOMERSID = {bookings.CUSTOMERSID}, ");
                    syntax.Append($"@QTYPERSONS = {bookings.QTYPERSONS}, ");
                    syntax.Append($"@STARTDATE = '{bookings.STARTDATE}', ");
                    syntax.Append($"@ENDDATE = '{bookings.ENDDATE}', ");

                    if (bookings.ETA != null)
                        syntax.Append($"@ETA = {bookings.ETA}");
                    else
                        syntax.Append("@ETA = NULL, ");

                    if (bookings.TIMEARRIVAL != null)
                        syntax.Append($"@TIMEARRIVAL = '{bookings.TIMEARRIVAL}', ");
                    else
                        syntax.Append("@TIMEARRIVAL = NULL, ");

                    if (bookings.SPECIALNEEDS != null)
                        syntax.Append($"@SPECIALNEEDS = '{bookings.SPECIALNEEDS}', ");
                    else
                        syntax.Append("@SPECIALNEEDS = NULL, ");

                    syntax.Append($"@EXTRABED = {bookings.EXTRABED}, ");
                    syntax.Append($"@PARKING = {bookings.PARKING}, ");
                    syntax.Append($"@BREAKFAST = {bookings.BREAKFAST}, ");

                    if (bookings.SPECIALNEEDS != null)
                        syntax.Append($"@STAFFID = {bookings.STAFFID}, ");
                    else
                        syntax.Append("@STAFFID = NULL, ");

                    syntax.Append($"@ROOMID = {roomID}");

                    await c.ExecuteAsync(syntax.ToString());
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