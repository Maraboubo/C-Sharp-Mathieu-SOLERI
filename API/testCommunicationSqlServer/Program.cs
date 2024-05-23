using Microsoft.EntityFrameworkCore;
namespace testCommunicationSqlServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<UtilisateursDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            var app = builder.Build();

            async Task<List<Utilisateurs>> GetUtilisateurs(UtilisateursDb db)=> await db.utilisateur.ToListAsync();

            app.MapPost("/utilisateur", async (UtilisateursDb db, Utilisateurs utilisateur) =>
            {
                db.utilisateur.Add(utilisateur);
                await db.SaveChangesAsync();
                return Results.Ok(await GetUtilisateurs(db));
            });

            app.MapGet("/utilisateur", async (UtilisateursDb db)=> await db.utilisateur.ToListAsync());

            app.MapGet("/utilisateur/{id}", async (UtilisateursDb db, int id) => await db.utilisateur.FindAsync(id)
            is Utilisateurs utilisateur ? Results.Ok(utilisateur) : Results.NotFound("Utilisateur introuvable")
            );

            app.MapPut("/utilisateur/{id}", async (UtilisateursDb db, Utilisateurs utilisateur, int id) =>
            {
                var utilisateurAChanger = await db.utilisateur.FindAsync(id);
                if (utilisateurAChanger == null) return Results.NotFound("Utilisateur introuvable");
                utilisateurAChanger.nom = utilisateur.nom;
                utilisateurAChanger.prenom = utilisateur.prenom;
                db.utilisateur.Update(utilisateurAChanger);
                await db.SaveChangesAsync();
                return Results.Ok(await GetUtilisateurs(db));
            });

            app.MapDelete("/Utilisateur/{id}", async (UtilisateursDb db, int id) =>
            {
                var utilisateurAChanger = await db.utilisateur.FindAsync(id);
                if (utilisateurAChanger == null) return Results.NotFound("Utilisateur introuvable");
                db.Remove(utilisateurAChanger);
                await db.SaveChangesAsync();
                return Results.Ok(await GetUtilisateurs(db));
            });

            app.Run();
        }
    }
}
