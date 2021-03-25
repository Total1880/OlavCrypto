using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using OlavCrypto.Api.Repositories;

namespace OlavCrypto.Api.Services
{
    public class CryptocurrencyDetailsService : ICryptocurrencyDetailsService
    {
        private IRepository<CryptocurrencyDetails> _cryptocurrencyDetailsRepository;

        public CryptocurrencyDetailsService(IRepository<CryptocurrencyDetails> cryptocurrencyDetailsRepository)
        {
            _cryptocurrencyDetailsRepository = cryptocurrencyDetailsRepository;
        }
        public bool CreateCryptocurrencyDetails(CryptocurrencyDetails cryptocurrencyDetails)
        {
            return _cryptocurrencyDetailsRepository.Create(cryptocurrencyDetails);
        }
    }
}
