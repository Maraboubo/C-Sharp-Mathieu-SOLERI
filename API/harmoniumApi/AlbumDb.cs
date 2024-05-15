using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class AlbumDb : DbContext
    {
        public AlbumDb(DbContextOptions<AlbumDb> options) : base(options) { }

        public DbSet<Album> AlbumSet => Set<Album>();
    }
}
