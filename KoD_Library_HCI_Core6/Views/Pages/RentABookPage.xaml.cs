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
    /// Interaction logic for RentABookPage.xaml
    /// </summary>
    public partial class RentABookPage : Page
    {
        private KnjigaController _knjigaController = new KnjigaController();
        private IznajmljivanjeController _iznajmljivanjeController = new IznajmljivanjeController();
        private NalogController _nalogController = new NalogController();
        public RentABookPage()
        {
            InitializeComponent();
            cbKorisnici.ItemsSource = _nalogController.GetAllUsers()?.Select(el => el.KorisnickoIme);
            dpDatumIznajmljivanja.SelectedDate = DateTime.Now;
            dpDatumVracanja.SelectedDate = DateTime.Now.AddMonths(1);
        }

        public RentABookPage(uint currentUserTypeId, KnjigaViewModel bookToRent)
        {
            InitializeComponent(); // Obavezno prvo ide poziv ove metode u konstruktoru
            spBookFilter.Visibility = Visibility.Collapsed;
            // spBookFilter.Visibility = Visibility.Hidden;
            tbKnjiga.Text = bookToRent.Naslov?.ToString(); // 
            cbKorisnici.ItemsSource = _nalogController.GetAllUsers()?.Select(el => el.KorisnickoIme);
            dpDatumIznajmljivanja.SelectedDate = DateTime.Now;
            dpDatumVracanja.SelectedDate = DateTime.Now.AddMonths(1);
        }

        private void btnIznajmiKnjigu_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbKnjiga.Text) || 
               string.IsNullOrEmpty(cbKorisnici.SelectedItem.ToString()) ||
               (dpDatumIznajmljivanja.SelectedDate == null) ||
               (dpDatumVracanja.SelectedDate == null))
            {
                MessageBox.Show("Molimo popunite sva potrebna polja da biste omogućili iznajmljivanje knjige!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if(dpDatumIznajmljivanja.SelectedDate > dpDatumVracanja.SelectedDate)
            {
                MessageBox.Show("Odabrani datumi nisu validni! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                IznajmljivanjeViewModel novoIznajmljivanjeViewModel = new IznajmljivanjeViewModel()
                {
                    NaslovKnjige = tbKnjiga.Text,
                    ImeNalog = cbKorisnici.SelectedItem.ToString(),
                    IsVracena = chbVracena.IsChecked.Value,
                    DatumOd = DateOnly.FromDateTime(dpDatumIznajmljivanja.SelectedDate.Value),
                    DatumDo = DateOnly.FromDateTime(dpDatumVracanja.SelectedDate.Value),
                };

                var insertIzanmljivanjeResult = _iznajmljivanjeController.InsertNewBookRental(novoIznajmljivanjeViewModel);
                if(insertIzanmljivanjeResult == true)
                    MessageBox.Show("Knjiga je uspješno iznajmljena!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Greška prilikom iznajmljivanja knjige!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbBookFilter.Text))
            {
                MessageBox.Show("Molimo unesite parametar za pretragu knjige!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            List<KnjigaViewModel>? booksFilterResult = _knjigaController.GetAllBooksByTitleFilter(tbBookFilter.Text);
            if(booksFilterResult == null || booksFilterResult.Count == 0)
            {
                MessageBox.Show("Ne postoji rezultat pretrage! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            cbFilterResult.ItemsSource = booksFilterResult.Select(el => el.Naslov).ToList();
            cbFilterResult.SelectedItem = booksFilterResult.FirstOrDefault();
            cbFilterResult.SelectedValue = booksFilterResult.FirstOrDefault().Naslov;
            tbKnjiga.Text = cbFilterResult.SelectedItem as string;
        }

        private void cbFilterResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbKnjiga.Text = cbFilterResult?.SelectedValue as string;
        }
    }
}
