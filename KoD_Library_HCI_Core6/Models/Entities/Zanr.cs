﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoD_Library_HCI_Core6.Models.Entities
{
    public partial class Zanr
    {
        public Zanr()
        {
            Knjiga = new HashSet<Knjiga>();
        }

        public uint Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Knjiga> Knjiga { get; set; }
    }
}