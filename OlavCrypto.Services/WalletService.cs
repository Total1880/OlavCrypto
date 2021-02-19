using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;

namespace OlavCrypto.Services
{
    public class WalletService : IWalletService
    {
        private readonly IRepository<Wallet> _walletRepository;

        public WalletService(IRepository<Wallet> walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public bool SaveWallet(Wallet wallet, bool newWallet)
        {
            if (newWallet)
            {
                return _walletRepository.Create(wallet);
            }

            return _walletRepository.Update(wallet);
        }
    }
}
