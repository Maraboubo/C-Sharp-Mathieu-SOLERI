using Microsoft.EntityFrameworkCore;

namespace harmoniumApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<UtilisateursDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDbContext<GroupeDb>(opt => opt.UseInMemoryDatabase("Harmonium2"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            var app = builder.Build();

            //AFFECTATION DU CHEMIN "app.MapGroup("/Utilisateursitems")" A LA VARIABLE "utilisateursitems"
            //QUE L'ON VA UTILISER SUR CHAQUE REQUETE.
            var utilisateursitems = app.MapGroup("/Utilisateursitems");
            var groupeitems = app.MapGroup("/Groupeitems");

            //ROUTES POUR LES METHODES CONCERNANT LES UTILISATEURS
            utilisateursitems.MapGet("/", GetAllUtilisateurs);
            utilisateursitems.MapGet("/{id}", GetUtilisateursById);
            utilisateursitems.MapPost("/", CreateUtilisateur);
            utilisateursitems.MapPut("/{id}", UpdateUtilisateurs);
            utilisateursitems.MapDelete("/{id}", DeleteUtilisateur);
            //ROUTES POUR LES METHODES CONCERNANT LES GROUPES
            groupeitems.MapGet("/", GetAllGroupes);
            groupeitems.MapGet("/{id}", GetGroupeById);
            groupeitems.MapPost("/", CreateGroupe);
            groupeitems.MapPut("/{id}", UpdateGroupe);
            groupeitems.MapDelete("/{id}", DeleteGroupe);


            app.Run();

            //AFFICHAGE DE TOUS LES GROUPES
            static async Task<IResult> GetAllGroupes(GroupeDb db)
            {
                return TypedResults.Ok(await db.GroupeSet.ToArrayAsync());
            }

            //RECHERCHER UN GROUPE PAR ID
            static async Task<IResult> GetGroupeById(int id, GroupeDb db)
            {
                return await db.GroupeSet.FindAsync(id)
                    is Groupe nouveauGroupe
                        ? Results.Ok(nouveauGroupe)
                        : Results.NotFound();
            }
            //AJOUT D'UN NOUVEAU GROUPE
            static async Task<IResult> CreateGroupe(Groupe nouveauGroupe, GroupeDb database)
            {
                database.GroupeSet.Add(nouveauGroupe);
                await database.SaveChangesAsync();

                //GENERATION D'ID POUR UN NOUVEAU GROUPE
                return Results.Created($"/Groupeitems/{nouveauGroupe.Id_Groupe}", nouveauGroupe);
            };
            //MODIFICATION D'UN GROUPE
            static async Task<IResult> UpdateGroupe(int id, Groupe inputGroupe, GroupeDb db)
            {
                var groupeAModifier = await db.GroupeSet.FindAsync(id);

                if (groupeAModifier is null) return Results.NotFound();

                groupeAModifier.gNom = inputGroupe.gNom;
                groupeAModifier.gDate = inputGroupe.gDate;

                await db.SaveChangesAsync();

                return Results.NoContent();
            };
            //SUPPRESSION D'UN GROUPE
            static async Task<IResult> DeleteGroupe(int id, GroupeDb db)
            {
                if (await db.GroupeSet.FindAsync(id) is Groupe groupeASupprimer)
                {
                    db.GroupeSet.Remove(groupeASupprimer);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            };

            //AFFICHAGE DE TOUS LES UTILISATEURS
            static async Task<IResult> GetAllUtilisateurs(UtilisateursDb db)
            {
                return TypedResults.Ok(await db.UtilisateursSet.ToArrayAsync());
            }

            //RECHERCHE D'UTILISATEUR PAR ID
            static async Task<IResult> GetUtilisateursById(int id, UtilisateursDb db)
            {
                return await db.UtilisateursSet.FindAsync(id)
                    is Utilisateurs nouvelUtilisateur
                        ? Results.Ok(nouvelUtilisateur)
                        : Results.NotFound();
            }

            //AJOUT D'UN NOUVEL UTILISATEUR
            static async Task<IResult> CreateUtilisateur(Utilisateurs nouvelUtilisateur, UtilisateursDb db)
            {
                db.UtilisateursSet.Add(nouvelUtilisateur);
                await db.SaveChangesAsync();

                //GENERATION D'ID POUR UN NOUVEL UTILISATEUR
                return Results.Created($"/Utilisateursitems/{nouvelUtilisateur.Id}", nouvelUtilisateur);
            };

            //MODIFICATION D'UN UTILISATEUR
            static async Task<IResult> UpdateUtilisateurs(int id, Utilisateurs inputUtilisateur, UtilisateursDb db)
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
            };

            //SUPPRESSION D'UN UTILISATEUR
            static async Task<IResult> DeleteUtilisateur(int id, UtilisateursDb db)
            {
                if (await db.UtilisateursSet.FindAsync(id) is Utilisateurs utilisateurASupprimer)
                {
                    db.UtilisateursSet.Remove(utilisateurASupprimer);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            };
            


            //SECONDE VERSION DU CODE AVEC L'AFFECTATION DU CHEMIN "app.MapGroup("/Utilisateursitems")" A LA VARIABLE "utilisateursitems"
            /*
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<UtilisateursDb>(opt => opt.UseInMemoryDatabase("Harmonium"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            var app = builder.Build();

            //AFFECTATION DU CHEMIN "app.MapGroup("/Utilisateursitems")" A LA VARIABLE "utilisateursitems"
            //QUE L'ON VA UTILISER SUR CHAQUE REQUETE.
            var utilisateursitems = app.MapGroup("/Utilisateursitems");

            utilisateursitems.MapGet("/", async (UtilisateursDb db) =>
                await db.UtilisateursSet.ToListAsync());


            //RECHERCHE D'UTILISATEUR PAR ID
            utilisateursitems.MapGet("/{id}", async (int id, UtilisateursDb db) =>
                await db.UtilisateursSet.FindAsync(id)
                    is Utilisateurs nouvelUtilisateur
                        ? Results.Ok(nouvelUtilisateur)
                        : Results.NotFound());

            //AJOUT D'UN NOUVEL UTILISATEUR
            utilisateursitems.MapPost("/", async (Utilisateurs nouvelUtilisateur, UtilisateursDb db) =>
            {
                db.UtilisateursSet.Add(nouvelUtilisateur);
                await db.SaveChangesAsync();

                //GENERATION D'ID POUR UN NOUVEL UTILISATEUR
                return Results.Created($"/Utilisateursitems/{nouvelUtilisateur.Id}", nouvelUtilisateur);
            });

            //MODIFICATION D'UN UTILISATEUR
            utilisateursitems.MapPut("/{id}", async (int id, Utilisateurs inputUtilisateur, UtilisateursDb db) =>
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
            utilisateursitems.MapDelete("/{id}", async (int id, UtilisateursDb db) =>
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
            */


            //PREMIERE VERSION DU CODE
            /*

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
            */
        }
    }
}
