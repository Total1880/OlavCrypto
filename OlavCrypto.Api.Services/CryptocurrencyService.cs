using OlavCrypto.Api.Repositories;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System.Collections.Generic;

namespace OlavCrypto.Api.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        private readonly IRepository<Cryptocurrency> _cryptocurrencyRepository;

        public CryptocurrencyService(IRepository<Cryptocurrency> cryptocurrencyRepository)
        {
            _cryptocurrencyRepository = cryptocurrencyRepository;
        }

        public bool CreateCryptocurrency(Cryptocurrency cryptocurrency)
        {
            return _cryptocurrencyRepository.Create(cryptocurrency);
        }

        public IList<Cryptocurrency> GetCryptocurrencies()
        {
            return _cryptocurrencyRepository.Get();
        }
    }
}
