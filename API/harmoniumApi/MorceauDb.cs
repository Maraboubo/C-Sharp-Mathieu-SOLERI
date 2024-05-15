using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class MorceauDb : DbContext
    {
        public MorceauDb(DbContextOptions<MorceauDb> options) : base(options) { }

        public DbSet<Morceau> MorceauSet => Set<Morceau>();
    }
}
