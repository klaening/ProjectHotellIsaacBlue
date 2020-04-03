using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomTypes>> GetRoomTypes();
        Task<RoomTypes> GetRoomType(int id);
        Task<RoomTypes> GetRoomType(string name);
    }
}
