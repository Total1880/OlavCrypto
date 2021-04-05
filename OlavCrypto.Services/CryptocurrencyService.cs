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
        }

        public async Task<IList<Cryptocurrency>> GetCryptocurrencies()
        {
            var listCrypto = await _cryptocurrencyRepository.Get();

            foreach (var crypto in listCrypto)
            {
                crypto.Price = await UpdatePrice(crypto.ShortName);
            }

            return listCrypto;
        }

        public bool SaveCryptocurrency(Cryptocurrency cryptocurrency)
        {
            return _cryptocurrencyRepository.Create(cryptocurrency);
        }

        public async Task<double> UpdatePrice(string shortname)
        {
            return await _coinMarketCapRepository.GetCurrentPrice(shortname);
        }
    }
}
