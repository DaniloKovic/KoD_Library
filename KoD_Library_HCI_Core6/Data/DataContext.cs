using KoD_Library_HCI_Core6.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoD_Library_HCI_Core6.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Autor>? Autor { get; set; }
        public DbSet<Knjiga>? Knjiga { get; set; }
        public DbSet<Iznajmljuje>? Iznajmljuje { get; set; }
        public DbSet<Nalog>? Nalog { get; set; }
        public DbSet<Tipnaloga>? Tipnaloga { get; set; }
        public DbSet<Zanr>? Zanr { get; set; }   

    }
}
