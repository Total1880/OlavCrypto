using System.Windows.Controls;

namespace OlavCrypto.Pages
{
    /// <summary>
    /// Interaction logic for OverviewWallets.xaml
    /// </summary>
    public partial class OverviewWalletsPage : Page
    {
        public OverviewWalletsPage()
        {
            InitializeComponent();
        }

        private void ButtonAddWalletClick(object sender, System.Windows.RoutedEventArgs e)
        {
            PopupWindow PopupWindow = new PopupWindow();
            PopupWindow.Show();
        }

        private void ButtonEditWalletClick(object sender, System.Windows.RoutedEventArgs e)
        {
            PopupWindow PopupWindow = new PopupWindow();
            PopupWindow.Show();
        }
    }
}
