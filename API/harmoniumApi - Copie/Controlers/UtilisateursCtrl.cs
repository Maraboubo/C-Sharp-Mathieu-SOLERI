using harmoniumApi.models;
using harmoniumApi.Context;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class UtilisateursCtrl
    {
        public static void ControleurUtilisateurs(this WebApplication appli)
        {
            var utilisateursitems = appli.MapGroup("/Utilisateursitems");

            utilisateursitems.MapGet("/", GetAllUtilisateurs);
            utilisateursitems.MapGet("/{id}", GetUtilisateursById);
            utilisateursitems.MapPost("/", CreateUtilisateur);
            utilisateursitems.MapPut("/{id}", UpdateUtilisateurs);
            utilisateursitems.MapDelete("/{id}", DeleteUtilisateur);
        }
        //AFFICHAGE DE TOUS LES UTILISATEURS
        public static async Task<IResult> GetAllUtilisateurs(UtilisateursDb db, InstrumentUtilisateurDb Db)
        {
            return TypedResults.Ok(await db.UtilisateursSet.ToArrayAsync());            
        }

        //RECHERCHE D'UTILISATEUR PAR ID
        public static async Task<IResult> GetUtilisateursById(int id, UtilisateursDb db)
        {
            return await db.UtilisateursSet.FindAsync(id)
                is Utilisateurs nouvelUtilisateur
                    ? Results.Ok(nouvelUtilisateur)
                    : Results.NotFound();
        }


        //AJOUT D'UN UTILISATEUR MULTI TABLES

        public static async Task<IResult> CreateUtilisateur(UtilisateurCreationDto utilisateurDto, UtilisateursDb utilisateursDb, InstrumentUtilisateurDb instrumentUtilisateurDb )
        {
            var nouvelUtilisateur = new Utilisateurs
            {
                Email = utilisateurDto.Email,
                motDePasse = utilisateurDto.motDePasse,
                Nom = utilisateurDto.Nom,
                Prenom = utilisateurDto.Prenom,
                Adresse1 = utilisateurDto.Adresse1,
                Adresse2 = utilisateurDto.Adresse2,
                CodePostal = utilisateurDto.CodePostal,
                Ville = utilisateurDto.Ville
            };

            utilisateursDb.UtilisateursSet.Add(nouvelUtilisateur);
            await utilisateursDb.SaveChangesAsync();

            foreach (var instrumentId in utilisateurDto.InstrumentIds)
            {
                var instrumentUtilisateur = new InstrumentUtilisateur
                {
                    UtilisateurId = nouvelUtilisateur.Id,
                    InstrumentId = instrumentId
                };

                instrumentUtilisateurDb.InstrumentUtilisateurSet.Add(instrumentUtilisateur);
            }

            await instrumentUtilisateurDb.SaveChangesAsync();

            return Results.Created($"/Utilisateursitems/{nouvelUtilisateur.Id}", nouvelUtilisateur);
        }

        //MODIFICATION D'UN UTILISATEUR
        public static async Task<IResult> UpdateUtilisateurs(int id, Utilisateurs inputUtilisateur, UtilisateursDb db)
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
            //utilisateurAModifier.NomInstrument = inputUtilisateur.NomInstrument;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        //SUPPRESSION D'UN UTILISATEUR
        public static async Task<IResult> DeleteUtilisateur(int id, UtilisateursDb db)
        {
            if (await db.UtilisateursSet.FindAsync(id) is Utilisateurs utilisateurASupprimer)
            {
                db.UtilisateursSet.Remove(utilisateurASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        }
    }
}
