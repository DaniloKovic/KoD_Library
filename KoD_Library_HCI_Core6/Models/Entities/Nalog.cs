﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoD_Library_HCI_Core6.Models.Entities
{
    public partial class Nalog
    {
        public Nalog()
        {
            Iznajmljuje = new HashSet<Iznajmljuje>();
        }

        public uint Id { get; set; }
        public string ImePrezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string BrojTelefona { get; set; }
        public string EMail { get; set; }
        public DateOnly DatumRegistracije { get; set; }
        public uint TipNalogaId { get; set; }
        public uint UserTemplate { get; set; }

        public virtual Tipnaloga TipNaloga { get; set; }
        public virtual ICollection<Iznajmljuje> Iznajmljuje { get; set; }
    }
}