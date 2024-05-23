using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class PisteDb : DbContext
    {
        public PisteDb(DbContextOptions<PisteDb> options) : base(options) { }

        public DbSet<Piste> PisteSet => Set<Piste>();

    }
}
