using KoD_Library_HCI_Core6.Controller;
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

namespace KoD_Library_HCI_Core6.Views
{
    /// <summary>
    /// Interaction logic for BookDetailsPage.xaml
    /// </summary>
    public partial class BookDetailsPage : Page
    {
        private KnjigaController _knjigaController = new KnjigaController();
        private AutorController _autorController = new AutorController();
        private ZanrController _zanrController = new ZanrController();

        private List<Control> _controls = new List<Control>();
        private bool isUpdate { get; set; } = false;

        public BookDetailsPage(uint userTypeID, KnjigaViewModel? book, bool isBookUpdate = false)
        {
            InitializeComponent();
            if (userTypeID == (uint)TipNalogaEnum.Korisnik)
            {
                InitializeComponentForLoggedUser(userTypeID, book, isBookUpdate);
            }
            else if (userTypeID == (uint)TipNalogaEnum.Zaposleni)
            {
                isUpdate = isBookUpdate;
                InitializeComponentForLoggedUser(userTypeID, book, isBookUpdate);
            }
        }

        public BookDetailsPage(KnjigaViewModel knjiga)
        {
            InitializeComponent();
            InitializeComponentForKorisnik(knjiga);
        }

        private List<Control> addControlsToControlList()
        {
            _controls = new List<Control>();
            _controls.Add(tbNaslovKnjige);
            _controls.Add(tbGodinaIzdanja);
            _controls.Add(tbOpis);
            _controls.Add(tbNoviAutor);
            _controls.Add(tbNoviZanr);
            _controls.Add(tbKolicina);
            _controls.Add(tbDostupnaKolicina);
            _controls.Add(cbAutori);
            _controls.Add(cbSelectedAutori);
            _controls.Add(cbZanrovi);
            _controls.Add(cbSelectedZanrovi);
            _controls.Add(btnAddToCbAutori);
            _controls.Add(btnAddToCbZanrovi);
            _controls.Add(btnAddNewAutor);
            _controls.Add(btnAddNewZanr);
            _controls.Add(btnAddOrUpdateBook);
            // _controls.Add(btnRentABook);
            _controls.Add(chbMultipleAutor);
            _controls.Add(chbMultipleZanr);
            _controls.Add(chbDostupnost);
            return _controls;
        }

