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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string idString)
        {
            try
            {
                int idInt = int.Parse(idString);
                return Ok(await _roomTypeService.GetRoomType(idInt));
            }
            catch (System.Exception)
            {
                return Ok(await _roomTypeService.GetRoomType(idString));
            }
        }

        //Testa att lägg till en med string i en HttpGet
    }
}
