﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoD_Library_HCI_Core6.Models.Entities
{
    public partial class Tipnaloga
    {
        public Tipnaloga()
        {
            Nalog = new HashSet<Nalog>();
        }

        public uint Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Nalog> Nalog { get; set; }
    }
}