using OlavCrypto.Pages;
using System.Windows;

namespace OlavCrypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OverviewWalletsPage _overviewWalletsPage;

        public OverviewWalletsPage OverviewWalletsPage => _overviewWalletsPage ??= new OverviewWalletsPage();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(OverviewWalletsPage);
        }
    }
}
