using KoD_Library_HCI_Core6.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Models.ViewModel
{
    public class NalogViewModel
    {
        public NalogViewModel()
        {

        }

        public uint Id { get; set; }
        public string? ImePrezime { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? Lozinka { get; set; }
        public string? BrojTelefona { get; set; }
        public string? EMail { get; set; }
        public DateOnly DatumRegistracije { get; set; }

        public int TrenutniBrojRezervacija { get; set; }
        public int UkupanBrojRezervacija { get; set; }
    }
}
