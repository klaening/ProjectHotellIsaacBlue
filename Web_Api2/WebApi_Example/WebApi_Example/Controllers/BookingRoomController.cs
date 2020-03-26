using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingRoomController : Controller
    {
        private readonly IBookingRoomService _bookingRoomService;

        public BookingRoomController(IBookingRoomService bookingRoomService)
        {
            _bookingRoomService = bookingRoomService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookingRoomService.GetBookingRooms());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _bookingRoomService.GetBookingRoom(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookingsRooms bookingsRooms)
        {
            return Ok(await _bookingRoomService.AddBookingRoom(bookingsRooms));
        }
    }
}
