using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("roomType/{roomTypeName}")]
        public async Task<IActionResult> Get(string roomTypeName)
        {
            return Ok(await _roomService.GetRooms(roomTypeName));
        }
    }
}
