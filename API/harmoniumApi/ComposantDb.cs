using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class ComposantDb : DbContext
    {
        public ComposantDb(DbContextOptions<ComposantDb> options) : base(options) { }

        public DbSet<Composant> ComposantSet => Set<Composant>();
    }
}
