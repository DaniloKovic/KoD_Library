using KoD_Library_HCI_Core6.Controller;
using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.Enums;
using KoD_Library_HCI_Core6.Models.ViewModel;
using KoD_Library_HCI_Core6.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for BooksView.xaml
    /// </summary>
    public partial class BooksView : Page
    {
        private KnjigaController _knjigaController = new KnjigaController();
        private AutorController _autorController = new AutorController();
        private ZanrController _zanrController = new ZanrController();
        public BooksView()
        {
            InitializeComponent();
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik)
            {
                // btnIznajmiKnjigu.Visibility = Visibility.Hidden;
                dgtcKolicina.Visibility = Visibility.Hidden;
                dgtcDostupnaKolicina.Visibility = Visibility.Hidden;
                btnIznajmiKnjigu.Visibility = Visibility.Collapsed;
            }
            else if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {

            }
            dgKnjige.ItemsSource = _knjigaController.GetAll();
            cbGenres.ItemsSource = _zanrController.GetAllGenres();
        }
        private void dgKnjige_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void btnPrikaziDetalje_Click(object sender, RoutedEventArgs e)
        {
            if (dgKnjige.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite neku knjigu!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var selectedBook = dgKnjige.SelectedItem as KnjigaViewModel;
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik) 
            {
                BookDetailsPage bookDetails = new BookDetailsPage(LoggedUserHelper.currentUserTypeId, selectedBook, false);
                this.NavigationService.Navigate(bookDetails);
            }
            else if(LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                BookDetailsPage bookDetails = new BookDetailsPage(LoggedUserHelper.currentUserTypeId, selectedBook, true);
                this.NavigationService.Navigate(bookDetails);
            }
        }

        private void dgKnjige_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnFilterBooks_Click(object sender, RoutedEventArgs e)
        {
            if (tbBookFilterByTitle.Text.Equals("") && tbFilterByAutorName.Text.Equals("") && (cbGenres.SelectedItem == null))
            {
                MessageBox.Show("Molimo da odaberete parametre za pretraživanje!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
               
            string filterByBookTitle = null;
            string filterByAuthorName = null;
            string fiteredByGenreType = null;

            if (!tbBookFilterByTitle.Text.Equals(""))
            {
                filterByBookTitle = tbBookFilterByTitle.Text;
            }
            if (!tbFilterByAutorName.Text.Equals(""))
            {
                filterByAuthorName = tbFilterByAutorName.Text;
            }
            if(cbGenres.SelectedItem != null)
            {
                fiteredByGenreType = cbGenres.SelectedItem.ToString();
            }
            var filteredBooksResult = _knjigaController.GetFilteredBooks(filterByBookTitle, filterByAuthorName, fiteredByGenreType);
            if (filteredBooksResult == null)
                MessageBox.Show("Ne postoji rezultat pretrage! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                dgKnjige.ItemsSource = filteredBooksResult;
        }

        private void btnIznajmiKnjigu_Click(object sender, RoutedEventArgs e)
        {
            if (dgKnjige.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite neku knjigu!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                KnjigaViewModel? selectedBook = dgKnjige.SelectedItem as KnjigaViewModel;
                if(selectedBook != null)
                {
                    if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik)
                    {
                        // BookDetailsPage bookDetails = new BookDetailsPage(LoggedUserHelper.currentUserTypeId, selectedBook, false);
                        // this.NavigationService.Navigate(bookDetails);
                    }
                    else if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
                    {
                        RentABookPage rentABook = new RentABookPage(LoggedUserHelper.currentUserTypeId, selectedBook);
                        this.NavigationService.Navigate(rentABook);
                    }
                }

            }
        }
    }
}
