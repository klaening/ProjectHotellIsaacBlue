using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypes>> GetRoomTypes();
        Task<RoomTypes> GetRoomType(short id);
        Task<RoomTypes> GetRoomType(string name);
    }
}
