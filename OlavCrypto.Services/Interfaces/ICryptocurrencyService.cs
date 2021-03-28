using OlavCrypto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Services.Interfaces
{
    public interface ICryptocurrencyService
    {
        bool SaveCryptocurrency(Cryptocurrency cryptocurrency);
        Task<IList<Cryptocurrency>> GetCryptocurrencies();
        void UpdatePrice();
    }
}
