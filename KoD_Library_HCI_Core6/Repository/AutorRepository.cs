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
    public class AutorRepository : BaseRepository<Autor> , IAutorRepository
    {

        public AutorRepository() : base()
        {

        }

        public AutorRepository(DataContext context) : base(context) {

        }

        public bool AddNewAutor(Autor autor)
        {
            using (_context = new DataContext(optionsBuilder.Options))
            {
                if(_context.Autor.Any(a => a.ImePrezime.Equals(autor.ImePrezime)))
                    return false;

                _context.Autor.Add(autor);
                _context.SaveChanges();
                return true;
            }
        }

        public Autor? GetAutorByName(string name)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                var autor = _context.Autor?.FirstOrDefault(a => a.ImePrezime.Equals(name));
                if (autor != null)
                    return autor;
                return null;
            }
        }

        public List<Autor> GetByImeIPrezime(string imePrezime) 
        {
            using (_context = new DataContext(optionsBuilder.Options))
            {
                return _context.Autor.Where(a => a.ImePrezime.Equals(imePrezime)).ToList<Autor>();
            }
        }
    }
}
