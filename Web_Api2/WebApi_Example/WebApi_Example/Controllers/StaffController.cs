using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _staffService.GetStaff());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _staffService.GetStaff(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Staff staff)
        {
            return Ok(await _staffService.AddStaff(staff));
        }
    }
}
