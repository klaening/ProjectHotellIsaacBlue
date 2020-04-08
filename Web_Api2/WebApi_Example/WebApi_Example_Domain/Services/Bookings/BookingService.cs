using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Bookings>> GetBookings()
        {
            return await _bookingRepository.GetBookings();
        }

        public async Task<Bookings> GetBooking(int id)
        {
            return await _bookingRepository.GetBooking(id);
        }

        public async Task<bool> AddBooking(Bookings bookings, short roomID)
        {
            return await _bookingRepository.AddBooking(bookings, roomID);
        }

        public async Task<bool> UpdateBooking(Bookings bookings)
        {
            return await _bookingRepository.UpdateBooking(bookings);
        }

        public async Task<IEnumerable<Bookings>> GetCustomerBooking(long customerID)
        {
            return await _bookingRepository.GetCustomerBooking(customerID);
        }
    }
}
