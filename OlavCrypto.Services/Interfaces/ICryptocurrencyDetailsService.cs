using OlavCrypto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Services.Interfaces
{
    public interface ICryptocurrencyDetailsService
    {
        bool SaveCryptocurrenyDetails(CryptocurrencyDetails cryptocurrencyDetails);
        bool UpdateCryptocurrencyDetails(CryptocurrencyDetails cryptocurrencyDetails);
        Task<IList<CryptocurrencyDetails>> GetCryptocurrencyDetailsPerWalletId(int id);
    }
}
