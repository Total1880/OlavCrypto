using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OlavCrypto.Messages;
using OlavCrypto.Messages.WindowOpeners;
using OlavCrypto.Models;
using OlavCrypto.Services.Interfaces;
using System;

namespace OlavCrypto.ViewModels
{
    public class DetailsWalletViewModel : ViewModelBase
    {
        private readonly IWalletService _walletService;
        private Wallet _wallet;
        private RelayCommand _saveWalletCommand;
        private RelayCommand _addCryptoCommand;

        public Wallet Wallet { get => _wallet; set { _wallet = value; RaisePropertyChanged(); } }

        public RelayCommand SaveWalletCommand => _saveWalletCommand ??= new RelayCommand(SaveWallet);
        public RelayCommand AddCryptoCommand => _addCryptoCommand ??= new RelayCommand(AddCrypto);

        public DetailsWalletViewModel(IWalletService walletService)
        {
            _walletService = walletService;
            MessengerInstance.Register<DetailsWalletMessage>(this, InitializeWallet);
        }

        private void InitializeWallet(DetailsWalletMessage obj)
        {
            Wallet = obj.Wallet;
        }

        private void SaveWallet()
        {
            _walletService.SaveWallet(Wallet, Wallet.WalletId < 1);
            MessengerInstance.Send(new OverviewWalletsRefreshMessage());
        }

        private void AddCrypto()
        {
            MessengerInstance.Send(new OpenDetailsCryptoMessage());
        }
    }
}
