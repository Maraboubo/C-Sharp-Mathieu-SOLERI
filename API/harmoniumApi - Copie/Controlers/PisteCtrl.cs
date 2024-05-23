using harmoniumApi.models;
using harmoniumApi.Context;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class PisteCtrl
    {
        public static void ControleurPiste(this WebApplication appli)
        {
            var pisteitems = appli.MapGroup("/Pisteitems");

            pisteitems.MapGet("/", GetAllPistes);
            pisteitems.MapGet("/{id}", GetPisteById);
            pisteitems.MapPost("/", CreatePiste);
            pisteitems.MapPut("/{id}", UpdatePiste);
            pisteitems.MapDelete("/{id}", DeletePiste);
        }
        //AFFICHAGE DE TOUTES LES PISTES
        public static async Task<IResult> GetAllPistes(PisteDb db)
        {
            return TypedResults.Ok(await db.PisteSet.ToArrayAsync());
        }

        //RECHERCHER PISTE PAR ID
        public static async Task<IResult> GetPisteById(int id, PisteDb db)
        {
            return await db.PisteSet.FindAsync(id)
                is Piste nouvellePiste
                    ? Results.Ok(nouvellePiste)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVELLE PISTE
        public static async Task<IResult> CreatePiste(Piste nouvellePiste, PisteDb database)
        {
            database.PisteSet.Add(nouvellePiste);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Pisteitems/{nouvellePiste.id_Piste}", nouvellePiste);
        }

        //MODIFICATION D'UNE PISTE
        public static async Task<IResult> UpdatePiste(int id, Piste inputPiste, PisteDb db)
        {
            var pisteAModifier = await db.PisteSet.FindAsync(id);

            if (pisteAModifier is null) return Results.NotFound();

            pisteAModifier.id_morceau = inputPiste.id_morceau;
            pisteAModifier.pNom = inputPiste.pNom;
            pisteAModifier.pImg = inputPiste.pImg;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        //SUPPRESSION D'UNE PISTE
        public static async Task<IResult> DeletePiste(int id, PisteDb db)
        {
            if (await db.PisteSet.FindAsync(id) is Piste PisteASupprimer)
            {
                db.PisteSet.Remove(PisteASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        }
    }
}
