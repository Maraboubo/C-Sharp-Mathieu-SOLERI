using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class UtilisateursDb : DbContext
    {
        public UtilisateursDb(DbContextOptions<UtilisateursDb> options) : base(options) { }

        public DbSet<Utilisateurs> UtilisateursSet => Set<Utilisateurs>();
    }
}
