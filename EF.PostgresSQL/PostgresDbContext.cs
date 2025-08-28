using EF.PostgresSQL.Entity;
using Microsoft.EntityFrameworkCore;

namespace EF.PostgresSQL
{
    internal class PostgresDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RecordConfiguration());
        }
    }
}
