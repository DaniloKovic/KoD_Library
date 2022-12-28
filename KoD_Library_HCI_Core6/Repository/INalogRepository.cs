using KoD_Library_HCI_Core6.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Repository
{
    public interface INalogRepository : IBaseRepository<Nalog>
    {
        Nalog? GetByName(string username);
        List<Nalog>? GetAllKorisnikUsers();

        Nalog? CheckLoginAttempt(string username, string password);
        bool CheckIfUsernameOrPasswordAlreadyExist(string username, string password);

        int TotalNumberOfBookRentsByUser(System.Linq.Expressions.Expression<Func<Nalog, bool>> predicate);

        int NumberOfCurrentBookRentsByUser(System.Linq.Expressions.Expression<Func<Nalog, bool>> predicate);
    }
}
