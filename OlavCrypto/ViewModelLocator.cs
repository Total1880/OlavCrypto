using Autofac;
using OlavCrypto.Repositories.RestClient;
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

            _container = builder.Build();
        }

        public DetailsWalletViewModel DetailsWallet => _container.Resolve<DetailsWalletViewModel>();
    }
}
