using GateKeeper.Data.Configuration;
using GateKeeper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GateKeeper.Data.Context
{
    public class GateKeeperDbContext : DbContext
    {
        public DbSet<Resident> Residents { get; set; }
        public DbSet<ResidentApartment> ResidentAparments { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<CondominiumBlock> CondominiumBlocks { get; set; }

        // public GateKeeperDbContext(DbContextOptions<GateKeeperDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ResidentConfiguration());
            modelBuilder.ApplyConfiguration(new CondominiumConfiguration());
            modelBuilder.ApplyConfiguration(new ResidentApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new CondominiumBlockConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gatekeeper.db");
        }
    }
}