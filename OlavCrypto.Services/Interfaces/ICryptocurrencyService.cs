using OlavCrypto.Models;

namespace OlavCrypto.Services.Interfaces
{
    public interface ICryptocurrencyService
    {
        bool SaveCryptocurrency(Cryptocurrency cryptocurrency);
    }
}
