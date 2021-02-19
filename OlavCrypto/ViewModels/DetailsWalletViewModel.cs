using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OlavCrypto.Models;
using OlavCrypto.Services.Interfaces;

namespace OlavCrypto.ViewModels
{
    public class DetailsWalletViewModel : ViewModelBase
    {
        private readonly IWalletService _walletService;
        private RelayCommand _saveWalletCommand;

        public Wallet Wallet { get; set; }

        public RelayCommand SaveWalletCommand => _saveWalletCommand ??= new RelayCommand(SaveWallet);

        public DetailsWalletViewModel(IWalletService walletService)
        {
            _walletService = walletService;
            Wallet = new Wallet();
        }

        private void SaveWallet()
        {
            _walletService.SaveWallet(Wallet, true);
        }
    }
}
