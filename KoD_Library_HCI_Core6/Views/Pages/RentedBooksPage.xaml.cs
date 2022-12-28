using KoD_Library_HCI_Core6.Controller;
using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Enums;
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
    /// Interaction logic for RentedBooksPage.xaml
    /// </summary>
    public partial class RentedBooksPage : Page
    {
        private IznajmljivanjeController _iznajmljivanjeController = new IznajmljivanjeController();
        public RentedBooksPage()
        {
            InitializeComponent();
            if(LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                dgRentedBooks.IsReadOnly = false;
                dgtcNaslovKnjige.IsReadOnly = true;
                dgtcImeNalog.IsReadOnly = true;
                dgtcDatumIznajmljivanja.IsReadOnly = true;
                dgtcDatumvracanja.IsReadOnly = true;
                dgcbcVracena.IsReadOnly = false;
                dgtcImeNalog.Visibility = Visibility.Visible;
            }
            else if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik)
            {
                btnSacuvajIzmjene.Visibility = Visibility.Hidden;
            }
            dgRentedBooks.ItemsSource = _iznajmljivanjeController.GetAllBookRentals(LoggedUserHelper.currentUserTypeId, LoggedUserHelper.currentUserID);
        }

        private void dgRentedBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSacuvajIzmjene_Click(object sender, RoutedEventArgs e)
        {
            if (dgRentedBooks.SelectedItem == null)
            {
                MessageBox.Show("Molimo izaberite red iz tabele!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            IznajmljivanjeViewModel? selectedRental = dgRentedBooks.SelectedItem as IznajmljivanjeViewModel;
            if(selectedRental != null)
            {
                bool updateResult = _iznajmljivanjeController.UpdateBookRental(selectedRental);
                if (updateResult == true)
                    MessageBox.Show("Uspješno ste ažurirali iznajmljivanje!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Greška prilikom iznajmljivanja! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Molimo izaberite red iz tabele!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return;
        }
    }
}
