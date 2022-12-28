using KoD_Library_HCI_Core6.Controller;
using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Enums;
using KoD_Library_HCI_Core6.Models.ViewModel;
using KoD_Library_HCI_Core6.Views.Menu;
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
    /// Interaction logic for MyAccountPage.xaml
    /// </summary>
    public partial class MyAccountPage : Page
    {
        private NalogController _nalogController = new NalogController();
        private Window _window;
        private Grid _windowGrid = new Grid();
        private List<DockPanel> _dockPanelList = new List<DockPanel>();

        // Konstruktor za Korisnika
        public MyAccountPage()
        {
            InitializeComponent();
            NalogViewModel? nalogVM = _nalogController.GetUser(n => n.Id == LoggedUserHelper.currentUserID);
            // NalogViewModel? nalogVM = _nalogController.GetUserById(LoggedUserHelper.currentUserID);
            if (nalogVM != null)
            {
                tbBrojTelefona.Text = nalogVM.BrojTelefona;
                tbKorisnickoIme.Text = nalogVM.KorisnickoIme;
                tbImePrezime.Text = nalogVM.ImePrezime;
                tbEmail.Text = nalogVM.EMail;
                tbDatumRegistracije.Text = nalogVM.DatumRegistracije.ToString();
                pbLozinka.Password = nalogVM.Lozinka;
                tbTrenutniBroj.Text = nalogVM.TrenutniBrojRezervacija.ToString();
                tbUkupniBroj.Text = nalogVM.UkupanBrojRezervacija.ToString();
            }
            if(LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                spBrIznajmljenihK.Visibility = Visibility.Collapsed;
                spUkupanBrIznajmljenihK.Visibility = Visibility.Collapsed;
            }
        }

        // Konstruktor za Zaposlenog
        public MyAccountPage(NalogViewModel? nalogVM)
        {
            InitializeComponent();
            if (nalogVM == null)
                throw new ArgumentNullException(nameof(nalogVM));

            NalogViewModel? nalogVMResult = _nalogController.GetUser(n => n.KorisnickoIme.Equals(nalogVM.KorisnickoIme));

            spInnerSP2.Visibility = Visibility.Collapsed;
            spLozinka.Visibility = Visibility.Collapsed;
            spPromjenaLozinke.Visibility = Visibility.Collapsed;

            tbImePrezime.Text = nalogVM.ImePrezime;
            tbKorisnickoIme.Text = nalogVM.KorisnickoIme;
            tbBrojTelefona.Text = nalogVM.BrojTelefona;
            tbEmail.Text = nalogVM.EMail;
            tbDatumRegistracije.Text = nalogVM.DatumRegistracije.ToString();  
            tbTrenutniBroj.Text = nalogVMResult.TrenutniBrojRezervacija.ToString();
            tbUkupniBroj.Text = nalogVMResult.UkupanBrojRezervacija.ToString();
        }


        private void btnPromjenaLozinke_Click(object sender, RoutedEventArgs e)
        {
            if (spPromjenaLozinke.Visibility == Visibility.Collapsed)
            {
                spPromjenaLozinke.Visibility = Visibility.Visible;
            }
            else if (spPromjenaLozinke.Visibility == Visibility.Visible)
            {
                spPromjenaLozinke.Visibility = Visibility.Collapsed;
            }
        }

        private void btnPotvrdiPromjenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbNovaLozinka.Text) && tbNovaLozinka.Text.Equals(tbPotvrdiLozinku.Text) && tbNovaLozinka.Text.Length >= 8)
            {
                int updatePasswordResult = _nalogController.ChangePassword(LoggedUserHelper.currentUserID, tbNovaLozinka.Text);
                if(updatePasswordResult == 1)
                {
                    MessageBox.Show("Uspješno ste ažurirali lozinku!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if(updatePasswordResult == 0)
                {
                    MessageBox.Show("Greška prilikom ažuriranja lozinke! Pokušajte ponovo.", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if(tbNovaLozinka.Text.Equals("") || tbPotvrdiLozinku.Text.Equals(""))
            {
                MessageBox.Show("Molimo popunite odgovarajuća polja!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (!tbPotvrdiLozinku.Text.Equals(tbNovaLozinka.Text))
            {
                MessageBox.Show("Lozinke nisu podudarne! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
        }

        private void cbPrikaziLozinku_Checked(object sender, RoutedEventArgs e)
        {
            if(cbPrikaziLozinku.IsChecked == true)
            {
                pbLozinkaText.Text = pbLozinka.Password;
                pbLozinkaText.Visibility = Visibility.Visible;
            }
        }

        private void cbPrikaziLozinku_Unchecked(object sender, RoutedEventArgs e)
        {
            if(cbPrikaziLozinku.IsChecked == false)
            {
                pbLozinkaText.Visibility = Visibility.Collapsed;
            }
        }

        private void InitializeWindowChildren(Window? window, string themeIndex)
        {
            if (window == null)
                return;

            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik)
            {
                _window = (KorisnikMenu)window;
            }
            else if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                _window = (ZaposleniMenu)window;
            }
            var windowChildControls = LogicalTreeHelper.GetChildren(_window);
            _windowGrid = windowChildControls.OfType<Grid>().ElementAt(0);
            foreach (var gridChild in _windowGrid.Children)
            {
                if (gridChild.GetType() == typeof(DockPanel))
                {
                    DockPanel dockPanel = (DockPanel)gridChild;
                    if(!dockPanel.Name.Equals("dpZaposleniFrame") && !dockPanel.Name.Equals("dpKorisnikFrame"))
                        _dockPanelList.Add(dockPanel);
                }
            }
            foreach (var dockPanel in _dockPanelList)
            {
                dockPanel.Style = (Style)Application.Current.FindResource($"dpTemplateStyle{themeIndex}");
            }
        }

        private void btnTemplate1_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this);
            if(currentWindow == null)
            {
                MessageBox.Show("Greška prilikom izbora teme! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            InitializeWindowChildren(currentWindow,"1");
            var updateResult = _nalogController.UpdateUserTemplate(LoggedUserHelper.currentUserID, (uint)CustomTemplateEnum.DarkBlueTemplate);
        }

        private void btnTemplate2_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this);
            if (currentWindow == null)
            {
                MessageBox.Show("Greška prilikom izbora teme! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            InitializeWindowChildren(currentWindow,"2");
            var updateResult = _nalogController.UpdateUserTemplate(LoggedUserHelper.currentUserID, (uint)CustomTemplateEnum.CadetBlueTemplate);
        }

        private void btnTemplate3_Click(object sender, RoutedEventArgs e)
        {
            var currentWindow = Window.GetWindow(this);
            if (currentWindow == null)
            {
                MessageBox.Show("Greška prilikom izbora teme! Pokušajte ponovo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            InitializeWindowChildren(currentWindow,"3");
            var updateResult = _nalogController.UpdateUserTemplate(LoggedUserHelper.currentUserID, (uint)CustomTemplateEnum.DarkRedTemplate);
        }

        private void btnSrb_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Odabrali ste srpski jezik.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnEng_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mogućnost promjene jezika trenutno nije moguća. Pokušajte kasnije!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
