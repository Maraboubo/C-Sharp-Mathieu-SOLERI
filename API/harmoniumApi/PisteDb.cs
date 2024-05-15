using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class PisteDb : DbContext
    {
        public PisteDb(DbContextOptions<PisteDb> options) : base(options) { }

        public DbSet<Piste> PisteSet => Set<Piste>();
    }
}
