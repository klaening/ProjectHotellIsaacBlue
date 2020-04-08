using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Rooms>> GetRooms();
        Task<Rooms> GetRoom(short id);
        Task<IEnumerable<Rooms>> GetRooms(short id);
        Task<IEnumerable<Rooms>> GetAvailableRooms(DateTime startDate, DateTime endDate, short roomType);
    }
}
