using OlavCrypto.Models;
using System.Collections.Generic;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface ICryptocurrencyDetailsService
    {
        bool CreateCryptocurrencyDetails(CryptocurrencyDetails cryptocurrencyDetails);
        bool UpdateCryptocurrencyDetails(CryptocurrencyDetails cryptocurrencyDetails);
        IList<CryptocurrencyDetails> GetCryptocurrencyDetails();
    }
}
