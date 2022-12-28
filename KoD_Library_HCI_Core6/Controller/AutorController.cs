using KoD_Library_HCI_Core6.Models.Entities;
using KoD_Library_HCI_Core6.Models.ViewModel;
using KoD_Library_HCI_Core6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Controller
{
    public class AutorController
    {
        private readonly AutorRepository _autorRepository = new AutorRepository();
        public AutorController()
        {

        }

        public Autor GetAutor(string name)
        {
            var autor = _autorRepository.GetAutorByName(name);
            if(autor == null) 
                return null;
            return autor;
        }

        public List<string> GetAllAuthors()
        {
            return _autorRepository.GetAll().Select(a => new AutorViewModel()
            {
                Id = a.Id,
                ImePrezime = a.ImePrezime
            }).OrderBy(a => a.ImePrezime).Select(a => a.ImePrezime).ToList();
        }

        public bool CreateNewAutor(AutorViewModel noviAutorVM)
        {
            Autor noviAutor = new Autor()
            {
                ImePrezime = noviAutorVM.ImePrezime,
            };

            if (_autorRepository.AddNewAutor(noviAutor))
            {
                return true;
            }
            return false;
        }
    }
}
