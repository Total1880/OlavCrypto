namespace OlavCrypto.Models
{
    public class CryptocurrencyWallet
    {
        public int CryptocurrencyWalletId { get; set; }
        public Wallet Wallet { get; set; }
        public Cryptocurrency Cryptocurrency { get; set; }
    }
}
