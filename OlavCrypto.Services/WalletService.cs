using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Services
{
    public class WalletService : IWalletService
    {
        private readonly IRepository<Wallet> _walletRepository;

        public WalletService(IRepository<Wallet> walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public Task<IList<Wallet>> GetWallets()
        {
            return _walletRepository.Get();
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
