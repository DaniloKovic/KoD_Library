using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.Enums;
using KoD_Library_HCI_Core6.Models.ViewModel;
using KoD_Library_HCI_Core6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Controller
{
    public class NalogController
    {
        private readonly NalogRepository _nalogRepository = new NalogRepository();

        public NalogController()
        {

        }

        public Nalog? GetUserByUsername(string? username)
        {
            if (username == null)
                return null;
            return _nalogRepository.GetByName(username);
        }

        public NalogViewModel? GetUserById(uint nalogId)
        {
            Nalog? nalog = _nalogRepository.Get(nalogId);
            // Nalog? nalogg= _nalogRepository.FindBy(n => n.Id == nalogId);
            if(nalog != null)
            {
                NalogViewModel nalogResultVM = new NalogViewModel()
                {
                    Id = nalog.Id,
                    ImePrezime = nalog.ImePrezime,
                    KorisnickoIme = nalog.KorisnickoIme,
                    BrojTelefona = nalog.BrojTelefona,
                    EMail = nalog.EMail,
                    Lozinka = nalog.Lozinka,
                    DatumRegistracije = nalog.DatumRegistracije,
                };
                nalogResultVM.TrenutniBrojRezervacija = _nalogRepository.NumberOfCurrentBookRentsByUser(n => n.Id == nalogId);
                nalogResultVM.UkupanBrojRezervacija = _nalogRepository.TotalNumberOfBookRentsByUser(n => n.Id == nalogId);
                return nalogResultVM;
            }
            return null;
        }

        public NalogViewModel? GetUser(System.Linq.Expressions.Expression<Func<Nalog, bool>> predicate)
        {
            if (predicate == null)
                return null;

            Nalog? nalog = _nalogRepository.FindBy(predicate);
            if (nalog != null)
            {
                NalogViewModel nalogResultVM = new NalogViewModel()
                {
                    Id = nalog.Id,
                    ImePrezime = nalog.ImePrezime,
                    KorisnickoIme = nalog.KorisnickoIme,
                    BrojTelefona = nalog.BrojTelefona,
                    EMail = nalog.EMail,
                    Lozinka = nalog.Lozinka,
                    DatumRegistracije = nalog.DatumRegistracije,
                };
                nalogResultVM.TrenutniBrojRezervacija = _nalogRepository.NumberOfCurrentBookRentsByUser(n => n.Id == nalog.Id);
                nalogResultVM.UkupanBrojRezervacija = _nalogRepository.TotalNumberOfBookRentsByUser(n => n.Id == nalog.Id);
                return nalogResultVM;
            }
            return null;
        }

        public List<NalogViewModel>? GetAllUsers()
        {
            return _nalogRepository.GetAllKorisnikUsers()?.Select(el => new NalogViewModel()
            {
                Id = el.Id,
                ImePrezime = el.ImePrezime,
                KorisnickoIme = el.KorisnickoIme,
                DatumRegistracije = el.DatumRegistracije,
                BrojTelefona = el.BrojTelefona,
                EMail = el.EMail,
                Lozinka = el.Lozinka,
            }).OrderBy(el => el.KorisnickoIme).ToList();
        }

        public int? LoginAttempt(string korisnickoIme, string lozinka)
        {
            var nalog = _nalogRepository.CheckLoginAttempt(korisnickoIme, lozinka);
            if(nalog == null)
            {
                return null;
            }
            if(nalog.TipNalogaId == (int)TipNalogaEnum.Korisnik)
            {
                LoggedUserHelper.currentUserID = nalog.Id;
                LoggedUserHelper.currentUserTypeId = (int)TipNalogaEnum.Korisnik;
                LoggedUserHelper.currentUserTemplateID = nalog.UserTemplate;
                return (int)TipNalogaEnum.Korisnik;
            }
            if(nalog.TipNalogaId == (int)TipNalogaEnum.Zaposleni)
            {
                LoggedUserHelper.currentUserID = nalog.Id;
                LoggedUserHelper.currentUserTypeId = (int)TipNalogaEnum.Zaposleni;
                LoggedUserHelper.currentUserTemplateID = nalog.UserTemplate;
                return (int)TipNalogaEnum.Zaposleni;
            }
            return null;
        }

        public int ChangePassword(uint nalogId, string newPassword)
        {
            Nalog? nalogToUpdate = _nalogRepository.FindBy(n => n.Id == nalogId);
            if (nalogToUpdate != null)
            {
                nalogToUpdate.Lozinka = newPassword;
                int nalogUpdateResult = _nalogRepository.Update(nalogToUpdate);
                return nalogUpdateResult;
            }
            return 0;
        }

        public bool RegistrationAtempt(string username, string password)
        {
            return _nalogRepository.CheckIfUsernameOrPasswordAlreadyExist(username, password);
        }

        public int UpdateUserTemplate(uint userID, uint templateID)
        {
            Nalog? nalog = _nalogRepository.FindBy(n => n.Id == userID);
            nalog.UserTemplate = templateID;
            return _nalogRepository.Update(nalog);
        }

        public void AddNewRegisteredUser(Nalog noviNalog)
        {
            _nalogRepository.AddNewRecord(noviNalog);
        }

        

        
    }
}