        public void InitializeComponentForLoggedUser(uint userTypeID, KnjigaViewModel? knjigaVM = null, bool isBookUpdate = false)
        {
            if (userTypeID == (uint)TipNalogaEnum.Korisnik)
            {
                gbBookInfo.Header = "Knjiga Info";
                _controls = addControlsToControlList();
                foreach (Control ctr in _controls)
                {
                    if (ctr.GetType() == typeof(Button) ||
                       ctr.GetType() == typeof(CheckBox))
                    {
                        ctr.IsEnabled = false;
                    }
                    else if (ctr.GetType() == typeof(ComboBox))
                    {
                        ComboBox cmb = (ComboBox)ctr;
                        cmb.IsReadOnly = true;
                    }
                    else if (ctr.GetType() == typeof(TextBox))
                    {
                        TextBox t = (TextBox)ctr;
                        t.IsReadOnly = true;
                    }
                }
                cbAutori.ItemsSource = knjigaVM.AutoriList;
                cbAutori.SelectedItem = knjigaVM.AutoriList?.ElementAt(0); // <=>  cbAutori.SelectedItem = knjiga.AutoriList[0];

                cbZanrovi.ItemsSource = knjigaVM.ZanroviList;
                cbZanrovi.SelectedItem = knjigaVM.ZanroviList?.ElementAt(0); // <=> cbZanrovi.SelectedItem = knjiga.ZanroviList[0];

                btnAddOrUpdateBook.Visibility = Visibility.Hidden; // <=> btnNovaKnjiga.Visibility = Visibility.Collapsed;

                tbNaslovKnjige.Text = knjigaVM.Naslov;
                tbOpis.Text = knjigaVM.Opis;
                tbGodinaIzdanja.Text = knjigaVM.GodinaIzdanja.ToString();
                tbKolicina.Text = knjigaVM.Kolicina.ToString();
                tbDostupnaKolicina.Text = knjigaVM.DostupnaKolicina.ToString();

                tbKolicina.Visibility = Visibility.Hidden | Visibility.Collapsed;
                lbKolicina.Visibility = Visibility.Hidden;
                tbDostupnaKolicina.Visibility = Visibility.Hidden;
                lbDostupnaKolicina.Visibility = Visibility.Hidden;

                if (knjigaVM.Dostupnost == true)
                    chbDostupnost.IsChecked = true;
                else
                    chbDostupnost.IsChecked = false;
                chbDostupnost.Focusable = false;
            }
            else if(userTypeID == (uint)TipNalogaEnum.Zaposleni)
            {
                if (isBookUpdate == true && knjigaVM != null) // UPDATE
                {
                    gbBookInfo.Header = "Knjiga Info";
                    btnAddOrUpdateBook.Content = "Sačuvaj izmjene";

                    cbAutori.ItemsSource = knjigaVM.AutoriList;
                    cbAutori.SelectedItem = knjigaVM.AutoriList?.ElementAt(0); // <=>  cbAutori.SelectedItem = knjiga.AutoriList[0];

                    cbZanrovi.ItemsSource = knjigaVM.ZanroviList;
                    cbZanrovi.SelectedItem = knjigaVM.ZanroviList?.ElementAt(0); // <=> cbZanrovi.SelectedItem = knjiga.ZanroviList[0];

                    btnAddOrUpdateBook.Visibility = Visibility.Visible; // <=> btnNovaKnjiga.Visibility = Visibility.Collapsed;

                    tbNaslovKnjige.Text = knjigaVM.Naslov;
                    tbOpis.Text = knjigaVM.Opis;
                    tbGodinaIzdanja.Text = knjigaVM.GodinaIzdanja.ToString();
                    tbKolicina.Text = knjigaVM.Kolicina.ToString();
                    tbDostupnaKolicina.Text = knjigaVM.DostupnaKolicina.ToString();

                    tbKolicina.Visibility = Visibility.Visible;
                    lbKolicina.Visibility = Visibility.Visible;
                    tbDostupnaKolicina.Visibility = Visibility.Visible;
                    lbDostupnaKolicina.Visibility = Visibility.Visible;

                    if (knjigaVM.Dostupnost == true)
                        chbDostupnost.IsChecked = true;
                    else
                        chbDostupnost.IsChecked = false;
                    chbDostupnost.IsEnabled = false;
                    
                }
                else if (isBookUpdate == false && knjigaVM == null) // INSERT
                {
                    gbBookInfo.Header = " Nova knjiga";
                    // btnRentABook.IsEnabled = false;
                    cbAutori.ItemsSource = _autorController.GetAllAuthors();
                    cbZanrovi.ItemsSource = _zanrController.GetAllGenres();
                    lbDostupnost.Visibility = Visibility.Hidden;
                    chbDostupnost.Visibility = Visibility.Hidden;
                }
            }
        }

        private void InitializeComponentForZaposleni(KnjigaViewModel? knjigaVM = null, bool isBookUpdate = false)
        {
            if(isBookUpdate == true && knjigaVM != null)
            {
                cbAutori.ItemsSource = knjigaVM.AutoriList;
                cbAutori.SelectedItem = knjigaVM.AutoriList?.ElementAt(0); // <=>  cbAutori.SelectedItem = knjiga.AutoriList[0];

                cbZanrovi.ItemsSource = knjigaVM.ZanroviList;
                cbZanrovi.SelectedItem = knjigaVM.ZanroviList?.ElementAt(0); // <=> cbZanrovi.SelectedItem = knjiga.ZanroviList[0];

                btnAddOrUpdateBook.Visibility = Visibility.Visible; // <=> btnNovaKnjiga.Visibility = Visibility.Collapsed;

                tbNaslovKnjige.Text = knjigaVM.Naslov;
                tbOpis.Text = knjigaVM.Opis;
                tbGodinaIzdanja.Text = knjigaVM.GodinaIzdanja.ToString();
                tbKolicina.Text = knjigaVM.Kolicina.ToString();
                tbDostupnaKolicina.Text = knjigaVM.DostupnaKolicina.ToString();

                tbKolicina.Visibility = Visibility.Visible;
                lbKolicina.Visibility = Visibility.Visible;
                tbDostupnaKolicina.Visibility = Visibility.Visible;
                lbDostupnaKolicina.Visibility = Visibility.Visible;

                if (knjigaVM.Dostupnost == true)
                    chbDostupnost.IsChecked = true;
                else
                    chbDostupnost.IsChecked = false;
                chbDostupnost.Focusable = false;
            }
            else if(isBookUpdate == false && knjigaVM == null)
            {
                cbAutori.ItemsSource = _autorController.GetAllAuthors();
                cbZanrovi.ItemsSource = _zanrController.GetAllGenres();
            }
            return;
        }

