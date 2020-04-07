using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerService.GetCustomers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _customerService.GetCustomer(id));
        }

        [HttpPost("account/{accountID}")]
        public async Task<IActionResult> Add([FromBody] Customers customer, int accountID)
        {
            return Ok(await _customerService.AddCustomer(customer, accountID));
        }
    }
}
