using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _paymentService.GetPayments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _paymentService.GetPayment(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Payments payment)
        {
            return Ok(await _paymentService.AddPayment(payment));
        }
    }
}
