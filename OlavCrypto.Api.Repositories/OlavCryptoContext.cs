using Microsoft.EntityFrameworkCore;
using OlavCrypto.Models;

namespace OlavCrypto.Api.Repositories
{
    public class OlavCryptoContext : DbContext
    {
        public DbSet<Wallet> WalletList { get; set; }
        public DbSet<Cryptocurrency> CryptocurrencyList { get; set; }
        public DbSet<CryptocurrencyDetails> CryptocurrencyDetailsList { get; set; }
        public DbSet<CryptocurrencyWallet> CryptocurrencyWalletList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=OlavCrypto;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
