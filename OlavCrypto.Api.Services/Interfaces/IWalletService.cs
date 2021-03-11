using OlavCrypto.Models;
using System.Collections.Generic;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface IWalletService
    {
        bool CreateWallet(Wallet wallet);
        bool EditWallet(Wallet wallet);
        IList<Wallet> GetWallets();
    }
}
