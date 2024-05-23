using harmoniumApi.Context;
using harmoniumApi.models;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class InstrumentCtrl
    {
        public static void ControleurInstruments(this WebApplication appli)
        {
            var instrumentsitems = appli.MapGroup("/Instrumentsitems");

            instrumentsitems.MapGet("/", GetAllInstruments);
            instrumentsitems.MapGet("/{id}", GetInstrumentsById);
            instrumentsitems.MapPost("/", CreateInstrument);
            instrumentsitems.MapPut("/{id}", UpdateInstruments);
            instrumentsitems.MapDelete("/{id}", DeleteInstruments);
        }
        //AFFICHAGE DE TOUS LES ALBUMS
        public static async Task<IResult> GetAllInstruments(InstrumentDb db)
        {
            return TypedResults.Ok(await db.InstrumentsSet.ToArrayAsync());
        }

        //RECHERCHER UN ALBUM PAR ID
        public static async Task<IResult> GetInstrumentsById(int id, InstrumentDb db)
        {
            return await db.InstrumentsSet.FindAsync(id)
                is Instrument nouvelInstrument
                    ? Results.Ok(nouvelInstrument)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEL ALBUM
        public static async Task<IResult> CreateInstrument(Instrument nouvelInstrument, InstrumentDb database)
        {
            database.InstrumentsSet.Add(nouvelInstrument);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Albumitems/{nouvelInstrument.Id}", nouvelInstrument);
        }

        //MODIFICATION D'UN ALBUM
        public static async Task<IResult> UpdateInstruments(int id, Instrument inputInstrument, InstrumentDb db)
        {
            var InstrumentAModifier = await db.InstrumentsSet.FindAsync(id);

            if (InstrumentAModifier is null) return Results.NotFound();

            InstrumentAModifier.Nom = inputInstrument.Nom;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        //SUPPRESSION D'UN ALBUM
        public static async Task<IResult> DeleteInstruments(int id, InstrumentDb db)
        {
            if (await db.InstrumentsSet.FindAsync(id) is Instrument InstrumentASupprimer)
            {
                db.InstrumentsSet.Remove(InstrumentASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        }
    }
}
