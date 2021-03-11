using System.Windows.Controls;

namespace OlavCrypto.Pages
{
    /// <summary>
    /// Interaction logic for OverviewWallets.xaml
    /// </summary>
    public partial class OverviewWalletsPage : Page
    {
        private PopupWindow _popupWindow;

        public PopupWindow PopupWindow => _popupWindow ??= new PopupWindow();
        public OverviewWalletsPage()
        {
            InitializeComponent();
        }

        private void ButtonAddWalletClick(object sender, System.Windows.RoutedEventArgs e)
        {
            PopupWindow.Show();
        }

        private void ButtonEditWalletClick(object sender, System.Windows.RoutedEventArgs e)
        {
            PopupWindow.Show();
        }
    }
}
