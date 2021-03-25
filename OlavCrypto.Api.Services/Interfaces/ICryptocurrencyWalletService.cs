using OlavCrypto.Models;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface ICryptocurrencyWalletService
    {
        bool CreateCryptoCurrencyWallet(CryptocurrencyWallet cryptocurrencyWallet);
    }
}
