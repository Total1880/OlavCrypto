using Autofac;
using OlavCrypto.Repositories.RestClient;
using OlavCrypto.Repositories;
using OlavCrypto.Services;
using OlavCrypto.ViewModels;
using static System.Configuration.ConfigurationManager;

namespace OlavCrypto
{
    public class ViewModelLocator
    {
        private readonly IContainer _container;

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<ServicesModule>();

            var _baseURI = AppSettings.Get("BasisURL");
            builder.RegisterType<OlavCryptoRestClient>().As<OlavCryptoRestClient>().WithParameter("baseAdress", _baseURI);

            builder.RegisterType<DetailsWalletViewModel>().SingleInstance();
            builder.RegisterType<OverviewWalletsViewModel>().SingleInstance();
            builder.RegisterType<DetailsCryptoViewModel>().SingleInstance();

            _container = builder.Build();
        }

        public DetailsWalletViewModel DetailsWallet => _container.Resolve<DetailsWalletViewModel>();
        public OverviewWalletsViewModel OverviewWallets => _container.Resolve<OverviewWalletsViewModel>();
        public DetailsCryptoViewModel DetailsCrypto => _container.Resolve<DetailsCryptoViewModel>();
    }
}
