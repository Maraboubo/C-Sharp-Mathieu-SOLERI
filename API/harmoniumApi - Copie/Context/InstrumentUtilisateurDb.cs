using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class InstrumentUtilisateurDb : DbContext
    {
        public InstrumentUtilisateurDb(DbContextOptions<InstrumentUtilisateurDb> options) : base(options) { }

        public DbSet<InstrumentUtilisateur> InstrumentUtilisateurSet => Set<InstrumentUtilisateur>();
    }
}
