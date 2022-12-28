using KoD_Library_HCI_Core6.Data;
using KoD_Library_HCI_Core6.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public string connectionString = ConfigurationManager.AppSettings["connectionString"];
        protected DbContextOptionsBuilder<DataContext> optionsBuilder;
        public DataContext _context;

        public BaseRepository() 
        {
            optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        
        public BaseRepository(DataContext context)
        {
            optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            _context = context;
        }
        
        public IEnumerable<T> GetAll()
        {
            using (_context = new DataContext(optionsBuilder.Options))
            {
                return _context.Set<T>().ToList();
            }
               
        }
        public T? Get(uint id)
        {
            using (_context = new DataContext(optionsBuilder.Options))
            {
                return _context.Set<T>().Find(id);
            }
        }

        public T? Get(string value)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                return _context.Set<T>().Find(value);
            }
        }

        public T? FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                return _context.Set<T>().Where(predicate).FirstOrDefault();
            }
        }

        public IEnumerable<T> FindByFilter(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                var resultList = _context.Set<T>().Where(predicate).ToList();
                if (resultList.Count > 0)
                    return resultList;
                return null;
            }
        }

        public int AddNewRecord(T item)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                _context.Set<T>().Add(item);
                return _context.SaveChanges();
            }
        }

        //  Tip: Use the EntityEntry.State property to set the state of just a single entity.For example, context.Entry(blog).State = EntityState.Modified.
        public int Update(T item)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                _context.Entry(item).State = EntityState.Modified;
                return _context.SaveChanges();
            }
        }

        public int UpdateRange(IEnumerable<T> items)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                foreach(T item in items)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                return _context.SaveChanges();
            }
        }
        
        public void Delete(T item)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                _context.Entry(item).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public int DeleteItem(T item)
        {
            using(_context= new DataContext(optionsBuilder.Options))
            {
                _context.Set<T>().Remove(item);
                return _context.SaveChanges();
            }
        }

        public int DeleteRange(IEnumerable<T> items)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                _context.Set<T>().RemoveRange(items);
                return _context.SaveChanges();
            }
        }

        /*
        public T GetByPropertyValue(Type t, string propertyName, string propertValue)
        {
            using(_context = new DataContext(optionsBuilder.Options))
            {
                if(t.GetType() == typeof(Autor))
                {
                    var x = (Autor)t;
                }
            }
        }
        */
    }
}
