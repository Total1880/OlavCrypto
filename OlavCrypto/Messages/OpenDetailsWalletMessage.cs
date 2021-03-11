using OlavCrypto.Models;

namespace OlavCrypto.Messages
{
    class OpenDetailsWalletMessage
    {
        public Wallet Wallet { get; set; }

        public OpenDetailsWalletMessage() : this(new Wallet())
        {

        }
        public OpenDetailsWalletMessage(Wallet wallet)
        {
            Wallet = wallet;
        }
    }
}
