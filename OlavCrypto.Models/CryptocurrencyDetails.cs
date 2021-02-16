namespace OlavCrypto.Models
{
    public class CryptocurrencyDetails
    {
        public int CryptocurrencyDetailsId { get; set; }
        public CryptocurrencyWallet CryptocurrencyWallet { get; set; }
        public decimal Balance { get; set; }
    }
}
