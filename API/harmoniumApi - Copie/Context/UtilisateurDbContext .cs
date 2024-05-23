using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Context
{
    public class UtilisateurDbContext : DbContext
    {
        public DbSet<Utilisateurs> UtilisateurSet { get; set; }
        public DbSet<Instrument> InstrumentsSet { get; set; }
        public DbSet<InstrumentUtilisateur> InstrumentsUtilisateursSet { get; set; }
        public UtilisateurDbContext(DbContextOptions<UtilisateurDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<InstrumentUtilisateur>().HasNoKey();
        /*
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
                .WithMany()
                .HasForeignKey(iu => iu.InstrumentId);
        }*/
    }
}
