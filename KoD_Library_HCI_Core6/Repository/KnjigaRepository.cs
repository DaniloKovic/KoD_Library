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
    public class KnjigaRepository : BaseRepository<Knjiga>, IKnjigaRepository
    {

        public KnjigaRepository() : base()
        {

        }
        public KnjigaRepository(DataContext context) : base(context)
        {

        }


        public List<Knjiga> GetAllBooks()
        {
            List<Knjiga> knjige = null;
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                knjige = ctx.Knjiga.OrderBy(k => k.Naslov).ToList();
            }
            return knjige;
        }


        public List<Knjiga> GetAllBooksWithAutors()
        {
            List<Knjiga> knjige = null;
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                knjige = ctx.Knjiga.OrderBy(k => k.Naslov).Include(k => k.Autor).ToList();
            }
            return knjige;
        }

        public List<Knjiga> GetAllBooksWithGenres()
        {
            List<Knjiga> knjige = null;
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                knjige = ctx.Knjiga.Include(k => k.Zanr).ToList();
            }
            return knjige;
        }

        public List<Knjiga> GetAllBooksWithAuthorsAndGenres()
        {
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                return ctx.Knjiga.Include(k => k.Autor)
                                 .Include(k => k.Zanr).ToList();
            }
        }

        public List<Knjiga>? GetAllBooksWithAllProperties()
        {
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                return ctx.Knjiga?.Include(k => k.Autor)
                                  .Include(k => k.Zanr)
                                  .Include(k => k.Iznajmljuje).ToList();
            }
        }

        public Knjiga? GetKnjigaByNaslov(string naslov)
        {
            
            using( var ctx = new DataContext(optionsBuilder.Options))
            {
                if (naslov != null)
                    return ctx.Knjiga?.Where(k => k.Naslov == naslov).FirstOrDefault();
                return null;
            }
        }

        public Knjiga? GetKnjiga(string naslov)
        {
            using (var ctx = new DataContext(optionsBuilder.Options))
            {
                Knjiga? knjigaInstance = ctx.Knjiga?
                                            .Include(k => k.Autor)
                                            .Include(k => k.Zanr)
                                            .Where(k => k.Naslov == naslov)
                                            .FirstOrDefault();
                if(knjigaInstance != null)
                    return knjigaInstance;
                return null;
            }
        }

        public List<Knjiga> GetAllByTitleFilter(string bookTitleFilter)
        {
            List<Knjiga> books = new List<Knjiga>();
            using( var ctx = new DataContext(optionsBuilder.Options))
            {
                books = ctx.Knjiga.Where(k => k.Naslov.Contains(bookTitleFilter)).ToList();
            }
            return books;
        }

        public List<Knjiga> GetAllBooksBySearchFilter(string bookTitleFilter, Autor? autor, Zanr? zanr)
        {
            List<Knjiga> books = new List<Knjiga>();
  
            using (var ctx = new DataContext(optionsBuilder.Options))
            {

                books = ctx.Knjiga.Include(k => k.Autor)
                                  .Include(k => k.Zanr)
                                  .Where(k => ((bookTitleFilter != null) ? k.Naslov.Contains(bookTitleFilter) : true) && 
                                              ((autor != null) ? k.Autor.Contains(autor) : true) && 
                                              ((zanr != null) ? k.Zanr.Contains(zanr) : true))
                                  .ToList();
            }
            return books;
        }

        public List<Knjiga> GetAllBooksBySearchFilter(string bookTitleFilter, string autorFilter, string zanrFilter)
        {
            List<Knjiga> books = new List<Knjiga>();

            using (var ctx = new DataContext(optionsBuilder.Options))
            {

                books = ctx.Knjiga.Include(k => k.Autor)
                                  .Include(k => k.Zanr)
                                  .Where(k => ((bookTitleFilter != null) ? k.Naslov.Contains(bookTitleFilter) : true))
                                  .Where(k => k.Autor.Any(a => a.ImePrezime.Equals(autorFilter)))
                                  .Where(k => k.Zanr.Any(z => z.Naziv.Equals(zanrFilter)))
                                  .ToList();
            }
            return books;
        }

        public bool AddNewKnjiga(Knjiga knjiga) // Add knjiga without related autor and zanr
        {
            using (var context = new DataContext(optionsBuilder.Options))
            {
                if (context.Knjiga.Any(k => k.Naslov.Equals(knjiga.Naslov)))
                    return false;

                context.Knjiga.Add(knjiga);
                context.SaveChanges();
                return true;
            }
        }

        public void UpdateBook()
        {
            using (var context = new DataContext(optionsBuilder.Options))
            {

            }
        }
        
        //public bool InsertKnjigaWithRelatedPropertiy<T>(uint knjigaId, uint propertyId, T obj)
        public bool InsertKnjigaWithRelatedPropertiy<T>(uint knjigaId, uint propertyId)
        {
            using (var context = new DataContext(optionsBuilder.Options))
            {
                Knjiga k = new Knjiga { Id = knjigaId, };
                context.Knjiga.Add(k);
                context.Knjiga.Attach(k);

                if(typeof(T) == typeof(Autor))
                {
                    Autor a = new Autor { Id = propertyId };
                    context.Autor.Add(a);
                    context.Autor.Attach(a);
                    k.Autor.Add(a);
                }
                else if(typeof(T) == typeof(Zanr))
                {
                    Zanr z = new Zanr { Id = propertyId };
                    context.Zanr.Add(z);
                    context.Zanr.Attach(z);
                    k.Zanr.Add(z);
                }
                context.SaveChanges();
                return true;
            }
        }

        public List<Knjiga> GetAllByNaslovFilter(string bookTitleFilter)
        {
            throw new NotImplementedException();
        }
    }
}
