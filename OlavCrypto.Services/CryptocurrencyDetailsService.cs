using OlavCrypto.Models;
using OlavCrypto.Repositories;
using OlavCrypto.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace OlavCrypto.Services
{
    public class CryptocurrencyDetailsService : ICryptocurrencyDetailsService
    {
        private IRepository<CryptocurrencyDetails> _cryptocurrencyDetailsRepository;

        public CryptocurrencyDetailsService(IRepository<CryptocurrencyDetails> cryptocurrencyDetailsRepository)
        {
            _cryptocurrencyDetailsRepository = cryptocurrencyDetailsRepository;
        }

        public async Task<IList<CryptocurrencyDetails>> GetCryptocurrencyDetailsPerWalletId(int id)
        {
            var newList = await _cryptocurrencyDetailsRepository.Get();
            return newList.Where(x => x.CryptocurrencyWallet.Wallet.WalletId == id).ToList();
        }

        public bool SaveCryptocurrenyDetails(CryptocurrencyDetails cryptocurrencyDetails)
        {
            return _cryptocurrencyDetailsRepository.Create(cryptocurrencyDetails);
        }

        public bool UpdateCryptocurrencyDetails(CryptocurrencyDetails cryptocurrencyDetails)
        {
            return _cryptocurrencyDetailsRepository.Update(cryptocurrencyDetails);
        }
    }
}
