using OlavCrypto.Models;

namespace OlavCrypto.Messages
{
    class DetailsWalletMessage
    {
        public Wallet Wallet { get; set; }

        public DetailsWalletMessage() : this(new Wallet())
        {

        }
        public DetailsWalletMessage(Wallet wallet)
        {
            Wallet = wallet;
        }
    }
}
