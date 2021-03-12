using OlavCrypto.Models;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface ICryptocurrencyService
    {
        bool CreateCryptocurrency(Cryptocurrency cryptocurrency);
    }
}
