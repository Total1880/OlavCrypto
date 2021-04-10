using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        private readonly IRepository<Cryptocurrency> _cryptocurrencyRepository;
        private readonly ICoinMarketCapRepository _coinMarketCapRepository;
        private readonly ICryptocurrencyHistoryService _cryptocurrencyHistoryService;

        public CryptocurrencyService(IRepository<Cryptocurrency> cryptocurrencyRepository, ICoinMarketCapRepository coinMarketCapRepository, ICryptocurrencyHistoryService cryptocurrencyHistoryService)
        {
            _cryptocurrencyRepository = cryptocurrencyRepository;
            _coinMarketCapRepository = coinMarketCapRepository;
            _cryptocurrencyHistoryService = cryptocurrencyHistoryService;
        }

        public async Task<IList<Cryptocurrency>> GetCryptocurrencies()
        {
            var listCrypto = await _cryptocurrencyRepository.Get();

            foreach (var crypto in listCrypto)
            {
                if (crypto.PriceUpdateDate < DateTime.Today)
                {
                    crypto.Price = await UpdatePrice(crypto.ShortName);
                    crypto.PriceUpdateDate = DateTime.Today;
                    UpdateCryptocurrency(crypto);
                }
            }

            return listCrypto;
        }

        public bool SaveCryptocurrency(Cryptocurrency cryptocurrency)
        {
            return _cryptocurrencyRepository.Create(cryptocurrency);
        }

        public bool UpdateCryptocurrency(Cryptocurrency cryptocurrency)
        {
            _cryptocurrencyHistoryService.CreateCryptocurrencyHistory(new CryptocurrencyHistory { Cryptocurrency = cryptocurrency, Date = cryptocurrency.PriceUpdateDate, Price = cryptocurrency.Price });
            return _cryptocurrencyRepository.Update(cryptocurrency);
        }

        public async Task<double> UpdatePrice(string shortname)
        {
            return await _coinMarketCapRepository.GetCurrentPrice(shortname);
        }
    }
}
