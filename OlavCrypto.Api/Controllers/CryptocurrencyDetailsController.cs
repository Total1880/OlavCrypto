using Microsoft.AspNetCore.Mvc;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
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
    }
}
