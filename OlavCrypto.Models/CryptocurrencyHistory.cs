using System;

namespace OlavCrypto.Models
{
    public class CryptocurrencyHistory
    {
        public int CryptocurrencyHistoryId { get; set; }
        public Cryptocurrency Cryptocurrency { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
