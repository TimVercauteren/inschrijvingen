using InschrijvenPietieterken.Entities;
using InschrijvingPietieterken.Entities;
using Microsoft.EntityFrameworkCore;

namespace InschrijvingPietieterken.DataAccess
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inschrijving>(entity =>
            {
                entity.ToTable("inschrijving");


            });

            modelBuilder.Entity<Kind>(entity =>
            {
                entity.ToTable("kinderen");
            });

            modelBuilder.Entity<Ouders>(entity =>
            {
                entity.ToTable("ouders");
            });

            modelBuilder.Entity<Medisch>(entity =>
            {
                entity.ToTable("medisch");
            });

            modelBuilder.Entity<Persoon>(entity =>
            {
                entity.ToTable("personen");
            });

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.ToTable("adressen");
            });
        }

        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Kind> Kinderen { get; set; }
        public DbSet<Ouders> Ouders { get; set; }
        public DbSet<Medisch> MedischeGegevens { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Adres> Adressen { get; set; }
        public DbSet<Auth> Authentication { get; set; }
    }
}
