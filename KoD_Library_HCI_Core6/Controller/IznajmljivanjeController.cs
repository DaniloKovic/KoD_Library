using KoD_Library_HCI_Core6.Data;
using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.Enums;
using KoD_Library_HCI_Core6.Models.ViewModel;
using KoD_Library_HCI_Core6.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KoD_Library_HCI_Core6.Controller
{
    public class IznajmljivanjeController
    {
        private readonly KnjigaRepository _knjigaRepository = new KnjigaRepository();
        private readonly AutorRepository _autorRepository = new AutorRepository();
        private readonly ZanrRepository _zanrRepository = new ZanrRepository();
        private readonly IznajmljivanjeRepository _iznajmljivanjeRepository = new IznajmljivanjeRepository();
        private readonly NalogRepository _nalogRepository = new NalogRepository();

        public IznajmljivanjeController()
        {
            
        }

        public List<IznajmljivanjeViewModel> GetAllBookRentals(uint currentUserTypeID, uint currentUserID)
        {
            if (currentUserTypeID == (uint)TipNalogaEnum.Zaposleni)
            {
                return _iznajmljivanjeRepository.GetAllRentals().Select(el => new IznajmljivanjeViewModel
                {
                    Id = el.Id,
                    DatumOd = el.DatumOd,
                    DatumDo = el.DatumDo,
                    Knjiga = el.Knjiga,
                    NaslovKnjige = el.Knjiga.Naslov,
                    Nalog = el.Nalog,
                    ImeNalog = el.Nalog.KorisnickoIme,
                    IsVracena = el.IsVracena,
                }).ToList();
            }
            else if (currentUserTypeID == (uint)TipNalogaEnum.Korisnik)
            {
                return _iznajmljivanjeRepository.GetAllRentalsByUser(currentUserID).Select(el => new IznajmljivanjeViewModel
                {
                    Id = el.Id,
                    DatumOd = el.DatumOd,
                    DatumDo = el.DatumDo,
                    Knjiga = el.Knjiga,
                    NaslovKnjige = el.Knjiga.Naslov,
                    Nalog = el.Nalog,
                    ImeNalog = el.Nalog.KorisnickoIme,
                    IsVracena = el.IsVracena,
                }).ToList();
            }
            return null;
        }

        public bool UpdateBookRental(IznajmljivanjeViewModel? selectedRental)
        {
            if (selectedRental == null)
                return false;

            Iznajmljuje? iznajmljivanjeToUpdate = _iznajmljivanjeRepository.Get(selectedRental.Id);
            if (iznajmljivanjeToUpdate != null)
            {
                if (iznajmljivanjeToUpdate.IsVracena != selectedRental.IsVracena)
                {
                    iznajmljivanjeToUpdate.IsVracena = selectedRental.IsVracena;
                    _iznajmljivanjeRepository.Update(iznajmljivanjeToUpdate);
                    Knjiga? bookToUpdate = _knjigaRepository.Get(iznajmljivanjeToUpdate.KnjigaId);
                    if (selectedRental.IsVracena == true) // Samo ako je cekirano znači da se treba promijeniti dostupnost knjige za 1 vise
                    {
                        bookToUpdate.DostupnaKolicina += 1;
                        int updateResult = _knjigaRepository.Update(bookToUpdate);
                        if (updateResult == 1)
                            return true;
                    }
                    else if (selectedRental.IsVracena == false)
                    {
                        bookToUpdate.DostupnaKolicina -= 1;
                        int updateResult = _knjigaRepository.Update(bookToUpdate);
                        if (updateResult == 1)
                            return true;
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Niste promijenili stanje! Pokušajte ponovo!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
                return false;
        }

        public List<IznajmljivanjeViewModel> GetAllBookRentalsByEmployee()
        {
            if(LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Zaposleni)
            {
                return _iznajmljivanjeRepository.GetAllRentals().Select(el => new IznajmljivanjeViewModel
                {
                    DatumOd = el.DatumOd,
                    DatumDo = el.DatumDo,
                    Knjiga = el.Knjiga,
                    Nalog = el.Nalog,
                    IsVracena = el.IsVracena,
                }).ToList();
            }
            return null;
        }

        public List<IznajmljivanjeViewModel> GetAllBookRentalsByUser()
        {
            if (LoggedUserHelper.currentUserTypeId == (uint)TipNalogaEnum.Korisnik)
            {
                return _iznajmljivanjeRepository.GetAllRentalsByUser(LoggedUserHelper.currentUserID).Select(el => new IznajmljivanjeViewModel
                {
                    DatumOd = el.DatumOd,
                    DatumDo = el.DatumDo,
                    Knjiga = el.Knjiga,
                    Nalog = el.Nalog,
                    IsVracena = el.IsVracena,
                }).ToList();
            }
            return null;
        }

        public bool InsertNewBookRental(IznajmljivanjeViewModel novoIznajmljivanjeViewModel)
        {
            Knjiga? bookToRent = _knjigaRepository.GetKnjiga(novoIznajmljivanjeViewModel.NaslovKnjige);
            if (bookToRent != null)
            {
                if (bookToRent.DostupnaKolicina < 1)
                {
                    MessageBox.Show("Knjiga trenutno nije dostupna. Pokušajte kasnije!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                bookToRent.DostupnaKolicina -= 1;
            }
            else
                throw new Exception("Greška prilikom iznajmljivanja knjige.");

            Nalog? userWhoRentsBook = _nalogRepository.GetByName(novoIznajmljivanjeViewModel.ImeNalog);
            if(userWhoRentsBook == null)
                throw new Exception("Greška prilikom iznajmljivanja knjige.");

            //Expression<Func<Nalog, bool>> predicate = el => el.KorisnickoIme.Equals(novoIznajmljivanjeViewModel.ImeNalog); -> OVO RADI
            //Nalog? userWhoRentsBookk = _nalogRepository.FindBy(el => el.KorisnickoIme.Equals(novoIznajmljivanjeViewModel.ImeNalog));
            //Nalog? userWhoRentsBookkk = _nalogRepository.FindBy(predicate);

            Iznajmljuje newBookRental = new Iznajmljuje()
            {
                KnjigaId = bookToRent.Id,
                // Knjiga = bookToRent, ???

                NalogId = userWhoRentsBook.Id,
                // Nalog = userWhoRentsBook, ???

                DatumOd = novoIznajmljivanjeViewModel.DatumOd,
                DatumDo = novoIznajmljivanjeViewModel.DatumDo,
                IsVracena = false
            };

            // Ovo je Transakcija
            var result = _iznajmljivanjeRepository.InsertNewRental(newBookRental, bookToRent);
            if (result == 2)
                return true;
            return false;

            /*
            int insertResult = _iznajmljivanjeRepository.AddNewRecord(newBookRental); // 
            if (insertResult == 1)
            {
                bookToRent.DostupnaKolicina -= 1;
                _knjigaRepository.Update(bookToRent);
                return true;
            }
            return false;
            */
        }
    }
}
