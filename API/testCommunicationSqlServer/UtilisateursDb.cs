using Microsoft.EntityFrameworkCore;

namespace testCommunicationSqlServer
{
    public class UtilisateursDb : DbContext
    {
        public UtilisateursDb(DbContextOptions<UtilisateursDb> options) : base (options) { }

        public DbSet<Utilisateurs> utilisateur => Set<Utilisateurs>();
    }
}
