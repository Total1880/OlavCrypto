using OlavCrypto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Services.Interfaces
{
    public interface ICryptocurrencyHistoryService
    {
        bool CreateCryptocurrencyHistory(CryptocurrencyHistory cryptocurrencyHistory);
        Task<IList<CryptocurrencyHistory>> GetCryptocurrencyHistoriesByShortname(string shortname);
    }
}
