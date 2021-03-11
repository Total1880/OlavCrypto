using Microsoft.AspNetCore.Mvc;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System;
using System.Net;

namespace OlavCrypto.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateWallet(Wallet wallet)
        {
            if (_walletService.CreateWallet(wallet))
            {
                return Created(string.Empty, wallet);
            }

            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult EditWallet(Wallet wallet)
        {
            if (_walletService.EditWallet(wallet))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetWallets()
        {
            try
            {
                return Ok(_walletService.GetWallets());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
