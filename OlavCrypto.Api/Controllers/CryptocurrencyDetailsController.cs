using Microsoft.AspNetCore.Mvc;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System;
using System.Net;

namespace OlavCrypto.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CryptocurrencyDetailsController : Controller
    {
        private readonly ICryptocurrencyDetailsService _cryptocurrencyDetailsService;

        public CryptocurrencyDetailsController(ICryptocurrencyDetailsService cryptocurrencyDetailsService)
        {
            _cryptocurrencyDetailsService = cryptocurrencyDetailsService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateCryprocurrency(CryptocurrencyDetails cryptocurrencyDetails)
        {
            if (_cryptocurrencyDetailsService.CreateCryptocurrencyDetails(cryptocurrencyDetails))
            {
                return Created(string.Empty, cryptocurrencyDetails);
            }

            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetCryptocurrencyDetails()
        {
            try
            {
                return Ok(_cryptocurrencyDetailsService.GetCryptocurrencyDetails());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EditCryptocurrencyDetails(CryptocurrencyDetails cryptocurrencyDetails)
        {
            if (_cryptocurrencyDetailsService.UpdateCryptocurrencyDetails(cryptocurrencyDetails))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
