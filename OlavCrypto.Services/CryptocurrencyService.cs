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
        private readonly ICoinMarketCapRepository _coinMarketCapRepository;

        public CryptocurrencyService(IRepository<Cryptocurrency> cryptocurrencyRepository, ICoinMarketCapRepository coinMarketCapRepository)
        {
            _cryptocurrencyRepository = cryptocurrencyRepository;
            _coinMarketCapRepository = coinMarketCapRepository;
            UpdatePrice();
        }

        public Task<IList<Cryptocurrency>> GetCryptocurrencies()
        {
            return _cryptocurrencyRepository.Get();
        }

        public bool SaveCryptocurrency(Cryptocurrency cryptocurrency)
        {
            return _cryptocurrencyRepository.Create(cryptocurrency);
        }

        public void UpdatePrice()
        {
            _coinMarketCapRepository.GetCurrentPrice("BTC");
        }
    }
}
