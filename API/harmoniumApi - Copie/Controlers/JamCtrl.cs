using harmoniumApi.models;
using harmoniumApi.Context;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class JamCtrl
    {
        public static void ControleurJam(this WebApplication appli)
        {
            var jamitems = appli.MapGroup("/Jamitems");

            jamitems.MapGet("/", GetAllJam);
            jamitems.MapGet("/{id}", GetJamById);
            jamitems.MapPost("/", CreateJam);
            jamitems.MapPut("/{id}", UpdateJam);
            jamitems.MapDelete("/{id}", DeleteJam);
        }
        //AFFICHAGE DE TOUTES LES JAM
        public static async Task<IResult> GetAllJam(JamDb db)
        {
            return TypedResults.Ok(await db.JamSet.ToArrayAsync());
        }

        //RECHERCHER JAM PAR ID
        public static async Task<IResult> GetJamById(int id, JamDb db)
        {
            return await db.JamSet.FindAsync(id)
                is Jam nouvelleJam
                    ? Results.Ok(nouvelleJam)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVELLE JAM
        public static async Task<IResult> CreateJam(Jam nouvelleJam, JamDb database)
        {
            database.JamSet.Add(nouvelleJam);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Morceauitems/{nouvelleJam.id_jam}", nouvelleJam);
        }

        //MODIFICATION D'UNE JAM
        public static async Task<IResult> UpdateJam(int id, Jam inputJam, JamDb db)
        {
            var jamAModifier = await db.JamSet.FindAsync(id);

            if (jamAModifier is null) return Results.NotFound();

            jamAModifier.jNom = inputJam.jNom;
            jamAModifier.jDateCrea = inputJam.jDateCrea;
            jamAModifier.jDateDif = inputJam.jDateDif;
            jamAModifier.jDur = inputJam.jDur;
            jamAModifier.jLink = inputJam.jLink;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        //SUPPRESSION D'UNE JAM
        public static async Task<IResult> DeleteJam(int id, JamDb db)
        {
            if (await db.JamSet.FindAsync(id) is Jam JamASupprimer)
            {
                db.JamSet.Remove(JamASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        }
    }
}
