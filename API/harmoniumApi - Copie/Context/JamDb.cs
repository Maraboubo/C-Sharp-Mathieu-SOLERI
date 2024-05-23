using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class JamDb : DbContext
    {
        public JamDb(DbContextOptions<JamDb> options) : base(options) { }

        public DbSet<Jam> JamSet => Set<Jam>();

    }
}
