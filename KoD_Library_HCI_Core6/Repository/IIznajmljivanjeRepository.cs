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
    public interface IIznajmljivanjeRepository : IBaseRepository<Iznajmljuje>
    {
        List<Iznajmljuje> GetAllRentals();
        List<Iznajmljuje> GetAllRentalsByUser(string username);

        List<Iznajmljuje> GetAllRentalsByUser(uint id);

        List<Iznajmljuje> GetAllRentalsByUser(Nalog nalog);

        int InsertNewRental(Iznajmljuje newBookRental, Knjiga bookToRent);
    }
}
