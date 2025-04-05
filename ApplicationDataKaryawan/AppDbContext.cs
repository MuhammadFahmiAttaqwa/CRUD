using ApplicationDataKaryawan.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDataKaryawan
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<KaryawanEntity> Karyawan { get; set; }
        public DbSet<CountryEntity> Country { get; set; }
        public DbSet<GenderEntity> Gender { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KaryawanEntity>()
                .Property(e => e.Nik)
                .ValueGeneratedNever(); 
        }
    }
}
