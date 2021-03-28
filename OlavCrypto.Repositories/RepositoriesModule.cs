using Autofac;

namespace OlavCrypto.Repositories
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WalletRepository>().AsImplementedInterfaces();
            builder.RegisterType<CryptocurrencyRepository>().AsImplementedInterfaces();
            builder.RegisterType<CryptocurrencyWalletRepository>().AsImplementedInterfaces();
            builder.RegisterType<CryptocurrencyDetailsRepository>().AsImplementedInterfaces();
            builder.RegisterType<CoinMarketCapRepository>().AsImplementedInterfaces();
        }
    }
}
