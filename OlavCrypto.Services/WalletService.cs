using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlavCrypto.Services
{
    public class WalletService : IWalletService
    {
        private readonly IRepository<Wallet> _walletRepository;
        private readonly ICryptocurrencyService _cryptocurrencyService;
        private readonly ICryptocurrencyDetailsService _cryptocurrencyDetailsService;

        public WalletService(IRepository<Wallet> walletRepository, ICryptocurrencyService cryptocurrencyService, ICryptocurrencyDetailsService cryptocurrencyDetailsService)
        {
            _walletRepository = walletRepository;
            _cryptocurrencyService = cryptocurrencyService;
            _cryptocurrencyDetailsService = cryptocurrencyDetailsService;
        }

        public async Task<IList<Wallet>> GetWallets()
        {
            var walletList = await _walletRepository.Get();
            var cryptoList = await _cryptocurrencyService.GetCryptocurrencies();

            foreach (var wallet in walletList)
            {
                var cryptoOfWalletList = await _cryptocurrencyDetailsService.GetCryptocurrencyDetailsPerWalletId(wallet.WalletId);

                foreach (var crypto in cryptoOfWalletList)
                {
                    crypto.BalanceInUSD = crypto.Balance * cryptoList.Where(x => x.CryptocurrencyId == crypto.CryptocurrencyWallet.Cryptocurrency.CryptocurrencyId).FirstOrDefault().Price;
                    wallet.BalanceInUSD += crypto.BalanceInUSD;
                }
            }

            return walletList;
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
