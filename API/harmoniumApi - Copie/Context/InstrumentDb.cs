using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class InstrumentDb : DbContext
    {
        public InstrumentDb(DbContextOptions<InstrumentDb> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrument>()
            .HasKey(i => i.Id);
        }
        public DbSet<Instrument> InstrumentsSet => Set<Instrument>();
    }
}
