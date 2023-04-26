using Microsoft.EntityFrameworkCore;
using OlympProject.WebApi.Models;

namespace OlympProject.Database
{
    public class AppDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<LocationPoint> LocationPoints { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(c => c.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Animal>()
                .Property(a => a.LifeStatus)
                .HasConversion<string>();
            base.OnModelCreating(modelBuilder);
                
        }

    }
}
