using KoD_Library_HCI_Core6.Controller;
using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.Enums;
using KoD_Library_HCI_Core6.Views.Menu;
using KoD_Library_HCI_Core6.Views.UserControls;
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

namespace KoD_Library_HCI_Core6.Views
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        private NalogController _nalogController = new NalogController();
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            if(this.Height < MaxHeight)
            {
                pnlRegistracija.Visibility = Visibility.Visible;
                this.Height = MaxHeight;
            }
            else if(this.Height == MaxHeight)
            {
                pnlRegistracija.Visibility = Visibility.Collapsed;
                this.Height = MinHeight;
            }

        }

        private void btnPotvrdiPrijavu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbKorisnickoIme.Text) || string.IsNullOrEmpty(pbLozinka.Password))
            {
                MessageBox.Show("Popunite sva potrebna polja!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Provjeravanje prijave
            int? result = _nalogController.LoginAttempt(tbKorisnickoIme.Text, pbLozinka.Password);
            if (result == (int)TipNalogaEnum.Korisnik) 
            {
                KorisnikMenu _korisnikMenu = new KorisnikMenu();
                _korisnikMenu.Show();
                this.Close();
            }
            else if(result == (int)TipNalogaEnum.Zaposleni)
            {
                ZaposleniMenu _zaposleniMenu = new ZaposleniMenu();
                _zaposleniMenu.Show();
                this.Close();
            }
            else if(result == null)
            {
                MessageBox.Show("Neispravno korisničko ime ili lozinka! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnPogledajLozinku_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnRegistracijaPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbImePrezime.Text) ||
                string.IsNullOrEmpty(tbKorisnickoImeReg.Text) || 
                string.IsNullOrEmpty(pbLozinkaReg.Password) ||
                string.IsNullOrEmpty(pbLozinkaRegPotvrda.Password) ||
                string.IsNullOrEmpty(tbBrojTelefona.Text) ||
                string.IsNullOrEmpty(tbEMail.Text))
            {
                MessageBox.Show("Popunite sva potrebna polja da biste se registrovali!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!pbLozinkaReg.Password.Equals(pbLozinkaRegPotvrda.Password))
            {
                MessageBox.Show("Lozinke nisu podudarne! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(pbLozinkaReg.Password.Length < 8 )
            {
                MessageBox.Show("Lozinka treba da sadrži najmanje 8 znakova", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (pbLozinkaReg.Password.All(char.IsLetter))
            {
                MessageBox.Show("Lozinka nije dovoljno jaka!", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            bool result = _nalogController.RegistrationAtempt(tbKorisnickoImeReg.Text, pbLozinkaRegPotvrda.Password);
            if (result == true)
            {
                MessageBox.Show("Registracija nije uspjela! Molimo unesite druge kredencijale!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Nalog noviNalog = new Nalog()
                {
                    ImePrezime = tbImePrezime.Text,
                    KorisnickoIme = tbKorisnickoImeReg.Text,
                    Lozinka = pbLozinkaReg.Password,
                    BrojTelefona = tbBrojTelefona.Text,
                    EMail = tbEMail.Text,
                    DatumRegistracije = DateOnly.FromDateTime(DateTime.Now),
                    TipNalogaId = (uint)TipNalogaEnum.Korisnik,
                    Iznajmljuje = null,
                };
                _nalogController.AddNewRegisteredUser(noviNalog);
                MessageBox.Show("Registracija je uspjela!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Height = this.MinHeight;
            }
        }

        private void cbPrikaziLozinku_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPrikaziLozinku.IsChecked == true)
            {
                pbLozinkaText.Text = pbLozinka.Password;
                pbLozinkaText.Visibility = Visibility.Visible;
            }
        }

        private void cbPrikaziLozinku_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbPrikaziLozinku.IsChecked == false)
            {
                pbLozinkaText.Visibility = Visibility.Collapsed;
            }
        }
    }
}
