using KoD_Library_HCI_Core6.Data;
using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Repository
{
    public class IznajmljivanjeRepository : BaseRepository<Iznajmljuje> , IIznajmljivanjeRepository
    {

        public IznajmljivanjeRepository() : base()
        {

        }

        public IznajmljivanjeRepository(DataContext context) : base(context) 
        {

        }

        public List<Iznajmljuje> GetAllRentals()
        {
            List<Iznajmljuje> rentals = null;
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                rentals = ctx.Iznajmljuje.Include(el => el.Knjiga)
                                         .Include(el => el.Nalog)
                                         .OrderBy(el => el.DatumOd)
                                         .OrderBy(el => el.IsVracena == true)
                                         .ToList();
            }
            if(rentals != null)
                return rentals;
            return null;
        }

        public List<Iznajmljuje> GetAllRentalsByUser(string username)
        {
            List<Iznajmljuje> rentals = null;
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                rentals = ctx.Iznajmljuje.Include(el => el.Knjiga)
                                         .Include(el => el.Nalog)
                                         .Where(el => el.Nalog.ImePrezime.Equals(username))
                                         .OrderBy(el => el.DatumOd)
                                         .OrderBy(el => el.IsVracena == false)
                                         .ToList();
            }
            if (rentals != null)
                return rentals;
            return null;
        }

        public List<Iznajmljuje> GetAllRentalsByUser(Nalog nalog)
        {
            List<Iznajmljuje> rentals = null;
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                rentals = ctx.Iznajmljuje.Include(el => el.Knjiga)
                                         .Include(el => el.Nalog)
                                         .Where(el => el.NalogId == nalog.Id)
                                         .OrderBy(el => el.DatumOd)
                                         .ToList();
            }
            if (rentals != null)
                return rentals;
            return null;
        }

        public List<Iznajmljuje> GetAllRentalsByUser(uint id)
        {
            List<Iznajmljuje> rentals = null;
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                rentals = ctx.Iznajmljuje.Include(el => el.Knjiga)
                                         .Include(el => el.Nalog)
                                         .Where(el => el.NalogId == id)
                                         .OrderBy(el => el.DatumOd)
                                         .OrderBy(el => el.IsVracena == true)
                                         .ToList();
            }
            if (rentals != null)
                return rentals;
            return null;
        }

        public int InsertNewRental(Iznajmljuje newBookRental, Knjiga bookToRent)
        {
            int result = -1;
            using (_context = new DataContext(optionsBuilder.Options))
            {
                // _context.Iznajmljuje?.Add(newBookRental);
                _context.Set<Iznajmljuje>().Add(newBookRental);

                //_context.Knjiga?.Update(bookToRent); // -> OVO NE RADI
                // _context.Set<Knjiga>().Update(bookToRent); // -> OVO NE RADI
                _context.Entry(bookToRent).State = EntityState.Modified;
                result = _context.SaveChanges();
            }
            return result;
        }
    }
}
