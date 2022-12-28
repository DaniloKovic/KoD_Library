using KoD_Library_HCI_Core6.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Models.Request
{
    public class KnjigaRequest : Knjiga
    {
        public KnjigaRequest() : base() 
        {

        }
        public string[] Autori { get; set; }

        public string[] Zanrovi { get; set; }
    }
}
