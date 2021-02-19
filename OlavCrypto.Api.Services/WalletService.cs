using OlavCrypto.Api.Repositories;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;

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
    }
}
