using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class MorceauDb : DbContext
    {
        public MorceauDb(DbContextOptions<MorceauDb> options) : base(options) { }

        public DbSet<Morceau> Morceauitems { get; set; }

    }
}
