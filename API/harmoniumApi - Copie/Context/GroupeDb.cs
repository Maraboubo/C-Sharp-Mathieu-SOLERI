using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class GroupeDb : DbContext
    {
        public GroupeDb(DbContextOptions<GroupeDb> options) : base(options) { }

        public DbSet<Groupe> GroupeSet => Set<Groupe>();

    }
}
