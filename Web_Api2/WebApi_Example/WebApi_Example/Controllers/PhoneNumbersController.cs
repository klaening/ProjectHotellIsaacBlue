using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneNumbersController : Controller
    {
        private readonly IPhoneNumberService _phoneNumbersService;

        public PhoneNumbersController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumbersService = phoneNumberService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _phoneNumbersService.GetPhoneNumbers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _phoneNumbersService.GetPhoneNumber(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PhoneNumbers phoneNumber)
        {
            return Ok(await _phoneNumbersService.AddPhoneNumber(phoneNumber));
        }
    }
}
