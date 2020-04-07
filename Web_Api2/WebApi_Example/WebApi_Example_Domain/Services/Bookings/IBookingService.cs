using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IBookingService
    {
        Task<bool> AddBooking(Bookings bookings, short roomID);
        Task<IEnumerable<Bookings>> GetBookings();
        Task<Bookings> GetBooking(int id);
        Task<bool> UpdateBooking(Bookings bookings);
    }
}
