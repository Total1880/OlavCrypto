using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;

namespace OlavCrypto.Services
{
    public class CryptocurrencyDetailsService : ICryptocurrencyDetailsService
    {
        private IRepository<CryptocurrencyDetails> _cryptocurrencyDetailsRepository;

        public CryptocurrencyDetailsService(IRepository<CryptocurrencyDetails> cryptocurrencyDetailsRepository)
        {
            _cryptocurrencyDetailsRepository = cryptocurrencyDetailsRepository;
        }

        public bool SaveCryptocurrenyDetails(CryptocurrencyDetails cryptocurrencyDetails)
        {
            return _cryptocurrencyDetailsRepository.Create(cryptocurrencyDetails);
        }
    }
}
