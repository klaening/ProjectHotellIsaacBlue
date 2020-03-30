using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
            return await _roomRepository.GetRooms();
        }

        public async Task<Rooms> GetRoom(int id)
        {
            return await _roomRepository.GetRoom(id);
        }
    }
}
