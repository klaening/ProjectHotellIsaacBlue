using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _reviewService.GetReviews());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _reviewService.GetReview(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Reviews review)
        {
            return Ok(await _reviewService.AddReview(review));
        }
    }
}
