using OlavCrypto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.Services.Interfaces
{
    public interface IWalletService
    {
        bool SaveWallet(Wallet wallet, bool newWallet);
        Task<IList<Wallet>> GetWallets();
    }
}
