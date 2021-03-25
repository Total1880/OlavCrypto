using OlavCrypto.Models;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface ICryptocurrencyDetailsService
    {
        bool CreateCryptocurrencyDetails(CryptocurrencyDetails cryptocurrencyDetails);
    }
}
