using harmoniumApi.Context;
using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class InstrumentUtilisateurCtrl
    {
        public static void ControleurInstrumentUtilisateurs(this WebApplication appli)
        {
            var Instrumentutilisateursitems = appli.MapGroup("/InstrumentUtilisateursitems");

            Instrumentutilisateursitems.MapGet("/", GetAllInstrumentUtilisateurs);
            Instrumentutilisateursitems.MapGet("/{id}", GetInstrumentUtilisateursById);
            //utilisateursitems.MapPost("/", CreateUtilisateur);
            Instrumentutilisateursitems.MapPut("/{id}", UpdateInstrumentUtilisateurs);
            //utilisateursitems.MapDelete("/{id}", DeleteUtilisateur);
        }

        //AFFICHAGE DE TOUS LES INSTRUMENTS_UTILISATEURS
        public static async Task<IResult> GetAllInstrumentUtilisateurs(InstrumentUtilisateurDb db)
        {
            return TypedResults.Ok(await db.InstrumentUtilisateurSet.ToArrayAsync());
        }

        //RECHERCHE D'INSTRUMENTS_UTILISATEURS PAR ID
        public static async Task<List<InstrumentUtilisateur>> GetInstrumentUtilisateursById(int id, InstrumentUtilisateurDb db)
        {
            return await db.InstrumentUtilisateurSet.Where(ui => ui.UtilisateurId == id).ToListAsync();
                //is InstrumentUtilisateur nouvelInstrumentUtilisateur
                //    ? Results.Ok(nouvelInstrumentUtilisateur)
                //    : Results.NotFound();
        }

        //MODIFICATION D'UN INSTRUMENTS_UTILISATEURS
        public static async Task<IResult> UpdateInstrumentUtilisateurs(int utilisateurId, List<int> newInstrumentIds, UtilisateursDb db)
        {
            // Trouver l'utilisateur
            var utilisateur = await db.UtilisateursSet
                .Include(u => u.InstrumentUtilisateurs)
                .FirstOrDefaultAsync(u => u.Id == utilisateurId);

            if (utilisateur == null) return Results.NotFound();

            // Supprimer les anciens instruments qui ne sont pas dans la nouvelle liste
            var instrumentsToRemove = utilisateur.InstrumentUtilisateurs
                .Where(iu => !newInstrumentIds.Contains(iu.InstrumentId))
                .ToList();

            db.UtilisateursSet.RemoveRange(instrumentsToRemove);

            // Ajouter les nouveaux instruments qui ne sont pas déjà associés à l'utilisateur
            var existingInstrumentIds = utilisateur.InstrumentsUtilisateurs.Select(iu => iu.InstrumentId).ToList();
            var instrumentsToAdd = newInstrumentIds
                .Where(id => !existingInstrumentIds.Contains(id))
                .Select(id => new InstrumentUtilisateur { UtilisateurId = utilisateurId, InstrumentId = id })
                .ToList();

            await db.InstrumentsUtilisateursSet.AddRangeAsync(instrumentsToAdd);

            // Sauvegarder les changements
            await db.SaveChangesAsync();

            return Results.NoContent();
        }

    }
}
