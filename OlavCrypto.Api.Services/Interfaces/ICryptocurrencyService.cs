using OlavCrypto.Models;
using System.Collections.Generic;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface ICryptocurrencyService
    {
        bool CreateCryptocurrency(Cryptocurrency cryptocurrency);
        bool UpdateCryptocurrency(Cryptocurrency cryptocurrency);
        IList<Cryptocurrency> GetCryptocurrencies();
    }
}
