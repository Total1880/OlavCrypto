using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OlavCrypto.Messages;
using OlavCrypto.Messages.WindowOpeners;
using OlavCrypto.Models;
using OlavCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ObservableCollection<CryptocurrencyDetails> _cryptoCurrencyDetailsList;
        private RelayCommand _saveWalletCommand;
        private RelayCommand _addCryptoCommand;
        private RelayCommand _addCryptoWalletCommand;
        private RelayCommand _editCryptocurrencyDetailsCommand;
        private bool _loadCryptoCurrencyDetailsCompleted = false;
        private bool _loadCryptoCurrencyCompleted = false;

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
        public ObservableCollection<CryptocurrencyDetails> CryptoCurrencyDetailsList { get => _cryptoCurrencyDetailsList; set { _cryptoCurrencyDetailsList = value; RaisePropertyChanged(); } }
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
        }

        private void InitializeWallet(DetailsWalletMessage obj)
        {
            Wallet = obj.Wallet;

            _ = LoadCryptocurrencyList();
            _ = LoadCryptocurrencyDetails();
        }

        private async Task LoadCryptocurrencyList()
        {
            CryptocurrencyList = await _cryptocurrencyService.GetCryptocurrencies();
            _loadCryptoCurrencyCompleted = true;

            if (_loadCryptoCurrencyDetailsCompleted)
            {
                UpdatePrice();
                _loadCryptoCurrencyCompleted = false;
                _loadCryptoCurrencyDetailsCompleted = false;
            }
        }

        private async Task LoadCryptocurrencyDetails()
        {
            CryptoCurrencyDetailsList = new ObservableCollection<CryptocurrencyDetails>();

            var list = await _cryptocurrencyDetailsService.GetCryptocurrencyDetailsPerWalletId(Wallet.WalletId);

            foreach (var item in list)
            {
                CryptoCurrencyDetailsList.Add(item);
            }

            _loadCryptoCurrencyDetailsCompleted = true;

            if (_loadCryptoCurrencyCompleted)
            {
                UpdatePrice();
                _loadCryptoCurrencyCompleted = false;
                _loadCryptoCurrencyDetailsCompleted = false;
            }
        }

        private void UpdatePrice()
        {
            var list = CryptoCurrencyDetailsList;
            foreach (var item in list)
            {
                item.CryptocurrencyWallet.Cryptocurrency.Price = CryptocurrencyList.Where(x => x.CryptocurrencyId == item.CryptocurrencyWallet.Cryptocurrency.CryptocurrencyId).FirstOrDefault().Price;
                item.BalanceInUSD = item.Balance * item.CryptocurrencyWallet.Cryptocurrency.Price;
            }
            CryptoCurrencyDetailsList = new ObservableCollection<CryptocurrencyDetails>();
            CryptoCurrencyDetailsList = list;
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

            _loadCryptoCurrencyCompleted = true;
            _ = LoadCryptocurrencyDetails();
        }

        private void EditCryptocurrencyDetails()
        {
            if (SelectedCryptoCurrencyDetails == null)
            {
                return;
            }

            if (_cryptocurrencyDetailsService.UpdateCryptocurrencyDetails(SelectedCryptoCurrencyDetails))
            {
                _loadCryptoCurrencyCompleted = true;
                _ = LoadCryptocurrencyDetails();
            }
        }
    }
}
