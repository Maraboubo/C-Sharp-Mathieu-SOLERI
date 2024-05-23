using harmoniumApi.Context;
using Microsoft.EntityFrameworkCore;

namespace harmoniumApi.Controlers
{
    public static class InstrumentUtilisateurCtrl
    {
        public static void ControleurInstrumentUtilisateurs(this WebApplication appli)
        {
            var utilisateursitems = appli.MapGroup("/InstrumentUtilisateursitems");

            utilisateursitems.MapGet("/", GetAllInstrumentUtilisateurs);
            //utilisateursitems.MapGet("/{id}", GetUtilisateursById);
            //utilisateursitems.MapPost("/", CreateUtilisateur);
            //utilisateursitems.MapPut("/{id}", UpdateUtilisateurs);
            //utilisateursitems.MapDelete("/{id}", DeleteUtilisateur);
        }

        //AFFICHAGE DE TOUS LES UTILISATEURS
        public static async Task<IResult> GetAllInstrumentUtilisateurs(InstrumentUtilisateurDb db)
        {
            return TypedResults.Ok(await db.InstrumentUtilisateurSet.ToArrayAsync());
        }
    }
}
