﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace varastonhallinta1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class naytto1Entities1 : DbContext
    {
        public naytto1Entities1()
            : base("name=naytto1Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asiakkaat> Asiakkaat { get; set; }
        public virtual DbSet<Henkilöstö> Henkilöstö { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Roolit> Roolit { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tilaukset> Tilaukset { get; set; }
        public virtual DbSet<Toimittajat> Toimittajat { get; set; }
        public virtual DbSet<Tuotteet> Tuotteet { get; set; }
        public virtual DbSet<VarastoSaldot> VarastoSaldot { get; set; }
        public virtual DbSet<TuoteLuokittelu> TuoteLuokittelu { get; set; }
    }
}
