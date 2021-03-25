using OlavCrypto.Models;
using System.Collections.Generic;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface ICryptocurrencyWalletService
    {
        bool CreateCryptoCurrencyWallet(CryptocurrencyWallet cryptocurrencyWallet);
        IList<CryptocurrencyWallet> GetCryptocurrencyWallets();
    }
}