        private void InitializeComponentForKorisnik(KnjigaViewModel knjigaVM)
        {
            gbBookInfo.Header = "Knjiga Info";

            _controls = addControlsToControlList();
            foreach (Control ctr in _controls)
            {
                if (ctr.GetType() == typeof(Button) ||
                   ctr.GetType() == typeof(CheckBox))
                {
                    ctr.IsEnabled = false;
                }
                else if (ctr.GetType() == typeof(ComboBox))
                {
                    ComboBox cmb = (ComboBox)ctr;
                    cmb.IsReadOnly = true;
                }
                else if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox t = (TextBox)ctr;
                    t.IsReadOnly = true;
                }
            }
            cbAutori.ItemsSource = knjigaVM.AutoriList;
            cbAutori.SelectedItem = knjigaVM.AutoriList?.ElementAt(0); // <=>  cbAutori.SelectedItem = knjiga.AutoriList[0];

            cbZanrovi.ItemsSource = knjigaVM.ZanroviList;
            cbZanrovi.SelectedItem = knjigaVM.ZanroviList?.ElementAt(0); // <=> cbZanrovi.SelectedItem = knjiga.ZanroviList[0];

            btnAddOrUpdateBook.Visibility = Visibility.Hidden; // <=> btnNovaKnjiga.Visibility = Visibility.Collapsed;

            tbNaslovKnjige.Text = knjigaVM.Naslov;
            tbOpis.Text = knjigaVM.Opis;
            tbGodinaIzdanja.Text = knjigaVM.GodinaIzdanja.ToString();
            tbKolicina.Text = knjigaVM.Kolicina.ToString();
            tbDostupnaKolicina.Text = knjigaVM.DostupnaKolicina.ToString();

            tbKolicina.Visibility = Visibility.Hidden | Visibility.Collapsed;
            lbKolicina.Visibility = Visibility.Hidden;
            tbDostupnaKolicina.Visibility = Visibility.Hidden;
            lbDostupnaKolicina.Visibility = Visibility.Hidden;

            if (knjigaVM.Dostupnost == true)
                chbDostupnost.IsChecked = true;
            else
                chbDostupnost.IsChecked = false;
            chbDostupnost.Focusable = false;
            return;
        }

