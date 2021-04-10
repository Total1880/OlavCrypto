using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlavCrypto.Services
{
    public class CryptocurrencyHistoryService : ICryptocurrencyHistoryService
    {
        private readonly IRepository<CryptocurrencyHistory> _cryptocurrencyHistoryRepository;

        public CryptocurrencyHistoryService(IRepository<CryptocurrencyHistory> cryptocurrencyHistoryRepository)
        {
            _cryptocurrencyHistoryRepository = cryptocurrencyHistoryRepository;
        }

        public bool CreateCryptocurrencyHistory(CryptocurrencyHistory cryptocurrencyHistory)
        {
            return _cryptocurrencyHistoryRepository.Create(cryptocurrencyHistory);
        }

        public async Task<IList<CryptocurrencyHistory>> GetCryptocurrencyHistoriesByShortname(string shortname)
        {
            var list = await _cryptocurrencyHistoryRepository.Get();

            return list.Where(x => x.Cryptocurrency.ShortName == shortname).ToList();
        }
    }
}
