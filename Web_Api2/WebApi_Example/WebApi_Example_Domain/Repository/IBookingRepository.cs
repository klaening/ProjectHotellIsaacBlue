using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface IBookingRepository
    {
        Task<bool> AddBooking(Bookings bookings);
        Task<IEnumerable<Bookings>> GetBookings();
        Task<Bookings> GetBooking(int id);
    }
}