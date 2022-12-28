using System.Windows;
using System.Windows.Controls;
using KoD_Library_HCI_Core6.Views.Pages;
using KoD_Library_HCI_Core6.Views.Menu;
using System.Windows.Media;
using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Enums;

namespace KoD_Library_HCI_Core6.Views.UserControls
{
    /// <summary>
    /// Interaction logic for NavSideBarEmployeeUC.xaml
    /// </summary>
    public partial class NavSideBarEmployeeUC : UserControl
    {
        public NavSideBarEmployeeUC()
        {
            InitializeComponent();
        }

        private void btnKnjige_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                ((ZaposleniMenu)(Window.GetWindow(this))).ZaposleniMenuContainer.Content = new BooksView();
            }
        }

        private void btnMojaZaduzenja_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                ((ZaposleniMenu)(Window.GetWindow(this))).ZaposleniMenuContainer.Content = new RentedBooksPage();
            }
        }

        private void btnMojNalog_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                ((ZaposleniMenu)(Window.GetWindow(this))).ZaposleniMenuContainer.Content = new MyAccountPage();
            }
        }

        private void btnONama_Click(object sender, RoutedEventArgs e)
        {
            ((ZaposleniMenu)(Window.GetWindow(this))).ZaposleniMenuContainer.Content = new AboutUsPage();
        }

        private void btnDodajNovuKnjigu_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                ((ZaposleniMenu)(Window.GetWindow(this))).ZaposleniMenuContainer.Content = new BookDetailsPage(LoggedUserHelper.currentUserTypeId, null, false);
            }
        }

        private void btnNovoZaduzenje_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                ((ZaposleniMenu)(Window.GetWindow(this))).ZaposleniMenuContainer.Content = new RentABookPage();
            }
        }

        private void btnKorisnickiNalozi_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                ((ZaposleniMenu)(Window.GetWindow(this))).ZaposleniMenuContainer.Content = new UserAccountsPage();
            }
        }
    }
}
