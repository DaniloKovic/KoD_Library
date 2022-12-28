using KoD_Library_HCI_Core6.Data;
using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Repository
{
    public class ZanrRepository : BaseRepository<Zanr> , IZanrRepository
    {

        public ZanrRepository() : base()
        {

        }
        public ZanrRepository(DataContext context) : base(context) {

        }

        public bool AddNewZanr(Zanr zanr)
        {
            using (_context = new DataContext(optionsBuilder.Options))
            {
                if(_context.Zanr.Any(z => z.Naziv.Equals(zanr.Naziv)))
                    return false;

                _context.Zanr.Add(zanr);
                _context.SaveChanges();
                return true;
            }
        }

        public Zanr? GetByNaziv(string naziv)
        {
            using (_context = new DataContext(optionsBuilder.Options))
            {
                var zanr = _context.Zanr.FirstOrDefault(z => z.Naziv.Equals(naziv));
                if (zanr == null)
                    return null;
                return zanr;
            }
        }

        
        public List<Zanr> GetAllGenres()
        {
            List<Zanr> zanrovi = null;
            using (var _context = new DataContext(optionsBuilder.Options))
            {
                zanrovi = _context.Zanr.OrderBy(z => z.Naziv).ToList();
            }
            return zanrovi;
        }
        
    }
}
