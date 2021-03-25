using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OlavCrypto.Messages.WindowOpeners;
using OlavCrypto.Models;
using OlavCrypto.Services.Interfaces;

namespace OlavCrypto.ViewModels
{
    public class DetailsCryptoViewModel : ViewModelBase
    {
        private readonly ICryptocurrencyService _cryptocurrencyService;
        private Cryptocurrency _cryptocurrency;
        private RelayCommand _saveCryptoCommand;
        private RelayCommand _cancelCommand;

        public Cryptocurrency Cryptocurrency { get => _cryptocurrency; set { _cryptocurrency = value; RaisePropertyChanged(); } }
        public RelayCommand SaveCryptoCommand => _saveCryptoCommand ??= new RelayCommand(SaveCrypto);
        public RelayCommand CancelCommand => _cancelCommand ??= new RelayCommand(Cancel);

        public DetailsCryptoViewModel(ICryptocurrencyService cryptocurrencyService)
        {
            _cryptocurrencyService = cryptocurrencyService;
            Cryptocurrency = new Cryptocurrency();
        }

        private void SaveCrypto()
        {
            _cryptocurrencyService.SaveCryptocurrency(Cryptocurrency);

            MessengerInstance.Send(new OpenDetailsWalletMessage());
        }

        private void Cancel()
        {
            MessengerInstance.Send(new OpenDetailsWalletMessage());
        }
    }
}
