using OlavCrypto.Models;

namespace OlavCrypto.Api.Services.Interfaces
{
    public interface IWalletService
    {
        bool CreateWallet(Wallet wallet);
        bool EditWallet(Wallet wallet);
    }
}
