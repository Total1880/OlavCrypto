using OlavCrypto.Models;

namespace OlavCrypto.Services.Interfaces
{
    public interface ICryptocurrencyDetailsService
    {
        bool SaveCryptocurrenyDetails(CryptocurrencyDetails cryptocurrencyDetails);
    }
}
