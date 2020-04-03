using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _accountService.GetAccounts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                int idInt = int.Parse(id);
                return Ok(await _accountService.GetAccount(idInt));
            }
            catch (System.Exception)
            {
                return Ok(await _accountService.GetAccount(id));
            }
        }

        [HttpGet("{userName}/{password}")]
        public async Task<IActionResult> Get(string userName, string password)
        {
            return Ok(await _accountService.GetAccount(userName, password));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Accounts accounts)
        {
            return Ok(await _accountService.AddAccount(accounts));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Accounts accounts)
        {
            return Ok(await _accountService.UpdateAccount(accounts));
        }
    }
}