        private void btnAddNewAutor_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnAddNewAutor_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNoviAutor.Text))
            {
                MessageBox.Show("Molimo unesite ime i prezime autora", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            AutorViewModel noviAutor = new AutorViewModel()
            {
                ImePrezime = tbNoviAutor.Text
            };
            if (_autorController.CreateNewAutor(noviAutor))
            {
                MessageBox.Show("Uspješno ste dodali novog autora!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                cbAutori.ItemsSource = _autorController.GetAllAuthors();
                cbAutori.SelectedItem = noviAutor.ImePrezime;
                tbNoviAutor.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Već postoji autor sa tim imenom i prezimenom! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbNoviAutor.Text = String.Empty;
            }

        }

        private void btnAddNewZanr_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNoviZanr.Text))
            {
                MessageBox.Show("Molimo unesite naziv žanra", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            ZanrViewModel noviZanr = new ZanrViewModel()
            {
                NazivZanra = tbNoviZanr.Text
            };
            if (_zanrController.CreateNewZanr(noviZanr))
            {
                MessageBox.Show("Uspješno ste dodali novi žanr!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                cbZanrovi.ItemsSource = _zanrController.GetAllGenres();
                cbZanrovi.SelectedItem = noviZanr.NazivZanra;
                tbNoviZanr.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Već postoji žanr sa tim nazivom! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                tbNoviZanr.Text = String.Empty;
            }
        }

        private void btnAddNewZanr_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnAddOrUpdateBook_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNaslovKnjige.Text) ||
               string.IsNullOrEmpty(tbGodinaIzdanja.Text) ||
               string.IsNullOrEmpty(tbOpis.Text) ||
               string.IsNullOrEmpty(tbKolicina.Text) ||
               string.IsNullOrEmpty(cbAutori.Text) ||
               string.IsNullOrEmpty(cbZanrovi.Text))
            {
                MessageBox.Show("Molimo popunite sve potrebne podatke!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if ((UInt32.Parse(tbGodinaIzdanja.Text) > DateTime.Now.Year) ||
                (UInt32.Parse(tbGodinaIzdanja.Text) < 0))
            {
                MessageBox.Show("Godina izdanja knjige nije validna! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if ((UInt32.Parse(tbKolicina.Text) < 1))
            {
                MessageBox.Show("Količina nije validna! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<string> selectedAutoriList = new List<string>();
            if (chbMultipleAutor.IsChecked == false) // Kada knjiga ima samo jednog autora, onda je checkbox nepotreban
            {
                if (cbAutori.SelectedItem != null)
                    selectedAutoriList.Add(cbAutori.SelectedItem.ToString());
            }
            else
            {
                selectedAutoriList = initializeList(cbSelectedAutori);
            }

            List<string> selectedZanroviList = new List<string>();
            if (chbMultipleZanr.IsChecked == false) // Kada knjiga ima samo jedan žanr, onda je checkbox nepotreban
            {
                if (cbZanrovi.SelectedItem != null)
                    selectedZanroviList.Add(cbZanrovi.SelectedItem.ToString());
            }
            else
            {
                selectedZanroviList = initializeList(cbSelectedZanrovi);
            }

            KnjigaViewModel novaKnjiga = new KnjigaViewModel()
            {
                Naslov = tbNaslovKnjige.Text,
                GodinaIzdanja = UInt32.Parse(tbGodinaIzdanja.Text),
                Opis = tbOpis.Text,
                Dostupnost = chbDostupnost.IsChecked == true ? true : false,
                Kolicina = UInt32.Parse(tbKolicina.Text),
                DostupnaKolicina = Int32.Parse(tbKolicina.Text),
                AutoriList = selectedAutoriList,
                ZanroviList = selectedZanroviList,
            };
            if(isUpdate == true) // UPDATE
            {
                var updateResult = _knjigaController.UpdateBook(novaKnjiga);
                if(updateResult == true)
                {
                    MessageBox.Show("Uspješno ste ažurirali knjigu!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Greška prilikom ažuriranja knjige!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return;
            }
            else // INSERT
            {
                bool insertResult = _knjigaController.CreateNewKnjiga(novaKnjiga);
                if (insertResult == true)
                {
                    MessageBox.Show("Uspješno ste dodali novu knjigu!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Već postoji knjiga sa tim naslovom! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }   
            }

                
        }

        private List<string> initializeList(ComboBox cb)
        {
            List<string> selectedComboBoxList = new List<string>();
            foreach (var item in cb.Items)
            {
                selectedComboBoxList.Add(item.ToString());
            }
            return selectedComboBoxList;
        }

        private void tbNoviAutor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void chbMultipleAutor_Checked(object sender, RoutedEventArgs e)
        {
            cbSelectedAutori.IsEnabled = true;
        }

        private void chbMultipleAutor_Unchecked(object sender, RoutedEventArgs e)
        {
            cbSelectedAutori.IsEnabled = false;
        }

        private void chbMultipleZanr_Checked(object sender, RoutedEventArgs e)
        {
            cbSelectedZanrovi.IsEnabled = true;
        }

        private void chbMultipleZanr_Unchecked(object sender, RoutedEventArgs e)
        {
            cbSelectedZanrovi.IsEnabled = false;
        }


        private void btnAddToCbAutori_Click(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() == typeof(Button))
                ComboBoxMultipleAdd(cbAutori, cbSelectedAutori, chbMultipleAutor, "Autor");
            return;
        }

        private void btnAddToCbZanrovi_Click(object sender, RoutedEventArgs e)
        {
            // if (sender is Button)
            if (sender.GetType() == typeof(Button))
                ComboBoxMultipleAdd(cbZanrovi, cbSelectedZanrovi, chbMultipleZanr, "Zanr");
            return;
        }

        private void ComboBoxMultipleAdd(ComboBox cbSource, ComboBox cbToFill, CheckBox chb, string objType)
        {
            if (chb.IsChecked == false)
                return;

            if (cbSource.SelectedItem != null)
            {
                if (cbToFill.Items.Contains(cbSource.SelectedItem))
                {
                    if (objType.Equals("Autor"))
                        MessageBox.Show("Već ste izabrali autora sa tim imenom! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    else if (objType.Equals("Zanr"))
                        MessageBox.Show("Već ste izabrali žanr sa tim nazivom! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                cbToFill.Items.Add(cbSource.SelectedItem);
                cbToFill.SelectedItem = cbSource.SelectedItem;
            }
            return;

        }

        private void btnRentABook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbKolicina_SelectionChanged(object sender, RoutedEventArgs e)
        {
            tbDostupnaKolicina.IsEnabled = true;
        }

        private void gbBookInfo_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }

}
