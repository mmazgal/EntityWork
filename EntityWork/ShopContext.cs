using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityWork
{
    public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("DataSource=ShopDB.db");
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-T3T6R4M\SQLEXPRESS; Initial Catalog=EntityKurs; Integrated Security=SSPI; TrustServerCertificate=True; ");
        }

        public DbSet<Egitmen> egitmen { get; set; }
        public DbSet<Kurs> kurs { get; set; }
        public DbSet<Ogrenci> ogrenci { get; set; }
        public DbSet<Personel> personel { get; set; }
        public DbSet<Sınıf> sınıf { get; set; }
    }
}
