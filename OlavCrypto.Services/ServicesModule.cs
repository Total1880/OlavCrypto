using Autofac;
using OlavCrypto.Repositories;

namespace OlavCrypto.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoriesModule>();

            builder.RegisterType<WalletService>().AsImplementedInterfaces();
            builder.RegisterType<CryptocurrencyService>().AsImplementedInterfaces();
            builder.RegisterType<CryptocurrencyWalletService>().AsImplementedInterfaces();
            builder.RegisterType<CryptocurrencyDetailsService>().AsImplementedInterfaces();
            builder.RegisterType<CryptocurrencyHistoryService>().AsImplementedInterfaces();
        }
    }
}
