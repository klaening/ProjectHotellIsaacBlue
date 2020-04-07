using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypesController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypesController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _roomTypeService.GetRoomTypes());
        }

        [HttpGet("{uri}")]
        public async Task<IActionResult> Get(string uri)
        {
            try
            {
                short id = short.Parse(uri);
                return Ok(await _roomTypeService.GetRoomType(id));
            }
            catch (System.Exception)
            {
                return Ok(await _roomTypeService.GetRoomType(uri));
            }
        }
    }
}
