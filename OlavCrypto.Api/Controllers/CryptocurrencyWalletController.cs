using Microsoft.AspNetCore.Mvc;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System.Net;

namespace OlavCrypto.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CryptocurrencyWalletController : ControllerBase
    {
        private readonly ICryptocurrencyWalletService _cryptocurrencyWalletService;

        public CryptocurrencyWalletController(ICryptocurrencyWalletService cryptocurrencyWalletService)
        {
            _cryptocurrencyWalletService = cryptocurrencyWalletService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateCryprocurrency(CryptocurrencyWallet cryptocurrencyWallet)
        {
            if (_cryptocurrencyWalletService.CreateCryptoCurrencyWallet(cryptocurrencyWallet))
            {
                return Created(string.Empty, cryptocurrencyWallet);
            }

            return BadRequest();
        }
    }
}
