using OlavCrypto.Api.Repositories;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;
using System.Collections.Generic;

namespace OlavCrypto.Api.Services
{
    public class WalletService : IWalletService
    {
        private readonly IRepository<Wallet> _walletRepository;

        public WalletService(IRepository<Wallet> walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public bool CreateWallet(Wallet wallet)
        {
            return _walletRepository.Create(wallet);
        }

        public bool EditWallet(Wallet wallet)
        {
            return _walletRepository.Update(wallet);
        }

        public IList<Wallet> GetWallets()
        {
            return _walletRepository.Get();
        }
    }
}
