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
    public interface IKnjigaRepository : IBaseRepository<Knjiga>
    {
        List<Knjiga> GetAllBooks();
        List<Knjiga> GetAllBooksWithAutors();
        List<Knjiga> GetAllBooksWithGenres();
        List<Knjiga> GetAllBooksWithAuthorsAndGenres();
        List<Knjiga> GetAllBooksWithAllProperties();
        List<Knjiga> GetAllByTitleFilter(string bookTitleFilter);

        bool AddNewKnjiga(Knjiga knjiga);
        bool InsertKnjigaWithRelatedPropertiy<T>(uint knjigaId, uint propertyId);
        Knjiga GetKnjiga(string naslov);

    }
}
