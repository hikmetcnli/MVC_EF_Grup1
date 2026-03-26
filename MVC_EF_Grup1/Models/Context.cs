using Microsoft.EntityFrameworkCore;

namespace MVC_EF_Grup1.Models
{
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GDKTP-NB-000;Database=DB_Grup1;User ID=hikmetcanli;Password=1234;Trusted_Connection=False;TrustServerCertificate=True");
        }

        public DbSet<Product> Products_ { get; set; }
        public DbSet<Departmant> Departmants_ { get; set; }
        public DbSet<Arac> Aracs_ { get; set; }
        public DbSet<Musteri> Musteris_ { get; set; }
        public DbSet<SatinAlma> SatinAlmas_ { get; set; }

    }
}
