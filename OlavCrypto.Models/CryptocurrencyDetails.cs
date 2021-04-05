namespace OlavCrypto.Models
{
    public class CryptocurrencyDetails
    {
        public int CryptocurrencyDetailsId { get; set; }
        public CryptocurrencyWallet CryptocurrencyWallet { get; set; }
        public double Balance { get; set; }
        public double BalanceInUSD { get; set; }
    }
}
