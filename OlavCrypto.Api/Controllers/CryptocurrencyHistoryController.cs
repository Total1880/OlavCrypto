using Microsoft.AspNetCore.Mvc;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OlavCrypto.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CryptocurrencyHistoryController : ControllerBase
    {
        private readonly ICryptocurrencyHistoryService _cryptocurrencyHistoryService;

        public CryptocurrencyHistoryController(ICryptocurrencyHistoryService cryptocurrencyHistoryService)
        {
            _cryptocurrencyHistoryService = cryptocurrencyHistoryService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateCryprocurrencyHistory(CryptocurrencyHistory cryptocurrencyHistory)
        {
            if (_cryptocurrencyHistoryService.CreateCryptocurrencyHistory(cryptocurrencyHistory))
            {
                return Created(string.Empty, cryptocurrencyHistory);
            }

            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetCryptocurrencyHistory()
        {
            try
            {
                return Ok(_cryptocurrencyHistoryService.GetCryptocurrencyHistories());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
