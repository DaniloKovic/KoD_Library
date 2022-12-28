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
    /// Interaction logic for NavigationSideBarUC.xaml
    /// </summary>
    public partial class NavSideBarUserUC : UserControl
    {
        // private Window KorisnikMenu;
        public NavSideBarUserUC()
        {
            InitializeComponent();

        }

        private void btnKnjige_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik)
            {
                ((KorisnikMenu)(Window.GetWindow(this))).KorisnikMenuContainer.Content = new BooksView();
            }
        }

        private void btnMojaZaduzenja_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik)
            {
                ((KorisnikMenu)(Window.GetWindow(this))).KorisnikMenuContainer.Content = new RentedBooksPage();
            }
        }

        private void btnMojNalog_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik)
            {
                ((KorisnikMenu)(Window.GetWindow(this))).KorisnikMenuContainer.Content = new MyAccountPage();
            }
        }

        private void btnONama_Click(object sender, RoutedEventArgs e)
        {
            ((KorisnikMenu)(Window.GetWindow(this))).KorisnikMenuContainer.Content = new AboutUsPage();
        }
    }
}
