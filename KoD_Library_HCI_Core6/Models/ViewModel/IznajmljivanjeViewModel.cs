using KoD_Library_HCI_Core6.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Models.ViewModel
{
    public class IznajmljivanjeViewModel
    {
        public IznajmljivanjeViewModel()
        {

        }

        public uint Id { get; set; }
        public DateOnly DatumOd { get; set; }
        public DateOnly DatumDo { get; set; }

        public bool IsVracena { get; set; }

        public Knjiga Knjiga { get; set; }
        public string NaslovKnjige { get; set; }
        public Nalog Nalog { get; set; }
        public string ImeNalog { get; set; }    
    }
}
