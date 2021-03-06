﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Services;

namespace WebApi_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneNumberTypesController : Controller
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;

        public PhoneNumberTypesController(IPhoneNumberTypeService phoneNumberTypeService)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _phoneNumberTypeService.GetPhoneNumberTypes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _phoneNumberTypeService.GetPhoneNumberType(id));
        }
    }
}
