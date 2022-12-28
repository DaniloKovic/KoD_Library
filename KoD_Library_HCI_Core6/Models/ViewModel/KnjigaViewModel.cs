using KoD_Library_HCI_Core6.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Models.ViewModel
{
    public class KnjigaViewModel
    {
        public KnjigaViewModel()
        {

        }

        public KnjigaViewModel(uint kolicina, int dostupnaKolicina)
        {
            dostupnost = DostupnaKolicina > 0 ? (DostupnaKolicina <= Kolicina ? true : false) : false;
        }

        public KnjigaViewModel(string naslov, uint godinaIzdanja, string opis, uint kolicina, sbyte dostupnost, ICollection<Autor> autori, ICollection<Zanr> zanrovi, ICollection<Iznajmljuje> iznajmljuje)
        {
            Naslov = naslov;
            GodinaIzdanja = godinaIzdanja;
            Opis = opis;
            Kolicina = kolicina;
            Dostupnost = Convert.ToBoolean(dostupnost);
            AutoriList = autori.Select(a => a.ImePrezime).ToList();
            ZanroviList = zanrovi.Select(z => z.Naziv).ToList();
            // Iznajmljuje = iznajmljuje
        }

        public uint Id { get; set; }
        public string? Naslov { get; set; } // auto-generated
        public uint GodinaIzdanja { get; set; }
        public string? Opis { get; set; }
        public uint Kolicina { get; set; }
        public int DostupnaKolicina { get; set; }

        private bool dostupnost;
        public bool Dostupnost { 
            get { return dostupnost; }
            set { dostupnost = DostupnaKolicina > 0 ? true : false; }
        }
        public string? Autori { get; set; }
        public string? Zanrovi { get; set; }
        public List<string>? AutoriList { get; set; }
        public List<string>? ZanroviList { get; set; }
        public string[]? AutoriArr { get; set; }
        public string[]? ZanroviArr { get; set; }

        private string ConvertListToString(List<string> lista)
        {
            if(lista == null)
                return string.Empty;
            if (lista.Count == 1)
                return lista.ElementAt(0).ToString();

            StringBuilder sb = new StringBuilder();
            foreach (string str in lista)
            {
                sb.Append(str + ",\n");
            }
            return sb.ToString().TrimEnd('\n').TrimEnd(',');
        }

        
        private string ListToStringAutor(ICollection<Autor> lista)
        {
            if (lista.Count == 1)
            {
                return lista.ElementAt(0).ImePrezime;
            }
            StringBuilder sb = new StringBuilder();
            foreach (Autor autor in lista)
            {
                sb.Append(autor.ImePrezime + ",\n");
            }
            return sb.ToString().TrimEnd('\n').TrimEnd(',');
        }

        private string ListToStringZanr(ICollection<Zanr> lista)
        {
            if (lista.Count == 1)
            {
                return lista.ElementAt(0).Naziv;
            }

            StringBuilder sb = new StringBuilder();
            foreach (Zanr zanr in lista)
            {
                sb.Append(zanr.Naziv + ",\n");
            }
            return sb.ToString().TrimEnd('\n').TrimEnd(',');
        }
       
    }
}
