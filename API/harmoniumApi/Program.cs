using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<UtilisateursDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            var app = builder.Build();

            app.MapGet("/Utilisateursitems", async (UtilisateursDb db) =>
                await db.UtilisateursSet.ToListAsync());


            //RECHERCHE D'UTILISATEUR PAR ID
            app.MapGet("/Utilisateursitems/{id}", async (int id, UtilisateursDb db) =>
                await db.UtilisateursSet.FindAsync(id)
                    is Utilisateurs nouvelUtilisateur
                        ? Results.Ok(nouvelUtilisateur)
                        : Results.NotFound());

            //AJOUT D'UN NOUVEL UTILISATEUR
            app.MapPost("/Utilisateursitems", async (Utilisateurs nouvelUtilisateur, UtilisateursDb db) =>
            {
                db.UtilisateursSet.Add(nouvelUtilisateur);
                await db.SaveChangesAsync();

                //GENERATION D'ID POUR UN NOUVEL UTILISATEUR
                return Results.Created($"/Utilisateursitems/{nouvelUtilisateur.Id}", nouvelUtilisateur);
            });

            //MODIFICATION D'UN UTILISATEUR
            app.MapPut("/Utilisateursitems/{id}", async (int id, Utilisateurs inputUtilisateur, UtilisateursDb db) =>
            {
                var utilisateurAModifier = await db.UtilisateursSet.FindAsync(id);

                if (utilisateurAModifier is null) return Results.NotFound();

                utilisateurAModifier.Email = inputUtilisateur.Email;
                utilisateurAModifier.motDePasse = inputUtilisateur.motDePasse;
                utilisateurAModifier.Nom = inputUtilisateur.Nom;
                utilisateurAModifier.Prenom = inputUtilisateur.Prenom;
                utilisateurAModifier.Adresse1 = inputUtilisateur.Adresse1;
                utilisateurAModifier.Adresse2 = inputUtilisateur.Adresse2;
                utilisateurAModifier.CodePostal = inputUtilisateur.CodePostal;
                utilisateurAModifier.Ville = inputUtilisateur.Ville;
                utilisateurAModifier.NomInstrument = inputUtilisateur.NomInstrument;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            //SUPPRESSION D'UN UTILISATEUR
            app.MapDelete("/Utilisateursitems/{id}", async (int id, UtilisateursDb db) =>
            {
                if (await db.UtilisateursSet.FindAsync(id) is Utilisateurs utilisateurASupprimer)
                {
                    db.UtilisateursSet.Remove(utilisateurASupprimer);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });

            app.Run();
        }
    }
}
