using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Rooms>> GetRooms();
        Task<Rooms> GetRoom(short id);
        Task<IEnumerable<Rooms>> GetRooms(string roomTypeName);
    }
}
