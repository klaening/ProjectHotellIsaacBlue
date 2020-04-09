using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;
using System.Web;
using System;

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

        [HttpGet("customer/{customerID}")]
        public async Task<IActionResult> Get(long customerID)
        {
            return Ok(await _bookingService.GetCustomerBookings(customerID));
        }

        [HttpGet("customer/{customerID}/end={dateToday}")]
        public async Task<IActionResult> Get(long customerID, DateTime dateToday)
        {
            return Ok(await _bookingService.GetCustomerBookings(customerID, dateToday));
        }

        [HttpGet("{id}/customer/{customerID}/")]
        public async Task<IActionResult> Get(long id, long customerID)
        {
            return Ok(await _bookingService.GetCustomerBooking(id, customerID));
        }


        [HttpPost("room/{roomID}")]
        public async Task<IActionResult> Add([FromBody] Bookings bookings, short roomID)
        {
            return Ok(await _bookingService.AddBooking(bookings, roomID));
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateBooking([FromBody] Bookings booking)
        {
            return Ok(await _bookingService.UpdateBooking(booking));
        }
    }
}
