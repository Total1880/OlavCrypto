using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OlavCrypto.Messages;
using OlavCrypto.Models;
using OlavCrypto.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlavCrypto.ViewModels
{
    public class OverviewWalletsViewModel : ViewModelBase
    {
        private readonly IWalletService _walletService;
        private IList<Wallet> _walletList;
        private Wallet _selectedWallet;
        private RelayCommand _openDetailsWalletCommand;
        private RelayCommand _openNewDetailsWalletCommand;

        public IList<Wallet> WalletList { get => _walletList; set { _walletList = value; RaisePropertyChanged(); } }
        public Wallet SelectedWallet { get => _selectedWallet; set { _selectedWallet = value; RaisePropertyChanged(); } }

        public RelayCommand OpenDetailsWalletCommand => _openDetailsWalletCommand ??= new RelayCommand(OpenDetailsWallet);
        public RelayCommand OpenNewDetailsWalletCommand => _openNewDetailsWalletCommand ??= new RelayCommand(OpenNewDetailsWallet);

        private void OpenDetailsWallet()
        {
            MessengerInstance.Send(new DetailsWalletMessage(SelectedWallet));
        }

        private void OpenNewDetailsWallet()
        {
            MessengerInstance.Send(new DetailsWalletMessage());
        }

        public OverviewWalletsViewModel(IWalletService walletService)
        {
            _walletService = walletService;
            MessengerInstance.Register<OverviewWalletsRefreshMessage>(this, RefreshWalletList);

            _ = LoadWalletList();
        }

        private void RefreshWalletList(OverviewWalletsRefreshMessage obj)
        {
            _ = LoadWalletList();
        }

        private async Task LoadWalletList()
        {
            WalletList = await _walletService.GetWallets();
        }
    }
}
