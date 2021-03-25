using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OlavCrypto.Messages;
using OlavCrypto.Messages.WindowOpeners;
using OlavCrypto.Models;
using OlavCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.ViewModels
{
    public class DetailsWalletViewModel : ViewModelBase
    {
        private readonly IWalletService _walletService;
        private readonly ICryptocurrencyService _cryptocurrencyService;
        private Wallet _wallet;
        private Cryptocurrency _selectedCryptocurrency;
        private IList<Cryptocurrency> _cryptocurrencyList;
        private RelayCommand _saveWalletCommand;
        private RelayCommand _addCryptoCommand;
        private RelayCommand _addCryptoWalletCommand;

        public Wallet Wallet { get => _wallet; set { _wallet = value; RaisePropertyChanged(); } }
        public Cryptocurrency SelectedCryptoCurrency { get => _selectedCryptocurrency; set { _selectedCryptocurrency = value; RaisePropertyChanged(); } }
        public IList<Cryptocurrency> CryptocurrencyList { get => _cryptocurrencyList; set { _cryptocurrencyList = value; RaisePropertyChanged(); } }

        public RelayCommand SaveWalletCommand => _saveWalletCommand ??= new RelayCommand(SaveWallet);
        public RelayCommand AddCryptoCommand => _addCryptoCommand ??= new RelayCommand(AddCrypto);
        public RelayCommand AddCryptoWalletCommand => _addCryptoWalletCommand ??= new RelayCommand(AddCryptoWallet);

        public DetailsWalletViewModel(IWalletService walletService, ICryptocurrencyService cryptocurrencyService)
        {
            _walletService = walletService;
            _cryptocurrencyService = cryptocurrencyService;

            MessengerInstance.Register<DetailsWalletMessage>(this, InitializeWallet);

            _ = LoadCryptocurrencyList();
        }

        private void InitializeWallet(DetailsWalletMessage obj)
        {
            Wallet = obj.Wallet;
        }

        private async Task LoadCryptocurrencyList()
        {
            CryptocurrencyList = await _cryptocurrencyService.GetCryptocurrencies();
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

        private void AddCryptoWallet()
        {
            if (Wallet == null || SelectedCryptoCurrency == null || Wallet.WalletId > 0)
            {
                return;
            }

            CryptocurrencyWallet cryptocurrencyWallet = new CryptocurrencyWallet { Wallet = Wallet, Cryptocurrency = SelectedCryptoCurrency };
        }
    }
}
