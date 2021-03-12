using Microsoft.AspNetCore.Mvc;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System.Net;

namespace OlavCrypto.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CryptocurrencyController : ControllerBase
    {
        private readonly ICryptocurrencyService _cryptocurrencyService;

        public CryptocurrencyController(ICryptocurrencyService cryptocurrencyService)
        {
            _cryptocurrencyService = cryptocurrencyService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateCryprocurrency(Cryptocurrency cryptocurrency)
        {
            if (_cryptocurrencyService.CreateCryptocurrency(cryptocurrency))
            {
                return Created(string.Empty, cryptocurrency);
            }

            return BadRequest();
        }
    }
}
