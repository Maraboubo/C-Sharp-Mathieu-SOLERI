using harmoniumApi.models;
using harmoniumApi.Context;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class GroupesCtrl
    {
        public static void ControleurGroupes(this WebApplication appli)
        {
            var groupeitems = appli.MapGroup("/Groupeitems");

            groupeitems.MapGet("/", GetAllGroupes);
            groupeitems.MapGet("/{id}", GetGroupeById);
            groupeitems.MapPost("/", CreateGroupe);
            groupeitems.MapPut("/{id}", UpdateGroupe);
            groupeitems.MapDelete("/{id}", DeleteGroupe);
        }
        //AFFICHAGE DE TOUS LES GROUPES
        public static async Task<IResult> GetAllGroupes(GroupeDb db)
        {
            return TypedResults.Ok(await db.GroupeSet.ToArrayAsync());
        }

        //RECHERCHER UN GROUPE PAR ID
        public static async Task<IResult> GetGroupeById(int id, GroupeDb db)
        {
            return await db.GroupeSet.FindAsync(id)
                is Groupe nouveauGroupe
                    ? Results.Ok(nouveauGroupe)
                    : Results.NotFound();
        }

        //AJOUT D'UN NOUVEAU GROUPE
        public static async Task<IResult> CreateGroupe(Groupe nouveauGroupe, GroupeDb database)
        {
            database.GroupeSet.Add(nouveauGroupe);
            await database.SaveChangesAsync();

            //GENERATION D'ID POUR UN NOUVEAU GROUPE
            return Results.Created($"/Groupeitems/{nouveauGroupe.Id_Groupe}", nouveauGroupe);
        }

        //MODIFICATION D'UN GROUPE
        public static async Task<IResult> UpdateGroupe(int id, Groupe inputGroupe, GroupeDb db)
        {
            var groupeAModifier = await db.GroupeSet.FindAsync(id);

            if (groupeAModifier is null) return Results.NotFound();

            groupeAModifier.gNom = inputGroupe.gNom;
            groupeAModifier.gDate = inputGroupe.gDate;

            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        //SUPPRESSION D'UN GROUPE
        public static async Task<IResult> DeleteGroupe(int id, GroupeDb db)
        {
            if (await db.GroupeSet.FindAsync(id) is Groupe groupeASupprimer)
            {
                db.GroupeSet.Remove(groupeASupprimer);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        }
    }
}
