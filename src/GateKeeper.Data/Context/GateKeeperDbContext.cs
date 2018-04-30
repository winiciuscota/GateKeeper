using GateKeeper.Data.Configuration;
using GateKeeper.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GateKeeper.Data.Context
{
    public class GateKeeperDbContext : DbContext
    {
        public DbSet<Resident> Residents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ResidentConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gatekeeper.db");
        }
    }
}