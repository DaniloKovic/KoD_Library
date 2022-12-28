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
    public interface IZanrRepository : IBaseRepository<Zanr>
    {
        bool AddNewZanr(Zanr zanr);
    }
}
