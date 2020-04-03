using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;
using System.Web;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookingService.GetBookings());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _bookingService.GetBooking(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Bookings bookings)
        {
            return Ok(await _bookingService.AddBooking(bookings));
        }

        //[HttpPost("{id}")]
        //public async Task<IActionResult> UpdateBooking([FromBody] int id)
        //{
        //    return Ok(await _bookingService.UpdateBooking(id));
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking([FromBody] int id)
        {
            return Ok(await _bookingService.UpdateBooking(id));
        }
    }
}
