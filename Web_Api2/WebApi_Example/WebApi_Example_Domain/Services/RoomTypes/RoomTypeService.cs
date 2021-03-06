﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<IEnumerable<RoomTypes>> GetRoomTypes()
        {
            return await _roomTypeRepository.GetRoomTypes();
        }

        public async Task<RoomTypes> GetRoomType(short id)
        {
            return await _roomTypeRepository.GetRoomType(id);
        }
        public async Task<RoomTypes> GetRoomType(string name)
        {
            return await _roomTypeRepository.GetRoomType(name);
        }
    }
}
