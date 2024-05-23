using harmoniumApi.models;
using harmoniumApi.Context;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class MorceauxCtrl
    {
        public static void ControleurMorceaux(this WebApplication appli)
        {
            var morceauitems = appli.MapGroup("/Morceauitems");

            morceauitems.MapGet("/", GetAllMorceaux);
            morceauitems.MapGet("/{id}", GetMorceauById);
            morceauitems.MapPost("/", CreateMorceau);
            morceauitems.MapPut("/{id}", UpdateMorceau);
            morceauitems.MapDelete("/{id}", DeleteMorceau);
        }
        //AFFICHAGE DE TOUS LES MORCEAUX
        public static async Task<IResult> GetAllMorceaux(MorceauDb db)
        {
            return TypedResults.Ok(await db.Morceauitems.ToArrayAsync());
        }

        //RECHERCHER UN MORCEAU PAR ID
        public static async Task<IResult> GetMorceauById(int id, MorceauDb db)
        {
            return await db.Morceauitems.FindAsync(id)
                is Morceau nouveauMorceau
                    ? Results.Ok(nouveauMorceau)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEAU MORCEAU
        public static async Task<IResult> CreateMorceau(Morceau nouveauMorceau, MorceauDb database)
        {
            database.Morceauitems.Add(nouveauMorceau);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Morceauitems/{nouveauMorceau.id_morceau}", nouveauMorceau);
        }

        //MODIFICATION D'UN MORCEAU
        public static async Task<IResult> UpdateMorceau(int id, Morceau inputMorceau, MorceauDb db)
        {
            var morceauAModifier = await db.Morceauitems.FindAsync(id);

            if (morceauAModifier is null) return Results.NotFound();

            morceauAModifier.id_album = inputMorceau.id_album;
            morceauAModifier.id_utilisateur = inputMorceau.id_utilisateur;
            morceauAModifier.id_groupe = inputMorceau.id_groupe;
            morceauAModifier.mNom = inputMorceau.mNom;
            morceauAModifier.mImg = inputMorceau.mImg;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        //SUPPRESSION D'UN MORCEAU
        public static async Task<IResult> DeleteMorceau(int id, MorceauDb db)
        {
            if (await db.Morceauitems.FindAsync(id) is Morceau MorceauASupprimer)
            {
                db.Morceauitems.Remove(MorceauASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        }
    }
}
