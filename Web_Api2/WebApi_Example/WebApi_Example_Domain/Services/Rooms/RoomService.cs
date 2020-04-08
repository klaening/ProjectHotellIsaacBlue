using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomService(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<Rooms> GetRoom(short id)
        {
            return await _roomRepository.GetRoom(id);
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
            return await _roomRepository.GetRooms();
        }

        public async Task<IEnumerable<Rooms>> GetRooms(string roomTypeName)
        {
            var roomType = await _roomTypeRepository.GetRoomType(roomTypeName);

            return await _roomRepository.GetRooms(roomType.ID);        
        }

        public async Task<IEnumerable<Rooms>> GetAvailableRooms(DateTime startDate, DateTime endDate, short roomType)
        {
            return await _roomRepository.GetAvailableRooms(startDate, endDate, roomType);
        }
    }
}
