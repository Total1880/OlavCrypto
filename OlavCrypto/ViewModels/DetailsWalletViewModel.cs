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
        private readonly ICryptocurrencyWalletService _cryptocurrencyWalletService;
        private readonly ICryptocurrencyDetailsService _cryptocurrencyDetailsService;
        private Wallet _wallet;
        private Cryptocurrency _selectedCryptocurrency;
        private CryptocurrencyDetails _selectedCryptocurrencyDetails;
        private IList<Cryptocurrency> _cryptocurrencyList;
        private IList<CryptocurrencyDetails> _cryptoCurrencyDetailsList;
        private RelayCommand _saveWalletCommand;
        private RelayCommand _addCryptoCommand;
        private RelayCommand _addCryptoWalletCommand;
        private RelayCommand _editCryptocurrencyDetailsCommand;

        public Wallet Wallet { get => _wallet; set { _wallet = value; RaisePropertyChanged(); } }
        public Cryptocurrency SelectedCryptoCurrency { get => _selectedCryptocurrency; set { _selectedCryptocurrency = value; RaisePropertyChanged(); } }
        public CryptocurrencyDetails SelectedCryptoCurrencyDetails
        {
            get => _selectedCryptocurrencyDetails;
            set
            {
                _selectedCryptocurrencyDetails = value;
                if (value != null)
                {
                    SelectedCryptoCurrency = value.CryptocurrencyWallet.Cryptocurrency;
                }
                RaisePropertyChanged();
            }
        }
        public IList<Cryptocurrency> CryptocurrencyList { get => _cryptocurrencyList; set { _cryptocurrencyList = value; RaisePropertyChanged(); } }
        public IList<CryptocurrencyDetails> CryptoCurrencyDetailsList { get => _cryptoCurrencyDetailsList; set { _cryptoCurrencyDetailsList = value; RaisePropertyChanged(); } }
        public RelayCommand SaveWalletCommand => _saveWalletCommand ??= new RelayCommand(SaveWallet);
        public RelayCommand AddCryptoCommand => _addCryptoCommand ??= new RelayCommand(AddCrypto);
        public RelayCommand AddCryptoWalletCommand => _addCryptoWalletCommand ??= new RelayCommand(AddCryptoWallet);
        public RelayCommand EditCryptocurrencyDetailsCommand => _editCryptocurrencyDetailsCommand ??= new RelayCommand(EditCryptocurrencyDetails);

        public DetailsWalletViewModel(IWalletService walletService, ICryptocurrencyService cryptocurrencyService, ICryptocurrencyWalletService cryptocurrencyWalletService, ICryptocurrencyDetailsService cryptocurrencyDetailsService)
        {
            _walletService = walletService;
            _cryptocurrencyService = cryptocurrencyService;
            _cryptocurrencyWalletService = cryptocurrencyWalletService;
            _cryptocurrencyDetailsService = cryptocurrencyDetailsService;

            MessengerInstance.Register<DetailsWalletMessage>(this, InitializeWallet);

            _ = LoadCryptocurrencyList();
        }

        private void InitializeWallet(DetailsWalletMessage obj)
        {
            Wallet = obj.Wallet;
            _ = LoadCryptocurrencyDetails();
        }

        private async Task LoadCryptocurrencyList()
        {
            CryptocurrencyList = await _cryptocurrencyService.GetCryptocurrencies();
        }

        private async Task LoadCryptocurrencyDetails()
        {
            CryptoCurrencyDetailsList = await _cryptocurrencyDetailsService.GetCryptocurrencyDetailsPerWalletId(Wallet.WalletId);
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
            if (Wallet == null || SelectedCryptoCurrency == null || Wallet.WalletId == 0)
            {
                return;
            }

            _cryptocurrencyWalletService.SaveCryptocurrencyWallet(new CryptocurrencyWallet { Wallet = Wallet, Cryptocurrency = SelectedCryptoCurrency });
        }

        private void EditCryptocurrencyDetails()
        {
            if (SelectedCryptoCurrencyDetails == null)
            {
                return;
            }

            if (_cryptocurrencyDetailsService.UpdateCryptocurrencyDetails(SelectedCryptoCurrencyDetails))
            {
                _ = LoadCryptocurrencyDetails();
            }
        }
    }
}
