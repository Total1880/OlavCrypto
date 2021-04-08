using OlavCrypto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Services.Interfaces
{
    public interface ICryptocurrencyService
    {
        bool SaveCryptocurrency(Cryptocurrency cryptocurrency);
        bool UpdateCryptocurrency(Cryptocurrency cryptocurrency);
        Task<IList<Cryptocurrency>> GetCryptocurrencies();
        Task<double> UpdatePrice(string shortname);
    }
}
