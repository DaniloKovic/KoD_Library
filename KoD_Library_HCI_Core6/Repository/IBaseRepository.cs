using KoD_Library_HCI_Core6.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Repository
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(uint id);
        T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindByFilter(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        int AddNewRecord(T item);
        int Update(T item);
        int UpdateRange(IEnumerable<T> items);
        void Delete(T item);
        int DeleteItem(T item);
        int DeleteRange(IEnumerable<T> items);

    }
}
