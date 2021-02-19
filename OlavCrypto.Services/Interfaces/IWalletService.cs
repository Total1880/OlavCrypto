using OlavCrypto.Models;

namespace OlavCrypto.Services.Interfaces
{
    public interface IWalletService
    {
        bool SaveWallet(Wallet wallet, bool newWallet);
    }
}
