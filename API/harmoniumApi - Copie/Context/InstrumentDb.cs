using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class InstrumentDb : DbContext
    {
        public InstrumentDb(DbContextOptions<InstrumentDb> options) : base(options) { }

        public DbSet<Instrument> InstrumentsSet => Set<Instrument>();
    }
}
