using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        private readonly IRepository<Cryptocurrency> _cryptocurrencyRepository;

        public CryptocurrencyService(IRepository<Cryptocurrency> cryptocurrencyRepository)
        {
            _cryptocurrencyRepository = cryptocurrencyRepository;
        }

        public Task<IList<Cryptocurrency>> GetCryptocurrencies()
        {
            return _cryptocurrencyRepository.Get();
        }

        public bool SaveCryptocurrency(Cryptocurrency cryptocurrency)
        {
            return _cryptocurrencyRepository.Create(cryptocurrency);
        }
    }
}
