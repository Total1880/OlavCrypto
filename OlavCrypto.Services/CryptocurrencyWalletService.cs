using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;

namespace OlavCrypto.Services
{
    public class CryptocurrencyWalletService : ICryptocurrencyWalletService
    {
        private IRepository<CryptocurrencyWallet> _cryptocurrencyWalletRepository;

        public CryptocurrencyWalletService(IRepository<CryptocurrencyWallet> cryptocurrencyWalletRepository)
        {
            _cryptocurrencyWalletRepository = cryptocurrencyWalletRepository;
        }

        public bool SaveCryptocurrencyWallet(CryptocurrencyWallet cryptocurrencyWallet)
        {
            return _cryptocurrencyWalletRepository.Create(cryptocurrencyWallet);
        }
    }
}
