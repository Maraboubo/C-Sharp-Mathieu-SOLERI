using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class GroupeDb : DbContext
    {
            public GroupeDb(DbContextOptions<GroupeDb> options) : base(options) { }

            public DbSet<Groupe> GroupeSet => Set<Groupe>();
    }
}
