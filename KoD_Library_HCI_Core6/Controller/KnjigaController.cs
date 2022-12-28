using KoD_Library_HCI_Core6.Data;
using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.ViewModel;
using KoD_Library_HCI_Core6.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KoD_Library_HCI_Core6.Controller
{
    public class KnjigaController
    {
        private readonly KnjigaRepository _knjigaRepository = new KnjigaRepository();
        private readonly AutorRepository _autorRepository = new AutorRepository();
        private readonly ZanrRepository _zanrRepository = new ZanrRepository();
        public KnjigaController()
        {
            
        }

        public KnjigaViewModel? GetBookByTitle(string title)
        {
            Knjiga? k = _knjigaRepository.GetKnjigaByNaslov(title);
            if(k != null)
            {
                KnjigaViewModel bookResult = new KnjigaViewModel()
                {
                    Id = k.Id,
                    Naslov = k.Naslov,
                    GodinaIzdanja = k.GodinaIzdanja,
                    Opis = k.Opis,
                    // Dostupnost = Convert.ToBoolean(k.Dostupnost),
                    Kolicina = k.Kolicina,
                    DostupnaKolicina = k.DostupnaKolicina,
                    AutoriList = k.Autor.Select(a => a.ImePrezime.ToString()).ToList(),
                    ZanroviList = k.Zanr.Select(z => z.Naziv.ToString()).ToList(),
                    Autori = ConvertListToString(k.Autor.Select(a => a.ImePrezime.ToString()).ToList()),
                    Zanrovi = ConvertListToString(k.Zanr.Select(z => z.Naziv.ToString()).ToList()),
                    AutoriArr = (k.Autor.Select(a => a.ImePrezime.ToString()).ToList()).ToArray(),
                    ZanroviArr = (k.Zanr.Select(z => z.Naziv.ToString()).ToList()).ToArray()
                };
                return bookResult;
            }
            return null;
           
        }

        public List<KnjigaViewModel> GetAllBooksByTitleFilter(string titleFilter)
        {

            return _knjigaRepository.GetAllByTitleFilter(titleFilter).Select(el => new KnjigaViewModel()
            {
                Id = el.Id,
                Naslov = el.Naslov,
            }).ToList();
        }

        public List<KnjigaViewModel> GetAll()
        {
            return _knjigaRepository.GetAllBooksWithAuthorsAndGenres().Select(k => new KnjigaViewModel()
            {
                Id = k.Id,
                Naslov = k.Naslov,
                GodinaIzdanja = k.GodinaIzdanja,
                Opis = k.Opis,
                // Dostupnost = Convert.ToBoolean(k.Dostupnost),
                Kolicina = k.Kolicina,
                DostupnaKolicina = k.DostupnaKolicina,
                Dostupnost = k.DostupnaKolicina > 0 ? true : false,
                AutoriList = k.Autor.Select(a => a.ImePrezime.ToString()).ToList(),
                ZanroviList = k.Zanr.Select(z => z.Naziv.ToString()).ToList(),
                Autori = ConvertListToString(k.Autor.Select(a => a.ImePrezime.ToString()).ToList()),
                Zanrovi = ConvertListToString(k.Zanr.Select(z => z.Naziv.ToString()).ToList()),
                AutoriArr = (k.Autor.Select(a => a.ImePrezime.ToString()).ToList()).ToArray(),
                ZanroviArr = (k.Zanr.Select(z => z.Naziv.ToString()).ToList()).ToArray()
            }).ToList();
        }

        public List<KnjigaViewModel> GetFilteredBooks(string filterByBookTitle, string filterByAuthorName, string filterByGenreType)
        {
            Autor? autor = _autorRepository.GetAutorByName(filterByAuthorName);
            Zanr? zanr = _zanrRepository.GetByNaziv(filterByGenreType);

            if(filterByAuthorName != null && autor == null)
                return null;

            var resultList = _knjigaRepository.GetAllBooksBySearchFilter(filterByBookTitle, autor, zanr).Select(k => new KnjigaViewModel()
            {
                Id = k.Id,
                Naslov = k.Naslov,
                GodinaIzdanja = k.GodinaIzdanja,
                Opis = k.Opis,
                Kolicina = k.Kolicina,
                DostupnaKolicina = k.DostupnaKolicina,
                Dostupnost = k.DostupnaKolicina > 0 ? true : false,
                AutoriList = k.Autor.Select(a => a.ImePrezime.ToString()).ToList(),
                ZanroviList = k.Zanr.Select(z => z.Naziv.ToString()).ToList(),
                Autori = ConvertListToString(k.Autor.Select(a => a.ImePrezime.ToString()).ToList()),
                Zanrovi = ConvertListToString(k.Zanr.Select(z => z.Naziv.ToString()).ToList()),
                AutoriArr = (k.Autor.Select(a => a.ImePrezime.ToString()).ToList()).ToArray(),
                ZanroviArr = (k.Zanr.Select(z => z.Naziv.ToString()).ToList()).ToArray()
            }).ToList();
            return resultList;
        }

        public bool CreateNewKnjiga(KnjigaViewModel? novaKnjigaVM)
        {
            if (novaKnjigaVM == null)
                return false;

            List<Autor> autori = new List<Autor>();
            foreach (var autorItem in novaKnjigaVM.AutoriList)
            {
                Autor? autor = _autorRepository.FindBy(autor => autor.ImePrezime.Equals(autorItem));
                if(autor != null)
                    autori.Add(autor);
            }

            List<Zanr> zanrovi = new List<Zanr>();
            foreach(var zanrItem in novaKnjigaVM.ZanroviList)
            {
                Zanr? zanr = _zanrRepository.FindBy(zanr => zanr.Naziv.Equals(zanrItem));
                if(zanr != null)
                    zanrovi.Add(zanr);
            }

            Knjiga novaKnjiga = new Knjiga()
            {
                // Id = 987,
                Naslov = novaKnjigaVM.Naslov,
                GodinaIzdanja = novaKnjigaVM.GodinaIzdanja,
                Opis = novaKnjigaVM.Opis,
                Kolicina = novaKnjigaVM.Kolicina,
                DostupnaKolicina = novaKnjigaVM.DostupnaKolicina,
                Autor = null,
                Zanr = null,
                Iznajmljuje = null
            };
            
            if (_knjigaRepository.AddNewKnjiga(novaKnjiga)) // Dodavanje nove knjige u bazu bez navigation properties
            {
                Knjiga? zadnjaKnjiga = _knjigaRepository.GetKnjigaByNaslov(novaKnjigaVM.Naslov);
                bool relatedPropertyInsert = true;
                foreach(var autorItem in autori)
                {
                    relatedPropertyInsert = _knjigaRepository.InsertKnjigaWithRelatedPropertiy<Autor>(zadnjaKnjiga.Id, autorItem.Id);
                }
                foreach(var zanrItem in zanrovi)
                {
                    relatedPropertyInsert = _knjigaRepository.InsertKnjigaWithRelatedPropertiy<Zanr>(zadnjaKnjiga.Id, zanrItem.Id);
                }
                if(relatedPropertyInsert)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public bool UpdateBook(KnjigaViewModel bookToUpdateVM)
        {
            if (String.IsNullOrEmpty(bookToUpdateVM.Naslov))
                return false;

            Knjiga? bookToUpdate = _knjigaRepository.GetKnjigaByNaslov(bookToUpdateVM.Naslov);
            if (bookToUpdate == null)
                return false;
            else
            {
                // bookToUpdate.Naslov = bookToUpdate.Naslov;
                bookToUpdate.Opis = bookToUpdateVM.Opis;
                bookToUpdate.GodinaIzdanja = bookToUpdateVM.GodinaIzdanja;
                bookToUpdate.Kolicina = bookToUpdateVM.Kolicina;
                bookToUpdate.DostupnaKolicina = bookToUpdateVM.DostupnaKolicina;

                int bookUpdateResult = _knjigaRepository.Update(bookToUpdate);
                if (bookUpdateResult == 1)
                    return true;
                return false;
            }
        }

        private string ConvertListToString(List<string> lista)
        {
            if (lista == null)
                return string.Empty;
            if (lista.Count == 1)
                return lista.ElementAt(0).ToString();

            StringBuilder sb = new StringBuilder();
            foreach (string str in lista)
            {
                sb.Append(str + ",\n");
            }
            return sb.ToString().TrimEnd('\n').TrimEnd(',');
        }
    }
}
