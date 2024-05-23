using harmoniumApi.models;
using harmoniumApi.Context;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class ComposantsCtrl
    {
        public static void ControleurComposant(this WebApplication appli)
        {
            var composantitems = appli.MapGroup("/Composantitems");

            composantitems.MapGet("/", GetAllComposants);
            composantitems.MapGet("/{id}", GetComposantById);
            composantitems.MapPost("/", CreateComposant);
            composantitems.MapPut("/{id}", UpdateComposant);
            composantitems.MapDelete("/{id}", DeleteComposant);
        }
        //AFFICHAGE DE TOUTS LES COMPOSANTS
        public static async Task<IResult> GetAllComposants(ComposantDb db)
        {
            return TypedResults.Ok(await db.ComposantSet.ToArrayAsync());
        }

        //RECHERCHER COMPOSANT PAR ID
        public static async Task<IResult> GetComposantById(int id, ComposantDb db)
        {
            return await db.ComposantSet.FindAsync(id)
                is Composant nouveauComposant
                    ? Results.Ok(nouveauComposant)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEAU COMOPOSANT
        public static async Task<IResult> CreateComposant(Composant nouveauComposant, ComposantDb database)
        {
            database.ComposantSet.Add(nouveauComposant);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU COMPOSANT
            return Results.Created($"/Composantitems/{nouveauComposant.id_composant}", nouveauComposant);
        }

        //MODIFICATION D'UN COMPOSANT
        public static async Task<IResult> UpdateComposant(int id, Composant inputComposant, ComposantDb db)
        {
            var composantAModifier = await db.ComposantSet.FindAsync(id);

            if (composantAModifier is null) return Results.NotFound();

            composantAModifier.cNom = inputComposant.cNom;
            composantAModifier.cDateCrea = inputComposant.cDateCrea;
            composantAModifier.cDateModif = inputComposant.cDateModif;
            composantAModifier.cImg = inputComposant.cImg;
            composantAModifier.cFich = inputComposant.cFich;


            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        //SUPPRESSION D'UN COMPOSANT
        public static async Task<IResult> DeleteComposant(int id, ComposantDb db)
        {
            if (await db.ComposantSet.FindAsync(id) is Composant ComposantASupprimer)
            {
                db.ComposantSet.Remove(ComposantASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        }
    }
}
