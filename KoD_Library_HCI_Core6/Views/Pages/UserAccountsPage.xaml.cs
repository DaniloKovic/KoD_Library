using KoD_Library_HCI_Core6.Controller;
using KoD_Library_HCI_Core6.Models.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KoD_Library_HCI_Core6.Views.Pages
{
    /// <summary>
    /// Interaction logic for UserAccountsPage.xaml
    /// </summary>
    public partial class UserAccountsPage : Page
    {
        NalogController _nalogController = new NalogController();
        public UserAccountsPage()
        {
            InitializeComponent();
            dgKorisnickiNalozi.ItemsSource = _nalogController.GetAllUsers();
        }

        private void dgKorisnickiNalozi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnPrikaziDetalje_Click(object sender, RoutedEventArgs e)
        {
            if (dgKorisnickiNalozi.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite korisnika!", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            var selectedUserAccount = dgKorisnickiNalozi.SelectedItem as NalogViewModel;
            MyAccountPage myAccountPage = new MyAccountPage(selectedUserAccount);
            this.NavigationService.Navigate(myAccountPage);

        }
    }
}
