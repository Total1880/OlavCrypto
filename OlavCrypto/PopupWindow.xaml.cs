using OlavCrypto.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OlavCrypto
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        private DetailsWalletPage _detailsWalletPage;

        public DetailsWalletPage DetailsWalletPage => _detailsWalletPage ??= new DetailsWalletPage();
        public PopupWindow()
        {
            InitializeComponent();
            MainFrame.NavigationService.Navigate(DetailsWalletPage);
        }
    }
}
