using KoD_Library_HCI_Core6.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Models.ViewModel
{
    public class AutorViewModel
    {
        public AutorViewModel()
        {

        }

        public AutorViewModel(string imePrezime)
        {
            // Id = 1; // auto-increment
            ImePrezime = imePrezime;
        }
        public uint Id { get; set; }
        public string ImePrezime { get; set; }
    }
}
