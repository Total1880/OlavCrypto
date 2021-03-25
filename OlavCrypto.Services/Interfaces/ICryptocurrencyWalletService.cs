using OlavCrypto.Models;

namespace OlavCrypto.Services.Interfaces
{
    public interface ICryptocurrencyWalletService
    {
        bool SaveCryptocurrencyWallet(CryptocurrencyWallet cryptocurrencyWallet);
    }
}
