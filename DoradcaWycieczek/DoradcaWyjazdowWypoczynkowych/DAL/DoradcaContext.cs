using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DoradcaWyjazdowWypoczynkowych.Models;

namespace DoradcaWyjazdowWypoczynkowych.DAL
{
    public class DoradcaContext : DbContext
    {
        public DbSet<Atrakcja> Atrakcja { get; set; }
        public DbSet<Kategoria> Kategoria { get; set; }
        public DbSet<OfertaGotowa> OfertaGotowa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}