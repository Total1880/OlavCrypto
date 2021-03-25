using OlavCrypto.Api.Repositories;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System.Collections.Generic;

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

        public IList<CryptocurrencyWallet> GetCryptocurrencyWallets()
        {
            return _cryptocurrencyWalletRepository.Get();
        }
    }
}
