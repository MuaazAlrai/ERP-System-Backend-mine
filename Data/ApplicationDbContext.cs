using KisanApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KisanApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Kisan> Kisans { get; set; }

        public DbSet<Fasal> Fasals { get; set; }

        public DbSet<Ozar> Ozars { get; set; }

        public DbSet<Zameen> Zameens { get; set; }

        protected override void OnModelCreating
            (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kisan>()
                .HasMany(x => x.Fasals)
                .WithOne(x => x.Kisan)
                .HasForeignKey(x => x.KisanId);

            modelBuilder.Entity<Kisan>()
                .HasMany(x => x.Ozars)
                .WithOne(x => x.Kisan)
                .HasForeignKey(x => x.KisanId);

            modelBuilder.Entity<Kisan>()
                .HasMany(x => x.Zameens)
                .WithOne(x => x.Kisan)
                .HasForeignKey(x => x.KisanId);
        }
    }
}