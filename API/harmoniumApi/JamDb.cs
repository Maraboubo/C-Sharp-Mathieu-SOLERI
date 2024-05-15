using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class JamDb : DbContext
    {
        public JamDb(DbContextOptions<JamDb> options) : base(options) { }

        public DbSet<Jam> JamSet => Set<Jam>();
    }
}
