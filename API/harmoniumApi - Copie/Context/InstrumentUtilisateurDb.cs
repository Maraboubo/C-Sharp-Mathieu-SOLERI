using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class InstrumentUtilisateurDb : DbContext
    {
        public InstrumentUtilisateurDb(DbContextOptions<InstrumentUtilisateurDb> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstrumentUtilisateur>()
            .HasKey(iu => new { iu.UtilisateurId, iu.InstrumentId });

            modelBuilder.Entity<InstrumentUtilisateur>()
                .HasOne(iu => iu.Utilisateur)
                .WithMany(u => u.InstrumentUtilisateurs)
                .HasForeignKey(iu => iu.UtilisateurId);

            modelBuilder.Entity<InstrumentUtilisateur>()
                .HasOne(iu => iu.Instrument)
                .WithMany(i => i.InstrumentUtilisateurs)
                .HasForeignKey(iu => iu.InstrumentId);
        }
        public DbSet<InstrumentUtilisateur> InstrumentUtilisateurSet => Set<InstrumentUtilisateur>();
    }
}
