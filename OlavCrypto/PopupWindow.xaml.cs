using GalaSoft.MvvmLight.Messaging;
using OlavCrypto.Messages.WindowOpeners;
using OlavCrypto.Pages;
using System;
using System.Windows;

namespace OlavCrypto
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        private DetailsWalletPage _detailsWalletPage;
        private DetailsCryptoPage _detailsCryptoPage;

        public DetailsWalletPage DetailsWalletPage => _detailsWalletPage ??= new DetailsWalletPage();
        public DetailsCryptoPage DetailsCryptoPage => _detailsCryptoPage ??= new DetailsCryptoPage();

        public PopupWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(DetailsWalletPage);
            Messenger.Default.Register<OpenDetailsCryptoMessage>(this, OpenDetailsCryptoPage);
            Messenger.Default.Register<OpenDetailsWalletMessage>(this, OpenDetailsWalletPage);
        }

        private void OpenDetailsCryptoPage(OpenDetailsCryptoMessage obj)
        {
            MainFrame.NavigationService.Navigate(DetailsCryptoPage);
        }

        private void OpenDetailsWalletPage(OpenDetailsWalletMessage obj)
        {
            MainFrame.NavigationService.Navigate(DetailsWalletPage);
        }
    }
}
