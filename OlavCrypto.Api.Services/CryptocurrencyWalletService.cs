using OlavCrypto.Api.Repositories;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;

namespace OlavCrypto.Api.Services
{
    public class CryptocurrencyWalletService : ICryptocurrencyWalletService
    {
        private IRepository<CryptocurrencyWallet> _cryptocurrencyWalletRepository;

        public CryptocurrencyWalletService(IRepository<CryptocurrencyWallet> cryptocurrencyWalletRepository)
        {
            _cryptocurrencyWalletRepository = cryptocurrencyWalletRepository;
        }

        public bool CreateCryptoCurrencyWallet(CryptocurrencyWallet cryptocurrencyWallet)
        {
            return _cryptocurrencyWalletRepository.Create(cryptocurrencyWallet);
        }
    }
}
