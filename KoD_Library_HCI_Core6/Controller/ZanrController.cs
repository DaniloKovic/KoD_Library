using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.ViewModel;
using KoD_Library_HCI_Core6.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Controller
{
    public class ZanrController
    {
        private readonly ZanrRepository _zanrRepository = new ZanrRepository();
        public ZanrController()
        {

        }

        public List<string> GetAllGenres()
        {
            return _zanrRepository.GetAll().Select(z => new ZanrViewModel()
            {
                Id = z.Id,
                NazivZanra = z.Naziv,
            }).OrderBy(z => z.NazivZanra).Select(z => z.NazivZanra).ToList();
        }

        public bool CreateNewZanr(ZanrViewModel noviZanrVM)
        {
            Zanr noviZanr = new Zanr()
            {
                Naziv = noviZanrVM.NazivZanra
            };

            if (_zanrRepository.AddNewZanr(noviZanr))
            {
                return true;
            }
            return false;
        }
    }
}
