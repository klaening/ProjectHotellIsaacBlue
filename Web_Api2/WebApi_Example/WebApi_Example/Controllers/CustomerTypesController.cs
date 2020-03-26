using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerTypesController : Controller
    {
        private readonly ICustomerTypesService _customerTypesService;

        public CustomerTypesController(ICustomerTypesService customerTypesService)
        {
            _customerTypesService = customerTypesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerTypesService.GetCustomerTypes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _customerTypesService.GetCustomerType(id));
        }
    }
}
