using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roomService.GetRooms());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(short id)
        {
            return Ok(await _roomService.GetRoom(id));
        }

        [HttpGet("roomtype/{roomTypeName}")]
        public async Task<IActionResult> Get(string roomTypeName)
        {
            return Ok(await _roomService.GetRooms(roomTypeName));
        }

        [HttpGet("roomtype/{roomType}/start={startDate}/end={endDate}")]
        public async Task<IActionResult> Get(DateTime startDate, DateTime endDate, short roomType)
        {
            return Ok(await _roomService.GetAvailableRooms(startDate, endDate, roomType));
        }
    }
}
