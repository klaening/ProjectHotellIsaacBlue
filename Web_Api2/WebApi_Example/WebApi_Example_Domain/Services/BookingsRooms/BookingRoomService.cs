using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class BookingRoomService : IBookingRoomService
    {
        private readonly IBookingRoomRepository _bookingRoomRepository;

        public BookingRoomService(IBookingRoomRepository bookingRoomRepository)
        {
            _bookingRoomRepository = bookingRoomRepository;
        }

        public async Task<IEnumerable<BookingsRooms>> GetBookingRooms()
        {
            return await _bookingRoomRepository.GetBookingRooms();
        }

        public async Task<BookingsRooms> GetBookingRoom(int id)
        {
            return await _bookingRoomRepository.GetBookingRoom(id);
        }

        public async Task<bool> AddBookingRoom(BookingsRooms bookingRooms)
        {
            return await _bookingRoomRepository.AddBookingRoom(bookingRooms);
        }
    }
}
