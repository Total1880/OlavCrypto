using OlavCrypto.Api.Repositories;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System.Collections.Generic;
using System.Linq;

namespace OlavCrypto.Api.Services
{
    public class CryptocurrencyHistoryService : ICryptocurrencyHistoryService
    {
        private IRepository<CryptocurrencyHistory> _cryptocurrencyHistoryRepository;

        public CryptocurrencyHistoryService(IRepository<CryptocurrencyHistory> cryptocurrencyHistoryRepository)
        {
            _cryptocurrencyHistoryRepository = cryptocurrencyHistoryRepository;
        }

        public bool CreateCryptocurrencyHistory(CryptocurrencyHistory cryptocurrencyHistory)
        {
            return _cryptocurrencyHistoryRepository.Create(cryptocurrencyHistory);
        }

        public IList<CryptocurrencyHistory> GetCryptocurrencyHistories()
        {
            return _cryptocurrencyHistoryRepository.Get();
        }
    }
}
