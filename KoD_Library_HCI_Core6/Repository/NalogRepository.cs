using KoD_Library_HCI_Core6.Data;
using KoD_Library_HCI_Core6.Helper;
using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Repository
{
    public class NalogRepository : BaseRepository<Nalog>, INalogRepository
    {
        public NalogRepository() : base()
        {

        }

        public NalogRepository(DataContext context) : base(context) 
        {

        }

        public Nalog? GetByName(string username)
        {
            using (var _context = new DataContext(optionsBuilder.Options))
            {
                return _context.Nalog?.FirstOrDefault(el => el.KorisnickoIme.Equals(username));
            }
        }

        public List<Nalog>? GetAllKorisnikUsers()
        {
            using (var _context = new DataContext(optionsBuilder.Options))
            {
                return _context.Nalog?.Where(el => el.TipNalogaId == (uint)TipNalogaEnum.Korisnik)
                                      .ToList();
            }
        }

        public Nalog? CheckLoginAttempt(string username, string password)
        {
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                Nalog? nalog = ctx.Nalog?.Where(n => n.KorisnickoIme.Equals(username) && 
                                                n.Lozinka.Equals(password)).FirstOrDefault();
                if (nalog == null)
                    return null;
                return nalog;
            }
        }

        public bool CheckIfUsernameOrPasswordAlreadyExist(string username, string password)
        {
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                return ctx.Nalog.Any(n => n.KorisnickoIme.Equals(username) || n.Lozinka.Equals(password));
            }
        }

        public int TotalNumberOfBookRentsByUser(System.Linq.Expressions.Expression<Func<Nalog, bool>> predicate)
        {
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                var result = ctx.Nalog?.Include(k => k.Iznajmljuje)
                                       .FirstOrDefault(predicate)?.Iznajmljuje
                                       .Count();
                if(result == null)
                {
                    return 0;
                }
                return (int)result; 
            }
        }
        public int NumberOfCurrentBookRentsByUser(System.Linq.Expressions.Expression<Func<Nalog, bool>> predicate)
        {
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                var result = ctx.Nalog?.Include(k => k.Iznajmljuje)
                                       .FirstOrDefault(predicate)?.Iznajmljuje
                                       .Where(iz => iz.IsVracena == false)?
                                       .Count();
                if(result == null)
                {
                    return 0;
                }
                return (int)result;
                
            }
        }
    }
}
