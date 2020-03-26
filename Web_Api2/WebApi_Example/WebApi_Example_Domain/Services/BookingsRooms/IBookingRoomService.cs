using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IBookingRoomService
    {
        Task<bool> AddBookingRoom(BookingsRooms bookingsRooms);
        Task<IEnumerable<BookingsRooms>> GetBookingRooms();
        Task<BookingsRooms> GetBookingRoom(int id);
    }
}