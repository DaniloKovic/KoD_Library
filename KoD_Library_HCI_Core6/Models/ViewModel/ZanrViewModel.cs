using KoD_Library_HCI_Core6.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Models.ViewModel
{
    public class ZanrViewModel
    {
        public ZanrViewModel()
        {

        }

        public ZanrViewModel(string nazivZanra)
        {
            NazivZanra = nazivZanra;
        }

        public uint Id { get; set; }
        public string NazivZanra { get; set; }
    }
}
